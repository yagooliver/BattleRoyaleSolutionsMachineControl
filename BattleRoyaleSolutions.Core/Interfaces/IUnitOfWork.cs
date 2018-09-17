using System;

namespace BattleRoyaleSolutions.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
