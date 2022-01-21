using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Api.DTOs.BookDtos
{
    public class BookPostDto
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public double SalePrice { get; set; }
    }

    public class BookPostDtoValidation : AbstractValidator<BookPostDto>
    {
        public BookPostDtoValidation()
        {
            RuleFor(x => x.Name).MaximumLength(150).NotNull();
            RuleFor(x => x.Desc).MaximumLength(500).NotNull();
            RuleFor(x => x.SalePrice).NotNull();
        }
    }

}
