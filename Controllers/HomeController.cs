using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Interfaces;
using WebApplication2.Model;
using WebApplication2.Repositories;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IProductRepository _repository;
        public HomeController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("v1/products")]
        public IEnumerable<Product> GetAll()
        {
         return _repository.Get();
        }

        [HttpGet("v1/product")]
        public IEnumerable<Product> Get(int id)
        {
            return _repository.Get(id);
        }

        [HttpPost("v1/products")]
        public string Post(Product product)
        {
            _repository.Create(product);
            return "Produto salvo com sucesso";
        }

        [HttpPut("v1/products")]
        public string UpDate(Product product)
        {
            _repository.Update(product);
            return "Produto Atualizado com sucesso";
        }

        [HttpDelete("v1/products")]
        public string Delete(int id)
        {
            _repository.Delete(id);
            return "Produto excluido com sucesso";
        }
    }
}

