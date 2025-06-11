using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
 

namespace voobly_drs_merger
{
    public static class DllResourceExtractor
    {
        // --- P/Invoke Definitions ---

        // Constants for LoadLibraryEx flags
        private const uint LOAD_LIBRARY_AS_DATAFILE = 0x00000002;
        private const uint LOAD_LIBRARY_AS_IMAGE_RESOURCE = 0x00000020; // For newer resource loading behavior

        // Resource Types (Common ones, many more exist)
        private const uint RT_CURSOR = 1;       // Cursor
        private const uint RT_BITMAP = 2;       // Bitmap
        private const uint RT_ICON = 3;         // Icon
        private const uint RT_MENU = 4;         // Menu
        private const uint RT_DIALOG = 5;       // Dialog box
        private const uint RT_STRING = 6;       // String table
        private const uint RT_FONTDIR = 7;      // Font directory
        private const uint RT_FONT = 8;         // Font
        private const uint RT_ACCELERATOR = 9;  // Accelerator table
        private const uint RT_RCDATA = 10;      // Raw data
        private const uint RT_MESSAGETABLE = 11; // Message table
        private const uint RT_GROUP_CURSOR = 12; // Group cursor (for .ico files)
        private const uint RT_GROUP_ICON = 14;   // Group icon (for .ico files)
        private const uint RT_VERSION = 16;      // Version information
        private const uint RT_DLGINCLUDE = 17;   // Dialog include
        private const uint RT_PLUGPLAY = 19;     // Plug and Play
        private const uint RT_VXD = 20;          // VXD
        private const uint RT_ANICURSOR = 21;    // Animated cursor
        private const uint RT_ANIICON = 22;      // Animated icon
        private const uint RT_HTML = 23;         // HTML resource
        private const uint RT_MANIFEST = 24;     // Manifest (e.g., for UAC)

        // Helper for resource names/types. Resources can be identified by integer ID or string name.
        // If the high-order word is 0, the low-order word is the integer ID.
        // Otherwise, it's a pointer to a null-terminated string.
        private static bool IS_INTRESOURCE(IntPtr value)
        {
            // Check if the pointer represents an integer ID (high-order word is zero)
            return ((ulong)value >> 16) == 0;
        }

        private static string GetResourceIdentifier(IntPtr identifier)
        {
            if (IS_INTRESOURCE(identifier))
            {
                return $"#{identifier.ToInt32()}"; // Return as "#ID" for integer IDs
            }
            else
            {
                return Marshal.PtrToStringUni(identifier); // Return as string
            }
        }

        // P/Invoke Delegates for Enumeration Callbacks
        public delegate bool EnumResTypeProc(IntPtr hModule, IntPtr lpszType, IntPtr lParam);
        public delegate bool EnumResNameProc(IntPtr hModule, IntPtr lpszType, IntPtr lpszName, IntPtr lParam);
        public delegate bool EnumResLangProc(IntPtr hModule, IntPtr lpszType, IntPtr lpszName, ushort wLanguage, IntPtr lParam);

        // P/Invoke Function Declarations
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr LoadLibraryEx(string lpFileName, IntPtr hFile, uint dwFlags);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool FreeLibrary(IntPtr hModule);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool EnumResourceTypes(IntPtr hModule, EnumResTypeProc lpEnumFunc, IntPtr lParam);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool EnumResourceNames(IntPtr hModule, IntPtr lpszType, EnumResNameProc lpEnumFunc, IntPtr lParam);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool EnumResourceLanguages(IntPtr hModule, IntPtr lpszType, IntPtr lpszName, EnumResLangProc lpEnumFunc, IntPtr lParam);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr FindResource(IntPtr hModule, IntPtr lpName, IntPtr lpType);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr LoadResource(IntPtr hModule, IntPtr hResInfo);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr LockResource(IntPtr hResData);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint SizeofResource(IntPtr hModule, IntPtr hResInfo);

        // --- Data Structures to hold extracted resources ---

        public class ResourceEntry
        {
            public string Type { get; set; }
            public string Name { get; set; }
            public ushort LanguageId { get; set; }
            public byte[] Data { get; set; }
            public int Size { get; set; }

            public override string ToString()
            {
                return $"Type: {Type}, Name: {Name}, Lang: {LanguageId}, Size: {Size} bytes";
            }
        }

        public class StringTableEntry
        {
            public uint Id { get; set; }
            public ushort LanguageId { get; set; }
            public string Value { get; set; }

            public override string ToString()
            {
                return $"ID: {Id}, Lang: {LanguageId}, Value: \"{Value}\"";
            }
        }

        // --- Main Resource Extraction Logic ---

        /// <summary>
        /// Extracts all resources from a specified DLL file.
        /// </summary>
        /// <param name="dllPath">The full path to the DLL file.</param>
        /// <param name="extractedResources">A list to populate with raw resource data.</param>
        /// <param name="extractedStrings">A list to populate with parsed string table entries.</param>
        /// <returns>True if the DLL was processed, false otherwise.</returns>
        public static bool ExtractAllResources(string dllPath , string outFile )
        {
            var extractedResources = new List<ResourceEntry>();
            var extractedStrings = new List<StringTableEntry>();

            IntPtr hModule = IntPtr.Zero;
            try
            {
                // Load the DLL as a data file for resource access
                hModule = LoadLibraryEx(dllPath, IntPtr.Zero, LOAD_LIBRARY_AS_DATAFILE);
                if (hModule == IntPtr.Zero)
                {
                    Console.WriteLine($"Failed to load library: {dllPath}. Error: {Marshal.GetLastWin32Error()}");
                    return false;
                }

                // Start enumeration of resource types
                EnumResourceTypes(hModule,
                    (hMod, lpszType, lParam) =>
                    {
                        // For each resource type, enumerate its names
                        EnumResourceNames(hMod, lpszType,
                            (hMod2, lpszType2, lpszName, lParam2) =>
                            {
                                // For each resource name, enumerate its languages
                                EnumResourceLanguages(hMod2, lpszType2, lpszName,
                                    (hMod3, lpszType3, lpszName3, wLanguage, lParam3) =>
                                    {
                                        string resourceType = GetResourceIdentifier(lpszType3);
                                        string resourceName = GetResourceIdentifier(lpszName3);

                                        if (lpszType3.ToInt32() == RT_STRING) // Handle string tables specifically
                                        {
                                            ParseStringTableBlock(hMod3, lpszName3, wLanguage, extractedStrings);
                                        }
                                        else // For all other resource types, extract raw data
                                        {
                                            ExtractRawResourceData(hMod3, lpszType3, lpszName3, wLanguage, extractedResources);
                                        }
                                        return true; // Continue enumeration of languages
                                    }, IntPtr.Zero);
                                return true; // Continue enumeration of names
                            }, IntPtr.Zero);
                        return true; // Continue enumeration of types
                    }, IntPtr.Zero);

                List<string> lst = new List<string>();
                foreach(var r in extractedStrings)
                {  
                    lst.Add($"{r.Id}={r.Value.Replace("\n", "\\n")}");
                }
                File.WriteAllLines(outFile, lst.ToArray(), Encoding.UTF8);
                return true;
            }
            finally
            {
                if (hModule != IntPtr.Zero)
                {
                    FreeLibrary(hModule);
                }
            }
        }

        /// <summary>
        /// Extracts the raw byte data for a given resource.
        /// </summary>
        private static void ExtractRawResourceData(IntPtr hModule, IntPtr lpszType, IntPtr lpszName, ushort wLanguage, List<ResourceEntry> extractedResources)
        {
            IntPtr hResInfo = FindResource(hModule, lpszName, lpszType);
            if (hResInfo == IntPtr.Zero)
            {
                // Console.WriteLine($"Error finding resource for {GetResourceIdentifier(lpszType)}, {GetResourceIdentifier(lpszName)}, Lang: {wLanguage}. Error: {Marshal.GetLastWin32Error()}");
                return;
            }

            IntPtr hResData = LoadResource(hModule, hResInfo);
            if (hResData == IntPtr.Zero)
            {
                // Console.WriteLine($"Error loading resource for {GetResourceIdentifier(lpszType)}, {GetResourceIdentifier(lpszName)}, Lang: {wLanguage}. Error: {Marshal.GetLastWin32Error()}");
                return;
            }

            IntPtr pResource = LockResource(hResData);
            if (pResource == IntPtr.Zero)
            {
                // Console.WriteLine($"Error locking resource for {GetResourceIdentifier(lpszType)}, {GetResourceIdentifier(lpszName)}, Lang: {wLanguage}. Error: {Marshal.GetLastWin32Error()}");
                return;
            }

            uint size = SizeofResource(hModule, hResInfo);
            if (size == 0)
            {
                // Console.WriteLine($"Resource size is 0 for {GetResourceIdentifier(lpszType)}, {GetResourceIdentifier(lpszName)}, Lang: {wLanguage}.");
                return;
            }

            byte[] buffer = new byte[size];
            Marshal.Copy(pResource, buffer, 0, (int)size);

            extractedResources.Add(new ResourceEntry
            {
                Type = GetResourceIdentifier(lpszType),
                Name = GetResourceIdentifier(lpszName),
                LanguageId = wLanguage,
                Data = buffer,
                Size = (int)size
            });
        }

        /// <summary>
        /// Parses a string table block and adds individual strings to the list.
        /// </summary>
        /// <param name="hModule">Handle to the module.</param>
        /// <param name="lpszName">The integer ID of the string block (e.g., #1 for IDs 0-15, #2 for 16-31, etc.).</param>
        /// <param name="wLanguage">The language ID.</param>
        /// <param name="extractedStrings">The list to add parsed strings to.</param>
        private static void ParseStringTableBlock(IntPtr hModule, IntPtr lpszName, ushort wLanguage, List<StringTableEntry> extractedStrings)
        {
            IntPtr hResInfo = FindResource(hModule, lpszName, new IntPtr(RT_STRING));
            if (hResInfo == IntPtr.Zero) return;

            IntPtr hResData = LoadResource(hModule, hResInfo);
            if (hResData == IntPtr.Zero) return;

            IntPtr pResource = LockResource(hResData);
            if (pResource == IntPtr.Zero) return;

            uint size = SizeofResource(hModule, hResInfo);
            if (size == 0) return;

            IntPtr currentPtr = pResource;
            int resourceBlockId = lpszName.ToInt32(); // The ID of the block, e.g., 1, 2, 3...

            for (int i = 0; i < 16; i++) // A string table block contains up to 16 strings
            {
                if ((long)currentPtr - (long)pResource >= size)
                {
                    break; // Reached end of resource data
                }

                // Read the length of the string (WORD)
                short length = Marshal.ReadInt16(currentPtr);
                length++;
                currentPtr = (IntPtr)((long)currentPtr + 2); // Move past the length

                if (length > 0)
                {
                    // Read the string itself (Unicode)
                    byte[] buffer = new byte[length * 2];
                    Marshal.Copy(currentPtr, buffer, 0, buffer.Length);
                    string value = Encoding.Unicode.GetString(buffer); 

                    uint stringId = (uint)((resourceBlockId - 1) * 16 + i); // Calculate the actual string ID

                    extractedStrings.Add(new StringTableEntry
                    {
                        Id = stringId,
                        LanguageId = wLanguage,
                        Value = value
                    });
                }

                currentPtr = (IntPtr)((long)currentPtr + length * 2); // Move to the next string entry
            }
        }

 
    }
}
