using System;
using System.Collections.Generic;
using System.Text;

namespace BattleRoyaleSolutions.Core.Entities
{
    public class CommandLog
    {
        public Guid Id { get; set; }
        public string Command { get; set; }
        public string Return { get; set; }
        public DateTime DateCommand { get; set; }
        public Guid MachineId { get; set; }

        public virtual LocalMachineInfo LocalMachineInfo { get; set; }
    }
}
