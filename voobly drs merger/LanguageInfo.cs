using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voobly_drs_merger
{
    public class LanguageInfo
    {
        public string DisplayName { get; set; }
        public ushort LanguageId { get; set; } // ushort to match LANGID type

        public LanguageInfo(string displayName, ushort languageId)
        {
            DisplayName = displayName;
            LanguageId = languageId;
        }

        // This override is crucial for the ComboBox to display the DisplayName
        public override string ToString()
        {
            return DisplayName;
        }
    }
}
