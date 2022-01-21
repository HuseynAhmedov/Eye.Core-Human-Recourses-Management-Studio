using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Api.DTOs.BookDtos
{
    public class BookListDto
    {
        public List<BookListItemDto> Items { get; set; }
        public int PageCount { get; set; }
    }
}
