namespace BoyScoutsCamp.Model
{
    public class Camp
    {
        public int CampId { get; set; }
        public string CampName { get; set; }
        public string CampMessType { get; set; }

        public Camp(int campId, string campName, string campMessType)
        {
            this.CampId = campId;
            this.CampName = campName;
            this.CampMessType = campMessType;
        }
    }
}
