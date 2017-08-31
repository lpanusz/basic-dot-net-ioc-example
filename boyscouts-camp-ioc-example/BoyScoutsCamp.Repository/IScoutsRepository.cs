using BoyScoutsCamp.Model;

namespace BoyScoutsCamp.Repository
{
    public interface IScoutsRepository
    {
        void SaveScout(Scout scout);
        void RemoveScout(Scout scout);
        Scout GetScoutById(int id);
        int GetLastSavedScoutId();
    }
}
