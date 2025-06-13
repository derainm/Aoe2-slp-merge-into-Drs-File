using System;
using System.Collections.Generic;
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
