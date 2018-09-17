using BattleRoyaleSolutions.Core.Interfaces;
using BattleRoyaleSolutions.Core.Interfaces.Repositories;
using BattleRoyaleSolutions.Data.Repositories;

namespace BattleRoyaleSolutions.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MachineRemoteControlContext _context;
        private bool _disposed = false;

        public ILocalMachineInfoRepository LocalMachineInfoRepository { get; set; }
        
        public UnitOfWork()
        {
            _context = new MachineRemoteControlContext();
            LocalMachineInfoRepository = new LocalMachineInfoRepository(_context);
        }

        public void Dispose() => _context.Dispose();

        public bool Commit() => _context.SaveChanges() > 0;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing && _context != null)
            {
                _context.Dispose();
            }

            _disposed = true;
        }
    }
}
