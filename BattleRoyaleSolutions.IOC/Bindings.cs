using SimpleInjector;
using CommonServiceLocator;
using BattleRoyaleSolutions.Core.Interfaces.Repositories;
using BattleRoyaleSolutions.Data.Repositories;
using BattleRoyaleSolutions.Core.Interfaces;
using BattleRoyaleSolutions.Data.UnitOfWork;
using BattleRoyaleSolutions.Application.Interfaces;
using BattleRoyaleSolutions.Application.Application;

namespace BattleRoyaleSolutions.IOC
{
    public class Bindings
    {
        public static void Start(Container container)
        {
            //Infrastructure
            container.Register(typeof(IRepository<>), typeof(Repository<>), Lifestyle.Scoped);
            container.Register<ILocalMachineInfoRepository, LocalMachineInfoRepository>();
            container.Register<IUnitOfWork, UnitOfWork>();
            container.Register(typeof(IMachineApplicationService<>), typeof(MachineApplicationService),Lifestyle.Scoped);

            //Locator
            ServiceLocator.SetLocatorProvider(() => new SimpleInjectorServiceLocatorAdapter(container));
        }

    }
}
