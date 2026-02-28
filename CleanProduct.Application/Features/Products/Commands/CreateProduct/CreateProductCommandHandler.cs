using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanProduct.Application.Interfaces;
using CleanProduct.Domain.Entities;
using MediatR;

namespace CleanProduct.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {

        private readonly IProductRepository _repository;

        public CreateProductCommandHandler(IProductRepository repository)
        {

            _repository = repository;
        }

        public async Task<int> Handle(
           CreateProductCommand request,
            CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price,
                ProductTypeId = request.ProductTypeId
            };

           return await _repository.AddAsync(product, cancellationToken);







        }
    }
}
