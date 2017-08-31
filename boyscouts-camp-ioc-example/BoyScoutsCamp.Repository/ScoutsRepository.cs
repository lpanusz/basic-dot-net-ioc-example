using System.Collections.Generic;
using BoyScoutsCamp.Model;

namespace BoyScoutsCamp.Repository
{
    public class ScoutsRepository : IScoutsRepository
    {
        private List<Scout> ScoutsList = new List<Scout>();

        public void SaveScout(Scout scout)
        {
            ScoutsList.Add(scout);
        }

        public void RemoveScout(Scout scout)
        {
            ScoutsList.Remove(scout);
        }

        public Scout GetScoutById(int id)
        {
            return ScoutsList.Find(Scout => Scout.ScoutId == id);
        }

        public int GetLastSavedScoutId()
        {
            return (ScoutsList[ScoutsList.Count-1]).ScoutId;
        }
    }
}
