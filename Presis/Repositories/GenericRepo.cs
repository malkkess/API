using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Presis.Data;

namespace Presis.Repositories
{
    public class GenericRepo<TEntity, TKey>(StoreDbContext dbContext) : IGenericRepo<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public async Task AddAsync(TEntity entity)=> await dbContext.Set<TEntity>().AddAsync(entity);

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await dbContext.Set<TEntity>().ToListAsync();

        public async Task<TEntity?> GetIdAsync(TKey id)=> await dbContext.Set<TEntity>().FindAsync(id);


        public void Remove(TEntity entity)=> dbContext.Set<TEntity>().Remove(entity);

        public void Update(TEntity entity)=> dbContext.Set<TEntity>().Update(entity);
        public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity, TKey> specification)
        {
           return await SpecificationEval.CreateQuery(dbContext.Set<TEntity>() , specification).ToListAsync();
        }
        public async Task<TEntity?> GetIdAsync(ISpecification<TEntity, TKey> specification)
        {
            return await SpecificationEval.CreateQuery(dbContext.Set<TEntity>(), specification).FirstOrDefaultAsync();
        }

        public async Task<int> CountAsync(ISpecification<TEntity, TKey> specification)
        => await SpecificationEval.CreateQuery(dbContext.Set<TEntity>() , specification).CountAsync();
    }
}
