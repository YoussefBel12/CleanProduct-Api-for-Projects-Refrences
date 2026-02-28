using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanProduct.Application.DTOs;
using CleanProduct.Application.Interfaces;
using CleanProduct.Domain.Entities;
using CleanProduct.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanProduct.Infrastructure.Repository
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        
        public ProductTypeRepository(AppDbContext  context , IMapper mapper)
        {

            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(ProductTypeDto productType , CancellationToken cancellationToken)
        {

            // 1. Map DTO to Entity
            var entity = _mapper.Map<ProductType>(productType);
            
            _context.ProductTypes.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;

        }


        public async Task<List<ProductTypeDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.ProductTypes
                .ProjectTo<ProductTypeDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }

    }
}
