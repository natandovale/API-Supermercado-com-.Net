using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Commands.Request;
using WebApplication2.DTOs;
using WebApplication2.Interfaces;
using WebApplication2.Model;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll([FromServices] IResponseCartHandler handler)
        {
            var response = handler.HandlerGetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromServices] IResponseCartHandler handler, int id)
        {
            var response = handler.HandlerGetById(id);
            
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post([FromServices] IRequestCartHandler handler,[FromBody] CartRequest command)
        {
            handler.HandlerCreate(command);
            return StatusCode(201);
        }

        [HttpPost("associate_product")]
        public IActionResult AssociateProduct([FromServices] IRequestCartHandler handler , AssociationProductCartDTO associationProductCart)
        {
            handler.AssociateProduct(associationProductCart.IdProduct, associationProductCart.IdCart);
            return StatusCode(200);
        }

        [HttpPut]
        public IActionResult UpDate([FromServices] IRequestCartHandler handler, [FromBody] CartRequest command)
        {
            handler.HandlerUpdate(command);
            return StatusCode(200);
        }

        [HttpDelete]
        public IActionResult Delete([FromServices] IRequestCartHandler handler, int id)
        {
            handler.HandlerDelete(id);
            return StatusCode(200);

        }
    }
}
