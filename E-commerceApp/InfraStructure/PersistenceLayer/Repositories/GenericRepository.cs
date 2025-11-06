using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using PersistenceLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayer.Repositories
{
    public class GenericRepository<TEntity, TKey>(StoreDbContext _storeDb) : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public async Task AddAsync(TEntity entity)
        {
          await _storeDb.Set<TEntity>().AddAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
            => await _storeDb.Set<TEntity>().ToListAsync();

       

        public async Task<TEntity?> GetByIdAsync(TKey id)
        
           =>await _storeDb.Set<TEntity>().FindAsync(id);

       

        public void Remove(TEntity entity)
        {
            _storeDb.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
          _storeDb.Set<TEntity>().Update(entity);
        }


        #region With Specification

        public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity, TKey> specifications)
        {
            return await SpecificationEvaluator.CreateQuery(_storeDb.Set<TEntity>(),specifications).ToListAsync();
        }
        public async Task<TEntity?> GetByIdAsync(ISpecifications<TEntity, TKey> specifications)
        {
            return await SpecificationEvaluator.CreateQuery(_storeDb.Set<TEntity>(), specifications).FirstOrDefaultAsync();
        }

        public async Task<int?> CountAsync(ISpecifications<TEntity, TKey> specifications)
        {
            return await SpecificationEvaluator.CreateQuery(_storeDb.Set<TEntity>(), specifications).CountAsync();
        }
        #endregion
    }
}
