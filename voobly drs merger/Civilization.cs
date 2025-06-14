using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace voobly_drs_merger
{

    // REMARQUE : Le code généré peut nécessiter au moins .NET Framework 4.5 ou .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class configuration
    {

        private string nameField;

        private string pathField;

        private configurationCivilizations civilizationsField;

        private string gameField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string path
        {
            get
            {
                return this.pathField;
            }
            set
            {
                this.pathField = value;
            }
        }

        /// <remarks/>
        public configurationCivilizations civilizations
        {
            get
            {
                return this.civilizationsField;
            }
            set
            {
                this.civilizationsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string game
        {
            get
            {
                return this.gameField;
            }
            set
            {
                this.gameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class configurationCivilizations
    {

        private configurationCivilizationsCivilization[] civilizationField;

        private ushort langIdField;

        private ushort descIdField;

        private ushort aiNameOffsetField;

        private ushort uiBaseIdField;

        private byte uiStrideField;

        private byte uiOffsetField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("civilization")]
        public configurationCivilizationsCivilization[] civilization
        {
            get
            {
                return this.civilizationField;
            }
            set
            {
                this.civilizationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort langId
        {
            get
            {
                return this.langIdField;
            }
            set
            {
                this.langIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort descId
        {
            get
            {
                return this.descIdField;
            }
            set
            {
                this.descIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort aiNameOffset
        {
            get
            {
                return this.aiNameOffsetField;
            }
            set
            {
                this.aiNameOffsetField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort uiBaseId
        {
            get
            {
                return this.uiBaseIdField;
            }
            set
            {
                this.uiBaseIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte uiStride
        {
            get
            {
                return this.uiStrideField;
            }
            set
            {
                this.uiStrideField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte uiOffset
        {
            get
            {
                return this.uiOffsetField;
            }
            set
            {
                this.uiOffsetField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class configurationCivilizationsCivilization
    {

        private byte idField;

        private string nameField;

        private string soundFileField;

        private ushort scoutUnitField;

        private ushort uniqueUnitField;

        private ushort eliteUniqueUnitField;

        private short uniqueUnitLineField;

        private ushort uniqueUnitUpgradeField;

        private ushort uniqueResearchField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string soundFile
        {
            get
            {
                return this.soundFileField;
            }
            set
            {
                this.soundFileField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort scoutUnit
        {
            get
            {
                return this.scoutUnitField;
            }
            set
            {
                this.scoutUnitField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort uniqueUnit
        {
            get
            {
                return this.uniqueUnitField;
            }
            set
            {
                this.uniqueUnitField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort eliteUniqueUnit
        {
            get
            {
                return this.eliteUniqueUnitField;
            }
            set
            {
                this.eliteUniqueUnitField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public short uniqueUnitLine
        {
            get
            {
                return this.uniqueUnitLineField;
            }
            set
            {
                this.uniqueUnitLineField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort uniqueUnitUpgrade
        {
            get
            {
                return this.uniqueUnitUpgradeField;
            }
            set
            {
                this.uniqueUnitUpgradeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort uniqueResearch
        {
            get
            {
                return this.uniqueResearchField;
            }
            set
            {
                this.uniqueResearchField = value;
            }
        }
    }


    public static class civilization
    { 
        public static configuration defaultAocCivXmlParser()
        {
            string xmlString =
            @"<?xml version=""1.0"" encoding=""utf-8""?>
                <configuration game=""age2_x1"">
                    <name>Age of Empires II: The Conquerors Expansion</name>
                    <path>The Conquerors</path>
                    <civilizations langId=""10230"" descId=""20150"" aiNameOffset=""140"" uiBaseId=""51100"" uiStride=""20"" uiOffset=""2"">
                    <civilization id=""0"" name=""gaia"" soundFile=""stream\random mp3"" scoutUnit=""448"" uniqueUnit=""0"" eliteUniqueUnit=""0"" uniqueUnitLine=""0"" uniqueUnitUpgrade=""0"" uniqueResearch=""0"" />
                    <civilization id=""2"" name=""briton"" soundFile=""stream\british mp3"" scoutUnit=""448"" uniqueUnit=""8"" eliteUniqueUnit=""530"" uniqueUnitLine=""-277"" uniqueUnitUpgrade=""360"" uniqueResearch=""3"" />
                    <civilization id=""6"" name=""frankish"" soundFile=""stream\french mp3"" scoutUnit=""448"" uniqueUnit=""281"" eliteUniqueUnit=""531"" uniqueUnitLine=""-272"" uniqueUnitUpgrade=""363"" uniqueResearch=""83"" />
                    <civilization id=""7"" name=""gothic"" soundFile=""stream\goth mp3"" scoutUnit=""448"" uniqueUnit=""41"" eliteUniqueUnit=""555"" uniqueUnitLine=""-279"" uniqueUnitUpgrade=""365"" uniqueResearch=""16"" />
                    <civilization id=""16"" name=""teutonic"" soundFile=""stream\teuton mp3"" scoutUnit=""448"" uniqueUnit=""25"" eliteUniqueUnit=""554"" uniqueUnitLine=""-273"" uniqueUnitUpgrade=""364"" uniqueResearch=""11"" />
                    <civilization id=""9"" name=""japanese"" soundFile=""stream\japanese mp3"" scoutUnit=""448"" uniqueUnit=""291"" eliteUniqueUnit=""560"" uniqueUnitLine=""-274"" uniqueUnitUpgrade=""366"" uniqueResearch=""59"" />
                    <civilization id=""5"" name=""chinese"" soundFile=""stream\chinese mp3"" scoutUnit=""448"" uniqueUnit=""73"" eliteUniqueUnit=""559"" uniqueUnitLine=""-280"" uniqueUnitUpgrade=""362"" uniqueResearch=""52"" />
                    <civilization id=""3"" name=""byzantine"" soundFile=""stream\byzantin mp3"" scoutUnit=""448"" uniqueUnit=""40"" eliteUniqueUnit=""553"" uniqueUnitLine=""-281"" uniqueUnitUpgrade=""361"" uniqueResearch=""61"" />
                    <civilization id=""13"" name=""persian"" soundFile=""stream\persian mp3"" scoutUnit=""448"" uniqueUnit=""239"" eliteUniqueUnit=""558"" uniqueUnitLine=""-271"" uniqueUnitUpgrade=""367"" uniqueResearch=""7"" />
                    <civilization id=""14"" name=""saracen"" soundFile=""stream\saracen mp3"" scoutUnit=""448"" uniqueUnit=""282"" eliteUniqueUnit=""556"" uniqueUnitLine=""-276"" uniqueUnitUpgrade=""368"" uniqueResearch=""9"" />
                    <civilization id=""17"" name=""turkish"" soundFile=""stream\turk mp3"" scoutUnit=""448"" uniqueUnit=""46"" eliteUniqueUnit=""557"" uniqueUnitLine=""-278"" uniqueUnitUpgrade=""369"" uniqueResearch=""10"" />
                    <civilization id=""18"" name=""viking"" soundFile=""stream\viking mp3"" scoutUnit=""448"" uniqueUnit=""692"" eliteUniqueUnit=""694"" uniqueUnitLine=""-282"" uniqueUnitUpgrade=""398"" uniqueResearch=""49"" />
                    <civilization id=""12"" name=""mongol"" soundFile=""stream\mongol mp3"" scoutUnit=""448"" uniqueUnit=""11"" eliteUniqueUnit=""561"" uniqueUnitLine=""-275"" uniqueUnitUpgrade=""371"" uniqueResearch=""6"" />
                    <civilization id=""4"" name=""celtic"" soundFile=""stream\celt mp3"" scoutUnit=""448"" uniqueUnit=""232"" eliteUniqueUnit=""534"" uniqueUnitLine=""-269"" uniqueUnitUpgrade=""370"" uniqueResearch=""5"" />
                    <civilization id=""15"" name=""spanish"" soundFile=""stream\spanish mp3"" scoutUnit=""448"" uniqueUnit=""771"" eliteUniqueUnit=""773"" uniqueUnitLine=""-264"" uniqueUnitUpgrade=""60"" uniqueResearch=""440"" />
                    <civilization id=""1"" name=""aztec"" soundFile=""stream\aztecs mp3"" scoutUnit=""751"" uniqueUnit=""725"" eliteUniqueUnit=""726"" uniqueUnitLine=""-268"" uniqueUnitUpgrade=""432"" uniqueResearch=""24"" />
                    <civilization id=""11"" name=""mayan"" soundFile=""stream\mayans mp3"" scoutUnit=""751"" uniqueUnit=""763"" eliteUniqueUnit=""765"" uniqueUnitLine=""-266"" uniqueUnitUpgrade=""27"" uniqueResearch=""4"" />
                    <civilization id=""8"" name=""hun"" soundFile=""stream\huns mp3"" scoutUnit=""448"" uniqueUnit=""755"" eliteUniqueUnit=""757"" uniqueUnitLine=""-265"" uniqueUnitUpgrade=""2"" uniqueResearch=""21"" />
                    <civilization id=""10"" name=""korean"" soundFile=""stream\koreans mp3"" scoutUnit=""448"" uniqueUnit=""827"" eliteUniqueUnit=""829"" uniqueUnitLine=""-270"" uniqueUnitUpgrade=""450"" uniqueResearch=""445"" />
                    </civilizations>
                </configuration>";
            configuration civs = null;
            try
            {
                // Create an XmlSerializer for the Bookstore class
                XmlSerializer serializer = new XmlSerializer(typeof(configuration));

                // Use a StringReader to read the XML string
                using (StringReader reader = new StringReader(xmlString))
                {
                    // Deserialize the XML into a civ configuration object
                    civs = (configuration)serializer.Deserialize(reader);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return civs;
        }



        public static configuration XmlParserCiv(string path)
        {

            string xmlString = File.ReadAllText(path);
            configuration civs = null;
            try
            {
                // Create an XmlSerializer for the Bookstore class
                XmlSerializer serializer = new XmlSerializer(typeof(configuration));

                // Use a StringReader to read the XML string
                using (StringReader reader = new StringReader(xmlString))
                {
                    // Deserialize the XML into a civ configuration object
                    civs = (configuration)serializer.Deserialize(reader);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return civs;
        }

        public static void XmlWriter(configuration civ,string filePath)
        { 
            try
            {
                // Create an XmlSerializer for the civilization class
                XmlSerializer serializer = new XmlSerializer(typeof(configuration));
                using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    // Serialize the Bookstore object to the file
                    serializer.Serialize(writer, civ,ns);
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }
    }
}
