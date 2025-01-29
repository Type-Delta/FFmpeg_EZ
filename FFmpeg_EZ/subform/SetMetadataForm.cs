using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFmpeg_EZ.subform
{
    public partial class SetMetadataForm : Form
    {
        public SetMetadataForm()
        {
            InitializeComponent();
        }

        private void SetMetadataForm_Load(object sender, EventArgs e)
        {
            if (preset == null) return;
            meta = preset;


        }





        public App.Metadata selection = null;
        public App.Metadata preset = null;
        public bool isConfirmed = false;

        private App.Metadata meta = new App.Metadata();




        private DateTime ToDate(string s)
        {
            // format: yyy-mm-ddThh:mm:ss
            int[] date = s.Split('T')[0]
                .Split('-')
                .Select(str => Convert.ToInt32(str))
                .ToArray();
            int[] time = s.Split('T')[1]
                .Split(':')
                .Select(str => Convert.ToInt32(str))
                .ToArray();

            return new DateTime(
                date[0], date[1], date[2],
                time[0], time[1], time[2]
            );
        }


        





        private void KeyTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Node == null||e.Node.Tag == null) return;
            string[] nodeTag = e.Node.Tag.ToString().Split(':');
            //DateTimePicker2.Value = ToDate(nodeTag[0]);

            EditTabControl.SelectedIndex = Convert.ToInt32(nodeTag[1]);

            switch (EditTabControl.SelectedIndex)
            {
                case 0:
                    ClearValueButton.Visible = false;
                    SetValueButton.Visible = false;
                    TipLabel.Text = "";
                    break;

                case 1:
                    ClearValueButton.Visible = true;
                    SetValueButton.Visible = true;
                    TipLabel.Text = e.Node.ToolTipText;
                    TextBox1.Text = meta.GetValue(nodeTag[0]) ?? "";
                    break;

                case 2:
                    ClearValueButton.Visible = true;
                    SetValueButton.Visible = true;
                    TipLabel.Text = e.Node.ToolTipText;
                    if (meta.GetValue(nodeTag[0]) != null)
                        DateTimePicker2.Value = ToDate(meta.GetValue(nodeTag[0])?.ToString());
                    else DateTimePicker2.Value = DateTime.Now;
                    break;

                case 3:
                    ClearValueButton.Visible = true;
                    SetValueButton.Visible = true;
                    TipLabel.Text = e.Node.ToolTipText;
                    LTextBox3.Text = meta.GetValue(nodeTag[0]) ?? "";
                    break;
            }

        }







        private void SetValueButton_Click(object sender, EventArgs e)
        {
            string[] nodeTag = KeyTreeView.SelectedNode.Tag.ToString().Split(':');
            dynamic value = null;

            switch (EditTabControl.SelectedIndex)
            {
                case 1: value = TextBox1.Text; break;
                case 2:
                    value = DateTimePicker2.Value.ToString("yyyy-MM-ddTHH:mm:ss");
                    break;
                case 3: value = LTextBox3.Text; break;
            }
            meta.SetValue(nodeTag[0], value);
        }


        private void ClearValueButton_Click(object sender, EventArgs e)
        {
            string[] nodeTag = KeyTreeView.SelectedNode.Tag.ToString().Split(':');
            switch (nodeTag[1])
            {
                case "1": TextBox1.Text = ""; break;
                case "2": DateTimePicker2.Value = DateTime.Now; break;
                case "3": LongTextPage3.Text = ""; break;
            }
            meta.SetValue(nodeTag[0], null);
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            this.isConfirmed = true;
            selection = meta;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }


    
}
