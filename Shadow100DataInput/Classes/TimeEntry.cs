using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shadow100DataInput.Classes
{
    class TimeEntry
    {
        private Level level;
        private int missionIndex;
        private uint time = 0;
        private string videoLink = "";

        public enum WeaponState
        {
            Not_Available,            
            Level2,
            Level1,
        }

        private WeaponState samuraiBlade = WeaponState.Not_Available;
        private WeaponState satelliteLaser = WeaponState.Not_Available;
        private WeaponState eggVacuum = WeaponState.Not_Available;
        private WeaponState omochaoGun = WeaponState.Not_Available;
        private WeaponState healCannon = WeaponState.Not_Available;

        public Level Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
            }
        }

        public int MissionIndex
        {
            get
            {
                return missionIndex;
            }
            set
            {
                missionIndex = value;
            }
        }

        public Level.MissionType Mission
        {
            get
            {
                return Level.Missions[missionIndex];
            }
        }

        public bool[] Keys
        {
            get
            {
                return level.Keys;
            }
            set
            {
                level.Keys = value;
            }
        }

        public bool UsesKeyDoor
        {
            get
            {
                return level.UsesKeyDoor;
            }
            set
            {
                level.UsesKeyDoor = value;
            }
        }

        public bool NoCCG
        {
            get
            {
                return level.NoCCG;
            }
            set
            {
                level.NoCCG = value;
            }
        }

        public WeaponState SamuraiBlade
        {
            get
            {
                return samuraiBlade;
            }
            set
            {
                samuraiBlade = value;
            }
        }
        public WeaponState SatelliteLaser
        {
            get
            {
                return satelliteLaser;
            }
            set
            {
                satelliteLaser = value;
            }
        }
        public WeaponState EggVacuum
        {
            get
            {
                return eggVacuum;
            }
            set
            {
                eggVacuum = value;
            }
        }
        public WeaponState OmochaoGun
        {
            get
            {
                return omochaoGun;
            }
            set
            {
                omochaoGun = value;
            }
        }
        public WeaponState HealCannon
        {
            get
            {
                return healCannon;
            }
            set
            {
                healCannon = value;
            }
        }

        public uint Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
            }
        }

        public string VideoLink
        {
            get
            {
                return videoLink;
            }
            set
            {
                videoLink = value;
            }
        }
    }
}
