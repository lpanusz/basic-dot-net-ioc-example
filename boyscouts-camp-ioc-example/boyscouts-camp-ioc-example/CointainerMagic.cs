using BoyScoutsCamp.Repository;
using BoyScoutsCamp.Service;
using Microsoft.Practices.Unity;

namespace boyscouts_camp_example
{
    public class CointainerMagic
    {
        public static void RegisterElementsAutomatically(IUnityContainer container)
        {
            container.RegisterTypes(
                AllClasses.FromAssemblies(),
                WithMappings.FromAllInterfaces,
                WithName.Default,
                WithLifetime.ContainerControlled
                );
        }

        public static void RegisterElements(IUnityContainer container)
        {
            container.RegisterType<ILoggerService, LoggerService>();
            var loggerType = typeof(ILoggerService);

            container.RegisterType<ICampsRepository, CampsRepository>();
            var campsRepositoryType = typeof(ICampsRepository);

            container.RegisterType<IScoutsRepository, ScoutsRepository>();
            var scoutRepositoryType = typeof(IScoutsRepository);

            container.RegisterType<IScoutsService, ScoutsService>(new InjectionConstructor(scoutRepositoryType, campsRepositoryType, loggerType));
        }
    }
}
