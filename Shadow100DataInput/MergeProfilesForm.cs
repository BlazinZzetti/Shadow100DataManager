using Shadow100DataInput.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shadow100DataInput
{
    public partial class MergeProfilesForm : Form
    {
        Common common = Common.Instance;

        public MergeProfilesForm()
        {
            InitializeComponent();

            Profile1SelectionComboBox.DataSource = null;
            Profile1SelectionComboBox.DataSource = new List<Profile>(common.Profiles);
            Profile1SelectionComboBox.SelectedIndex = 0;

            Profile2SelectionComboBox.DataSource = null;
            Profile2SelectionComboBox.DataSource = new List<Profile>(common.Profiles);
            Profile2SelectionComboBox.SelectedIndex = 1;

            generateNewMergedProfileName();
        }

        private void MergeProfilesButton_Click(object sender, EventArgs e)
        {
            var mergedProfile = Profile.NewMergedProfile(MergedProfileNameTextBox.Text, common.Profiles[Profile1SelectionComboBox.SelectedIndex], common.Profiles[Profile2SelectionComboBox.SelectedIndex]);

            mergedProfile.Save();

            //Need to name check.

            Close();
        }

        private void Profile1SelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Profile1SelectionComboBox.SelectedIndex == Profile2SelectionComboBox.SelectedIndex)
            {
                Profile2SelectionComboBox.SelectedIndex = (Profile1SelectionComboBox.SelectedIndex == 0) ? 1 : 0;
            }

            generateNewMergedProfileName();
        }

        private void Profile2SelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Profile1SelectionComboBox.SelectedIndex == Profile2SelectionComboBox.SelectedIndex)
            {
                Profile1SelectionComboBox.SelectedIndex = (Profile2SelectionComboBox.SelectedIndex == 0) ? 1 : 0;
            }
            generateNewMergedProfileName();
        }

        private void generateNewMergedProfileName()
        {
            if (Profile1SelectionComboBox.SelectedIndex >= 0 && Profile2SelectionComboBox.SelectedIndex >= 0)
            {
                MergedProfileNameTextBox.Text = common.Profiles[Profile1SelectionComboBox.SelectedIndex] + "_" + common.Profiles[Profile2SelectionComboBox.SelectedIndex] + "_Merged";
            }
        }
    }
}
