using BoyScoutsCamp.Model;
using BoyScoutsCamp.Repository;
using System.Collections.Generic;

namespace BoyScoutsCamp.Service
{
    public class ScoutsService
    {
        private ScoutsRepository scoutsRepository = new ScoutsRepository();
        private CampsRepository campsRepository = new CampsRepository();
        private LoggerService logger = new LoggerService();
        private AuthService auth = new AuthService();

        public void BootstrapScouts()
        {
            logger.WriteLog("Initilization of scouts..");
            scoutsRepository.SaveScout(new Model.Scout(1, "John Doe", "Cleaning.."));
            logger.WriteLog("Scout: " + scoutsRepository.GetScoutById(1).ScoutName + " added");
            scoutsRepository.SaveScout(new Model.Scout(2, "Scout Solid", "Separate Conserns"));
            logger.WriteLog("Scout: " + scoutsRepository.GetScoutById(2).ScoutName + " added");
            scoutsRepository.SaveScout(new Model.Scout(3, "Scout Inversion", "Lets invert things.."));
            logger.WriteLog("Scout: " + scoutsRepository.GetScoutById(3).ScoutName + " added");
            logger.WriteLog("Processing complete");
        }

        public int AddScout(string scoutName, string scoutMsg)
        {
            var id = scoutsRepository.GetLastSavedScoutId() + 1;
            scoutsRepository.SaveScout(new Model.Scout(id , scoutName, scoutMsg));
            logger.WriteLog("Scout added with ID: " + id);
            return id;
        }

        public void RegisterCamp(string campName, string campMessType)
        {
            var id = campsRepository.GetLastSavedCampId() + 1;
            campsRepository.SaveCamp(new Model.Camp(id, campName, campMessType));
            logger.WriteLog("Camp added with ID: " + id);
        }

        public bool RegisterScoutForCamp(int scoutId, int campId)
        {
            var scout = scoutsRepository.GetScoutById(scoutId);

            return (auth.IsValid(scout.ScoutName)) ? campsRepository.SaveCampAttender(campId, scout) : false;
        }

        public List<Scout> GetListOfScoutsRegisteredForCamp(int campId)
        {
            return campsRepository.GetListOfCampAttenders(campId);
        }
    }
}
