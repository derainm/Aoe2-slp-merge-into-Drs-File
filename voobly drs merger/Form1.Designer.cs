namespace voobly_drs_merger
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBoxSlpDir = new System.Windows.Forms.TextBox();
            this.textBoxdrsBrowser = new System.Windows.Forms.TextBox();
            this.buttonBrowserDrs = new System.Windows.Forms.Button();
            this.buttonMergeSlpIntoDrs = new System.Windows.Forms.Button();
            this.buttonBrowserSlpDir = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.VooblyMods = new System.Windows.Forms.TabPage();
            this.SlpIntoDrs = new System.Windows.Forms.TabPage();
            this.tabPagelangdllIni = new System.Windows.Forms.TabPage();
            this.buttonLangDll = new System.Windows.Forms.Button();
            this.buttonLangIni = new System.Windows.Forms.Button();
            this.textBoxLanguagedll = new System.Windows.Forms.TextBox();
            this.tabPageLanginidll = new System.Windows.Forms.TabPage();
            this.richTextBoxLogs = new System.Windows.Forms.RichTextBox();
            this.textBoxLangdll = new System.Windows.Forms.TextBox();
            this.buttonSaveLanguageDll = new System.Windows.Forms.Button();
            this.buttonBrowserLangIni = new System.Windows.Forms.Button();
            this.textBoxLangIni = new System.Windows.Forms.TextBox();
            this.tabPageSwitchDataMods = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxLanguageIni = new System.Windows.Forms.CheckBox();
            this.labelUp = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonRestoreMod = new System.Windows.Forms.Button();
            this.mergeVooblyMod = new System.Windows.Forms.Button();
            this.browserAoe2 = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.SlpIntoDrs.SuspendLayout();
            this.tabPagelangdllIni.SuspendLayout();
            this.tabPageLanginidll.SuspendLayout();
            this.tabPageSwitchDataMods.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxSlpDir
            // 
            this.textBoxSlpDir.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.textBoxSlpDir.Location = new System.Drawing.Point(206, 198);
            this.textBoxSlpDir.Name = "textBoxSlpDir";
            this.textBoxSlpDir.ReadOnly = true;
            this.textBoxSlpDir.Size = new System.Drawing.Size(613, 20);
            this.textBoxSlpDir.TabIndex = 14;
            // 
            // textBoxdrsBrowser
            // 
            this.textBoxdrsBrowser.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.textBoxdrsBrowser.Location = new System.Drawing.Point(206, 138);
            this.textBoxdrsBrowser.Name = "textBoxdrsBrowser";
            this.textBoxdrsBrowser.ReadOnly = true;
            this.textBoxdrsBrowser.Size = new System.Drawing.Size(613, 20);
            this.textBoxdrsBrowser.TabIndex = 13;
            // 
            // buttonBrowserDrs
            // 
            this.buttonBrowserDrs.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonBrowserDrs.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonBrowserDrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBrowserDrs.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonBrowserDrs.Location = new System.Drawing.Point(28, 119);
            this.buttonBrowserDrs.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonBrowserDrs.Name = "buttonBrowserDrs";
            this.buttonBrowserDrs.Size = new System.Drawing.Size(138, 49);
            this.buttonBrowserDrs.TabIndex = 11;
            this.buttonBrowserDrs.Text = "Browser drs file";
            this.buttonBrowserDrs.UseVisualStyleBackColor = false;
            this.buttonBrowserDrs.Click += new System.EventHandler(this.buttonBrowserDrs_Click);
            // 
            // buttonMergeSlpIntoDrs
            // 
            this.buttonMergeSlpIntoDrs.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonMergeSlpIntoDrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMergeSlpIntoDrs.ForeColor = System.Drawing.Color.Cornsilk;
            this.buttonMergeSlpIntoDrs.Location = new System.Drawing.Point(28, 237);
            this.buttonMergeSlpIntoDrs.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonMergeSlpIntoDrs.Name = "buttonMergeSlpIntoDrs";
            this.buttonMergeSlpIntoDrs.Size = new System.Drawing.Size(138, 49);
            this.buttonMergeSlpIntoDrs.TabIndex = 12;
            this.buttonMergeSlpIntoDrs.Text = "Merge slp into drs ";
            this.buttonMergeSlpIntoDrs.UseVisualStyleBackColor = false;
            this.buttonMergeSlpIntoDrs.Click += new System.EventHandler(this.buttonMergeSlpIntoDrs_Click);
            // 
            // buttonBrowserSlpDir
            // 
            this.buttonBrowserSlpDir.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonBrowserSlpDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBrowserSlpDir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonBrowserSlpDir.Location = new System.Drawing.Point(28, 174);
            this.buttonBrowserSlpDir.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonBrowserSlpDir.Name = "buttonBrowserSlpDir";
            this.buttonBrowserSlpDir.Size = new System.Drawing.Size(138, 49);
            this.buttonBrowserSlpDir.TabIndex = 10;
            this.buttonBrowserSlpDir.Text = "Browser slp directory";
            this.buttonBrowserSlpDir.UseVisualStyleBackColor = false;
            this.buttonBrowserSlpDir.Click += new System.EventHandler(this.buttonBrowserSlpDir_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.VooblyMods);
            this.tabControl.Controls.Add(this.SlpIntoDrs);
            this.tabControl.Controls.Add(this.tabPagelangdllIni);
            this.tabControl.Controls.Add(this.tabPageLanginidll);
            this.tabControl.Controls.Add(this.tabPageSwitchDataMods);
            this.tabControl.Location = new System.Drawing.Point(28, 23);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(938, 495);
            this.tabControl.TabIndex = 19;
            this.tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl_Selected);
            // 
            // VooblyMods
            // 
            this.VooblyMods.AutoScroll = true;
            this.VooblyMods.BackColor = System.Drawing.Color.SteelBlue;
            this.VooblyMods.Location = new System.Drawing.Point(4, 22);
            this.VooblyMods.Name = "VooblyMods";
            this.VooblyMods.Padding = new System.Windows.Forms.Padding(3);
            this.VooblyMods.Size = new System.Drawing.Size(930, 469);
            this.VooblyMods.TabIndex = 0;
            this.VooblyMods.Text = "Voobly Mods";
            // 
            // SlpIntoDrs
            // 
            this.SlpIntoDrs.BackColor = System.Drawing.Color.SteelBlue;
            this.SlpIntoDrs.Controls.Add(this.buttonBrowserDrs);
            this.SlpIntoDrs.Controls.Add(this.buttonBrowserSlpDir);
            this.SlpIntoDrs.Controls.Add(this.textBoxSlpDir);
            this.SlpIntoDrs.Controls.Add(this.buttonMergeSlpIntoDrs);
            this.SlpIntoDrs.Controls.Add(this.textBoxdrsBrowser);
            this.SlpIntoDrs.Location = new System.Drawing.Point(4, 22);
            this.SlpIntoDrs.Name = "SlpIntoDrs";
            this.SlpIntoDrs.Padding = new System.Windows.Forms.Padding(3);
            this.SlpIntoDrs.Size = new System.Drawing.Size(930, 469);
            this.SlpIntoDrs.TabIndex = 1;
            this.SlpIntoDrs.Text = "Slp Into Drs";
            // 
            // tabPagelangdllIni
            // 
            this.tabPagelangdllIni.BackColor = System.Drawing.Color.SteelBlue;
            this.tabPagelangdllIni.Controls.Add(this.buttonLangDll);
            this.tabPagelangdllIni.Controls.Add(this.buttonLangIni);
            this.tabPagelangdllIni.Controls.Add(this.textBoxLanguagedll);
            this.tabPagelangdllIni.Location = new System.Drawing.Point(4, 22);
            this.tabPagelangdllIni.Name = "tabPagelangdllIni";
            this.tabPagelangdllIni.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagelangdllIni.Size = new System.Drawing.Size(930, 469);
            this.tabPagelangdllIni.TabIndex = 2;
            this.tabPagelangdllIni.Text = "language dll -> language ini";
            // 
            // buttonLangDll
            // 
            this.buttonLangDll.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonLangDll.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonLangDll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLangDll.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonLangDll.Location = new System.Drawing.Point(28, 119);
            this.buttonLangDll.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonLangDll.Name = "buttonLangDll";
            this.buttonLangDll.Size = new System.Drawing.Size(138, 49);
            this.buttonLangDll.TabIndex = 16;
            this.buttonLangDll.Text = "Browser language dll";
            this.buttonLangDll.UseVisualStyleBackColor = false;
            this.buttonLangDll.Click += new System.EventHandler(this.buttonLangDll_Click);
            // 
            // buttonLangIni
            // 
            this.buttonLangIni.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonLangIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLangIni.ForeColor = System.Drawing.Color.Cornsilk;
            this.buttonLangIni.Location = new System.Drawing.Point(28, 174);
            this.buttonLangIni.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonLangIni.Name = "buttonLangIni";
            this.buttonLangIni.Size = new System.Drawing.Size(138, 49);
            this.buttonLangIni.TabIndex = 15;
            this.buttonLangIni.Text = "save as language ini";
            this.buttonLangIni.UseVisualStyleBackColor = false;
            this.buttonLangIni.Click += new System.EventHandler(this.buttonLangIni_Click);
            // 
            // textBoxLanguagedll
            // 
            this.textBoxLanguagedll.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.textBoxLanguagedll.Location = new System.Drawing.Point(206, 138);
            this.textBoxLanguagedll.Name = "textBoxLanguagedll";
            this.textBoxLanguagedll.ReadOnly = true;
            this.textBoxLanguagedll.Size = new System.Drawing.Size(613, 20);
            this.textBoxLanguagedll.TabIndex = 18;
            // 
            // tabPageLanginidll
            // 
            this.tabPageLanginidll.BackColor = System.Drawing.Color.SteelBlue;
            this.tabPageLanginidll.Controls.Add(this.richTextBoxLogs);
            this.tabPageLanginidll.Controls.Add(this.textBoxLangdll);
            this.tabPageLanginidll.Controls.Add(this.buttonSaveLanguageDll);
            this.tabPageLanginidll.Controls.Add(this.buttonBrowserLangIni);
            this.tabPageLanginidll.Controls.Add(this.textBoxLangIni);
            this.tabPageLanginidll.Location = new System.Drawing.Point(4, 22);
            this.tabPageLanginidll.Name = "tabPageLanginidll";
            this.tabPageLanginidll.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLanginidll.Size = new System.Drawing.Size(930, 469);
            this.tabPageLanginidll.TabIndex = 3;
            this.tabPageLanginidll.Text = "language ini -> language dll ";
            // 
            // richTextBoxLogs
            // 
            this.richTextBoxLogs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBoxLogs.Location = new System.Drawing.Point(28, 242);
            this.richTextBoxLogs.Name = "richTextBoxLogs";
            this.richTextBoxLogs.Size = new System.Drawing.Size(791, 206);
            this.richTextBoxLogs.TabIndex = 23;
            this.richTextBoxLogs.Text = "";
            // 
            // textBoxLangdll
            // 
            this.textBoxLangdll.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.textBoxLangdll.Location = new System.Drawing.Point(206, 198);
            this.textBoxLangdll.Name = "textBoxLangdll";
            this.textBoxLangdll.ReadOnly = true;
            this.textBoxLangdll.Size = new System.Drawing.Size(613, 20);
            this.textBoxLangdll.TabIndex = 22;
            // 
            // buttonSaveLanguageDll
            // 
            this.buttonSaveLanguageDll.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonSaveLanguageDll.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonSaveLanguageDll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveLanguageDll.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonSaveLanguageDll.Location = new System.Drawing.Point(28, 174);
            this.buttonSaveLanguageDll.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonSaveLanguageDll.Name = "buttonSaveLanguageDll";
            this.buttonSaveLanguageDll.Size = new System.Drawing.Size(138, 49);
            this.buttonSaveLanguageDll.TabIndex = 20;
            this.buttonSaveLanguageDll.Text = "Save language dll";
            this.buttonSaveLanguageDll.UseVisualStyleBackColor = false;
            this.buttonSaveLanguageDll.Click += new System.EventHandler(this.buttonSaveLanguageDll_Click);
            // 
            // buttonBrowserLangIni
            // 
            this.buttonBrowserLangIni.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonBrowserLangIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBrowserLangIni.ForeColor = System.Drawing.Color.Cornsilk;
            this.buttonBrowserLangIni.Location = new System.Drawing.Point(28, 119);
            this.buttonBrowserLangIni.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonBrowserLangIni.Name = "buttonBrowserLangIni";
            this.buttonBrowserLangIni.Size = new System.Drawing.Size(138, 49);
            this.buttonBrowserLangIni.TabIndex = 19;
            this.buttonBrowserLangIni.Text = "Browser language ini";
            this.buttonBrowserLangIni.UseVisualStyleBackColor = false;
            this.buttonBrowserLangIni.Click += new System.EventHandler(this.buttonBrowserLangIni_Click);
            // 
            // textBoxLangIni
            // 
            this.textBoxLangIni.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.textBoxLangIni.Location = new System.Drawing.Point(206, 138);
            this.textBoxLangIni.Name = "textBoxLangIni";
            this.textBoxLangIni.ReadOnly = true;
            this.textBoxLangIni.Size = new System.Drawing.Size(613, 20);
            this.textBoxLangIni.TabIndex = 21;
            // 
            // tabPageSwitchDataMods
            // 
            this.tabPageSwitchDataMods.BackColor = System.Drawing.Color.SteelBlue;
            this.tabPageSwitchDataMods.Controls.Add(this.label3);
            this.tabPageSwitchDataMods.Controls.Add(this.label2);
            this.tabPageSwitchDataMods.Controls.Add(this.checkBoxLanguageIni);
            this.tabPageSwitchDataMods.Controls.Add(this.labelUp);
            this.tabPageSwitchDataMods.Controls.Add(this.label1);
            this.tabPageSwitchDataMods.Location = new System.Drawing.Point(4, 22);
            this.tabPageSwitchDataMods.Name = "tabPageSwitchDataMods";
            this.tabPageSwitchDataMods.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSwitchDataMods.Size = new System.Drawing.Size(930, 469);
            this.tabPageSwitchDataMods.TabIndex = 4;
            this.tabPageSwitchDataMods.Text = "Switch Data Mods";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(723, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "if it is installed";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(723, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Aoe2 patch will manage language ini";
            // 
            // checkBoxLanguageIni
            // 
            this.checkBoxLanguageIni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxLanguageIni.AutoSize = true;
            this.checkBoxLanguageIni.Location = new System.Drawing.Point(708, 73);
            this.checkBoxLanguageIni.Name = "checkBoxLanguageIni";
            this.checkBoxLanguageIni.Size = new System.Drawing.Size(213, 17);
            this.checkBoxLanguageIni.TabIndex = 2;
            this.checkBoxLanguageIni.Text = "Language Ini don\'t compile language dll";
            this.checkBoxLanguageIni.UseVisualStyleBackColor = true;
            // 
            // labelUp
            // 
            this.labelUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUp.AutoSize = true;
            this.labelUp.BackColor = System.Drawing.Color.White;
            this.labelUp.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelUp.Location = new System.Drawing.Point(705, 40);
            this.labelUp.Name = "labelUp";
            this.labelUp.Size = new System.Drawing.Size(158, 13);
            this.labelUp.TabIndex = 1;
            this.labelUp.Text = "https://userpatch.aiscripters.net";
            this.labelUp.Click += new System.EventHandler(this.labelUp_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(705, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "work only with verison user patch >= 1.5";
            // 
            // FolderDialog
            // 
            this.FolderDialog.ShowNewFolderButton = false;
            // 
            // FileDialog
            // 
            this.FileDialog.FileName = "FileDialog";
            // 
            // buttonRestoreMod
            // 
            this.buttonRestoreMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRestoreMod.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonRestoreMod.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonRestoreMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRestoreMod.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonRestoreMod.Location = new System.Drawing.Point(170, 536);
            this.buttonRestoreMod.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonRestoreMod.Name = "buttonRestoreMod";
            this.buttonRestoreMod.Size = new System.Drawing.Size(155, 49);
            this.buttonRestoreMod.TabIndex = 22;
            this.buttonRestoreMod.Text = "Restore your game as before";
            this.buttonRestoreMod.UseVisualStyleBackColor = false;
            this.buttonRestoreMod.Click += new System.EventHandler(this.buttonRestoreMod_Click);
            // 
            // mergeVooblyMod
            // 
            this.mergeVooblyMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mergeVooblyMod.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.mergeVooblyMod.Cursor = System.Windows.Forms.Cursors.Default;
            this.mergeVooblyMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mergeVooblyMod.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.mergeVooblyMod.Location = new System.Drawing.Point(432, 536);
            this.mergeVooblyMod.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.mergeVooblyMod.Name = "mergeVooblyMod";
            this.mergeVooblyMod.Size = new System.Drawing.Size(184, 49);
            this.mergeVooblyMod.TabIndex = 21;
            this.mergeVooblyMod.Text = "Merge voobly mod to drs mod";
            this.mergeVooblyMod.UseVisualStyleBackColor = false;
            this.mergeVooblyMod.Click += new System.EventHandler(this.mergeVooblyMod_Click);
            // 
            // browserAoe2
            // 
            this.browserAoe2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.browserAoe2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.browserAoe2.Cursor = System.Windows.Forms.Cursors.Default;
            this.browserAoe2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browserAoe2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.browserAoe2.Location = new System.Drawing.Point(740, 536);
            this.browserAoe2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.browserAoe2.Name = "browserAoe2";
            this.browserAoe2.Size = new System.Drawing.Size(180, 49);
            this.browserAoe2.TabIndex = 20;
            this.browserAoe2.Text = "Browser Aoe2 folder";
            this.browserAoe2.UseVisualStyleBackColor = false;
            this.browserAoe2.Click += new System.EventHandler(this.browserAoe2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1003, 594);
            this.Controls.Add(this.buttonRestoreMod);
            this.Controls.Add(this.mergeVooblyMod);
            this.Controls.Add(this.browserAoe2);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Slp Drs merger";
            this.tabControl.ResumeLayout(false);
            this.SlpIntoDrs.ResumeLayout(false);
            this.SlpIntoDrs.PerformLayout();
            this.tabPagelangdllIni.ResumeLayout(false);
            this.tabPagelangdllIni.PerformLayout();
            this.tabPageLanginidll.ResumeLayout(false);
            this.tabPageLanginidll.PerformLayout();
            this.tabPageSwitchDataMods.ResumeLayout(false);
            this.tabPageSwitchDataMods.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSlpDir;
        private System.Windows.Forms.TextBox textBoxdrsBrowser;
        private System.Windows.Forms.Button buttonBrowserDrs;
        private System.Windows.Forms.Button buttonMergeSlpIntoDrs;
        private System.Windows.Forms.Button buttonBrowserSlpDir;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage VooblyMods;
        private System.Windows.Forms.TabPage SlpIntoDrs;
        private System.Windows.Forms.FolderBrowserDialog FolderDialog;
        private System.Windows.Forms.OpenFileDialog FileDialog;
        private System.Windows.Forms.Button buttonRestoreMod;
        private System.Windows.Forms.Button mergeVooblyMod;
        private System.Windows.Forms.Button browserAoe2;
        private System.Windows.Forms.TabPage tabPagelangdllIni;
        private System.Windows.Forms.Button buttonLangDll;
        private System.Windows.Forms.Button buttonLangIni;
        private System.Windows.Forms.TextBox textBoxLanguagedll;
        private System.Windows.Forms.TabPage tabPageLanginidll;
        private System.Windows.Forms.Button buttonSaveLanguageDll;
        private System.Windows.Forms.Button buttonBrowserLangIni;
        private System.Windows.Forms.TextBox textBoxLangIni;
        private System.Windows.Forms.TextBox textBoxLangdll;
        private System.Windows.Forms.RichTextBox richTextBoxLogs;
        private System.Windows.Forms.TabPage tabPageSwitchDataMods;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelUp;
        private System.Windows.Forms.CheckBox checkBoxLanguageIni;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

