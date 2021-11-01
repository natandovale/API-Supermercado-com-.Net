using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApplication2.Commands.Request;
using WebApplication2.Commands.Response;
using WebApplication2.Interfaces;

namespace WebApplication2.HandlersMediator.Request
{
    public class DeleteCartHandler : IRequestHandler<DeleteCartRequest, CartResponse>
    {
        private readonly ICartRepository _repository;
        public DeleteCartHandler(ICartRepository repository)
        {
            _repository = repository;
        }

        public Task<CartResponse> Handle(DeleteCartRequest request, CancellationToken cancellationToken)
        {
            _repository.Delete(request.Id);
            var result = new CartResponse
            {
                Id = request.Id,
            };

            return Task.FromResult(result);
        }
    }
}
