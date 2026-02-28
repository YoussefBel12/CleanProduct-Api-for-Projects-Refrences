using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanProduct.Application.DTOs;
using CleanProduct.Domain.Entities;

namespace CleanProduct.Application.Interfaces
{
    public interface IProductTypeRepository
    {
        Task<int> AddAsync(ProductTypeDto productType, CancellationToken cancellationToken);

        Task<List<ProductTypeDto>> GetAllAsync(CancellationToken cancellationToken);

    }
}
