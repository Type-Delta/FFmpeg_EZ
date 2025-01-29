namespace FFmpeg_EZ.subform
{
    partial class ExpandTextForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpandTextForm));
            this.MainRTextBox = new System.Windows.Forms.RichTextBox();
            this.RecentTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // MainRTextBox
            // 
            this.MainRTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainRTextBox.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainRTextBox.Location = new System.Drawing.Point(12, 12);
            this.MainRTextBox.Name = "MainRTextBox";
            this.MainRTextBox.Size = new System.Drawing.Size(476, 260);
            this.MainRTextBox.TabIndex = 0;
            this.MainRTextBox.Text = "";
            this.MainRTextBox.TextChanged += new System.EventHandler(this.MainRTextBox_TextChanged);
            // 
            // RecentTextBox
            // 
            this.RecentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RecentTextBox.Font = new System.Drawing.Font("Cascadia Code", 10.2F);
            this.RecentTextBox.Location = new System.Drawing.Point(12, 278);
            this.RecentTextBox.Multiline = true;
            this.RecentTextBox.Name = "RecentTextBox";
            this.RecentTextBox.ReadOnly = true;
            this.RecentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.RecentTextBox.Size = new System.Drawing.Size(476, 43);
            this.RecentTextBox.TabIndex = 1;
            // 
            // ExpandTextForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 331);
            this.Controls.Add(this.MainRTextBox);
            this.Controls.Add(this.RecentTextBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ExpandTextForm";
            this.Text = "Expand View";
            this.Load += new System.EventHandler(this.ExpandTextForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RichTextBox MainRTextBox;
        private System.Windows.Forms.TextBox RecentTextBox;
    }
}