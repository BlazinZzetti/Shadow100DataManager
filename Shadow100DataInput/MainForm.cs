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

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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
                xProfileFiles = Directory.GetFiles(Common.Instance.DatabaseLocation, "*.xprofile").ToList();

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
                    createFirstProfileForm.ShowDialog();
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
                Name = "Digital Curcuit",
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

                    timeMinutesTextBox.Text = "0";
                    timeSecondsTextBox.Text = "0";
                    timeMillisecondsTextBox.Text = "0";
                    videoLinkTextBox.Text = "";

                    break;
                case UserMode.Search:
                    submitSearchButton.Text = "Search";
                    TimeVideoReadOnlyState(true);

                    timeMinutesTextBox.Text = "";
                    timeSecondsTextBox.Text = "";
                    timeMillisecondsTextBox.Text = "";
                    videoLinkTextBox.Text = "";

                    break;
            }
        }

        private void TimeVideoReadOnlyState(bool readOnly)
        {
            timeMinutesTextBox.ReadOnly = readOnly;
            timeSecondsTextBox.ReadOnly = readOnly;
            timeMillisecondsTextBox.ReadOnly = readOnly;
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
            missionComboBox.DataSource = common.Levels[((ComboBox)sender).SelectedIndex].Missions;
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

        private void InputButtonPressed()
        {
            var timeEntry = new TimeEntry();

            timeEntry.Level = common.Levels[levelComboBox.SelectedIndex];
            timeEntry.MissionIndex = missionComboBox.SelectedIndex;
            timeEntry.Keys = new bool[] { keyCheckBox1.Checked,
                                          keyCheckBox2.Checked,
                                          keyCheckBox3.Checked,
                                          keyCheckBox4.Checked,
                                          keyCheckBox5.Checked };

            timeEntry.SamuraiBlade = (TimeEntry.WeaponState)samuraiBladeCheckBox.CheckState;
            timeEntry.SatelliteLaser = (TimeEntry.WeaponState)satelliteLaserCheckBox.CheckState;
            timeEntry.EggVacuum = (TimeEntry.WeaponState)eggVacuumCheckBox.CheckState;
            timeEntry.OmochaoGun = (TimeEntry.WeaponState)omochaoGunCheckBox.CheckState;
            timeEntry.HealCannon = (TimeEntry.WeaponState)healCannonCheckBox.CheckState;

            timeEntry.Time = TimeInMilliseconds(Int32.Parse(timeMinutesTextBox.Text), Int32.Parse(timeSecondsTextBox.Text), Int32.Parse(timeMillisecondsTextBox.Text) * 10);

            timeEntry.VideoLink = videoLinkTextBox.Text;

            //TODO: Check to see if an time entry already exists for these settings.
            //If so, check to see if the time you have entered is better.
            //If so, update the existing time without adding a new entry.
            //If not, reject entry with a message box explaining why.

            var profileMatch = common.Profiles[profileComboBox.SelectedIndex].FindTimeEntry(timeEntry);

            if (profileMatch != null )
            {
                if (profileMatch.Time > timeEntry.Time)
                {
                    profileMatch.Time = timeEntry.Time;
                    profileMatch.VideoLink = timeEntry.VideoLink;
                    common.Profiles[profileComboBox.SelectedIndex].Save();
                    MessageBox.Show("Time Updated");
                }
                else
                {
                    MessageBox.Show("Time not updated.");
                }
            }
            else
            {
                common.Profiles[profileComboBox.SelectedIndex].TimeEntries.Add(timeEntry);
                common.Profiles[profileComboBox.SelectedIndex].Save();
                MessageBox.Show("Time Added.");
            }
        }

        private uint TimeInMilliseconds(int minutes, int seconds, int milliseconds)
        {
            uint returnMilliseconds = 0;

            returnMilliseconds += (uint)minutes * 60000;
            returnMilliseconds += (uint)seconds * 1000;
            returnMilliseconds += (uint)milliseconds;

            return returnMilliseconds;
        }

        private void SearchButtonPressed()
        {
            throw new NotImplementedException();
        }
    }
}
