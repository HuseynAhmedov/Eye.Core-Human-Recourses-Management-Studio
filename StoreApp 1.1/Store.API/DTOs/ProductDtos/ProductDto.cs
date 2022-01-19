using FluentValidation;
using Store.API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.DTOs.ProductDtos
{
    public class ProductDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public  Category Category { get; set; }
        public int CategoryId { get; set; }
    }

    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(150).WithMessage("Max 150 ola biler")
                .MinimumLength(2).WithMessage("Min 2 ola biler")
                .NotNull().WithMessage("Mecburidir");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("0-dan asagi ola bilmez!")
                .NotNull().WithMessage("Mecburidir");


            RuleFor(x => x).Custom((x, context) =>
            {
                if(x.Name.Length>5 && x.Price < 10)
                {
                    

                    context.AddFailure("Price", "Name 5-den boyukdurse Price 10-dan kicik ola bilmez");
                }
            });

        }
    }
}
