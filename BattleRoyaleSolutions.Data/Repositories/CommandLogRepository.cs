using BattleRoyaleSolutions.Core.Entities;
using BattleRoyaleSolutions.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleRoyaleSolutions.Data.Repositories
{
    public class CommandLogRepository : Repository<CommandLog>, ICommandLogRepository
    {
        public CommandLogRepository(MachineRemoteControlContext context) : base(context)
        {
        }
    }
}
