using BigBoxFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBoxFramework.Core.DataAccess.EntityRepository
{
    public class EfQueryableRepository<TEntity> : IQueryableReposity<TEntity>
        where TEntity: class, IEntity, new()
    {
        private DbContext _context;
        private IDbSet<TEntity> _entities;

        public EfQueryableRepository(DbContext context)
        {
            _context = context;
        }
        public IQueryable<TEntity> Table => this.Entities;

        protected virtual IDbSet<TEntity> Entities
        {
            get
            {
               return _entities ?? (_entities = _context.Set<TEntity>());
            }
        }
    }
}
