using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Contracts;
using DomainLayer.Models;

namespace Service.Specifications
{
    abstract class BaseSpecifications<TEntity, TKey> : ISpecification<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        protected BaseSpecifications(Expression<Func<TEntity, bool>>? expression)
        {
            Criteria = expression;
        }

        public Expression<Func<TEntity, bool>>? Criteria { get; private set; }
        public List<Expression<Func<TEntity, object>>> IncludeExpression { get; }=[];


        protected void AddInclude(Expression<Func<TEntity, object>> includex) => IncludeExpression.Add(includex);
        public Expression<Func<TEntity, object>> OrderBy { get; private set; }

        public Expression<Func<TEntity, object>> OrderByDescending { get; private set; }


        protected void AddOrderBy(Expression<Func<TEntity, object>> orderExp) => OrderBy = orderExp;
        protected void AddOrderByDescending(Expression<Func<TEntity, object>> OrderDesc) => OrderByDescending = OrderDesc;
        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPagination { get; set; }
        protected void ApplyPagination (int PageSize ,int PageIndex)
        {
            IsPagination = true;
            Take = PageSize;
            Skip=(PageIndex-1)*PageSize;
        }
    }

}

