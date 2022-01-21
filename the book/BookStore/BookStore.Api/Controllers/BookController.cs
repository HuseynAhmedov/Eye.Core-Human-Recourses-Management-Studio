using AutoMapper;
using BookStore.Api.DTOs.BookDtos;
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
    public class BookController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public BookController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult Create(BookPostDto postDto)
        {
            Author author = _context.Authors.FirstOrDefault(x => x.Id == postDto.AuthorId);
            if (author == null)
            {
                return BadRequest();
            }
            Book book = new Book
            {
                Name = postDto.Name,
                Desc = postDto.Desc,
                SalePrice = postDto.SalePrice,
                AuthorId = postDto.AuthorId
            };
            _context.Books.Add(book);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPost]
        [Route("{id}")]
        public ActionResult Update(BookPostDto postDto, int id)
        {
            Book baseBook = _context.Books.FirstOrDefault(x => x.Id == id);
            if (baseBook == null)
            {
                return NotFound();
            }
            Author author = _context.Authors.FirstOrDefault(x => x.Id == postDto.AuthorId);
            if (author == null)
            {
                return BadRequest();
            }

            baseBook.Name = postDto.Name;
            baseBook.Desc = postDto.Desc;
            baseBook.AuthorId = postDto.AuthorId;
            baseBook.SalePrice = postDto.SalePrice;
            baseBook.ModifiedAt = DateTime.UtcNow.AddHours(4);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpGet]
        public ActionResult GetAll(int page = 1)
        {
            var book = _context.Books.Include(x => x.Author).Where(x => !x.IsDeleted);
            if (book == null)
            {
                return NotFound();
            }
            BookListDto bookListDto = new BookListDto
            {
                Items = new List<BookListItemDto>(),
                PageCount = (int)Math.Ceiling(book.Count() / 4d)
            };
            book = book.Skip((page - 1) * 4).Take(4);
            bookListDto.Items = _mapper.Map<List<BookListItemDto>>(book.ToList());
            return StatusCode(200, bookListDto);
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(int id)
        {
            var book = _context.Books.Include(x => x.Author).Where(x => !x.IsDeleted).FirstOrDefault(x=> x.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            BookGetDto bookGetDto = _mapper.Map<BookGetDto>(book);
            return StatusCode(200, bookGetDto);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var book = _context.Books.Include(x => x.Author).Where(x => !x.IsDeleted).FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            book.IsDeleted = true;
            return NoContent();
        }
    }
}
