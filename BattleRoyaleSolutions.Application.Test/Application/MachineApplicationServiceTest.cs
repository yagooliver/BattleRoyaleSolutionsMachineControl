using BattleRoyaleSolutions.Application.Interfaces;
using BattleRoyaleSolutions.Application.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BattleRoyaleSolutions.Application.Application;
using BattleRoyaleSolutions.Core;
using BattleRoyaleSolutions.Core.Interfaces;
using BattleRoyaleSolutions.Core.Interfaces.Repositories;

namespace BattleRoyaleSolutions.Application.Test.Application
{
    [TestClass]
    public class MachineApplicationServiceTest
    {
        private MachineViewModel _machine;
        private ILocalMachineInfoRepository _machineInfoRepository;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<ILocalMachineInfoRepository> _mockMachineRepository;
        private Mock<IMapper> _mockMapper;


        [TestInitialize]
        public void Initialize()
        {
            //var mockMachine = new Mock<IMachineApplicationService>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMachineRepository = new Mock<ILocalMachineInfoRepository>();
            _mockMapper = new Mock<IMapper>();

            #region Machine Instance

            _machine = new MachineViewModel()
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

            #endregion

            #region Mapper Mock

            _mockMapper.Setup(x => x.Map<MachineViewModel>(It.IsAny<LocalMachineInfo>())).Returns(new MachineViewModel()
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
            });

            _mockMapper.Setup(x => x.Map<LocalMachineInfo>(It.IsAny<MachineViewModel>())).Returns(new LocalMachineInfo()
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
            });

            var list = new List<LocalMachineInfo>()
            {
                _mockMapper.Object.Map<MachineViewModel, LocalMachineInfo>(_machine)
            };

            var listVM = new List<MachineViewModel>()
            {
                _machine
            };

            _mockMapper.Setup(x => x.Map<IEnumerable<LocalMachineInfo>, IEnumerable<MachineViewModel>>(It.IsAny<IEnumerable<LocalMachineInfo>>())).Returns(listVM.AsEnumerable);

            #endregion

            #region MockRepositories

            _mockMachineRepository.Setup(x => x.Add(It.IsAny<LocalMachineInfo>()))
                .Returns(_mockMapper.Object.Map<MachineViewModel, LocalMachineInfo>(_machine));

            _mockMachineRepository.Setup(x => x.GetById(_machine.Id))
                .Returns(_mockMapper.Object.Map<MachineViewModel, LocalMachineInfo>(_machine));

            _mockMachineRepository.Setup(x => x.GetAll())
                .Returns(list.AsQueryable());

            _mockMachineRepository.Setup(x => x.Update(It.IsAny<LocalMachineInfo>()))
                .Callback(() => _machine.InternetProtocol = "http");

            _mockMachineRepository.Setup(x => x.Remove(It.IsAny<Guid>()));

            #endregion

            _mockUnitOfWork.Setup(x => x.Commit()).Returns(true);
            
            _mapper = _mockMapper.Object;
            _machineInfoRepository = _mockMachineRepository.Object;
            _unitOfWork = _mockUnitOfWork.Object;
        }

        [TestMethod]
        public void Machine_Application_Save_Test()
        {
            var service = new MachineApplicationService(_unitOfWork,_machineInfoRepository, _mapper);

            var result = service.Save(_machine);
            
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Machine_Application_Get_By_Id_Test()
        {
            var service = new MachineApplicationService(_unitOfWork, _machineInfoRepository, _mapper);

            service.Save(_machine);
            var result = service.GetById(_machine.Id);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Machine_Application_Get_All_Test()
        {
            var service = new MachineApplicationService(_unitOfWork, _machineInfoRepository, _mapper);

            service.Save(_machine);
            var listResult = service.GetAll();

            Assert.AreEqual(1, listResult.Count());
        }

        [TestMethod]
        public void Machine_Application_Update_Test()
        {
            var service = new MachineApplicationService(_unitOfWork, _machineInfoRepository, _mapper);

            service.Save(_machine);
            service.Update(_machine);

            _mockMachineRepository.Verify(x => x.Update(It.IsAny<LocalMachineInfo>()), Times.Once);
        }

        [TestMethod]
        public void Machine_Application_Remove_Test()
        {
            var service = new MachineApplicationService(_unitOfWork, _machineInfoRepository, _mapper);

            service.Save(_machine);
            service.Update(_machine);

            _mockMachineRepository.Verify(x => x.Update(It.IsAny<LocalMachineInfo>()),Times.Once);
        }
    }
}
