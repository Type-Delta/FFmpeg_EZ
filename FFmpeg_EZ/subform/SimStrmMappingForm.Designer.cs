using System.Collections.Generic;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FFmpeg_EZ.subform
{
    partial class SimStrmMappingForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimStrmMappingForm));
            this.InputPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.MoveAllLeftButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.MoveRightButton = new System.Windows.Forms.Button();
            this.MoveLeftButton = new System.Windows.Forms.Button();
            this.OutputPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.OutputListBox = new System.Windows.Forms.ListBox();
            this.IncDCheckBox = new System.Windows.Forms.CheckBox();
            this.IncACheckBox = new System.Windows.Forms.CheckBox();
            this.IncVCheckBox = new System.Windows.Forms.CheckBox();
            this.IncSCheckBox = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Tooltip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.DragIconPictureBox = new System.Windows.Forms.PictureBox();
            this.DragIconPictureBox_dropReady = new System.Windows.Forms.PictureBox();
            this.LongToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.InputPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.OutputPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DragIconPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DragIconPictureBox_dropReady)).BeginInit();
            this.SuspendLayout();
            // 
            // InputPanel
            // 
            this.InputPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.InputPanel.AutoScroll = true;
            this.InputPanel.BackColor = System.Drawing.Color.Gray;
            this.InputPanel.Controls.Add(this.label4);
            this.InputPanel.Location = new System.Drawing.Point(18, 33);
            this.InputPanel.Name = "InputPanel";
            this.InputPanel.Size = new System.Drawing.Size(159, 253);
            this.InputPanel.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Swera Demo", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(6, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Inputs";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.linkLabel2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.MoveAllLeftButton);
            this.groupBox1.Controls.Add(this.ResetButton);
            this.groupBox1.Controls.Add(this.MoveRightButton);
            this.groupBox1.Controls.Add(this.MoveLeftButton);
            this.groupBox1.Controls.Add(this.OutputPanel);
            this.groupBox1.Controls.Add(this.InputPanel);
            this.groupBox1.Controls.Add(this.IncDCheckBox);
            this.groupBox1.Controls.Add(this.IncACheckBox);
            this.groupBox1.Controls.Add(this.IncVCheckBox);
            this.groupBox1.Controls.Add(this.IncSCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 384);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stream Mapping";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(182, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Includes";
            // 
            // linkLabel2
            // 
            this.linkLabel2.ActiveLinkColor = System.Drawing.Color.Blue;
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel2.Location = new System.Drawing.Point(18, 320);
            this.linkLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(56, 18);
            this.linkLabel2.TabIndex = 4;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Stream";
            this.LongToolTip.SetToolTip(this.linkLabel2, resources.GetString("linkLabel2.ToolTip"));
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 320);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(358, 54);
            this.label6.TabIndex = 3;
            this.label6.Text = "Stream Mapping aka Stream Selection determines\r\nwhat stream from Input gos to the" +
    " Output,\r\nthis process normally done automatically by FFmpeg \r\n";
            // 
            // MoveAllLeftButton
            // 
            this.MoveAllLeftButton.Image = global::FFmpeg_EZ.Properties.Resources.keyboard_double_arrow_left_FILL0_wght300_GRAD200_opsz24;
            this.MoveAllLeftButton.Location = new System.Drawing.Point(199, 113);
            this.MoveAllLeftButton.Name = "MoveAllLeftButton";
            this.MoveAllLeftButton.Size = new System.Drawing.Size(90, 28);
            this.MoveAllLeftButton.TabIndex = 2;
            this.MoveAllLeftButton.UseVisualStyleBackColor = true;
            this.MoveAllLeftButton.Click += new System.EventHandler(this.MoveAllLeftButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(199, 83);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(90, 28);
            this.ResetButton.TabIndex = 2;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // MoveRightButton
            // 
            this.MoveRightButton.Image = global::FFmpeg_EZ.Properties.Resources.arrow_forward_ios_FILL0_wght600_GRAD0_opsz24;
            this.MoveRightButton.Location = new System.Drawing.Point(247, 43);
            this.MoveRightButton.Name = "MoveRightButton";
            this.MoveRightButton.Size = new System.Drawing.Size(42, 34);
            this.MoveRightButton.TabIndex = 1;
            this.MoveRightButton.UseVisualStyleBackColor = true;
            this.MoveRightButton.Click += new System.EventHandler(this.MoveRightButton_Click);
            // 
            // MoveLeftButton
            // 
            this.MoveLeftButton.Image = global::FFmpeg_EZ.Properties.Resources.arrow_back_ios_FILL0_wght600_GRAD0_opsz24;
            this.MoveLeftButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MoveLeftButton.Location = new System.Drawing.Point(199, 43);
            this.MoveLeftButton.Name = "MoveLeftButton";
            this.MoveLeftButton.Size = new System.Drawing.Size(42, 34);
            this.MoveLeftButton.TabIndex = 1;
            this.MoveLeftButton.UseVisualStyleBackColor = true;
            this.MoveLeftButton.Click += new System.EventHandler(this.MoveLeftButton_Click);
            // 
            // OutputPanel
            // 
            this.OutputPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OutputPanel.AutoScroll = true;
            this.OutputPanel.BackColor = System.Drawing.Color.Gray;
            this.OutputPanel.Controls.Add(this.label5);
            this.OutputPanel.Controls.Add(this.OutputListBox);
            this.OutputPanel.Location = new System.Drawing.Point(312, 33);
            this.OutputPanel.Name = "OutputPanel";
            this.OutputPanel.Size = new System.Drawing.Size(159, 253);
            this.OutputPanel.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Swera Demo", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(6, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 22);
            this.label5.TabIndex = 3;
            this.label5.Text = "output";
            // 
            // OutputListBox
            // 
            this.OutputListBox.BackColor = System.Drawing.Color.Gray;
            this.OutputListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OutputListBox.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.OutputListBox.FormattingEnabled = true;
            this.OutputListBox.ItemHeight = 20;
            this.OutputListBox.Location = new System.Drawing.Point(3, 28);
            this.OutputListBox.Name = "OutputListBox";
            this.OutputListBox.Size = new System.Drawing.Size(153, 220);
            this.OutputListBox.TabIndex = 1;
            // 
            // IncDCheckBox
            // 
            this.IncDCheckBox.AutoSize = true;
            this.IncDCheckBox.Checked = true;
            this.IncDCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IncDCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IncDCheckBox.Location = new System.Drawing.Point(185, 255);
            this.IncDCheckBox.Name = "IncDCheckBox";
            this.IncDCheckBox.Size = new System.Drawing.Size(111, 20);
            this.IncDCheckBox.TabIndex = 5;
            this.IncDCheckBox.Text = "Data Streams";
            this.IncDCheckBox.UseVisualStyleBackColor = true;
            this.IncDCheckBox.CheckedChanged += new System.EventHandler(this.IncCheckBox_CheckedChanged);
            // 
            // IncACheckBox
            // 
            this.IncACheckBox.AutoSize = true;
            this.IncACheckBox.Checked = true;
            this.IncACheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IncACheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IncACheckBox.Location = new System.Drawing.Point(185, 207);
            this.IncACheckBox.Name = "IncACheckBox";
            this.IncACheckBox.Size = new System.Drawing.Size(117, 20);
            this.IncACheckBox.TabIndex = 5;
            this.IncACheckBox.Text = "Audio Streams";
            this.IncACheckBox.UseVisualStyleBackColor = true;
            this.IncACheckBox.CheckedChanged += new System.EventHandler(this.IncCheckBox_CheckedChanged);
            // 
            // IncVCheckBox
            // 
            this.IncVCheckBox.AutoSize = true;
            this.IncVCheckBox.Checked = true;
            this.IncVCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IncVCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IncVCheckBox.Location = new System.Drawing.Point(185, 183);
            this.IncVCheckBox.Name = "IncVCheckBox";
            this.IncVCheckBox.Size = new System.Drawing.Size(118, 20);
            this.IncVCheckBox.TabIndex = 5;
            this.IncVCheckBox.Text = "Video Streams";
            this.IncVCheckBox.UseVisualStyleBackColor = true;
            this.IncVCheckBox.CheckedChanged += new System.EventHandler(this.IncCheckBox_CheckedChanged);
            // 
            // IncSCheckBox
            // 
            this.IncSCheckBox.AutoSize = true;
            this.IncSCheckBox.Checked = true;
            this.IncSCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IncSCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IncSCheckBox.Location = new System.Drawing.Point(185, 231);
            this.IncSCheckBox.Name = "IncSCheckBox";
            this.IncSCheckBox.Size = new System.Drawing.Size(126, 20);
            this.IncSCheckBox.TabIndex = 5;
            this.IncSCheckBox.Text = "Subtitle Streams";
            this.IncSCheckBox.UseVisualStyleBackColor = true;
            this.IncSCheckBox.CheckedChanged += new System.EventHandler(this.IncCheckBox_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 312);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 20);
            this.label7.TabIndex = 3;
            this.label7.Text = "What is this?";
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.CancelButton.Location = new System.Drawing.Point(317, 401);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(87, 34);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ConfirmButton.Location = new System.Drawing.Point(410, 401);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(87, 34);
            this.ConfirmButton.TabIndex = 5;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // DragIconPictureBox
            // 
            this.DragIconPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.DragIconPictureBox.Image = global::FFmpeg_EZ.Properties.Resources.check_box_outline_blank_FILL0_wght400_GRAD0_opsz24;
            this.DragIconPictureBox.Location = new System.Drawing.Point(12, 399);
            this.DragIconPictureBox.Name = "DragIconPictureBox";
            this.DragIconPictureBox.Size = new System.Drawing.Size(24, 24);
            this.DragIconPictureBox.TabIndex = 2;
            this.DragIconPictureBox.TabStop = false;
            this.DragIconPictureBox.Visible = false;
            // 
            // DragIconPictureBox_dropReady
            // 
            this.DragIconPictureBox_dropReady.BackColor = System.Drawing.Color.Transparent;
            this.DragIconPictureBox_dropReady.Image = global::FFmpeg_EZ.Properties.Resources.add_box_FILL0_wght300_GRAD0_opsz24;
            this.DragIconPictureBox_dropReady.Location = new System.Drawing.Point(12, 399);
            this.DragIconPictureBox_dropReady.Name = "DragIconPictureBox_dropReady";
            this.DragIconPictureBox_dropReady.Size = new System.Drawing.Size(24, 24);
            this.DragIconPictureBox_dropReady.TabIndex = 2;
            this.DragIconPictureBox_dropReady.TabStop = false;
            this.DragIconPictureBox_dropReady.Visible = false;
            // 
            // LongToolTip
            // 
            this.LongToolTip.AutoPopDelay = 50000;
            this.LongToolTip.InitialDelay = 500;
            this.LongToolTip.ReshowDelay = 100;
            // 
            // SimStrmMappingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 443);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.DragIconPictureBox);
            this.Controls.Add(this.DragIconPictureBox_dropReady);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SimStrmMappingForm";
            this.Text = "Modify Stream Selection";
            this.Load += new System.EventHandler(this.SimStrmMappingForm_Load);
            this.InputPanel.ResumeLayout(false);
            this.InputPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.OutputPanel.ResumeLayout(false);
            this.OutputPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DragIconPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DragIconPictureBox_dropReady)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel InputPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Collections.Generic.List<ListBox> InputFileListBoxs = new List<ListBox>();
        private System.Collections.Generic.List<System.Windows.Forms.Label> InputLabels = new List<System.Windows.Forms.Label>();
        private System.Windows.Forms.PictureBox DragIconPictureBox_dropReady;
        private Panel OutputPanel;
        private ListBox OutputListBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Button MoveLeftButton;
        private Button MoveRightButton;
        private Button ResetButton;
        private Button MoveAllLeftButton;
        private ToolTip Tooltip1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private Button CancelButton;
        private Button ConfirmButton;
        private PictureBox DragIconPictureBox;
        private LinkLabel linkLabel2;
        private CheckBox IncDCheckBox;
        private CheckBox IncSCheckBox;
        private CheckBox IncACheckBox;
        private CheckBox IncVCheckBox;
        private System.Windows.Forms.Label label1;
        private ToolTip LongToolTip;
    }
}