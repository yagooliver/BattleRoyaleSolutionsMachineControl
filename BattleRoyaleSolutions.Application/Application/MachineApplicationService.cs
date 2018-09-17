using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BattleRoyaleSolutions.Application.Interfaces;
using BattleRoyaleSolutions.Core;
using BattleRoyaleSolutions.Core.Interfaces;
using BattleRoyaleSolutions.Core.Interfaces.Repositories;
using System.Linq;
using BattleRoyaleSolutions.Application.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace BattleRoyaleSolutions.Application.Application
{
    public class MachineApplicationService : IMachineApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILocalMachineInfoRepository localMachineInfoRepository;
        private readonly IMapper _mapper;

        public MachineApplicationService(IUnitOfWork unitOfWork, ILocalMachineInfoRepository repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            localMachineInfoRepository = repository;
            _mapper = mapper;
        }

        public bool Save(MachineViewModel obj)
        {
            using (_unitOfWork)
            {
                localMachineInfoRepository.Add(_mapper.Map<LocalMachineInfo>(obj));
                return _unitOfWork.Commit();
            }
            
        }

        public IEnumerable<MachineViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<LocalMachineInfo>, IEnumerable<MachineViewModel>>(localMachineInfoRepository.GetAll());
        }

        public MachineViewModel GetById(Guid id)
        {
            return _mapper.Map<MachineViewModel>(localMachineInfoRepository.GetById(id));
        }

        public void Remove(Guid id)
        {
            using (_unitOfWork)
            {
                localMachineInfoRepository.Remove(id);
                _unitOfWork.Commit();
            }
        }

        public void Update(MachineViewModel obj)
        {
            using (_unitOfWork)
            {
                localMachineInfoRepository.Update(_mapper.Map<LocalMachineInfo>(obj));
                _unitOfWork.Commit();
            }
        }
    }
}
