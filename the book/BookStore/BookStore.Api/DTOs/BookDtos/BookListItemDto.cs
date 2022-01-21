using BookStore.Api.DTOs.AuthorDtos;
using BookStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Api.DTOs.BookDtos
{
    public class BookListItemDto
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public double CostPrice { get; set; }
        public double SalePrice { get; set; }
        public Author Author { get; set; }
    }
}
