namespace BoyScoutsCamp.Service
{
    class AuthService
    {
        public bool IsValid(string scoutName) => ((scoutName.Length % 2 == 0) ? true : false);
    }
}
