using AutoMapper;
using BattleRoyaleSolutions.Application.Interfaces;
using BattleRoyaleSolutions.Application.Models;
using BattleRoyaleSolutions.Core.Entities;
using BattleRoyaleSolutions.Core.Interfaces;
using BattleRoyaleSolutions.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;

namespace BattleRoyaleSolutions.Application.Application
{
    public class CommandLogApplicationService : ICommandLogApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommandLogRepository _commandLogRepository;
        private readonly IMapper _mapper;

        public CommandLogApplicationService(IUnitOfWork unitOfWork, ICommandLogRepository _commandLogRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this._commandLogRepository = _commandLogRepository;
            _mapper = mapper;
        }

        public bool Save(CommandLogViewModel obj)
        {
            using (_unitOfWork)
            {
                _commandLogRepository.Add(_mapper.Map<CommandLog>(obj));
                return _unitOfWork.Commit();
            }

        }

        public IEnumerable<CommandLogViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<CommandLog>, IEnumerable<CommandLogViewModel>>(_commandLogRepository.GetAll());
        }

        public CommandLogViewModel GetById(Guid id)
        {
            return _mapper.Map<CommandLogViewModel>(_commandLogRepository.GetById(id));
        }

        public void Remove(Guid id)
        {
            using (_unitOfWork)
            {
                _commandLogRepository.Remove(id);
                _unitOfWork.Commit();
            }
        }

        public void Update(CommandLogViewModel obj)
        {
            using (_unitOfWork)
            {
                _commandLogRepository.Update(_mapper.Map<CommandLog>(obj));
                _unitOfWork.Commit();
            }
        }
    }
}
