using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using CleanProduct.Application.DTOs;
namespace CleanProduct.Application.Features.ProductTypes.Commands.CreateProductType
{
    public class CreateProductTypeCommand : IRequest<ProductTypeDto>
    {
        public string Name { get; set; } 
    }
}
