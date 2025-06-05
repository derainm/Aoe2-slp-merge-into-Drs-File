using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private List<string> selectedMods = new List<string>();
        public Form formm = new Form();
        private Form form_ = new Form();
        private List<string> datamodsSelected = new List<string>();
        private List<string> lstDrsSelected = new List<string>();
        public Form1()
        {
            InitializeComponent(); 
        }

        private void buttonBrowserSlpDir_Click(object sender, EventArgs e)
        {
            if(FileDialog.ShowDialog() == DialogResult.OK)
            {
                drsPath = FileDialog.FileName;
                textBoxSlpDire.Text = drsPath;
            }
        }

        private void buttonBrowserDrs_Click(object sender, EventArgs e)
        {
            if (FolderDialog.ShowDialog(this)==DialogResult.OK)
            {
                slpPath = FolderDialog.SelectedPath;
                textBoxdrsBrowser.Text = slpPath;
            }
        }
        private void removeTextBowModWhenRebrowserGame()
        {
            this.tabControl1.Controls["VooblyMods"].Controls.Clear();
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
                        this.tabControl1.Controls["VooblyMods"].Controls.Add((Control)checkBox);
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
                foreach (CheckBox control in this.tabControl1.Controls["VooblyMods"].Controls)
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
                        int num6 = (int)MessageBox.Show("Chose a Data Mods !!!");
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
                        List<string> list = ((IEnumerable<string>)Directory.GetFiles(this.datamodsSelected.First<string>())).Where<string>((Func<string, bool>)(x => x.EndsWith(".drs"))).ToList<string>();
                        this.form_ = new Form();
                        int num1 = 0;
                        foreach (string str in list)
                        {
                            RadioButton radioButton = new RadioButton();
                            radioButton.Tag = (object)(((IEnumerable<string>)str.Split('\\')).Last<string>() + num1.ToString());
                            radioButton.Text = ((IEnumerable<string>)str.Split('\\')).Last<string>();
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
                        //CheckBox checkBox = new CheckBox();
                        //checkBox.Text = "is Only Update slp";
                        //checkBox.Name = "isOnlyUpdatechb";
                        //checkBox.Tag = (object)"validation";
                        //checkBox.Location = new Point(210, num2 * 21);
                        button.Click += new EventHandler(this.buttonDrsChoice_Click);
                        this.form_.Controls.Add((Control)button);
                        //this.form_.Controls.Add((Control)checkBox);
                        this.form_.StartPosition = FormStartPosition.CenterScreen;
                        this.form_.MinimumSize = new Size(400, 400);
                        this.form_.AutoScroll = true;
                        if (this.form_.ShowDialog() == DialogResult.OK)
                        {
                            string drsffile = Path.Combine(this.datamodsSelected.First<string>(), this.lstDrsSelected.First<string>());
                            Cursor.Current = Cursors.WaitCursor;
                            ////foreach (string selectdMod in this.selectedMods)
                            ////    this.mergeVooblymodsToDataGame(Path.Combine(Aoe2Path, "Voobly Mods\\AOC\\Local Mods", selectdMod, "drs"), drsffile, checkBox.Checked);
                            Cursor.Current = Cursors.Default;
                            int num3 = (int)MessageBox.Show("Done.");
                            this.lstDrsSelected.Clear();
                        }
                        this.form_.Dispose();
                    }
                    else
                    {
                        this.datamodsSelected.Add(Path.Combine(Aoe2Path, "Voobly Mods\\AOC\\Data Mods", ((Control)control).Text, "Data"));
                        List<string> list = ((IEnumerable<string>)Directory.GetFiles(this.datamodsSelected.First<string>())).Where<string>((Func<string, bool>)(x => x.EndsWith(".drs"))).ToList<string>();
                        this.form_ = new Form();
                        int num4 = 0;
                        foreach (string str in list)
                        {
                            RadioButton radioButton = new RadioButton();
                            radioButton.Tag = (object)(((IEnumerable<string>)str.Split('\\')).Last<string>() + num4.ToString());
                            radioButton.Text = ((IEnumerable<string>)str.Split('\\')).Last<string>();
                            radioButton.AutoSize = true;
                            radioButton.Location = new Point(10, num4 * 20);
                            this.form_.Controls.Add((Control)radioButton);
                            ++num4;
                        }
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
                            string drsffile = Path.Combine(this.datamodsSelected.First<string>(), this.lstDrsSelected.First<string>());
                            string saveDrs = drsffile.Replace(".drs", "_Original.drs");
                            if (!File.Exists(saveDrs))
                            {
                                File.Copy(drsffile, saveDrs);
                            }
                            Cursor.Current = Cursors.WaitCursor;
                            foreach(var d in selectedMods)
                            {
                                string dir = Path.Combine(Aoe2Path, "Voobly Mods\\AOC\\Local Mods", d, "drs");
                                DrsUtilities.mergeFileIntoDrs(dir, drsffile);
                            }
                            Cursor.Current = Cursors.Default;
                            int num6 = (int)MessageBox.Show("Done.");
                            this.lstDrsSelected.Clear();
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
                int num2 = (int)MessageBox.Show("chose a DRS File to merge Voobly mod !!");
            }
            else
                this.form_.DialogResult = DialogResult.OK;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
