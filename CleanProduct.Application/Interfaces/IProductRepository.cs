using CleanProduct.Domain.Entities;

namespace CleanProduct.Application.Interfaces;

public interface IProductRepository
{
    Task<int> AddAsync(Product product, CancellationToken cancellationToken);

    Task<List<Product>> GetAllAsync(CancellationToken cancellationToken);


}

