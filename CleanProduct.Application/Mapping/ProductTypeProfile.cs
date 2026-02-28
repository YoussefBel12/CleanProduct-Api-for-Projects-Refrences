using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanProduct.Application.DTOs;
using CleanProduct.Application.Features.ProductTypes.Commands.CreateProductType;
using CleanProduct.Domain.Entities;

namespace CleanProduct.Application.Mapping
{
    public class ProductTypeProfile : Profile
    {
        public ProductTypeProfile()
        {
            CreateMap<ProductType, ProductTypeDto>().ReverseMap();
            CreateMap<CreateProductTypeCommand ,ProductTypeDto >().ReverseMap();
        }

    }
}
