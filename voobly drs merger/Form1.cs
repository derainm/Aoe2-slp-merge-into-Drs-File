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
using System.Text;
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

            lstLanguageInfo.Add(new LanguageInfo("LANG_NEUTRAL", 0x00));
            lstLanguageInfo.Add(new LanguageInfo("LANG_ALBANIAN", 0x1c));
            lstLanguageInfo.Add(new LanguageInfo("LANG_ARABIC", 0x01));
            lstLanguageInfo.Add(new LanguageInfo("LANG_ARMENIAN", 0x2b));
            lstLanguageInfo.Add(new LanguageInfo("LANG_AZERI", 0x2c));
            lstLanguageInfo.Add(new LanguageInfo("LANG_BASQUE", 0x2d));
            lstLanguageInfo.Add(new LanguageInfo("LANG_BELARUSIAN", 0x23));
            lstLanguageInfo.Add(new LanguageInfo("LANG_BOSNIAN", 0x1a));
            lstLanguageInfo.Add(new LanguageInfo("LANG_BULGARIAN", 0x02));
            lstLanguageInfo.Add(new LanguageInfo("LANG_CATALAN", 0x03));
            lstLanguageInfo.Add(new LanguageInfo("LANG_CHINESE", 0x04));
            lstLanguageInfo.Add(new LanguageInfo("LANG_CROATIAN", 0x1a));
            lstLanguageInfo.Add(new LanguageInfo("LANG_CZECH", 0x05));
            lstLanguageInfo.Add(new LanguageInfo("LANG_DANISH", 0x06));
            lstLanguageInfo.Add(new LanguageInfo("LANG_DUTCH", 0x13));
            lstLanguageInfo.Add(new LanguageInfo("LANG_ENGLISH", 0x09));
            lstLanguageInfo.Add(new LanguageInfo("LANG_ESTONIAN", 0x25));
            lstLanguageInfo.Add(new LanguageInfo("LANG_FARSI", 0x29));
            lstLanguageInfo.Add(new LanguageInfo("LANG_FINNISH", 0x0b));
            lstLanguageInfo.Add(new LanguageInfo("LANG_FRENCH", 0x0c));
            lstLanguageInfo.Add(new LanguageInfo("LANG_GALICIAN", 0x56));
            lstLanguageInfo.Add(new LanguageInfo("LANG_GEORGIAN", 0x37));
            lstLanguageInfo.Add(new LanguageInfo("LANG_GERMAN", 0x07));
            lstLanguageInfo.Add(new LanguageInfo("LANG_GREEK", 0x08));
            lstLanguageInfo.Add(new LanguageInfo("LANG_HEBREW", 0x0d));
            lstLanguageInfo.Add(new LanguageInfo("LANG_HINDI", 0x39));
            lstLanguageInfo.Add(new LanguageInfo("LANG_HUNGARIAN", 0x0e));
            lstLanguageInfo.Add(new LanguageInfo("LANG_ICELANDIC", 0x0f));
            lstLanguageInfo.Add(new LanguageInfo("LANG_INDONESIAN", 0x21));
            lstLanguageInfo.Add(new LanguageInfo("LANG_ITALIAN", 0x10));
            lstLanguageInfo.Add(new LanguageInfo("LANG_JAPANESE", 0x11));
            lstLanguageInfo.Add(new LanguageInfo("LANG_KOREAN", 0x12));
            lstLanguageInfo.Add(new LanguageInfo("LANG_LATVIAN", 0x26));
            lstLanguageInfo.Add(new LanguageInfo("LANG_LITHUANIAN", 0x27));
            lstLanguageInfo.Add(new LanguageInfo("LANG_MACEDONIAN", 0x2f));
            lstLanguageInfo.Add(new LanguageInfo("LANG_MALAY", 0x3e));
            lstLanguageInfo.Add(new LanguageInfo("LANG_NORWEGIAN", 0x14));
            lstLanguageInfo.Add(new LanguageInfo("LANG_POLISH", 0x15));
            lstLanguageInfo.Add(new LanguageInfo("LANG_PORTUGUESE", 0x16));
            lstLanguageInfo.Add(new LanguageInfo("LANG_ROMANIAN", 0x18));
            lstLanguageInfo.Add(new LanguageInfo("LANG_RUSSIAN", 0x19));
            lstLanguageInfo.Add(new LanguageInfo("LANG_SERBIAN", 0x1a));
            lstLanguageInfo.Add(new LanguageInfo("LANG_SLOVAK", 0x1b));
            lstLanguageInfo.Add(new LanguageInfo("LANG_SLOVENIAN", 0x24));
            lstLanguageInfo.Add(new LanguageInfo("LANG_SPANISH", 0x0a));
            lstLanguageInfo.Add(new LanguageInfo("LANG_SWEDISH", 0x1d));
            lstLanguageInfo.Add(new LanguageInfo("LANG_THAI", 0x1e));
            lstLanguageInfo.Add(new LanguageInfo("LANG_TURKISH", 0x1f));
            lstLanguageInfo.Add(new LanguageInfo("LANG_UKRAINIAN", 0x22));
            lstLanguageInfo.Add(new LanguageInfo("LANG_VIETNAMESE", 0x2a)); 
            comboBoxLanguage.DisplayMember = "Language";
            comboBoxLanguage.ValueMember = "HexValue";  
            comboBoxLanguage.DataSource = lstLanguageInfo;
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
        private void mergeVooblyMod_Click(object sender, EventArgs e)
        {
            selectedMods = new List<string>();
            if (string.IsNullOrEmpty(this.Aoe2Path))
            {
                MessageBox.Show("browser Age of Empire II !");
            }
            else
            {
                foreach (CheckBox control in this.tabControl.Controls["VooblyMods"].Controls)
                {
                    if (control.GetType() == typeof(CheckBox) && control.Checked)
                        selectedMods.Add(control.Text);
                }
                if (this.selectedMods.Count == 0)
                {
                    MessageBox.Show("select a voobly mods please!!");
                }
                else
                {
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
                    button.Name = "validation";
                    button.Tag = (object)"validation";
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
                    if (this.datamodsSelected.Count == 0)
                    {
                        MessageBox.Show("Chose a Data Mods !!!");
                    }
                    else
                    {
                        this.selectedMods.Clear();
                        this.datamodsSelected.Clear();
                    }
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
                MessageBox.Show("chose a DRS File to merge Voobly mod !!");
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
            FileDialog.Filter = "language dll (*.dll)|*.dll";
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
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            // Create a new instance of SaveFileDialog
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // Set properties for the dialog
                saveFileDialog.Filter = "Text Files (*.ini)|*.ini";
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
                        DllResourceExtractor.ExtractAllResources(LanguageDll, LanguageIni);
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
        }

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        { 

            buttonRestoreMod.Visible = e.TabPageIndex == 0;
            mergeVooblyMod.Visible = e.TabPageIndex == 0;
            browserAoe2.Visible = e.TabPageIndex == 0;  
        }

        private void buttonRestoreMod_Click(object sender, EventArgs e)
        {

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

        private void buttonSaveLanguageDll_Click(object sender, EventArgs e)
        {  
            StringBuilder sb = new StringBuilder(); 
            string pathRc = LanguageIni.Replace(".ini", ".rc");
            string pathRes = LanguageIni.Replace(".ini", ".res");

             
            if (string.IsNullOrEmpty(LanguageIni))
            {
                MessageBox.Show("Browser language ini file .");
                return;
            } 
            List<string> lst = File.ReadAllLines(LanguageIni, Encoding.UTF8).ToList();
            if(lst.Count() == 0)
            {
                MessageBox.Show("empty file ."); 
                return;
            }
            sb.AppendLine("STRINGTABLE");
            sb.AppendLine($"LANGUAGE {comboBoxLanguage.SelectedItem}, 1 ");
            sb.AppendLine("{");
            foreach (var l in lst)
            {
                ushort id = 0; 
                string stringvalue = l.Split('=').LastOrDefault();
                if (ushort.TryParse(l.Split('=').First(), out id))
                {
                    //if (id ==19705)
                    //{
                    //    stringvalue = stringvalue.Replace(@"\\", "\\\\");
                    //}
                    //stringvalue = stringvalue.Replace(@"\\", "\\\\");
                    sb.AppendLine($"{id},\"{stringvalue}\"");
                }
            }
            sb.AppendLine("}");
            File.WriteAllText(pathRc, sb.ToString(), Encoding.UTF8);
            sb.Clear(); 
            if(!File.Exists("rh.exe"))
            {
                var rh = Resource1.RH;
                File.WriteAllBytes("rh.exe", rh);
            }
            //rh.exe is https://www.angusj.com/resourcehacker/
            string cmd = $" -open \"{pathRc}\" -save \"{pathRes}\" -action compile -log ";
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = @"rh.exe";
                startInfo.Arguments = cmd;
                startInfo.UseShellExecute = false;

                using (Process process = Process.Start(startInfo))
                {
                    Console.WriteLine($"Executing: rh.exe with arguments: \"{cmd}\"");
                    process.WaitForExit();
                    Console.WriteLine($"Process exited with code: {process.ExitCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }



        }
    }
}
