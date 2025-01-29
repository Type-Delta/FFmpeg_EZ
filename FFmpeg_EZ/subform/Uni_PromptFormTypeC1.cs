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
    public partial class Uni_PromptFormTypeC1 : Form
    {
        public Uni_PromptFormTypeC1()
        {
            InitializeComponent();
        }

        public string selection = null;
        public bool isConfirmed = false;
        public string preset = null;



        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            // use text instead to let user type any things they want
            // Items were there for guidance
            selection = comboBox.Text; 
            isConfirmed = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Uni_PromptFormTypeC1_Load(object sender, EventArgs e)
        {
            if(preset == null) return;
            comboBox.Text = selection = preset;

        }
    }
}
