using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shadow100DataInput.Classes
{
    public class Level
    {
        private string name;
        private List<Mission> missions;
        private bool[] keys = new bool[5];

        public string Name
        {
            get
            {
                return name;
            }
        }

        public List<Mission> Missions
        {
            get
            {
                return missions;
            }
        }

        public bool[] Keys
        {
            get
            {
                return keys;
            }
        }
    }
}
