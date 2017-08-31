using BoyScoutsCamp.Service;
using System;

namespace boyscouts_camp_example
{
    class BoyScoutsCamp
    {
        static void Main(string[] args)
        {
            LoggerService logger = new LoggerService();
            ScoutsService scouts = new ScoutsService();

            logger.WriteLog("Registration for cleanning camps is starting here.");

            scouts.BootstrapScouts();
            logger.WriteLog("Known scouts are already registered!");

            scouts.AddScout("Quality Man", "Testing, Testing..");

            logger.WriteLog("Done.");

            Console.ReadKey();
        }
    }
}
