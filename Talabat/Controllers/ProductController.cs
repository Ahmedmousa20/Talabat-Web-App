using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talabat.BL.Interfaces;
using Talabat.BL.Repositories.Specifications;
using Talabat.DAL.Entities;
using Talabat.DTOs;

namespace Talabat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseApiController
    {
        private readonly IGenericRepo<Product> productsRepo;
        private readonly IMapper mapper;

        public ProductController(IGenericRepo<Product> productsRepo , IMapper mapper)
        {
            this.productsRepo = productsRepo;
            this.mapper = mapper;
        }

        #region comments
        //ActionResult vs IActionResult 
        //IActionResult -- mvc دا الى هوا ممكن ترجع اى حاجه...ودى يفضل استخدمها مع ال general دى مينفعش تاخد هيا هترجع اى ف بتبقا  
        //ActionResult -- api هنا هينفع احدد نوع الحاه الى انا عايز ارجعها جواها...ودى بيفضل اكتر استخدمها مع ال
        #endregion
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductWithTypeAndBrandSpecification();
            var products =await productsRepo.GeAllWithSpecAsync(spec);

            return Ok(mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProductById(int id)
        {
            var spec = new ProductWithTypeAndBrandSpecification(id);
            var product = await productsRepo.GetByIdWithSpecAsync(spec);

            return Ok(mapper.Map<Product, ProductToReturnDto>(product));
        }

    }
}
