using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Commands.Response;
using WebApplication2.Interfaces;
using WebApplication2.Model;

namespace WebApplication2.Handlers
{
    public class ResponseCartHandler : IResponseCartHandler
    {
        private readonly ICartRepository _repository;
        public ResponseCartHandler(ICartRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<CartResponse> HandlerGetAll()
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
            return cartResponses;
        }

        public CartResponse HandlerGetById(int id)
        {
            Cart cart = _repository.GetCartProduct(id);

            var cartResponse = new CartResponse()
            {
                Id = cart.Id,
                Nome = cart.Nome,
                Products = cart.Products,
                SomaTotal = cart.SomaTotal
            };

            return cartResponse;
        }
    }
}
