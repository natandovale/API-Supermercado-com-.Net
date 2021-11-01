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

namespace WebApplication2.HandlersMediator.Response
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdResponse, ProductResponse>
    {
        private readonly IProductRepository _repository;
        public GetProductByIdHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public Task<ProductResponse> Handle(GetProductByIdResponse request, CancellationToken cancellationToken)
        {
            Product productId = _repository.Get(request.Id);
            var product = new ProductResponse()
            {
                Id = productId.Id,
                Price = productId.Price,
                Title = productId.Title,
            };

            return Task.FromResult(product);

        }
    }
}
