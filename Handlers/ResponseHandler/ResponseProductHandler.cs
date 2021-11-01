using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Commands.Response;
using WebApplication2.Interfaces;
using WebApplication2.Model;

namespace WebApplication2.Handlers
{
    public class ResponseProductHandler : IResponseProductHandler
    {
        private readonly IProductRepository _repository;
        public ResponseProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<ProductResponse> HandlerGetAll()
        {
            var products = _repository.Get();

            List<ProductResponse> productResponses = new();

            foreach (var product in products)
            {
                productResponses.Add(new ProductResponse
                {
                    Price = product.Price,
                    Title = product.Title,
                });
            }
            return productResponses;
        }

        public ProductResponse HandlerGetById(int id)
        {
            Product product = _repository.Get(id);
            return new ProductResponse()
            {
                Price = product.Price,
                Title = product.Title,
            };
        }
    }
}
