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
        private enum UserMode
        {
            Input,
            Search,
        }

        private UserMode currentUserMode = UserMode.Input;

        private List<Profile> profiles;
        private List<Level> levels;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDatabase();
            InitalizeLevelData();
            InitializeUI();
        }

        public void LoadDatabase()
        {
            Config.Instance.LoadConfigFile();
            //Check if a location exists.
            while (Config.Instance.DatabaseLocation == string.Empty || !Directory.Exists(Config.Instance.DatabaseLocation))
            {
                Form2 setDatabaseLocationForm = new Form2();
                setDatabaseLocationForm.ShowDialog();
            }

            //Check for profiles.
            profiles = new List<Profile>();
            var xProfileFiles = new List<string>();

            do
            {
                xProfileFiles = Directory.GetFiles(Config.Instance.DatabaseLocation, "*.xprofile").ToList();

                //Do we have any profiles.
                if (xProfileFiles.Count > 0)
                {
                    foreach (string xProfileFile in xProfileFiles)
                    {
                        profiles.Add(new Profile(xProfileFile));
                    }

                    Config.Instance.ProfileCount = profiles.Count();
                }
                else
                {
                    Form3 createFirstProfileForm = new Form3();
                    createFirstProfileForm.ShowDialog();
                }
            }
            while (xProfileFiles.Count == 0);
        }

        private void InitalizeLevelData()
        {
            levels = new List<Level>();

            levels.Add(new Level()
            {
                Name = "Westopolis",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Normal, Level.MissionType.Hero }
            });

            levels.Add(new Level()
            {
                Name = "Digital Curcuit",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Hero }
            });

            levels.Add(new Level()
            {
                Name = "Glyphic Canyon",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Normal, Level.MissionType.Hero }
            });

            levels.Add(new Level()
            {
                Name = "Lethal Highway",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Hero }
            });

            levels.Add(new Level()
            {
                Name = "Cryptic Castle",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Normal, Level.MissionType.Hero }
            });

            levels.Add(new Level()
            {
                Name = "Prison Island",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Normal, Level.MissionType.Hero }
            });

            levels.Add(new Level()
            {
                Name = "Circus Park",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Normal, Level.MissionType.Hero }
            });

            levels.Add(new Level()
            {
                Name = "Central City",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Hero }
            });

            levels.Add(new Level()
            {
                Name = "The Doom",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Normal, Level.MissionType.Hero }
            });

            levels.Add(new Level()
            {
                Name = "Sky Troops",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Normal, Level.MissionType.Hero }
            });

            levels.Add(new Level()
            {
                Name = "Mad Matrix",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Normal, Level.MissionType.Hero }
            });

            levels.Add(new Level()
            {
                Name = "Death Ruins",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Hero }
            });

            levels.Add(new Level()
            {
                Name = "The ARK",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Normal }
            });

            levels.Add(new Level()
            {
                Name = "Air Fleet",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Normal, Level.MissionType.Hero }
            });

            levels.Add(new Level()
            {
                Name = "Iron Jungle",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Normal, Level.MissionType.Hero }
            });

            levels.Add(new Level()
            {
                Name = "Space Gadget",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Normal, Level.MissionType.Hero }
            });

            levels.Add(new Level()
            {
                Name = "Lost Impact",
                Missions = new List<Level.MissionType>() { Level.MissionType.Normal, Level.MissionType.Hero }
            });

            levels.Add(new Level()
            {
                Name = "GUN Fortress",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Hero }
            });

            levels.Add(new Level()
            {
                Name = "Black Comet",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Hero }
            });

            levels.Add(new Level()
            {
                Name = "Lava Shelter",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Hero }
            });

            levels.Add(new Level()
            {
                Name = "Cosmic Fall",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Hero }
            });

            levels.Add(new Level()
            {
                Name = "Final Haunt",
                Missions = new List<Level.MissionType>() { Level.MissionType.Dark, Level.MissionType.Hero }
            });

            levels.Add(new Level()
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
            profileComboBox.DataSource = profiles;

            levelComboBox.DataSource = null;
            levelComboBox.DataSource = levels;
            levelComboBox.SelectedIndex = 0;

            //Make the assumption that Westopolis has already been created.
            missionComboBox.DataSource = null;
            missionComboBox.DataSource = levels[0].Missions;
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
            missionComboBox.DataSource = levels[((ComboBox)sender).SelectedIndex].Missions;
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

            timeEntry.Level = levels[levelComboBox.SelectedIndex];
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

            profiles[profileComboBox.SelectedIndex].TimeEntries.Add(timeEntry);
            profiles[profileComboBox.SelectedIndex].Save();
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
