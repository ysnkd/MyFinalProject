using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIss.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //ATTRIBUTE
    
    public class ProductsController : ControllerBase
    {
        //Lose coupled
        //naming convention
        //IoC Container -- Inversion of Control-> referansları belleğe atıyor.

        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet("getall")]
        

        public IActionResult GetAll()
        {
            //Swagger
            //dependency chain ---
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
        [HttpGet("getbycategory")]
        //bu teknikte controller'dan başlıyoruz.
        //Aliance verebiliriz.
        public IActionResult GetByCategory(int categoryId)
        {
            var result = _productService.GetAllByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
       
    }
}
