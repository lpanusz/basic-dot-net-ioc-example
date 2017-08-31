using BoyScoutsCamp.Model;
using BoyScoutsCamp.Repository;
using BoyScoutsCamp.Service;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;

namespace BoyScoutCamp.UnitTests
{
    [TestFixture]
    public class ScoutsServiceTests
    {
        [Test]
        public void AddScoutTest()
        {
            IUnityContainer unityContainer = new UnityContainer();
            Mock<IScoutsRepository> scoutsRepositoryMock = new Mock<IScoutsRepository>();
            Mock<ICampsRepository> campRepositoryMock = new Mock<ICampsRepository>();
            Mock<ILoggerService> loggerServiceMock = new Mock<ILoggerService>();

            unityContainer.RegisterType<IScoutsService, ScoutsService>(new InjectionConstructor(scoutsRepositoryMock.Object, campRepositoryMock.Object, loggerServiceMock.Object));
            IScoutsService scoutsService = unityContainer.Resolve<IScoutsService>();

            scoutsService.AddScout("Testing Scout", "Here comes Unit test");
            scoutsRepositoryMock.Verify(s => s.SaveScout(It.Is<Scout>(r => r.ScoutName == "Testing Scout")));
        }
    }
}
