﻿
using System;
using System.IO;


namespace voobly_drs_merger
{



    public class slpReader
    {
        public string name;
        public string version = "2.0N";
        public int numframes;
        public string Comment = "ArtDesk 1.00 SLP Writer";
        public int playernumber;
        public int mask = 8;
        public int outline1 = 8;
        public int outline2 = 8;
        internal int shadow = 131;
        public string sample = "50500.bmp";
        internal frame[] frames;

        public void Read(string s)
        {
            try
            {
                FileStream fileStream = new FileStream(s, FileMode.OpenOrCreate);
                int length1 = this.version.Length;
                byte[] buffer1 = new byte[length1];
                fileStream.Read(buffer1, 0, length1);
                int count1 = 4;
                byte[] buffer2 = new byte[count1];
                fileStream.Read(buffer2, 0, count1);
                this.numframes = ((int)buffer2[3] & (int)byte.MaxValue) << 24 | ((int)buffer2[2] & (int)byte.MaxValue) << 16 /*0x10*/ | ((int)buffer2[1] & (int)byte.MaxValue) << 8 | (int)buffer2[0] & (int)byte.MaxValue;
                Console.WriteLine("Number of frames: " + this.numframes.ToString());
                this.frames = new frame[this.numframes];
                for (int index = 0; index < this.numframes; ++index)
                    this.frames[index] = new frame();
                int length2 = this.Comment.Length;
                byte[] buffer3 = new byte[length2];
                fileStream.Read(buffer3, 0, length2);
                fileStream.ReadByte();
                int num1 = 32 /*0x20*/;
                for (int index = 0; index < this.numframes; ++index)
                {
                    int count2 = 4;
                    byte[] buffer4 = new byte[count2];
                    fileStream.Read(buffer4, 0, count2);
                    this.frames[index].frame_data_offsets = ((int)buffer4[3] & (int)byte.MaxValue) << 24 | ((int)buffer4[2] & (int)byte.MaxValue) << 16 /*0x10*/ | ((int)buffer4[1] & (int)byte.MaxValue) << 8 | (int)buffer4[0] & (int)byte.MaxValue;
                    int count3 = 4;
                    byte[] buffer5 = new byte[count3];
                    fileStream.Read(buffer5, 0, count3);
                    this.frames[index].frame_outline_offset = ((int)buffer5[3] & (int)byte.MaxValue) << 24 | ((int)buffer5[2] & (int)byte.MaxValue) << 16 /*0x10*/ | ((int)buffer5[1] & (int)byte.MaxValue) << 8 | (int)buffer5[0] & (int)byte.MaxValue;
                    int count4 = 4;
                    byte[] buffer6 = new byte[count4];
                    fileStream.Read(buffer6, 0, count4);
                    this.frames[index].palette_offset = ((int)buffer6[3] & (int)byte.MaxValue) << 24 | ((int)buffer6[2] & (int)byte.MaxValue) << 16 /*0x10*/ | ((int)buffer6[1] & (int)byte.MaxValue) << 8 | (int)buffer6[0] & (int)byte.MaxValue;
                    int count5 = 4;
                    byte[] buffer7 = new byte[count5];
                    fileStream.Read(buffer7, 0, count5);
                    this.frames[index].properties = ((int)buffer7[3] & (int)byte.MaxValue) << 24 | ((int)buffer7[2] & (int)byte.MaxValue) << 16 /*0x10*/ | ((int)buffer7[1] & (int)byte.MaxValue) << 8 | (int)buffer7[0] & (int)byte.MaxValue;
                    int count6 = 4;
                    byte[] buffer8 = new byte[count6];
                    fileStream.Read(buffer8, 0, count6);
                    this.frames[index].width = ((int)buffer8[3] & (int)byte.MaxValue) << 24 | ((int)buffer8[2] & (int)byte.MaxValue) << 16 /*0x10*/ | ((int)buffer8[1] & (int)byte.MaxValue) << 8 | (int)buffer8[0] & (int)byte.MaxValue;
                    int count7 = 4;
                    byte[] buffer9 = new byte[count7];
                    fileStream.Read(buffer9, 0, count7);
                    this.frames[index].height = ((int)buffer9[3] & (int)byte.MaxValue) << 24 | ((int)buffer9[2] & (int)byte.MaxValue) << 16 /*0x10*/ | ((int)buffer9[1] & (int)byte.MaxValue) << 8 | (int)buffer9[0] & (int)byte.MaxValue;
                    int count8 = 4;
                    byte[] buffer10 = new byte[count8];
                    fileStream.Read(buffer10, 0, count8);
                    this.frames[index].anchorx = ((int)buffer10[3] & (int)byte.MaxValue) << 24 | ((int)buffer10[2] & (int)byte.MaxValue) << 16 /*0x10*/ | ((int)buffer10[1] & (int)byte.MaxValue) << 8 | (int)buffer10[0] & (int)byte.MaxValue;
                    int count9 = 4;
                    byte[] buffer11 = new byte[count9];
                    fileStream.Read(buffer11, 0, count9);
                    this.frames[index].anchory = ((int)buffer11[3] & (int)byte.MaxValue) << 24 | ((int)buffer11[2] & (int)byte.MaxValue) << 16 /*0x10*/ | ((int)buffer11[1] & (int)byte.MaxValue) << 8 | (int)buffer11[0] & (int)byte.MaxValue;
                    num1 += 32 /*0x20*/;
                }
                for (int index1 = 0; index1 < this.numframes; ++index1)
                {
                    this.frames[index1].initrowedge(this.frames[index1].height);
                    this.frames[index1].initpic(this.frames[index1].width, this.frames[index1].height);
                    for (int index2 = 0; index2 < this.frames[index1].height; ++index2)
                    {
                        byte[] buffer12 = new byte[2];
                        fileStream.Read(buffer12, 0, 2);
                        int num2 = num1 + 2;
                        this.frames[index1].edges[index2].left = ((int)buffer12[1] & (int)byte.MaxValue) << 8 | (int)buffer12[0] & (int)byte.MaxValue;
                        if (this.frames[index1].edges[index2].left > 1000)
                            this.frames[index1].edges[index2].left = this.frames[index1].width;
                        fileStream.Read(buffer12, 0, 2);
                        num1 = num2 + 2;
                        this.frames[index1].edges[index2].right = ((int)buffer12[1] & (int)byte.MaxValue) << 8 | (int)buffer12[0] & (int)byte.MaxValue;
                        if (this.frames[index1].edges[index2].right > 1000)
                            this.frames[index1].edges[index2].right = this.frames[index1].width;
                    }
                    for (int index3 = 0; index3 < this.frames[index1].height; ++index3)
                    {
                        byte[] buffer13 = new byte[4];
                        fileStream.Read(buffer13, 0, 4);
                        num1 += 4;
                        this.frames[index1].commandoff[index3] = ((int)buffer13[3] & (int)byte.MaxValue) << 24 | ((int)buffer13[2] & (int)byte.MaxValue) << 16 /*0x10*/ | ((int)buffer13[1] & (int)byte.MaxValue) << 8 | (int)buffer13[0] & (int)byte.MaxValue;
                    }
                    for (int row = 0; row < this.frames[index1].height; ++row)
                    {
                        this.frames[index1].drawmask(row, this.frames[index1].edges[row].left);
                        if (num1 != this.frames[index1].commandoff[row])
                            Console.WriteLine($"--Mismatch in command offset -- Read: {num1.ToString()}-should be {this.frames[index1].commandoff[row].ToString()} -");
                        bool flag = true;
                        do
                        {
                            byte[] buffer14 = new byte[1];
                            fileStream.Read(buffer14, 0, 1);
                            ++num1;
                            byte num3 = buffer14[0];
                            switch ((int)num3 & 15)
                            {
                                case 0:
                                case 4:
                                case 8:
                                case 12:
                                    int count10 = ((int)num3 & (int)byte.MaxValue) >> 2;
                                    byte[] numArray1 = new byte[count10];
                                    fileStream.Read(numArray1, 0, count10);
                                    num1 += count10;
                                    this.frames[index1].drawbytearray(row, numArray1);
                                    break;
                                case 1:
                                case 5:
                                case 9:
                                case 13:
                                    int n1 = ((int)num3 & (int)byte.MaxValue) >> 2;
                                    this.frames[index1].drawmask(row, n1);
                                    break;
                                case 2:
                                    byte[] buffer15 = new byte[1];
                                    fileStream.Read(buffer15, 0, 1);
                                    int num4 = num1 + 1;
                                    byte num5 = buffer15[0];
                                    int count11 = (((int)num3 & 240 /*0xF0*/) << 4) + ((int)num5 & (int)byte.MaxValue);
                                    byte[] numArray2 = new byte[count11];
                                    fileStream.Read(numArray2, 0, count11);
                                    int num6 = count11;
                                    num1 = num4 + num6;
                                    this.frames[index1].drawbytearray(row, numArray2);
                                    break;
                                case 3:
                                    byte[] buffer16 = new byte[1];
                                    fileStream.Read(buffer16, 0, 1);
                                    ++num1;
                                    byte num7 = buffer16[0];
                                    int n2 = (((int)num3 & 240 /*0xF0*/) << 4) + ((int)num7 & (int)byte.MaxValue);
                                    this.frames[index1].drawmask(row, n2);
                                    break;
                                case 6:
                                    int num8 = (int)num3 & 240 /*0xF0*/;
                                    int count12;
                                    if (num8 == 0)
                                    {
                                        count12 = fileStream.ReadByte();
                                        ++num1;
                                    }
                                    else
                                        count12 = (num8 & (int)byte.MaxValue) >> 4;
                                    byte[] numArray3 = new byte[count12];
                                    fileStream.Read(numArray3, 0, count12);
                                    num1 += count12;
                                    this.frames[index1].drawplayercolors(row, numArray3, this.playernumber);
                                    break;
                                case 7:
                                    int num9 = (int)num3 & 240 /*0xF0*/;
                                    int n3;
                                    if (num9 == 0)
                                    {
                                        n3 = fileStream.ReadByte();
                                        ++num1;
                                    }
                                    else
                                        n3 = (num9 & (int)byte.MaxValue) >> 4;
                                    byte[] numArray4 = new byte[1];
                                    fileStream.Read(numArray4, 0, 1);
                                    ++num1;
                                    int num10 = (int)numArray4[0];
                                    this.frames[index1].fill(row, numArray4, n3);
                                    break;
                                case 10:
                                    int num11 = (int)num3 & 240 /*0xF0*/;
                                    int n4;
                                    if (num11 == 0)
                                    {
                                        n4 = fileStream.ReadByte();
                                        ++num1;
                                    }
                                    else
                                        n4 = (num11 & (int)byte.MaxValue) >> 4;
                                    byte[] numArray5 = new byte[1];
                                    fileStream.Read(numArray5, 0, 1);
                                    ++num1;
                                    int num12 = (int)numArray5[0];
                                    this.frames[index1].playercolorfill(row, numArray5, n4, this.playernumber);
                                    break;
                                case 11:
                                    int num13 = (int)num3 & 240 /*0xF0*/;
                                    int n5;
                                    if (num13 == 0)
                                    {
                                        n5 = fileStream.ReadByte();
                                        ++num1;
                                    }
                                    else
                                        n5 = (num13 & (int)byte.MaxValue) >> 4;
                                    this.frames[index1].drawshadowpixels(row, n5);
                                    break;
                                case 14:
                                    switch (num3)
                                    {
                                        case 78:
                                        case 110:
                                            if (num3 == (byte)78)
                                            {
                                                this.frames[index1].drawselectionmask(row, 1);
                                                break;
                                            }
                                            this.frames[index1].drawselectionmask2(row, 1);
                                            break;
                                        case 94:
                                        case 126:
                                            byte[] buffer17 = new byte[1];
                                            fileStream.Read(buffer17, 0, 1);
                                            ++num1;
                                            int n6 = (int)buffer17[0];
                                            if (num3 == (byte)94)
                                            {
                                                this.frames[index1].drawselectionmask(row, n6);
                                                break;
                                            }
                                            this.frames[index1].drawselectionmask2(row, n6);
                                            break;
                                        default:
                                            Console.WriteLine("Extended command unrecognized");
                                            break;
                                    }
                                    break;
                                case 15:
                                    flag = false;
                                    break;
                            }
                        }
                        while (flag);
                        this.frames[index1].drawmask(row, this.frames[index1].edges[row].right);
                    }
                }
                fileStream.Close();
                fileStream.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Caught exception in Read slp! ");
                Console.WriteLine((object)ex);
            }
        }

        public virtual void save(string outdir)
        {
            for (int index = 0; index < this.numframes; ++index)
            {
                string filename = $"{outdir.ToString()}{this.name}.bmp";
                this.frames[index].converttobitmap(filename, this.mask, this.outline1, this.outline2, this.shadow, this.sample);
            }
        }

        public virtual void saveMultiFames(string outdir)
        {
            for (int index = 0; index < this.numframes; ++index)
            {
                string filename = $"{outdir.ToString()}{this.name}{index.ToString()}.bmp";
                this.frames[index].converttobitmap(filename, this.mask, this.outline1, this.outline2, this.shadow, this.sample);
            }
        }

        public virtual void savecsv(string outdir)
        {
            string path = $"{outdir.ToString()}Frames{this.name}\\{this.name}.csv";
            string[] strArray = new string[this.numframes];
            for (int index = 0; index < this.numframes; ++index)
                strArray[index] = $"{this.frames[index].anchorx.ToString()}, {this.frames[index].anchory.ToString()}";
            try
            {
                StreamWriter streamWriter = new StreamWriter(path);
                for (int index = 0; index < this.numframes; ++index)
                    streamWriter.Write(strArray[index].ToString() + "\r\n");
                streamWriter.Close();
            }
            catch (IOException ex)
            {
            }
        }

        internal virtual void timedelay(double num)
        {
            long num1 = slpReader.DateTimeHelper.CurrentUnixTimeMillis();
            long num2 = (long)(1000.0 * num);
            do
                ;
            while (slpReader.DateTimeHelper.CurrentUnixTimeMillis() - num1 < num2);
        }

        internal static class DateTimeHelper
        {
            private static readonly DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            public static long CurrentUnixTimeMillis()
            {
                return (long)(DateTime.UtcNow - slpReader.DateTimeHelper.Jan1st1970).TotalMilliseconds;
            }
        }
    }
}