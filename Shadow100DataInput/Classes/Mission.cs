namespace Shadow100DataInput.Classes
{
    public class Mission
    {
        public enum MissionType
        {
            DARK,
            NORMAL,
            HERO
        }

        private MissionType missionType = MissionType.NORMAL;

        public MissionType Type
        {
            get
            {
                return missionType;
            }
        }
    }
}