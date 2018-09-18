using BattleRoyaleSolutions.Application.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BattleRoyaleSolutions.Application.Application;
using BattleRoyaleSolutions.Core.Entities;
using BattleRoyaleSolutions.Core.Interfaces;
using BattleRoyaleSolutions.Core.Interfaces.Repositories;

namespace BattleRoyaleSolutions.Application.Test.Application
{
    [TestClass]
    public class CommandLogApplicationServiceTest
    {
        private CommandLogViewModel commandLog;
        private ICommandLogRepository _commandMachineRepository;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<ICommandLogRepository> _mockCommandRepository;
        private Mock<IMapper> _mockMapper;


        [TestInitialize]
        public void Initialize()
        {
            //var mockMachine = new Mock<IMachineApplicationService>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockCommandRepository = new Mock<ICommandLogRepository>();
            _mockMapper = new Mock<IMapper>();

            #region Machine Instance

            commandLog = new CommandLogViewModel()
            {
                Id = Guid.NewGuid(),
                Command = "dir",
                Return = "./",
                DateCommand = DateTime.Now,
                MachineId = Guid.NewGuid()

            };

            #endregion

            #region Mapper Mock

            _mockMapper.Setup(x => x.Map<CommandLogViewModel>(It.IsAny<CommandLog>())).Returns(new CommandLogViewModel()
            {
                Id = Guid.NewGuid(),
                Command = "dir",
                Return = "./",
                DateCommand = DateTime.Now,
                MachineId = Guid.NewGuid()
            });

            _mockMapper.Setup(x => x.Map<CommandLog>(It.IsAny<CommandLogViewModel>())).Returns(new CommandLog()
            {
                Id = Guid.NewGuid(),
                Command = "dir",
                Return = "./",
                DateCommand = DateTime.Now,
                MachineId = Guid.NewGuid()
            });

            var list = new List<CommandLog>()
            {
                _mockMapper.Object.Map<CommandLogViewModel, CommandLog>(commandLog)
            };

            var listVM = new List<CommandLogViewModel>()
            {
                commandLog
            };

            _mockMapper.Setup(x => 
                x.Map<IEnumerable<CommandLog>, IEnumerable<CommandLogViewModel>>(It.IsAny<IEnumerable<CommandLog>>())).Returns(listVM.AsEnumerable);

            #endregion

            #region MockRepositories

            _mockCommandRepository.Setup(x => x.Add(It.IsAny<CommandLog>()))
                .Returns(_mockMapper.Object.Map<CommandLogViewModel, CommandLog>(commandLog));

            _mockCommandRepository.Setup(x => x.GetById(commandLog.Id))
                .Returns(_mockMapper.Object.Map<CommandLogViewModel, CommandLog>(commandLog));

            _mockCommandRepository.Setup(x => x.GetAll())
                .Returns(list.AsQueryable());

            _mockCommandRepository.Setup(x => x.Update(It.IsAny<CommandLog>()));

            _mockCommandRepository.Setup(x => x.Remove(It.IsAny<Guid>()));

            #endregion

            _mockUnitOfWork.Setup(x => x.Commit()).Returns(true);

            _mapper = _mockMapper.Object;
            _commandMachineRepository = _mockCommandRepository.Object;
            _unitOfWork = _mockUnitOfWork.Object;
        }

        [TestMethod]
        public void Machine_Application_Save_Test()
        {
            var service = new CommandLogApplicationService(_unitOfWork, _commandMachineRepository, _mapper);

            var result = service.Save(commandLog);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Machine_Application_Get_By_Id_Test()
        {
            var service = new CommandLogApplicationService(_unitOfWork, _commandMachineRepository, _mapper);

            service.Save(commandLog);
            var result = service.GetById(commandLog.Id);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Machine_Application_Get_All_Test()
        {
            var service = new CommandLogApplicationService(_unitOfWork, _commandMachineRepository, _mapper);

            service.Save(commandLog);
            var listResult = service.GetAll();

            Assert.AreEqual(1, listResult.Count());
        }

        [TestMethod]
        public void Machine_Application_Update_Test()
        {
            var service = new CommandLogApplicationService(_unitOfWork, _commandMachineRepository, _mapper);

            service.Save(commandLog);
            service.Update(commandLog);

            _mockCommandRepository.Verify(x => x.Update(It.IsAny<CommandLog>()), Times.Once);
        }

        [TestMethod]
        public void Machine_Application_Remove_Test()
        {
            var service = new CommandLogApplicationService(_unitOfWork, _commandMachineRepository, _mapper);

            service.Save(commandLog);
            service.Update(commandLog);

            _mockCommandRepository.Verify(x => x.Update(It.IsAny<CommandLog>()), Times.Once);
        }
    }
}
