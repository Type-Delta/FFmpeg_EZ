using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FFmpeg_EZ
{
    public partial class V_cropSelectForm : Form
    {
        public V_cropSelectForm()
        {
            InitializeComponent();

            //
            /*file = new App.InputFile();
            file.info = new App.FileInfo();
            file.info.streams = new List<App.FileInfo.StreamInfo>();
            file.info.streams.Add(
                new App.FileInfo.StreamInfo()
            );
            file.info.streams[0].ratio = new float[2] { 16, 9 };
            file.info.streams[0].dimension = new ushort[2] { 1920, 1080 };
            file.info.streams[0].streamType = "video";*/
            //
        }


        private void V_cropSelectForm_Load(object sender, EventArgs e)
        {
            if (file == null) throw new Exception("Internal Error: (input) var `V_cropSelectForm.file` not set");
            fileDimension = file.info.getBestStream("video").dimension;
            fileRatio = file.info.getBestStream("video").ratio;
            RMlabelDefFont = RMlabel.Font;
            referencFromSSL.Text = $"dimension from: {file.name}";

            defaultCanvasSize = PreviewPanel_canvas.Size;
            System.Drawing.Size defSize = defaultCanvasSize;
            if (fileRatio == null) throw new Exception(
                "Internal Error: `V_cropSelectForm.file` does not contains any Video ratio"
            );





            // calculate canvas size
            ushort w = (ushort)(defSize.Height * (fileRatio[0] / fileRatio[1])); // cal width
            // capping width size from exceeding more than 87% of Form width
            if (w > (this.Width * 0.87)) w = (ushort)Math.Round(this.Width * 0.87);
            ushort h = (ushort)(w * (fileRatio[1] / fileRatio[0])); // cal height
            canvasSize = new Size(w, h);

            selecting_ratio = fileRatio;
            rmCanvasSize = PreviewPanel_remainds.Size = PreviewPanel_canvas.Size = canvasSize;

            // calaulate position to center the canvas
            /* v=leftWinEdge           v=rightWinEdge
             *  ______________________  <=topWinEdge
             * |        Window        |
             * |   ____________       | <=topEdge
             * |  |            |      |
             * |  |   canvas   |      |
             * |  |____________|      | <=bottomEdge
             * |______________________| <=bottomWinEdge
             *    ^=leftEdge   ^=rightEdge
             * l__l=leftPadding 
             *                 l______l=rightPadding
             * Note1: (0, 0) pos is the upleft cornner of the Form
             * Note2: bottom of Window here is not an actual bottom of the Form
             *      but the top of the GroupBox below
             */
            int leftEdge = PreviewPanel_canvas.Location.X;
            int rightEdge = PreviewPanel_canvas.Location.X + canvasSize.Width;
            int topEdge = PreviewPanel_canvas.Location.Y;
            int bottomEdge = PreviewPanel_canvas.Location.Y + canvasSize.Height;
            const int leftWinEdgeOffset = 17; // leftWinEdge + offset
            const int topWinEdge = 0;
            int bottomWinEdge = groupBox.Location.Y;
            int rightWinEdge = this.Width;

            // calculate X position
            int leftPadding = leftEdge - leftWinEdgeOffset;
            int rightPadding = rightWinEdge - rightEdge;
            int Xpadding = (leftPadding + rightPadding) / 2; // total distance of left & right padding / 2

            // calculate Y position
            int topPadding = topEdge - topWinEdge;
            int bottomPadding = bottomWinEdge - bottomEdge;
            int Ypadding = (topPadding + bottomPadding) / 2;

            // set PreviewPanel_canvas location (gray)
            PreviewPanel_canvas.Location = new Point(
                Xpadding,
                Ypadding
            );
            // set PreviewPanel_remainds location to the same as PreviewPanel_canvas
            rmCanvasPos = PreviewPanel_remainds.Location = PreviewPanel_canvas.Location;
            RT_XOffset = (short)PreviewPanel_canvas.Location.X;
            RT_YOffset = (short)PreviewPanel_canvas.Location.Y;


            WidthNumUD.Maximum = fileDimension[0];
            HeightNumUD.Maximum = fileDimension[1];
            WidthNumUD.Value = fileDimension[0];
            HeightNumUD.Value = fileDimension[1];

            loadPreset();

            initializing = false;
            updateRMCanvas();

            PreviewPanel_remainds.Visible = true;

            if (processOpt.v_scale != null)
                WarnLabel.Text = "Warning: the End result may look diffrent when use this option with Video croping";
            timer1_60.Start();
        }


        //////          PUBLIC           //////
        // PUBLIC var
        public App.InputFile file = null;
        public App.ProcessOptions processOpt = null;
        public Selection selection = null;
        public Selection preset = null;
        public bool isConfirmed = false;


        // PUBLIC Class
        public class Selection
        {
            public short width = -1;
            public short height = -1;
            public int x = 0;
            public int y = 0;
        }




        //////          PRIVATE          //////
        /// PRIVATE var ///
        private System.Drawing.Size defaultCanvasSize; //canvas size before init
        private System.Drawing.Size canvasSize; //target canvas size after init
        private float[] selecting_ratio = null;
        private ushort[] selecting_pos = new ushort[2] {0, 0};
        private ushort[] fileDimension = null; //original file Dimension
        private float[] fileRatio = null; //original file Ratio
        private Font RMlabelDefFont; //default font
        private const string defaultRMlabelText = "Remaining Area";
        private short rmWidth = -1; // remainingWidth (real size)
        private short rmHeigth = -1;
        private int rmX = 0; //remainingX (real position)
        private int rmY = 0; 

        //Relative data (the smaller Size, Pos of the Media relative to real Media data)
        private System.Drawing.Size rmCanvasSize; //remainingCanvasSize
        private System.Drawing.Point rmCanvasPos; //remainingCanvasPos
        private short RT_XOffset;
        private short RT_YOffset;
        private short rmWidth_RT = -1;
        private short rmHeigth_RT = -1;
        private int rmX_RT = 0; //reminingX(relative position)
        private int rmY_RT = 0; //reminingY(relative position)

        //Config
        const byte minRMWidth = 20;
        const byte minRMHeight = 20;


        //SYSTEM
        private bool initializing = true;




        /// PRIVATE Functions ///
        private void loadPreset()
        {
            if (preset == null) return;
            WidthNumUD.Value = preset.width;
            HeightNumUD.Value = preset.height;
            PosXNumUD.Value = preset.x;
            PosYNumUD.Value = preset.y;
        }
        
        
        private void updateRMCanvas()
        {
            if (initializing) return;
            // update data
            rmWidth = (short) WidthNumUD.Value;
            rmHeigth = (short) HeightNumUD.Value;
            rmX = (int) PosXNumUD.Value;
            rmY = (int) PosYNumUD.Value;


            // calculate Relative data
            // RT-data = raw * (min / max)
            rmWidth_RT = (short) (rmWidth * ((float)canvasSize.Width / fileDimension[0]));
            rmHeigth_RT = (short) (rmHeigth * ((float)canvasSize.Height / fileDimension[1]));
            rmX_RT = (int)(rmX * ((float)canvasSize.Width / fileDimension[0]));
            rmY_RT = (int)(rmY * ((float)canvasSize.Height / fileDimension[1]));


            /// set Canvas Size
            rmCanvasSize = new Size(
                rmWidth_RT, rmHeigth_RT    
            );

            /// set Canvas Locations
            rmCanvasPos = new Point(
                (ushort)RT_XOffset + rmX_RT, (ushort)RT_YOffset + rmY_RT
            );


            // prevent rmCanvas from expand out of Canvas (gray pannel)
            if(rmCanvasSize.Width + rmCanvasPos.X > PreviewPanel_canvas.Location.X + canvasSize.Width)
            {// modify Width
                int overAmu = (rmCanvasSize.Width + rmCanvasPos.X) - (PreviewPanel_canvas.Location.X + canvasSize.Width);
                rmCanvasSize = new Size(
                    rmCanvasSize.Width - overAmu, rmCanvasSize.Height
                );
            }
            if(rmCanvasSize.Height + rmCanvasPos.Y > PreviewPanel_canvas.Location.Y + canvasSize.Height)
            {
                int overAmu = (rmCanvasSize.Height + rmCanvasPos.Y) - (PreviewPanel_canvas.Location.Y + canvasSize.Height);
                rmCanvasSize = new Size(
                    rmCanvasSize.Width, rmCanvasSize.Height - overAmu
                );
            }



            PreviewPanel_remainds.Size = rmCanvasSize;
            PreviewPanel_remainds.Location = rmCanvasPos;


            // modify label
            if (rmCanvasSize.Height < minRMHeight || rmCanvasSize.Width < minRMWidth)
            {
                RMlabel.Visible = false;
            }
            else if (rmCanvasSize.Width * 1.3 < rmCanvasSize.Height) // if hight is larger than 130% of width...
            { // ...rotate & resize Label
                RMlabel.Text = defaultRMlabelText;
                float fontSize = (float)(
                    (RMlabelDefFont.Size * ((float)rmCanvasSize.Height / (float)defaultCanvasSize.Width)) * 0.45
                );
                RMlabel.Font = RMlabel.Font.changeFontSize(fontSize);
                char[] text = RMlabel.Text.ToCharArray(); // split every characters to char[]
                RMlabel.Text = "";
                foreach (char c in text) RMlabel.Text += $"{c}\n";
                int labelCenterPosX = ((rmCanvasSize.Width - RMlabel.Width) / 2) + 1;
                int labelCenterPosY = ((rmCanvasSize.Height - RMlabel.Height) / 2) - 1;
                RMlabel.Location = new Point(labelCenterPosX, labelCenterPosY);
                RMlabel.Visible = true;

            }
            else if (rmCanvasSize.Width < RMlabel.Width)
            {
                RMlabel.Text = defaultRMlabelText;
                float fontSize = (float)(
                    (RMlabelDefFont.Size * ((float)rmCanvasSize.Width / (float)defaultCanvasSize.Width)) * 1.3
                );
                RMlabel.Font = App.changeFontSize(RMlabel.Font, fontSize);
                RMlabel.Text = RMlabel.Text.Replace(" ", "\n");
                int labelCenterPosX =  ((rmCanvasSize.Width - RMlabel.Width) / 2) + 1;
                int labelCenterPosY = ((rmCanvasSize.Height - RMlabel.Height) / 2) + 1;
                RMlabel.Location = new Point(labelCenterPosX, labelCenterPosY);
                RMlabel.Visible = true;
            }
            else
            {
                RMlabel.Text = defaultRMlabelText;
                float fontSize = (float)(
                    (RMlabelDefFont.Size * ((float)rmCanvasSize.Width / (float)defaultCanvasSize.Width))
                );
                RMlabel.Font = App.changeFontSize(RMlabel.Font, fontSize);
                int labelCenterPosX =  ((rmCanvasSize.Width - RMlabel.Width) / 2) + 1;
                int labelCenterPosY = ((rmCanvasSize.Height - RMlabel.Height) / 2) + 1;
                RMlabel.Location = new Point(labelCenterPosX, labelCenterPosY);
                RMlabel.Visible = true;
            }
        
        
        }


        ////////// Event handler Functions /////////////
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            this.isConfirmed = true;
            selection = new Selection();
            selection.width = (short) WidthNumUD.Value;
            selection.height = (short) HeightNumUD.Value;
            selection.x = (int) PosXNumUD.Value;
            selection.y = (int) PosYNumUD.Value;

            if (selection.width == fileDimension[0] && selection.height == fileDimension[1] && selection.x + selection.y == 0) selection = null;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            initializing = true;
            WidthNumUD.Maximum = fileDimension[0];
            HeightNumUD.Maximum = fileDimension[1];
            WidthNumUD.Value = fileDimension[0];
            HeightNumUD.Value = fileDimension[1];
            initializing = false;

            PosXNumUD.Value = 0;
            PosYNumUD.Value = 0;

            updateRMCanvas();
        }






        ////////// Tick Functions /////////////
        private void timer1_60_Tick(object sender, EventArgs e)
        {
            Point mousePos = PointToClient(MousePosition);
            Point mouse = new Point(
                mousePos.X - PreviewPanel_canvas.Location.X,
                mousePos.Y - PreviewPanel_canvas.Location.Y
            );
            

            if (
               !PreviewPanel_canvas.ClientRectangle.Contains(mouse)
              )
            {
                if (relativeMousePosSSL.Text != "Pos -X, -Y") relativeMousePosSSL.Text = "Pos -X, -Y";
                return;
            }

            short mIncanvasPosX_RT = (short)(mouse.X - PreviewPanel_canvas.Location.X);
            short mIncanvasPosY_RT = (short)(mouse.Y - PreviewPanel_canvas.Location.Y);

            int mIncanvasPosX = (int)(mIncanvasPosX_RT / ((float)canvasSize.Width / fileDimension[0]));
            int mIncanvasPosY = (int)(mIncanvasPosY_RT / ((float)canvasSize.Height / fileDimension[1]));
            relativeMousePosSSL.Text = $"Pos {mIncanvasPosX}X, {mIncanvasPosY}Y";
        }




        ////////// SYSTEM Function /////////////
        private void noDING(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) e.Handled = e.SuppressKeyPress = true;
        }


        private void WidthNumUD_ValueChanged(object sender, EventArgs e)
        {
            updateRMCanvas();
        }

        private void HeightNumUD_ValueChanged(object sender, EventArgs e)
        {
            updateRMCanvas();
        }

        private void PosXNumUD_ValueChanged(object sender, EventArgs e)
        {
            updateRMCanvas();
        }

        private void PosYNumUD_ValueChanged(object sender, EventArgs e)
        {
            updateRMCanvas();
        }

        // shut the DING!
        private void WidthNumUD_KeyDown(object sender, KeyEventArgs e) => noDING(e);
        private void HeightNumUD_KeyDown(object sender, KeyEventArgs e) => noDING(e);
        private void PosXNumUD_KeyDown(object sender, KeyEventArgs e) => noDING(e);
        private void PosYNumUD_KeyDown(object sender, KeyEventArgs e) => noDING(e);

        
    }
}
