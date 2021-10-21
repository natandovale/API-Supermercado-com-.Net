using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Commands.Request;
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
        public IActionResult Create([FromServices] IRequestProductHandler handler,[FromBody] ProductRequest command)
        {
            var response = handler.HandlerCreate(command);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpDate([FromServices] IRequestProductHandler handler, [FromBody] ProductRequest command)
        {
            handler.HandlerUpdate(command);
            return StatusCode(200);
        }

        [HttpDelete]
        public IActionResult Delete([FromServices] IRequestProductHandler handler, [FromBody] int id)
        {
            handler.HandlerDelete(id);
            return StatusCode(200);
        }
    }
}

