using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DAL.Entities;

namespace Talabat.BL.Repositories.Specifications
{
    public class ProductWithTypeAndBrandSpecification:BaseSpecification<Product>
    {
        #region comments
        //وكذلك بعمل كدا مع ى كلاس عايز وانا بجيب بياناتو Product بتاعه ال includes الكلاس دا انا عاملو عشان اضيف من خلاله ال
        //بتاعتو includes اجيب معاه ال
        #endregion
        public ProductWithTypeAndBrandSpecification()
        {
            AddInclude(P => P.ProductType);
            AddInclude(P => P.ProductBrand);
        }

        public ProductWithTypeAndBrandSpecification(int id):base(P=>P.Id == id)
        {
            AddInclude(P => P.ProductType);
            AddInclude(P => P.ProductBrand);
        }
    }
}
