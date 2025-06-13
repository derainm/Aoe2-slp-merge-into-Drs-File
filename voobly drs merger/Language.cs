using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace voobly_drs_merger
{
    public static class Language
    {
        private static bool executeProcess(string cmd, string exe)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = exe;
                startInfo.Arguments = cmd;
                startInfo.UseShellExecute = false;

                using (Process process = Process.Start(startInfo))
                {
                    Console.WriteLine($"Executing: rh.exe with arguments: \"{cmd}\"");
                    process.WaitForExit();
                    Console.WriteLine($"Process exited with code: {process.ExitCode}");

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public static void compileLanguageRes(string languageIni,string LanguageDll)
        { 
            StringBuilder sb = new StringBuilder();
            string cmd = string.Empty;

            string pathRc = languageIni.Replace(".ini", ".rc");
            string pathRes = languageIni.Replace(".ini", ".res");
            List<string> lst = File.ReadAllLines(languageIni, Encoding.UTF8).ToList();
            if (lst.Count() == 0)
            {
                MessageBox.Show("empty file .");
                return;
            }
            if (string.IsNullOrEmpty(LanguageDll))
            {
                MessageBox.Show("LANGUAGE DLL doesn't exist .");
                return;
            }
            ///////////////////////////////////////////////////////////////////////////
            Regex regex = new Regex(Regex.Escape("="));
            sb.AppendLine("STRINGTABLE");
            if (!string.IsNullOrEmpty(LanguageDll))
            {
                //we read the language from dll
                cmd = $"-open \"{LanguageDll}\"  -save lang.rc  -action extract -mask STRINGTABLE,,";
                executeProcess(cmd, @"rh.exe");
                if (File.Exists("lang.rc"))
                {
                    string languageFromDll = File.ReadAllLines("lang.rc").ElementAt(1);
                    sb.AppendLine(languageFromDll);
                }
                else
                {
                    sb.AppendLine("LANGUAGE LANG_ENGLISH, SUBLANG_ENGLISH_US");
                }
            }
            else //empty language dll
            {
                sb.AppendLine("LANGUAGE LANG_ENGLISH, SUBLANG_ENGLISH_US");
            }
            sb.AppendLine("{");
            foreach (var l in lst)
            {
                ushort id = 0;
                string stringvalue = l.Split('=').LastOrDefault();
                if (ushort.TryParse(l.Split('=').First(), out id))
                {
                    if (l.Contains("=") && !(l == Environment.NewLine))
                    {
                        string input = l.Replace("\"", "");
                        if (l.Contains("="))
                            input = regex.Replace(input, ", \t\"", 1);
                        string str = input + "\" ";
                        sb.AppendLine(str);
                    }

                    //sb.AppendLine($"{id},\"{stringvalue}\"");
                }
            }
            sb.AppendLine("}");
            File.WriteAllText(pathRc, sb.ToString(), Encoding.UTF8);
            sb.Clear();
            ///////////////////////////////////////////////////////////////////////////
            //rh.exe is https://www.angusj.com/resourcehacker/
            cmd = $" -open \"{pathRc}\" -save \"{pathRes}\" -action compile -log ";
            executeProcess(cmd, @"rh.exe");
        }
        public static void compileLanguagedll(string LanguageDll,string languageIni)
        {
            string pathRes = languageIni.Replace(".ini", ".res");  
            StringBuilder sb = new StringBuilder(); 
            string cmd = string.Empty;
            //generate script to build language dll with .res file
            sb.Clear();
            sb.AppendLine("[FILENAMES]");
            sb.AppendLine($"Open=\"{LanguageDll}\"");
            sb.AppendLine($"Save=\"{LanguageDll}\"");
            sb.AppendLine("[COMMANDS]");
            sb.AppendLine($"-addoverwrite \"{pathRes}\" , STRINGTABLE,,");
            File.WriteAllText("myscript.txt", sb.ToString());
            cmd = " -script myscript.txt";
            executeProcess(cmd, @"rh.exe"); 
        }

        public static void generateLanguageIni(string LanguageIni,string LanguageDll)
        {
            string cmd = $" -d  \"{LanguageIni}\" \"{LanguageDll}\"";
            executeProcess(cmd, "langconv.exe");
        }
    }
}
