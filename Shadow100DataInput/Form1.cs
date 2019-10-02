using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Shadow100DataInput
{
    public partial class Form1 : Form
    {
        private XmlDocument configXml;
        public static string configXmlString = "config.xml";

        private string databaseLocation = "";

        public Form1()
        {
            InitializeComponent();
            //MessageBox.Show("Form1() Complete.");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("File Load Started.");
            LoadConfigFile();
            LoadDatabase();
        }

        private void InitializeConfigXml(XmlDocument xml)
        {
            var baseNode = xml.CreateElement("Config");

            var databaseLocationNode = xml.CreateElement("DatabaseLocation");
            databaseLocationNode.InnerText = String.Empty;

            var profilesDataNote = xml.CreateElement("ProfilesData");
            profilesDataNote.InnerText = "0"; // How many are there?
            profilesDataNote.SetAttribute("index", "0");

            baseNode.AppendChild(profilesDataNote);
            baseNode.AppendChild(databaseLocationNode);

            xml.AppendChild(baseNode);
        }

        private void LoadConfigFile()
        {
            //Check if we have initialized the config data.
            //If not, initialize.
            if (configXml == null)
            {
                configXml = new XmlDocument();

                //Check if config file exists before trying to use it.
                if (!File.Exists(configXmlString))
                {
                    //File.Create(configXmlString);
                    InitializeConfigXml(configXml);

                    configXml.Save(configXmlString);
                }

                //Double Check in case the file creation failed 
                //if we attempted to create one.
                if (File.Exists(configXmlString))
                {
                    configXml.Load(configXmlString);
                }
                else
                {
                    MessageBox.Show("Config Xml File Load Failed.");
                    this.Close();
                }
            }
            else //Config already initialized, update data.
            {
                //Double Check in case the file creation failed 
                //if we attempted to create one.
                if (File.Exists(configXmlString))
                {
                    configXml.Load(configXmlString);
                }
                else
                {
                    MessageBox.Show("Config Xml File Load Failed.");
                    this.Close();
                }
            }
        }

        private void LoadDatabase()
        {            
            if (configXml == null)
            {
                LoadConfigFile();
            }

            if (configXml != null)
            {
                //Check if a location exists.
                do
                {
                    //Get Database Location stored in configXml.
                    foreach (XmlElement node in configXml.DocumentElement)
                    {
                        if (node.Name == "DatabaseLocation")
                        {
                            databaseLocation = node.InnerText;
                        }
                    }

                    //Check if location string is empty or if it does not exists.
                    if (databaseLocation == string.Empty || !Directory.Exists(databaseLocation))
                    {
                        Form2 setDatabaseLocationForm = new Form2();
                        setDatabaseLocationForm.ShowDialog();
                        LoadConfigFile();
                    }                    
                }
                while (databaseLocation == string.Empty);

                //Check for profiles.
                var xProfiles = new List<string>();

                do
                {
                    xProfiles = Directory.GetFiles(databaseLocation, "*.xprofile").ToList();
                    if (xProfiles.Count > 0)
                    {
                        foreach (string xProfile in xProfiles)
                        {

                        }
                    }
                    else
                    {
                        Form3 createFirstProfileForm = new Form3();
                        createFirstProfileForm.ShowDialog();
                    }
                }
                while (xProfiles.Count == 0);               
            }
            else
            {
                MessageBox.Show("Database Load Failed.");
                this.Close();
            }
        }
    }
}
