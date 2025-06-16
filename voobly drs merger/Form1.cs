using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms; 

namespace voobly_drs_merger
{
    public partial class Form1 : Form
    {
        private string Aoe2Path;
        private string VooblyModsPath;
        private string drsPath;
        private string slpPath;
        private string LanguageDll;
        private string LanguageIni;
        private List<string> selectedMods = new List<string>();
        public Form formm = new Form();
        private Form form_ = new Form();
        private List<string> datamodsSelected = new List<string>();
        private List<string> lstDrsSelected = new List<string>();
        private List<LanguageInfo> lstLanguageInfo = new List<LanguageInfo>();
        public Form1()
        { 
            InitializeComponent();
            // Get the directory where the current executable is located
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            // Get the full path to the currently executing assembly 
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;
            // Get the directory name from the assembly location
            string appDir = Path.GetDirectoryName(assemblyLocation);
            //fix bug copy file in C:\Windows\System32 instead of current directory
            Environment.CurrentDirectory=appDir; 

        }

        private void buttonBrowserSlpDir_Click(object sender, EventArgs e)
        {
            if (FolderDialog.ShowDialog(this)==DialogResult.OK)
            {
                slpPath = FolderDialog.SelectedPath;
                if (string.IsNullOrEmpty(slpPath))
                {
                    MessageBox.Show("File is empty");
                    textBoxSlpDir.Text = string.Empty;
                    return;
                }  
                textBoxSlpDir.Text = slpPath;
            }
        }

        private void buttonBrowserDrs_Click(object sender, EventArgs e)
        { 
            FileDialog.Filter = "Drs files (*.drs)|*.drs";
            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                drsPath = FileDialog.FileName;
                if(string.IsNullOrEmpty(drsPath))
                {
                    MessageBox.Show("File is empty");
                    textBoxdrsBrowser.Text = string.Empty;
                    return;
                } 
                textBoxdrsBrowser.Text = drsPath;
            }
        }
        private void removeTextBowModWhenRebrowserGame()
        {
            this.tabControl.Controls["VooblyMods"].Controls.Clear();
        }
        private void removeTextBowModWhenRebrowserGameV2()
        { 
            //this.tabControl.Controls["tabPageSwitchDataMods"].Controls.Clear();
            foreach(Control c in this.tabControl.Controls["tabPageSwitchDataMods"].Controls)
            {
                if (c.Name.Contains("data_mods_"))
                { 
                    this.tabControl.Controls["tabPageSwitchDataMods"].Controls.Remove(c);
                }
            }
        }
        private void browserAoe2_Click(object sender, EventArgs e)
        {
            if (FolderDialog.ShowDialog() == DialogResult.OK)
            {
                Aoe2Path = FolderDialog.SelectedPath; 
            }
            else
            {
                return;
            }
                //clear check box mods 
                this.removeTextBowModWhenRebrowserGame();
            if (tabControl.SelectedIndex == 0)
            {
                VooblyModsPath = Path.Combine(Aoe2Path, "Voobly Mods\\AOC\\Local Mods");
                if (!Directory.Exists(VooblyModsPath))
                {
                    MessageBox.Show(VooblyModsPath + " is missing try again!");
                }
                else
                {
                    List<string> list = Directory.GetDirectories(VooblyModsPath).ToList();
                    int i = 0;
                    foreach (string p in list)
                    {
                        var drsMods = Path.Combine(p, "drs");
                        var ini = Path.Combine(p, "version.ini");
                        if (Directory.Exists(drsMods) && File.Exists(ini))
                        {
                            CheckBox checkBox = new CheckBox();
                            checkBox.Tag = "mods_" + p.Split('\\').Last();
                            checkBox.Name = "mods_" + p.Split('\\').Last();
                            checkBox.Text = p.Split('\\').Last();
                            checkBox.AutoSize = true;
                            checkBox.Location = new Point(10, i * 20);
                            this.tabControl.Controls["VooblyMods"].Controls.Add((Control)checkBox);
                            i++;
                        }
                    }
                }
            }
            if (tabControl.SelectedIndex == 4)
            { 
                //clear check box mods 
                this.removeTextBowModWhenRebrowserGameV2();
                VooblyModsPath = Path.Combine(Aoe2Path, "Voobly Mods\\AOC\\Data Mods");
                if (!Directory.Exists(VooblyModsPath))
                {
                    MessageBox.Show(VooblyModsPath + " is missing try again!");
                }
                else
                {
                    List<string> list = Directory.GetDirectories(VooblyModsPath).ToList();
                    int i = 0;
                    foreach (string p in list)
                    {
                        var drsMods = Path.Combine(p, "drs");
                        var ini = Path.Combine(p, "version.ini");
                        if ( File.Exists(ini))//Directory.Exists(drsMods) &&
                        {
                            RadioButton checkBox = new RadioButton();
                            checkBox.Tag = "data_mods_" + p.Split('\\').Last();
                            checkBox.Name = "data_mods_" + p.Split('\\').Last();
                            checkBox.Text = p.Split('\\').Last();
                            checkBox.AutoSize = true;
                            checkBox.Location = new Point(10, i * 20);
                            this.tabControl.Controls["tabPageSwitchDataMods"].Controls.Add((Control)checkBox);
                            i++;
                        }
                    }
                }
            }
        } 
        private void mergeVooblyMod_Click(object sender, EventArgs e)
        {
            selectedMods = new List<string>();
            if (string.IsNullOrEmpty(this.Aoe2Path))
            {
                MessageBox.Show("Browser Age of Empire II !");
                return;
            }
            else
            {
                if (tabControl.SelectedIndex == 0)
                {
                    foreach (CheckBox control in this.tabControl.Controls["VooblyMods"].Controls)
                    {
                        if (control.GetType() == typeof(CheckBox) && control.Checked)
                            selectedMods.Add(control.Text);
                    }
                    if (this.selectedMods.Count == 0)
                    {
                        MessageBox.Show("Select a voobly mods please!!");
                        return;
                    }
                    else
                    {
                        this.formm.Controls.Clear();
                        VooblyModsPath = Path.Combine(Aoe2Path, "Voobly Mods\\AOC\\Data Mods");
                        List<string> list = Directory.GetDirectories(VooblyModsPath).ToList();
                        int i = 0;
                        foreach (string str in list)
                        {
                            RadioButton radioButton = new RadioButton();
                            radioButton.Tag = str.Split('\\').Last() + i.ToString();
                            radioButton.Text = str.Split('\\').Last();
                            radioButton.AutoSize = true;
                            radioButton.Location = new Point(10, i * 20);
                            this.formm.Controls.Add((Control)radioButton);
                            i++;
                        }
                        RadioButton radioButton1 = new RadioButton();
                        radioButton1.Tag = (object)"Your local Aoe2";
                        radioButton1.Text = "Your local Aoe2";
                        radioButton1.AutoSize = true;
                        radioButton1.Location = new Point(10, i * 20);
                        this.formm.Controls.Add((Control)radioButton1);
                        int num4 = i + 1;
                        Button button = new Button();
                        button.Text = "Merge";
                        button.Name = "Merge";
                        button.Tag = (object)"Merge";
                        button.AutoSize = true;
                        button.Size = new Size(123, 49);
                        int num5 = num4 + 1;
                        button.Location = new Point(10, num5 * 21);
                        button.Click += new EventHandler(this.buttonBrowserdataMod_Click);
                        this.formm.Controls.Add((Control)button);
                        this.formm.StartPosition = FormStartPosition.CenterScreen;
                        this.formm.AutoScroll = true;
                        this.formm.MinimumSize = new Size(400, 400);
                        if (this.formm.ShowDialog() != DialogResult.Cancel)
                            return;
                        this.selectedMods.Clear();
                        this.datamodsSelected.Clear();
                    }
                }
                if (tabControl.SelectedIndex == 4)
                {
                    //research data mod to switch
                    string datamod = string.Empty;
                    foreach (Control control in this.tabControl.Controls["tabPageSwitchDataMods"].Controls)
                    {
                        if (control.GetType() == typeof(RadioButton) && ((RadioButton)control).Checked)
                        {
                            datamod = control.Text;
                        }
                    }
                    if (string.IsNullOrEmpty(datamod))
                    {
                        MessageBox.Show("Select a voobly date mods please!!");
                        return;
                    }
                    string aocPath = Path.Combine(this.Aoe2Path, @"Age2_x1");
                    string gamesPath = Path.Combine(this.Aoe2Path, @"Games");
                    string dataModFolder = Path.Combine(this.Aoe2Path, @"Voobly Mods\AOC\Data Mods");
                    string dataMod = Path.Combine(dataModFolder, datamod);
                    string dataModData = Path.Combine(dataMod, "Data");
                    string languageIni = Path.Combine(dataMod, "language.ini");
                    string languageIniDest = Path.Combine(aocPath, "language.ini");
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //copy civ xml 
                    string civXml = Path.Combine(dataMod, "age2_x1.xml");
                    string civXmlDest = Path.Combine(gamesPath, "age2_x1.xml");
                    if(!Directory.Exists(gamesPath))
                    {
                        Directory.CreateDirectory(gamesPath);
                        return;
                    }
                    configuration age2_x1xml = null;
                    if (!File.Exists(civXml)) 
                    {
                        //MessageBox.Show($"Age2_x1.xml is missing on {datamod}:{Environment.NewLine}{civXml}");
                        //return;
                        age2_x1xml =civilization.defaultAocCivXmlParser();
                    }
                    else
                    {
                        age2_x1xml = civilization.XmlParserCiv(civXml);
                    } 
                    age2_x1xml.path =$@"..\Voobly Mods\AOC\Data Mods\{datamod}";
                    //File.Copy(civXml, civXmlDest, true);

                    civilization.XmlWriter(age2_x1xml, civXmlDest);
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //Language resource
                    if (!File.Exists(languageIni))
                    {
                        MessageBox.Show($"Language ini is missing on {datamod}:{Environment.NewLine}{languageIni}");
                        return;
                    }
                    if (checkBoxLanguageIni.Checked)
                    { 
                        File.Copy(languageIni, languageIniDest ,true); 
                    }
                    else// we compile language dll
                    {
                        if (!File.Exists("rh.exe"))
                        {
                            var rh = Resource1.RH;
                            File.WriteAllBytes("rh.exe", rh);
                        }
                        string langDll = Path.Combine(Aoe2Path, "language.dll");
                        string langDllTmp = langDll.Replace("language.dll", "languageTmp.dll");
                        string langIni = Path.Combine(dataMod, "language.ini");
                        if (File.Exists(langDll))
                        {
                            File.Copy(langDll, langDllTmp,true);
                            //we copy language.dll to get language and we merge with language .ini
                            //we generate .rec
                            Language.compileLanguageRes(langIni, langDllTmp);
                            //we compile language dll
                            Language.compileLanguagedll(langDllTmp, langIni);
                            //we copy language dll to Data folder to allow user patch read language dll
                            string language_x1_p1 = Path.Combine(dataModData, "language_x1_p1.dll");
                            File.Copy(langDllTmp, language_x1_p1,true);
                        }
                        else
                        {
                            MessageBox.Show($"Language.dll is missing on {Environment.NewLine}{gamesPath}"); 
                        }
                    }
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //Drs a lot of voobly mod has only drs folder with slp -> we need  drs compilation to make it offline
                    string slpDataMods = Path.Combine(dataMod, "drs");
                    if (Directory.Exists(slpDataMods))
                    {
                        string drsDataMods = Path.Combine(dataModData, "gamedata_x1_p1.drs");
                        string drsDataModsSVG = Path.Combine(dataModData, "gamedata_x1_p1_Original.drs");
                        if (File.Exists(drsDataMods) && !File.Exists(drsDataModsSVG))
                        {
                            File.Copy(drsDataMods, drsDataModsSVG);
                        }
                        DrsUtilities.mergeFileIntoDrs(slpDataMods, drsDataMods);
                    }
                    MessageBox.Show($"Done.");
                }
            }
        }

        private void buttonBrowserdataMod_Click(object sender, EventArgs e)
        {
            foreach (object control in this.formm.Controls)
            {
                if (control.GetType() == typeof(RadioButton) && ((RadioButton)control).Checked)
                {
                    if (((Control)control).Text == "Your local Aoe2")
                    {
                        this.datamodsSelected.Add(Path.Combine(this.Aoe2Path, "Data"));
                        List<string> list = Directory.GetFiles(this.datamodsSelected.First()).Where(x => x.EndsWith(".drs")).ToList();
                        this.form_ = new Form();
                        int num1 = 0;
                        foreach (string str in list)
                        {
                            RadioButton radioButton = new RadioButton();
                            radioButton.Tag = str.Split('\\').Last() + num1.ToString();
                            radioButton.Text = str.Split('\\').Last();
                            radioButton.AutoSize = true;
                            radioButton.Location = new Point(10, num1 * 20);
                            this.form_.Controls.Add((Control)radioButton);
                            ++num1;
                        }
                        Button button = new Button();
                        button.Text = "Merge";
                        button.Name = "Merge";
                        button.Tag = (object)"Merge";
                        button.AutoSize = true;
                        button.Size = new Size(123, 49);
                        int num2 = num1 + 1;
                        button.Location = new Point(10, num2 * 21); 
                        button.Click += new EventHandler(this.buttonDrsChoice_Click);
                        this.form_.Controls.Add((Control)button); 
                        this.form_.StartPosition = FormStartPosition.CenterScreen;
                        this.form_.MinimumSize = new Size(400, 400);
                        this.form_.AutoScroll = true;
                        if (this.form_.ShowDialog() == DialogResult.OK)
                        {
                            string drsffile = Path.Combine(this.datamodsSelected.First(), this.lstDrsSelected.First());
                            Cursor.Current = Cursors.WaitCursor;
                            Cursor.Current = Cursors.Default;
                            MessageBox.Show("Done.");
                            this.lstDrsSelected.Clear();
                        }
                        this.form_.Dispose();
                    }
                    else
                    {
                        this.datamodsSelected.Add(Path.Combine(Aoe2Path, "Voobly Mods\\AOC\\Data Mods", ((Control)control).Text, "Data"));
                        List<string> list = Directory.GetFiles(this.datamodsSelected.First()).Where(x => x.EndsWith(".drs")).ToList();
                        this.form_ = new Form();
                        int num4 = 0;
                        foreach (string str in list)
                        {
                            RadioButton radioButton = new RadioButton();
                            radioButton.Tag = str.Split('\\').Last() + num4.ToString();
                            radioButton.Text = str.Split('\\').Last();
                            radioButton.AutoSize = true;
                            radioButton.Location = new Point(10, num4 * 20);
                            this.form_.Controls.Add((Control)radioButton);
                            ++num4;
                        }
                        RadioButton radioButton2 = new RadioButton();
                        radioButton2.Tag ="custom";
                        radioButton2.Text = "";
                        radioButton2.AutoSize = true;
                        radioButton2.Location = new Point(10, num4 * 20);
                        this.form_.Controls.Add((Control)radioButton2);
                        TextBox textBox = new TextBox(); 
                        textBox.Text = "curstom.drs";
                        //stextBox.Tag = "curstom.drs";
                        textBox.AutoSize = true;
                        textBox.Location = new Point(10+15, num4 * 20);
                        this.form_.Controls.Add((Control)textBox);
                        //radioButton2.Text= textBox.Text;
                       
                        Button button = new Button();
                        button.Text = "Merge";
                        button.Name = "Merge";
                        button.Tag = (object)"Merge";
                        button.AutoSize = true;
                        button.Size = new Size(123, 49);
                        int num5 = num4 + 1;
                        button.Location = new Point(10, num5 * 21);
                        button.Click += new EventHandler(this.buttonDrsChoice_Click);
                        this.form_.Controls.Add((Control)button);
                        this.form_.StartPosition = FormStartPosition.CenterScreen;
                        this.form_.MinimumSize = new Size(400, 400);
                        this.form_.AutoScroll = true;
                        if (this.form_.ShowDialog() == DialogResult.OK)
                        {
                            lstDrsSelected.Add(textBox.Text);
                            lstDrsSelected= lstDrsSelected.Where(x=>!string.IsNullOrEmpty(x)).ToList();
                            if (lstDrsSelected.Count() > 0)
                            {
                                string drsffile = Path.Combine(this.datamodsSelected.First(), this.lstDrsSelected.First());
                                string saveDrs = drsffile.Replace(".drs", "_Original.drs");
                                if (File.Exists(drsffile)   && !File.Exists(saveDrs))
                                {
                                    File.Copy(drsffile, saveDrs);
                                }
                                Cursor.Current = Cursors.WaitCursor;
                                foreach (var d in selectedMods)
                                {
                                    string dir = Path.Combine(Aoe2Path, "Voobly Mods\\AOC\\Local Mods", d, "drs");
                                    DrsUtilities.mergeFileIntoDrs(dir, drsffile);
                                }
                                Cursor.Current = Cursors.Default;
                                MessageBox.Show("Done.");
                                this.lstDrsSelected.Clear();
                            }
                        }
                        this.form_.Dispose();
                    }
                }
            }
        }

        private void buttonRestoreAsBefore_Click(object sender, EventArgs e)
        {
            foreach (object control in this.formm.Controls)
            {
                if (control.GetType() == typeof(RadioButton) && ((RadioButton)control).Checked)
                {
                    if (((Control)control).Text == "Your local Aoe2")
                    {
                        string dataPath = Path.Combine(Aoe2Path, "Data");
                        foreach(var f in Directory.GetFiles(dataPath).Where(x=>x.EndsWith(".drs")))
                        {
                            if(f.Contains("_Original.drs"))
                            {
                                var drs = f.Replace("_Original", "");
                                File.Copy(f, drs,true);
                            }
                        }
                    }
                    else
                    { 
                        string dataPath = Path.Combine(Aoe2Path, "Voobly Mods\\AOC\\Data Mods", ((Control)control).Text, "Data");
                        foreach (var f in Directory.GetFiles(dataPath).Where(x => x.EndsWith(".drs")))
                        {
                            if (f.Contains("_Original.drs"))
                            {
                                var drs = f.Replace("_Original", "");
                                File.Copy(f, drs, true);
                            }
                        }
                        if (tabControl.SelectedIndex == 4)
                        {
                            string gamesPath = Path.Combine(this.Aoe2Path, @"Games");
                            //we disable data mode connection
                            string civXml = Path.Combine(gamesPath, "age2_x1.xml");
                            if (File.Exists(civXml))
                            {
                                File.Delete(civXml);
                            }
                        }
                    }
                }
            }
            MessageBox.Show("Done.");
        }
        private void buttonDrsChoice_Click(object sender, EventArgs e)
        {
            int num1 = 0;
            foreach (object control in this.form_.Controls)
            {
                if (control.GetType() == typeof(RadioButton) && ((RadioButton)control).Checked)
                {
                    this.lstDrsSelected.Add(((Control)control).Text);
                    ++num1;
                }
            }
            if (num1 == 0)
            {
                MessageBox.Show("Chose a DRS File to merge Voobly mod !!");
            }
            else
                this.form_.DialogResult = DialogResult.OK;
        }
 

        private void buttonMergeSlpIntoDrs_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if(string.IsNullOrEmpty(slpPath))
            {
                MessageBox.Show("Browser a Aoe2 mod folder!");
                return;
            }
            if (string.IsNullOrEmpty(drsPath))
            {
                MessageBox.Show("Browser a Aoe2 drs file!");
                return;
            }
            DrsUtilities.mergeFileIntoDrs(slpPath,drsPath) ;
            Cursor.Current = Cursors.Default;
            MessageBox.Show("Done.");
        }
 
        private void buttonLangDll_Click(object sender, EventArgs e)
        {
            FileDialog.Filter = "Language dll (*.dll)|*.dll";
            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                LanguageDll = FileDialog.FileName;
                if (string.IsNullOrEmpty(LanguageDll))
                {
                    MessageBox.Show("File is empty");
                    textBoxLanguagedll.Text = string.Empty;
                    return;
                }
                textBoxLanguagedll.Text = LanguageDll;
            }
        }

        private void buttonLangIni_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor; 
            //https://www.voobly.com/pages/view/289/Game-Mod-Guide#Language_DLL_to_INI_Conversion_Tool
            if (!File.Exists("langconv.exe"))
            {
                File.WriteAllBytes("langconv.exe", Resource1.langconv);
            }
            // Create a new instance of SaveFileDialog
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // Set properties for the dialog
                saveFileDialog.Filter = "Language ini (*.ini)|*.ini";
                saveFileDialog.Title = "Save your file";
                if(string.IsNullOrEmpty(LanguageDll))
                    saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                else
                    saveFileDialog.InitialDirectory = Path.GetDirectoryName(LanguageDll);// Environment.SpecialFolder.MyDocuments);
                saveFileDialog.DefaultExt = "ini"; // Default extension if user doesn't specify one
                saveFileDialog.AddExtension = true; // Add the default extension if user omits it

                // Show the dialog and check if the user clicked OK
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected file path
                    LanguageIni = saveFileDialog.FileName;

                    try
                    {
                        Language.generateLanguageIni(LanguageIni,LanguageDll);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Save operation cancelled by the user.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            Cursor.Current = Cursors.Default;
            MessageBox.Show("Done.");
        }

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {

            if (e.TabPageIndex == 0 || e.TabPageIndex == 4)
            {
                buttonRestoreMod.Visible = true;
                mergeVooblyMod.Visible = true;
                browserAoe2.Visible = true;
            }
            else
            {
                buttonRestoreMod.Visible = false;
                mergeVooblyMod.Visible = false;
                browserAoe2.Visible = false; 
            }
            if (e.TabPageIndex == 0 )
            {
                mergeVooblyMod.Text = "Merge voobly mod to drs mod";
            }
            if(e.TabPageIndex == 4)
            {
                mergeVooblyMod.Text = "Switch data mod Offline";
                //buttonRestoreMod.Visible = false;
            }
             
            this.BackColor = Color.SteelBlue;
            this.tabPageLanginidll.BackColor = Color.SteelBlue;
        }

        private void buttonRestoreMod_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0|| tabControl.SelectedIndex == 4)
            {
                if (string.IsNullOrEmpty(this.Aoe2Path))
                {
                    MessageBox.Show("Browser Age of Empire II !");
                    return;
                }

                VooblyModsPath = Path.Combine(Aoe2Path, "Voobly Mods\\AOC\\Data Mods");
                List<string> list = Directory.GetDirectories(VooblyModsPath).ToList();
                if(list.Count() == 0 )
                {
                    MessageBox.Show("No Game Data mods to restore !");
                    return;
                }
                int i = 0;
                foreach (string str in list)
                {
                    RadioButton radioButton = new RadioButton();
                    radioButton.Tag = str.Split('\\').Last() + i.ToString();
                    radioButton.Text = str.Split('\\').Last();
                    radioButton.AutoSize = true;
                    radioButton.Location = new Point(10, i * 20);
                    this.formm.Controls.Add((Control)radioButton);
                    i++;
                }
                RadioButton radioButton1 = new RadioButton();
                radioButton1.Tag = (object)"Your local Aoe2";
                radioButton1.Text = "Your local Aoe2";
                radioButton1.AutoSize = true;
                radioButton1.Location = new Point(10, i * 20);
                this.formm.Controls.Add((Control)radioButton1);
                int num4 = i + 1;
                Button button = new Button();
                button.Text = "Restore";
                button.Name = "Restore";
                button.Tag = (object)"Restore";
                button.AutoSize = true;
                button.Size = new Size(123, 49);
                int num5 = num4 + 1;
                button.Location = new Point(10, num5 * 21);
                button.Click += new EventHandler(this.buttonRestoreAsBefore_Click);
                this.formm.Controls.Add((Control)button);
                this.formm.StartPosition = FormStartPosition.CenterScreen;
                this.formm.AutoScroll = true;
                this.formm.MinimumSize = new Size(400, 400);
                if (this.formm.ShowDialog() != DialogResult.Cancel)
                    return;
   
            }
        }

        private void buttonBrowserLangIni_Click(object sender, EventArgs e)
        {
            FileDialog.Filter = "Language ini (*.ini)|*.ini";
            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                LanguageIni = FileDialog.FileName;
                if (string.IsNullOrEmpty(LanguageIni))
                {
                    MessageBox.Show("File is empty");
                    textBoxLangIni.Text = string.Empty;
                    return;
                }
                textBoxLangIni.Text = LanguageIni;
            } 
        }

        private bool readRhLog()
        {
            bool hasAnError= true;
            if (File.Exists("rh.log"))
            {
                string[] logs = File.ReadAllLines("rh.log", Encoding.GetEncoding("iso-8859-1"));
                string txtLog = string.Empty;
                foreach (string l in logs)
                {
                    txtLog += l.Replace("\0", "")+Environment.NewLine;
                    if (l.Replace("\0", "").Contains("Success!"))
                    {
                        hasAnError= false;
                    }
                }
                richTextBoxLogs.Text = txtLog;

            }
            return hasAnError;
        }

        private void buttonSaveLanguageDll_Click(object sender, EventArgs e)
        {
            string cmd = string.Empty;
            Cursor.Current = Cursors.WaitCursor;
            StringBuilder sb = new StringBuilder(); 

            // Create a new instance of SaveFileDialog
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // Set properties for the dialog
                saveFileDialog.Filter = "Language (*.dll)|*.dll";
                saveFileDialog.Title = "Save your file";
                if (string.IsNullOrEmpty(LanguageDll))
                    saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                else
                    saveFileDialog.InitialDirectory = Path.GetDirectoryName(LanguageDll);// Environment.SpecialFolder.MyDocuments);
                saveFileDialog.DefaultExt = "dll"; // Default extension if user doesn't specify one
                saveFileDialog.AddExtension = true; // Add the default extension if user omits it
     
                // Show the dialog and check if the user clicked OK
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected file path
                    LanguageDll = saveFileDialog.FileName;
                    textBoxLangdll.Text = LanguageDll;
                }
                else
                {
                    MessageBox.Show("Save operation cancelled by the user.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cursor.Current = Cursors.Default; 
                    return;
                }
            }
            if (string.IsNullOrEmpty(LanguageIni))
            {
                MessageBox.Show("Browser language ini file .");
                return;
            }

            if (!File.Exists("rh.exe"))
            {
                var rh = Resource1.RH;
                File.WriteAllBytes("rh.exe", rh);
            }
            //compile .rc file into .res file
            Language.compileLanguageRes(LanguageIni, LanguageDll); 
            if(readRhLog())
            {
                Cursor.Current = Cursors.Default;
                this.BackColor = Color.Red;
                this.tabPageLanginidll.BackColor = Color.Red;
                return;
            }
            this.BackColor = Color.SteelBlue;
            this.tabPageLanginidll.BackColor = Color.SteelBlue;

            //compile .res file into language.dll file
            Language.compileLanguagedll(LanguageDll,LanguageIni); 
            if (readRhLog())
            {
                this.BackColor = Color.Red;
                this.tabPageLanginidll.BackColor = Color.Red;
            }

            Cursor.Current = Cursors.Default;
            MessageBox.Show("Done.");
        }

        private void labelUp_Click(object sender, EventArgs e)
        {
            Process.Start("https://userpatch.aiscripters.net/");
        }
    }
}
