namespace BoyScoutsCamp.Model
{
    public class Scout
    {
        public int ScoutId { get; set; }
        public string ScoutName { get; set; }
        public string ScoutMsg { get; set; }

        public Scout(int scoutId, string scoutName, string scoutMsg)
        {
            this.ScoutId = scoutId;
            this.ScoutName = scoutName;
            this.ScoutMsg = ScoutMsg;
        }
    }
}
