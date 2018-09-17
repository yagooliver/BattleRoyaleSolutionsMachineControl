using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BattleRoyaleSolutions.Application.Interfaces;
using BattleRoyaleSolutions.Core;
using BattleRoyaleSolutions.Core.Interfaces;
using BattleRoyaleSolutions.Core.Interfaces.Repositories;
using System.Linq;

namespace BattleRoyaleSolutions.Application.Application
{
    public class MachineApplicationService : IMachineApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILocalMachineInfoRepository localMachineInfoRepository;

        public MachineApplicationService(IUnitOfWork unitOfWork, ILocalMachineInfoRepository repository)
        {
            _unitOfWork = unitOfWork;
            localMachineInfoRepository = repository;
        }

        public bool Save(LocalMachineInfo obj)
        {
            using (_unitOfWork)
            {
                localMachineInfoRepository.Add(obj);
                return _unitOfWork.Commit();
            }
            
        }

        public IList<LocalMachineInfo> GetAll(Expression<Func<LocalMachineInfo, bool>> predicate)
        {
            return localMachineInfoRepository.GetAll().Where(predicate).ToList();
        }

        public LocalMachineInfo GetById(Guid id)
        {
            return localMachineInfoRepository.GetById(id);
        }

        public void Remove(Guid id)
        {
            using (_unitOfWork)
            {
                localMachineInfoRepository.Remove(id);
                _unitOfWork.Commit();
            }
        }

        public void Update(LocalMachineInfo obj)
        {
            using (_unitOfWork)
            {
                localMachineInfoRepository.Update(obj);
                _unitOfWork.Commit();
            }
        }
    }
}
