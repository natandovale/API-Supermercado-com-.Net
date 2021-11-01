using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApplication2.Commands.Response;
using WebApplication2.Interfaces;
using WebApplication2.Model;

namespace WebApplication2.HandlersMediator.Response
{
    public class GetCartByIdHandler : IRequestHandler<GetCartByIdResponse, CartResponse>
    {
        private readonly ICartRepository _repository;
        public GetCartByIdHandler(ICartRepository repository)
        {
            _repository = repository;
        }

        public Task<CartResponse> Handle(GetCartByIdResponse request, CancellationToken cancellationToken)
        {
            Cart cart = _repository.GetCartProduct(request.Id);

            var cartResponse = new CartResponse()
            {
                Id = cart.Id,
                Nome = cart.Nome,
                Products = cart.Products,
                SomaTotal = cart.SomaTotal
            };

            return Task.FromResult(cartResponse);
        }
    }
}
