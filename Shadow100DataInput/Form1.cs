using Shadow100DataInput.Classes;
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
            Config.Instance.LoadConfigFile();
            Config.Instance.LoadDatabase();
        }
    }
}
