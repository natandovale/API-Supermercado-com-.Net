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
    public class GetAllCartHandler : IRequestHandler<GetAllCartResponse, IEnumerable<CartResponse>>
    {
        private readonly ICartRepository _repository;
        public GetAllCartHandler(ICartRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CartResponse>> Handle(GetAllCartResponse request, CancellationToken cancellationToken)
        {
            var carts = _repository.Get();

            List<CartResponse> cartResponses = new();

            foreach (var cart in carts)
            {
                cartResponses.Add(new CartResponse
                {
                    Id = cart.Id,
                    Nome = cart.Nome,
                    Products = cart.Products,
                    SomaTotal = cart.SomaTotal
                });
            }
            return await Task.FromResult(cartResponses);
        }
    }
}
