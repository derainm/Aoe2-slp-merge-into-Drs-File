
namespace Aoe2_slp_merge_into_Drs_File
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
            this.buttonBrowserDrs = new System.Windows.Forms.Button();
            this.buttonMergeSlpIntoDrs = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDRS = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonBrowserSlpDir = new System.Windows.Forms.Button();
            this.tabLanguageIniToDll = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBrowserLanguageDll = new System.Windows.Forms.Button();
            this.buttonUpdateLanguage = new System.Windows.Forms.Button();
            this.buttonBrowserLanguageIni = new System.Windows.Forms.Button();
            this.tabLanguageDllToIni = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabDRS.SuspendLayout();
            this.tabLanguageIniToDll.SuspendLayout();
            this.tabLanguageDllToIni.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBrowserDrs
            // 
            this.buttonBrowserDrs.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonBrowserDrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBrowserDrs.ForeColor = System.Drawing.Color.Cornsilk;
            this.buttonBrowserDrs.Location = new System.Drawing.Point(19, 326);
            this.buttonBrowserDrs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonBrowserDrs.Name = "buttonBrowserDrs";
            this.buttonBrowserDrs.Size = new System.Drawing.Size(185, 76);
            this.buttonBrowserDrs.TabIndex = 0;
            this.buttonBrowserDrs.Text = "Browser slp files directory";
            this.buttonBrowserDrs.UseVisualStyleBackColor = false;
            this.buttonBrowserDrs.Click += new System.EventHandler(this.buttonBrowserDrs_Click);
            // 
            // buttonMergeSlpIntoDrs
            // 
            this.buttonMergeSlpIntoDrs.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonMergeSlpIntoDrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMergeSlpIntoDrs.ForeColor = System.Drawing.Color.Cornsilk;
            this.buttonMergeSlpIntoDrs.Location = new System.Drawing.Point(449, 326);
            this.buttonMergeSlpIntoDrs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonMergeSlpIntoDrs.Name = "buttonMergeSlpIntoDrs";
            this.buttonMergeSlpIntoDrs.Size = new System.Drawing.Size(150, 76);
            this.buttonMergeSlpIntoDrs.TabIndex = 2;
            this.buttonMergeSlpIntoDrs.Text = "Merge slp into drs ";
            this.buttonMergeSlpIntoDrs.UseVisualStyleBackColor = false;
            this.buttonMergeSlpIntoDrs.Click += new System.EventHandler(this.buttonMergeSlpIntoDrs_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDRS);
            this.tabControl1.Controls.Add(this.tabLanguageIniToDll);
            this.tabControl1.Controls.Add(this.tabLanguageDllToIni);
            this.tabControl1.Location = new System.Drawing.Point(26, 30);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(614, 479);
            this.tabControl1.TabIndex = 3;
            // 
            // tabDRS
            // 
            this.tabDRS.BackColor = System.Drawing.Color.SteelBlue;
            this.tabDRS.Controls.Add(this.label3);
            this.tabDRS.Controls.Add(this.buttonBrowserSlpDir);
            this.tabDRS.Controls.Add(this.buttonMergeSlpIntoDrs);
            this.tabDRS.Controls.Add(this.buttonBrowserDrs);
            this.tabDRS.Location = new System.Drawing.Point(4, 29);
            this.tabDRS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabDRS.Name = "tabDRS";
            this.tabDRS.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabDRS.Size = new System.Drawing.Size(606, 446);
            this.tabDRS.TabIndex = 0;
            this.tabDRS.Text = "Slp Into DRS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Cornsilk;
            this.label3.Location = new System.Drawing.Point(14, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(412, 32);
            this.label3.TabIndex = 6;
            this.label3.Text = "Merges slp files into a drs file";
            // 
            // buttonBrowserSlpDir
            // 
            this.buttonBrowserSlpDir.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonBrowserSlpDir.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonBrowserSlpDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBrowserSlpDir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonBrowserSlpDir.Location = new System.Drawing.Point(19, 221);
            this.buttonBrowserSlpDir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonBrowserSlpDir.Name = "buttonBrowserSlpDir";
            this.buttonBrowserSlpDir.Size = new System.Drawing.Size(185, 76);
            this.buttonBrowserSlpDir.TabIndex = 1;
            this.buttonBrowserSlpDir.Text = "Browser drs file";
            this.buttonBrowserSlpDir.UseVisualStyleBackColor = false;
            this.buttonBrowserSlpDir.Click += new System.EventHandler(this.buttonBrowserSlpDir_Click);
            // 
            // tabLanguageIniToDll
            // 
            this.tabLanguageIniToDll.BackColor = System.Drawing.Color.SteelBlue;
            this.tabLanguageIniToDll.Controls.Add(this.label1);
            this.tabLanguageIniToDll.Controls.Add(this.buttonBrowserLanguageDll);
            this.tabLanguageIniToDll.Controls.Add(this.buttonUpdateLanguage);
            this.tabLanguageIniToDll.Controls.Add(this.buttonBrowserLanguageIni);
            this.tabLanguageIniToDll.Location = new System.Drawing.Point(4, 29);
            this.tabLanguageIniToDll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabLanguageIniToDll.Name = "tabLanguageIniToDll";
            this.tabLanguageIniToDll.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabLanguageIniToDll.Size = new System.Drawing.Size(606, 446);
            this.tabLanguageIniToDll.TabIndex = 1;
            this.tabLanguageIniToDll.Text = "Language ini ->dll";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Cornsilk;
            this.label1.Location = new System.Drawing.Point(15, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(411, 32);
            this.label1.TabIndex = 5;
            this.label1.Text = "Language ini to Language dll";
            // 
            // buttonBrowserLanguageDll
            // 
            this.buttonBrowserLanguageDll.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonBrowserLanguageDll.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonBrowserLanguageDll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBrowserLanguageDll.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonBrowserLanguageDll.Location = new System.Drawing.Point(20, 214);
            this.buttonBrowserLanguageDll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonBrowserLanguageDll.Name = "buttonBrowserLanguageDll";
            this.buttonBrowserLanguageDll.Size = new System.Drawing.Size(163, 76);
            this.buttonBrowserLanguageDll.TabIndex = 4;
            this.buttonBrowserLanguageDll.Text = "Browser language dll";
            this.buttonBrowserLanguageDll.UseVisualStyleBackColor = false;
            this.buttonBrowserLanguageDll.Click += new System.EventHandler(this.buttonBrowserLanguageDll_Click_1);
            // 
            // buttonUpdateLanguage
            // 
            this.buttonUpdateLanguage.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonUpdateLanguage.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonUpdateLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdateLanguage.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonUpdateLanguage.Location = new System.Drawing.Point(410, 330);
            this.buttonUpdateLanguage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonUpdateLanguage.Name = "buttonUpdateLanguage";
            this.buttonUpdateLanguage.Size = new System.Drawing.Size(164, 76);
            this.buttonUpdateLanguage.TabIndex = 3;
            this.buttonUpdateLanguage.Text = "Update language dll";
            this.buttonUpdateLanguage.UseVisualStyleBackColor = false;
            this.buttonUpdateLanguage.Click += new System.EventHandler(this.buttonUpdateLanguage_Click);
            // 
            // buttonBrowserLanguageIni
            // 
            this.buttonBrowserLanguageIni.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonBrowserLanguageIni.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonBrowserLanguageIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBrowserLanguageIni.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonBrowserLanguageIni.Location = new System.Drawing.Point(20, 330);
            this.buttonBrowserLanguageIni.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonBrowserLanguageIni.Name = "buttonBrowserLanguageIni";
            this.buttonBrowserLanguageIni.Size = new System.Drawing.Size(163, 76);
            this.buttonBrowserLanguageIni.TabIndex = 2;
            this.buttonBrowserLanguageIni.Text = "Browser language.ini";
            this.buttonBrowserLanguageIni.UseVisualStyleBackColor = false;
            this.buttonBrowserLanguageIni.Click += new System.EventHandler(this.buttonBrowserLanguageIni_Click);
            // 
            // tabLanguageDllToIni
            // 
            this.tabLanguageDllToIni.BackColor = System.Drawing.Color.SteelBlue;
            this.tabLanguageDllToIni.Controls.Add(this.label2);
            this.tabLanguageDllToIni.Controls.Add(this.button3);
            this.tabLanguageDllToIni.Controls.Add(this.button1);
            this.tabLanguageDllToIni.Location = new System.Drawing.Point(4, 29);
            this.tabLanguageDllToIni.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabLanguageDllToIni.Name = "tabLanguageDllToIni";
            this.tabLanguageDllToIni.Size = new System.Drawing.Size(606, 446);
            this.tabLanguageDllToIni.TabIndex = 2;
            this.tabLanguageDllToIni.Text = "Language dll -> ini ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Cornsilk;
            this.label2.Location = new System.Drawing.Point(15, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(411, 32);
            this.label2.TabIndex = 8;
            this.label2.Text = "Language dll to Language ini";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button3.Cursor = System.Windows.Forms.Cursors.Default;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button3.Location = new System.Drawing.Point(408, 330);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(164, 76);
            this.button3.TabIndex = 7;
            this.button3.Text = "Create Language.ini ";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(20, 330);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 76);
            this.button1.TabIndex = 5;
            this.button1.Text = "Browser language dll";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(649, 529);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(671, 585);
            this.MinimumSize = new System.Drawing.Size(671, 585);
            this.Name = "Form1";
            this.Text = "slp merge into drs file made by katsuie";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabDRS.ResumeLayout(false);
            this.tabDRS.PerformLayout();
            this.tabLanguageIniToDll.ResumeLayout(false);
            this.tabLanguageIniToDll.PerformLayout();
            this.tabLanguageDllToIni.ResumeLayout(false);
            this.tabLanguageDllToIni.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonBrowserDrs;
        private System.Windows.Forms.Button buttonMergeSlpIntoDrs;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDRS;
        private System.Windows.Forms.TabPage tabLanguageIniToDll;
        private System.Windows.Forms.Button buttonUpdateLanguage;
        private System.Windows.Forms.Button buttonBrowserLanguageIni;
        private System.Windows.Forms.Button buttonBrowserLanguageDll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBrowserSlpDir;
        private System.Windows.Forms.TabPage tabLanguageDllToIni;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

