using BoyScoutsCamp.Model;
using BoyScoutsCamp.Repository;
using System.Collections.Generic;

namespace BoyScoutsCamp.Service
{
    public class ScoutsService : IScoutsService
    {
        private IScoutsRepository _scoutsRepository;
        private ICampsRepository _campsRepository;
        private ILoggerService _loggerService;
        private AuthService auth = new AuthService();

        public ScoutsService(IScoutsRepository scoutsRepository, ICampsRepository campsRepository, ILoggerService loggerService)
        {
            _scoutsRepository = scoutsRepository;
            _campsRepository = campsRepository;
            _loggerService = loggerService;
        }

        public void BootstrapScouts()
        {
            _loggerService.WriteLog("Initilization of scouts..");
            _scoutsRepository.SaveScout(new Model.Scout(1, "John Doe", "Cleaning.."));
            _loggerService.WriteLog("Scout: " + _scoutsRepository.GetScoutById(1).ScoutName + " added");
            _scoutsRepository.SaveScout(new Model.Scout(2, "Scout Solid", "Separate Conserns"));
            _loggerService.WriteLog("Scout: " + _scoutsRepository.GetScoutById(2).ScoutName + " added");
            _scoutsRepository.SaveScout(new Model.Scout(3, "Scout Inversion", "Lets invert things.."));
            _loggerService.WriteLog("Scout: " + _scoutsRepository.GetScoutById(3).ScoutName + " added");
            _loggerService.WriteLog("Processing complete");
        }

        public int AddScout(string scoutName, string scoutMsg)
        {
            var id = _scoutsRepository.GetLastSavedScoutId() + 1;
            _scoutsRepository.SaveScout(new Model.Scout(id , scoutName, scoutMsg));
            _loggerService.WriteLog("Scout added with ID: " + id);
            return id;
        }

        public void RegisterCamp(string campName, string campMessType)
        {
            var id = _campsRepository.GetLastSavedCampId() + 1;
            _campsRepository.SaveCamp(new Model.Camp(id, campName, campMessType));
            _loggerService.WriteLog("Camp added with ID: " + id);
        }

        public bool RegisterScoutForCamp(int scoutId, int campId)
        {
            var scout = _scoutsRepository.GetScoutById(scoutId);

            return (auth.IsValid(scout.ScoutName)) ? _campsRepository.SaveCampAttender(campId, scout) : false;
        }

        public List<Scout> GetListOfScoutsRegisteredForCamp(int campId)
        {
            return _campsRepository.GetListOfCampAttenders(campId);
        }
    }
}
