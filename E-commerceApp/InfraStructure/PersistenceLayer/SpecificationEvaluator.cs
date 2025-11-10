using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayer
{
    internal static class SpecificationEvaluator
    {
        public static IQueryable<TEntity> CreateQuery<TEntity,TKey>(IQueryable<TEntity> inputQuery ,ISpecifications<TEntity,TKey> specifications)
            where TEntity : BaseEntity<TKey>
        {
            var query = inputQuery;
            if(specifications.Criteria is not null) 
            { 
                query=query.Where(specifications.Criteria);

            }
            if (specifications.OrderBy is not null)
                query = query.OrderBy(specifications.OrderBy);


            if (specifications.OrderByDesc is not null)
                query = query.OrderBy(specifications.OrderByDesc);


            if (specifications.IncludesExpression is not null&&specifications.IncludesExpression.Count>0)
            {
                foreach (var include in specifications.IncludesExpression)
                    query = query.Include(include);
                    
                
            }
            if (specifications.IsPaginated) 
            { 
                query=query.Skip(specifications.Skip).Take(specifications.Take);    
            }


            return query;

        }

    }
}
