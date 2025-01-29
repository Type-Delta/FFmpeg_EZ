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
    public partial class OffsetSelectForm : Form
    {
        public OffsetSelectForm()
        {
            InitializeComponent();
        }


        ///// PUBLIC 
        public double offset = 0;
        public double presetValue = 0;





        ///// PRIVATE



        ////////// Event handler Functions /////////////
        private void OffsetSetNumUD_ValueChanged(object sender, EventArgs e)
        {
            ushort barPos = Convert.ToUInt16(
                Math.Round(
                    OffsetSetNumUD.Value + (OffsetVisualTrackBar.Maximum/2)
                )
            );

            if (barPos > OffsetVisualTrackBar.Maximum) barPos = Convert.ToUInt16(OffsetVisualTrackBar.Maximum);
            else if (barPos < OffsetVisualTrackBar.Minimum) barPos = Convert.ToUInt16(OffsetVisualTrackBar.Minimum);

            OffsetVisualTrackBar.Value = barPos;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            offset = Convert.ToDouble(OffsetSetNumUD.Value);
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            offset = presetValue;
            this.Close();
        }

        private void OffsetSelectForm_Load(object sender, EventArgs e)
        {
            offset = presetValue;
            OffsetSetNumUD.Value = (decimal)presetValue;
        }

        private void SetzeroButton_Click(object sender, EventArgs e)
        {
            OffsetSetNumUD.Value = 0;
        }

    }
}
