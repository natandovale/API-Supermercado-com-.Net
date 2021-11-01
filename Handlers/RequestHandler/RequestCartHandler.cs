using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Commands.Request;
using WebApplication2.DTOs;
using WebApplication2.Interfaces;
using WebApplication2.Model;

namespace WebApplication2.Handlers
{
    public class RequestCartHandler : IRequestCartHandler
    {
        private readonly ICartRepository _repository;
        public RequestCartHandler(ICartRepository repository)
        {
            _repository = repository;
        }

        public void AssociateProduct(int idProduto, int idCart)
        {
            _repository.AddProductToCart(idProduto, idCart);
        }

        public void HandlerCreate(CreateCartRequest command)
        {
            var cart = new Cart(command.Nome);
            _repository.Create(cart);
        }

        public void HandlerDelete(int id)
        {
            _repository.Delete(id);
        }

        public void HandlerUpdate(CreateCartRequest command)
        {
            var cart = new Cart(command.Id, command.Nome);
            _repository.Update(cart); 
        }
    }
}
