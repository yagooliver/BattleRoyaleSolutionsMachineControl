using BattleRoyaleSolutions.Application.Models;
using System;
using System.Collections.Generic;

namespace BattleRoyaleSolutions.Application.Interfaces
{
    public interface ICommandLogApplicationService
    {
        bool Save(CommandLogViewModel obj);
        CommandLogViewModel GetById(Guid id);
        IEnumerable<CommandLogViewModel> GetAll();
        void Update(CommandLogViewModel obj);
        void Remove(Guid id);
    }
}
