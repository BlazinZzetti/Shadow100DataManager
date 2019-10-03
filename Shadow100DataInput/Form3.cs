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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.InitialDirectory = Config.Instance.DatabaseLocation;
                sfd.AddExtension = true;
                sfd.DefaultExt = "xprofile";
                sfd.Filter = "xprofile (*.xprofile)|*.xprofile";

                var result = sfd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(sfd.FileName))
                {                    
                    //Double Check in case the file creation failed 
                    //if we attempted to create one.
                    if (!File.Exists(sfd.FileName))
                    {
                        var newProfile = new Profile(sfd.FileName);
                        newProfile.Save();
                        Close();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
