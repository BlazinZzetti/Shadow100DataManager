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
            NOT_AVAILABLE,
            LEVEL1,
            LEVEL2
        }

        private WeaponState samuraiBlade = WeaponState.NOT_AVAILABLE;
        private WeaponState satelliteLaser = WeaponState.NOT_AVAILABLE;
        private WeaponState eggVacuum = WeaponState.NOT_AVAILABLE;
        private WeaponState omochaoGun = WeaponState.NOT_AVAILABLE;
        private WeaponState healCannon = WeaponState.NOT_AVAILABLE;

        public Level Level
        {
            get
            {
                return level;
            }
        }

        public Mission.MissionType Mission
        {
            get
            {
                return Level.Missions[missionIndex].Type;
            }
        }

        public bool[] Keys
        {
            get
            {
                return level.Keys;
            }
        }

        public WeaponState SamuraiBlade
        {
            get
            {
                return samuraiBlade;
            }
        }
        public WeaponState SatelliteLaser
        {
            get
            {
                return satelliteLaser;
            }
        }
        public WeaponState EggVacuum
        {
            get
            {
                return eggVacuum;
            }
        }
        public WeaponState OmochaoGun
        {
            get
            {
                return omochaoGun;
            }
        }
        public WeaponState HealCannon
        {
            get
            {
                return healCannon;
            }
        }

        public uint Time
        {
            get
            {
                return time;
            }
        }

        public string VideoLink
        {
            get
            {
                return videoLink;
            }
        }
    }
}
