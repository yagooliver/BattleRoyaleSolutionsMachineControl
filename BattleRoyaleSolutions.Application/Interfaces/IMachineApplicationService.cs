using BattleRoyaleSolutions.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BattleRoyaleSolutions.Application.Interfaces
{
    public interface IMachineApplicationService
    {
        bool Save(LocalMachineInfo obj);
        LocalMachineInfo GetById(Guid id);
        IList<LocalMachineInfo> GetAll(Expression<Func<LocalMachineInfo, bool>> Predicate);
        void Update(LocalMachineInfo obj);
        void Remove(Guid id);
    }
}
