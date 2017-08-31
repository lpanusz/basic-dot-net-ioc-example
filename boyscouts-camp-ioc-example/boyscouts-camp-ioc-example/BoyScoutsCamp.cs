using BoyScoutsCamp.Service;
using Microsoft.Practices.Unity;
using System;

namespace boyscouts_camp_example
{
    class BoyScoutsCamp
    {
        static void Main(string[] args)
        {
            IUnityContainer unityContainer = new UnityContainer();
            CointainerMagic.RegisterElements(unityContainer);

            ILoggerService loggerService = unityContainer.Resolve<ILoggerService>();
            IScoutsService scoutsService = unityContainer.Resolve<IScoutsService>();

            loggerService.WriteLog("Registration for cleanning camps is starting here.");

            scoutsService.BootstrapScouts();
            loggerService.WriteLog("Known scouts are already registered!");

            scoutsService.AddScout("Quality Man", "Testing, Testing..");

            loggerService.WriteLog("Done.");

            Console.ReadKey();
        }
    }
}
