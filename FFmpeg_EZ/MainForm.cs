using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FFmpeg_EZ.subform;

namespace FFmpeg_EZ
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            App.loadConfig();
            if (App.prefs == null) App.prefs = App.defaultConfig;
            InitializeComponent();


            thisDefSize = this.Size;

            // prepare Animation
            AMenuPanel = new App.Animetible();
            AMenuPanel.control = MenuPanel;
            AMenuPanel.startSize = new Size(
                menuPanelStartWidth,
                MenuPanel.Size.Height
            );

            AcExcPanel = new App.Animetible();
            AcExcPanel.control = Sim_CommandExePanel;
            AcExcPanel.startSize = new Size(
                Sim_CommandExePanel.Size.Width,
                cExePanelStartHeight
            );

           
            


            AppControl.FixPointResize(Menu_aboutButton, new Size(
                (int)(
                    (this.Size.Width * menuPanelExpandPhase1Mul) * menuPanelButtonExpandMul
                ),
                Menu_aboutButton.Size.Height
            ), "tr");
            
            AppControl.FixPointResize(Menu_SettingButton, new Size(
                (int)(
                    (this.Size.Width * menuPanelExpandPhase1Mul) * menuPanelButtonExpandMul
                ),
                Menu_SettingButton.Size.Height
            ), "tr");
            
            AppControl.FixPointResize(Menu_docButton, new Size(
                (int)(
                    (this.Size.Width * menuPanelExpandPhase1Mul) * menuPanelButtonExpandMul
                ),
                Menu_docButton.Size.Height
            ), "tr");

            AMenuAboutButton = new App.Animetible();
            AMenuAboutButton.control = Menu_aboutButton;

            AMenuSettingButton = new App.Animetible();
            AMenuSettingButton.control = Menu_SettingButton;

            AMenuDocButton = new App.Animetible();
            AMenuDocButton.control = Menu_docButton;


            ASubMenuAboutPanel = new App.Animetible();
            ASubMenuAboutPanel.control = Menu_aboutPanel;

            ASubMenuSettingPanel = new App.Animetible();
            ASubMenuSettingPanel.control = Menu_settingPanel;

            ASubMenuDocPanel = new App.Animetible();
            ASubMenuDocPanel.control = Menu_docPanel;


            // resize & position Controls
            AppControl.FixPointResize(Sim_CommandExePanel, new Size(
                Sim_CommandExePanel.Size.Width,
                cExePanelStartHeight
            ), "bl");

            AppControl.FixPointResize(MenuPanel, new Size(
                menuPanelStartWidth,
                MenuPanel.Size.Height
            ), "tl");

            AppControl.FixPointResize(Coverpanel_top, new Size(
                coverPanel_topWidth,
                Coverpanel_top.Size.Height
            ), "tl");


            AppControl.FixPointResize(Menu_aboutPanel, new Size(
                MenuSubpanelHindedSize.Width,
                MenuSubpanelHindedSize.Height
            ), "bl");
                     
            AppControl.FixPointResize(Menu_settingPanel, new Size(
                MenuSubpanelHindedSize.Width,
                MenuSubpanelHindedSize.Height
            ), "bl");
            
            AppControl.FixPointResize(Menu_docPanel, new Size(
                MenuSubpanelHindedSize.Width,
                MenuSubpanelHindedSize.Height
            ), "bl");




            Menu_aboutPanel.Location = MenuSubpanelPos;
            Menu_settingPanel.Location = MenuSubpanelPos;
            Menu_docPanel.Location = MenuSubpanelPos;







            // load Menu
            Menu_verLabel.Text += App.Version;
            Menu_aboutPanel.Visible = false;
            Menu_settingPanel.Visible = false;
            Menu_docPanel.Visible = false;

            if (!App.makeMenuPanelVisible)
            {
                Menu_aboutPanel.BackColor = Color.Crimson;
                Menu_settingPanel.BackColor = Color.Crimson;
                Menu_docPanel.BackColor = Color.Crimson;

            }



            CE_loadingTextColor = CE_commandRTextBox.ForeColor;
            CE_loadingTextFont = CE_commandRTextBox.Font;
            CE_normalTextColor = Sim_CommandExePanel.ForeColor;
            CE_cmdLoadingText = CE_commandRTextBox.Text;
            CE_whatItDoesLoadingText = CE_whatItDoesRTextBox.Text;

            CE_stopCommandButton.Location = CE_runCommandButton.Location;



            try
            {// if path does not exits will thow an Exception
                fileSystemWatcher1.Path = App.prefs?.js_folderP ?? App.defaultConfig.js_folderP;
            }
            catch
            {// if so, catch it by creating Directory
                Directory.CreateDirectory(App.prefs?.js_folderP ?? App.defaultConfig.js_folderP);
                fileSystemWatcher1.Path = App.prefs?.js_folderP ?? App.defaultConfig.js_folderP;
            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            setCEControlDisEnable(false);
            Timer_20.Start();
            Timer_1000.Start();

            App.checkMissingDep();
            App.generateMissingDep();


            if (App.MissingFFmpeg || App.MissingMpv || App.MissingFFprobe || App.MissingNodeJS)
            {
                string res = "Missing Exe: \n";
                if (App.MissingFFmpeg) res += "     ffmpeg.exe\n";
                if (App.MissingMpv) res += "     mpv.exe\n";
                if (App.MissingFFprobe) res += "    ffprobe.exe\n";
                if (App.MissingNodeJS) res += "    node.exe\n";
                MessageBox.Show(
                    res + "\nsome features may not function correctly!",
                    "Dependencies Missing",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }


            if (File.Exists($"{App.prefs.js_folderP}.cache01")){
                File.WriteAllText($"{App.prefs.js_folderP}.cache01", "");
            }
            
            if (File.Exists($"{App.prefs.js_folderP}.cache02")){
                File.WriteAllText($"{App.prefs.js_folderP}.cache02", "");
            }

        }



        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            App.appClosing = true;
            CE_stopCommandButton_Click(new object { }, new EventArgs());
            App.prefs.lastSelInputExt = App.lastChooseFileExt;

            if (!App.prefs.saveSettingToFile) return;
            App.saveConfig();
        }












        //////          PUBLIC           //////
        // PUBLIC var



        // PUBLIC class




        // PUBLIC functions
        public void clearStatusBar(string tabShortName = null)
        {
            
            if(tabShortName == null)
            {
                Sim_statusStripLabel.Text = "";
                Sim_statusStripLabel.ForeColor = Color.Black;
                return;
            }

            switch(tabShortName.ToLower()){
                case "sim":
                    Sim_statusStripLabel.Text = "";
                    Sim_statusStripLabel.ForeColor = Color.Black;
                    break;

                case "adv":
                    // reserve for future update
                    break;
            }
        }


























        //////          PRIVATE          //////
        /// Form var
        private TimeSessionSelectForm TSSform;
        private OffsetSelectForm OFSform;
        private Uni_PromptFormTypeN1 UPFTypeN1;
        private V_scaleSelectForm v_scaleForm;
        private V_cropSelectForm v_cropForm;
        private SimStrmMappingForm strmMapForm;
        private Uni_PromptFormTypeC1 UPFTypeC1;
        private ExpandTextForm CE_cmdExpForm;
        private ExpandTextForm CE_whatItDoesExpForm;
        private SetMetadataForm MetadataForm;
        private ExpandTextForm CMDOutputViewForm;


        private Process process = null;
        private List<Trigger> triggers = new List<Trigger>();
        private bool settingInvalid = false;
        

        /// const
        private readonly Size thisDefSize;
        private const int cExePanelStartHeight = 39;
        private const int menuPanelStartWidth = 13;
        private const int coverPanel_topWidth = 486;
        private const double menuPanelExpandPhase1Mul = 0.52;
        private const double cExcPanelExpandMul = 0.83;
        private const double menuPanelButtonExpandMul = 0.936;
        private const int menuPanelButtonTopPading = 32;
        private const double menuPanelButtonOpenXMul = 0.168;
        private readonly Size MenuSubpanelExpandedSize = new Size(236, 483);
        private readonly Size MenuSubpanelHindedSize = new Size(236, 10);
        private readonly Point MenuSubpanelPos = new Point(10, 78);


        /// Animation
        private App.Animetible AMenuPanel = null;
        private App.Animetible AcExcPanel = null;
        private App.Animetible AMenuAboutButton = null;
        private App.Animetible AMenuSettingButton = null;
        private App.Animetible AMenuDocButton = null;
        private App.Animetible ASubMenuAboutPanel = null;
        private App.Animetible ASubMenuSettingPanel = null;
        private App.Animetible ASubMenuDocPanel = null;

        /// Menu
        private sbyte menu_openedButtonPage = -1; //index number
        private bool menu_closeButtonGobackMode = false;
        private const string menu_closeButtonDefTTtext = "Close Menu";
        private const string menu_closeButtonGobackTTtext = "Go Back";

        /// CE
        private readonly Font CE_normalTextFont = new Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        private readonly dynamic CE_normalTextColor = null;
        private readonly Font CE_loadingTextFont = null;
        private readonly dynamic CE_loadingTextColor = null;
        private readonly string CE_cmdLoadingText = null;
        private readonly string CE_whatItDoesLoadingText = null;

        /// System
        private const StringSplitOptions OptNone = StringSplitOptions.None;
      /*  private string lastCache01Content = null;
        private string lastCache02Content = null;
*/









        /// Class
        private class Trigger
        {
            public dynamic control = null;
            public App.Animetible AControl = null;
            public string type = null;
            public int EventKeyFrame = 0;
            public List<int> eventPoints = new List<int>();
        }



        /// Functions
        private bool hasTrigger(string q, List<Trigger> tg)
        {
            foreach(Trigger t in tg)
                if(t.type == q) return true;
            return false;
        }
        
        
        private void removeSelectedInputFile()
        {
            clearStatusBar("sim");
            int selIndex = Sim_inputFilelistBox.SelectedIndex;
            if (selIndex == -1) return;
            Sim_inputFilelistBox.Items.RemoveAt(selIndex);

            App.IDlist.Remove(App.Sim_inputFiles[selIndex].ID);
            App.Sim_inputFiles.RemoveAt(selIndex);

        }

        /// <summary>
        /// update treeView Color to reflect what option has been changed
        /// </summary>
        /// <param name="nodeNameWithChange">name of node that has its option changed</param>
        /// <param name="formToCheck">the form that made changed to that options</param>
        private void updateOptTreeViewColor(string nodeNameWithChange = null, dynamic formToCheck = null, object setNoSelection = null)
        {
            if(setNoSelection?.GetType() != typeof(bool)) setNoSelection = null;
            // set TreeView color
            foreach (TreeNode node in Sim_processTreeView.Nodes) // loop through parent Nodes
            {
                foreach (TreeNode subNode1 in node.Nodes) // loop through subNodes(childNodes) layer 1
                {
                    if (subNode1.Name != nodeNameWithChange&&nodeNameWithChange != null) continue;
                    if(setNoSelection != null)
                    {
                        if ((bool) setNoSelection) setNodeNoEdit(subNode1, node);
                        else setNodeEdited(subNode1, node);
                    }
                    else if (formToCheck?.selection == null || formToCheck == null)
                    {
                        setNodeNoEdit(subNode1, node);
                        if (formToCheck != null) return;
                    }
                    else
                    {
                        setNodeEdited(subNode1, node);
                        return;
                    }
                }
            }


            void setNodeNoEdit(TreeNode subNode, TreeNode Pnode)
            {
                subNode.ForeColor = Color.Black;
                // skip, if any subNode in this layer has some changes
                if (formToCheck != null)
                    foreach (TreeNode currenLayerN in Pnode.Nodes) if (currenLayerN.ForeColor == Color.Aqua) return;
                Pnode.ForeColor = Color.Black;
            }

            void setNodeEdited(TreeNode subNode, TreeNode Pnode)
            {
                subNode.ForeColor = Color.Aqua;
                Pnode.ForeColor = Color.Aqua;
            }
        }

        /// <summary>
        /// set Main Control on Sim-page disable/enable
        /// </summary>
        /// <param name="enable"></param>
        private void setControlDisEnable(bool enable)
        {
            Sim_addInputFileButton.Enabled = enable;
            Sim_inputFilelistBox.Enabled = enable;
            Sim_removeInputFileButton.Enabled = enable;
            Sim_InputGroupBox.Enabled = enable;
            Sim_outputGroupBox.Enabled = enable;
            Sim_processGroupBox.Enabled = enable;
            Sim_inputFileLabel.Enabled = enable;
            Sim_continueButton.Enabled = enable;
            Sim_resetButton.Enabled = enable;
        }

        /// <summary>
        /// set CEpanel's control disable/enable
        /// </summary>
        /// <param name="enable"></param>
        private void setCEControlDisEnable(bool enable)
        {
            CE_panelCloseButton.Enabled = enable;
            CE_genCommandLabel.Enabled = enable;
            CE_commandRTextBox.Enabled = enable;
            CE_whatItDoesRTextBox.Enabled = enable;
            CE_whatItDoesLabel.Enabled = enable;
            CE_runCommandButton.Enabled = enable;
        }

        /// <summary>
        /// set MenuPanel's control disable/enable
        /// </summary>
        /// <param name="enable"></param>
        private void setMenuControlDisEnable(bool enable)
        {
            Menu_closeButton.Enabled = enable;
            Menu_aboutButton.Enabled = enable;
            Menu_SettingButton.Enabled = enable;
            Menu_docButton.Enabled = enable;
            Menu_verLabel.Enabled = enable;
            Menu_aboutPanel.Enabled = enable;
            Menu_settingPanel.Enabled = enable;
            Menu_docPanel.Enabled = enable;
        }



        private void loadSettingsToPanel()
        {
            MenuS_defInPutPathTextBox.Text = App.prefs.defOpenInputP;
            MenuS_defOutPutPathTextBox.Text = App.prefs.defOpenOutputP;

            MenuS_hofRadioButton.Checked = MenuS_hocRadioButton.Checked
                = MenuS_hbRadioButton.Checked = MenuS_dnhRadioButton.Checked = false;
            if (App.prefs.hideCMD && !App.prefs.hideFFmpegOutput)
                MenuS_hocRadioButton.Checked = true;
            else if (App.prefs.hideFFmpegOutput && !App.prefs.hideCMD)
                MenuS_hofRadioButton.Checked = true;
            else if (App.prefs.hideFFmpegOutput && App.prefs.hideCMD)
                MenuS_hbRadioButton.Checked = true;
            else if (!App.prefs.hideFFmpegOutput && !App.prefs.hideCMD)
                MenuS_dnhRadioButton.Checked = true;

            MenuS_saveSettingCheckBox.Checked = App.prefs.saveSettingToFile;

            MenuS_inputArgTextBox.Text = App.prefs.FF_inputArg;
            MenuS_processArgTextBox.Text = App.prefs.FF_processArg;
            MenuS_hwaccelCodeTextBox.Text = App.prefs.FF_hardwareAccelDecodeCodec;
        }


        private void saveSettingsToPref()
        {
            if (MenuS_defInPutPathTextBox.Text.Trim() == "") App.prefs.defOpenInputP = null;
            else App.prefs.defOpenInputP = MenuS_defInPutPathTextBox.Text.Trim();

            if (MenuS_defOutPutPathTextBox.Text.Trim() == "") App.prefs.defOpenOutputP = null;
            else App.prefs.defOpenOutputP = MenuS_defOutPutPathTextBox.Text.Trim();

            App.prefs.hideFFmpegOutput = App.prefs.hideCMD = false;
            if (MenuS_hofRadioButton.Checked||MenuS_hbRadioButton.Checked)
                App.prefs.hideFFmpegOutput = true;
            if (MenuS_hocRadioButton.Checked || MenuS_hbRadioButton.Checked)
                App.prefs.hideCMD = true;

            App.prefs.saveSettingToFile = MenuS_saveSettingCheckBox.Checked;

            if (MenuS_inputArgTextBox.Text.Trim() == "") App.prefs.FF_inputArg = null;
            else App.prefs.FF_inputArg = MenuS_inputArgTextBox.Text.Trim();

            if (MenuS_processArgTextBox.Text.Trim() == "") App.prefs.FF_processArg = null;
            else App.prefs.FF_processArg = MenuS_processArgTextBox.Text.Trim();

            if (MenuS_hwaccelCodeTextBox.Text.Trim() == "") 
                App.prefs.FF_hardwareAccelDecodeCodec = null;
            else App.prefs.FF_hardwareAccelDecodeCodec = MenuS_hwaccelCodeTextBox.Text.Trim().ToLower();
        }


        private void checkSettingValid()
        {
            settingInvalid = false;
            string defIpath = MenuS_defInPutPathTextBox.Text.Trim();
            if (!Directory.Exists(defIpath)&&defIpath != "")
            {
                ToolTip1.SetToolTip(MenuS_defInPutPathTextBox, "this Directory path does not exists");
                MenuS_defInPutPathTextBox.ForeColor = Color.Red;
                settingInvalid = true;
            }
            else
            {
                ToolTip1.SetToolTip(MenuS_defInPutPathTextBox, null);
                MenuS_defInPutPathTextBox.ForeColor = Color.WhiteSmoke;

            }


            string defOpath = MenuS_defOutPutPathTextBox.Text.Trim();
            if (!Directory.Exists(defOpath) && defOpath != "")
            {
                ToolTip1.SetToolTip(MenuS_defOutPutPathTextBox, "this Directory path does not exists");
                MenuS_defOutPutPathTextBox.ForeColor = Color.Red;
                settingInvalid = true;
            }
            else
            {
                ToolTip1.SetToolTip(MenuS_defOutPutPathTextBox, null);
                MenuS_defOutPutPathTextBox.ForeColor = Color.WhiteSmoke;
            }


            string hwaccelCode = MenuS_hwaccelCodeTextBox.Text.Trim().ToLower();
            if (Regex.IsMatch(hwaccelCode, @"[ /\:|]"))
            {
                ToolTip1.SetToolTip(MenuS_hwaccelCodeTextBox, "not a valid Codec");
                MenuS_hwaccelCodeTextBox.ForeColor = Color.Red;
                settingInvalid = true;
            }
            else
            {
                ToolTip1.SetToolTip(MenuS_hwaccelCodeTextBox, null);
                MenuS_hwaccelCodeTextBox.ForeColor = Color.WhiteSmoke;
            }

        }


        public void wait(int milliseconds)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            // Console.WriteLine("start wait timer");
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
            };

            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }


        private void startRender()
        {

            if (App.Sim_renderOpt.requiredMutiStep)
            {
                CE_stepLable.Text = $"step {App.Sim_renderOpt.step} of {App.Sim_renderOpt.step_total}";
            }


            if (process != null) return;
            string command = CE_commandRTextBox.Text.Trim();
            App.Sim_renderOpt.renderModeCopy = command.Contains("-c:v copy") || command.Contains("-c copy");

            File.WriteAllText($"{App.prefs.js_folderP}.controller", "");
            File.WriteAllText($"{App.prefs.js_folderP}.cache01", "");
            process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = $"/C cd ./_js/ && node.exe terminal.js \"./.cache01\" " + (App.usingPATHExe ? "" : "../_bin/") + $"{command}";
            if (!App.prefs.hideFFmpegOutput)
            {
                if (CMDOutputViewForm != null)
                    CMDOutputViewForm.TopMost = true;
                else
                {
                    CMDOutputViewForm = new ExpandTextForm();
                    CMDOutputViewForm.cmdOutDisplayMode = true;
                    CMDOutputViewForm.Text = "Command Output";
                    CMDOutputViewForm.Tag = "CMDOutputViewForm";
                    CMDOutputViewForm.MainRTextBox.Text = "";
                    CMDOutputViewForm.FormClosed += ExpandTextForm_FormClosed;
                    CMDOutputViewForm.Show();
                }
            }
            process.Exited += CMDProcess_OnExit;

            process.StartInfo = startInfo;
            //CE_progressBar.Maximum = App.estimateOutputSize(App.Sim_inputFiles, new List<App.OutputFile>() { App.Sim_outputFile });
            if (App.Sim_renderOpt.renderModeRepeat)
            {
                App.InputFile currentStepFile = App.Sim_inputFiles.getFileByID(App.Sim_renderOpt.fileToRepeat[0]);
                CE_progressBar.Maximum = (int)App.estimateOutputDuration(
                    new List<App.InputFile>() { currentStepFile },
                    new List<App.OutputFile>() { App.Sim_outputFile }
                );
               
            }
            else
            {
                CE_progressBar.Maximum = (int)App.estimateOutputDuration(
                    App.Sim_inputFiles, 
                    new List<App.OutputFile>() { App.Sim_outputFile }
                );
                App.Sim_renderOpt.renderStartMS = 0;
            }
            CE_progressBar.Style = ProgressBarStyle.Marquee;
            App.fileSystemWatcherTriggerCount = 0;

            process.Start();
            App.cmdRunning = true;
            App.stdError = null;
            if (App.Sim_renderOpt.renderStartMS == 0)
                App.Sim_renderOpt.renderStartMS = (uint)(DateTime.Now.Ticks / 10_000);
        }

        private void refreshCEcommandMsg()
        {
            App.Sim_prepareToRunCommand();

            List<App.InputFile> IPFs = App.Sim_inputFiles;
            if (App.Sim_renderOpt.renderModeRepeat)
            {
                IPFs = new List<App.InputFile>(){
                    App.Sim_inputFiles.getFileByID(App.Sim_renderOpt.fileToRepeat[0])
                };
            }

            CE_commandRTextBox.Text = App.generateCommand(
                IPFs,
                new List<App.OutputFile>() { App.Sim_outputFile }
            );
            CE_whatItDoesRTextBox.Text = App.generateWhatItDoesMsg(
                IPFs,
                new List<App.OutputFile>() { App.Sim_outputFile }
            );
        }

        
















        ////////// Event handler Functions /////////////
        /// - Sim_addInputFileButton_Click
        /// - Sim_removeInputFileButton_Click
        /// - Sim_inputFilelistBox_MouseDown
        /// - Sim_trimInputFileMenuStripSubItem_addNmod_Click
        /// - Sim_trimInputFileMenuStripSubItem_rm_Click
        /// - Sim_offsetFileMenuStripSubItem_addNmod_Click
        /// - Sim_offsetFileMenuStripSubItem_rm_Click
        /// - Sim_moveupInputFileMenuStripItem_Click
        /// - Sim_movedownInputFileMenuStripItem_Click
        /// - Sim_removeInputFileMenuStripItem_Click
        /// - Sim_previewInputFileMenuStripItem_Click
        /// - Sim_viewInputFileInfoMenuStripItem_Click
        /// - Sim_processTreeView_NodeMouseDoubleClick
        /// - Sim_processTreeView_NodeMouseClick
        /// - Sim_ClearProcessOptButton_Click
        /// - Sim_forceFormatButton_Click
        /// - Sim_OpenSaveFileButton_Click
        /// - Sim_OutputFileTextBox_TextChanged
        /// - Sim_clearOutputButton_Click
        /// - Sim_continueButton_Click
        /// - Sim_resetButton_Click
        /// - CE_panelCloseButton_Click
        /// - CE_panel_OnOpen
        /// - CE_panel_OnClose
        /// - CE_genCmdExpandButton_Click
        /// - CE_whatItDoesExpandButton_Click
        /// - CE_genCmdCopyButton_Click
        /// - CE_runCommandButton_Click
        /// - CE_stopCommandButton_Click
        /// - render_OnFinished
        /// - Menu_openButton_Click
        /// - MenuPanel_OnOpen
        /// - MenuPanel_OnClose
        /// - Menu_closeButton_Click
        /// - Menu_aboutButton_Click
        /// - Menu_SettingButton_Click
        /// - Menu_docButton_Click
        /// - Menubuttons_OnOpen
        /// - Menubuttons_OnClose
        /// - SubMenuPanel_OnOpen
        /// - SubMenuPanel_OnClose
        /// - MenuS_toDefButton_Click
        /// - MenuS_TextBox_TextChanged
        /// - menuD_ffmpegDocLLabel_LinkClicked
        /// - menuD_easyCommandLLabel_LinkClicked
        /// - menuD_hwaccelWikiLLabel_LinkClicked
        /// - menuD_AMDhwaccelGuideLLabel_LinkClicked
        /// - CMDProcess_OnExit


        /// INPUTS
        private void Sim_addInputFileButton_Click(object sender, EventArgs e)
        {
            clearStatusBar("sim");
            OpenInputFileDialog.Title = "Choose Input file";
            OpenInputFileDialog.Multiselect = true;
            OpenInputFileDialog.CheckPathExists = true;
            OpenInputFileDialog.InitialDirectory = App.prefs.defOpenInputP;
            OpenInputFileDialog.DefaultExt = App.lastChooseFileExt;
            OpenInputFileDialog.FileName = "";
            OpenInputFileDialog.Filter = App.inputFileFilter;
            OpenInputFileDialog.ShowDialog();
            
            // note: `FileName` actually contains Path all together
            string[] filePaths = OpenInputFileDialog.FileNames;

            AddFiles();

            async void AddFiles()
            {
                foreach (string fPath in filePaths)
                {
                    if (fPath == "") return;
                    string fName = fPath.Substring(fPath.LastIndexOf("\\") + 1);
                    App.lastChooseFileExt = string.Join("", fName.Skip(fName.LastIndexOf('.') + 1));

                    Sim_inputFilelistBox.Items.Add(fName + "   "); //add spacing for tag to be added later


                    if (!fName.EndsWith(".txt"))
                    {
                        App.addFileRemote = new Tools.Remote();
                        App.FileInfo.request(fPath);
                    }
                    App.InputFile inputFileToAdd = new App.InputFile();
                    FileInfo fi = new FileInfo(fPath);
                    if (!fName.EndsWith(".txt"))
                    {
                        inputFileToAdd.info = new App.FileInfo();
                        inputFileToAdd.info.sizekB = (int)(fi.Length / 1000);
                    }
                    inputFileToAdd.ID = Tools.generateID(4, App.IDlist);
                    inputFileToAdd.name = fName;
                    inputFileToAdd.path = fPath;
                    App.Sim_inputFiles.Add(inputFileToAdd);

                    Console.WriteLine("wait begins");
                    await App.addFileRemote?.WaitForTrigger();
                    Console.WriteLine("wait done");
                }
            }
            
        }



        private void Sim_removeInputFileButton_Click(object sender, EventArgs e)
        {
            removeSelectedInputFile();
            clearStatusBar("sim");
        }


        
        /// menuStrip //
        private void Sim_inputFilelistBox_MouseDown(object sender, MouseEventArgs e)
        {
            clearStatusBar("sim");


            // if Right-click
            if (e.Button != MouseButtons.Right) return;
            int selIndex = Sim_inputFilelistBox.SelectedIndex;

            if(Sim_inputFilelistBox.SelectedIndex == -1)
            {
                Sim_statusStripLabel.ForeColor = Color.Red;
                Sim_statusStripLabel.Text = "Please select Inputfile first";
                return;
            }

            if (App.Sim_inputFiles[selIndex].trimming == null)
            {
                Sim_trimInputFileMenuStripSubItem_addNmod.Text = "Add Trimming";
                Sim_trimInputFileMenuStripSubItem_rm.Enabled = false;
            }
            else
            {
                Sim_trimInputFileMenuStripSubItem_addNmod.Text = "Modify Trimming";
                Sim_trimInputFileMenuStripSubItem_rm.Enabled = true;
            }

            if (App.Sim_inputFiles[selIndex].offset == 0)
            {
                Sim_offsetFileMenuStripSubItem_addNmod.Text = "Add Offset";
                Sim_offsetFileMenuStripSubItem_rm.Enabled = false;
            }
            else
            {
                Sim_offsetFileMenuStripSubItem_addNmod.Text = "Modify Offset";
                Sim_offsetFileMenuStripSubItem_rm.Enabled = true;
            }

            Sim_moveupInputFileMenuStripItem.Enabled = (selIndex != 0); //if selIndex != 0 enable `moveup`
            Sim_movedownInputFileMenuStripItem.Enabled = (App.Sim_inputFiles.Last().ID != App.Sim_inputFiles[selIndex].ID); //if selIndex != -1 enable `movedown`


            Sim_inputFileMenuStrip.Show(MousePosition.X, MousePosition.Y);
        }



        private void Sim_trimInputFileMenuStripSubItem_addNmod_Click(object sender, EventArgs e)
        {
            if(TSSform != null)
            {
                TSSform.TopMost = true;
                return;
            }
            TSSform = new TimeSessionSelectForm();
            TSSform.FormClosed += TSSform_FormClosed;
            
            int selIndex = Sim_inputFilelistBox.SelectedIndex;
            TSSform.Tag = selIndex.ToString();
            TSSform.preset = App.Sim_inputFiles[selIndex].trimming;
            TSSform.fileInfo = App.Sim_inputFiles[selIndex].info;

            TSSform.Show();
        }



        private void Sim_trimInputFileMenuStripSubItem_rm_Click(object sender, EventArgs e)
        {
            int selIndex = Sim_inputFilelistBox.SelectedIndex;
            ListBox.ObjectCollection listBoxItems = Sim_inputFilelistBox.Items;
            if (App.Sim_inputFiles[selIndex].trimming == null) return;

            App.Sim_inputFiles[selIndex].trimming = null;
            if (listBoxItems[selIndex].ToString().Contains("[T]"))
                listBoxItems[selIndex] = listBoxItems[selIndex].ToString().Replace("[T]", "");
        }



        private void Sim_offsetFileMenuStripSubItem_addNmod_Click(object sender, EventArgs e)
        {
            if(OFSform != null)
            {
                OFSform.TopMost = true;
                return;
            }       
            OFSform = new OffsetSelectForm();
            OFSform.FormClosed += OFSform_FormClosed;

            int selIndex = Sim_inputFilelistBox.SelectedIndex;
            OFSform.Tag = selIndex.ToString();
            OFSform.presetValue = App.Sim_inputFiles[selIndex].offset;

            OFSform.Show();
        }



        private void Sim_offsetFileMenuStripSubItem_rm_Click(object sender, EventArgs e)
        {
            int selIndex = Sim_inputFilelistBox.SelectedIndex;
            ListBox.ObjectCollection listBoxItems = Sim_inputFilelistBox.Items;
            if (App.Sim_inputFiles[selIndex].offset == 0) return;

            App.Sim_inputFiles[selIndex].offset = 0;
            if (listBoxItems[selIndex].ToString().Contains("[Off]"))
                listBoxItems[selIndex] = listBoxItems[selIndex].ToString().Replace("[Off]", "");
        }



        private void Sim_moveupInputFileMenuStripItem_Click(object sender, EventArgs e)
        {
            int selIndex = Sim_inputFilelistBox.SelectedIndex;
            if (selIndex == 0) return;
            ListBox.ObjectCollection listBoxItems = Sim_inputFilelistBox.Items;


            List<App.InputFile> swapedItems = new List<App.InputFile>() { App.Sim_inputFiles[selIndex], App.Sim_inputFiles[selIndex - 1] };
            App.Sim_inputFiles.RemoveRange(selIndex - 1, 2);
            App.Sim_inputFiles.InsertRange(selIndex - 1, swapedItems);


            List<Object> swapedLBItems = new List<Object>(){ listBoxItems[selIndex], listBoxItems[selIndex - 1] };
            listBoxItems.RemoveAt(selIndex - 1);
            listBoxItems.Insert(selIndex - 1, swapedLBItems[0]);

            listBoxItems.RemoveAt(selIndex);
            listBoxItems.Insert(selIndex, swapedLBItems[1]);
        }



        private void Sim_movedownInputFileMenuStripItem_Click(object sender, EventArgs e)
        {
            int selIndex = Sim_inputFilelistBox.SelectedIndex;
            ListBox.ObjectCollection listBoxItems = Sim_inputFilelistBox.Items;
            if (App.Sim_inputFiles.Last().ID == App.Sim_inputFiles[selIndex].ID) return;


            List<App.InputFile> swapedItems = new List<App.InputFile>() { App.Sim_inputFiles[selIndex + 1], App.Sim_inputFiles[selIndex] };
            App.Sim_inputFiles.RemoveRange(selIndex, 2);
            App.Sim_inputFiles.InsertRange(selIndex, swapedItems);


            List<Object> swapedLBItems = new List<Object>() { listBoxItems[selIndex + 1], listBoxItems[selIndex] };
            listBoxItems.RemoveAt(selIndex);
            listBoxItems.Insert(selIndex, swapedLBItems[0]);

            listBoxItems.RemoveAt(selIndex + 1);
            listBoxItems.Insert(selIndex + 1, swapedLBItems[1]);
        }



        private void Sim_removeInputFileMenuStripItem_Click(object sender, EventArgs e) => removeSelectedInputFile();



        private void Sim_previewInputFileMenuStripItem_Click(object sender, EventArgs e)
        {
            if(App.MissingNodeJS||App.MissingMpv)
            {
                MessageBox.Show(
                    "due to absent of Dependecies\nthis feature is temporary unavailable",
                    "Cannot fulfill request",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }
            int selIndex = Sim_inputFilelistBox.SelectedIndex;
            string selFilePath = App.Sim_inputFiles[selIndex].path;

            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            if(App.prefs.hideCMD) startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "CMD.exe";

            if (selFilePath.EndsWith(".txt"))
            {   // `/C` before arguments is important, w/o it won't work!!
                startInfo.Arguments = $"/C notepad \"{selFilePath}\"";
            }
            else startInfo.Arguments = $"/C cd /d \"{App.prefs.bin_folderP}\" && mpv.exe \"{selFilePath}\"";

            process.StartInfo = startInfo;
            process.Start();
       

            //if(selFilePath.EndsWith(".txt")) return;

            //only for ffplay (unuse)
            /*MessageBox.Show(
                $"File is being Preview\n\nHere are shortcuts for it:\n" +
                "   q - quit" +
                "   SPACEBAR - play/pause" +
                "   left/right - Seek backward/forward 10 seconds" +
                "   up/down - Seek backward/forward 1 minute" +
                "   9, 0 - Decrease/increase volume respectively" +
                "   f - Toggle full screen" +
                "   m - Toggle mute" +
                ((App.prefs.hideCMD)?"":"\n\nNote: to hide Terminal, you can do that in Settings")
            );*/
        }

        private void Sim_viewInputFileInfoMenuStripItem_Click(object sender, EventArgs e)
        {
            if (App.MissingNodeJS || App.MissingFFprobe)
            {
                MessageBox.Show(
                    "due to absent of Dependecies\nthis feature is temporary unavailable",
                    "Cannot fulfill request",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }
            int selIndex = Sim_inputFilelistBox.SelectedIndex;
            string selFilePath = App.Sim_inputFiles[selIndex].path;

            if (App.Sim_inputFiles[selIndex].info == null)
            {
                App.FileInfo.request(selFilePath);
                App.FileInfo._request.showFileInfoWhenReady = true;
                return;
            }
            else
            {
                var info = App.Sim_inputFiles[selIndex].info;
                MessageBox.Show(info.ToString(), "File Info");
            }


        }





        // TreeView
        private void Sim_processTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            clearStatusBar("sim");
            
            // set the prorerties for the Form
            switch (e.Node.Name)
            {
                case "V_qualNode":
                    if(UPFTypeN1 != null)
                    {
                        UPFTypeN1.TopMost = true;
                        return;
                    }
                    UPFTypeN1 = new Uni_PromptFormTypeN1(); // init Form
                    UPFTypeN1.FormClosed += UPFTypeN1_FormClosed;
                    UPFTypeN1.Tag = e.Node.Name;
                    if(App.Sim_processOpt_temp.quality == null)
                        App.Sim_processOpt_temp.quality = new App.P_OptionQuality();
                    UPFTypeN1.preset = App.Sim_processOpt_temp.quality.vQuality;
                    UPFTypeN1.noneValue = 0;

                    UPFTypeN1.Text = "Set Video Quality";
                    UPFTypeN1.label1.Text = "set to 0 will keep Video Quality to Lossless";
                    UPFTypeN1.label2.Text = "Kbps";
                    UPFTypeN1.numericUpDown.DecimalPlaces = 0;
                    UPFTypeN1.numericUpDown.Increment = 512;
                    UPFTypeN1.numericUpDown.Maximum = 100000;
                    UPFTypeN1.numericUpDown.Minimum = 0;
                    UPFTypeN1.Show();
                    break;


                case "A_qualNode":
                    if (UPFTypeN1 != null)
                    {
                        UPFTypeN1.TopMost = true;
                        return;
                    }
                    UPFTypeN1 = new Uni_PromptFormTypeN1(); // init Form
                    UPFTypeN1.FormClosed += UPFTypeN1_FormClosed;
                    UPFTypeN1.Tag = e.Node.Name;
                    if(App.Sim_processOpt_temp.quality == null) App.Sim_processOpt_temp.quality = new App.P_OptionQuality();
                    UPFTypeN1.preset = App.Sim_processOpt_temp.quality.aQuality;
                    UPFTypeN1.noneValue = 0;

                    UPFTypeN1.Text = "Set Audio Quality";
                    UPFTypeN1.label1.Text = "leave blank will set Quality to Lossless";
                    UPFTypeN1.label2.Text = "Kbps";
                    UPFTypeN1.numericUpDown.DecimalPlaces = 0;
                    UPFTypeN1.numericUpDown.Increment = 64;
                    UPFTypeN1.numericUpDown.Maximum = 10000;
                    UPFTypeN1.numericUpDown.Minimum = 0;
                    UPFTypeN1.Show();
                    break;


                case "V_scalingNode":
                    if (v_scaleForm != null)
                    {
                        v_scaleForm.TopMost = true;
                        return;
                    }
                    v_scaleForm = new V_scaleSelectForm(); // init Form
                    v_scaleForm.FormClosed += v_scaleForm_FormClosed;
                    v_scaleForm.preset = App.Sim_processOpt_temp.v_scale;
                    v_scaleForm.Show();
                    break;


                case "V_cropNode":
                    if (App.MissingNodeJS||App.MissingFFprobe)
                    {
                        MessageBox.Show(
                            "due to absent of Dependecies\nthis feature is temporary unavailable",
                            "Cannot fulfill request",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                        return;
                    }

                    if (v_cropForm != null)
                    {
                        v_cropForm.TopMost = true;
                        return;
                    }

                    App.InputFile bestVdoFile = App.Sim_inputFiles.getBestFile("video");
                    if (bestVdoFile == null)
                    {
                        MessageBox.Show(
                           "Please select at least one video file before continue\n\nthis option requires at least one video stream to work\nvideo stream can be found in any video file format\nEx: mp4, m4a, mov",
                           "No input file with video stream detected",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information
                        );
                        return;
                    }
                    if(bestVdoFile.info == null)
                    {
                        MessageBox.Show(
                           "Input file Infomation not found\n\nfor some reason file infomation failed to process\ntry revert Settings to default may help.",
                           "Missing file Infomation",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information
                        );
                        return;
                    }

                    v_cropForm = new V_cropSelectForm();
                    v_cropForm.FormClosed += v_cropForm_FormClosed;
                    v_cropForm.file = bestVdoFile;
                    v_cropForm.processOpt = App.Sim_processOpt_temp;
                    v_cropForm.preset = App.Sim_processOpt_temp.v_crop;
                    v_cropForm.Show();
                    break;


                case "StrmMapNode":
                    if (App.MissingNodeJS||App.MissingFFprobe)
                    {
                        MessageBox.Show(
                            "due to absent of Dependecies\nthis feature is temporary unavailable",
                            "Cannot fulfill request",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                        return;
                    }

                    if (strmMapForm != null)
                    {
                        strmMapForm.TopMost = true;
                        return;
                    }

                    if (App.Sim_inputFiles.Count == 0)
                    {
                        MessageBox.Show(
                          "Please add at least one Input file before continue\n\nthis option requires at least one Input file\nbut ideal for two or more",
                          "No Input file were added",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information
                        );
                        return;
                    }
                    bool missInfo = true;
                    foreach (App.InputFile file in App.Sim_inputFiles)
                        if (file.info != null) missInfo = false;

                    if (missInfo)
                    {
                        MessageBox.Show(
                           "Input file Infomation not found\n\nfor some reason file infomation failed to process\ntry revert Settings to default may help.",
                           "Missing file Infomation",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information
                        );
                        return;
                    }

                    strmMapForm = new SimStrmMappingForm();
                    strmMapForm.FormClosed += strmMapForm_FormClosed;
                    strmMapForm.preset = App.Sim_processOpt_temp.strmMapping;
                    strmMapForm.Show();
                    break;

                case "MetadataNode":
                    if(MetadataForm != null)
                    {
                        MetadataForm.TopMost = true;
                        return;
                    }
                    MetadataForm = new SetMetadataForm();
                    MetadataForm.FormClosed += MetadataForm_FormClosed;
                    MetadataForm.preset = App.Sim_processOpt_temp.metadata;
                    MetadataForm.Show();
                    break;

            }
        }

        private void Sim_processTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {          
            if(e.Node.Tag == null)
            {
                clearStatusBar("sim");
                return;
            }
            // display help message on the Sim_statusStripLabel
            Sim_statusStripLabel.ForeColor = Color.Black;
            Sim_statusStripLabel.Text = e.Node.Tag.ToString(); // tag works as decriptions
        }


        private void Sim_ClearProcessOptButton_Click(object sender, EventArgs e)
        {
            TreeNode selNode = Sim_processTreeView.SelectedNode;
            switch (selNode.Name)
            {
                case "QualityNode":
                    App.Sim_processOpt_temp.quality = null;
                    break;
                case "V_qualNode":
                    if (App.Sim_processOpt_temp.quality?.aQuality == -1) 
                        App.Sim_processOpt_temp.quality = null;
                    else App.Sim_processOpt_temp.quality.vQuality = -1;
                    break;
                case "A_qualNode":
                    if (App.Sim_processOpt_temp.quality?.vQuality == -1)
                        App.Sim_processOpt_temp.quality = null;
                    else App.Sim_processOpt_temp.quality.aQuality = -1;
                    break;
                case "V_scalingNode":
                    App.Sim_processOpt_temp.v_scale = null;
                    break;
                case "V_cropNode":
                    App.Sim_processOpt_temp.v_crop = null;
                    break;
                case "StrmMapNode":
                    App.Sim_processOpt_temp.strmMapping = null;
                    break;
                case "MetadataNode":
                    App.Sim_processOpt_temp.metadata = null;
                    break;
            }
            updateOptTreeViewColor(selNode.Name, null);
            clearStatusBar("sim");
        }


        private void Sim_forceFormatButton_Click(object sender, EventArgs e)
        {
            if (UPFTypeC1 != null)
            {
                UPFTypeC1.TopMost = true;
                return;
            }
            UPFTypeC1 = new Uni_PromptFormTypeC1();
            UPFTypeC1.FormClosed += UPFTypeC1_FormClosed;
            UPFTypeC1.Tag = "forceFormatButton";
            UPFTypeC1.preset = App.Sim_processOpt_temp.forceOutputFormat;

            UPFTypeC1.Text = "Select Format";
            UPFTypeC1.label1.Text = "enter any format needed or choose from the list";
            UPFTypeC1.label2.Text = "";
            UPFTypeC1.comboBox.Items.AddRange(new object[] {
                "mp4",
                "mov",
                "mp3",
                "aac",
                "wav",
                "ogg",
                "m4v",
                "h216",
                "h263",
                "h264",
                "avi",
                "ts"
            });
            UPFTypeC1.Show();
            clearStatusBar("sim");
        }


        private void Sim_OpenSaveFileButton_Click(object sender, EventArgs e)
        {
            SaveOutputFileDialog.Title = "Choose Save location";
            SaveOutputFileDialog.CheckPathExists = true;
            if(App.Sim_outputFile != null)
            {
                SaveOutputFileDialog.InitialDirectory = App.Sim_outputFile.directory;
                SaveOutputFileDialog.FileName = App.Sim_outputFile.name;
            }

            SaveOutputFileDialog.Filter = App.outputFileFilter;
            SaveOutputFileDialog.ShowDialog();
            // note: `FileName` actually contains Path all together
            string fPath = SaveOutputFileDialog.FileName;
            if (fPath == "") return;
            //string fName = fPath.Substring(fPath.LastIndexOf("\\") + 1);

            Sim_OutputFileTextBox.Text = fPath; // <- this will trigger the function below hence, commented code is unnecessary

            /*App.OutputFile outFiletoAdd = new App.OutputFile();
            outFiletoAdd.ID = Tools.generateID(4, App.IDlist);
            outFiletoAdd.name = fName;
            outFiletoAdd.path = fPath;
            outFiletoAdd.directory = fPath.Substring(
                    0,
                    fPath.LastIndexOf("\\") + 1
            );
            App.Sim_outputFile.Add(outFiletoAdd); */
            clearStatusBar("sim");
        }

        private void Sim_OutputFileTextBox_TextChanged(object sender, EventArgs e)
        {
            string fPath = Sim_OutputFileTextBox.Text.Trim().Replace('/', '\\');
            if (fPath == "") return;
            if (!fPath.ContainsAny(new List<string>() { "\\", ":" })&& App.Sim_inputFiles.Count != 0)
                fPath = ".\\" + fPath;
            string fName = fPath.Substring(fPath.LastIndexOf("\\") + 1);

            if (fPath.StartsWith(".\\"))
            {
                string rootDir = App.Sim_inputFiles[0].path.Substring(
                    0,
                    App.Sim_inputFiles[0].path.LastIndexOf("\\") + 1
                );
                fPath = rootDir + fPath.Substring(2);
            }

            //Sim_OutputFileTextBox.Text = fPath;

            App.OutputFile outFiletoAdd = new App.OutputFile();
            outFiletoAdd.directory = fPath.Substring(
                    0,
                    fPath.LastIndexOf("\\") + 1
            );

            if (!Directory.Exists(outFiletoAdd.directory))
            {
                Sim_OutputFileTextBox.ForeColor = Color.Red;
                ToolTip1.SetToolTip(Sim_OutputFileTextBox, "file path does not exists\ndid you miss typed something?");
                return;
            }

            outFiletoAdd.ID = Tools.generateID(4, App.IDlist);
            outFiletoAdd.name = fName;
            outFiletoAdd.path = fPath;
            App.Sim_inputFiles.ForEach(file => 
                outFiletoAdd.childInputFilesID.Add(file.ID)
            );
            Sim_OutputFileTextBox.ForeColor = Color.Black;
            ToolTip1.SetToolTip(Sim_OutputFileTextBox, null); // clear ToolTip
            App.Sim_outputFile = outFiletoAdd;
            clearStatusBar("sim");

        }

        private void Sim_clearOutputButton_Click(object sender, EventArgs e)
        {
            Sim_OutputFileTextBox.Text = "";
            ToolTip1.SetToolTip(Sim_OutputFileTextBox, null); // clear ToolTip
            App.Sim_outputFile = null;
            clearStatusBar("sim");
        }


        private void Sim_continueButton_Click(object sender, EventArgs e)
        {
            if (App.MissingNodeJS||App.MissingFFmpeg)
            {
                MessageBox.Show(
                    "due to absent of Dependecies\nthis feature is temporary unavailable",
                    "Cannot fulfill request",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            if (App.Sim_inputFiles.Count == 0)
            {
                Sim_statusStripLabel.Text = "no Input file selelcted";
                Sim_statusStripLabel.ForeColor = Color.Red;
                return;
            }
            if(App.Sim_outputFile == null)
            {
                Sim_statusStripLabel.Text = "no Output file selelcted";
                Sim_statusStripLabel.ForeColor = Color.Red;
                return;
            }

            App.Sim_renderOpt.requiredMutiStep = false;
            App.Sim_outputFile.processOption = App.Sim_processOpt_temp;
            App.Sim_renderOpt.renderModeRepeat = Sim_repeatAllInputCheckBox.Checked;
            if (App.Sim_renderOpt.renderModeRepeat)
                App.Sim_renderOpt.requiredMutiStep = true;
            App.Sim_checkValidity();


            setControlDisEnable(false);
            AcExcPanel.TriggerOpen = true;
            clearStatusBar("sim");
        }


        private void Sim_resetButton_Click(object sender, EventArgs e)
        {
            App.Sim_inputFiles = null;
            App.Sim_outputFile = null;
            App.Sim_processOpt_temp = null;
            updateOptTreeViewColor();
            Sim_inputFilelistBox.Items.Clear();
            Sim_OutputFileTextBox.Text = "";
            clearStatusBar("sim");
        }





        /// CE (cExePanel) ///
        private void CE_panelCloseButton_Click(object sender, EventArgs e)
        {
            if (App.cmdRunning)
            {
                DialogResult dr = MessageBox.Show(
                    "File(s) are rendering\nclosing this pannel will Stop the process.\n\nwish to Continue?",
                    "Stop the Process?",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if(dr == DialogResult.No) return;
                CE_stopCommandButton_Click(sender, e);
                return;
            }

            setCEControlDisEnable(false);
            AcExcPanel.TriggerClose = true;
        }

        private void CE_panel_OnOpen()
        {
            setCEControlDisEnable(true);
            CE_whatItDoesRTextBox.Font = CE_commandRTextBox.Font = CE_normalTextFont;
            CE_whatItDoesRTextBox.ForeColor = CE_commandRTextBox.ForeColor = CE_normalTextColor;
            

            CE_stepLable.Text = "";
            refreshCEcommandMsg();
        }
        
        private void CE_panel_OnClose()
        {
            setCEControlDisEnable(false);
            CE_whatItDoesRTextBox.Font = CE_commandRTextBox.Font = CE_loadingTextFont;
            CE_whatItDoesRTextBox.ForeColor = CE_commandRTextBox.ForeColor = CE_loadingTextColor;
            CE_commandRTextBox.Text = CE_cmdLoadingText; 
            CE_stopCommandButton.Visible = false;
            CE_stopCommandButton.Enabled = false;
            CE_whatItDoesRTextBox.Text = CE_whatItDoesLoadingText;
            setControlDisEnable(true);
        }

        private void CE_genCmdExpandButton_Click(object sender, EventArgs e)
        {
            if (CE_cmdExpForm != null)
            {
                CE_cmdExpForm.TopMost = true;
                return;
            }
            CE_cmdExpForm = new ExpandTextForm();
            CE_cmdExpForm.Tag = "CE_cmdExpForm";
            CE_cmdExpForm.cmdOutDisplayMode = true;
           /* CE_cmdExpForm.SyncedControl = CE_commandRTextBox;
            CE_commandRTextBox.TextChanged += CE_cmdExpForm.SyncHostToClient;*/
            CE_cmdExpForm.FormClosed += ExpandTextForm_FormClosed;

            CE_cmdExpForm.MainRTextBox.Text = CE_commandRTextBox.Text;
            CE_cmdExpForm.Show();
        }

        private void CE_whatItDoesExpandButton_Click(object sender, EventArgs e)
        {
            if(CE_whatItDoesExpForm != null)
            {
                CE_whatItDoesExpForm.TopMost = true;
                return;
            }
            CE_whatItDoesExpForm = new ExpandTextForm();
            CE_whatItDoesExpForm.Tag = "CE_whatItDoesExpForm";
            CE_whatItDoesExpForm.FormClosed += ExpandTextForm_FormClosed;

            CE_whatItDoesExpForm.MainRTextBox.Text = CE_whatItDoesRTextBox.Text;
            CE_whatItDoesExpForm.Show();
        }


        private void CE_genCmdCopyButton_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "CMD.exe";


            startInfo.Arguments = $"/C echo {CE_commandRTextBox.Text} | clip";

            process.StartInfo = startInfo;
            process.Start();
        }


        private void CE_runCommandButton_Click(object sender, EventArgs e)
        {
            startRender();
            CE_stopCommandButton.Enabled = true;
            CE_stopCommandButton.Visible = true;
        }


        private void CE_stopCommandButton_Click(object sender, EventArgs e)
        {
            File.WriteAllText(App.prefs.js_controllerP, "stop"); // tell Javascript to stop its process
            App.cmdKill = true;
            render_OnFinished();
        }


        private void render_OnFinished()
        {
            if (process == null) return;
            App.fileSystemWatcherTriggerCount = 0;
            App.Sim_renderOpt.renderModeCopy = false;
            CE_progressBar.Value = CE_progressBar.Maximum;
            CE_progressBar.Style = ProgressBarStyle.Continuous;
            //process.WaitForExit();
            process.Close();
            process?.Dispose();
            process = null;
            App.cmdRunning = false;


            if (!App.cmdKill && (App.stdError == null) && App.Sim_renderOpt.requiredMutiStep)
            {
                if (App.Sim_renderOpt.renderModeRepeat)
                {
                    App.Sim_renderOpt.fileToRepeat.RemoveAt(0);
                    //Console.WriteLine("rm 0");
                    if (App.Sim_renderOpt.fileToRepeat.Count == 0)
                    {
                        App.Sim_renderOpt.Reset();
                        finishingOff();
                        return;
                    }
                    CE_progressBar.Value = CE_progressBar.Minimum;
                    refreshCEcommandMsg();
                    startRender();
                    return;
                }
            }

            finishingOff();




            void finishingOff()
            {
                Console.WriteLine("finishing");

                if (App.stdError != null)
                {
                    if (CMDOutputViewForm != null)
                    {
                        CMDOutputViewForm.Close();
                        CMDOutputViewForm?.Dispose();
                        CMDOutputViewForm = null;
                    }
                    ExpandTextForm etf = new ExpandTextForm();
                    etf.Text = "FFmpeg throws an Error";
                    etf.MainRTextBox.Text = App.stdError;
                    etf.ShowDialog();
                }
                else if (App.cmdKill)
                {
                    if (App.appClosing) return;
                    MessageBox.Show(
                        "render Job Stoped",
                        "Render Terminated"
                    );
                }
                else
                {
                    Console.WriteLine(App.Sim_renderOpt.renderStartMS);
                    Console.WriteLine((uint)((DateTime.Now.Ticks / 10_000) - App.Sim_renderOpt.renderStartMS));
                    MessageBox.Show(
                        $"render Job finished!\nelapse: {Tools.ToTimeString((uint)((DateTime.Now.Ticks / 10_000) - App.Sim_renderOpt.renderStartMS), "modern")}",
                        "Render Completed"
                    );
                }


                App.cmdKill = false;
                App.stdError = null;
                CE_progressBar.Value = CE_progressBar.Minimum;
                CE_stopCommandButton.Enabled = false;
                CE_stopCommandButton.Visible = false;
                App.Sim_renderOpt.renderStartMS = 0;
                //CE_panelCloseButton_Click(new object(), new EventArgs()); //close panel
            }
        }



        private void Menu_openButton_Click(object sender, EventArgs e)
        {
            setControlDisEnable(false);
            //Trigger.menuPanelOpen = true;
            AMenuPanel.TriggerOpen = true;
        }


        private void MenuPanel_OnOpen()
        {
            setMenuControlDisEnable(true);
            if (AMenuAboutButton.startPoint == Point.Empty) 
                AMenuAboutButton.startPoint = Menu_aboutButton.Location;

            if (AMenuSettingButton.startPoint == Point.Empty) 
                AMenuSettingButton.startPoint = Menu_SettingButton.Location;

            if (AMenuDocButton.startPoint == Point.Empty) 
                AMenuDocButton.startPoint = Menu_docButton.Location;

            if (ASubMenuAboutPanel.startPoint == Point.Empty)
                ASubMenuAboutPanel.startPoint = Menu_aboutPanel.Location;

            if (ASubMenuSettingPanel.startPoint == Point.Empty)
                ASubMenuSettingPanel.startPoint = Menu_settingPanel.Location;

            if (ASubMenuDocPanel.startPoint == Point.Empty)
                ASubMenuDocPanel.startPoint = Menu_docPanel.Location;
        }


        private void MenuPanel_OnClose()
        {
            setControlDisEnable(true);
        }


        private void Menu_closeButton_Click(object sender, EventArgs e)
        {
            if (!menu_closeButtonGobackMode)
            {
                setMenuControlDisEnable(false);
                AMenuPanel.TriggerClose = true;
                return;
            }

            Menu_closeButton.Enabled = false;
            switch (menu_openedButtonPage)
            {
                case 0:
                    Menu_aboutPanel.Enabled = false;
                    ASubMenuAboutPanel.TriggerClose = true;
                    break;
                case 1:
                    Menu_settingPanel.Enabled = false;
                    ASubMenuSettingPanel.TriggerClose = true;
                    break;
                case 2:
                    Menu_docPanel.Enabled = false;
                    ASubMenuDocPanel.TriggerClose = true;
                    break;
            }

        }


        private void Menu_aboutButton_Click(object sender, EventArgs e)
        {
            Trigger tg = new Trigger();
            tg.control = Menu_aboutButton;
            tg.AControl = AMenuAboutButton;
            tg.type = "menu_buttonclick";
            triggers.Add(tg);
        }

        private void Menu_SettingButton_Click(object sender, EventArgs e)
        {
            Trigger tg = new Trigger();
            tg.control = Menu_SettingButton;
            tg.AControl = AMenuSettingButton;
            tg.type = "menu_buttonclick";
            triggers.Add(tg);
        }

        private void Menu_docButton_Click(object sender, EventArgs e)
        {
            Trigger tg = new Trigger();
            tg.control = Menu_docButton;
            tg.AControl = AMenuDocButton;
            tg.type = "menu_buttonclick";
            triggers.Add(tg);
        }

        private void Menubuttons_OnOpen()
        {
            Menu_closeButton.Enabled = true;
            ToolTip1.SetToolTip(Menu_closeButton, menu_closeButtonGobackTTtext);
            menu_closeButtonGobackMode = true;
            switch (menu_openedButtonPage)
            {
                case 0:
                    ASubMenuAboutPanel.TriggerOpen = true;
                    Menu_aboutPanel.Visible = true;
                    break;
                case 1:
                    ASubMenuSettingPanel.TriggerOpen = true;
                    Menu_settingPanel.Visible = true;
                    break;
                case 2:
                    ASubMenuDocPanel.TriggerOpen = true;
                    Menu_docPanel.Visible = true;
                    break;
            }
        }


        private void Menubuttons_OnClose()
        {
            Menu_closeButton.Enabled = true;
            ToolTip1.SetToolTip(Menu_closeButton, menu_closeButtonDefTTtext);
            menu_closeButtonGobackMode = false;
            setMenuControlDisEnable(true);

            Menu_aboutButton.Location = AMenuAboutButton.startPoint;
            Menu_SettingButton.Location = AMenuSettingButton.startPoint;
            Menu_docButton.Location = AMenuDocButton.startPoint;
        }


        private void SubMenuPanel_OnOpen()
        {
            switch (menu_openedButtonPage)
            {
                case 0:
                    Menu_aboutPanel.Enabled = true;
                    break;
                case 1:
                    loadSettingsToPanel();
                    Menu_settingPanel.Enabled = true;
                    break;
                case 2:
                    Menu_docPanel.Enabled = true;
                    break;
            }
        }



        private void SubMenuPanel_OnClose()
        {
            Trigger tg = new Trigger();
            switch (menu_openedButtonPage)
            {
                case 0:
                    tg.control = Menu_aboutButton;
                    tg.AControl = AMenuAboutButton;
                    break;
                case 1:
                    tg.control = Menu_SettingButton;
                    tg.AControl = AMenuSettingButton;
                    break;
                case 2:
                    tg.control = Menu_docButton;
                    tg.AControl = AMenuDocButton;
                    break;
            }

            tg.type = "menu_gobackbuttonclick";
            triggers.Add(tg);

            if (!settingInvalid&&menu_openedButtonPage == 1)
                saveSettingsToPref();
        }



        private void MenuS_toDefButton_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show(
                "Do you mean to Reset All settings to Default?",
                "Reset to Default",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (res == DialogResult.No) return;
            App.prefs = App.defaultConfig;
            loadSettingsToPanel();
        }


        private void MenuS_TextBox_TextChanged(object sender, EventArgs e)
        {
            checkSettingValid();
        }



        private void menuD_ffmpegDocLLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(App.FFmpegDocs[0]);
            menuD_ffmpegDocLLabel.LinkVisited = true;
        }

        private void menuD_easyCommandLLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(App.FFmpegDocs[1]);
            menuD_easyCommandLLabel.LinkVisited = true;
        }

        private void menuD_hwaccelWikiLLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(App.FFmpegDocs[2]);
            menuD_hwaccelWikiLLabel.LinkVisited = true;
        }

        private void menuD_AMDhwaccelGuideLLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(App.FFmpegDocs[3]);
            menuD_AMDhwaccelGuideLLabel.LinkVisited = true;
        }

        private void CMDProcess_OnExit(object sender, EventArgs e)
        {
            if(process != null)
                render_OnFinished();
        }























        ///////////   On CLOSED Events    ///////////
        ////  TSSform (TimeSessionSelectForm)  /////
        /// EventHandelers
        private void TSSform_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (TSSform.selection == null)
            {
                TSSform = null;
                return;
            }
            // get infomation from the Form replace it with old data
            int selIndex = Convert.ToInt32(TSSform.Tag.ToString()); // tag contains file index this Form is working with
            ListBox.ObjectCollection listBoxItems = Sim_inputFilelistBox.Items;
            if (TSSform.selection.selectedAll)
            {
                if (listBoxItems[selIndex].ToString().Contains("[T]"))
                    listBoxItems[selIndex] = listBoxItems[selIndex].ToString().Replace("[T]" ,"");
                App.Sim_inputFiles[selIndex].trimming = null;
                return; //in case no triming needed; return
            }

            if (!listBoxItems[selIndex].ToString().Contains("[T]"))
                listBoxItems[selIndex] = listBoxItems[selIndex].ToString() + "[T]";
            App.Sim_inputFiles[selIndex].trimming = TSSform.selection;
            App.Sim_inputFiles[selIndex].UpdateFinalLength();
            TSSform?.Dispose();
            TSSform = null;
        }




        ////  OFSform (OffsetSelectForm)  /////
        /// EventHandelers
        private void OFSform_FormClosed(object sender, FormClosedEventArgs e)
        {
            int selIndex = Convert.ToInt32(OFSform.Tag.ToString()); // tag contains file index this Form is working with
            ListBox.ObjectCollection listBoxItems = Sim_inputFilelistBox.Items;

            if (OFSform.offset == 0)
            {
                if (listBoxItems[selIndex].ToString().Contains("[Off]"))
                    listBoxItems[selIndex] = listBoxItems[selIndex].ToString().Replace("[Off]", "");
            }
            else
            {
                if (!listBoxItems[selIndex].ToString().Contains("[Off]"))
                    listBoxItems[selIndex] = listBoxItems[selIndex].ToString() + "[Off]";
            }

            App.Sim_inputFiles[selIndex].offset = OFSform.offset;
            OFSform?.Dispose();
            OFSform = null;
        }





        ////  UPFTypeN1 (Uni_PromptFormTypeN1)  /////
        /// EventHandelers
        private void UPFTypeN1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!UPFTypeN1.isConfirmed)
            {
                UPFTypeN1?.Dispose();
                UPFTypeN1 = null;
                return;
            }
            if (UPFTypeN1.Tag == null) throw new Exception("Internal Error: `UPFTypeN1.promptTag` not set");

            if(App.Sim_processOpt_temp == null) App.Sim_processOpt_temp = new App.ProcessOptions();
            switch (UPFTypeN1.Tag.ToString()) // set value from the Form to Sim_processOptions
            {
                case "V_qualNode":
                    App.Sim_processOpt_temp.quality.vQuality = Convert.ToInt32(UPFTypeN1.selection);
                    break;

                case "A_qualNode":
                    App.Sim_processOpt_temp.quality.aQuality = Convert.ToInt32(UPFTypeN1.selection);
                    break;
            }

            // set TreeView color
            bool exitLoop = false;
            foreach (TreeNode node in Sim_processTreeView.Nodes) // loop through parent Nodes
            {
                foreach (TreeNode subNode1 in node.Nodes) // loop through subNodes(childNodes) layer 1
                {
                    // filter only subNode that User just interacted with
                    if (subNode1.Name != UPFTypeN1.Tag.ToString()) continue;
                    if (UPFTypeN1.selection == UPFTypeN1.noneValue) // check if user has made any change to Options associate with the node
                    {
                        subNode1.ForeColor = Color.Black; //if not set Font color to Black
                        // skip, if any subNode in this layer has some changes
                        foreach (TreeNode currenLayerN in node.Nodes) if (currenLayerN.ForeColor == Color.Aqua) return;
                        node.ForeColor = Color.Black;
                        exitLoop = true;
                        break;
                    }
                    else
                    {
                        subNode1.ForeColor = Color.Aqua; //else Aqua
                        node.ForeColor = Color.Aqua;
                        exitLoop = true;
                        break;
                    }
                }

                if(exitLoop) break;
            }

            UPFTypeN1?.Dispose();
            UPFTypeN1 = null;
        }


        ////  UPFTypeC1 (Uni_PromptFormTypeC1)  /////
        private void UPFTypeC1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!UPFTypeC1.isConfirmed)
            {
                UPFTypeC1?.Dispose();
                UPFTypeC1 = null;
                return;
            }
            if (UPFTypeC1.Tag == null) throw new Exception("Internal Error: `UPFTypeC1.promptTag` not set");

            switch (UPFTypeC1.Tag.ToString()) // set value from the Form to Sim_processOptions
            {
                case "forceFormatButton":
                    App.Sim_processOpt_temp.forceOutputFormat = UPFTypeC1.selection;
                    break;
            }

            updateOptTreeViewColor(UPFTypeC1.Tag.ToString(), UPFTypeC1);
            UPFTypeC1?.Dispose();
            UPFTypeC1 = null;
        }
    



        ////  v_scaleForm (V_scaleSelectForm)  /////
        private void v_scaleForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(v_scaleForm?.selection != null||v_scaleForm.isConfirmed) // if null means user canceled
                App.Sim_processOpt_temp.v_scale = v_scaleForm.selection;

            // set TreeView color
            updateOptTreeViewColor("V_scalingNode", v_scaleForm);
            v_scaleForm?.Dispose();
            v_scaleForm = null;
        }



        ////  v_cropForm (V_cropSelectForm)  /////
        private void v_cropForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(v_cropForm?.selection != null||v_cropForm.isConfirmed)
                App.Sim_processOpt_temp.v_crop = v_cropForm.selection;

            // set TreeView color
            updateOptTreeViewColor("V_cropNode", v_cropForm);
            v_cropForm?.Dispose();
            v_cropForm = null;
        }


        private void strmMapForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(strmMapForm?.selection != null||strmMapForm.isConfirmed)
                App.Sim_processOpt_temp.strmMapping = strmMapForm.selection;

            // set TreeView color
            updateOptTreeViewColor("StrmMapNode", strmMapForm);
            strmMapForm?.Dispose();
            strmMapForm = null;
        }

        private void ExpandTextForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            dynamic s = sender;
            if (s == null) return;
            switch (s.Tag.ToString())
            {
                case "CE_cmdExpForm":
                    CE_commandRTextBox.Text = CE_cmdExpForm.MainRTextBox.Text;
                    CE_cmdExpForm?.Dispose();
                    CE_cmdExpForm = null; 
                    break;
                case "CE_whatItDoesExpForm": 
                    CE_whatItDoesExpForm?.Dispose();
                    CE_whatItDoesExpForm = null;
                    break;
                case "CMDOutputViewForm":
                    CMDOutputViewForm?.Dispose();
                    CMDOutputViewForm = null;
                    break;
            }
        }


        private void MetadataForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(MetadataForm?.selection != null)
                App.Sim_processOpt_temp.metadata = MetadataForm.selection;

            updateOptTreeViewColor(
                "MetadataNode",
                MetadataForm,
                App.Sim_processOpt_temp.metadata?.isAllNull()
            );
            MetadataForm?.Dispose();
            MetadataForm = null;
        }





















        ////    SYSTEM    /////
        /// EventHandelers
        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            if(!App.cmdRunning)
            {
                wait(5);
                return;
            }
            App.fileSystemWatcherTriggerCount++;
            /* if (App.fileSystemWatcherTriggerCount > 8 && !runningFFCommand)
             {
                 wait(1000);
             }
             if (App.fileSystemWatcherTriggerCount > 1000)
             {
                 fileSystemWatcher1.Changed -= fileSystemWatcher1_Changed;
                 triggers.Add(new Trigger() { type = "fileSystemWatcherReset" });
             }*/


            //`.cache01`: ffmpeg render
            //`.cache02`: getinfo
            //System.Threading.Thread.Sleep(10);
            string stdout;
            try
            {   // when node and System.IO try to access the same file at the same times
                // will cause Error, handle by try again
                stdout = File.ReadAllText(e.FullPath, Encoding.UTF8);
            }
            catch
            {
                return;
            }

            if (stdout == null || stdout == "")
            {
                /*System.Threading.Thread.Sleep(1000);
                wait(1000);*/
                return;
            }
            if (e.Name == ".cache01")
            {
                // for some reasons `fs.writeFileSync()` would trigger `fileSystemWatcher_on_fileChanged` twice
                // this `if` statment is here to prevent that

                if (App.lastStrStdout == stdout) return;
                App.lastStrStdout = stdout;
                //App.fileSystemWatcherTriggerCount = 0;
                App.stdOut = stdout;

                if (CMDOutputViewForm != null)
                {
                    Console.WriteLine("[FFmpeg] " + stdout);
                    CMDOutputViewForm.AddText(stdout);
                }

                if (stdout.ContainsAny(App.FFmpegErrorKeyWords)||App.stdError != null)
                {
                    if (App.stdError == null)
                    {
                        Trigger t = new Trigger();
                        t.type = "cmderror";
                        if (!triggers.Contains(t)) triggers.Add(t);
                        App.stdError = "";
                    }
                    App.stdError += stdout;
                }

                
                if (stdout.Contains("time=") && CE_progressBar.Value < CE_progressBar.Maximum * 0.98)
                { // when rendering start
                    if (!hasTrigger("checkRenderEnd", triggers))
                    {
                        App.Sim_renderOpt.renderStartMS = (uint)(DateTime.Now.Ticks / 10_000);
                        Trigger t = new Trigger();
                        t.type = "checkRenderEnd";
                        triggers.Add(t);
                    }

                    CE_progressBar.Style = ProgressBarStyle.Continuous;
                    int size = (int) stdout.Split(new string[] { "time=" }, OptNone)[1]
                        .Split(' ')[0]
                        .ToTimeMS();
                    CE_progressBar.Value = size < CE_progressBar.Maximum ? size : CE_progressBar.Value;
                }




                // for future use //
            }
            else if (e.Name == ".cache02") // for `View info` menu stript
            {
                /*if (App.lastStdout + 1_000_000 > DateTime.Now.Ticks) return;
                App.lastStdout = DateTime.Now.Ticks;*/
                if (App.lastStrStdout == stdout) return;
                App.lastStrStdout = stdout;

                string fileName = App.FileInfo.getName(stdout);
                App.FileInfo info = null;
                foreach (App.InputFile f in App.Sim_inputFiles)
                {
                    if (f.name != fileName) continue;
                    if (f.info != null) info = App.FileInfo.parse(stdout, f.info);
                    else info = App.FileInfo.parse(stdout);
                    f.info = info;
                    App.addFileRemote.Trigger();
                    //Console.WriteLine("tri");
                    break;
                }

                if (App.FileInfo._request.showFileInfoWhenReady && info != null)
                {
                    MessageBox.Show(info.ToString(), "File Info");
                    App.FileInfo._request.showFileInfoWhenReady = false;
                }

                App.cmdRunning = false;
            }
        }













        // Tick Functions
        private void Timer_20_Tick(object sender, EventArgs e)
        {
            if(Sim_processTreeView.SelectedNode == null)
                Sim_ClearProcessOptButton.Enabled = false;
            else 
                Sim_ClearProcessOptButton.Enabled = (Sim_processTreeView.SelectedNode.ForeColor == Color.Aqua);
            

            foreach(Trigger tg in triggers.ToList())
            {
                switch (tg.type)
                {
                    case "menu_buttonclick":
                        setMenuControlDisEnable(false);
                        /* since each buttons on the Menu will open and close in the different orders,
                         * each buttons that hasn't been clicked will move (in/out) first
                         * then the one that is clicked will move with a special animation
                         * which identify(for driver) as "selected" tag
                         */
                        switch (tg.EventKeyFrame)
                        {
                            case 0:
                                if (AMenuAboutButton.control.Name != tg.control.Name)
                                    AMenuAboutButton.TriggerOpen = true;
                                break;
                            case 1:
                                if (AMenuSettingButton.control.Name != tg.control.Name)
                                    AMenuSettingButton.TriggerOpen = true;
                                break;
                            case 2:
                                if (AMenuDocButton.control.Name != tg.control.Name)
                                    AMenuDocButton.TriggerOpen = true;
                                break;
                            case 4:
                                tg.AControl.TriggerOpen = true;
                                tg.AControl.triggerTag = "selected";
                                break;
                        }
                        break;

                    case "menu_gobackbuttonclick": 
                        switch (tg.EventKeyFrame)
                        {
                            case 0:
                                if (AMenuAboutButton.control.Name != tg.control.Name)
                                    AMenuAboutButton.TriggerClose = true;
                                break;
                            case 1:
                                if (AMenuSettingButton.control.Name != tg.control.Name)
                                    AMenuSettingButton.TriggerClose = true;
                                break;
                            case 2:
                                if (AMenuDocButton.control.Name != tg.control.Name)
                                    AMenuDocButton.TriggerClose = true;
                                break;
                            case 4:
                                tg.AControl.TriggerClose = true;
                                tg.AControl.triggerTag = "selected";
                                break;
                        }
                        break;

                    case "cmderror":
                        if(App.lastStdError + 1_500_000 > DateTime.Now.Ticks) return; //wait for Errors to fetched out
                        CE_stopCommandButton_Click(new object { }, new EventArgs());
                        triggers.Remove(tg);
                        break;

                    case "fileSystemWatcherReset":
                        App.fileSystemWatcherTriggerCount = 0;
                        fileSystemWatcher1.Changed += fileSystemWatcher1_Changed;
                        triggers.Remove(tg);
                        break;

                    case "checkRenderEnd":
                        //Console.WriteLine(App.stdOut);
                        if (App.stdOut.ContainsAny(App.FFmpegRenderEndKeyWords)) //when ffmpeg finish
                        {
                            Console.WriteLine("Render Job Finished");
                            //wait((App.Sim_renderOpt.renderModeCopy ? 200 : App.prefs.internalReadDelay));
                            triggers.Remove(tg);
                            wait(100);
                            render_OnFinished();
                        }
                        break;
                }
            
                tg.EventKeyFrame += 1;
            }


            if(menu_openedButtonPage == -1)
            {
                int selIndex = Sim_inputFilelistBox.SelectedIndex;
                if (selIndex == -1) Sim_removeInputFileButton.Enabled = false;
                else Sim_removeInputFileButton.Enabled = true;
            }
        }



        private void Timer_1000_Tick(object sender, EventArgs e)
        {

            /// Animation
            if (AcExcPanel.TriggerOpen||AcExcPanel.TriggerClose)
            {
                unsafe //declare code as unsafe to allowed Pointers to work
                {   //define pointer in fixed() (no pointer allowed outside)
                    fixed(double* KFA = &AcExcPanel.keyFrame) // KFA = keyFrameAdress
                    {
                        int height = Animation.Driver(
                            KFA,
                            0.023 * (AcExcPanel.TriggerClose ? -1 : 1),
                            Animation.Curve.easeOutExpo,
                            (int)(MainTabControl.Size.Height * cExcPanelExpandMul),
                            AcExcPanel.startSize.Height
                        );
                        AppControl.FixPointResize(Sim_CommandExePanel, new Size(
                            Sim_CommandExePanel.Size.Width,
                            height
                        ), "bl");
                        if(AcExcPanel.keyFrame >= 1)
                        {
                            if (AcExcPanel.TriggerClose) CE_panel_OnClose();
                            else CE_panel_OnOpen();
                            AcExcPanel.AnimReset();
                        }
                    }
                    
                }
                
            }



            if (AMenuPanel.TriggerOpen||AMenuPanel.TriggerClose)
            {
                unsafe
                {
                    fixed (double* KFA = &AMenuPanel.keyFrame) // KFA = keyFrameAdress
                    {
                        int EndPoint = (int)(
                            thisDefSize.Width * menuPanelExpandPhase1Mul
                        );
                        int width = Animation.Driver(
                            KFA,
                            0.023 * (AMenuPanel.TriggerClose?-1:1), //if close reverse Start-End
                            Animation.Curve.easeOutExpo,
                            EndPoint,
                            menuPanelStartWidth
                        );
                        AppControl.FixPointResize(AMenuPanel.control, new Size(
                            width,
                            MenuPanel.Size.Height
                        ), "tl");
                        if (AMenuPanel.keyFrame >= 1)
                        {
                            if (AMenuPanel.TriggerClose) MenuPanel_OnClose();
                            else MenuPanel_OnOpen();
                            AMenuPanel.AnimReset();
                        }
                    }

                }
            }





            if (AMenuAboutButton.TriggerOpen||AMenuAboutButton.TriggerClose)
            {
                unsafe
                {
                    fixed (double* KFA = &AMenuAboutButton.keyFrame)
                    {
                        int VX, VA; //ValueX
                        if(AMenuAboutButton.triggerTag == "selected")
                        {
                            VX = Animation.Driver(
                                KFA,
                                0.025 * (AMenuAboutButton.TriggerClose ? -1 : 1),
                                Animation.Curve.easeOutExpo,
                                menuPanelButtonTopPading,
                                AMenuAboutButton.startPoint.Y
                            );
                            VA = Animation.Driver(
                               KFA, // this KeyFrame is driven by Driver above thus, speed needed to be 0
                               1e-31 * (AMenuAboutButton.TriggerClose ? -1 : 1), //the Driver also required negative-value so a verry small value is use instead of 0
                               Animation.Curve.easeOutExpo,
                               (int)(MenuPanel.Size.Width * menuPanelButtonOpenXMul),
                               AMenuAboutButton.startPoint.X
                            );
                            Menu_aboutButton.Location = new Point(
                                VA,
                                VX
                            );
                        }
                        else
                        {
                            VX = Animation.Driver(
                                KFA,
                                0.03 * (AMenuAboutButton.TriggerClose ? -1 : 1),
                                Animation.Curve.easeOutExpo,
                                (int)(-AMenuAboutButton.control.Size.Width),
                                AMenuAboutButton.startPoint.X
                            );
                            Menu_aboutButton.Location = new Point(
                                VX,
                                AMenuAboutButton.startPoint.Y
                            );
                        }
                        

                        if (AMenuAboutButton.keyFrame >= 1)
                        {
                            if (AMenuAboutButton.triggerTag == "selected")
                            {
                                foreach (Trigger tg in triggers.ToList()) 
                                    if (tg.control.Name == AMenuAboutButton.control.Name) triggers.Remove(tg);
                                if (AMenuAboutButton.TriggerClose)
                                {
                                    menu_openedButtonPage = -1; // as index
                                    Menubuttons_OnClose();
                                }
                                else
                                {
                                    menu_openedButtonPage = 0;
                                    Menubuttons_OnOpen();
                                }
                            }
                            AMenuAboutButton.AnimReset();
                        }
                    }

                }
            }


            if (AMenuSettingButton.TriggerOpen||AMenuSettingButton.TriggerClose)
            {
                unsafe
                {
                    fixed (double* KFA = &AMenuSettingButton.keyFrame)
                    {
                        int VX, VA; //ValueX
                        if (AMenuSettingButton.triggerTag == "selected")
                        {
                            VX = Animation.Driver(
                                KFA,
                                0.025 * (AMenuSettingButton.TriggerClose ? -1 : 1),
                                Animation.Curve.easeOutExpo,
                                menuPanelButtonTopPading,
                                AMenuSettingButton.startPoint.Y
                            );
                            VA = Animation.Driver(
                                KFA,
                                1e-31 * (AMenuSettingButton.TriggerClose ? -1 : 1),
                                Animation.Curve.easeOutExpo,
                                (int)(MenuPanel.Size.Width * menuPanelButtonOpenXMul),
                                AMenuSettingButton.startPoint.X
                            );
                            Menu_SettingButton.Location = new Point(
                                VA,
                                VX
                            );
                        }
                        else
                        {
                            VX = Animation.Driver(
                                KFA,
                                0.03 * (AMenuSettingButton.TriggerClose ? -1 : 1),
                                Animation.Curve.easeOutExpo,
                                (int)(-AMenuSettingButton.control.Size.Width),
                                AMenuSettingButton.startPoint.X
                            );
                            Menu_SettingButton.Location = new Point(
                                VX,
                                AMenuSettingButton.startPoint.Y
                            );
                        }


                        if (AMenuSettingButton.keyFrame >= 1)
                        {
                            if (AMenuSettingButton.triggerTag == "selected")
                            {
                                foreach (Trigger tg in triggers.ToList()) 
                                    if (tg.control.Name == AMenuSettingButton.control.Name) triggers.Remove(tg);
                                if (AMenuSettingButton.TriggerClose)
                                {
                                    menu_openedButtonPage = -1;
                                    Menubuttons_OnClose();
                                }
                                else
                                {
                                    menu_openedButtonPage = 1;
                                    Menubuttons_OnOpen();
                                }
                            }
                            AMenuSettingButton.AnimReset();
                        }
                    }

                }
            }


            if (AMenuDocButton.TriggerOpen||AMenuDocButton.TriggerClose)
            {
                unsafe
                {
                    fixed (double* KFA = &AMenuDocButton.keyFrame)
                    {
                        int VX, VA; //ValueX
                        if (AMenuDocButton.triggerTag == "selected")
                        {
                            VX = Animation.Driver(
                                KFA,
                                0.023 * (AMenuDocButton.TriggerClose ? -1 : 1),
                                Animation.Curve.easeOutExpo,
                                menuPanelButtonTopPading,
                                AMenuDocButton.startPoint.Y
                            );
                            VA = Animation.Driver(
                                KFA,
                                1e-31 * (AMenuDocButton.TriggerClose ? -1 : 1),
                                Animation.Curve.easeOutExpo,
                                (int)(MenuPanel.Size.Width * menuPanelButtonOpenXMul),
                                AMenuDocButton.startPoint.X
                            );
                            Menu_docButton.Location = new Point(
                                VA,
                                VX
                            );
                        }
                        else
                        {
                            VX = Animation.Driver(
                                KFA,
                                0.03 * (AMenuDocButton.TriggerClose ? -1 : 1),
                                Animation.Curve.easeOutExpo,
                                (int)(-AMenuDocButton.control.Size.Width),
                                AMenuDocButton.startPoint.X
                            );
                            Menu_docButton.Location = new Point(
                                VX,
                                AMenuDocButton.startPoint.Y
                            );
                        }


                        if (AMenuDocButton.keyFrame >= 1)
                        {
                            if (AMenuDocButton.triggerTag == "selected")
                            {
                                foreach(Trigger tg in triggers.ToList()) 
                                    if(tg.control.Name == AMenuDocButton.control.Name) triggers.Remove(tg);
                                if (AMenuDocButton.TriggerClose)
                                {
                                    menu_openedButtonPage = -1;
                                    Menubuttons_OnClose();
                                }
                                else
                                {
                                    menu_openedButtonPage = 2;
                                    Menubuttons_OnOpen();
                                }
                            }
                            AMenuDocButton.AnimReset();
                        }
                    }

                }
            }




            if (ASubMenuAboutPanel.TriggerOpen || ASubMenuAboutPanel.TriggerClose)
            {
                unsafe
                {
                    fixed (double* KFA = &ASubMenuAboutPanel.keyFrame) // KFA = keyFrameAdress
                    {
                        int EndPoint = (int)(
                            thisDefSize.Width * menuPanelExpandPhase1Mul
                        );
                        int height = Animation.Driver(
                            KFA,
                            0.023 * (ASubMenuAboutPanel.TriggerClose ? -1 : 1), //if close reverse Start-End
                            Animation.Curve.easeOutExpo,
                            MenuSubpanelExpandedSize.Height,
                            MenuSubpanelHindedSize.Height
                        );
                        AppControl.FixPointResize(ASubMenuAboutPanel.control, new Size(
                            Menu_aboutPanel.Size.Height,
                            height
                        ), "tr");
                        if (ASubMenuAboutPanel.keyFrame >= 1)
                        {
                            if (ASubMenuAboutPanel.TriggerClose) SubMenuPanel_OnClose();
                            else SubMenuPanel_OnOpen();
                            ASubMenuAboutPanel.AnimReset();
                        }
                    }

                }
            }





            if (ASubMenuSettingPanel.TriggerOpen || ASubMenuSettingPanel.TriggerClose)
            {
                unsafe
                {
                    fixed (double* KFA = &ASubMenuSettingPanel.keyFrame) // KFA = keyFrameAdress
                    {
                        int EndPoint = (int)(
                            thisDefSize.Width * menuPanelExpandPhase1Mul
                        );
                        int height = Animation.Driver(
                            KFA,
                            0.023 * (ASubMenuSettingPanel.TriggerClose ? -1 : 1), //if close reverse Start-End
                            Animation.Curve.easeOutExpo,
                            MenuSubpanelExpandedSize.Height,
                            MenuSubpanelHindedSize.Height
                        );
                        AppControl.FixPointResize(ASubMenuSettingPanel.control, new Size(
                            Menu_settingPanel.Size.Height,
                            height
                        ), "tr");
                        if (ASubMenuSettingPanel.keyFrame >= 1)
                        {
                            if (ASubMenuSettingPanel.TriggerClose) SubMenuPanel_OnClose();
                            else SubMenuPanel_OnOpen();
                            ASubMenuSettingPanel.AnimReset();
                        }
                    }

                }
            }





            if (ASubMenuDocPanel.TriggerOpen || ASubMenuDocPanel.TriggerClose)
            {
                unsafe
                {
                    fixed (double* KFA = &ASubMenuDocPanel.keyFrame) // KFA = keyFrameAdress
                    {
                        int EndPoint = (int)(
                            thisDefSize.Width * menuPanelExpandPhase1Mul
                        );
                        int height = Animation.Driver(
                            KFA,
                            0.023 * (ASubMenuDocPanel.TriggerClose ? -1 : 1), //if close reverse Start-End
                            Animation.Curve.easeOutExpo,
                            MenuSubpanelExpandedSize.Height,
                            MenuSubpanelHindedSize.Height
                        );
                        AppControl.FixPointResize(ASubMenuDocPanel.control, new Size(
                            Menu_docPanel.Size.Height,
                            height
                        ), "tr");
                        if (ASubMenuDocPanel.keyFrame >= 1)
                        {
                            if (ASubMenuDocPanel.TriggerClose) SubMenuPanel_OnClose();
                            else SubMenuPanel_OnOpen();
                            ASubMenuDocPanel.AnimReset();
                        }
                    }

                }
            }





        }

        
    }
}
