using BattleRoyaleSolutions.Application.Interfaces;
using BattleRoyaleSolutions.Application.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleRoyaleSolutions.Application.Test.Application
{
    [TestClass]
    public class MachineApplicationServiceTest
    {
        private MachineViewModel machine;

        [TestMethod]
        public void Machine_Application_Save_Test()
        {
            machine = new MachineViewModel()
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
            };

            var mockMachine = new Mock<IMachineApplicationService>();
            mockMachine.Setup(x => x.Save(machine)).Returns(true);
            var result = mockMachine.Object.Save(machine);
            mockMachine.Verify(x => x.Save(machine), Times.Once());
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Machine_Application_Get_By_Id_Test()
        {
            machine = new MachineViewModel()
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
            };

            var mockMachine = new Mock<IMachineApplicationService>();
            mockMachine.Setup(x => x.Save(machine)).Returns(true);
            mockMachine.Setup(x => x.GetById(machine.Id)).Returns(machine);
            mockMachine.Object.Save(machine);
            var entity = mockMachine.Object.GetById(machine.Id);
            Assert.AreEqual(machine.Id, entity.Id);
        }

        [TestMethod]
        public void Machine_Application_Get_All_Test()
        {
            machine = new MachineViewModel()
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
            };

            var mockMachine = new Mock<IMachineApplicationService>();
            mockMachine.Setup(x => x.Save(machine)).Returns(true);
            mockMachine.Setup(x => x.GetAll()).Returns(new List<MachineViewModel>() { machine });
            mockMachine.Object.Save(machine);
            var listResult = mockMachine.Object.GetAll();
            Assert.AreEqual(1, listResult.Count());
        }

        [TestMethod]
        public void Machine_Application_Update_Test()
        {
            machine = new MachineViewModel()
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
            };

            var mockMachine = new Mock<IMachineApplicationService>();
            mockMachine.Setup(x => x.Save(machine)).Returns(true);
            mockMachine.Setup(x => x.GetById(machine.Id)).Returns(machine);
            mockMachine.Setup(x => x.Update(machine));

            mockMachine.Object.Save(machine);

            machine.InternetProtocol = "http";
            machine.IsFirewallActive = true;
            mockMachine.Object.Update(machine);
            Assert.AreEqual(machine.InternetProtocol, mockMachine.Object.GetById(machine.Id).InternetProtocol);
        }

        [TestMethod]
        public void Machine_Application_Remove_Test()
        {
            machine = new MachineViewModel()
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
            };

            var mockMachine = new Mock<IMachineApplicationService>();
            mockMachine.Setup(x => x.Save(machine)).Returns(true);
            mockMachine.Setup(x => x.Remove(machine.Id));
            mockMachine.Object.Save(machine);
            mockMachine.Object.Remove(machine.Id);
            mockMachine.Verify(x => x.Remove(machine.Id), Times.Once);
        }
    }
}
