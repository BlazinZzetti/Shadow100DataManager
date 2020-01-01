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
    public partial class MainForm : Form
    {
        private enum UserMode
        {
            Input,
            Search,
        }

        private UserMode currentUserMode = UserMode.Input;

        Common common = Common.Instance;
        private bool afterFirstLoad;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshForm();
            afterFirstLoad = true;
        }

        private void RefreshForm()
        {
            InitalizeLevelData();
            LoadDatabase();
            InitializeUI();
        }

        public void LoadDatabase()
        {
            Common.Instance.LoadConfigFile();
            //Check if a location exists.
            while (common.DatabaseLocation == string.Empty || !Directory.Exists(common.DatabaseLocation))
            {
                StartDatabaseSetForm setDatabaseLocationForm = new StartDatabaseSetForm();
                setDatabaseLocationForm.ShowDialog();
            }

            //Check for profiles.
            common.Profiles = new List<Profile>();
            var xProfileFiles = new List<string>();

            do
            {
                xProfileFiles = Directory.GetFiles(Common.Instance.DatabaseLocation, "*.xshadowprofile").ToList();

                //Do we have any profiles.
                if (xProfileFiles.Count > 0)
                {
                    foreach (string xProfileFile in xProfileFiles)
                    {
                        common.Profiles.Add(new Profile(xProfileFile));
                    }

                    common.ProfileCount = common.Profiles.Count();
                }
                else
                {
                    StartupProfileCreationForm createFirstProfileForm = new StartupProfileCreationForm();
                    var result = createFirstProfileForm.ShowDialog();
                    //if(result == DialogResult.Cancel)
                    //{
                    //    Close();
                    //}
                }
            }
            while (xProfileFiles.Count == 0);
        }

        private void InitalizeLevelData()
        {
            common.Levels = new List<Level>();

            common.Levels.Add(new Level()
            {
                Name = "Westopolis",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Normal, Level.MissionType.Hero }
            });

            common.Levels.Add(new Level()
            {
                Name = "Digital Circuit",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Hero }
            });

            common.Levels.Add(new Level()
            {
                Name = "Glyphic Canyon",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Normal, Level.MissionType.Hero }
            });

            common.Levels.Add(new Level()
            {
                Name = "Lethal Highway",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Hero }
            });

            common.Levels.Add(new Level()
            {
                Name = "Cryptic Castle",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Normal, Level.MissionType.Hero }
            });

            common.Levels.Add(new Level()
            {
                Name = "Prison Island",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Normal, Level.MissionType.Hero }
            });

            common.Levels.Add(new Level()
            {
                Name = "Circus Park",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Normal, Level.MissionType.Hero }
            });

            common.Levels.Add(new Level()
            {
                Name = "Central City",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Hero }
            });

            common.Levels.Add(new Level()
            {
                Name = "The Doom",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Normal, Level.MissionType.Hero }
            });

            common.Levels.Add(new Level()
            {
                Name = "Sky Troops",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Normal, Level.MissionType.Hero }
            });

            common.Levels.Add(new Level()
            {
                Name = "Mad Matrix",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Normal, Level.MissionType.Hero }
            });

            common.Levels.Add(new Level()
            {
                Name = "Death Ruins",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Hero }
            });

            common.Levels.Add(new Level()
            {
                Name = "The ARK",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Normal }
            });

            common.Levels.Add(new Level()
            {
                Name = "Air Fleet",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Normal, Level.MissionType.Hero }
            });

            common.Levels.Add(new Level()
            {
                Name = "Iron Jungle",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Normal, Level.MissionType.Hero }
            });

            common.Levels.Add(new Level()
            {
                Name = "Space Gadget",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Normal, Level.MissionType.Hero }
            });

            common.Levels.Add(new Level()
            {
                Name = "Lost Impact",
                Missions = new List<Level.MissionType>() { Level.MissionType.Normal, Level.MissionType.Hero }
            });

            common.Levels.Add(new Level()
            {
                Name = "GUN Fortress",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Hero }
            });

            common.Levels.Add(new Level()
            {
                Name = "Black Comet",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Hero }
            });

            common.Levels.Add(new Level()
            {
                Name = "Lava Shelter",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Hero }
            });

            common.Levels.Add(new Level()
            {
                Name = "Cosmic Fall",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Hero }
            });

            common.Levels.Add(new Level()
            {
                Name = "Final Haunt",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Hero }
            });

            common.Levels.Add(new Level()
            {
                Name = "The Last Way",
                Missions = new List<Level.MissionType>() { Level.MissionType.Normal }
            });
        }

        private void InitializeUI()
        {
            UpdateUserMode(UserMode.Input);

            keyCheckBox1.Checked = false;
            keyCheckBox2.Checked = false;
            keyCheckBox3.Checked = false;
            keyCheckBox4.Checked = false;
            keyCheckBox5.Checked = false;

            samuraiBladeCheckBox.Checked = false;
            satelliteLaserCheckBox.Checked = false;
            eggVacuumCheckBox.Checked = false;
            omochaoGunCheckBox.Checked = false;
            healCannonCheckBox.Checked = false;

            profileComboBox.DataSource = null;
            profileComboBox.DataSource = common.Profiles;
            profileComboBox.SelectedIndex = common.ProfileIndex;

            levelComboBox.DataSource = null;
            levelComboBox.DataSource = common.Levels;
            levelComboBox.SelectedIndex = 0;

            //Make the assumption that Westopolis has already been created.
            missionComboBox.DataSource = null;
            missionComboBox.DataSource = common.Levels[0].Missions;
            missionComboBox.SelectedIndex = 0;
        }

        #region UserMode updates

        private void UpdateUserMode(UserMode userMode)
        {
            currentUserMode = userMode;

            inputToolStripMenuItem.Checked = userMode == UserMode.Input;
            searchToolStripMenuItem.Checked = userMode == UserMode.Search;

            switch (currentUserMode)
            {
                case UserMode.Input:
                    submitSearchButton.Text = "Submit";
                    TimeVideoReadOnlyState(false);

                    minutesNumericUpDown.Value = 0;
                    secondsNumericUpDown.Value = 0;
                    centiNumericUpDown.Value = 0;
                    videoLinkTextBox.Text = "";

                    break;
                case UserMode.Search:
                    submitSearchButton.Text = "Search";
                    TimeVideoReadOnlyState(true);

                    minutesNumericUpDown.Value = 0;
                    secondsNumericUpDown.Value = 0;
                    centiNumericUpDown.Value = 0;
                    videoLinkTextBox.Text = "";

                    break;
            }
        }

        private void TimeVideoReadOnlyState(bool readOnly)
        {
            minutesNumericUpDown.ReadOnly = readOnly;
            minutesNumericUpDown.Increment = (readOnly) ? 0 : 1;

            secondsNumericUpDown.ReadOnly = readOnly;
            secondsNumericUpDown.Increment = (readOnly) ? 0 : 1;

            centiNumericUpDown.ReadOnly = readOnly;
            centiNumericUpDown.Increment = (readOnly) ? 0 : 1;

            videoLinkTextBox.ReadOnly = readOnly;
        }

        private void inputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentUserMode != UserMode.Input)
            {
                UpdateUserMode(UserMode.Input);
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentUserMode != UserMode.Search)
            {
                UpdateUserMode(UserMode.Search);
            }
        }

        #endregion

        private void levelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            missionComboBox.DataSource = null;
            missionComboBox.DataSource = common.Levels[Math.Max(((ComboBox)sender).SelectedIndex, 0)].Missions;
            missionComboBox.SelectedIndex = 0;
        }

        #region Weapon Checkbox updates

        private CheckState UpdateWeaponLevel(CheckState checkState)
        {
            switch (checkState)
            {
                case CheckState.Unchecked:
                    return CheckState.Indeterminate;
                case CheckState.Indeterminate:
                    return CheckState.Checked;
                case CheckState.Checked:
                    return CheckState.Unchecked;
            }
            return CheckState.Unchecked;
        }

        private void samuraiBladeCheckBox_Click(object sender, EventArgs e)
        {
            samuraiBladeCheckBox.CheckState = UpdateWeaponLevel(samuraiBladeCheckBox.CheckState);     
        }

        private void satelliteLaserCheckBox_Click(object sender, EventArgs e)
        {
            satelliteLaserCheckBox.CheckState = UpdateWeaponLevel(satelliteLaserCheckBox.CheckState);
        }

        private void eggVacuumCheckBox_Click(object sender, EventArgs e)
        {
            eggVacuumCheckBox.CheckState = UpdateWeaponLevel(eggVacuumCheckBox.CheckState);
        }

        private void omochaoGunCheckBox_Click(object sender, EventArgs e)
        {
            omochaoGunCheckBox.CheckState = UpdateWeaponLevel(omochaoGunCheckBox.CheckState);
        }

        private void healCannonCheckBox_Click(object sender, EventArgs e)
        {
            healCannonCheckBox.CheckState = UpdateWeaponLevel(healCannonCheckBox.CheckState);
        }

        #endregion

        private void submitSearchButton_Click(object sender, EventArgs e)
        {
            switch (currentUserMode)
            {
                case UserMode.Input:
                    InputButtonPressed();
                    break;
                case UserMode.Search:
                    SearchButtonPressed();
                    break;
            }
        }

        private TimeEntry TimeEntryFromFormSettings(UserMode userMode)
        {
            var timeEntry = new TimeEntry();

            timeEntry.Level = common.Levels[levelComboBox.SelectedIndex];
            timeEntry.MissionIndex = missionComboBox.SelectedIndex;
            timeEntry.Keys = new bool[] { keyCheckBox1.Checked,
                                          keyCheckBox2.Checked,
                                          keyCheckBox3.Checked,
                                          keyCheckBox4.Checked,
                                          keyCheckBox5.Checked };

            timeEntry.UsesKeyDoor = usesKeyDoorCheckBox.Checked;
            timeEntry.NoCCG = noCCGCheckBox.Checked;

            timeEntry.SamuraiBlade = (TimeEntry.WeaponState)samuraiBladeCheckBox.CheckState;
            timeEntry.SatelliteLaser = (TimeEntry.WeaponState)satelliteLaserCheckBox.CheckState;
            timeEntry.EggVacuum = (TimeEntry.WeaponState)eggVacuumCheckBox.CheckState;
            timeEntry.OmochaoGun = (TimeEntry.WeaponState)omochaoGunCheckBox.CheckState;
            timeEntry.HealCannon = (TimeEntry.WeaponState)healCannonCheckBox.CheckState;

            if (userMode == UserMode.Input)
            {
                timeEntry.Time = common.TimeInMilliseconds((int)minutesNumericUpDown.Value, (int)secondsNumericUpDown.Value, (int)(centiNumericUpDown.Value * 10));

                timeEntry.VideoLink = videoLinkTextBox.Text;
            }

            return timeEntry;
        }

        private void InputButtonPressed()
        {
            var timeEntry = TimeEntryFromFormSettings(UserMode.Input);

            if (timeEntry.Time > 0)
            {

                var profileMatch = common.Profiles[profileComboBox.SelectedIndex].FindTimeEntry(timeEntry);

                if (profileMatch != null)
                {
                    if (profileMatch.Time > timeEntry.Time)
                    {
                        var confirmTime = new ConfirmUpdateForm(profileMatch.Time, timeEntry.Time);
                        var result = confirmTime.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            profileMatch.Time = timeEntry.Time;
                            profileMatch.VideoLink = timeEntry.VideoLink;
                            common.Profiles[profileComboBox.SelectedIndex].Save();
                            MessageBox.Show("Time Updated");
                        }
                        if (result == DialogResult.Cancel)
                        {
                            MessageBox.Show("Time not updated.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Better time exists.\n" + common.TimeInString(profileMatch.Time) + "\nTime not updated.");
                    }
                }
                else
                {
                    common.Profiles[profileComboBox.SelectedIndex].TimeEntries.Add(timeEntry);
                    common.Profiles[profileComboBox.SelectedIndex].Save();
                    MessageBox.Show("Time Added.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a time greater than 0.");
            }
        }

        private void SearchButtonPressed()
        {
            var timeEntry = TimeEntryFromFormSettings(UserMode.Search);

            var profileMatch = common.Profiles[profileComboBox.SelectedIndex].FindTimeEntry(timeEntry);

            if (profileMatch != null)
            {
                var timeInSegments = common.TimeInSegments(profileMatch.Time);
                minutesNumericUpDown.Value = timeInSegments[0];
                secondsNumericUpDown.Value = timeInSegments[1];
                centiNumericUpDown.Value = (timeInSegments[2] / 10);

                videoLinkTextBox.Text = profileMatch.VideoLink;
            }
            else
            {
                MessageBox.Show("Time not found for these settings.");
            }
        }

        private void setDatabaseFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            common.SetDatabaseFolderLocation();
            RefreshForm();
        }

        private void createProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            common.CreateNewProfile();
            RefreshForm();
        }

        private void profileComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (afterFirstLoad)
            {
                common.ProfileIndex = ((ComboBox)sender).SelectedIndex;
                common.Save();
            }
        }

        private void mergeProfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Check if a location exists.
            if (common.Profiles.Count >= 2)
            {
                MergeProfilesForm mergeProfilesForm = new MergeProfilesForm();
                mergeProfilesForm.ShowDialog();
                RefreshForm();
            }
            else
            {
                MessageBox.Show("More than 2 profiles need to be loaded to allow merging.");
            }
        }

        private void allEndingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Reports
                .GenerateAllEndingsReport(common.Profiles[common.ProfileIndex]));
        }

        private void hundoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Reports
                .GenerateHundoReport(common.Profiles[common.ProfileIndex]));
        }
    }
}
