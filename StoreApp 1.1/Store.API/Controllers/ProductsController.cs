using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.API.Data.DAL;
using Store.API.Data.Entities;
using Store.API.DTOs.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;

        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            return Ok(_context.Products.Include(x=> x.Category).ToList());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            Product product = _context.Products.FirstOrDefault(x => x.Id == id);

            if (product == null)
                return NotFound();
            return StatusCode(200, product);
        }

        [HttpPost]
        public IActionResult Create(ProductDto productDto)
        {
            Product product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                CategoryId = productDto.CategoryId
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            return StatusCode(201, product);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(ProductDto productDto,int id)
        {
            Product existProduct = _context.Products.FirstOrDefault(x => x.Id == id);

            if (existProduct == null) return NotFound();

            existProduct.Name = productDto.Name;
            existProduct.Price = productDto.Price;
            existProduct.ModifiedAt = DateTime.UtcNow.AddHours(4);
            existProduct.CategoryId = productDto.CategoryId;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product product = _context.Products.FirstOrDefault(x => x.Id == id && !x.IsDeleted);

            if (product == null) return NotFound();

            //_context.Products.Remove(product);
            product.IsDeleted = true;
            _context.SaveChanges();

            return NoContent();
        }
    }
}
