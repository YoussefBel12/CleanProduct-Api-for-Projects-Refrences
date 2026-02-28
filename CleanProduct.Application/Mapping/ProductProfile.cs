using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanProduct.Application.DTOs;
using CleanProduct.Domain.Entities;
namespace CleanProduct.Application.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
          .ForMember(d => d.ProductTypeName,
              opt => opt.MapFrom(s => s.ProductType.Name)).ReverseMap();
        }

    }
}
