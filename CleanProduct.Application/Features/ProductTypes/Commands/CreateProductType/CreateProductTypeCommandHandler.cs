using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanProduct.Application.DTOs;
using CleanProduct.Application.Interfaces;
using MediatR;

namespace CleanProduct.Application.Features.ProductTypes.Commands.CreateProductType
{
    public class CreateProductTypeCommandHandler :  IRequestHandler<CreateProductTypeCommand , ProductTypeDto>
    {
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly IMapper _mapper;

        public CreateProductTypeCommandHandler(IProductTypeRepository repository , IMapper mapper)
        {
            _productTypeRepository = repository;
            _mapper = mapper;
        }

        public async Task<ProductTypeDto> Handle(CreateProductTypeCommand request, CancellationToken cancellationToken)
        {
            // 1. Map Command to DTO (to pass to repository)
            var dto = _mapper.Map<ProductTypeDto>(request);

            // 2. Call the Repository (which maps DTO to Entity and Saves)
            var id = await _productTypeRepository.AddAsync(dto, cancellationToken);

            // 3. Return the created DTO (usually with the new ID)
            dto.Id = id;
            return dto;
        }


    }
}
