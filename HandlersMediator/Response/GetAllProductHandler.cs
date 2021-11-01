using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApplication2.Commands.Response;
using WebApplication2.Interfaces;

namespace WebApplication2.HandlersMediator.Response
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductsResponse, IEnumerable<ProductResponse>>
    {
        private readonly IProductRepository _repository;
        public GetAllProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductResponse>> Handle(GetAllProductsResponse request, CancellationToken cancellationToken)
        {
            var products = _repository.Get();

            List<ProductResponse> productResponses = new();

            foreach (var product in products)
            {
                productResponses.Add(new ProductResponse
                {
                    Id = product.Id,
                    Price = product.Price,
                    Title = product.Title,
                });
            }
            return await Task.FromResult(productResponses);
        }
    }
}
