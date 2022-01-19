using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.DTOs.CategoryDtos
{
    public class CategoryDto
    {
        public string Name { get; set; }
    }
    public class CategoryDtoValidator : AbstractValidator<CategoryDto>
    {
        public CategoryDtoValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(150).WithMessage("Max 150 ola biler")
                .MinimumLength(2).WithMessage("Min 2 ola biler")
                .NotNull().WithMessage("Mecburidir");
        }
    }
}
