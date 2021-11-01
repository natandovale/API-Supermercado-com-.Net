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
    public class UpdateCartHandler : IRequestHandler<UpdateCartRequest, CartResponse>
    {
        private readonly ICartRepository _repository;
        public UpdateCartHandler(ICartRepository repository)
        {
            _repository = repository;
        }


        public Task<CartResponse> Handle(UpdateCartRequest request, CancellationToken cancellationToken)
        {
            var cart = new Cart(request.Id, request.Nome);
            _repository.Update(cart);

            var result = new CartResponse
            {
                Id = request.Id,
                Nome = request.Nome
            };

            return Task.FromResult(result);
        }
    }
}
