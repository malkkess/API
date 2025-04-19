using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;

namespace DomainLayer.Contracts
{
    public interface IGenericRepo<TEntity , TKey>where TEntity : BaseEntity<TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetIdAsync(TKey id);
        Task AddAsync(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity, TKey> specification);
        Task<TEntity?> GetIdAsync(ISpecification<TEntity, TKey> specification);

    }
}
