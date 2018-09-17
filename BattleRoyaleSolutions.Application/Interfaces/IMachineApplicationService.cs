using BattleRoyaleSolutions.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BattleRoyaleSolutions.Application.Interfaces
{
    public interface IMachineApplicationService
    {
        bool Save(MachineViewModel obj);
        MachineViewModel GetById(Guid id);
        IEnumerable<MachineViewModel> GetAll();
        void Update(MachineViewModel obj);
        void Remove(Guid id);
    }
}
