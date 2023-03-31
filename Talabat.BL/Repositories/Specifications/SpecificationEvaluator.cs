using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DAL.Entities;

namespace Talabat.BL.Repositories.Specifications
{
    public class SpecificationEvaluator<TEntity> where TEntity:BaseEntity
    {
        #region comments
        //IQueryable عموما بيبقا نوعها  query والمفروض ان ال query هنا المفروض ان الفانشن دى الى هترجعلى ال
        //inputQuery -- context.set<Product> دى كدا عف حالتى هنا مثلا هتمثلى ال
        //spec --.Where(p=>p.id==id) او .Include(P=>P.productBrand).Include(P=>P.ProductType) سواء query ودى طبعا بتمثلى بقا ال
        #endregion
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery , ISpecification<TEntity> spec)
        {
            var query = inputQuery;
            if (spec.Criteria != null)
                query = query.Where(spec.Criteria);
               //context.set<Product>.Where(p=>p.id==id)
            query = spec.Includes.Aggregate(query, (currentQuery, include) => currentQuery.Include(include));
            //context.set<Product>.Include(P=>P.productBrand).Include(P=>P.ProductType)
            //or
            //context.set<Product>.Where(p=>p.id==id).Include(P=>P.productBrand).Include(P=>P.ProductType)
            #region Comments
            //Aggregate --include ورا include واحده واحده وتضيف Includes ألى فوقى دا المفروض انها بعتدى على ال Syntax دى كدا بال
            #endregion

            return query;
        }
    }
}
