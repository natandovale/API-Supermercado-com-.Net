using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApplication2.Commands.Request;
using WebApplication2.Commands.Response;
using WebApplication2.Interfaces;
using WebApplication2.Model;

namespace WebApplication2.HandlersMediator.Request
{
    public class CreateProductHandler : IRequestHandler<CreateProductResponse, ProductResponse>
    {
        private readonly IProductRepository _repository;
        public CreateProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task<ProductResponse> Handle(CreateProductResponse request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Title, request.Price);
            _repository.Create(product);

            var result = new ProductResponse
            {
                Price = product.Price,
                Title = product.Title
            };

            return Task.FromResult(result);
        }
    }
}
