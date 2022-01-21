using AutoMapper;
using BookStore.Api.DTOs.AuthorDtos;
using BookStore.Core.Entities;
using BookStore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AuthorsController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(AuthorPostDto postDto)
        {
            Author author = new Author
            {
                BornYear = postDto.BornYear,
                FullName = postDto.FullName
            };

            _context.Authors.Add(author);
            _context.SaveChanges();

            //return StatusCode(201,new {author.Id});
            return StatusCode(201, new { Id = author.Id });
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Update(AuthorPostDto postDto , int id)
        {
            Author BaseAuthor = _context.Authors.FirstOrDefault(x => x.Id == id);

            BaseAuthor.FullName = postDto.FullName;
            BaseAuthor.BornYear = postDto.BornYear;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Author author = _context.Authors.Include(x=> x.Books).FirstOrDefault(x => x.Id == id && !x.IsDeleted);

            if (author == null) return NotFound();

            AuthorGetDto authorGetDto = _mapper.Map<AuthorGetDto>(author);

            return Ok(authorGetDto);
        }

        [HttpGet("")]
        public IActionResult GetAll(int page = 1)
        {
            var authors = _context.Authors.Include(x => x.Books).Where(x => !x.IsDeleted);

            AuthorListDto authorListDto = new AuthorListDto
            {
                Items = new List<AuthorListItemDto>(),
                TotalPage = (int)Math.Ceiling(authors.Count()/4d)
            };

            authors = authors.Skip((page - 1) * 4).Take(4);

            authorListDto.Items = _mapper.Map<List<AuthorListItemDto>>(authors.ToList());

            return Ok(authorListDto);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            Author BaseAuthor = _context.Authors.FirstOrDefault(x => x.Id == id);
            if (BaseAuthor == null)
            {
                return NotFound();
            }

            BaseAuthor.IsDeleted = true;
            _context.SaveChanges();

            return NoContent();
        }

    }
}
