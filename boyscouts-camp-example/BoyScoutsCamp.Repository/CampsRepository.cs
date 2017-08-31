using BoyScoutsCamp.Model;
using System.Collections.Generic;

namespace BoyScoutsCamp.Repository
{
    public class CampsRepository
    {
        private List<Camp> CampsList = new List<Camp>();
        private Dictionary<int, Scout> CampsAttenders = new Dictionary<int, Scout>();

        public void SaveCamp(Camp camp) => CampsList.Add(camp);

        public void RemoveCamp(Camp camp) => CampsList.Remove(camp);

        public Camp GetCampById(int id) => CampsList.Find(Camp => Camp.CampId == id);

        public int GetLastSavedCampId() => (CampsList[CampsList.Count - 1]).CampId;

        public bool SaveCampAttender(int campId, Scout scout)
        {
            CampsAttenders.Add(campId, scout);
            return true;
        }

        public List<Scout> GetListOfCampAttenders(int campId)
        {
            var attendeers = new List<Scout>();

            foreach(KeyValuePair<int, Scout> kvp in CampsAttenders)
            {
                if (kvp.Key == campId)
                    attendeers.Add(kvp.Value);
            }
            return attendeers;
        }
    }
}
