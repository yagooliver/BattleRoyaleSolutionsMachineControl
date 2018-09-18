using BattleRoyaleSolutions.Application.Interfaces;
using BattleRoyaleSolutions.Application.Models;
using BattleRoyaleSolutions.Web.Controllers;
using BattleRoyaleSolutions.Web.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace BattleRoyaleSolutions.Web.Test.ControllerTest
{
    [TestClass]
    public class MachineControllerTest
    {
        [TestMethod]
        public void Get_All_Machines_Test()
        {
            var machines = new List<MachineViewModel>()
            {
                new MachineViewModel()
                {
                    Id = Guid.NewGuid(),
                    AntiVirusName = "te",
                    DotNetVersion = "",
                    IsActive = true,
                    MachineName = "Test 1",
                    Ip = "10.0.0.1",
                    WindowsVersion = "NT",
                    InternetProtocol = "https",
                    IsFirewallActive = false,
                    TotalAvalible = 1000,
                    TotalSize = 2000,
                    TotalUsed = 1000
                }
            };

            var mockMachine = new Mock<IMachineApplicationService>();
            var mockHub = new Mock<IHubContext<ApplicationHub>>();

            mockMachine.Setup(x => x.GetAll()).Returns(machines);
            var controller = new MachineController(mockMachine.Object, mockHub.Object);
            var result = controller.GetAllMachines();
            CollectionAssert.AreEqual(machines, result);
        }
    }
}
