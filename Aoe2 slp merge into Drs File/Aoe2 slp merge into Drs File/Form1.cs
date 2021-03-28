using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Aoe2_slp_merge_into_Drs_File
{
    public partial class Form1 : Form
    {
        private string fileName;
        private string filePath;
        private List<string> lstLang;
        public Form1()
        {
            InitializeComponent();
        }
        private static DrsTable[] GetDrsTable(string newDrsName)
        {
            List<DrsItem> lstitems = new List<DrsItem>();
            DrsTable[] drsTableArray;
            //List<DrsItem> lstItem = new List<DrsItem>();
            var idToPick = new List<uint>();

            using (FileStream fileStream1 = new FileStream(newDrsName, FileMode.Open, FileAccess.Read, FileShare.Read, 1048576, FileOptions.SequentialScan))
            {
                BinaryReader binaryReader = new BinaryReader(fileStream1);
                bool flag = false;
                while (true)
                {
                    byte num = binaryReader.ReadByte();
                    //binaryWriter.Write(num);
                    if (num == (byte)26)
                        flag = true;
                    else if (num > (byte)0 & flag)
                        break;
                }
                binaryReader.ReadBytes(3);
                binaryReader.ReadBytes(12);
                uint num1 = binaryReader.ReadUInt32();
                uint num2 = binaryReader.ReadUInt32();

                drsTableArray = new DrsTable[(int)num1];
                for (int index = 0; (long)index < (long)num1; ++index)
                    drsTableArray[index] = new DrsTable();
                foreach (DrsTable drsTable in drsTableArray)
                {
                    drsTable.Type = binaryReader.ReadUInt32();
                    drsTable.Start = binaryReader.ReadUInt32();
                    uint num3 = binaryReader.ReadUInt32();
                    DrsItem[] drsItemArray = new DrsItem[(int)num3];
                    for (int index = 0; (long)index < (long)num3; ++index)
                        drsItemArray[index] = new DrsItem();
                    drsTable.Items = (IEnumerable<DrsItem>)drsItemArray;
                }
                foreach (DrsTable drsTable in drsTableArray)
                {
                    //Trace.Assert(fileStream1.Position == (long)drsTable.Start);
                    foreach (DrsItem drsItem in drsTable.Items)
                    {
                        drsItem.Id = binaryReader.ReadUInt32();
                        drsItem.Start = binaryReader.ReadUInt32();
                        drsItem.Size = binaryReader.ReadUInt32();
                    }
                }
                foreach (DrsItem drsItem in ((IEnumerable<DrsTable>)drsTableArray).SelectMany<DrsTable, DrsItem>((Func<DrsTable, IEnumerable<DrsItem>>)(table => table.Items)))
                {
                    //Trace.Assert(fileStream1.Position == (long)drsItem.Start);
                    drsItem.Data = binaryReader.ReadBytes((int)drsItem.Size);
                }
                //lstItem = drsTableArray.Where(w => w.Type == 1936486432).First().Items.ToList();
                binaryReader.Close();

                return drsTableArray;
            }

        }
        private static bool uploadSlpToDrs(string _orgDrsPath, string newDrsName, DrsTable[] drsTableArray)
        {
            using (FileStream fileStream1 = new FileStream(_orgDrsPath, FileMode.Open))
            {

                BinaryReader binaryReader = new BinaryReader(fileStream1);
                using (FileStream fileStream2 = new FileStream(newDrsName, FileMode.Create))
                {
                    bool flag = false;
                    BinaryWriter binaryWriter = new BinaryWriter(fileStream2);
                    while (true)
                    {
                        byte num = binaryReader.ReadByte();
                        binaryWriter.Write(num);
                        if (num == (byte)26)
                            flag = true;
                        else if (num > (byte)0 & flag)
                            break;
                    }
                    binaryWriter.Write(binaryReader.ReadBytes(3));
                    binaryWriter.Write(binaryReader.ReadBytes(12));
                    uint num1 = binaryReader.ReadUInt32();
                    binaryWriter.Write(num1);
                    uint num2 = binaryReader.ReadUInt32();
                    binaryWriter.Write(num2);
                    binaryReader.Close();
                    uint num4 = num2;
                    List<DrsTable> source = new List<DrsTable>();// new List<DrsTable>(drsTableArray.Length);
                    //update possitions
                    foreach (DrsTable drsTable1 in drsTableArray)
                    {
                        List<DrsItem> drsItemList = new List<DrsItem>();
                        DrsTable drsTable2 = new DrsTable()
                        {
                            Start = drsTable1.Start,
                            Type = drsTable1.Type,
                            Items = (IEnumerable<DrsItem>)drsItemList
                        };
                        foreach (DrsItem drsItem1 in drsTable1.Items)
                        {
                            DrsItem drsItem2 = new DrsItem()
                            {
                                Id = drsItem1.Id,
                                Start = num4,
                                Data = drsItem1.Data
                            };
                            drsItem2.Size = (uint)drsItem2.Data.Length;
                            num4 += drsItem2.Size;
                            drsItemList.Add(drsItem2);
                        }
                        source.Add(drsTable2);
                    }
                    foreach (DrsTable drsTable in source)
                    {
                        binaryWriter.Write(drsTable.Type);
                        binaryWriter.Write(drsTable.Start);
                        binaryWriter.Write(drsTable.Items.Count<DrsItem>());
                    }
                    foreach (DrsTable drsTable in source)
                    {
                        foreach (DrsItem drsItem in drsTable.Items)
                        {
                            binaryWriter.Write(drsItem.Id);
                            binaryWriter.Write(drsItem.Start);
                            binaryWriter.Write(drsItem.Size);
                        }
                    }
                    foreach (DrsItem drsItem in source.SelectMany<DrsTable, DrsItem>((Func<DrsTable, IEnumerable<DrsItem>>)(outTable => outTable.Items)))
                    {
                        binaryWriter.Write(drsItem.Data);
                    }
                    binaryWriter.Close();
                    fileStream2.Close();
                }
                fileStream1.Close();
            }
            return true;
        }
        private static void SlpWrite(string workingDir, string fileName)
        {
            bool transmask = true;
            bool outline1 = false;
            bool outline2 = false;
            bool plcolor = false;
            bool shadowpix = false;
            #region write slp
            slpWriter slpw = new slpWriter();
            slpw.maskfile = Path.Combine(workingDir, "mask.bmp");
            int numframes = 1;
            byte b;
            int i;
            String outputname = Path.Combine(workingDir, fileName + ".slp");
            slpw.initframes(numframes);
            string Mosaicfile = "\\" + fileName + ".bmp";
            slpw.getframe(0, workingDir, Mosaicfile, transmask, outline1, outline2, plcolor, shadowpix);
            slpw.compress();
            slpw.Write(outputname);
            #endregion
        }
        private static Bitmap slpToBmp(string SlpFileName)
        {
            #region slp export to bmp
            slpReader slpname = new slpReader();
            String workingDir = Directory.GetCurrentDirectory(); //Path.GetDirectoryName(SlpFileName);
            if (!workingDir.EndsWith("\\"))
                workingDir += "\\";
            string fi = Path.GetFileName(SlpFileName);
            Console.WriteLine("Extracting frames from " + fi + "...");
            slpname.sample = fi.Equals("int50101.slp") ? "50532.bmp" : "50500.bmp";
            Console.WriteLine(fi + " " + slpname.sample);
            slpname.name = fi.Split('.').First();
            slpname.Read(SlpFileName);
            slpname.save(workingDir);
            var fileName = Path.GetDirectoryName(SlpFileName) + $@"{slpname.name}.bmp";

            Bitmap bmp = (Bitmap)Bitmap.FromFile(fileName);
            #endregion
            return bmp;
        }
        private static DrsTable[] getDrsTable(string newDrsName)
        {
            List<DrsItem> lstitems = new List<DrsItem>();
            DrsTable[] drsTableArray;
            //List<DrsItem> lstItem = new List<DrsItem>();
            var idToPick = new List<uint>();

            using (FileStream fileStream1 = new FileStream(newDrsName, FileMode.Open, FileAccess.Read, FileShare.Read, 1048576, FileOptions.SequentialScan))
            {
                BinaryReader binaryReader = new BinaryReader(fileStream1);
                bool flag = false;
                while (true)
                {
                    byte num = binaryReader.ReadByte();
                    //binaryWriter.Write(num);
                    if (num == (byte)26)
                        flag = true;
                    else if (num > (byte)0 & flag)
                        break;
                }
                binaryReader.ReadBytes(3);
                binaryReader.ReadBytes(12);
                uint num1 = binaryReader.ReadUInt32();
                uint num2 = binaryReader.ReadUInt32();

                drsTableArray = new DrsTable[(int)num1];
                for (int index = 0; (long)index < (long)num1; ++index)
                    drsTableArray[index] = new DrsTable();
                foreach (DrsTable drsTable in drsTableArray)
                {
                    drsTable.Type = binaryReader.ReadUInt32();
                    drsTable.Start = binaryReader.ReadUInt32();
                    uint num3 = binaryReader.ReadUInt32();
                    DrsItem[] drsItemArray = new DrsItem[(int)num3];
                    for (int index = 0; (long)index < (long)num3; ++index)
                        drsItemArray[index] = new DrsItem();
                    drsTable.Items = (IEnumerable<DrsItem>)drsItemArray;
                }
                foreach (DrsTable drsTable in drsTableArray)
                {
                    //Trace.Assert(fileStream1.Position == (long)drsTable.Start);
                    foreach (DrsItem drsItem in drsTable.Items)
                    {
                        drsItem.Id = binaryReader.ReadUInt32();
                        drsItem.Start = binaryReader.ReadUInt32();
                        drsItem.Size = binaryReader.ReadUInt32();
                    }
                }
                foreach (DrsItem drsItem in ((IEnumerable<DrsTable>)drsTableArray).SelectMany<DrsTable, DrsItem>((Func<DrsTable, IEnumerable<DrsItem>>)(table => table.Items)))
                {
                    //Trace.Assert(fileStream1.Position == (long)drsItem.Start);
                    drsItem.Data = binaryReader.ReadBytes((int)drsItem.Size);
                }
                //lstItem = drsTableArray.Where(w => w.Type == 1936486432).First().Items.ToList();
                binaryReader.Close();

                return drsTableArray;
            }

        }
        private uint getfirstStartDrs(List<DrsTable> lstDrsTable)
        {
            uint res = 0;
            uint precStart = 0;
            uint result = 0;
            uint itemCount = 0;
            uint countallItem = 0;
            uint firstStart = 0;
            DrsTable precDrsTable = new DrsTable();

            foreach (DrsTable drsTable in lstDrsTable)
            {

                if (precStart == 0)
                {
                    firstStart = drsTable.Start;
                }
                else
                {
                    itemCount = (uint)precDrsTable.Items.Count<DrsItem>();
                    result = (uint)itemCount * 12 + precStart;

                }
                uint count = (uint)drsTable.Items.Count<DrsItem>();
                countallItem += count;
                precStart = drsTable.Start;
                precDrsTable = drsTable;
            }
            res = (uint)12 * countallItem + firstStart;
            return res;
        }
        private void saveDrsFromLis(string drsPathFile, string newDrsFile, List<DrsTable> lstDrsTable)
        {


            using (FileStream fileStream1 = new FileStream(drsPathFile, FileMode.Open))
            {

                BinaryReader binaryReader = new BinaryReader(fileStream1);
                using (FileStream fileStream2 = new FileStream(newDrsFile, FileMode.Create))
                {
                    bool flag = false;
                    BinaryWriter binaryWriter = new BinaryWriter(fileStream2);
                    string res = string.Empty;
                    while (true)
                    {
                        byte num = binaryReader.ReadByte();
                        binaryWriter.Write(num);
                        res += num;
                        if (num == (byte)26)
                            flag = true;
                        else if (num > (byte)0 & flag)
                            break;
                    }
                    var tb = binaryReader.ReadBytes(3);
                    binaryWriter.Write(tb);
                    var db = binaryReader.ReadBytes(12);
                    binaryWriter.Write(db);
                    //nb of type exemple :3 slp bina way
                    uint num1 = binaryReader.ReadUInt32();
                    binaryWriter.Write(num1);
                    //first start position drs item
                    uint num2 = binaryReader.ReadUInt32();
                    uint nume2_ = getfirstStartDrs(lstDrsTable);
                    binaryWriter.Write(nume2_);
                    //binaryWriter.Write(num2);

                    uint num4 = nume2_;
                    //uint num4 = num2;
                    List<DrsTable> source = new List<DrsTable>();
                    uint id;
                    //need update number of item
                    //uint num3 = 0;

                    //update possitions
                    foreach (DrsTable drsTable1 in lstDrsTable)
                    {

                        List<DrsItem> drsItemList = new List<DrsItem>();
                        DrsTable drsTable2 = new DrsTable()
                        {
                            Start = drsTable1.Start,
                            Type = drsTable1.Type,
                            Items = (IEnumerable<DrsItem>)drsItemList
                        };
                        foreach (DrsItem drsItem1 in drsTable1.Items)
                        {
                            DrsItem drsItem2 = new DrsItem()
                            {
                                Id = drsItem1.Id,
                                Start = num4,
                                Data = drsItem1.Data
                            };
                            drsItem2.Size = (uint)drsItem2.Data.Length;
                            num4 += drsItem2.Size;
                            drsItemList.Add(drsItem2);
                        }
                        source.Add(drsTable2);
                    }
                    //binaryWriter.Write(num3);
                    binaryReader.Close();
                    //start 100
                    //126*1512  //126 = item cout
                    //1512+100 =1612
                    //224*12 =2688‬   //224 = item count
                    //2688+1612 = 4300‬
                    uint precStart = 0;
                    uint result = 0;
                    uint itemCount = 0;
                    uint countallItem = 0;
                    uint firstStart = 0;
                    DrsTable precDrsTable = new DrsTable();
                    foreach (DrsTable drsTable in source)
                    {
                        binaryWriter.Write(drsTable.Type);
                        if (precStart == 0)
                        {
                            binaryWriter.Write(drsTable.Start);
                            firstStart = drsTable.Start;
                        }
                        else
                        {
                            itemCount = (uint)precDrsTable.Items.Count<DrsItem>();
                            result = (uint)itemCount * 12 + precStart;
                            binaryWriter.Write(result);
                        }
                        uint count = (uint)drsTable.Items.Count<DrsItem>();
                        binaryWriter.Write(count);
                        countallItem += count;
                        precStart = drsTable.Start;
                        precDrsTable = drsTable;
                    }
                    precStart = 0;
                    uint num_ = num2;
                    //4264 221
                    //4864
                    //+3 SLP+> 4900
                    //4888
                    //4900 -4888 + 12
                    //conclusion num2 = 12*(126+223+50) = 4 788‬ +100

                    num_ = (uint)12 * countallItem + firstStart;
                    foreach (DrsTable drsTable in source)
                    {
                        foreach (DrsItem drsItem in drsTable.Items)
                        {
                            binaryWriter.Write(drsItem.Id);
                            binaryWriter.Write(drsItem.Start);
                            binaryWriter.Write(drsItem.Size);
                        }
                    }
                    foreach (DrsItem drsItem in source.SelectMany<DrsTable, DrsItem>((Func<DrsTable, IEnumerable<DrsItem>>)(outTable => outTable.Items)))
                    {
                        binaryWriter.Write(drsItem.Data);
                    }
                    binaryWriter.Close();
                    fileStream2.Close();
                }
                fileStream1.Close();
            }
        }
        enum drstype
        {
            slp = 1936486432,
            wav = 2002875936,
            bina = 1651076705
        };
        uint sl = 1936486432U;
        private string directorySlp = string.Empty;
        private string drsFile = string.Empty;
        private string newdrsFile = string.Empty;
        private List<string> lstFiles = new List<string>();
        private void buttonBrowserDrs_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                string[] files = Directory.GetFiles(fbd.SelectedPath);
                lstFiles = new List<string>(files);
            }
        }

        private void buttonBrowserSlpDir_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.ShowDialog();
            drsFile = fd.FileName;
            newdrsFile = drsFile.Replace(".drs", "tmp.drs");
        }

        private void buttonMergeSlpIntoDrs_Click(object sender, EventArgs e)
        {
            //convert drs file to drs table
            DrsTable[] drsTable = getDrsTable(drsFile);
            List<DrsTable> lstdrsTable = new List<DrsTable>(drsTable);
            IList<DrsItem> lstSlpDrsItem = lstdrsTable.Where(x => x.Type == (uint)drstype.slp).First().Items.ToList();
            IList<DrsItem> lstSlpDrsItemWay = lstdrsTable.Where(x => x.Type == (uint)drstype.wav).First().Items.ToList();
            List<uint> idToPick = new List<uint>();
            //get slp id to upload in drs
            foreach (var el in lstFiles)
            {
                FileInfo fi = new FileInfo(el);
                if (fi.Extension.ToLower().Trim() == ".slp")
                {
                    uint id = uint.Parse(fi.Name.Replace(".slp", ""));
                    idToPick.Add(id);
                    var data = File.ReadAllBytes(el);
                    var lastDrsItem = lstSlpDrsItem.OrderByDescending(x => x.Id).First();
                    //var preccItem = lstDrsItem.ElementAt(lstDrsItem.Count-2);
                    ////56616688+238= 56616926
                    ////56616926
                    //uint precDrsItem = preccItem.Start+ preccItem.Size;
                    uint LastId = lastDrsItem.Id;
                    uint lastStartPos = (uint)lastDrsItem.Start + (uint)lastDrsItem.Size;
                    lstSlpDrsItem.Add(new DrsItem()
                    {
                        Id = id,
                        Data = data,
                        Size = (uint)data.Length,
                        Start = (uint)lastStartPos
                    }
                    );
                }

                if (fi.Extension.ToLower().Trim() == ".wav")
                {
                    uint id = uint.Parse(fi.Name.Replace(".wav", ""));
                    idToPick.Add(id);
                    var data = File.ReadAllBytes(el);
                    var lastDrsItem = lstSlpDrsItemWay.OrderByDescending(x => x.Id).First();
                    //var preccItem = lstDrsItem.ElementAt(lstDrsItem.Count-2);
                    ////56616688+238= 56616926
                    ////56616926
                    //uint precDrsItem = preccItem.Start+ preccItem.Size;
                    uint LastId = lastDrsItem.Id;
                    uint lastStartPos = (uint)lastDrsItem.Start + (uint)lastDrsItem.Size;
                    lstSlpDrsItemWay.Add(new DrsItem()
                    {
                        Id = id,
                        Data = data,
                        Size = (uint)data.Length,
                        Start = (uint)lastStartPos
                    }
                    );
                }
            }

            lstdrsTable.Where(x => x.Type == (uint)drstype.slp).First().Items = lstSlpDrsItem;
            lstdrsTable.Where(x => x.Type == (uint)drstype.wav).First().Items = lstSlpDrsItemWay;

            saveDrsFromLis(drsFile, newdrsFile, lstdrsTable.ToList());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonBrowserLanguageDll_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Filter = "txt files (*.ini)|txt files (*.ini)";
            ofd.ShowDialog();
            fileName = ofd.FileName;

            string[] arraLang = File.ReadAllLines(fileName, System.Text.Encoding.GetEncoding("iso-8859-1"));
            lstLang = new List<string>(arraLang);
        }

        private void buttonUpdateLanguage_Click(object sender, EventArgs e)
        {
            if (File.Exists("RH.exe"))
                File.Delete("RH.exe");
            if (!File.Exists("RH.exe"))
                File.WriteAllBytes("RH.exe", Properties.Resources.RH);
            List<string> newFilelst = new List<string>();
            string langContent = string.Empty;
            newFilelst.Add("STRINGTABLE");
            
            //read language dll language example LANGUAGE LANG_ENGLISH, SUBLANG_ENGLISH_US
            System.Diagnostics.Process.Start("RH.exe", "-open \"" + languageDllPath + "\"  -save lang.rc  -action extract -mask STRINGTABLE,,").WaitForExit();
            var fileLang =File.ReadAllLines("lang.rc");
            string language = fileLang.ElementAt(1);
            newFilelst.Add(language);
            newFilelst.Add("{");
            var regex = new Regex(Regex.Escape("="));
            
            foreach (var el in lstLang)
            {
                if ( !el.Contains("=")|| el == Environment.NewLine)
                    continue;
                langContent = el;
                if (el.Contains("="))
                {
                    langContent = regex.Replace(langContent, ", 	\"", 1);
                    //langContent = langContent.Replace("=", ", 	\"");
                }
                langContent += "\" ";
                newFilelst.Add(langContent);
            }
            newFilelst.Add("}");
            string dir = fileName;
            DirectoryInfo di = new DirectoryInfo(fileName);
            string d = di.Name;
            string f = fileName.Replace(d, "");
            string newPathFile = Path.Combine(f, "res.ini");
            //File.WriteAllLines(newPathFile, newFilelst, Encoding.UTF8);
            File.WriteAllLines("res.rc", newFilelst, Encoding.UTF8);




            //rh.exe -open resources.rc -save resources.res -action compile -log NUL
            System.Diagnostics.Process.Start("RH.exe", " -open res.rc -save resources.res -action compile ").WaitForExit();
            
            
            StringBuilder strmyScript = new StringBuilder();

            //comments are preceded by double slashes
            //[FILENAMES]
            //Open=language_x1_p1.dll
            //Save=language_x1_p1.dll
            //Log=
            //[COMMANDS]
            ////one or more of the following commands ...
            //-addoverwrite resss.res , STRINGTABLE,,

            strmyScript.AppendLine("[FILENAMES]");
            strmyScript.AppendLine("Open="+ "\"" + languageDllPath + "\"");
            strmyScript.AppendLine("Save="+ "\"" + languageDllPath + "\"");
            strmyScript.AppendLine("[COMMANDS]");
            strmyScript.AppendLine("-addoverwrite resources.res , STRINGTABLE,,");
            File.WriteAllText("myscript.txt", strmyScript.ToString());


            System.Diagnostics.Process.Start("RH.exe", " -script myscript.txt").WaitForExit();
            //RH.exe -script myscript.txt
        }

        private void buttonBrowserLanguageIni_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "language txt file (*.ini)|*.ini";
            ofd.ShowDialog();
            fileName = ofd.FileName;

            string[] arraLang = File.ReadAllLines(fileName, System.Text.Encoding.GetEncoding("iso-8859-1"));
            lstLang = new List<string>(arraLang);
        }
        string languageDllPath = string.Empty;
        private void buttonBrowserLanguageDll_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Language dll file (*.dll)|*.dll";
            ofd.ShowDialog();
            languageDllPath = ofd.FileName;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "language txt file (*.dll)|*.dll";
            ofd.ShowDialog();
            fileName = ofd.FileName;


        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (File.Exists("langconv.exe"))
                File.Delete("langconv.exe");
            if (!File.Exists("langconv.exe"))
                File.WriteAllBytes("langconv.exe", Properties.Resources.langconv);

            FileInfo fi = new FileInfo(fileName);
            String MylanguageIni = Path.Combine(fi.Directory.FullName, "game_default_language.ini");

            System.Diagnostics.Process.Start("langconv.exe", " -d  \"" + MylanguageIni + "\" \"" + fileName+ "\"").WaitForExit();

            
        }
    }
}

