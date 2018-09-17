using System;

namespace BattleRoyaleSolutions.Application.Models
{
    public class MachineViewModel
    {
        public Guid Id { get; set; }
        public string MachineName { get; set; }
        public string InternetProtocol { get; set; }
        public string AntiVirusName { get; set; }
        public bool IsFirewallActive { get; set; }
        public string WindowsVersion { get; set; }
        public string DotNetVersion { get; set; }
        public string Ip { get; set; }
        public bool IsActive { get; set; }
        public string ConnectionId { get; set; }
        public double TotalSize { get; set; }
        public double TotalUsed { get; set; }

        private double _TotalAvalible;
        public double TotalAvalible
        {
            get
            {
                return _TotalAvalible;
            }
            set
            {
                _TotalAvalible = TotalSize - TotalUsed;
            }
        }

    }
}
