using BattleRoyaleSolutions.Core;
using BattleRoyaleSolutions.Core.Interfaces.Repositories;

namespace BattleRoyaleSolutions.Data.Repositories
{
    public class LocalMachineInfoRepository : Repository<LocalMachineInfo>, ILocalMachineInfoRepository
    {
        public LocalMachineInfoRepository(MachineRemoteControlContext context) : base(context)
        {
        }
    }
}
