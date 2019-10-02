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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                var result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    //Double Check in case the file creation failed 
                    //if we attempted to create one.
                    if (File.Exists(Form1.configXmlString))
                    {
                        var configXml = new XmlDocument();
                        configXml.Load(Form1.configXmlString);

                        //Get Database Location stored in configXml.
                        foreach (XmlElement node in configXml.DocumentElement)
                        {
                            if (node.Name == "DatabaseLocation")
                            {
                                node.InnerText = fbd.SelectedPath;
                            }
                        }

                        configXml.Save(Form1.configXmlString);
                        Close();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
