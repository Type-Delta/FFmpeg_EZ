using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFmpeg_EZ
{
    public partial class Uni_PromptFormTypeN1 : Form
    {
        public Uni_PromptFormTypeN1()
        {
            InitializeComponent();
        }

        public double selection = 0;
        public bool isConfirmed = false;
        public double noneValue = 0; // value in which count as None when `value` is equivalent to this Value
        public double preset = 0;
        


        


        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            selection = Convert.ToDouble(numericUpDown.Value);
            isConfirmed = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Uni_PromptFormTypeN1_Load(object sender, EventArgs e)
        {
            if(preset == -1) return;
            selection = preset;
            numericUpDown.Value = Convert.ToDecimal(preset);
        }

        
    }
}
