using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFmpeg_EZ
{
    public partial class V_scaleSelectForm : Form
    {
        public V_scaleSelectForm()
        {
            InitializeComponent();

            PresetComboBox.SelectedIndex = 0;
            FARComboBox.Enabled = false;
        }

        private void V_scaleSelectForm_Load(object sender, EventArgs e)
        {
            if(preset == null) return;
            RARCheckBox.Checked = preset.RAR;
            FARCheckBox.Checked = preset.FAR;

            string width = "";
            string height = "";
            if (preset.RAR)
            {
                if (preset.width == -1) width = "auto";
                else width = Convert.ToString(preset.width);

                if (preset.height == -1) height = "auto";
                else height = Convert.ToString(preset.height);
            }
            else
            {
                if(preset.width != -1) width = Convert.ToString(preset.width);
                if (preset.height != -1) height = Convert.ToString(preset.height);
            }

            WidthTextBox.Text = width;
            HeightTextBox.Text = height;

            FARComboBox.SelectedIndex = preset.FARselIndex;
        }


        //////          PUBLIC           //////
        // PUBLIC Var
        public Selection selection = null;
        public Selection preset = null;
        public bool isConfirmed = false;





        // PUBLIC Class
        public class Selection
        {
            public bool RAR = false;
            public bool FAR = false;
            public sbyte FARselIndex = -1;
            public int width = -1;
            public int height = -1;
        }

        



        //////          PRIVATE          //////
        /// Var
        private string widthBackup = "";
        private sbyte FARSelectedIndex = -1;
        private readonly short[,] presetDimensions = new short[,] {
            {-1, -1},
            {7680, 4320},
            {3840, 2160},
            {2560, 1440},
            {1920, 1080},
            {1280, 720},
            {720, 480},
            {480, 360},
            {320, 240},
            {192, 144}
        };


        /// Functions
        private void updateFormData()
        {
            TextBox wTB = WidthTextBox;
            TextBox hTB = HeightTextBox;


            // reset old states
            if (wTB.ForeColor != Color.Black && wTB.Text != "auto") wTB.ForeColor = Color.Black;
            if (hTB.ForeColor != Color.Black && hTB.Text != "auto") hTB.ForeColor = Color.Black;
            WarnLabel.Text = "";


            // prevent too big value
            if (wTB.Text.Length > 5|| hTB.Text.Length > 5)
            {
                WarnLabel.Text = "dimensions too Big!";
                if(wTB.Text.Length > 5) wTB.ForeColor = Color.Red;
                if(hTB.Text.Length > 5) hTB.ForeColor = Color.Red;
                PixelsTextBox.Text = "-";
                return;
            }


            //calculate resolution pixels
            if(wTB.Text == "auto" || hTB.Text == "auto") PixelsTextBox.Text = "-";
            else
            {
                ulong pixels = Convert.ToUInt64(
                    Convert.ToUInt16((wTB.Text == "") ? "0" : wTB.Text) *
                    Convert.ToUInt16((hTB.Text == "") ? "0" : hTB.Text)
                );

                if (pixels > 1_000_000)
                {
                    PixelLabel.Text = "Mega pixels";
                    PixelsTextBox.Text = (Math.Round(
                        (double)(pixels) / 1_000_000
                    , 3, MidpointRounding.AwayFromZero)).ToString();
                }else if(pixels > 3000)
                {
                    PixelLabel.Text = "Kilo pixels";
                    PixelsTextBox.Text = (
                        (double)(pixels) / 1000
                    ).ToString();
                }
                else
                {
                    PixelLabel.Text = "pixels";
                    PixelsTextBox.Text = (
                        pixels
                    ).ToString();
                }
            }


            if (!RARCheckBox.Checked) { return; }
            if (wTB.Text == "" || wTB.Text == "0")
            {
                wTB.Text = "auto";
                wTB.ForeColor = Color.Blue;


            } else if (hTB.Text == "" || hTB.Text == "0")
            {
                hTB.Text = "auto";
                hTB.ForeColor = Color.Blue;
            }

        }








        ////////// Event handler Functions /////////////
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            this.isConfirmed = true;
            selection = new Selection();
            selection.RAR = RARCheckBox.Checked;
            selection.FAR = FARCheckBox.Checked;
            selection.FARselIndex = FARSelectedIndex;

            int w = 0;
            int h = 0;
            TextBox[] dimentionBox = new TextBox[] { WidthTextBox, HeightTextBox };
            foreach(TextBox tb in dimentionBox)
            {
                if(tb.Text == ""||tb.Text == "0"||tb.Text == "auto")
                {
                    if (w == 0) w = -1;
                    else if(h == 0) h = -1;
                    continue;
                }

                if (w == 0) w = Convert.ToInt32(tb.Text);
                else if (h == 0) h = Convert.ToInt32(tb.Text);
            }

            if (w == -1&&h == -1) selection = null;
            else
            {
                selection.width = w;
                selection.height = h;
            }
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            RARCheckBox.Checked = false;
            FARCheckBox.Checked = false;
            PresetComboBox.SelectedIndex = 0;
            FARComboBox.SelectedIndex = -1;
            WidthTextBox.Text = "";
            HeightTextBox.Text = "";
            widthBackup = "";

            updateFormData();
        }

        private void WidthTextBox_TextChanged(object sender, EventArgs e)
        {
            if (WidthTextBox.Text == "auto") return;
            // remove any non Numbers char
            WidthTextBox.Text = Regex.Replace(WidthTextBox.Text, @"[^0-9]+", "");

            if (
                FARCheckBox.Checked&&
                WidthTextBox.Text != ""&&
                WidthTextBox.Focused&&
                WidthTextBox.Text.Length < 5
            ){
                ushort width = Convert.ToUInt16(WidthTextBox.Text);
                float[] ratio = new float[2];
                string[] sRatio = FARComboBox.Items[FARComboBox.SelectedIndex].ToString().Split(':');
                for (byte i = 0; i < sRatio.Length; i++) ratio[i] = Convert.ToSingle(sRatio[i]);

                // height = width / ratio
                string sHeight = Math.Round(
                    width * (ratio[1] / ratio[0])
                ).ToString();

                if(HeightTextBox.Text != sHeight) HeightTextBox.Text = sHeight;
            }
            updateFormData();
        }

        private void HeightTextBox_TextChanged(object sender, EventArgs e)
        {
            if(HeightTextBox.Text == "auto") return;
            // remove any non Numbers char
            HeightTextBox.Text = Regex.Replace(HeightTextBox.Text, @"[^0-9]+", "");

            if (
                FARCheckBox.Checked&&
                HeightTextBox.Text != ""&&
                HeightTextBox.Focused&&
                HeightTextBox.Text.Length < 5
            ){
                ushort height = Convert.ToUInt16(HeightTextBox.Text);
                float[] ratio = new float[2];
                string[] sRatio = FARComboBox.Items[FARComboBox.SelectedIndex].ToString().Split(':');
                for (byte i = 0; i < sRatio.Length; i++) ratio[i] = Convert.ToSingle(sRatio[i]);

                // width = height * ratio
                string sWidth = Math.Round(
                    height * (ratio[0] / ratio[1])
                ).ToString();
                
                if(WidthTextBox.Text != sWidth) WidthTextBox.Text = sWidth;
            }
            updateFormData();
        }

        private void RARCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // prevent two checkbox from both being `checked`
            if (FARCheckBox.Checked&&RARCheckBox.Checked) FARCheckBox.Checked = false;
            TextBox wTB = WidthTextBox;
            TextBox hTB = HeightTextBox;
            //selection.RAR = RARCheckBox.Checked;

            if (RARCheckBox.Checked)
            {
                widthBackup = wTB.Text;
                wTB.Text = "auto";
                wTB.ForeColor = Color.Blue;
            } else
            {
                if (wTB.Text == "auto")
                {
                    wTB.Text = widthBackup;
                    wTB.ForeColor = Color.Black;
                }
                if (hTB.Text == "auto")
                {
                    hTB.Text = "0";
                    hTB.ForeColor = Color.Black;
                }
            }
            updateFormData();
        }

        private void PresetComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selIndex = PresetComboBox.SelectedIndex;
            if (selIndex == 0) return;

            WidthTextBox.Text = presetDimensions[selIndex,0].ToString();
            HeightTextBox.Text = presetDimensions[selIndex,1].ToString();

            RARCheckBox.Checked = false;
            updateFormData();
        }

        private void PresetComboBox_Leave(object sender, EventArgs e)
        {
            // reset text in combobox incase user type sometings
            int selIndex = PresetComboBox.SelectedIndex;
            if (selIndex == -1) return;
            //MessageBox.Show(PresetComboBox.Items[selIndex].ToString());
            PresetComboBox.Text = PresetComboBox.Items[selIndex].ToString();
            updateFormData();
        }

        private void FARCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // prevent two checkbox from both being `checked`
            if (RARCheckBox.Checked&&FARCheckBox.Checked) RARCheckBox.Checked = false;
            //selection.FAR = FARCheckBox.Checked;

            if(FARCheckBox.Checked)
            {
                FARComboBox.SelectedIndex = FARSelectedIndex;
                FARComboBox.Enabled = true;
            }
            else
            {
                FARComboBox.SelectedIndex = -1;
                FARComboBox.Enabled = false;
            }

            updateFormData();
        }

        private void FARComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FARComboBox.SelectedIndex == -1) return;
            FARSelectedIndex = (sbyte)FARComboBox.SelectedIndex;
        }

       
    }
}
