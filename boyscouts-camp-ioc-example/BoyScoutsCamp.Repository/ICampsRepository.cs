using BoyScoutsCamp.Model;
using System.Collections.Generic;

namespace BoyScoutsCamp.Repository
{
    public interface ICampsRepository
    {
        void SaveCamp(Camp camp);
        void RemoveCamp(Camp camp);
        Camp GetCampById(int id);
        int GetLastSavedCampId();
        bool SaveCampAttender(int campId, Scout scout);
        List<Scout> GetListOfCampAttenders(int campId);
    }
}
