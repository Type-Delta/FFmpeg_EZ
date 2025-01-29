using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFmpeg_EZ.subform
{
    public partial class SimStrmMappingForm : Form
    {
        public SimStrmMappingForm()
        {
            InitializeComponent();


            // initialize InputsList
            {
                foreach(App.InputFile file in App.Sim_inputFiles)
                {
                    if (file.info == null) continue;
                    inputFileCount++;
                    addInputListBox(InputPanel, file);                    
                }

                byte fileIdex = 0;
                foreach (ListBox lb in InputFileListBoxs)
                {
                    for (byte i = 0; i < lb.Items.Count; i++)
                    {
                        DragAble dab = new DragAble();
                        string itemName = lb.Items[i].ToString();
                        if(itemName.Contains(" "))
                        {
                            dab.streamIndexByType = (byte)(Convert.ToByte(itemName.Split(' ').Last()) - 1);
                            itemName = itemName.Split(' ')[0];
                        }

                        dab.rectangle = lb.absoluteRec(lb.GetItemRectangle(i));
                        dab.parentListBox = lb;
                        dab.inputSimpleID = lb.Tag.ToString(); // id of the File
                        dab.streamIndex = i;
                        dab.streamType = itemName; // type [video|audio|subtitle]
                        dab.fileIndex = fileIdex;
                        dragAbleList.Add(dab);

                        AppControl.DragNDrop dnd = new AppControl.DragNDrop();
                        dnd.OnDropEvent += ControlEven_OnDropEvent;
                        dndHandelers.Add(dnd);
                    }

                    fileIdex++;
                }
            }


            // tool tip
            Tooltip1.SetToolTip(MoveLeftButton, "Move selected stream Left");
            Tooltip1.SetToolTip(MoveRightButton, "Move selected stream Right");
            Tooltip1.SetToolTip(MoveAllLeftButton, "Move All streams to Left");
            Tooltip1.SetToolTip(
                InputPanel,
                "Tip: you can drag and drop stream direcly on the Output"
            );

            DragIconPictureBox_dropReady.Visible = false;
            DragIconPictureBox.Visible = false;
        }

        private void SimStrmMappingForm_Load(object sender, EventArgs e)
        {
            loadPreset();
            timer1.Start();
        }







        //////          PUBLIC           //////
        // PUBLIC var
        public Selection selection = null;
        public Selection preset = null;
        public bool isConfirmed = false;


        // PUBLIC Class
        public class Selection
        {
            public List<string> stringSelectCode = new List<string>();
            public List<DragAble> infoList = new List<DragAble>();
            public bool disableVideo = false;
            public bool disableAudio = false;
            public bool disableSubtitle = false;
            public bool disableData = false;
        }







        //////          PRIVATE          //////
        /// PRIVATE var ///
        //private List
        private List<string> outputStrmSelect = new List<string>();
        private List<DragAble> outputStrmInfoList = new List<DragAble>();
        
        // InputListBox Config
        private const short lbStartYPos = 48;
        private const short lbStartXPos = 13;
        private const short lbSpacing = 26;
        private const short lbWidth = 121;
        private const short lbHeight = 64;
        private const short labHeight = 18; //input label height

        private ushort inputFileCount = 0;

        private List<DragAble> dragAbleList = new List<DragAble>();
        private List<AppControl.DragNDrop> dndHandelers = new List<AppControl.DragNDrop>();

        //system
        private sbyte selFileIndex = -1;
        private bool pauseCheckChangeCheck = false;


        /// PRIVATE Class
        
        
        public class DragAble
        {
            //FFmpeg MapFormat > `fileIndex:streamType:streamIndex`
            public Rectangle rectangle;
            public ListBox parentListBox;
            public string inputSimpleID;
            public string streamType; // ["video"|"audio"|"subtitle"]
            public byte streamIndexByType = 0; //index of stream of its type
            public byte streamIndex = 0;
            public byte fileIndex = 0;
        }








        private void addInputListBox(Panel panel, App.InputFile file)
        {
            ListBox lb = new ListBox();
            Label lab = new Label();

            lb.SuspendLayout();
            lab.SuspendLayout();
            lb.FormattingEnabled = true;
            lb.ItemHeight = 20;
            byte vCount, aCount, sCount;
            vCount = aCount = sCount = 0;
            foreach (App.FileInfo.StreamInfo strm in file.info.streams)
            {
                if(!strm.available()) continue; 
                string itemLabel = $"{strm.streamType}";
                switch (strm.streamType)
                {
                    case "video": itemLabel += (file.info.v_streamCount > 1 ? $" {++vCount}" :"");
                        break;
                    case "audio": itemLabel += (file.info.a_streamCount > 1 ? $" {++aCount}" : "");
                        break;
                    case "subtitle": itemLabel += (file.info.s_streamCount > 1 ? $" {++sCount}" : "");
                        break;
                }
                lb.Items.Add(itemLabel);
            }
            if(InputFileListBoxs.Count == 0) lb.Location = new Point(lbStartXPos, lbStartYPos);
            else lb.Location = new Point(
                lbStartXPos,
                lbStartYPos + ((lbSpacing + lbHeight) * InputFileListBoxs.Count)
            );
            lb.Name = $"inputListBox{InputFileListBoxs.Count}";
            lb.BackColor = Color.DarkGray;
            lb.BorderStyle = BorderStyle.None;
            lb.ForeColor = SystemColors.MenuBar;
            lb.Size = new Size(lbWidth, lbHeight);
            lb.TabIndex = 1;
            lb.SelectedIndexChanged += InputFile_SelectChanged;
            lb.Tag = ((ushort)inputFileCount).ToCharID();

            lab.AutoSize = true;
            lab.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            lab.ForeColor = SystemColors.GradientActiveCaption;
            lab.Location = new Point(
                lbStartXPos - 3,
                lbStartYPos + ((lbSpacing + lbHeight) * InputFileListBoxs.Count) - 18
            );
            lab.Name = $"inputLabel{InputFileListBoxs.Count}";
            lab.Size = new Size(lbWidth, labHeight);
            lab.TabIndex = 3;
            lab.Text = file.name + $" ({((ushort)inputFileCount).ToCharID()})";

            panel.Controls.Add(lb);
            panel.Controls.Add(lab);
            InputFileListBoxs.Add(lb);
            InputLabels.Add(lab);

            lb.ResumeLayout();
            lab.ResumeLayout();
        }

        //private int countAZ(string s) => s.Length - Regex.Replace(s, @"[a-zA-Z]", "").Length;




        public void loadPreset()
        {
            if (preset == null) return;
            outputStrmInfoList = preset.infoList;

            OutputListBox.Items.Clear();
            foreach(DragAble outputStrmInfo in preset.infoList.ToList())
            {
                addInputStream(outputStrmInfo);
            }

            if (preset.disableVideo) IncVCheckBox.Checked = true;
            if (preset.disableAudio) IncACheckBox.Checked = true;
            if (preset.disableSubtitle) IncSCheckBox.Checked = true;
            if (preset.disableData) IncDCheckBox.Checked = true;
        }



        private void addInputStream(DragAble info)
        {
            OutputListBox.Items.Add(info.streamType.ToString() + $" {info.parentListBox.Tag}");
            outputStrmInfoList.Add(info);
        }


        private void removeInputStream(short index = -1)
        {
            if(index == -1)
            {
                OutputListBox.Items.Clear();
                outputStrmInfoList.Clear();
                return;
            }

            for(byte i = 0; i < outputStrmInfoList.Count; i++)
            {
                DragAble dab = outputStrmInfoList[i];
                if ($"{dab.streamType} {dab.parentListBox.Tag}" != OutputListBox.Items[index].ToString()) continue;
                outputStrmInfoList.RemoveAt(i);
                break;
            }
            OutputListBox.Items.RemoveAt(index);

        }











        ////////// Event handler Functions /////////////
        // custom Event, see control.cs 
        private void ControlEven_OnDropEvent(object sender, AppControl.DragNDropEventArgs e)
        {
            //label3.Text = $"Pos {e.MousePos.X}X {e.MousePos.Y}Y\nindex {e.DragItemData.streamIndex}";
            
            if (e.MousePos.isInBoundOf(OutputListBox))
            {
                addInputStream(e.DragItemData);
            }
        }

        private void MoveRightButton_Click(object sender, EventArgs e)
        {
            foreach(ListBox lb in InputFileListBoxs)
            {
                if (lb.SelectedIndex == -1) continue;
                foreach(DragAble dab in dragAbleList)
                {
                    if(dab.parentListBox.Name != lb.Name) continue;
                    if (dab.streamIndex != lb.SelectedIndex) continue;
                    addInputStream(dab);
                    return;
                }
            }
        }

        private void InputFile_SelectChanged(object sender, EventArgs e)
        {
            Point mousePos = PointToClient(MousePosition);
            for (short i = 0; i < InputFileListBoxs.Count; i++)
            {
                ListBox lb = InputFileListBoxs[i];

                if (mousePos.isInBoundOf(lb))
                {
                    selFileIndex = (sbyte) i;
                }
                else lb.SelectedIndex = -1;
            }
        }

        private void MoveLeftButton_Click(object sender, EventArgs e)
        {
            removeInputStream((short) OutputListBox.SelectedIndex);
        }

        private void MoveAllLeftButton_Click(object sender, EventArgs e)
        {
            removeInputStream();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            this.isConfirmed = false;
            selection = new Selection();

            foreach (DragAble outputStrmInfo in outputStrmInfoList)
            {
                string strmCode = "";
                App.FileInfo fInfo = App.Sim_inputFiles[outputStrmInfo.fileIndex].info;

                strmCode += $"{outputStrmInfo.fileIndex}";
                switch (outputStrmInfo.streamType)
                {
                    case "video":
                        strmCode += ":v";
                        if (fInfo.v_streamCount == 1) break;
                        strmCode += $":{outputStrmInfo.streamIndexByType}";
                        break;
                    case "audio":
                        strmCode += ":a";
                        if (fInfo.a_streamCount == 1) break;
                        strmCode += $":{outputStrmInfo.streamIndexByType}";
                        break;
                    case "subtitle":
                        strmCode += ":s";
                        if (fInfo.s_streamCount == 1) break;
                        strmCode += $":{outputStrmInfo.streamIndexByType}";
                        break;
                }

                selection.stringSelectCode.Add(strmCode);          
            }

            selection.infoList = outputStrmInfoList;
            if (!IncVCheckBox.Checked) selection.disableVideo = true;
            if (!IncACheckBox.Checked) selection.disableAudio = true;
            if (!IncSCheckBox.Checked) selection.disableSubtitle = true;
            if (!IncDCheckBox.Checked) selection.disableData = true;

            if (
                outputStrmInfoList.Count == 0&&
                IncVCheckBox.Checked&&IncACheckBox.Checked&&
                IncSCheckBox.Checked&&IncDCheckBox.Checked               
            ) selection = null;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void ResetButton_Click(object sender, EventArgs e)
        {
            OutputListBox.Items.Clear();
            outputStrmInfoList.Clear();

            pauseCheckChangeCheck = true;
            IncVCheckBox.Checked = true;
            IncACheckBox.Checked = true;
            IncSCheckBox.Checked = true;
            IncDCheckBox.Checked = true;
            pauseCheckChangeCheck = false;
        }



        // called when any checkBoxs CheckedChanged
        private void IncCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (pauseCheckChangeCheck) return;

            if (
                !(IncVCheckBox.Checked && IncACheckBox.Checked &&
                IncSCheckBox.Checked && IncDCheckBox.Checked)
            )
            {
                Tooltip1.SetToolTip(
                    OutputListBox,
                    "some Stream type are disabled\nthose won't be include in output file\neven it being specified here"
                );
            }
            else Tooltip1.SetToolTip(OutputListBox, null);
        }









        ////////// Tick Functions /////////////
        private void timer1_Tick(object sender, EventArgs e)
        {
            // For Debug //
            /*if (PointToClient(MousePosition).isInBoundOf(OutputListBox, b))
            {
                label1.Text = "in bound!";
            }
            else label1.Text = "out bound";// PointToClient

            Point mousePos = PointToClient(MousePosition);
            label2.Text = $"{mousePos.X}X, {mousePos.Y}Y";*/

            for (byte i = 0; i < dndHandelers.Count; i++)
            {
                AppControl.DragNDrop handeler = dndHandelers[i];
                DragAble dragAble = dragAbleList[i];
                // dragAble.itemIndex
                handeler.HandleDragNDrop(
                    dragAble.rectangle,
                    PointToClient(MousePosition),
                    DragIconPictureBox,
                    DragIconPictureBox_dropReady,
                    dragAble,
                    OutputListBox.absoluteRec(OutputListBox.ClientRectangle)
                );
            }
        }

        
    }
}
