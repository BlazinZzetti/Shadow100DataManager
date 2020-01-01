using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shadow100DataInput.Classes
{
    class Reports
    {
        public static string GenerateAllEndingsReport(Profile profile)
        {
            var reportString = string.Empty;

            var AllMissionsCompleteableNoSPWReport = AllMissionsCompleteableNoSPW(profile);

            reportString += AllMissionsCompleteableNoSPWReport.Value;

            if (!AllMissionsCompleteableNoSPWReport.Key)
            {
                var OneOfEachEndStageReport = OneOfEachEndStage(profile);
                reportString += OneOfEachEndStageReport.Value;

                if (OneOfEachEndStageReport.Key)
                {
                    //Check if there is at least one valid path foreach ending.
                }
            }

            return reportString;
        }

        private static KeyValuePair<bool, string> OneOfEachEndStage(Profile profile)
        {
            var reportString = string.Empty;
            var oneOfEachEndStage = false;

            //Check for end stages
            oneOfEachEndStage = profile.TimeEntries.Any(te => te.Level.Name == "GUN Fortress" && te.Mission == Level.MissionType.Dark);
            oneOfEachEndStage &= profile.TimeEntries.Any(te => te.Level.Name == "GUN Fortress" && te.Mission == Level.MissionType.Hero);
            oneOfEachEndStage &= profile.TimeEntries.Any(te => te.Level.Name == "Black Comet" && te.Mission == Level.MissionType.Dark);
            oneOfEachEndStage &= profile.TimeEntries.Any(te => te.Level.Name == "Black Comet" && te.Mission == Level.MissionType.Hero);
            oneOfEachEndStage &= profile.TimeEntries.Any(te => te.Level.Name == "Lava Shelter" && te.Mission == Level.MissionType.Dark);
            oneOfEachEndStage &= profile.TimeEntries.Any(te => te.Level.Name == "Lava Shelter" && te.Mission == Level.MissionType.Hero);
            oneOfEachEndStage &= profile.TimeEntries.Any(te => te.Level.Name == "Cosmic Fall" && te.Mission == Level.MissionType.Dark);
            oneOfEachEndStage &= profile.TimeEntries.Any(te => te.Level.Name == "Cosmic Fall" && te.Mission == Level.MissionType.Hero);
            oneOfEachEndStage &= profile.TimeEntries.Any(te => te.Level.Name == "Final Haunt" && te.Mission == Level.MissionType.Dark);
            oneOfEachEndStage &= profile.TimeEntries.Any(te => te.Level.Name == "Final Haunt" && te.Mission == Level.MissionType.Hero);

            reportString += "One Of Each End Stage: " + ((oneOfEachEndStage) ? "PASSED" : "FAILED");

            return new KeyValuePair<bool, string>(oneOfEachEndStage, reportString);
        }

        private static KeyValuePair<bool, string> AllMissionsCompleteableNoSPW(Profile profile)
        {
            var reportString = string.Empty;
            var allMissionsCompleteableNoSPW = true; //first false will make this only false.
            var missingNoSPWMissons = new List<string>();            

            //completable no spw
            foreach (var level in Common.Instance.Levels)
            {
                var levelNoSPWEntries = profile.TimeEntries.FindAll(te => te.Level.Name == level.Name && te.SamuraiBlade == TimeEntry.WeaponState.Not_Available && te.SatelliteLaser == TimeEntry.WeaponState.Not_Available && te.EggVacuum == TimeEntry.WeaponState.Not_Available && te.OmochaoGun == TimeEntry.WeaponState.Not_Available && te.HealCannon == TimeEntry.WeaponState.Not_Available);

                foreach (var mission in level.Missions)
                {
                    var result = profile.TimeEntries.Any(te => te.Mission == mission);
                    allMissionsCompleteableNoSPW &= result;
                    if (!result)
                    {
                        missingNoSPWMissons.Add(level.Name + " " + mission + " No SPW");
                    }
                }
            }

            reportString += "All Missions Completeable No SPW: " + ((allMissionsCompleteableNoSPW) ? "PASSED" : "FAILED" + Environment.NewLine);
            if (!allMissionsCompleteableNoSPW)
            {
                foreach (var item in missingNoSPWMissons)
                {
                    reportString += item + Environment.NewLine;
                }
            }

            return new KeyValuePair<bool, string>(allMissionsCompleteableNoSPW, reportString);
        }

        public static string GenerateHundoReport(Profile profile)
        {
            var reportString = string.Empty;

            reportString += AllMissionsCompleteableNoSPW(profile).Value;

            reportString += Environment.NewLine + Environment.NewLine;

            reportString += AllKeysObtainableNoSPW(profile).Value;

            return reportString;
        }

        private static KeyValuePair<bool, string> AllKeysObtainableNoSPW(Profile profile)
        {
            var reportString = string.Empty;
            var allKeysObtainableNoSPW = true;
            var missingKeysLevels = new List<string>();

            foreach (var level in Common.Instance.Levels)
            {
                var levelNoSPWEntries = profile.TimeEntries.FindAll(te => te.Level.Name == level.Name && te.SamuraiBlade == TimeEntry.WeaponState.Not_Available && te.SatelliteLaser == TimeEntry.WeaponState.Not_Available && te.EggVacuum == TimeEntry.WeaponState.Not_Available && te.OmochaoGun == TimeEntry.WeaponState.Not_Available && te.HealCannon == TimeEntry.WeaponState.Not_Available);

                bool[] keys = new bool[5];

                foreach (var entry in levelNoSPWEntries)
                {
                    keys[0] |= entry.Keys[0];
                    keys[1] |= entry.Keys[1];
                    keys[2] |= entry.Keys[2];
                    keys[3] |= entry.Keys[3];
                    keys[4] |= entry.Keys[4];
                }

                var result = (keys[0] && keys[1] && keys[2] && keys[3] && keys[4]);
                allKeysObtainableNoSPW &= result;

                if (!result)
                {
                    var output = level.Name;

                    if (!keys[0] && !keys[1] && !keys[2] && !keys[3] && !keys[4])
                    {
                        output += " All Keys";
                    }
                    else
                    {
                        output += " Keys: ";
                        if (!keys[0])
                        {
                            output += "1 ";
                        }
                        if (!keys[1])
                        {
                            output += "2 ";
                        }
                        if (!keys[2])
                        {
                            output += "3 ";
                        }
                        if (!keys[3])
                        {
                            output += "4 ";
                        }
                        if (!keys[4])
                        {
                            output += "5 ";
                        }
                    }

                    missingKeysLevels.Add(output);
                }
            }

            reportString += "All Keys Obtainable No SPW: " + ((allKeysObtainableNoSPW) ? "PASSED" : "FAILED" + Environment.NewLine);
            if (!allKeysObtainableNoSPW)
            {
                foreach (var item in missingKeysLevels)
                {
                    reportString += item + Environment.NewLine;
                }
            }

            return new KeyValuePair<bool, string>(allKeysObtainableNoSPW, reportString);
        }
    }
}
