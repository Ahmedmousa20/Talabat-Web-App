using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talabat.DAL.Entities;
using Talabat.DTOs;

namespace Talabat.Helpers
{
    public class MapperProfiles:Profile
    {
        public MapperProfiles()
        {
            #region Comments
            //d stands for-> Destination -> ProductToReturnDto
            //s stands for-> source -> Product
            //o => o.MapFrom()-->بتاعى ياخدها Destination بحط فيها القيمه الى انا عايز ال
            #endregion
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name));
           
        }
    }
}
