using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Reflection;

namespace voobly_drs_merger
{
    public class DrsHeaderFile
    {
        public string copy_right;    //40
        public string version;       //4
        public string file_type;     //12
        public uint DrsTable_length; //4
        public int eof;              //4  num2;    
    }

    public class DrsFile
    {
        public DrsHeaderFile headerFile;
        public List<DrsTable> listDrsTable;
    }
    public class DrsTable
    {
        public uint Type;
        public uint Start;
        public IEnumerable<DrsItem> Items;
    }
    public class DrsItem
    {
        public uint Id;
        public uint Start;
        public uint Size;
        public byte[] Data;
    }
    public enum drstype
    {
        slp = 1936486432, // 0x736C7020    " pls"  slp 
        wav = 2002875936, // 0x77617620    " vaw"
        bina = 1651076705, // 0x62696E61   "anib"  bina
    }
    public static class DrsUtilities
    {
        public static string getSlpTableHeader()
        {
            return " pls";
        }
        public static string getBinaryTableHeader()
        {
            return "anib";
        }
        public static string getSoundTableHeader()
        {
            return " vaw";
        }
 
        public static uint getEofDrs(List<DrsTable> lstDrsTable)
        {
            DrsTable first = lstDrsTable.First();
            uint c = 0;
            foreach (DrsTable d in lstDrsTable)
            {
                c += (uint)d.Items.Count();
            }
            return c*12 + first.Start;
        }

        public static uint firstDrsTable(List<DrsTable> lstDrsTable)
        {
            uint DrsTableCount = (uint)lstDrsTable.Count();
            //header size
            //64 :  40 (0x28 copyright) +  4 (version) + 12 (File type) + 4 (DrsTable_length) + 4 (num2)
            //if you want star war drs add 0c2c instead of 0x28
            return DrsTableCount*12 + 64;
        }

 
        public static bool isVoolbyCodedSlp(string filePath)
        {
            bool res = false;
            FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            res = fileStream.ReadUInt32() ==0xBEEF1337;// 3203339063U;
            fileStream.Close();
            return res;
        }
        public static byte[] DecodeVooblySLP(string pathFile )
        {
            //https://github.com/withmorten/vooblyslpdecode
            /*
              uchar *fslp;
                uint beef1337;
                int fsize, i;
                FILE *f;
    
                if(argc < 3) {
                    fprintf(stderr, "usage: vooblyslpdecode slp_in.slp slp_out.slp\n");
                    return 1;
                }
    
                f = fopen_f(argv[1], "rb");
                fread(&beef1337, 1, 4, f);
    
                if(beef1337 != 0xBEEF1337) {
                    fprintf(stderr, "error: not a voobly encoded slp file\n");
                    return 1;
                }
    
                fseek(f, 0, SEEK_END);
                fsize = ftell(f) - 4;
                fseek(f, 4, SEEK_SET);
    
                fslp = malloc(fsize);
                fread(fslp, 1, fsize, f);
                fclose(f);
    
                for(i = 0; i < fsize; i++)
                    fslp[i] = 0x20 * ((fslp[i] - 17) ^ 0x23) | ((uchar)((fslp[i] - 17) ^ 0x23) >> 3);
    
                f = fopen_f(argv[2], "wb");
                fwrite(fslp, 1, fsize, f);
                fclose(f);
             */
            byte[] decodedBytes = null;
            using (FileStream fs = new FileStream(pathFile, FileMode.Open, FileAccess.Read))
            using (BinaryReader br = new BinaryReader(fs))
            { 
                uint beef1337 = br.ReadUInt32(); 
                if (beef1337 != 0xBEEF1337)
                {
                    return null;
                } 
                int fsize = (int)(fs.Length - 4);
                if (fsize < 0) fsize = 0; 
                byte[] fslp = br.ReadBytes(fsize);  
                for (int i = 0; i < fsize; i++)
                {
                    // Original C code: fslp[i] = 0x20 * ((fslp[i] - 17) ^ 0x23) | ((uchar)((fslp[i] - 17) ^ 0x23) >> 3);
                    byte intermediate = (byte)((fslp[i] - 17) ^ 0x23);
                    fslp[i] = (byte)(0x20 * intermediate | (intermediate >> 3));
                }
                decodedBytes  =fslp;
            } 
            return decodedBytes;
        } 

        /// <summary>
        /// Parse drs file into DrsTable object
        /// </summary>
        /// <param name="pathDrs">Path of drs file</param>
        /// <returns></returns>
        public static List<DrsTable> getDrsTable(string pathDrs)
        {
            List<DrsItem> drsItemList = new List<DrsItem>();
            List<uint> uintList = new List<uint>();
            using (FileStream input = new FileStream(pathDrs, FileMode.Open))//, FileAccess.Read, FileShare.Read, 1048576 /*0x100000*/, FileOptions.SequentialScan))
            {
                BinaryReader binaryReader = new BinaryReader(input);
                string copy_right = System.Text.Encoding.Default.GetString(binaryReader.ReadBytes(0x28));
                string version = System.Text.Encoding.Default.GetString(binaryReader.ReadBytes(4));
                string file_type = System.Text.Encoding.Default.GetString(binaryReader.ReadBytes(12)); //File type
                uint DrsTable_length = binaryReader.ReadUInt32();
                int num2 = (int)binaryReader.ReadUInt32();
                DrsTable[] source = new DrsTable[DrsTable_length];
                for (int index = 0; index < DrsTable_length; ++index)
                {
                    source[index] = new DrsTable();
                }
                foreach (DrsTable drsTable in source)
                {
                    drsTable.Type = binaryReader.ReadUInt32();
                    drsTable.Start = binaryReader.ReadUInt32();
                    uint DrsItem_length = binaryReader.ReadUInt32();
                    DrsItem[] drsItemArray = new DrsItem[(int)DrsItem_length];
                    for (int index = 0; index < DrsItem_length; ++index)
                        drsItemArray[index] = new DrsItem();
                    drsTable.Items = drsItemArray;
                }
                foreach (DrsTable drsTable in source)
                {
                    foreach (DrsItem drsItem in drsTable.Items)
                    {
                        drsItem.Id = binaryReader.ReadUInt32();
                        drsItem.Start = binaryReader.ReadUInt32();
                        drsItem.Size = binaryReader.ReadUInt32();
                    }
                }
                foreach (DrsItem drsItem in source.SelectMany(table => table.Items))
                {
                    drsItem.Data = binaryReader.ReadBytes((int)drsItem.Size);
                }
                binaryReader.Close();
                return new List<DrsTable>(source);
            }
        }
        public static DrsFile parseToDrsClass(string pathDrs)
        {
            List<DrsItem> drsItemList = new List<DrsItem>();
            List<uint> uintList = new List<uint>();
            DrsFile drs = new DrsFile();
            using (FileStream input = new FileStream(pathDrs, FileMode.Open))//, FileAccess.Read, FileShare.Read, 1048576 /*0x100000*/, FileOptions.SequentialScan))
            {
                BinaryReader binaryReader = new BinaryReader(input);
                string copy_right = System.Text.Encoding.Default.GetString(binaryReader.ReadBytes(0x28));
                string version = System.Text.Encoding.Default.GetString(binaryReader.ReadBytes(4));
                string file_type = System.Text.Encoding.Default.GetString(binaryReader.ReadBytes(12)); //File type
                uint DrsTable_length = binaryReader.ReadUInt32();
                int num2 = (int)binaryReader.ReadUInt32();
                drs.headerFile = new DrsHeaderFile()
                {
                    copy_right = copy_right,
                    version = version,
                    file_type = file_type,
                    DrsTable_length = DrsTable_length,
                    eof = num2
                };
                DrsTable[] source = new DrsTable[DrsTable_length];
                for (int index = 0; index < DrsTable_length; ++index)
                {
                    source[index] = new DrsTable();
                }
                foreach (DrsTable drsTable in source)
                {
                    drsTable.Type = binaryReader.ReadUInt32();
                    drsTable.Start = binaryReader.ReadUInt32();
                    uint DrsItem_length = binaryReader.ReadUInt32();
                    DrsItem[] drsItemArray = new DrsItem[(int)DrsItem_length];
                    for (int index = 0; index < DrsItem_length; ++index)
                        drsItemArray[index] = new DrsItem();
                    drsTable.Items = drsItemArray;
                }
                foreach (DrsTable drsTable in source)
                {
                    foreach (DrsItem drsItem in drsTable.Items)
                    {
                        drsItem.Id = binaryReader.ReadUInt32();
                        drsItem.Start = binaryReader.ReadUInt32();
                        drsItem.Size = binaryReader.ReadUInt32();
                    }
                }
                foreach (DrsItem drsItem in source.SelectMany(table => table.Items))
                {
                    drsItem.Data = binaryReader.ReadBytes((int)drsItem.Size);
                }
                binaryReader.Close();
                drs.listDrsTable = new List<DrsTable>(source);
                return drs;
            }
        }

        private static bool hasFileType(string modPath, drstype type)
        {
            bool res  = false;
            var fileExtention = getFileExtention((int)type);
            var lstFile= Directory.GetFiles(modPath).ToList();
            if(lstFile.Count== 0)
            {
                return false;
            }
            res = lstFile.Where(x => x.EndsWith(fileExtention)).Count()>0;


            return res;
        }
        private static void CreateMissingDrsTable(DrsFile drs, string modPath)
        {
            if (!drs.listDrsTable.Exists(x => x.Type == (int)drstype.slp) && hasFileType(modPath, drstype.slp))
            {
                uint posSlp = firstDrsTable(drs.listDrsTable);
                drs.listDrsTable.Add(new DrsTable() { Start = posSlp, Type = (uint)drstype.slp, Items  = new List<DrsItem>() });
                drs.headerFile.DrsTable_length +=1;
            }
            if (!drs.listDrsTable.Exists(x => x.Type == (int)drstype.wav) && hasFileType(modPath, drstype.wav))
            {
                drs.listDrsTable.Add(new DrsTable() { Start = 0, Type = (uint)drstype.wav, Items  = new List<DrsItem>() });
                drs.headerFile.DrsTable_length +=1;
            }
            if (!drs.listDrsTable.Exists(x => x.Type == (int)drstype.bina) && hasFileType(modPath, drstype.bina))
            {
                drs.listDrsTable.Add(new DrsTable() { Start = 0, Type = (uint)drstype.bina, Items  = new List<DrsItem>() });
                drs.headerFile.DrsTable_length +=1;
            }  
        }
 

            private static void fixDrsTablePosition(List<DrsTable> drsTableToUpdate,string modPath)
        {
            //drsItem.Id = binaryReader.ReadUInt32();
            //drsItem.Start = binaryReader.ReadUInt32();
            //drsItem.Size = binaryReader.ReadUInt32();
            // 3 * 4 = 12   -> 4 is the sizeof UInt32 
            //slp 
            uint posSlp = firstDrsTable(drsTableToUpdate);
            if(drsTableToUpdate.Exists(x => x.Type == (int)drstype.slp) && hasFileType(modPath, drstype.slp))
            { 
                drsTableToUpdate.Where(x => x.Type == (int)drstype.slp).First().Start = posSlp;
            }
            //wav
            if(drsTableToUpdate.Exists(x => x.Type == (int)drstype.wav) && hasFileType(modPath, drstype.wav))
            {
                var slpDrsItemCount = drsTableToUpdate.Where(x => x.Type == (int)drstype.slp).First().Items.Count();    
                drsTableToUpdate.Where(x => x.Type == (int)drstype.wav).First().Start = (uint)slpDrsItemCount * 12 + posSlp;
            }
            //bina
            if (drsTableToUpdate.Exists(x => x.Type == (int)drstype.bina) &&  hasFileType(modPath, drstype.bina))
            {
                var posWav = drsTableToUpdate.Where(x => x.Type == (int)drstype.wav).First().Start;
                var wavDrsItemCount = drsTableToUpdate.Where(x => x.Type == (int)drstype.wav).First().Items.Count();
                drsTableToUpdate.Where(x => x.Type == (int)drstype.bina).First().Start = (uint)wavDrsItemCount * 12 + posWav;
            }
        }

        private static string getFileExtention(int type)
        {
            switch (type)
            {
                case (int)drstype.slp:
                    return ".slp"; 
                case (int)drstype.wav:
                    return ".wav";
                case (int)drstype.bina:
                    return ".bina";
                default:
                    return string.Empty;
            } 
        }


        /// <summary>
        /// Add slp , wav or bina file to drs list to make the drs file
        /// </summary>
        /// <param name="type"> slp or wav or bina</param>
        /// <param name="id">id of file to append</param>
        /// <param name="path">path of file to get his buffer </param>
        /// <param name="drsTableToUpdate">list of drs table </param>
        private static void appendDrsToList(int type, uint id, string f , DrsFile drs)
        {
            List<DrsItem> DrsItems = drs.listDrsTable.Where(x => x.Type == type).First().Items.ToList();
            byte[] buffer;
            if (isVoolbyCodedSlp(f))
            {
                buffer = DecodeVooblySLP(f);
            }
            else
            { 
                buffer = File.ReadAllBytes(f);
            }
            var last = DrsItems.LastOrDefault();
            if(last == null)
            {
                last =drs.listDrsTable.Where(x => x.Items.Count()>0)?.FirstOrDefault()?.Items?.LastOrDefault();
                if(last == null )
                {
                    last = new DrsItem() { Start = drs.listDrsTable.Where(x=>x.Start>0).Last().Start, Size=0  };
                }
            }
            if (buffer!=null)
            {
                if (!DrsItems.Exists(x => x.Id == id))
                {
                    DrsItems.Add(new DrsItem()
                    {
                        Id = id,
                        Data = buffer,
                        Size = (uint)buffer.Length,
                        Start = last.Start + last.Size,
                    });
                }
                else
                {
                    //DrsItems.Where(x=>x.Id ==id).First().Start = buffer; //a function will fix the position for DrsItem
                    DrsItems.Where(x => x.Id ==id).First().Data = buffer;
                    DrsItems.Where(x => x.Id ==id).First().Size = (uint)buffer.Length;
                }
                drs.listDrsTable.Where(x => x.Type == type).First().Items =DrsItems;
            }
        }
        private static void writeDrsFile(string path, DrsFile drs)
        {
            using (FileStream output = new FileStream(path, FileMode.Create))
            {
                BinaryWriter binaryWriter = new BinaryWriter(output);
                //write drs header file
                binaryWriter.Write(drs.headerFile.copy_right.ReadBytes(0x28));
                binaryWriter.Write(drs.headerFile.version.ReadBytes(4));
                binaryWriter.Write(drs.headerFile.file_type.ReadBytes(12));
                binaryWriter.Write(drs.headerFile.DrsTable_length);
                binaryWriter.Write(drs.headerFile.eof);
                //write DrsTable description 
                foreach (DrsTable d in drs.listDrsTable)
                {
                    binaryWriter.Write(d.Type);
                    binaryWriter.Write(d.Start);
                    uint DrsItemsCount = (uint)d.Items.Count();
                    binaryWriter.Write(DrsItemsCount);
                }
                //Write drs Items descriptions
                foreach (DrsTable d in drs.listDrsTable)
                {
                    foreach (DrsItem drsItem in d.Items)
                    {
                        binaryWriter.Write(drsItem.Id);
                        binaryWriter.Write(drsItem.Start);
                        binaryWriter.Write(drsItem.Size);
                    }
                }
                //Write drsItem contiant
                foreach (DrsTable d in drs.listDrsTable)
                {
                    foreach (DrsItem drsItem in d.Items)
                    {
                        binaryWriter.Write(drsItem.Data);
                    }
                }
                binaryWriter.Close();
            }
        }

        public static void UpdateDrsFile(string f, DrsFile drs)
        {
            uint id = 0;
            var fileExtention = Path.GetExtension(f);
            var fileName = Path.GetFileNameWithoutExtension(f);
            if (uint.TryParse(fileName, out id))
            {
                switch (fileExtention)
                {
                    case ".slp":
                        appendDrsToList((int)drstype.slp, id, f, drs);
                        break;
                    case ".wav":
                        appendDrsToList((int)drstype.wav, id, f, drs);
                        break;
                    case ".bina":
                        appendDrsToList((int)drstype.bina, id, f, drs);
                        break;
                }
            }
        }
        public static void fixDrsItemPosition(DrsFile drs,string folderPath)
        {
            //fix drs table position
            fixDrsTablePosition(drs.listDrsTable, folderPath);
            //fix drs items positions
            uint pos = getEofDrs(drs.listDrsTable);
            drs.headerFile.eof =(int)pos;
            foreach (var d in drs.listDrsTable)
            {
                foreach (DrsItem item in d.Items)
                { 
                    item.Start = pos;  
                    pos += item.Size; 
                }
            } 
        }

        public static void mergeFileIntoDrs(string folderPath , string  drsPath  )
        {
            DrsFile drs = new DrsFile();
            if (File.Exists(drsPath))
            {
                drs = parseToDrsClass(drsPath);
            }
            else
            {
                drs.headerFile = new DrsHeaderFile()
                {
                    copy_right = "Copyright (c) 1997 Ensemble Studios.\u001a",
                    version = "1.00",
                    file_type = "tribe",
                    DrsTable_length = 0 ,
                    eof = 0
                };
                drs.listDrsTable = new List<DrsTable>();
            }
            CreateMissingDrsTable(drs,folderPath);
            foreach (var f in Directory.GetFiles(folderPath)) 
            {
                UpdateDrsFile(f, drs);
            }
            fixDrsItemPosition(drs, folderPath);//we add new slp,wav , bina so we need update position
            writeDrsFile(drsPath, drs);
        } 
    }
}
