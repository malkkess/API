using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Presis
{
    static class SpecificationEval
    {
        public static IQueryable<TEntity> CreateQuery<TEntity , TKey>(IQueryable<TEntity> startPoint ,ISpecification<TEntity , TKey> spec) where TEntity :BaseEntity<TKey> 
        {
            var Query = startPoint;
            if(spec.Criteria is not null)
            {
                Query = Query.Where(spec.Criteria);
            }
            if (spec.IncludeExpression is not null && spec.IncludeExpression.Count >0)
            {
                //foreach(var exp in spec.IncludeExpression)
                //{
                //    Query = Query.Include(exp);
                //}
                Query = spec.IncludeExpression.Aggregate(Query, (CurrentQuery, IncludeExp) => CurrentQuery.Include(IncludeExp));

            }
            return Query;
        }
    }
}
