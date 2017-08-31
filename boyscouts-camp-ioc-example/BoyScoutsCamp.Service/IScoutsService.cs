using BoyScoutsCamp.Model;
using System.Collections.Generic;

namespace BoyScoutsCamp.Service
{
    public interface IScoutsService
    {
        void BootstrapScouts();
        int AddScout(string scoutName, string scoutMsg);
        void RegisterCamp(string campName, string campMessType);
        bool RegisterScoutForCamp(int scoutId, int campId);
        List<Scout> GetListOfScoutsRegisteredForCamp(int campId);
    }
}
