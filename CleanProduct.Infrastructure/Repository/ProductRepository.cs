using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanProduct.Application.Interfaces;
using CleanProduct.Domain.Entities; 
using CleanProduct.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanProduct.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(Product product, CancellationToken cancellationToken)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync(cancellationToken);
            return product.Id;
        }

       
        public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Products
             .Include(p => p.ProductType)
             .ToListAsync(cancellationToken);
        }


    }
}
