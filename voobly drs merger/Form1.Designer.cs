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
            this.textBoxSlpDire = new System.Windows.Forms.TextBox();
            this.textBoxdrsBrowser = new System.Windows.Forms.TextBox();
            this.buttonBrowserSlpDir = new System.Windows.Forms.Button();
            this.buttonMergeSlpIntoDrs = new System.Windows.Forms.Button();
            this.buttonBrowserDrs = new System.Windows.Forms.Button();
            this.checkBoxisUpdateOnlyy = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.VooblyMods = new System.Windows.Forms.TabPage();
            this.SlpIntoDrs = new System.Windows.Forms.TabPage();
            this.FolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.button5 = new System.Windows.Forms.Button();
            this.mergeVooblyMod = new System.Windows.Forms.Button();
            this.browserAoe2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.SlpIntoDrs.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxSlpDire
            // 
            this.textBoxSlpDire.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.textBoxSlpDire.Location = new System.Drawing.Point(262, 177);
            this.textBoxSlpDire.Name = "textBoxSlpDire";
            this.textBoxSlpDire.ReadOnly = true;
            this.textBoxSlpDire.Size = new System.Drawing.Size(412, 20);
            this.textBoxSlpDire.TabIndex = 14;
            // 
            // textBoxdrsBrowser
            // 
            this.textBoxdrsBrowser.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.textBoxdrsBrowser.Location = new System.Drawing.Point(262, 117);
            this.textBoxdrsBrowser.Name = "textBoxdrsBrowser";
            this.textBoxdrsBrowser.ReadOnly = true;
            this.textBoxdrsBrowser.Size = new System.Drawing.Size(412, 20);
            this.textBoxdrsBrowser.TabIndex = 13;
            // 
            // buttonBrowserSlpDir
            // 
            this.buttonBrowserSlpDir.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonBrowserSlpDir.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonBrowserSlpDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBrowserSlpDir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonBrowserSlpDir.Location = new System.Drawing.Point(84, 98);
            this.buttonBrowserSlpDir.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonBrowserSlpDir.Name = "buttonBrowserSlpDir";
            this.buttonBrowserSlpDir.Size = new System.Drawing.Size(138, 49);
            this.buttonBrowserSlpDir.TabIndex = 11;
            this.buttonBrowserSlpDir.Text = "Browser drs file";
            this.buttonBrowserSlpDir.UseVisualStyleBackColor = false;
            this.buttonBrowserSlpDir.Click += new System.EventHandler(this.buttonBrowserSlpDir_Click);
            // 
            // buttonMergeSlpIntoDrs
            // 
            this.buttonMergeSlpIntoDrs.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonMergeSlpIntoDrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMergeSlpIntoDrs.ForeColor = System.Drawing.Color.Cornsilk;
            this.buttonMergeSlpIntoDrs.Location = new System.Drawing.Point(84, 216);
            this.buttonMergeSlpIntoDrs.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonMergeSlpIntoDrs.Name = "buttonMergeSlpIntoDrs";
            this.buttonMergeSlpIntoDrs.Size = new System.Drawing.Size(138, 49);
            this.buttonMergeSlpIntoDrs.TabIndex = 12;
            this.buttonMergeSlpIntoDrs.Text = "Merge slp into drs ";
            this.buttonMergeSlpIntoDrs.UseVisualStyleBackColor = false;
            // 
            // buttonBrowserDrs
            // 
            this.buttonBrowserDrs.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonBrowserDrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBrowserDrs.ForeColor = System.Drawing.Color.Cornsilk;
            this.buttonBrowserDrs.Location = new System.Drawing.Point(84, 153);
            this.buttonBrowserDrs.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonBrowserDrs.Name = "buttonBrowserDrs";
            this.buttonBrowserDrs.Size = new System.Drawing.Size(138, 49);
            this.buttonBrowserDrs.TabIndex = 10;
            this.buttonBrowserDrs.Text = "Browser slp directory";
            this.buttonBrowserDrs.UseVisualStyleBackColor = false;
            this.buttonBrowserDrs.Click += new System.EventHandler(this.buttonBrowserDrs_Click);
            // 
            // checkBoxisUpdateOnlyy
            // 
            this.checkBoxisUpdateOnlyy.AutoSize = true;
            this.checkBoxisUpdateOnlyy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxisUpdateOnlyy.ForeColor = System.Drawing.Color.AliceBlue;
            this.checkBoxisUpdateOnlyy.Location = new System.Drawing.Point(242, 229);
            this.checkBoxisUpdateOnlyy.Name = "checkBoxisUpdateOnlyy";
            this.checkBoxisUpdateOnlyy.Size = new System.Drawing.Size(131, 24);
            this.checkBoxisUpdateOnlyy.TabIndex = 18;
            this.checkBoxisUpdateOnlyy.Text = "is Update Only";
            this.checkBoxisUpdateOnlyy.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.VooblyMods);
            this.tabControl1.Controls.Add(this.SlpIntoDrs);
            this.tabControl1.Location = new System.Drawing.Point(28, 23);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(938, 495);
            this.tabControl1.TabIndex = 19;
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
            this.SlpIntoDrs.Controls.Add(this.buttonBrowserSlpDir);
            this.SlpIntoDrs.Controls.Add(this.checkBoxisUpdateOnlyy);
            this.SlpIntoDrs.Controls.Add(this.buttonBrowserDrs);
            this.SlpIntoDrs.Controls.Add(this.textBoxSlpDire);
            this.SlpIntoDrs.Controls.Add(this.buttonMergeSlpIntoDrs);
            this.SlpIntoDrs.Controls.Add(this.textBoxdrsBrowser);
            this.SlpIntoDrs.Location = new System.Drawing.Point(4, 22);
            this.SlpIntoDrs.Name = "SlpIntoDrs";
            this.SlpIntoDrs.Padding = new System.Windows.Forms.Padding(3);
            this.SlpIntoDrs.Size = new System.Drawing.Size(930, 469);
            this.SlpIntoDrs.TabIndex = 1;
            this.SlpIntoDrs.Text = "Slp Into Drs";
            // 
            // FolderDialog
            // 
            this.FolderDialog.ShowNewFolderButton = false;
            // 
            // FileDialog
            // 
            this.FileDialog.FileName = "FileDialog";
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button5.Cursor = System.Windows.Forms.Cursors.Default;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button5.Location = new System.Drawing.Point(170, 536);
            this.button5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(155, 49);
            this.button5.TabIndex = 22;
            this.button5.Text = "Restore your game as before";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
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
            this.mergeVooblyMod.Text = "merge voobly mod to drs mod";
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
            this.Controls.Add(this.button5);
            this.Controls.Add(this.mergeVooblyMod);
            this.Controls.Add(this.browserAoe2);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Slp Drs merger";
            this.tabControl1.ResumeLayout(false);
            this.SlpIntoDrs.ResumeLayout(false);
            this.SlpIntoDrs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSlpDire;
        private System.Windows.Forms.TextBox textBoxdrsBrowser;
        private System.Windows.Forms.Button buttonBrowserSlpDir;
        private System.Windows.Forms.Button buttonMergeSlpIntoDrs;
        private System.Windows.Forms.Button buttonBrowserDrs;
        private System.Windows.Forms.CheckBox checkBoxisUpdateOnlyy;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage VooblyMods;
        private System.Windows.Forms.TabPage SlpIntoDrs;
        private System.Windows.Forms.FolderBrowserDialog FolderDialog;
        private System.Windows.Forms.OpenFileDialog FileDialog;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button mergeVooblyMod;
        private System.Windows.Forms.Button browserAoe2;
    }
}

