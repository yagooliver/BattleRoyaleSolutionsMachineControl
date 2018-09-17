using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using BattleRoyaleSolutions.Web.Hubs;
using System.Threading.Tasks;
using BattleRoyaleSolutions.Application.Interfaces;
using System.Linq;
using BattleRoyaleSolutions.Application.Models;

namespace BattleRoyaleSolutions.Web.Controllers
{
    [Route("api/[controller]")]
    public class MachineController : Controller
    {
        private readonly IMachineApplicationService machineApplicationService;
        private readonly IHubContext<ApplicationHub> _hubContext;

        public MachineController(IMachineApplicationService _machineApplicationService, IHubContext<ApplicationHub> hubContext)
        {
            machineApplicationService = _machineApplicationService;
            _hubContext = hubContext;
        }

        [HttpGet("[action]")]
        public List<MachineViewModel> GetAllMachines()
        {
            var machines = machineApplicationService.GetAll().Where(x => x.IsActive).ToList();

            return machines;
        }

        [HttpPost("[action]")]
        public async Task<string> SendCommand(List<string> machineIds, string command)
        {
            foreach (var id in machineIds)
            {
                var machine = machineApplicationService.GetById(Guid.Parse(id));
                try
                {
                    await _hubContext.Clients.Client(machine.ConnectionId).SendAsync("SendCommand", command);
                }
                catch
                {

                }

            }
            return "";
        }
    }
}