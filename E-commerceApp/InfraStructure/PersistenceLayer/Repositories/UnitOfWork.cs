using DomainLayer.Contracts;
using DomainLayer.Models;
using PersistenceLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayer.Repositories
{
    public class UnitOfWork(StoreDbContext _storeContext) : IUnitOfWork
    {
        private readonly Dictionary<string,object> _repositories = [];
        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var typeName= typeof(TEntity).Name;
            if (_repositories.ContainsKey(typeName))
            {
                return _repositories[typeName] as IGenericRepository<TEntity,TKey>;

            }
            else
            {
                var repo = new GenericRepository<TEntity, TKey>(_storeContext);
                _repositories.Add(typeName, repo);
                return repo;
            }
            
            
        }

        public async Task SaveChangesAsync()
          =>await _storeContext.SaveChangesAsync();
    }
}
