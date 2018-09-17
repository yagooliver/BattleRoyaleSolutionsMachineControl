using System;

namespace BattleRoyaleSolutions.Application.Models
{
    public class CommandLogViewModel
    {
        public Guid Id { get; set; }
        public string Command { get; set; }
        public string Return { get; set; }
        public DateTime DataCommand { get; set; }
        public Guid MachineId { get; set; }
    }
}
