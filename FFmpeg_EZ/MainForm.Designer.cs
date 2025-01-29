
namespace FFmpeg_EZ
{
    partial class MainForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("video quality");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("audio quality");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Quality", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Video Scaling");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Video Cropping");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Video Options", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Steam Mapping");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Streams", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Metadata");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Others", new System.Windows.Forms.TreeNode[] {
            treeNode9});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Sim_CommandExePanel = new System.Windows.Forms.Panel();
            this.CE_progressBar = new System.Windows.Forms.ProgressBar();
            this.CE_genCmdExpandButton = new System.Windows.Forms.Button();
            this.CE_whatItDoesExpandButton = new System.Windows.Forms.Button();
            this.CE_stopCommandButton = new System.Windows.Forms.Button();
            this.CE_runCommandButton = new System.Windows.Forms.Button();
            this.CE_genCmdCopyButton = new System.Windows.Forms.Button();
            this.CE_stepLable = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CE_whatItDoesLabel = new System.Windows.Forms.Label();
            this.CE_genCommandLabel = new System.Windows.Forms.Label();
            this.CE_panelCloseButton = new System.Windows.Forms.Button();
            this.CE_whatItDoesRTextBox = new System.Windows.Forms.RichTextBox();
            this.CE_commandRTextBox = new System.Windows.Forms.RichTextBox();
            this.Sim_resetButton = new System.Windows.Forms.Button();
            this.Sim_continueButton = new System.Windows.Forms.Button();
            this.Sim_outputGroupBox = new System.Windows.Forms.GroupBox();
            this.Sim_clearOutputButton = new System.Windows.Forms.Button();
            this.Sim_forceFormatButton = new System.Windows.Forms.Button();
            this.Sim_OpenSaveFileButton = new System.Windows.Forms.Button();
            this.Sim_OutputFileTextBox = new System.Windows.Forms.TextBox();
            this.Sim_processGroupBox = new System.Windows.Forms.GroupBox();
            this.Sim_ClearProcessOptButton = new System.Windows.Forms.Button();
            this.Sim_processTreeView = new System.Windows.Forms.TreeView();
            this.Sim_InputGroupBox = new System.Windows.Forms.GroupBox();
            this.Sim_inputFilelistBox = new System.Windows.Forms.ListBox();
            this.Sim_removeInputFileButton = new System.Windows.Forms.Button();
            this.Sim_inputFileLabel = new System.Windows.Forms.Label();
            this.Sim_addInputFileButton = new System.Windows.Forms.Button();
            this.Sim_repeatAllInputCheckBox = new System.Windows.Forms.CheckBox();
            this.Sim_statusStrip = new System.Windows.Forms.StatusStrip();
            this.Sim_statusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.OpenInputFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.Sim_inputFileMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Sim_trimInputFileMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Sim_trimInputFileMenuStripSubItem_addNmod = new System.Windows.Forms.ToolStripMenuItem();
            this.Sim_trimInputFileMenuStripSubItem_rm = new System.Windows.Forms.ToolStripMenuItem();
            this.Sim_offsetFileMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Sim_offsetFileMenuStripSubItem_addNmod = new System.Windows.Forms.ToolStripMenuItem();
            this.Sim_offsetFileMenuStripSubItem_rm = new System.Windows.Forms.ToolStripMenuItem();
            this.Sim_moveupInputFileMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Sim_movedownInputFileMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Sim_removeInputFileMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Sim_previewInputFileMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Sim_viewInputFileInfoMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Menu_openButton = new System.Windows.Forms.Button();
            this.Menu_closeButton = new System.Windows.Forms.Button();
            this.menuD_hwaccelWikiLLabel = new System.Windows.Forms.LinkLabel();
            this.menuD_AMDhwaccelGuideLLabel = new System.Windows.Forms.LinkLabel();
            this.menuD_easyCommandLLabel = new System.Windows.Forms.LinkLabel();
            this.Timer_20 = new System.Windows.Forms.Timer(this.components);
            this.ToolTip2_longer = new System.Windows.Forms.ToolTip(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SaveOutputFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.Timer_1000 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.Menu_settingPanel = new System.Windows.Forms.Panel();
            this.MenuS_saveSettingCheckBox = new System.Windows.Forms.CheckBox();
            this.MenuS_toDefButton = new System.Windows.Forms.Button();
            this.MenuS_dnhRadioButton = new System.Windows.Forms.RadioButton();
            this.MenuS_hbRadioButton = new System.Windows.Forms.RadioButton();
            this.MenuS_hofRadioButton = new System.Windows.Forms.RadioButton();
            this.MenuS_hocRadioButton = new System.Windows.Forms.RadioButton();
            this.MenuS_defOutPutPathTextBox = new System.Windows.Forms.TextBox();
            this.MenuS_hwaccelCodeTextBox = new System.Windows.Forms.TextBox();
            this.MenuS_inputArgTextBox = new System.Windows.Forms.TextBox();
            this.MenuS_processArgTextBox = new System.Windows.Forms.TextBox();
            this.MenuS_defInPutPathTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Menu_docPanel = new System.Windows.Forms.Panel();
            this.menuD_ffmpegDocLLabel = new System.Windows.Forms.LinkLabel();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Menu_aboutPanel = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.Menu_verLabel = new System.Windows.Forms.Label();
            this.Menu_docButton = new System.Windows.Forms.Button();
            this.Menu_SettingButton = new System.Windows.Forms.Button();
            this.Menu_aboutButton = new System.Windows.Forms.Button();
            this.Coverpanel_top = new System.Windows.Forms.Panel();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.Sim_CommandExePanel.SuspendLayout();
            this.Sim_outputGroupBox.SuspendLayout();
            this.Sim_processGroupBox.SuspendLayout();
            this.Sim_InputGroupBox.SuspendLayout();
            this.Sim_statusStrip.SuspendLayout();
            this.MainTabControl.SuspendLayout();
            this.Sim_inputFileMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.MenuPanel.SuspendLayout();
            this.Menu_settingPanel.SuspendLayout();
            this.Menu_docPanel.SuspendLayout();
            this.Menu_aboutPanel.SuspendLayout();
            this.Coverpanel_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(473, 568);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Advance";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Swera Demo", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label15.Location = new System.Drawing.Point(95, 211);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(263, 78);
            this.label15.TabIndex = 0;
            this.label15.Text = "      Features\r\nComming Soon";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Sim_CommandExePanel);
            this.tabPage1.Controls.Add(this.Sim_resetButton);
            this.tabPage1.Controls.Add(this.Sim_continueButton);
            this.tabPage1.Controls.Add(this.Sim_outputGroupBox);
            this.tabPage1.Controls.Add(this.Sim_processGroupBox);
            this.tabPage1.Controls.Add(this.Sim_InputGroupBox);
            this.tabPage1.Controls.Add(this.Sim_repeatAllInputCheckBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(473, 568);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Sim_CommandExePanel
            // 
            this.Sim_CommandExePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Sim_CommandExePanel.BackColor = System.Drawing.Color.Gainsboro;
            this.Sim_CommandExePanel.Controls.Add(this.CE_progressBar);
            this.Sim_CommandExePanel.Controls.Add(this.CE_genCmdExpandButton);
            this.Sim_CommandExePanel.Controls.Add(this.CE_whatItDoesExpandButton);
            this.Sim_CommandExePanel.Controls.Add(this.CE_stopCommandButton);
            this.Sim_CommandExePanel.Controls.Add(this.CE_runCommandButton);
            this.Sim_CommandExePanel.Controls.Add(this.CE_genCmdCopyButton);
            this.Sim_CommandExePanel.Controls.Add(this.CE_stepLable);
            this.Sim_CommandExePanel.Controls.Add(this.label1);
            this.Sim_CommandExePanel.Controls.Add(this.CE_whatItDoesLabel);
            this.Sim_CommandExePanel.Controls.Add(this.CE_genCommandLabel);
            this.Sim_CommandExePanel.Controls.Add(this.CE_panelCloseButton);
            this.Sim_CommandExePanel.Controls.Add(this.CE_whatItDoesRTextBox);
            this.Sim_CommandExePanel.Controls.Add(this.CE_commandRTextBox);
            this.Sim_CommandExePanel.Location = new System.Drawing.Point(0, 409);
            this.Sim_CommandExePanel.Name = "Sim_CommandExePanel";
            this.Sim_CommandExePanel.Size = new System.Drawing.Size(472, 177);
            this.Sim_CommandExePanel.TabIndex = 8;
            // 
            // CE_progressBar
            // 
            this.CE_progressBar.Location = new System.Drawing.Point(22, 427);
            this.CE_progressBar.MarqueeAnimationSpeed = 1;
            this.CE_progressBar.Name = "CE_progressBar";
            this.CE_progressBar.Size = new System.Drawing.Size(308, 26);
            this.CE_progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.CE_progressBar.TabIndex = 7;
            // 
            // CE_genCmdExpandButton
            // 
            this.CE_genCmdExpandButton.Image = global::FFmpeg_EZ.Properties.Resources.open_in_full_FILL0_wght400_GRAD0_opsz24;
            this.CE_genCmdExpandButton.Location = new System.Drawing.Point(396, 132);
            this.CE_genCmdExpandButton.Name = "CE_genCmdExpandButton";
            this.CE_genCmdExpandButton.Size = new System.Drawing.Size(30, 30);
            this.CE_genCmdExpandButton.TabIndex = 6;
            this.ToolTip1.SetToolTip(this.CE_genCmdExpandButton, "Expand");
            this.CE_genCmdExpandButton.UseVisualStyleBackColor = true;
            this.CE_genCmdExpandButton.Click += new System.EventHandler(this.CE_genCmdExpandButton_Click);
            // 
            // CE_whatItDoesExpandButton
            // 
            this.CE_whatItDoesExpandButton.Image = global::FFmpeg_EZ.Properties.Resources.open_in_full_FILL0_wght400_GRAD0_opsz24;
            this.CE_whatItDoesExpandButton.Location = new System.Drawing.Point(396, 360);
            this.CE_whatItDoesExpandButton.Name = "CE_whatItDoesExpandButton";
            this.CE_whatItDoesExpandButton.Size = new System.Drawing.Size(30, 30);
            this.CE_whatItDoesExpandButton.TabIndex = 6;
            this.ToolTip1.SetToolTip(this.CE_whatItDoesExpandButton, "Expand");
            this.CE_whatItDoesExpandButton.UseVisualStyleBackColor = true;
            this.CE_whatItDoesExpandButton.Click += new System.EventHandler(this.CE_whatItDoesExpandButton_Click);
            // 
            // CE_stopCommandButton
            // 
            this.CE_stopCommandButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CE_stopCommandButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CE_stopCommandButton.ForeColor = System.Drawing.Color.Red;
            this.CE_stopCommandButton.Location = new System.Drawing.Point(341, 388);
            this.CE_stopCommandButton.Name = "CE_stopCommandButton";
            this.CE_stopCommandButton.Size = new System.Drawing.Size(119, 35);
            this.CE_stopCommandButton.TabIndex = 0;
            this.CE_stopCommandButton.Text = "Stop";
            this.ToolTip1.SetToolTip(this.CE_stopCommandButton, "Stop rendering");
            this.CE_stopCommandButton.UseVisualStyleBackColor = false;
            this.CE_stopCommandButton.Visible = false;
            this.CE_stopCommandButton.Click += new System.EventHandler(this.CE_stopCommandButton_Click);
            // 
            // CE_runCommandButton
            // 
            this.CE_runCommandButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CE_runCommandButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CE_runCommandButton.Location = new System.Drawing.Point(341, 418);
            this.CE_runCommandButton.Name = "CE_runCommandButton";
            this.CE_runCommandButton.Size = new System.Drawing.Size(119, 35);
            this.CE_runCommandButton.TabIndex = 0;
            this.CE_runCommandButton.Text = "Run Command";
            this.CE_runCommandButton.UseVisualStyleBackColor = false;
            this.CE_runCommandButton.Click += new System.EventHandler(this.CE_runCommandButton_Click);
            // 
            // CE_genCmdCopyButton
            // 
            this.CE_genCmdCopyButton.Image = global::FFmpeg_EZ.Properties.Resources.content_copy_FILL0_wght400_GRAD0_opsz24;
            this.CE_genCmdCopyButton.Location = new System.Drawing.Point(368, 132);
            this.CE_genCmdCopyButton.Name = "CE_genCmdCopyButton";
            this.CE_genCmdCopyButton.Size = new System.Drawing.Size(30, 30);
            this.CE_genCmdCopyButton.TabIndex = 3;
            this.ToolTip1.SetToolTip(this.CE_genCmdCopyButton, "Copy to Clipboard");
            this.CE_genCmdCopyButton.UseVisualStyleBackColor = true;
            this.CE_genCmdCopyButton.Click += new System.EventHandler(this.CE_genCmdCopyButton_Click);
            // 
            // CE_stepLable
            // 
            this.CE_stepLable.AutoSize = true;
            this.CE_stepLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CE_stepLable.Location = new System.Drawing.Point(107, 405);
            this.CE_stepLable.Name = "CE_stepLable";
            this.CE_stepLable.Size = new System.Drawing.Size(20, 18);
            this.CE_stepLable.TabIndex = 2;
            this.CE_stepLable.Text = "   ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 403);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Progress";
            // 
            // CE_whatItDoesLabel
            // 
            this.CE_whatItDoesLabel.AutoSize = true;
            this.CE_whatItDoesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CE_whatItDoesLabel.Location = new System.Drawing.Point(23, 183);
            this.CE_whatItDoesLabel.Name = "CE_whatItDoesLabel";
            this.CE_whatItDoesLabel.Size = new System.Drawing.Size(113, 22);
            this.CE_whatItDoesLabel.TabIndex = 2;
            this.CE_whatItDoesLabel.Text = "What it Does";
            // 
            // CE_genCommandLabel
            // 
            this.CE_genCommandLabel.AutoSize = true;
            this.CE_genCommandLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CE_genCommandLabel.Location = new System.Drawing.Point(22, 19);
            this.CE_genCommandLabel.Name = "CE_genCommandLabel";
            this.CE_genCommandLabel.Size = new System.Drawing.Size(181, 22);
            this.CE_genCommandLabel.TabIndex = 2;
            this.CE_genCommandLabel.Text = "Generated Command";
            // 
            // CE_panelCloseButton
            // 
            this.CE_panelCloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CE_panelCloseButton.BackColor = System.Drawing.Color.Gainsboro;
            this.CE_panelCloseButton.Image = global::FFmpeg_EZ.Properties.Resources.expand_more_FILL0_wght400_GRAD0_opsz24;
            this.CE_panelCloseButton.Location = new System.Drawing.Point(441, 0);
            this.CE_panelCloseButton.Name = "CE_panelCloseButton";
            this.CE_panelCloseButton.Size = new System.Drawing.Size(30, 30);
            this.CE_panelCloseButton.TabIndex = 0;
            this.ToolTip1.SetToolTip(this.CE_panelCloseButton, "Close");
            this.CE_panelCloseButton.UseVisualStyleBackColor = false;
            this.CE_panelCloseButton.Click += new System.EventHandler(this.CE_panelCloseButton_Click);
            // 
            // CE_whatItDoesRTextBox
            // 
            this.CE_whatItDoesRTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CE_whatItDoesRTextBox.Font = new System.Drawing.Font("Swera Demo", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CE_whatItDoesRTextBox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.CE_whatItDoesRTextBox.Location = new System.Drawing.Point(49, 208);
            this.CE_whatItDoesRTextBox.Name = "CE_whatItDoesRTextBox";
            this.CE_whatItDoesRTextBox.ReadOnly = true;
            this.CE_whatItDoesRTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.CE_whatItDoesRTextBox.Size = new System.Drawing.Size(377, 182);
            this.CE_whatItDoesRTextBox.TabIndex = 5;
            this.CE_whatItDoesRTextBox.Text = "\n\n\t          Loading";
            // 
            // CE_commandRTextBox
            // 
            this.CE_commandRTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CE_commandRTextBox.Font = new System.Drawing.Font("Swera Demo", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CE_commandRTextBox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.CE_commandRTextBox.Location = new System.Drawing.Point(49, 45);
            this.CE_commandRTextBox.Name = "CE_commandRTextBox";
            this.CE_commandRTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.CE_commandRTextBox.Size = new System.Drawing.Size(377, 117);
            this.CE_commandRTextBox.TabIndex = 5;
            this.CE_commandRTextBox.Text = "\n     Generating Command";
            // 
            // Sim_resetButton
            // 
            this.Sim_resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Sim_resetButton.ForeColor = System.Drawing.Color.Red;
            this.Sim_resetButton.Location = new System.Drawing.Point(253, 502);
            this.Sim_resetButton.Name = "Sim_resetButton";
            this.Sim_resetButton.Size = new System.Drawing.Size(98, 32);
            this.Sim_resetButton.TabIndex = 7;
            this.Sim_resetButton.Text = "Reset";
            this.Sim_resetButton.UseVisualStyleBackColor = true;
            this.Sim_resetButton.Click += new System.EventHandler(this.Sim_resetButton_Click);
            // 
            // Sim_continueButton
            // 
            this.Sim_continueButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Sim_continueButton.Location = new System.Drawing.Point(362, 503);
            this.Sim_continueButton.Name = "Sim_continueButton";
            this.Sim_continueButton.Size = new System.Drawing.Size(98, 32);
            this.Sim_continueButton.TabIndex = 7;
            this.Sim_continueButton.Text = "Continue";
            this.Sim_continueButton.UseVisualStyleBackColor = true;
            this.Sim_continueButton.Click += new System.EventHandler(this.Sim_continueButton_Click);
            // 
            // Sim_outputGroupBox
            // 
            this.Sim_outputGroupBox.Controls.Add(this.Sim_clearOutputButton);
            this.Sim_outputGroupBox.Controls.Add(this.Sim_forceFormatButton);
            this.Sim_outputGroupBox.Controls.Add(this.Sim_OpenSaveFileButton);
            this.Sim_outputGroupBox.Controls.Add(this.Sim_OutputFileTextBox);
            this.Sim_outputGroupBox.Location = new System.Drawing.Point(16, 422);
            this.Sim_outputGroupBox.Name = "Sim_outputGroupBox";
            this.Sim_outputGroupBox.Size = new System.Drawing.Size(445, 68);
            this.Sim_outputGroupBox.TabIndex = 6;
            this.Sim_outputGroupBox.TabStop = false;
            this.Sim_outputGroupBox.Text = "OUTPUT (Single)";
            // 
            // Sim_clearOutputButton
            // 
            this.Sim_clearOutputButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sim_clearOutputButton.Location = new System.Drawing.Point(390, 24);
            this.Sim_clearOutputButton.Name = "Sim_clearOutputButton";
            this.Sim_clearOutputButton.Size = new System.Drawing.Size(30, 30);
            this.Sim_clearOutputButton.TabIndex = 7;
            this.Sim_clearOutputButton.Text = "X";
            this.ToolTip1.SetToolTip(this.Sim_clearOutputButton, "Clear");
            this.Sim_clearOutputButton.UseVisualStyleBackColor = true;
            this.Sim_clearOutputButton.Click += new System.EventHandler(this.Sim_clearOutputButton_Click);
            // 
            // Sim_forceFormatButton
            // 
            this.Sim_forceFormatButton.Image = global::FFmpeg_EZ.Properties.Resources.video_settings_FILL0_wght400_GRAD0_opsz24;
            this.Sim_forceFormatButton.Location = new System.Drawing.Point(359, 24);
            this.Sim_forceFormatButton.Name = "Sim_forceFormatButton";
            this.Sim_forceFormatButton.Size = new System.Drawing.Size(30, 30);
            this.Sim_forceFormatButton.TabIndex = 7;
            this.ToolTip2_longer.SetToolTip(this.Sim_forceFormatButton, "Force Output Format\r\n\r\nforce output file format to the disired format\r\nwhile keep" +
        "ing Extension name the same\r\n(maybe usefull if FFmpeg fails to detect an appropr" +
        "iate\r\nOutput format)\r\n");
            this.Sim_forceFormatButton.UseVisualStyleBackColor = true;
            this.Sim_forceFormatButton.Click += new System.EventHandler(this.Sim_forceFormatButton_Click);
            // 
            // Sim_OpenSaveFileButton
            // 
            this.Sim_OpenSaveFileButton.Image = global::FFmpeg_EZ.Properties.Resources.file_open_FILL0_wght400_GRAD0_opsz24;
            this.Sim_OpenSaveFileButton.Location = new System.Drawing.Point(328, 24);
            this.Sim_OpenSaveFileButton.Name = "Sim_OpenSaveFileButton";
            this.Sim_OpenSaveFileButton.Size = new System.Drawing.Size(30, 30);
            this.Sim_OpenSaveFileButton.TabIndex = 7;
            this.ToolTip1.SetToolTip(this.Sim_OpenSaveFileButton, "Choose Output file");
            this.Sim_OpenSaveFileButton.UseVisualStyleBackColor = true;
            this.Sim_OpenSaveFileButton.Click += new System.EventHandler(this.Sim_OpenSaveFileButton_Click);
            // 
            // Sim_OutputFileTextBox
            // 
            this.Sim_OutputFileTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sim_OutputFileTextBox.Location = new System.Drawing.Point(21, 25);
            this.Sim_OutputFileTextBox.Name = "Sim_OutputFileTextBox";
            this.Sim_OutputFileTextBox.Size = new System.Drawing.Size(303, 28);
            this.Sim_OutputFileTextBox.TabIndex = 6;
            this.Sim_OutputFileTextBox.TextChanged += new System.EventHandler(this.Sim_OutputFileTextBox_TextChanged);
            // 
            // Sim_processGroupBox
            // 
            this.Sim_processGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Sim_processGroupBox.Controls.Add(this.Sim_ClearProcessOptButton);
            this.Sim_processGroupBox.Controls.Add(this.Sim_processTreeView);
            this.Sim_processGroupBox.Location = new System.Drawing.Point(16, 151);
            this.Sim_processGroupBox.Name = "Sim_processGroupBox";
            this.Sim_processGroupBox.Size = new System.Drawing.Size(215, 265);
            this.Sim_processGroupBox.TabIndex = 5;
            this.Sim_processGroupBox.TabStop = false;
            this.Sim_processGroupBox.Text = "PROCESS";
            // 
            // Sim_ClearProcessOptButton
            // 
            this.Sim_ClearProcessOptButton.Image = global::FFmpeg_EZ.Properties.Resources.rounded_corner_FILL0_wght400_GRAD0_opsz24;
            this.Sim_ClearProcessOptButton.Location = new System.Drawing.Point(175, 32);
            this.Sim_ClearProcessOptButton.Name = "Sim_ClearProcessOptButton";
            this.Sim_ClearProcessOptButton.Size = new System.Drawing.Size(30, 30);
            this.Sim_ClearProcessOptButton.TabIndex = 1;
            this.ToolTip1.SetToolTip(this.Sim_ClearProcessOptButton, "Clear option");
            this.Sim_ClearProcessOptButton.UseVisualStyleBackColor = true;
            this.Sim_ClearProcessOptButton.Click += new System.EventHandler(this.Sim_ClearProcessOptButton_Click);
            // 
            // Sim_processTreeView
            // 
            this.Sim_processTreeView.ForeColor = System.Drawing.Color.Black;
            this.Sim_processTreeView.Location = new System.Drawing.Point(11, 32);
            this.Sim_processTreeView.Name = "Sim_processTreeView";
            treeNode1.Name = "V_qualNode";
            treeNode1.Tag = "set video bitrate";
            treeNode1.Text = "video quality";
            treeNode1.ToolTipText = "Double-click to edit";
            treeNode2.Name = "A_qualNode";
            treeNode2.Tag = "set audio bitrate";
            treeNode2.Text = "audio quality";
            treeNode2.ToolTipText = "Double-click to edit";
            treeNode3.Name = "QualityNode";
            treeNode3.Tag = "modify audio and video quality";
            treeNode3.Text = "Quality";
            treeNode3.ToolTipText = "Expand to see options for this category";
            treeNode4.Name = "V_scalingNode";
            treeNode4.Tag = "modify Video resolution by Pixels";
            treeNode4.Text = "Video Scaling";
            treeNode4.ToolTipText = "Double-click to edit";
            treeNode5.Name = "V_cropNode";
            treeNode5.Tag = "Crop video frame to any dimension of choice";
            treeNode5.Text = "Video Cropping";
            treeNode5.ToolTipText = "Double-click to edit";
            treeNode6.Name = "V_OptNode";
            treeNode6.Tag = "modify Video properties";
            treeNode6.Text = "Video Options";
            treeNode6.ToolTipText = "Expand to see options for this category";
            treeNode7.Name = "StrmMapNode";
            treeNode7.Tag = "Control what Input gos to what Output";
            treeNode7.Text = "Steam Mapping";
            treeNode7.ToolTipText = "Double-click to edit";
            treeNode8.Name = "StreamNode";
            treeNode8.Text = "Streams";
            treeNode8.ToolTipText = "Expand to see options for this category";
            treeNode9.Name = "MetadataNode";
            treeNode9.Tag = "Set Outputfile Metadata";
            treeNode9.Text = "Metadata";
            treeNode9.ToolTipText = "Double-click to edit";
            treeNode10.Name = "OtherNode";
            treeNode10.Text = "Others";
            treeNode10.ToolTipText = "Expand to see options for this category";
            this.Sim_processTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6,
            treeNode8,
            treeNode10});
            this.Sim_processTreeView.PathSeparator = "/";
            this.Sim_processTreeView.ShowNodeToolTips = true;
            this.Sim_processTreeView.Size = new System.Drawing.Size(159, 211);
            this.Sim_processTreeView.TabIndex = 0;
            this.Sim_processTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.Sim_processTreeView_NodeMouseClick);
            this.Sim_processTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.Sim_processTreeView_NodeMouseDoubleClick);
            // 
            // Sim_InputGroupBox
            // 
            this.Sim_InputGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Sim_InputGroupBox.AutoSize = true;
            this.Sim_InputGroupBox.Controls.Add(this.Sim_inputFilelistBox);
            this.Sim_InputGroupBox.Controls.Add(this.Sim_removeInputFileButton);
            this.Sim_InputGroupBox.Controls.Add(this.Sim_inputFileLabel);
            this.Sim_InputGroupBox.Controls.Add(this.Sim_addInputFileButton);
            this.Sim_InputGroupBox.Location = new System.Drawing.Point(16, 10);
            this.Sim_InputGroupBox.Name = "Sim_InputGroupBox";
            this.Sim_InputGroupBox.Size = new System.Drawing.Size(445, 134);
            this.Sim_InputGroupBox.TabIndex = 3;
            this.Sim_InputGroupBox.TabStop = false;
            this.Sim_InputGroupBox.Text = "INPUTS";
            // 
            // Sim_inputFilelistBox
            // 
            this.Sim_inputFilelistBox.FormattingEnabled = true;
            this.Sim_inputFilelistBox.HorizontalScrollbar = true;
            this.Sim_inputFilelistBox.ItemHeight = 20;
            this.Sim_inputFilelistBox.Location = new System.Drawing.Point(22, 44);
            this.Sim_inputFilelistBox.Name = "Sim_inputFilelistBox";
            this.Sim_inputFilelistBox.Size = new System.Drawing.Size(303, 64);
            this.Sim_inputFilelistBox.TabIndex = 0;
            this.ToolTip1.SetToolTip(this.Sim_inputFilelistBox, "Right-click to open context menu");
            this.Sim_inputFilelistBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Sim_inputFilelistBox_MouseDown);
            // 
            // Sim_removeInputFileButton
            // 
            this.Sim_removeInputFileButton.Location = new System.Drawing.Point(339, 79);
            this.Sim_removeInputFileButton.Name = "Sim_removeInputFileButton";
            this.Sim_removeInputFileButton.Size = new System.Drawing.Size(90, 29);
            this.Sim_removeInputFileButton.TabIndex = 2;
            this.Sim_removeInputFileButton.Text = "Remove";
            this.Sim_removeInputFileButton.UseVisualStyleBackColor = true;
            this.Sim_removeInputFileButton.Click += new System.EventHandler(this.Sim_removeInputFileButton_Click);
            // 
            // Sim_inputFileLabel
            // 
            this.Sim_inputFileLabel.AutoSize = true;
            this.Sim_inputFileLabel.Location = new System.Drawing.Point(18, 21);
            this.Sim_inputFileLabel.Name = "Sim_inputFileLabel";
            this.Sim_inputFileLabel.Size = new System.Drawing.Size(81, 20);
            this.Sim_inputFileLabel.TabIndex = 1;
            this.Sim_inputFileLabel.Text = "Input files";
            // 
            // Sim_addInputFileButton
            // 
            this.Sim_addInputFileButton.Location = new System.Drawing.Point(339, 44);
            this.Sim_addInputFileButton.Name = "Sim_addInputFileButton";
            this.Sim_addInputFileButton.Size = new System.Drawing.Size(90, 29);
            this.Sim_addInputFileButton.TabIndex = 2;
            this.Sim_addInputFileButton.Text = "Add file";
            this.Sim_addInputFileButton.UseVisualStyleBackColor = true;
            this.Sim_addInputFileButton.Click += new System.EventHandler(this.Sim_addInputFileButton_Click);
            // 
            // Sim_repeatAllInputCheckBox
            // 
            this.Sim_repeatAllInputCheckBox.AutoSize = true;
            this.Sim_repeatAllInputCheckBox.Location = new System.Drawing.Point(271, 174);
            this.Sim_repeatAllInputCheckBox.Name = "Sim_repeatAllInputCheckBox";
            this.Sim_repeatAllInputCheckBox.Size = new System.Drawing.Size(174, 24);
            this.Sim_repeatAllInputCheckBox.TabIndex = 9;
            this.Sim_repeatAllInputCheckBox.Text = "Repeat for All Input";
            this.ToolTip2_longer.SetToolTip(this.Sim_repeatAllInputCheckBox, "Repeat the same Process for all Input\r\n\r\napply all Input files with the same Proc" +
        "ess options\r\nsome options will be ignored and Output files name\r\nwill be append " +
        "with file number\r\n");
            this.Sim_repeatAllInputCheckBox.UseVisualStyleBackColor = true;
            // 
            // Sim_statusStrip
            // 
            this.Sim_statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Sim_statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Sim_statusStripLabel});
            this.Sim_statusStrip.Location = new System.Drawing.Point(0, 575);
            this.Sim_statusStrip.Name = "Sim_statusStrip";
            this.Sim_statusStrip.Size = new System.Drawing.Size(481, 26);
            this.Sim_statusStrip.TabIndex = 4;
            this.Sim_statusStrip.Text = "statusStrip1";
            // 
            // Sim_statusStripLabel
            // 
            this.Sim_statusStripLabel.Name = "Sim_statusStripLabel";
            this.Sim_statusStripLabel.Size = new System.Drawing.Size(25, 20);
            this.Sim_statusStripLabel.Text = "    ";
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.tabPage1);
            this.MainTabControl.Controls.Add(this.tabPage2);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Location = new System.Drawing.Point(0, 0);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(481, 601);
            this.MainTabControl.TabIndex = 0;
            // 
            // OpenInputFileDialog
            // 
            this.OpenInputFileDialog.FileName = "openFileDialog1";
            // 
            // Sim_inputFileMenuStrip
            // 
            this.Sim_inputFileMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Sim_inputFileMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Sim_trimInputFileMenuStripItem,
            this.Sim_offsetFileMenuStripItem,
            this.Sim_moveupInputFileMenuStripItem,
            this.Sim_movedownInputFileMenuStripItem,
            this.Sim_removeInputFileMenuStripItem,
            this.Sim_previewInputFileMenuStripItem,
            this.Sim_viewInputFileInfoMenuStripItem});
            this.Sim_inputFileMenuStrip.Name = "H_inputFileMenuStrip";
            this.Sim_inputFileMenuStrip.Size = new System.Drawing.Size(178, 172);
            // 
            // Sim_trimInputFileMenuStripItem
            // 
            this.Sim_trimInputFileMenuStripItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Sim_trimInputFileMenuStripSubItem_addNmod,
            this.Sim_trimInputFileMenuStripSubItem_rm});
            this.Sim_trimInputFileMenuStripItem.Name = "Sim_trimInputFileMenuStripItem";
            this.Sim_trimInputFileMenuStripItem.Size = new System.Drawing.Size(177, 24);
            this.Sim_trimInputFileMenuStripItem.Text = "File Trimming...";
            // 
            // Sim_trimInputFileMenuStripSubItem_addNmod
            // 
            this.Sim_trimInputFileMenuStripSubItem_addNmod.Name = "Sim_trimInputFileMenuStripSubItem_addNmod";
            this.Sim_trimInputFileMenuStripSubItem_addNmod.Size = new System.Drawing.Size(213, 26);
            this.Sim_trimInputFileMenuStripSubItem_addNmod.Text = "Add Trimming";
            this.Sim_trimInputFileMenuStripSubItem_addNmod.Click += new System.EventHandler(this.Sim_trimInputFileMenuStripSubItem_addNmod_Click);
            // 
            // Sim_trimInputFileMenuStripSubItem_rm
            // 
            this.Sim_trimInputFileMenuStripSubItem_rm.Name = "Sim_trimInputFileMenuStripSubItem_rm";
            this.Sim_trimInputFileMenuStripSubItem_rm.Size = new System.Drawing.Size(213, 26);
            this.Sim_trimInputFileMenuStripSubItem_rm.Text = "Remove Trimming";
            this.Sim_trimInputFileMenuStripSubItem_rm.Click += new System.EventHandler(this.Sim_trimInputFileMenuStripSubItem_rm_Click);
            // 
            // Sim_offsetFileMenuStripItem
            // 
            this.Sim_offsetFileMenuStripItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Sim_offsetFileMenuStripSubItem_addNmod,
            this.Sim_offsetFileMenuStripSubItem_rm});
            this.Sim_offsetFileMenuStripItem.Name = "Sim_offsetFileMenuStripItem";
            this.Sim_offsetFileMenuStripItem.Size = new System.Drawing.Size(177, 24);
            this.Sim_offsetFileMenuStripItem.Text = "File Offset...";
            // 
            // Sim_offsetFileMenuStripSubItem_addNmod
            // 
            this.Sim_offsetFileMenuStripSubItem_addNmod.Name = "Sim_offsetFileMenuStripSubItem_addNmod";
            this.Sim_offsetFileMenuStripSubItem_addNmod.Size = new System.Drawing.Size(190, 26);
            this.Sim_offsetFileMenuStripSubItem_addNmod.Text = "Add Offset";
            this.Sim_offsetFileMenuStripSubItem_addNmod.Click += new System.EventHandler(this.Sim_offsetFileMenuStripSubItem_addNmod_Click);
            // 
            // Sim_offsetFileMenuStripSubItem_rm
            // 
            this.Sim_offsetFileMenuStripSubItem_rm.Name = "Sim_offsetFileMenuStripSubItem_rm";
            this.Sim_offsetFileMenuStripSubItem_rm.Size = new System.Drawing.Size(190, 26);
            this.Sim_offsetFileMenuStripSubItem_rm.Text = "Remove Offset";
            this.Sim_offsetFileMenuStripSubItem_rm.Click += new System.EventHandler(this.Sim_offsetFileMenuStripSubItem_rm_Click);
            // 
            // Sim_moveupInputFileMenuStripItem
            // 
            this.Sim_moveupInputFileMenuStripItem.Name = "Sim_moveupInputFileMenuStripItem";
            this.Sim_moveupInputFileMenuStripItem.Size = new System.Drawing.Size(177, 24);
            this.Sim_moveupInputFileMenuStripItem.Text = "Move Up";
            this.Sim_moveupInputFileMenuStripItem.Click += new System.EventHandler(this.Sim_moveupInputFileMenuStripItem_Click);
            // 
            // Sim_movedownInputFileMenuStripItem
            // 
            this.Sim_movedownInputFileMenuStripItem.Name = "Sim_movedownInputFileMenuStripItem";
            this.Sim_movedownInputFileMenuStripItem.Size = new System.Drawing.Size(177, 24);
            this.Sim_movedownInputFileMenuStripItem.Text = "Move Down";
            this.Sim_movedownInputFileMenuStripItem.Click += new System.EventHandler(this.Sim_movedownInputFileMenuStripItem_Click);
            // 
            // Sim_removeInputFileMenuStripItem
            // 
            this.Sim_removeInputFileMenuStripItem.Name = "Sim_removeInputFileMenuStripItem";
            this.Sim_removeInputFileMenuStripItem.Size = new System.Drawing.Size(177, 24);
            this.Sim_removeInputFileMenuStripItem.Text = "Remove File";
            this.Sim_removeInputFileMenuStripItem.Click += new System.EventHandler(this.Sim_removeInputFileMenuStripItem_Click);
            // 
            // Sim_previewInputFileMenuStripItem
            // 
            this.Sim_previewInputFileMenuStripItem.Name = "Sim_previewInputFileMenuStripItem";
            this.Sim_previewInputFileMenuStripItem.Size = new System.Drawing.Size(177, 24);
            this.Sim_previewInputFileMenuStripItem.Text = "Preview File";
            this.Sim_previewInputFileMenuStripItem.Click += new System.EventHandler(this.Sim_previewInputFileMenuStripItem_Click);
            // 
            // Sim_viewInputFileInfoMenuStripItem
            // 
            this.Sim_viewInputFileInfoMenuStripItem.Name = "Sim_viewInputFileInfoMenuStripItem";
            this.Sim_viewInputFileInfoMenuStripItem.Size = new System.Drawing.Size(177, 24);
            this.Sim_viewInputFileInfoMenuStripItem.Text = "View Info";
            this.Sim_viewInputFileInfoMenuStripItem.Click += new System.EventHandler(this.Sim_viewInputFileInfoMenuStripItem_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.NotifyFilter = System.IO.NotifyFilters.LastWrite;
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
            // 
            // ToolTip1
            // 
            this.ToolTip1.AutoPopDelay = 5000;
            this.ToolTip1.InitialDelay = 500;
            this.ToolTip1.ReshowDelay = 100;
            // 
            // Menu_openButton
            // 
            this.Menu_openButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Menu_openButton.ForeColor = System.Drawing.SystemColors.Control;
            this.Menu_openButton.Image = global::FFmpeg_EZ.Properties.Resources.menu_FILL0_wght400_GRAD0_opsz24;
            this.Menu_openButton.Location = new System.Drawing.Point(7, 2);
            this.Menu_openButton.Name = "Menu_openButton";
            this.Menu_openButton.Size = new System.Drawing.Size(30, 30);
            this.Menu_openButton.TabIndex = 0;
            this.ToolTip1.SetToolTip(this.Menu_openButton, "Open Menu");
            this.Menu_openButton.UseVisualStyleBackColor = true;
            this.Menu_openButton.Click += new System.EventHandler(this.Menu_openButton_Click);
            // 
            // Menu_closeButton
            // 
            this.Menu_closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Menu_closeButton.BackColor = System.Drawing.Color.Crimson;
            this.Menu_closeButton.BackgroundImage = global::FFmpeg_EZ.Properties.Resources.keyboard_arrow_left_FILL1_wght400_GRAD0_opsz24;
            this.Menu_closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Menu_closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Menu_closeButton.ForeColor = System.Drawing.Color.Crimson;
            this.Menu_closeButton.Location = new System.Drawing.Point(-8, 2);
            this.Menu_closeButton.Name = "Menu_closeButton";
            this.Menu_closeButton.Size = new System.Drawing.Size(30, 30);
            this.Menu_closeButton.TabIndex = 0;
            this.ToolTip1.SetToolTip(this.Menu_closeButton, "Close Menu");
            this.Menu_closeButton.UseVisualStyleBackColor = false;
            this.Menu_closeButton.Click += new System.EventHandler(this.Menu_closeButton_Click);
            // 
            // menuD_hwaccelWikiLLabel
            // 
            this.menuD_hwaccelWikiLLabel.AutoSize = true;
            this.menuD_hwaccelWikiLLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.menuD_hwaccelWikiLLabel.Location = new System.Drawing.Point(24, 248);
            this.menuD_hwaccelWikiLLabel.Name = "menuD_hwaccelWikiLLabel";
            this.menuD_hwaccelWikiLLabel.Size = new System.Drawing.Size(178, 40);
            this.menuD_hwaccelWikiLLabel.TabIndex = 1;
            this.menuD_hwaccelWikiLLabel.TabStop = true;
            this.menuD_hwaccelWikiLLabel.Text = "https://trac.ffmpeg.org/\r\nwiki/HWAccelIntro";
            this.ToolTip1.SetToolTip(this.menuD_hwaccelWikiLLabel, "Hardware Acceleration intro (wiki)");
            this.menuD_hwaccelWikiLLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.menuD_hwaccelWikiLLabel_LinkClicked);
            // 
            // menuD_AMDhwaccelGuideLLabel
            // 
            this.menuD_AMDhwaccelGuideLLabel.AutoSize = true;
            this.menuD_AMDhwaccelGuideLLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.menuD_AMDhwaccelGuideLLabel.Location = new System.Drawing.Point(24, 303);
            this.menuD_AMDhwaccelGuideLLabel.Name = "menuD_AMDhwaccelGuideLLabel";
            this.menuD_AMDhwaccelGuideLLabel.Size = new System.Drawing.Size(210, 100);
            this.menuD_AMDhwaccelGuideLLabel.TabIndex = 1;
            this.menuD_AMDhwaccelGuideLLabel.TabStop = true;
            this.menuD_AMDhwaccelGuideLLabel.Text = "https://askubuntu.com/\r\nquestions/1107782/\r\nhow-to-use-\r\ngpu-acceleration-\r\nin-ff" +
    "mpeg-with-amd-radeon";
            this.ToolTip1.SetToolTip(this.menuD_AMDhwaccelGuideLLabel, "Hardware Acceleration for AMD users\r\nhow it works and how to Build it");
            this.menuD_AMDhwaccelGuideLLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.menuD_AMDhwaccelGuideLLabel_LinkClicked);
            // 
            // menuD_easyCommandLLabel
            // 
            this.menuD_easyCommandLLabel.AutoSize = true;
            this.menuD_easyCommandLLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.menuD_easyCommandLLabel.Location = new System.Drawing.Point(25, 135);
            this.menuD_easyCommandLLabel.Name = "menuD_easyCommandLLabel";
            this.menuD_easyCommandLLabel.Size = new System.Drawing.Size(178, 60);
            this.menuD_easyCommandLLabel.TabIndex = 1;
            this.menuD_easyCommandLLabel.TabStop = true;
            this.menuD_easyCommandLLabel.Text = "https://ostechnix.com/\r\n20-ffmpeg-commands-\r\nbeginners/";
            this.ToolTip1.SetToolTip(this.menuD_easyCommandLLabel, "easy commands and usage of FFmpeg");
            this.menuD_easyCommandLLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.menuD_easyCommandLLabel_LinkClicked);
            // 
            // Timer_20
            // 
            this.Timer_20.Interval = 50;
            this.Timer_20.Tick += new System.EventHandler(this.Timer_20_Tick);
            // 
            // ToolTip2_longer
            // 
            this.ToolTip2_longer.AutoPopDelay = 10000;
            this.ToolTip2_longer.InitialDelay = 500;
            this.ToolTip2_longer.ReshowDelay = 100;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(27, 497);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(169, 18);
            this.label9.TabIndex = 0;
            this.label9.Text = "hardware Accel Encoder";
            this.ToolTip2_longer.SetToolTip(this.label9, resources.GetString("label9.ToolTip"));
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(29, 442);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 18);
            this.label7.TabIndex = 0;
            this.label7.Text = "process Argument";
            this.ToolTip2_longer.SetToolTip(this.label7, "Process Argument\r\n\r\nthis Argument will be parse in to every\r\nOutput stream while " +
        "rendering\r\nfor Hardware Accelerated Encoding \r\nuse the option below");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(29, 391);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 18);
            this.label10.TabIndex = 0;
            this.label10.Text = "input Argument";
            this.ToolTip2_longer.SetToolTip(this.label10, "Input Argument\r\n\r\nthis Argument will be parse in to the first\r\nInput stream while" +
        " rendering\r\ncan be usefull for specifying Global option\r\n");
            // 
            // Timer_1000
            // 
            this.Timer_1000.Interval = 1;
            this.Timer_1000.Tick += new System.EventHandler(this.Timer_1000_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.Color.Crimson;
            this.MenuPanel.Controls.Add(this.Menu_settingPanel);
            this.MenuPanel.Controls.Add(this.Menu_docPanel);
            this.MenuPanel.Controls.Add(this.Menu_aboutPanel);
            this.MenuPanel.Controls.Add(this.Menu_verLabel);
            this.MenuPanel.Controls.Add(this.Menu_docButton);
            this.MenuPanel.Controls.Add(this.Menu_SettingButton);
            this.MenuPanel.Controls.Add(this.Menu_aboutButton);
            this.MenuPanel.Controls.Add(this.Menu_closeButton);
            this.MenuPanel.Location = new System.Drawing.Point(-11, 0);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(25, 601);
            this.MenuPanel.TabIndex = 9;
            // 
            // Menu_settingPanel
            // 
            this.Menu_settingPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Menu_settingPanel.AutoScroll = true;
            this.Menu_settingPanel.BackColor = System.Drawing.Color.LightSlateGray;
            this.Menu_settingPanel.Controls.Add(this.MenuS_saveSettingCheckBox);
            this.Menu_settingPanel.Controls.Add(this.MenuS_toDefButton);
            this.Menu_settingPanel.Controls.Add(this.MenuS_dnhRadioButton);
            this.Menu_settingPanel.Controls.Add(this.MenuS_hbRadioButton);
            this.Menu_settingPanel.Controls.Add(this.MenuS_hofRadioButton);
            this.Menu_settingPanel.Controls.Add(this.MenuS_hocRadioButton);
            this.Menu_settingPanel.Controls.Add(this.MenuS_defOutPutPathTextBox);
            this.Menu_settingPanel.Controls.Add(this.MenuS_hwaccelCodeTextBox);
            this.Menu_settingPanel.Controls.Add(this.MenuS_inputArgTextBox);
            this.Menu_settingPanel.Controls.Add(this.MenuS_processArgTextBox);
            this.Menu_settingPanel.Controls.Add(this.MenuS_defInPutPathTextBox);
            this.Menu_settingPanel.Controls.Add(this.label4);
            this.Menu_settingPanel.Controls.Add(this.label9);
            this.Menu_settingPanel.Controls.Add(this.label10);
            this.Menu_settingPanel.Controls.Add(this.label8);
            this.Menu_settingPanel.Controls.Add(this.label7);
            this.Menu_settingPanel.Controls.Add(this.label3);
            this.Menu_settingPanel.Controls.Add(this.label6);
            this.Menu_settingPanel.Controls.Add(this.label5);
            this.Menu_settingPanel.Controls.Add(this.label2);
            this.Menu_settingPanel.Location = new System.Drawing.Point(-209, 424);
            this.Menu_settingPanel.Name = "Menu_settingPanel";
            this.Menu_settingPanel.Size = new System.Drawing.Size(236, 70);
            this.Menu_settingPanel.TabIndex = 3;
            // 
            // MenuS_saveSettingCheckBox
            // 
            this.MenuS_saveSettingCheckBox.AutoSize = true;
            this.MenuS_saveSettingCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuS_saveSettingCheckBox.Location = new System.Drawing.Point(32, 317);
            this.MenuS_saveSettingCheckBox.Name = "MenuS_saveSettingCheckBox";
            this.MenuS_saveSettingCheckBox.Size = new System.Drawing.Size(159, 22);
            this.MenuS_saveSettingCheckBox.TabIndex = 5;
            this.MenuS_saveSettingCheckBox.Text = "Save Settings to file";
            this.MenuS_saveSettingCheckBox.UseVisualStyleBackColor = true;
            // 
            // MenuS_toDefButton
            // 
            this.MenuS_toDefButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuS_toDefButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuS_toDefButton.Location = new System.Drawing.Point(107, 9);
            this.MenuS_toDefButton.Name = "MenuS_toDefButton";
            this.MenuS_toDefButton.Size = new System.Drawing.Size(128, 27);
            this.MenuS_toDefButton.TabIndex = 4;
            this.MenuS_toDefButton.Text = "Reset to Default";
            this.MenuS_toDefButton.UseVisualStyleBackColor = true;
            this.MenuS_toDefButton.Click += new System.EventHandler(this.MenuS_toDefButton_Click);
            // 
            // MenuS_dnhRadioButton
            // 
            this.MenuS_dnhRadioButton.AutoSize = true;
            this.MenuS_dnhRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuS_dnhRadioButton.Location = new System.Drawing.Point(32, 288);
            this.MenuS_dnhRadioButton.Name = "MenuS_dnhRadioButton";
            this.MenuS_dnhRadioButton.Size = new System.Drawing.Size(132, 22);
            this.MenuS_dnhRadioButton.TabIndex = 3;
            this.MenuS_dnhRadioButton.TabStop = true;
            this.MenuS_dnhRadioButton.Text = "Do not hide any";
            this.MenuS_dnhRadioButton.UseVisualStyleBackColor = true;
            // 
            // MenuS_hbRadioButton
            // 
            this.MenuS_hbRadioButton.AutoSize = true;
            this.MenuS_hbRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuS_hbRadioButton.Location = new System.Drawing.Point(32, 267);
            this.MenuS_hbRadioButton.Name = "MenuS_hbRadioButton";
            this.MenuS_hbRadioButton.Size = new System.Drawing.Size(92, 22);
            this.MenuS_hbRadioButton.TabIndex = 3;
            this.MenuS_hbRadioButton.TabStop = true;
            this.MenuS_hbRadioButton.Text = "Hide both";
            this.MenuS_hbRadioButton.UseVisualStyleBackColor = true;
            // 
            // MenuS_hofRadioButton
            // 
            this.MenuS_hofRadioButton.AutoSize = true;
            this.MenuS_hofRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuS_hofRadioButton.Location = new System.Drawing.Point(32, 244);
            this.MenuS_hofRadioButton.Name = "MenuS_hofRadioButton";
            this.MenuS_hofRadioButton.Size = new System.Drawing.Size(197, 22);
            this.MenuS_hofRadioButton.TabIndex = 3;
            this.MenuS_hofRadioButton.TabStop = true;
            this.MenuS_hofRadioButton.Text = "Hide only FFmpeg Output";
            this.MenuS_hofRadioButton.UseVisualStyleBackColor = true;
            // 
            // MenuS_hocRadioButton
            // 
            this.MenuS_hocRadioButton.AutoSize = true;
            this.MenuS_hocRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuS_hocRadioButton.Location = new System.Drawing.Point(32, 220);
            this.MenuS_hocRadioButton.Name = "MenuS_hocRadioButton";
            this.MenuS_hocRadioButton.Size = new System.Drawing.Size(129, 22);
            this.MenuS_hocRadioButton.TabIndex = 3;
            this.MenuS_hocRadioButton.TabStop = true;
            this.MenuS_hocRadioButton.Text = "Hide only CMD";
            this.MenuS_hocRadioButton.UseVisualStyleBackColor = true;
            // 
            // MenuS_defOutPutPathTextBox
            // 
            this.MenuS_defOutPutPathTextBox.BackColor = System.Drawing.Color.Firebrick;
            this.MenuS_defOutPutPathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MenuS_defOutPutPathTextBox.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.MenuS_defOutPutPathTextBox.Location = new System.Drawing.Point(28, 115);
            this.MenuS_defOutPutPathTextBox.Name = "MenuS_defOutPutPathTextBox";
            this.MenuS_defOutPutPathTextBox.Size = new System.Drawing.Size(191, 27);
            this.MenuS_defOutPutPathTextBox.TabIndex = 1;
            this.MenuS_defOutPutPathTextBox.TextChanged += new System.EventHandler(this.MenuS_TextBox_TextChanged);
            // 
            // MenuS_hwaccelCodeTextBox
            // 
            this.MenuS_hwaccelCodeTextBox.BackColor = System.Drawing.Color.Firebrick;
            this.MenuS_hwaccelCodeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MenuS_hwaccelCodeTextBox.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.MenuS_hwaccelCodeTextBox.Location = new System.Drawing.Point(26, 518);
            this.MenuS_hwaccelCodeTextBox.Name = "MenuS_hwaccelCodeTextBox";
            this.MenuS_hwaccelCodeTextBox.Size = new System.Drawing.Size(191, 27);
            this.MenuS_hwaccelCodeTextBox.TabIndex = 1;
            this.MenuS_hwaccelCodeTextBox.TextChanged += new System.EventHandler(this.MenuS_TextBox_TextChanged);
            // 
            // MenuS_inputArgTextBox
            // 
            this.MenuS_inputArgTextBox.BackColor = System.Drawing.Color.Firebrick;
            this.MenuS_inputArgTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MenuS_inputArgTextBox.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.MenuS_inputArgTextBox.Location = new System.Drawing.Point(28, 412);
            this.MenuS_inputArgTextBox.Name = "MenuS_inputArgTextBox";
            this.MenuS_inputArgTextBox.Size = new System.Drawing.Size(191, 27);
            this.MenuS_inputArgTextBox.TabIndex = 1;
            this.MenuS_inputArgTextBox.TextChanged += new System.EventHandler(this.MenuS_TextBox_TextChanged);
            // 
            // MenuS_processArgTextBox
            // 
            this.MenuS_processArgTextBox.BackColor = System.Drawing.Color.Firebrick;
            this.MenuS_processArgTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MenuS_processArgTextBox.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.MenuS_processArgTextBox.Location = new System.Drawing.Point(28, 463);
            this.MenuS_processArgTextBox.Name = "MenuS_processArgTextBox";
            this.MenuS_processArgTextBox.Size = new System.Drawing.Size(191, 27);
            this.MenuS_processArgTextBox.TabIndex = 1;
            this.MenuS_processArgTextBox.TextChanged += new System.EventHandler(this.MenuS_TextBox_TextChanged);
            // 
            // MenuS_defInPutPathTextBox
            // 
            this.MenuS_defInPutPathTextBox.BackColor = System.Drawing.Color.Firebrick;
            this.MenuS_defInPutPathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MenuS_defInPutPathTextBox.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.MenuS_defInPutPathTextBox.Location = new System.Drawing.Point(28, 59);
            this.MenuS_defInPutPathTextBox.Name = "MenuS_defInPutPathTextBox";
            this.MenuS_defInPutPathTextBox.Size = new System.Drawing.Size(191, 27);
            this.MenuS_defInPutPathTextBox.TabIndex = 1;
            this.MenuS_defInPutPathTextBox.TextChanged += new System.EventHandler(this.MenuS_TextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "default Output folder";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(29, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(184, 18);
            this.label8.TabIndex = 0;
            this.label8.Text = "Hide CMD/FFmpeg Output";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "default Input folder";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 362);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 22);
            this.label6.TabIndex = 0;
            this.label6.Text = "FFmpeg (Advance)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 22);
            this.label5.TabIndex = 0;
            this.label5.Text = "System";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Paths";
            // 
            // Menu_docPanel
            // 
            this.Menu_docPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Menu_docPanel.AutoScroll = true;
            this.Menu_docPanel.BackColor = System.Drawing.Color.LightSlateGray;
            this.Menu_docPanel.Controls.Add(this.menuD_AMDhwaccelGuideLLabel);
            this.Menu_docPanel.Controls.Add(this.menuD_easyCommandLLabel);
            this.Menu_docPanel.Controls.Add(this.menuD_hwaccelWikiLLabel);
            this.Menu_docPanel.Controls.Add(this.menuD_ffmpegDocLLabel);
            this.Menu_docPanel.Controls.Add(this.label14);
            this.Menu_docPanel.Controls.Add(this.label13);
            this.Menu_docPanel.Controls.Add(this.label11);
            this.Menu_docPanel.Location = new System.Drawing.Point(-209, 498);
            this.Menu_docPanel.Name = "Menu_docPanel";
            this.Menu_docPanel.Size = new System.Drawing.Size(236, 67);
            this.Menu_docPanel.TabIndex = 3;
            // 
            // menuD_ffmpegDocLLabel
            // 
            this.menuD_ffmpegDocLLabel.AutoSize = true;
            this.menuD_ffmpegDocLLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.menuD_ffmpegDocLLabel.Location = new System.Drawing.Point(24, 48);
            this.menuD_ffmpegDocLLabel.Name = "menuD_ffmpegDocLLabel";
            this.menuD_ffmpegDocLLabel.Size = new System.Drawing.Size(185, 40);
            this.menuD_ffmpegDocLLabel.TabIndex = 1;
            this.menuD_ffmpegDocLLabel.TabStop = true;
            this.menuD_ffmpegDocLLabel.Text = "https://www.ffmpeg.org/\r\ndocumentation.html";
            this.menuD_ffmpegDocLLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.menuD_ffmpegDocLLabel_LinkClicked);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(10, 111);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(212, 22);
            this.label14.TabIndex = 0;
            this.label14.Text = "FFmpeg Easy commands";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(11, 222);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(192, 22);
            this.label13.TabIndex = 0;
            this.label13.Text = "Hardware Acceleration";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(11, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(173, 22);
            this.label11.TabIndex = 0;
            this.label11.Text = "Official FFmpeg Doc";
            // 
            // Menu_aboutPanel
            // 
            this.Menu_aboutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Menu_aboutPanel.AutoScroll = true;
            this.Menu_aboutPanel.BackColor = System.Drawing.Color.LightSlateGray;
            this.Menu_aboutPanel.Controls.Add(this.label12);
            this.Menu_aboutPanel.Location = new System.Drawing.Point(-210, 342);
            this.Menu_aboutPanel.Name = "Menu_aboutPanel";
            this.Menu_aboutPanel.Size = new System.Drawing.Size(236, 77);
            this.Menu_aboutPanel.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(8, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(231, 684);
            this.label12.TabIndex = 1;
            this.label12.Text = resources.GetString("label12.Text");
            // 
            // Menu_verLabel
            // 
            this.Menu_verLabel.AutoSize = true;
            this.Menu_verLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Menu_verLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Menu_verLabel.Location = new System.Drawing.Point(12, 578);
            this.Menu_verLabel.Name = "Menu_verLabel";
            this.Menu_verLabel.Size = new System.Drawing.Size(106, 16);
            this.Menu_verLabel.TabIndex = 2;
            this.Menu_verLabel.Text = "FFEasy Version ";
            // 
            // Menu_docButton
            // 
            this.Menu_docButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Menu_docButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Menu_docButton.Font = new System.Drawing.Font("Swera Demo", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Menu_docButton.Location = new System.Drawing.Point(-211, 143);
            this.Menu_docButton.Name = "Menu_docButton";
            this.Menu_docButton.Size = new System.Drawing.Size(218, 45);
            this.Menu_docButton.TabIndex = 1;
            this.Menu_docButton.Text = "    Documents";
            this.Menu_docButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Menu_docButton.UseVisualStyleBackColor = true;
            this.Menu_docButton.Click += new System.EventHandler(this.Menu_docButton_Click);
            // 
            // Menu_SettingButton
            // 
            this.Menu_SettingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Menu_SettingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Menu_SettingButton.Font = new System.Drawing.Font("Swera Demo", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Menu_SettingButton.Location = new System.Drawing.Point(-211, 92);
            this.Menu_SettingButton.Name = "Menu_SettingButton";
            this.Menu_SettingButton.Size = new System.Drawing.Size(218, 45);
            this.Menu_SettingButton.TabIndex = 1;
            this.Menu_SettingButton.Text = "    Settings";
            this.Menu_SettingButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Menu_SettingButton.UseVisualStyleBackColor = true;
            this.Menu_SettingButton.Click += new System.EventHandler(this.Menu_SettingButton_Click);
            // 
            // Menu_aboutButton
            // 
            this.Menu_aboutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Menu_aboutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Menu_aboutButton.Font = new System.Drawing.Font("Swera Demo", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Menu_aboutButton.Location = new System.Drawing.Point(-211, 41);
            this.Menu_aboutButton.Name = "Menu_aboutButton";
            this.Menu_aboutButton.Size = new System.Drawing.Size(218, 45);
            this.Menu_aboutButton.TabIndex = 1;
            this.Menu_aboutButton.Text = "    About";
            this.Menu_aboutButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Menu_aboutButton.UseVisualStyleBackColor = true;
            this.Menu_aboutButton.Click += new System.EventHandler(this.Menu_aboutButton_Click);
            // 
            // Coverpanel_top
            // 
            this.Coverpanel_top.Controls.Add(this.Menu_openButton);
            this.Coverpanel_top.Location = new System.Drawing.Point(-6, -3);
            this.Coverpanel_top.Name = "Coverpanel_top";
            this.Coverpanel_top.Size = new System.Drawing.Size(48, 33);
            this.Coverpanel_top.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(481, 601);
            this.Controls.Add(this.MenuPanel);
            this.Controls.Add(this.Coverpanel_top);
            this.Controls.Add(this.Sim_statusStrip);
            this.Controls.Add(this.MainTabControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "FFmpeg made Easy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.Sim_CommandExePanel.ResumeLayout(false);
            this.Sim_CommandExePanel.PerformLayout();
            this.Sim_outputGroupBox.ResumeLayout(false);
            this.Sim_outputGroupBox.PerformLayout();
            this.Sim_processGroupBox.ResumeLayout(false);
            this.Sim_InputGroupBox.ResumeLayout(false);
            this.Sim_InputGroupBox.PerformLayout();
            this.Sim_statusStrip.ResumeLayout(false);
            this.Sim_statusStrip.PerformLayout();
            this.MainTabControl.ResumeLayout(false);
            this.Sim_inputFileMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.MenuPanel.ResumeLayout(false);
            this.MenuPanel.PerformLayout();
            this.Menu_settingPanel.ResumeLayout(false);
            this.Menu_settingPanel.PerformLayout();
            this.Menu_docPanel.ResumeLayout(false);
            this.Menu_docPanel.PerformLayout();
            this.Menu_aboutPanel.ResumeLayout(false);
            this.Menu_aboutPanel.PerformLayout();
            this.Coverpanel_top.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.Button Sim_removeInputFileButton;
        private System.Windows.Forms.Button Sim_addInputFileButton;
        private System.Windows.Forms.Label Sim_inputFileLabel;
        private System.Windows.Forms.TextBox Sim_OutputFileTextBox;
        private System.Windows.Forms.ListBox Sim_inputFilelistBox;
        private System.Windows.Forms.OpenFileDialog OpenInputFileDialog;
        private System.Windows.Forms.GroupBox Sim_InputGroupBox;
        private System.Windows.Forms.ContextMenuStrip Sim_inputFileMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem Sim_trimInputFileMenuStripItem;
        private System.Windows.Forms.ToolStripMenuItem Sim_offsetFileMenuStripItem;
        private System.Windows.Forms.ToolStripMenuItem Sim_moveupInputFileMenuStripItem;
        private System.Windows.Forms.ToolStripMenuItem Sim_movedownInputFileMenuStripItem;
        private System.Windows.Forms.ToolStripMenuItem Sim_removeInputFileMenuStripItem;
        private System.Windows.Forms.StatusStrip Sim_statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel Sim_statusStripLabel;
        private System.Windows.Forms.ToolStripMenuItem Sim_trimInputFileMenuStripSubItem_addNmod;
        private System.Windows.Forms.ToolStripMenuItem Sim_trimInputFileMenuStripSubItem_rm;
        private System.Windows.Forms.ToolStripMenuItem Sim_offsetFileMenuStripSubItem_addNmod;
        private System.Windows.Forms.ToolStripMenuItem Sim_offsetFileMenuStripSubItem_rm;
        private System.Windows.Forms.GroupBox Sim_processGroupBox;
        private System.Windows.Forms.GroupBox Sim_outputGroupBox;
        private System.Windows.Forms.TreeView Sim_processTreeView;
        private System.Windows.Forms.ToolStripMenuItem Sim_previewInputFileMenuStripItem;
        private System.Windows.Forms.ToolStripMenuItem Sim_viewInputFileInfoMenuStripItem;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button Sim_ClearProcessOptButton;
        private System.Windows.Forms.Button Sim_OpenSaveFileButton;
        private System.Windows.Forms.ToolTip ToolTip1;
        private System.Windows.Forms.Timer Timer_20;
        private System.Windows.Forms.Button Sim_forceFormatButton;
        private System.Windows.Forms.ToolTip ToolTip2_longer;
        private System.Windows.Forms.SaveFileDialog SaveOutputFileDialog;
        private System.Windows.Forms.Button Sim_clearOutputButton;
        private System.Windows.Forms.Panel Sim_CommandExePanel;
        private System.Windows.Forms.Button Sim_resetButton;
        private System.Windows.Forms.Button Sim_continueButton;
        private System.Windows.Forms.Timer Timer_1000;
        private System.Windows.Forms.Button CE_panelCloseButton;
        private System.Windows.Forms.Button CE_genCmdCopyButton;
        private System.Windows.Forms.Label CE_genCommandLabel;
        private System.Windows.Forms.Button CE_runCommandButton;
        private System.Windows.Forms.Label CE_whatItDoesLabel;
        private System.Windows.Forms.RichTextBox CE_whatItDoesRTextBox;
        private System.Windows.Forms.RichTextBox CE_commandRTextBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button CE_genCmdExpandButton;
        private System.Windows.Forms.Button CE_whatItDoesExpandButton;
        private System.Windows.Forms.ProgressBar CE_progressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.Button Menu_closeButton;
        private System.Windows.Forms.Button CE_stopCommandButton;
        private System.Windows.Forms.Panel Coverpanel_top;
        private System.Windows.Forms.Button Menu_openButton;
        private System.Windows.Forms.Button Menu_SettingButton;
        private System.Windows.Forms.Button Menu_aboutButton;
        private System.Windows.Forms.Label Menu_verLabel;
        private System.Windows.Forms.Button Menu_docButton;
        private System.Windows.Forms.Panel Menu_aboutPanel;
        private System.Windows.Forms.Panel Menu_settingPanel;
        private System.Windows.Forms.Panel Menu_docPanel;
        private System.Windows.Forms.TextBox MenuS_defInPutPathTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox MenuS_defOutPutPathTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton MenuS_dnhRadioButton;
        private System.Windows.Forms.RadioButton MenuS_hbRadioButton;
        private System.Windows.Forms.RadioButton MenuS_hofRadioButton;
        private System.Windows.Forms.RadioButton MenuS_hocRadioButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox MenuS_processArgTextBox;
        private System.Windows.Forms.TextBox MenuS_hwaccelCodeTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button MenuS_toDefButton;
        private System.Windows.Forms.CheckBox MenuS_saveSettingCheckBox;
        private System.Windows.Forms.TextBox MenuS_inputArgTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.LinkLabel menuD_ffmpegDocLLabel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.LinkLabel menuD_AMDhwaccelGuideLLabel;
        private System.Windows.Forms.LinkLabel menuD_easyCommandLLabel;
        private System.Windows.Forms.LinkLabel menuD_hwaccelWikiLLabel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox Sim_repeatAllInputCheckBox;
        private System.Windows.Forms.Label CE_stepLable;
    }
}

