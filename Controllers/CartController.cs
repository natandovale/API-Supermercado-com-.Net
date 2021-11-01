using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Commands.Request;
using WebApplication2.Commands.Response;
using WebApplication2.DTOs;
using WebApplication2.Interfaces;
using WebApplication2.Model;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {

        [HttpGet("{id}")]
        public IActionResult Get([FromServices] IMediator mediator, [FromBody] GetCartByIdResponse command)
        {
            var response = mediator.Send(command);
            
            return Ok(response);
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAll([FromServices] IMediator mediator)
        {
            
            var response = await mediator.Send(new GetAllCartResponse());
            
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Create([FromServices] IMediator mediator,[FromBody] CreateCartRequest command)
        {
            mediator.Send(command);
            return StatusCode(201);
        }

        [HttpPost("associate_product")]
        public IActionResult AssociateProduct([FromServices] IRequestCartHandler handler , AssociationProductCartDTO associationProductCart)
        {
            handler.AssociateProduct(associationProductCart.IdProduct, associationProductCart.IdCart);
            return StatusCode(200);
        }

        [HttpPut]
        public IActionResult UpDate([FromServices] IMediator mediator, [FromBody] UpdateCartRequest command)
        {
            mediator.Send(command);
            return StatusCode(200);
        }

        [HttpDelete]
        public IActionResult Delete([FromServices] IMediator mediator, [FromBody] DeleteCartRequest command)
        {
            mediator.Send(command);
            return StatusCode(200);

        }
    }
}
