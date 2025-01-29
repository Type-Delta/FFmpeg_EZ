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
    public partial class TimeSessionSelectForm : Form
    {
        public TimeSessionSelectForm()
        {
            InitializeComponent();
        }

        private void TimeSessionSelectForm_Load(object sender, EventArgs e)
        {
            parseInputFileDuration();
            // using preset incases TimeSession has already selected for this item
            if (preset == null) return;
            if (preset.fromDuration)
            {
                MainTabControl.SelectedIndex = 1; //change tab focus
                FD_durHrNumUD.Value = preset.from.hr;
                FD_durMinNumUD.Value = preset.from.min;
                FD_durSecNumUD.Value = preset.from.sec;
                FD_durMsNumUD.Value = preset.from.ms;
                return;
            }

            /// else...
            MainTabControl.SelectedIndex = 0; //change tab focus
            FR_fromHrNumUD.Value = preset.from.hr;
            FR_fromMinNumUD.Value = preset.from.min;
            FR_fromSecNumUD.Value = preset.from.sec;
            FR_fromMsNumUD.Value = preset.from.ms;
            FR_toHrNumUD.Value = preset.to.hr;
            FR_toMinNumUD.Value = preset.to.min;
            FR_toSecNumUD.Value = preset.to.sec;
            FR_toMsNumUD.Value = preset.to.ms;
            FR_fromBeginCheckB.Checked = preset.fromStart;
            FR_toLastCheckB.Checked = preset.toEnd;

            updateNumBoxs();
        }

        ///// PUBLIC 
        public class Selection{
            public bool selectedAll = false;
            public bool fromDuration = false;
            public bool fromStart = false;
            public bool toEnd = false;
            public Time from = new Time();
            public Time to = new Time();


            public class Time
            {
                public ushort hr = 0;
                public ushort min = 0;
                public ushort sec = 0;
                public ushort ms = 0;

                public override string ToString()
                {
                    string res = "";
                    res += this.hr.ToString().PadLeft(2, '0') + ":";
                    res += this.min.ToString().PadLeft(2, '0') + ":";
                    res += this.sec.ToString().PadLeft(2, '0') + ".";
                    res += this.ms.ToString().PadLeft(3, '0');
                    return res;
                }
            }

            

        }

        public Selection selection = null;
        public Selection preset = null;
        public App.FileInfo fileInfo = null;


        private int file_hr;
        private int file_min;
        private int file_sec;
        private int file_ms;







        //// private functions
        private void parseInputFileDuration()
        {
            List<string> time = Regex.Split(fileInfo.duration, "[:.]").ToList();
            file_hr = Convert.ToInt32(time[0]);
            file_min = Convert.ToInt32(time[1]);
            file_sec = Convert.ToInt32(time[2]);
            file_ms = Convert.ToInt32(time[3].PadRight(3, '0'));
        }


        /// <summary>
        /// check for invalid or risky inputs
        /// </summary>
        /// <returns>
        ///   code 0: every things looks good
        ///   code 1: `to` is lessthan `from`
        ///   code 2: `to` is equal to `from`
        ///   code 3: this just select the whole thing, whats the point of that?
        ///   code 4: (logic error) someting is'n right, code 4 should not be presented no matter what
        ///   code 5: any of Time selection is morethan InputFile length
        /// </returns>
        private byte checkInvalidInputs()
        {
            ushort FRfromSum = Convert.ToUInt16(FR_fromHrNumUD.Value + FR_fromMinNumUD.Value + FR_fromSecNumUD.Value + FR_fromMsNumUD.Value);
            if (FR_toLastCheckB.Checked && FRfromSum == 0) return 3;
            if (FR_fromBeginCheckB.Checked && FR_toLastCheckB.Checked) return 3;

            // if any of Time selection is morethan InputFile length
            if (isSelectOver()) return 5;


            if (FR_toLastCheckB.Checked) return 0;

            if (FR_fromHrNumUD.Value < FR_toHrNumUD.Value) return 0;
            if (FR_fromHrNumUD.Value > FR_toHrNumUD.Value) return 1;
            if (FR_fromMinNumUD.Value < FR_toMinNumUD.Value) return 0;
            if (FR_fromMinNumUD.Value > FR_toMinNumUD.Value) return 1;
            if (FR_fromSecNumUD.Value < FR_toSecNumUD.Value) return 0;
            if (FR_fromSecNumUD.Value > FR_toSecNumUD.Value) return 1;

            if (FR_fromMsNumUD.Value < FR_toMsNumUD.Value) return 0;
            if (FR_fromMsNumUD.Value > FR_toMsNumUD.Value) return 1;
            if (FR_fromMsNumUD.Value == FR_toMsNumUD.Value) return 2;

            return 4;
        }

        private bool isSelectOver()
        {
            if (FR_fromHrNumUD.Value < file_hr) return false;
            if (FR_fromHrNumUD.Value > file_hr) return true;
            if (FR_fromMinNumUD.Value < file_min) return false;
            if (FR_fromMinNumUD.Value > file_min) return true;
            if (FR_fromSecNumUD.Value < file_sec) return false;
            if (FR_fromSecNumUD.Value > file_sec) return true;

            if (FR_fromMsNumUD.Value < file_ms) return false;
            if (FR_fromMsNumUD.Value > file_ms) return true;
            return false;
        }

        private void clearWarning() { WarnLabel.Text = "    "; }

        private void updateNumBoxs()
        {
            bool fromBegin = FR_fromBeginCheckB.Checked;
            bool toLast = FR_toLastCheckB.Checked;

            FR_fromHrNumUD.Enabled = !fromBegin;
            FR_fromMinNumUD.Enabled = !fromBegin;
            FR_fromSecNumUD.Enabled = !fromBegin;
            FR_fromMsNumUD.Enabled = !fromBegin;

            FR_toHrNumUD.Enabled = !toLast;
            FR_toMinNumUD.Enabled = !toLast;
            FR_toSecNumUD.Enabled = !toLast;
            FR_toMsNumUD.Enabled = !toLast;


           /* if (FR_fromBeginCheckB.Checked)
            {
                FR_fromHrNumUD.Enabled = false;
                FR_fromMinNumUD.Enabled = false;
                FR_fromSecNumUD.Enabled = false;
                FR_fromMsNumUD.Enabled = false;
            }
            else
            {
                FR_fromHrNumUD.Enabled = true;
                FR_fromMinNumUD.Enabled = true;
                FR_fromSecNumUD.Enabled = true;
                FR_fromMsNumUD.Enabled = true;
            }

            if (FR_toLastCheckB.Checked)
            {
                FR_toHrNumUD.Enabled = false;
                FR_toMinNumUD.Enabled = false;
                FR_toSecNumUD.Enabled = false;
                FR_toMsNumUD.Enabled = false;
            }
            else
            {
                FR_toHrNumUD.Enabled = true;
                FR_toMinNumUD.Enabled = true;
                FR_toSecNumUD.Enabled = true;
                FR_toMsNumUD.Enabled = true;
            }*/
        }








        ////////// Event handler Functions /////////////
        private void ConfirmButton_Click(object sender, EventArgs e)
        {

            /////// if...
            selection = new Selection();
            if (MainTabControl.SelectedIndex == 1) selection.fromDuration = true;


            if (selection.fromDuration)
            {
                selection.from.hr = Convert.ToUInt16(FD_durHrNumUD.Value);
                selection.from.min = Convert.ToUInt16(FD_durMinNumUD.Value);
                selection.from.sec = Convert.ToUInt16(FD_durSecNumUD.Value);
                selection.from.ms = Convert.ToUInt16(FD_durMsNumUD.Value);
                this.Close();
                return;
            }



            ////// else...
            byte checkRes = checkInvalidInputs();
            switch (checkRes)
            {
                case 1:
                    WarnLabel.Text = "Start time can't be greater than\nEnd time";
                    return;
                case 2:
                    WarnLabel.Text = "Start time can't be equal to End time";
                    return;
                case 3:
                    selection.selectedAll = true;
                    this.Close();
                    return;
                case 4:
                    throw new Exception("Logic Error: code 4 detected\nfrom checkInvalidInputs()");

                case 5:
                    WarnLabel.Text = "Selected time can't be greater than\nthe actual File duration";
                    return;
            }

            if (!FR_fromBeginCheckB.Checked)
            {
                selection.from.hr = Convert.ToUInt16(FR_fromHrNumUD.Value);
                selection.from.min = Convert.ToUInt16(FR_fromMinNumUD.Value);
                selection.from.sec = Convert.ToUInt16(FR_fromSecNumUD.Value);
                selection.from.ms = Convert.ToUInt16(FR_fromMsNumUD.Value);
            }

            if (!FR_toLastCheckB.Checked)
            {
                selection.to.hr = Convert.ToUInt16(FR_toHrNumUD.Value);
                selection.to.min = Convert.ToUInt16(FR_toMinNumUD.Value);
                selection.to.sec = Convert.ToUInt16(FR_toSecNumUD.Value);
                selection.to.ms = Convert.ToUInt16(FR_toMsNumUD.Value);
            }

            // save check box state
            selection.fromStart = FR_fromBeginCheckB.Checked;
            selection.toEnd = FR_toLastCheckB.Checked;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            selection = null;
            this.Close();
        }
        



        // clear waring madness, can't think of a better way T^T
        private void FR_fromBeginCheckB_CheckedChanged(object sender, EventArgs e)
        {
            clearWarning();
            updateNumBoxs();
        }

        private void FR_toLastCheckB_CheckedChanged(object sender, EventArgs e)
        {
            clearWarning();
            updateNumBoxs();
        }

        private void FR_fromHrNumUD_ValueChanged(object sender, EventArgs e)
        {
            clearWarning();
        }

        private void FR_fromMinNumUD_ValueChanged(object sender, EventArgs e)
        {
            clearWarning();
        }

        private void FR_fromSecNumUD_ValueChanged(object sender, EventArgs e)
        {
            clearWarning();
        }

        private void FR_fromMsNumUD_ValueChanged(object sender, EventArgs e)
        {
            clearWarning();
        }

        private void FR_toHrNumUD_ValueChanged(object sender, EventArgs e)
        {
            clearWarning();
        }

        private void FR_toMinNumUD_ValueChanged(object sender, EventArgs e)
        {
            clearWarning();
        }

        private void FR_toSecNumUD_ValueChanged(object sender, EventArgs e)
        {
            clearWarning();
        }

        private void FR_toMsNumUD_ValueChanged(object sender, EventArgs e)
        {
            clearWarning();
        }

        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearWarning();
        }

        
    }
}
