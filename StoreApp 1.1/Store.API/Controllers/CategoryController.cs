using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.API.Data.DAL;
using Store.API.Data.Entities;
using Store.API.DTOs.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly StoreContext _context;

        public CategoryController(StoreContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("")]
        public ActionResult GetAll()
        {
            List<Category> categories = _context.Categories.Include(x => x.Products).ToList();
            if (categories == null)
            {
                return NotFound();

            }
            return StatusCode(200, categories);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(int id)
        {
            Category category = _context.Categories.Include(x=> x.Products).FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return StatusCode(200, category);
        }

        [HttpPost]
        public ActionResult Create(CategoryDto newCategory)
        {
            if (newCategory == null)
            {
                return BadRequest();
            }
            Category category = new Category
            { 
                Name = newCategory.Name
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
            return StatusCode(201, category);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Update(CategoryDto updateCategory , int id )
        {
            Category baseCategory = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (baseCategory == null)
            {
                return BadRequest();
            }

            baseCategory.Name = updateCategory.Name;
            baseCategory.ModifiedAt = DateTime.UtcNow.AddHours(4);

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Category category = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return BadRequest();
            }
            category.IsDeleted = true;
            _context.SaveChanges();
            return NoContent();
        }

    }
}
