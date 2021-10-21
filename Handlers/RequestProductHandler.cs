using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Commands.Request;
using WebApplication2.Commands.Response;
using WebApplication2.Interfaces;
using WebApplication2.Model;

namespace WebApplication2.Handlers
{
    public class RequestProductHandler : IRequestProductHandler
    {
        private readonly IProductCart _repository;

        public RequestProductHandler(IProductCart repository)
        {
            _repository = repository;
        }

        public void HandlerCreate(ProductRequest command)
        {
            var product = new Product(command.Title, command.Price );
            _repository.Create(product);

        }

        public void HandlerDelete(int id)
        {
            _repository.Delete(id);
        }

        public void HandlerUpdate(ProductRequest command)
        {
            var product = new Product(command.Id, command.Title, command.Price);
            _repository.Update(product);
        }
    }
}
