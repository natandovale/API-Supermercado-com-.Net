using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Model;
using WebApplication2.Repositories;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ProductRepository _repository;
        public HomeController(ProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("v1/products")]
        public IEnumerable<Product> Get()
        {
         return _repository.Get();
        }

        [HttpPost("v1/products")]
        public string Post(Product product)
        {
            _repository.Create(product);
            return "Produto salvo com sucesso";
        }

    }
}

