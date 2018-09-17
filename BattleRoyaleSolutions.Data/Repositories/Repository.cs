using BattleRoyaleSolutions.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleRoyaleSolutions.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly MachineRemoteControlContext _context;
        public Repository(MachineRemoteControlContext context)
        {
            _context = context;
        }

        public TEntity Add(TEntity obj) => _context.Add(obj).Entity;

        public IQueryable<TEntity> GetAll() => _context.Set<TEntity>();

        public TEntity GetById(Guid id) => _context.Set<TEntity>().Find(id);

        public void Remove(Guid id) => _context.Remove(GetById(id));

        public void Update(TEntity obj) => _context.Entry(obj).State = EntityState.Modified;
    }
}
