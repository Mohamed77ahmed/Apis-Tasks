using DomainLayer.Contracts;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Specifications
{
    public abstract class BaseSpecifications<TEntity, TKey> : ISpecifications<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
    {
        public BaseSpecifications(Expression<Func<TEntity, bool>>? criteria)
        {
            Criteria=criteria;
        }
        public Expression<Func<TEntity, bool>> ?Criteria {  get; private set; }

        public List<Expression<Func<TEntity, object>>> IncludesExpression { get; } = [];

        public Expression<Func<TEntity, object>> OrderBy { get; private set; }

        public Expression<Func<TEntity, object>> OrderByDesc { get; private set; }

        

        protected void AddInclude(Expression<Func<TEntity, object>> includeExpression)
        {
            IncludesExpression.Add(includeExpression);
        }

        #region OrderBy
        protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression)
        {
            OrderBy=orderByExpression;
        }

        protected void AddOrderByDescending(Expression<Func<TEntity, object>> orderByDescExpression)
        {
            OrderByDesc=orderByDescExpression;
        }

        #endregion

        #region pagination
        public int Take {  get;private set; }

        public int Skip { get; private set; }

        public bool IsPaginated { get; private set; }

        protected void ApplyPagination(int pageSize,int pageIndex) 
        { 
            Take=pageSize;
            Skip=(pageIndex-1)*pageSize;
            IsPaginated=true;

        }
        #endregion



    }
}
