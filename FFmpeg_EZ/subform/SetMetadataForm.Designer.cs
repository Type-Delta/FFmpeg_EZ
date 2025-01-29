namespace FFmpeg_EZ.subform
{
    partial class SetMetadataForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Title");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Author");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Composter");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Description");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Creation Time");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Copyright");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Comment");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("General", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Grouping");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Album");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Album artist");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Genre");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Media Grouping", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetMetadataForm));
            this.EditTabControl = new System.Windows.Forms.TabControl();
            this.NonePage0 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TextPage1 = new System.Windows.Forms.TabPage();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.DateTextPage2 = new System.Windows.Forms.TabPage();
            this.DateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.LongTextPage3 = new System.Windows.Forms.TabPage();
            this.LTextBox3 = new System.Windows.Forms.TextBox();
            this.KeyTreeView = new System.Windows.Forms.TreeView();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.TipLabel = new System.Windows.Forms.Label();
            this.SetValueButton = new System.Windows.Forms.Button();
            this.ClearValueButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.EditTabControl.SuspendLayout();
            this.NonePage0.SuspendLayout();
            this.TextPage1.SuspendLayout();
            this.DateTextPage2.SuspendLayout();
            this.LongTextPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditTabControl
            // 
            this.EditTabControl.Controls.Add(this.NonePage0);
            this.EditTabControl.Controls.Add(this.TextPage1);
            this.EditTabControl.Controls.Add(this.DateTextPage2);
            this.EditTabControl.Controls.Add(this.LongTextPage3);
            this.EditTabControl.Location = new System.Drawing.Point(267, 2);
            this.EditTabControl.Name = "EditTabControl";
            this.EditTabControl.SelectedIndex = 0;
            this.EditTabControl.Size = new System.Drawing.Size(267, 229);
            this.EditTabControl.TabIndex = 0;
            // 
            // NonePage0
            // 
            this.NonePage0.Controls.Add(this.label2);
            this.NonePage0.Controls.Add(this.label1);
            this.NonePage0.Location = new System.Drawing.Point(4, 29);
            this.NonePage0.Name = "NonePage0";
            this.NonePage0.Padding = new System.Windows.Forms.Padding(3);
            this.NonePage0.Size = new System.Drawing.Size(259, 196);
            this.NonePage0.TabIndex = 0;
            this.NonePage0.Text = "NonePage0";
            this.NonePage0.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkGray;
            this.label2.Location = new System.Drawing.Point(20, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select Key from the left side";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Swera Demo", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(52, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 72);
            this.label1.TabIndex = 0;
            this.label1.Text = "No Key\r\nSelected";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TextPage1
            // 
            this.TextPage1.Controls.Add(this.TextBox1);
            this.TextPage1.Location = new System.Drawing.Point(4, 29);
            this.TextPage1.Name = "TextPage1";
            this.TextPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TextPage1.Size = new System.Drawing.Size(259, 196);
            this.TextPage1.TabIndex = 1;
            this.TextPage1.Text = "TextPage1";
            this.TextPage1.UseVisualStyleBackColor = true;
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(22, 89);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(198, 27);
            this.TextBox1.TabIndex = 0;
            // 
            // DateTextPage2
            // 
            this.DateTextPage2.Controls.Add(this.DateTimePicker2);
            this.DateTextPage2.Location = new System.Drawing.Point(4, 29);
            this.DateTextPage2.Name = "DateTextPage2";
            this.DateTextPage2.Padding = new System.Windows.Forms.Padding(3);
            this.DateTextPage2.Size = new System.Drawing.Size(259, 196);
            this.DateTextPage2.TabIndex = 2;
            this.DateTextPage2.Text = "DateTextPage2";
            this.DateTextPage2.UseVisualStyleBackColor = true;
            // 
            // DateTimePicker2
            // 
            this.DateTimePicker2.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTimePicker2.CustomFormat = "dd/MM/yyyy HH:mm";
            this.DateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimePicker2.Location = new System.Drawing.Point(26, 83);
            this.DateTimePicker2.Name = "DateTimePicker2";
            this.DateTimePicker2.Size = new System.Drawing.Size(190, 24);
            this.DateTimePicker2.TabIndex = 0;
            // 
            // LongTextPage3
            // 
            this.LongTextPage3.Controls.Add(this.LTextBox3);
            this.LongTextPage3.Location = new System.Drawing.Point(4, 29);
            this.LongTextPage3.Name = "LongTextPage3";
            this.LongTextPage3.Padding = new System.Windows.Forms.Padding(3);
            this.LongTextPage3.Size = new System.Drawing.Size(259, 196);
            this.LongTextPage3.TabIndex = 3;
            this.LongTextPage3.Text = "LongTextPage3";
            this.LongTextPage3.UseVisualStyleBackColor = true;
            // 
            // LTextBox3
            // 
            this.LTextBox3.Location = new System.Drawing.Point(17, 38);
            this.LTextBox3.Multiline = true;
            this.LTextBox3.Name = "LTextBox3";
            this.LTextBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LTextBox3.Size = new System.Drawing.Size(212, 108);
            this.LTextBox3.TabIndex = 0;
            // 
            // KeyTreeView
            // 
            this.KeyTreeView.Location = new System.Drawing.Point(12, 32);
            this.KeyTreeView.Name = "KeyTreeView";
            treeNode1.Name = "TitleNode";
            treeNode1.Tag = "title:1";
            treeNode1.Text = "Title";
            treeNode1.ToolTipText = "Set/Modify Title";
            treeNode2.Name = "AuthorNode";
            treeNode2.Tag = "author:1";
            treeNode2.Text = "Author";
            treeNode2.ToolTipText = "Set/Modify media Author";
            treeNode3.Name = "ComposterNode";
            treeNode3.Tag = "composter:1";
            treeNode3.Text = "Composter";
            treeNode3.ToolTipText = "Set/Modify media Composter";
            treeNode4.Name = "DescriptionNode";
            treeNode4.Tag = "description:3";
            treeNode4.Text = "Description";
            treeNode4.ToolTipText = "Set/Modify media Description";
            treeNode5.Name = "Creation_timeNode";
            treeNode5.Tag = "creation_time:2";
            treeNode5.Text = "Creation Time";
            treeNode5.ToolTipText = "Set/Modify Creation Time";
            treeNode6.Name = "CopyrightNode";
            treeNode6.Tag = "copyright:1";
            treeNode6.Text = "Copyright";
            treeNode6.ToolTipText = "Set/Modify Copyright";
            treeNode7.Name = "CommentNode";
            treeNode7.Tag = "comment:3";
            treeNode7.Text = "Comment";
            treeNode7.ToolTipText = "Set/Modify Comments";
            treeNode8.Name = "GeneralNode";
            treeNode8.Text = "General";
            treeNode9.Name = "GroupingNode";
            treeNode9.Tag = "grouping:1";
            treeNode9.Text = "Grouping";
            treeNode9.ToolTipText = "Set/Modify media Grouping";
            treeNode10.Name = "AlbumNode";
            treeNode10.Tag = "album:1";
            treeNode10.Text = "Album";
            treeNode10.ToolTipText = "Set/Modify media Album";
            treeNode11.Name = "Album_artistNode";
            treeNode11.Tag = "album_artist:1";
            treeNode11.Text = "Album artist";
            treeNode11.ToolTipText = "Set/Modify media Album artist";
            treeNode12.Name = "GenreNode";
            treeNode12.Tag = "genre:1";
            treeNode12.Text = "Genre";
            treeNode12.ToolTipText = "Set/Modify media Genre";
            treeNode13.Name = "MGroupingNode";
            treeNode13.Text = "Media Grouping";
            this.KeyTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode13});
            this.KeyTreeView.Size = new System.Drawing.Size(235, 197);
            this.KeyTreeView.TabIndex = 1;
            this.KeyTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.KeyTreeView_NodeMouseClick);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.CancelButton.Location = new System.Drawing.Point(349, 241);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(87, 34);
            this.CancelButton.TabIndex = 6;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ConfirmButton.Location = new System.Drawing.Point(442, 241);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(87, 34);
            this.ConfirmButton.TabIndex = 7;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // TipLabel
            // 
            this.TipLabel.AutoSize = true;
            this.TipLabel.BackColor = System.Drawing.SystemColors.Window;
            this.TipLabel.Location = new System.Drawing.Point(284, 46);
            this.TipLabel.Name = "TipLabel";
            this.TipLabel.Size = new System.Drawing.Size(24, 20);
            this.TipLabel.TabIndex = 1;
            this.TipLabel.Text = "   ";
            // 
            // SetValueButton
            // 
            this.SetValueButton.Location = new System.Drawing.Point(433, 189);
            this.SetValueButton.Name = "SetValueButton";
            this.SetValueButton.Size = new System.Drawing.Size(90, 31);
            this.SetValueButton.TabIndex = 2;
            this.SetValueButton.Text = "Set Value";
            this.SetValueButton.UseVisualStyleBackColor = true;
            this.SetValueButton.Click += new System.EventHandler(this.SetValueButton_Click);
            // 
            // ClearValueButton
            // 
            this.ClearValueButton.Location = new System.Drawing.Point(320, 189);
            this.ClearValueButton.Name = "ClearValueButton";
            this.ClearValueButton.Size = new System.Drawing.Size(107, 31);
            this.ClearValueButton.TabIndex = 2;
            this.ClearValueButton.Text = "Clear Value";
            this.ClearValueButton.UseVisualStyleBackColor = true;
            this.ClearValueButton.Click += new System.EventHandler(this.ClearValueButton_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(13, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(521, 30);
            this.panel1.TabIndex = 8;
            // 
            // SetMetadataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 282);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TipLabel);
            this.Controls.Add(this.ClearValueButton);
            this.Controls.Add(this.SetValueButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.KeyTreeView);
            this.Controls.Add(this.EditTabControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SetMetadataForm";
            this.Text = "Modify Metadata";
            this.Load += new System.EventHandler(this.SetMetadataForm_Load);
            this.EditTabControl.ResumeLayout(false);
            this.NonePage0.ResumeLayout(false);
            this.NonePage0.PerformLayout();
            this.TextPage1.ResumeLayout(false);
            this.TextPage1.PerformLayout();
            this.DateTextPage2.ResumeLayout(false);
            this.LongTextPage3.ResumeLayout(false);
            this.LongTextPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl EditTabControl;
        private System.Windows.Forms.TabPage NonePage0;
        private System.Windows.Forms.TabPage TextPage1;
        private System.Windows.Forms.TreeView KeyTreeView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage DateTextPage2;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.TabPage LongTextPage3;
        private System.Windows.Forms.TextBox TextBox1;
        private System.Windows.Forms.DateTimePicker DateTimePicker2;
        private System.Windows.Forms.TextBox LTextBox3;
        private System.Windows.Forms.Label TipLabel;
        private System.Windows.Forms.Button SetValueButton;
        private System.Windows.Forms.Button ClearValueButton;
        private System.Windows.Forms.Panel panel1;
    }
}