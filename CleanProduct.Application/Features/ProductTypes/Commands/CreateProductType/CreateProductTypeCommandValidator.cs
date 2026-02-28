using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanProduct.Application.DTOs;
using FluentValidation;

namespace CleanProduct.Application.Features.ProductTypes.Commands.CreateProductType
{
    public class CreateProductTypeCommandValidator : AbstractValidator<CreateProductTypeCommand >
    {

        public CreateProductTypeCommandValidator()
        {
            RuleFor(x => x.Name)
                 .NotEmpty()
                 .MaximumLength(100);
        }

    }
}
