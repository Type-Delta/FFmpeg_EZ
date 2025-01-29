namespace FFmpeg_EZ
{
    partial class V_scaleSelectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(V_scaleSelectForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PixelLabel = new System.Windows.Forms.Label();
            this.PixelsTextBox = new System.Windows.Forms.TextBox();
            this.FARComboBox = new System.Windows.Forms.ComboBox();
            this.PresetComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.WarnLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FARCheckBox = new System.Windows.Forms.CheckBox();
            this.RARCheckBox = new System.Windows.Forms.CheckBox();
            this.HeightTextBox = new System.Windows.Forms.TextBox();
            this.WidthTextBox = new System.Windows.Forms.TextBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.PixelLabel);
            this.groupBox1.Controls.Add(this.PixelsTextBox);
            this.groupBox1.Controls.Add(this.FARComboBox);
            this.groupBox1.Controls.Add(this.PresetComboBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.WarnLabel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.FARCheckBox);
            this.groupBox1.Controls.Add(this.RARCheckBox);
            this.groupBox1.Controls.Add(this.HeightTextBox);
            this.groupBox1.Controls.Add(this.WidthTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 171);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Video Resolution";
            // 
            // PixelLabel
            // 
            this.PixelLabel.AutoSize = true;
            this.PixelLabel.Location = new System.Drawing.Point(97, 142);
            this.PixelLabel.Name = "PixelLabel";
            this.PixelLabel.Size = new System.Drawing.Size(98, 20);
            this.PixelLabel.TabIndex = 5;
            this.PixelLabel.Text = "Mega pixels";
            // 
            // PixelsTextBox
            // 
            this.PixelsTextBox.Location = new System.Drawing.Point(25, 137);
            this.PixelsTextBox.Name = "PixelsTextBox";
            this.PixelsTextBox.ReadOnly = true;
            this.PixelsTextBox.Size = new System.Drawing.Size(72, 27);
            this.PixelsTextBox.TabIndex = 4;
            this.PixelsTextBox.Text = "0";
            // 
            // FARComboBox
            // 
            this.FARComboBox.FormattingEnabled = true;
            this.FARComboBox.Items.AddRange(new object[] {
            "16:9",
            "16:10",
            "1:1",
            "4:3",
            "9:16",
            "4:5",
            "5:7",
            "3:4"});
            this.FARComboBox.Location = new System.Drawing.Point(328, 137);
            this.FARComboBox.Name = "FARComboBox";
            this.FARComboBox.Size = new System.Drawing.Size(136, 28);
            this.FARComboBox.TabIndex = 3;
            this.FARComboBox.SelectedIndexChanged += new System.EventHandler(this.FARComboBox_SelectedIndexChanged);
            // 
            // PresetComboBox
            // 
            this.PresetComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PresetComboBox.FormattingEnabled = true;
            this.PresetComboBox.Items.AddRange(new object[] {
            "[None]",
            "(7,680 x 4,320) 8K Ultra HD",
            "(3,840 x 2,160) 4K Ultra HD",
            "(2,560 x 1,440) 1440p QuadHD",
            "(1,920 x 1,080) 1080p Full HD",
            "(1,280 x 720) 720p HD",
            "(720 x 480)  480p",
            "(480 x 360) 360p",
            "(320 x 240) 240p",
            "(192 x 144) 144p"});
            this.PresetComboBox.Location = new System.Drawing.Point(301, 42);
            this.PresetComboBox.Name = "PresetComboBox";
            this.PresetComboBox.Size = new System.Drawing.Size(163, 24);
            this.PresetComboBox.TabIndex = 3;
            this.PresetComboBox.SelectedIndexChanged += new System.EventHandler(this.PresetComboBox_SelectedIndexChanged);
            this.PresetComboBox.Leave += new System.EventHandler(this.PresetComboBox_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(306, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 18);
            this.label5.TabIndex = 2;
            this.label5.Text = "to";
            // 
            // WarnLabel
            // 
            this.WarnLabel.AutoSize = true;
            this.WarnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WarnLabel.ForeColor = System.Drawing.Color.Red;
            this.WarnLabel.Location = new System.Drawing.Point(22, 91);
            this.WarnLabel.Name = "WarnLabel";
            this.WarnLabel.Size = new System.Drawing.Size(20, 18);
            this.WarnLabel.TabIndex = 2;
            this.WarnLabel.Text = "   ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(164, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Height";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Width";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(137, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "X";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(297, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Presets";
            // 
            // FARCheckBox
            // 
            this.FARCheckBox.AutoSize = true;
            this.FARCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FARCheckBox.Location = new System.Drawing.Point(301, 115);
            this.FARCheckBox.Name = "FARCheckBox";
            this.FARCheckBox.Size = new System.Drawing.Size(130, 22);
            this.FARCheckBox.TabIndex = 1;
            this.FARCheckBox.Text = "Fix aspect ratio";
            this.FARCheckBox.UseVisualStyleBackColor = true;
            this.FARCheckBox.CheckedChanged += new System.EventHandler(this.FARCheckBox_CheckedChanged);
            // 
            // RARCheckBox
            // 
            this.RARCheckBox.AutoSize = true;
            this.RARCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RARCheckBox.Location = new System.Drawing.Point(301, 80);
            this.RARCheckBox.Name = "RARCheckBox";
            this.RARCheckBox.Size = new System.Drawing.Size(153, 22);
            this.RARCheckBox.TabIndex = 1;
            this.RARCheckBox.Text = "Retain aspect ratio";
            this.RARCheckBox.UseVisualStyleBackColor = true;
            this.RARCheckBox.CheckedChanged += new System.EventHandler(this.RARCheckBox_CheckedChanged);
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeightTextBox.Location = new System.Drawing.Point(167, 60);
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.Size = new System.Drawing.Size(103, 28);
            this.HeightTextBox.TabIndex = 0;
            this.HeightTextBox.TextChanged += new System.EventHandler(this.HeightTextBox_TextChanged);
            // 
            // WidthTextBox
            // 
            this.WidthTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WidthTextBox.Location = new System.Drawing.Point(25, 60);
            this.WidthTextBox.Name = "WidthTextBox";
            this.WidthTextBox.Size = new System.Drawing.Size(103, 28);
            this.WidthTextBox.TabIndex = 0;
            this.WidthTextBox.TextChanged += new System.EventHandler(this.WidthTextBox_TextChanged);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.CancelButton.Location = new System.Drawing.Point(299, 184);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(87, 34);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ConfirmButton.Location = new System.Drawing.Point(392, 184);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(87, 34);
            this.ConfirmButton.TabIndex = 3;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ResetButton.Location = new System.Drawing.Point(12, 182);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(87, 34);
            this.ResetButton.TabIndex = 2;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(206, 226);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 27);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // V_scaleSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 226);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "V_scaleSelectForm";
            this.Text = "Set Video Resolution";
            this.Load += new System.EventHandler(this.V_scaleSelectForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox PresetComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox RARCheckBox;
        private System.Windows.Forms.TextBox HeightTextBox;
        private System.Windows.Forms.TextBox WidthTextBox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Label PixelLabel;
        private System.Windows.Forms.TextBox PixelsTextBox;
        private System.Windows.Forms.ComboBox FARComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox FARCheckBox;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Label WarnLabel;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}