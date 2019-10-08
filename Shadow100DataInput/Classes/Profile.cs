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
    class Profile
    {
        private string profileName;
        private List<TimeEntry> timeEntries;
        private string fileLocation;

        public List<TimeEntry> TimeEntries
        {
            get
            {
                return timeEntries;
            }
            set
            {
                timeEntries = value;
            }
        }

        public Profile()
        {
            timeEntries = new List<TimeEntry>();
        }

        public Profile(string filePathToXProfile)
        {
            timeEntries = new List<TimeEntry>();
            fileLocation = filePathToXProfile;
            XmlDocument xml = new XmlDocument();

            //Double Check in case the file creation failed 
            //if we attempted to create one.
            if (File.Exists(filePathToXProfile))
            {
                xml.Load(filePathToXProfile);

                profileName = xml.DocumentElement.GetAttribute("name");

                //Get Database Location stored in configXml.
                foreach (XmlElement node in xml.DocumentElement)
                {
                    if (node.Name == "TimeEntries")
                    {
                        foreach (XmlElement i in node.ChildNodes)
                        {
                            if (i.Name == "TimeEntry")
                            {
                                var timeEntry = new TimeEntry();

                                foreach (XmlElement j in i.ChildNodes)
                                {
                                    if (j.Name == "Level")
                                    {
                                        timeEntry.Level = new Level(Common.Instance.Levels.First(l => l.Name == j.InnerText));
                                    }
                                    if (j.Name == "Keys")
                                    {
                                        for (int k = 0; k < 5; k++)
                                        {
                                            timeEntry.Keys[k] = bool.Parse(j.ChildNodes[k].InnerText);
                                        }                                        
                                    }
                                    if (j.Name == "MissionIndex")
                                    {
                                        timeEntry.MissionIndex = int.Parse(j.InnerText);
                                    }
                                    if (j.Name == "WeaponStates")
                                    {
                                        timeEntry.SamuraiBlade = (TimeEntry.WeaponState)int.Parse(j.ChildNodes[0].InnerText);
                                        timeEntry.SatelliteLaser = (TimeEntry.WeaponState)int.Parse(j.ChildNodes[1].InnerText);
                                        timeEntry.EggVacuum = (TimeEntry.WeaponState)int.Parse(j.ChildNodes[2].InnerText);
                                        timeEntry.OmochaoGun = (TimeEntry.WeaponState)int.Parse(j.ChildNodes[3].InnerText);
                                        timeEntry.HealCannon = (TimeEntry.WeaponState)int.Parse(j.ChildNodes[4].InnerText);
                                    }
                                    if (j.Name == "Time")
                                    {
                                        timeEntry.Time = uint.Parse(j.InnerText);
                                    }
                                    if (j.Name == "VideoLink")
                                    {
                                        timeEntry.VideoLink = j.InnerText;
                                    }
                                }

                                TimeEntries.Add(timeEntry);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("xProfile File Load Failed.");
            }
        }

        public void Save()
        {
            var xml = new XmlDocument();

            var baseNode = xml.CreateElement("Profile");
            baseNode.SetAttribute("name", profileName);

            var timeEntriesNode = xml.CreateElement("TimeEntries");

            foreach (var timeEntry in TimeEntries)
            {
                var timeEntryNode = xml.CreateElement("TimeEntry");
                var levelNode = xml.CreateElement("Level");
                var keysNode = xml.CreateElement("Keys");
                var key1Node = xml.CreateElement("Key1");
                var key2Node = xml.CreateElement("Key2");
                var key3Node = xml.CreateElement("Key3");
                var key4Node = xml.CreateElement("Key4");
                var key5Node = xml.CreateElement("Key5");
                var missionIndexNode = xml.CreateElement("MissionIndex");
                var weaponStatesNode = xml.CreateElement("WeaponStates");
                var samuraiBladeNode = xml.CreateElement("SamuraiBlade");
                var satelliteLaserNode = xml.CreateElement("SatelliteLaser");
                var eggVacuumNode = xml.CreateElement("EggVacuum");
                var omochaoGunNode = xml.CreateElement("OmochaoGun");
                var healCannonNode = xml.CreateElement("HealCannon");
                var timeNode = xml.CreateElement("Time");
                var videoLinkNode = xml.CreateElement("VideoLink");

                levelNode.InnerText = timeEntry.Level.Name;

                key1Node.InnerText = timeEntry.Keys[0].ToString();
                key2Node.InnerText = timeEntry.Keys[1].ToString();
                key3Node.InnerText = timeEntry.Keys[2].ToString();
                key4Node.InnerText = timeEntry.Keys[3].ToString();
                key5Node.InnerText = timeEntry.Keys[4].ToString();

                missionIndexNode.InnerText = timeEntry.MissionIndex.ToString();

                samuraiBladeNode.InnerText = ((int)timeEntry.SamuraiBlade).ToString();
                satelliteLaserNode.InnerText = ((int)timeEntry.SatelliteLaser).ToString();
                eggVacuumNode.InnerText = ((int)timeEntry.EggVacuum).ToString();
                omochaoGunNode.InnerText = ((int)timeEntry.OmochaoGun).ToString();
                healCannonNode.InnerText = ((int)timeEntry.HealCannon).ToString();

                timeNode.InnerText = timeEntry.Time.ToString();

                videoLinkNode.InnerText = timeEntry.VideoLink;

                timeEntryNode.AppendChild(levelNode);

                keysNode.AppendChild(key1Node);
                keysNode.AppendChild(key2Node);
                keysNode.AppendChild(key3Node);
                keysNode.AppendChild(key4Node);
                keysNode.AppendChild(key5Node);

                timeEntryNode.AppendChild(keysNode);

                timeEntryNode.AppendChild(missionIndexNode);

                weaponStatesNode.AppendChild(samuraiBladeNode);
                weaponStatesNode.AppendChild(satelliteLaserNode);
                weaponStatesNode.AppendChild(eggVacuumNode);
                weaponStatesNode.AppendChild(omochaoGunNode);
                weaponStatesNode.AppendChild(healCannonNode);

                timeEntryNode.AppendChild(weaponStatesNode);

                timeEntryNode.AppendChild(timeNode);
                timeEntryNode.AppendChild(videoLinkNode);

                timeEntriesNode.AppendChild(timeEntryNode);
            }

            baseNode.AppendChild(timeEntriesNode);
            xml.AppendChild(baseNode);

            xml.Save(fileLocation);
        }

        public TimeEntry FindTimeEntry(TimeEntry timeEntry)
        {
            return timeEntries.Find(te => te.Level.Equals(timeEntry.Level)
                                       && te.MissionIndex == timeEntry.MissionIndex 
                                       && te.SamuraiBlade == timeEntry.SamuraiBlade
                                       && te.SatelliteLaser == timeEntry.SatelliteLaser
                                       && te.EggVacuum == timeEntry.EggVacuum
                                       && te.OmochaoGun == timeEntry.OmochaoGun
                                       && te.HealCannon == timeEntry.HealCannon);
        }

        public override string ToString()
        {
            return profileName;
        }
    }
}
