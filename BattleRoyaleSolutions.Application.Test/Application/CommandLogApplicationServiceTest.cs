using BattleRoyaleSolutions.Application.Interfaces;
using BattleRoyaleSolutions.Application.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleRoyaleSolutions.Application.Test.Application
{
    [TestClass]
    public class CommandLogApplicationServiceTest
    {
        private CommandLogViewModel commandLog;

        [TestMethod]
        public void Machine_Application_Save_Test()
        {
            commandLog = new CommandLogViewModel()
            {
                Id = Guid.NewGuid(),
                Command = "dir",
                Return = "./",
                DataCommand = DateTime.Now,
                MachineId = Guid.NewGuid()

            };

            var mockCommandLog = new Mock<ICommandLogApplicationService>();
            mockCommandLog.Setup(x => x.Save(commandLog)).Returns(true);
            var result = mockCommandLog.Object.Save(commandLog);
            mockCommandLog.Verify(x => x.Save(commandLog), Times.Once());
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Machine_Application_Get_By_Id_Test()
        {
            commandLog = new CommandLogViewModel()
            {
                Id = Guid.NewGuid(),
                Command = "dir",
                Return = "./",
                DataCommand = DateTime.Now,
                MachineId = Guid.NewGuid()

            };

            var mockCommandLog = new Mock<ICommandLogApplicationService>();
            mockCommandLog.Setup(x => x.Save(commandLog)).Returns(true);
            mockCommandLog.Setup(x => x.GetById(commandLog.Id)).Returns(commandLog);
            mockCommandLog.Object.Save(commandLog);
            var entity = mockCommandLog.Object.GetById(commandLog.Id);
            Assert.AreEqual(commandLog.Id, entity.Id);
        }

        [TestMethod]
        public void Machine_Application_Get_All_Test()
        {
            commandLog = new CommandLogViewModel()
            {
                Id = Guid.NewGuid(),
                Command = "dir",
                DataCommand = DateTime.Now,
                Return = "./",
                MachineId = Guid.NewGuid()

            };

            var mockCommandLog = new Mock<ICommandLogApplicationService>();
            mockCommandLog.Setup(x => x.Save(commandLog)).Returns(true);
            mockCommandLog.Setup(x => x.GetAll()).Returns(new List<CommandLogViewModel>() { commandLog });
            mockCommandLog.Object.Save(commandLog);
            var listResult = mockCommandLog.Object.GetAll();
            Assert.AreEqual(1, listResult.Count());
        }

        [TestMethod]
        public void Machine_Application_Update_Test()
        {
            commandLog = new CommandLogViewModel()
            {
                Id = Guid.NewGuid(),
                Command = "dir",
                Return = "./",
                DataCommand = DateTime.Now,
                MachineId = Guid.NewGuid()

            };

            var mockCommandLog = new Mock<ICommandLogApplicationService>();
            mockCommandLog.Setup(x => x.Save(commandLog)).Returns(true);
            mockCommandLog.Setup(x => x.GetById(commandLog.Id)).Returns(commandLog);
            mockCommandLog.Setup(x => x.Update(commandLog));

            mockCommandLog.Object.Save(commandLog);

            commandLog.Command = "cd ..";
            commandLog.Return = "C:\\";
            mockCommandLog.Object.Update(commandLog);
            Assert.AreEqual(commandLog.Return, mockCommandLog.Object.GetById(commandLog.Id).Return);
        }

        [TestMethod]
        public void Machine_Application_Remove_Test()
        {
            commandLog = new CommandLogViewModel()
            {
                Id = Guid.NewGuid(),
                Command = "dir",
                Return = "./",
                DataCommand = DateTime.Now,
                MachineId = Guid.NewGuid()

            };

            var mockCommandLog = new Mock<ICommandLogApplicationService>();
            mockCommandLog.Setup(x => x.Save(commandLog)).Returns(true);
            mockCommandLog.Setup(x => x.Remove(commandLog.Id));
            mockCommandLog.Object.Save(commandLog);
            mockCommandLog.Object.Remove(commandLog.Id);
            mockCommandLog.Verify(x => x.Remove(commandLog.Id), Times.Once);
        }
    }
}
