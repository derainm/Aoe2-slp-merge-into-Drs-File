
using System;
using System.IO;
using System.Text;


namespace voobly_drs_merger
{


    public class slpWriter
    {
        private int shadow = 131;
        private int outline1 = 8;
        private int outline2 = 124;
        private int outputmask;
        private string csvfile = "dunno";
        private bool cvtused;
        private bool plcolorused;
        public string maskfile = "";
        private int numframes;
        private frame[] frames;
        private int[] mapping;
        private string version;
        private string comment;

        public void initframes(int n)
        {
            this.numframes = n;
            this.frames = new frame[n];
        }

        public void Writemasks(string inputfile, string outputfile, int choice)
        {
            imagehandler imagehandler = new imagehandler();
            imagehandler.loadbitmap(inputfile, 0);
            byte[][] numArray = imagehandler.returnrawpixels();
            int length1 = numArray[0].Length;
            int length2 = numArray.Length;
            int[][] picture = slpWriter.RectangularArrays.RectangularIntArray(length2, length1);
            for (int index1 = 0; index1 < length2; ++index1)
            {
                for (int index2 = 0; index2 < length1; ++index2)
                    picture[index1][index2] = (int)numArray[index1][index2] & (int)byte.MaxValue;
            }
            int num = picture[length2 - 1][0];
            switch (choice)
            {
                case 1:
                    for (int index3 = 0; index3 < length2; ++index3)
                    {
                        for (int index4 = 0; index4 < length1; ++index4)
                            picture[index3][index4] = picture[index3][index4] != num ? (int)byte.MaxValue : this.outputmask;
                    }
                    break;
                case 2:
                    for (int index5 = 0; index5 < length2; ++index5)
                    {
                        for (int index6 = 0; index6 < length1 - 1; ++index6)
                        {
                            if (picture[index5][index6] == num && picture[index5][index6 + 1] != num && index6 + 1 != length1 - 1)
                                picture[index5][index6] = -2;
                        }
                        for (int index7 = length1 - 1; index7 > 0; --index7)
                        {
                            if (picture[index5][index7] == num && picture[index5][index7 - 1] != num && index7 + 1 != length1 - 1)
                                picture[index5][index7] = -2;
                        }
                    }
                    for (int index8 = 0; index8 < length1; ++index8)
                    {
                        for (int index9 = 0; index9 <= length2 - 2; ++index9)
                        {
                            if (picture[index9][index8] == num && picture[index9 + 1][index8] != num && picture[index9 + 1][index8] != -2)
                                picture[index9][index8] = -2;
                        }
                        for (int index10 = length2 - 1; index10 > 0; --index10)
                        {
                            if (picture[index10][index8] == num && picture[index10 - 1][index8] != num && picture[index10 - 1][index8] != -2)
                                picture[index10][index8] = -2;
                        }
                    }
                    for (int index11 = 0; index11 < length2; ++index11)
                    {
                        for (int index12 = 0; index12 < length1; ++index12)
                        {
                            if (picture[index11][index12] != -2)
                                picture[index11][index12] = this.outputmask;
                        }
                    }
                    break;
                case 3:
                    for (int index13 = 0; index13 < length2; ++index13)
                    {
                        for (int index14 = 0; index14 < length1; ++index14)
                        {
                            if (picture[index13][index14] < 16 /*0x10*/ || picture[index13][index14] > 23)
                                picture[index13][index14] = this.outputmask;
                        }
                    }
                    break;
                case 4:
                    for (int index15 = 0; index15 < length2; ++index15)
                    {
                        for (int index16 = 0; index16 < length1; ++index16)
                            picture[index15][index16] = picture[index15][index16] != 131 ? this.outputmask : 131;
                    }
                    break;
                case 5:
                    for (int index17 = 0; index17 < length2; ++index17)
                    {
                        for (int index18 = 0; index18 < length1 - 1; ++index18)
                        {
                            if (picture[index17][index18] == num && picture[index17][index18 + 1] != num && index18 + 1 != length1 - 1)
                                picture[index17][index18] = -2;
                        }
                        for (int index19 = length1 - 1; index19 > 0; --index19)
                        {
                            if (picture[index17][index19] == num && picture[index17][index19 - 1] != num && index19 + 1 != length1 - 1)
                                picture[index17][index19] = -2;
                        }
                    }
                    for (int index20 = 0; index20 < length1; ++index20)
                    {
                        for (int index21 = 0; index21 <= length2 - 2; ++index21)
                        {
                            if (picture[index21][index20] == num && picture[index21 + 1][index20] != num && picture[index21 + 1][index20] != -2)
                                picture[index21][index20] = -2;
                        }
                        for (int index22 = length2 - 2; index22 > 0; --index22)
                        {
                            if (picture[index22][index20] == num && picture[index22 - 1][index20] != num && picture[index22 - 1][index20] != -2)
                                picture[index22][index20] = -2;
                        }
                    }
                    for (int index23 = 0; index23 < length2; ++index23)
                    {
                        for (int index24 = 0; index24 < length1 - 1; ++index24)
                        {
                            if (picture[index23][index24] == num && picture[index23][index24 + 1] != num && index24 + 1 != length1 - 1)
                                picture[index23][index24] = -3;
                        }
                        for (int index25 = length1 - 1; index25 > 0; --index25)
                        {
                            if (picture[index23][index25] == num && picture[index23][index25 - 1] != num && index25 + 1 != length1 - 1)
                                picture[index23][index25] = -3;
                        }
                    }
                    for (int index26 = 0; index26 < length1; ++index26)
                    {
                        for (int index27 = 0; index27 <= length2 - 2; ++index27)
                        {
                            if (picture[index27][index26] == num && picture[index27 + 1][index26] != num && picture[index27 + 1][index26] != -3)
                                picture[index27][index26] = -3;
                        }
                        for (int index28 = length2 - 2; index28 > 0; --index28)
                        {
                            if (picture[index28][index26] == num && picture[index28 - 1][index26] != num && picture[index28 - 1][index26] != -3)
                                picture[index28][index26] = -3;
                        }
                    }
                    for (int index29 = 0; index29 < length2; ++index29)
                    {
                        for (int index30 = 0; index30 < length1; ++index30)
                        {
                            if (picture[index29][index30] != -3)
                                picture[index29][index30] = this.outputmask;
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Unrecognized command");
                    break;
            }
            new Aokbitmap(this.outputmask, this.outline1, this.outline2, this.shadow).Write(outputfile, picture, numArray[0].Length, numArray.Length);
        }

        public virtual void getframe(
          int num,
          string path,
          string filename,
          bool msk,
          bool o1,
          bool o2,
          bool pl,
          bool sh)
        {
            imagehandler imagehandler = new imagehandler();
            imagehandler.loadbitmap(path.ToString() + filename, 0);
            byte[][] numArray1 = imagehandler.returnrawpixels();
            int length1 = numArray1[0].Length;
            int length2 = numArray1.Length;
            int[][] numArray2 = slpWriter.RectangularArrays.RectangularIntArray(length2, length1);
            for (int index1 = 0; index1 < length2; ++index1)
            {
                for (int index2 = 0; index2 < length1; ++index2)
                    numArray2[index1][index2] = (int)numArray1[index1][index2] & (int)byte.MaxValue;
            }
            if (msk)
            {
                string maskfile = this.maskfile;
                if (File.Exists(maskfile))
                    imagehandler.loadbitmap(maskfile, 0);
                byte[][] numArray3 = imagehandler.returnrawpixels();
                for (int index3 = 0; index3 < length2; ++index3)
                {
                    for (int index4 = 0; index4 < length1; ++index4)
                    {
                        if (((int)numArray3[index3][index4] & (int)byte.MaxValue) == 0)
                            numArray2[index3][index4] = -1;
                    }
                }
            }
            if (o1)
            {
                string filename1 = $"{path.ToString()}U{filename.Substring(1)}";
                imagehandler.loadbitmap(filename1, 0);
                byte[][] numArray4 = imagehandler.returnrawpixels();
                for (int index5 = 0; index5 < length2; ++index5)
                {
                    for (int index6 = 0; index6 < length1; ++index6)
                    {
                        if (((int)numArray4[index5][index6] & (int)byte.MaxValue) != 0)
                            numArray2[index5][index6] = -2;
                    }
                }
            }
            if (o2)
            {
                string filename2 = $"{path.ToString()}O{filename.Substring(1)}";
                imagehandler.loadbitmap(filename2, 0);
                byte[][] numArray5 = imagehandler.returnrawpixels();
                for (int index7 = 0; index7 < length2; ++index7)
                {
                    for (int index8 = 0; index8 < length1; ++index8)
                    {
                        if (((int)numArray5[index7][index8] & (int)byte.MaxValue) != 0)
                            numArray2[index7][index8] = -3;
                    }
                }
            }
            if (pl)
            {
                string filename3 = $"{path.ToString()}P{filename.Substring(1)}";
                imagehandler.loadbitmap(filename3, 0);
                byte[][] numArray6 = imagehandler.returnrawpixels();
                for (int index9 = 0; index9 < length2; ++index9)
                {
                    for (int index10 = 0; index10 < length1; ++index10)
                    {
                        int num1 = (int)numArray6[index9][index10] & (int)byte.MaxValue;
                        if (num1 != 0)
                            numArray2[index9][index10] = num1;
                    }
                }
                this.plcolorused = true;
            }
            if (sh)
            {
                string filename4 = $"{path.ToString()}H{filename.Substring(1)}";
                imagehandler.loadbitmap(filename4, 0);
                byte[][] numArray7 = imagehandler.returnrawpixels();
                Console.WriteLine("Entering shadow stuff");
                for (int index11 = 0; index11 < length2; ++index11)
                {
                    for (int index12 = 0; index12 < length1; ++index12)
                    {
                        if (((int)numArray7[index11][index12] & (int)byte.MaxValue) != 0)
                            numArray2[index11][index12] = -4;
                    }
                }
            }
            if (this.frames == null)
                this.frames = new frame[num + 1];
            this.frames[num] = new frame();
            this.frames[num].width = length1;
            this.frames[num].height = length2;
            this.frames[num].picture = numArray2;
            if (!this.cvtused)
                return;
            this.frames[num].convertcvt(this.mapping);
        }

        public virtual void convertcvt(string cvtname)
        {
            try
            {
                this.cvtused = true;
                StreamReader streamReader = new StreamReader(cvtname);
                this.mapping = new int[256 /*0x0100*/];
                for (int index = 0; index < 256 /*0x0100*/; ++index)
                    this.mapping[index] = -11;
                if (streamReader.ReadLine().Equals("<MPS PALETTE REMAP>"))
                    Console.WriteLine("Recognized as MPS cvt file");
                else
                    Console.WriteLine("Not recognized as MPS cvt file");
                string str;
                while ((str = streamReader.ReadLine()) != null)
                {
                    int length = str.IndexOf(" ", StringComparison.Ordinal);
                    this.mapping[int.Parse(str.Substring(0, length))] = int.Parse(str.Substring(length + 1));
                }
                streamReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Caught exception in applying CVT! ");
                Console.WriteLine(ex.ToString());
                Console.Write(ex.StackTrace);
            }
        }

        public virtual void compress()
        {
            for (int index1 = 0; index1 < this.numframes; ++index1)
            {
                this.frames[index1].initrowedge(this.frames[index1].height);
                for (int index2 = 0; index2 < this.frames[index1].height; ++index2)
                {
                    int l = 0;
                    for (int index3 = 0; index3 < this.frames[index1].width && this.frames[index1].picture[index2][index3] == -1; ++index3)
                        ++l;
                    int r = 0;
                    for (int index4 = this.frames[index1].width - 1; index4 >= 0 && this.frames[index1].picture[index2][index4] == -1; --index4)
                        ++r;
                    if (l == this.frames[index1].width)
                        r = 0;
                    this.frames[index1].edges[index2] = new rowedge(l, r);
                }
                this.frames[index1].initcommands();
                for (int index5 = 0; index5 < this.frames[index1].height; ++index5)
                {
                    int num1 = -5;
                    int left = this.frames[index1].edges[index5].left;
                    int num2 = this.frames[index1].width - this.frames[index1].edges[index5].right - 1;
                    int index6 = left;
                    int n = 0;
                    string str = "null";
                    int length = -1;
                    int num3 = -1;
                    for (; index6 <= num2; ++index6)
                    {
                        int num4 = this.frames[index1].picture[index5][index6];
                        if (num4 != num1 && num4 < 0)
                        {
                            switch (str)
                            {
                                case "skip":
                                    this.frames[index1].cmdskip(n);
                                    break;
                                case "outline1":
                                    this.frames[index1].cmdoutline1(n);
                                    break;
                                case "outline2":
                                    this.frames[index1].cmdoutline2(n);
                                    break;
                                case "shadowpix":
                                    this.frames[index1].cmdshadowpix(n);
                                    break;
                            }
                            if (str.Equals("color"))
                            {
                                byte[] array = new byte[length];
                                for (int index7 = 0; index7 < length; ++index7)
                                    array[index7] = (byte)this.frames[index1].picture[index5][index7 + num3];
                                this.frames[index1].cmdcolorblock(array, this.plcolorused);
                                length = -1;
                                num3 = -1;
                            }
                            switch (num4)
                            {
                                case -4:
                                    str = "shadowpix";
                                    break;
                                case -3:
                                    str = "outline2";
                                    break;
                                case -2:
                                    str = "outline1";
                                    break;
                                case -1:
                                    str = "skip";
                                    break;
                                default:
                                    Console.WriteLine("Unknown pixel");
                                    break;
                            }
                            num1 = num4;
                            n = 1;
                        }
                        else if (num4 != num1 && num1 < 0)
                        {
                            switch (str)
                            {
                                case "skip":
                                    this.frames[index1].cmdskip(n);
                                    break;
                                case "outline1":
                                    this.frames[index1].cmdoutline1(n);
                                    break;
                                case "outline2":
                                    this.frames[index1].cmdoutline2(n);
                                    break;
                                case "shadowpix":
                                    this.frames[index1].cmdshadowpix(n);
                                    break;
                            }
                            str = "color";
                            num1 = num4;
                            n = 1;
                            num3 = index6;
                            length = 1;
                        }
                        else if (str.Equals("color"))
                        {
                            ++length;
                            num1 = num4;
                            n = 1;
                        }
                        else
                            ++n;
                    }
                    switch (str)
                    {
                        case "color":
                            byte[] array1 = new byte[length];
                            for (int index8 = 0; index8 < length; ++index8)
                                array1[index8] = (byte)this.frames[index1].picture[index5][index8 + num3];
                            this.frames[index1].cmdcolorblock(array1, this.plcolorused);
                            break;
                        case "skip":
                            this.frames[index1].cmdskip(n);
                            break;
                        case "outline1":
                            this.frames[index1].cmdoutline1(n);
                            break;
                        case "outline2":
                            this.frames[index1].cmdoutline2(n);
                            break;
                        case "shadowpix":
                            this.frames[index1].cmdshadowpix(n);
                            break;
                    }
                    this.frames[index1].cmdeol();
                }
            }
        }

        public virtual void Write(string filename)
        {
            try
            {
                this.version = "2.0N";
                this.comment = "ArtDesk 1.00 SLP Writer ";
                Console.WriteLine("Number of frames " + this.numframes.ToString());
                FileStream output = new FileStream(filename, FileMode.Create, FileAccess.Write);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                byte[] bytes1 = Encoding.ASCII.GetBytes(this.version);
                binaryWriter.Write(bytes1);
                byte[] buffer1 = this.bytefromint(this.numframes);
                binaryWriter.Write(buffer1);
                byte[] bytes2 = Encoding.ASCII.GetBytes(this.comment);
                binaryWriter.Write(bytes2);
                int num1 = 32 /*0x20*/ + 32 /*0x20*/ * this.numframes;
                for (int index = 0; index < this.numframes; ++index)
                {
                    this.frames[index].frame_outline_offset = num1;
                    this.frames[index].computecommandbytes();
                    int num2 = num1 + this.frames[index].height * 4;
                    this.frames[index].frame_data_offsets = num2;
                    num1 = num2 + this.frames[index].height * 4;
                    for (int n = 0; n < this.frames[index].height; ++n)
                    {
                        this.frames[index].commandoff[n] = num1;
                        num1 += this.frames[index].linecommandLength(n);
                    }
                }
                for (int index = 0; index < this.numframes; ++index)
                    this.frames[index].setanchor(0, 0);
                for (int index = 0; index < this.numframes; ++index)
                {
                    this.frames[index].computeframeheader();
                    byte[] buffer2 = this.bytefromint(this.frames[index].frame_data_offsets);
                    binaryWriter.Write(buffer2);
                    byte[] buffer3 = this.bytefromint(this.frames[index].frame_outline_offset);
                    binaryWriter.Write(buffer3);
                    byte[] buffer4 = this.bytefromint(this.frames[index].palette_offset);
                    binaryWriter.Write(buffer4);
                    byte[] buffer5 = this.bytefromint(this.frames[index].properties);
                    binaryWriter.Write(buffer5);
                    byte[] buffer6 = this.bytefromint(this.frames[index].width);
                    binaryWriter.Write(buffer6);
                    byte[] buffer7 = this.bytefromint(this.frames[index].height);
                    binaryWriter.Write(buffer7);
                    byte[] buffer8 = this.bytefromint(this.frames[index].anchorx);
                    binaryWriter.Write(buffer8);
                    byte[] buffer9 = this.bytefromint(this.frames[index].anchory);
                    binaryWriter.Write(buffer9);
                }
                for (int index1 = 0; index1 < this.numframes; ++index1)
                {
                    for (int index2 = 0; index2 < this.frames[index1].height; ++index2)
                    {
                        byte[] buffer10 = this.bytefromshort(this.frames[index1].edges[index2].left);
                        byte[] buffer11 = this.bytefromshort(this.frames[index1].edges[index2].right);
                        binaryWriter.Write(buffer10);
                        binaryWriter.Write(buffer11);
                    }
                    for (int index3 = 0; index3 < this.frames[index1].height; ++index3)
                    {
                        byte[] buffer12 = this.bytefromint(this.frames[index1].commandoff[index3]);
                        binaryWriter.Write(buffer12);
                    }
                    for (int index4 = 0; index4 < this.frames[index1].numcommands; ++index4)
                    {
                        switch (this.frames[index1].commands[index4].type)
                        {
                            case "one":
                                byte[] buffer13 = new byte[1]
                                {
                this.frames[index1].commands[index4].cmdbyte
                                };
                                binaryWriter.Write(buffer13);
                                break;
                            case "two Length":
                                byte[] buffer14 = new byte[2]
                                {
                this.frames[index1].commands[index4].cmdbyte,
                this.frames[index1].commands[index4].next_byte
                                };
                                binaryWriter.Write(buffer14);
                                break;
                            case "two data":
                                byte[] buffer15 = new byte[1]
                                {
                this.frames[index1].commands[index4].cmdbyte
                                };
                                binaryWriter.Write(buffer15);
                                binaryWriter.Write(this.frames[index1].commands[index4].data);
                                break;
                            case "three":
                                byte[] buffer16 = new byte[2]
                                {
                this.frames[index1].commands[index4].cmdbyte,
                this.frames[index1].commands[index4].next_byte
                                };
                                binaryWriter.Write(buffer16);
                                binaryWriter.Write(this.frames[index1].commands[index4].data);
                                break;
                            default:
                                Console.WriteLine("Whoa, unrecognized type");
                                break;
                        }
                    }
                }
                binaryWriter.Close();
                output.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Caught exception in Write slp! ");
                Console.WriteLine(ex.ToString());
                Console.Write(ex.StackTrace);
            }
        }

        internal virtual byte[] bytefromint(int i)
        {
            return new byte[4]
            {
      (byte) i,
      (byte) (i >> 8),
      (byte) (i >> 16 /*0x10*/),
      (byte) (i >> 24)
            };
        }

        internal virtual byte[] bytefromshort(int i)
        {
            return new byte[2] { (byte)i, (byte)(i >> 8) };
        }

        internal static class RectangularArrays
        {
            public static int[][] RectangularIntArray(int size1, int size2)
            {
                int[][] numArray = new int[size1][];
                for (int index = 0; index < size1; ++index)
                    numArray[index] = new int[size2];
                return numArray;
            }
        }
    }
}