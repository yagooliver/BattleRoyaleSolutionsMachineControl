using BattleRoyaleSolutions.Core.Interfaces.Repositories;
using BattleRoyaleSolutions.Data.Repositories;
using BattleRoyaleSolutions.Core.Interfaces;
using BattleRoyaleSolutions.Data.UnitOfWork;
using BattleRoyaleSolutions.Application.Interfaces;
using BattleRoyaleSolutions.Application.Application;
using Microsoft.Extensions.DependencyInjection;
using BattleRoyaleSolutions.Data;

namespace BattleRoyaleSolutions.IOC
{
    public class DependencyInjectionResolver
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //unitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //Repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ILocalMachineInfoRepository, LocalMachineInfoRepository>();
            services.AddScoped<ICommandLogRepository,CommandLogRepository>();
            //Application
            services.AddScoped<IMachineApplicationService, MachineApplicationService>();
            services.AddScoped<ICommandLogApplicationService, CommandLogApplicationService>();
            //context
            services.AddScoped<MachineRemoteControlContext>();
        }

    }
}
