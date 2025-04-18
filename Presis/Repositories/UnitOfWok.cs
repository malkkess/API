using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Contracts;
using DomainLayer.Models;
using Presis.Data;

namespace Presis.Repositories
{
    public class UnitOfWok(StoreDbContext dbContext) : IUnitOfWork
    {
        private readonly Dictionary<string, object> _Repos = [];
        public IGenericRepo<TEntity, TKey> GetRepo<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var typeName =typeof(TEntity).Name;
            if(_Repos.TryGetValue(typeName , out object? value))
                return(IGenericRepo<TEntity,TKey>) value;
            else
            {
                var Repo = new GenericRepo<TEntity,TKey>(dbContext);
                _Repos["typeName"]=Repo;
                return Repo;
            }
        }

        public async Task<int> SaveChangesAsync() => await dbContext.SaveChangesAsync();
        
    }
}
