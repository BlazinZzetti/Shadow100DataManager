using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Shadow100DataInput.Classes
{
    class Common
    {
        private static Common instance = null;

        private string configXmlString = "config.xml";
        private XmlDocument xml = new XmlDocument();

        private string databaseLocation;
        private int profileCount;
        private int profileIndex;

        private List<Profile> profiles;
        private List<Level> levels;

        private Common()
        {
            xml = new XmlDocument();

            databaseLocation = String.Empty;
            profileCount = 0;
            profileIndex = 0;
        }

        public static Common Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Common();
                }
                return instance;
            }
        }

        public string DatabaseLocation
        {
            get
            {
                return databaseLocation;
            }
            set
            {
                //TODO: add directory check here since this should only be a valid directory.
                databaseLocation = value;
            }
        }

        public List<Profile> Profiles
        {
            get
            {
                return profiles;
            }

            set
            {
                profiles = value;
            }
        }

        public List<Level> Levels
        {
            get
            {
                return levels;
            }

            set
            {
                levels = value;
            }
        }

        public int ProfileCount
        {
            get
            {
                return profileCount;
            }
            set
            {
                profileCount = value;
            }
        }

        public int ProfileIndex
        {
            get
            {
                return profileIndex;
            }
            set
            {
                profileIndex = value;
            }
        }

        public void LoadConfigFile()
        {
            //Check if config file exists before trying to use it.
            if (!File.Exists(configXmlString))
            {
                //Save will create a file with default parameters from initialization.
                Save();
            }

            //Double Check in case the file creation failed 
            //if we attempted to create one.
            if (File.Exists(configXmlString))
            {
                xml.Load(configXmlString);
                //Get Database Location stored in configXml.
                foreach (XmlElement node in xml.DocumentElement)
                {
                    if (node.Name == "DatabaseLocation")
                    {
                        databaseLocation = node.InnerText;
                    }
                    if (node.Name == "ProfilesData")
                    {
                        profileIndex = Int32.Parse(node.GetAttribute("index"));
                        profileCount = Int32.Parse(node.InnerText);
                    }
                }
            }
            else
            {
                MessageBox.Show("Config Xml File Load Failed.");
            }
        }

        public void Save()
        {
            xml = new XmlDocument();

            var baseNode = xml.CreateElement("Config");

            var databaseLocationNode = xml.CreateElement("DatabaseLocation");
            databaseLocationNode.InnerText = databaseLocation;

            var profilesDataNote = xml.CreateElement("ProfilesData");
            profilesDataNote.InnerText = profileCount.ToString(); // How many are there?
            profilesDataNote.SetAttribute("index", profileIndex.ToString());

            baseNode.AppendChild(databaseLocationNode);
            baseNode.AppendChild(profilesDataNote);

            xml.AppendChild(baseNode);

            xml.Save(configXmlString);
        }        
    }
}
