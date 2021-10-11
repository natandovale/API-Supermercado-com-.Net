using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.DTOs;
using WebApplication2.Interfaces;
using WebApplication2.Model;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartsController : ControllerBase
    {
        private readonly ICartRepository _repository;
        public CartsController(ICartRepository repository)
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
        public IActionResult Post(Cart cart)
        {
            _repository.Create(cart);
            return StatusCode(201);
        }

        [HttpPost("associate_product")]
        public IActionResult AssociateProduct([FromBody]AssociationProductCartDTO association)
        {
            _repository.AddProductToCart(association.IdProduct, association.IdCart);
            return StatusCode(200);
        }

        [HttpPut]
        public IActionResult UpDate(Cart cart)
        {
            _repository.Update(cart);
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
