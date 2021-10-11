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
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repository.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_repository.Get(id));
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            _repository.Create(product);
            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult UpDate(Product product)
        {
            _repository.Update(product);
            return StatusCode(200);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return StatusCode(200);

        }
    }
}

