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
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, ProductResponse>
    {
        private readonly IProductRepository _repository;
        public DeleteProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task<ProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            if(_repository.Get(request.Id) == null)
            {
                throw new Exception("Produto não encontrado");
            }

            _repository.Delete(request.Id);
            var result = new ProductResponse
            {
                Id = request.Id
            };

            return Task.FromResult(result);
        }
    }
}
