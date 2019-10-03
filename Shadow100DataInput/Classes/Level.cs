using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shadow100DataInput.Classes
{
    public class Level
    {
        public enum MissionType
        {
            Dark,
            Normal,
            Hero
        }

        private string name;
        private List<MissionType> missions;
        private bool[] keys = new bool[5];

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public List<MissionType> Missions
        {
            get
            {
                return missions;
            }
            set
            {
                missions = value;
            }
        }

        public bool[] Keys
        {
            get
            {
                return keys;
            }
            set
            {
                keys = value;
            }
        }

        public Level()
        {
        }

        public Level(string name, List<MissionType> missions)
        {
            this.name = name;
            this.missions = missions;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
