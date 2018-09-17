using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BattleRoyaleSolutions.Core;
using Microsoft.AspNetCore.SignalR;
using BattleRoyaleSolutions.Web.Hubs;
using System.Threading.Tasks;
using BattleRoyaleSolutions.Application.Interfaces;
using System.Linq;

namespace BattleRoyaleSolutions.Web.Controllers
{
    [Route("api/[controller]")]
    public class MachineController : Controller
    {
        private readonly IHubContext<ApplicationHub> hubContext;
        private readonly IMachineApplicationService machineApplicationService;

        public MachineController(IMachineApplicationService _machineApplicationService)
        {
            machineApplicationService = _machineApplicationService;
        }

        [HttpGet("[action]")]
        public List<LocalMachineInfo> GetAllMachines()
        {
            var machines = machineApplicationService.GetAll(x => x.IsActive).ToList();
            return machines;
        }

        [HttpGet("[action]")]
        public async Task<JsonResult> SendCommand(List<string> machineIds, string command)
        {
            foreach(var id in machineIds)
            {
                var machine = machineApplicationService.GetById(Guid.Parse(id));
                try
                {
                    await hubContext.Clients.Client(machine.ConnectionId).SendAsync("SendCommand", command);
                }
                catch
                {

                }

            }
            return null;
        }
    }
}