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
    public class UpdateProductHandle : IRequestHandler<UpdateProductRequest, ProductResponse>
    {
        private readonly IProductRepository _repository;
        public UpdateProductHandle(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task<ProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Id, request.Title, request.Price);
            _repository.Update(product);

            var result = new ProductResponse
            {
                Price = request.Price,
                Title = request.Title
            };

            return Task.FromResult(result);
        }
    }
}
