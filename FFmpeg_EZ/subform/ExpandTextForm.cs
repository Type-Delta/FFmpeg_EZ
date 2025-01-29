using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFmpeg_EZ.subform
{
    public partial class ExpandTextForm : Form
    {
        public ExpandTextForm()
        {
            InitializeComponent();
            
        }

        private void ExpandTextForm_Load(object sender, EventArgs e)
        {
            if (!cmdOutDisplayMode)
            {
                MainRTextBox.Size = new Size(
                    MainRTextBox.Width,
                    309
                );
                RecentTextBox.Enabled = false;
            }
        }


        //private bool noUpdate = false;
        public bool cmdOutDisplayMode = false;
        public dynamic SyncedControl = null;


        public void AddText(string text)
        {
            MainRTextBox.Text += text;
            if(cmdOutDisplayMode) RecentTextBox.Text = text;
        }

        /// <summary>
        /// EventHandeler for TextChanged event, use to apply changed made on Host (form that create `this`)
        ///  to client's (this) control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SyncHostToClient(object sender, EventArgs e)
        {
            MainRTextBox.Text = SyncedControl?.Text;
        }


        private void MainRTextBox_TextChanged(object sender, EventArgs e)
        {
            if (MainRTextBox.Text.Length + 1000 > MainRTextBox.MaxLength)
            {
                MainRTextBox.Text = MainRTextBox.Text.Substring(1000);
            }

            if(SyncedControl != null)
            {
                SyncedControl.Text = MainRTextBox.Text;
            }
        }
    }
}
