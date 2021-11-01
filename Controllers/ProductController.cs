using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Commands.Request;
using WebApplication2.Commands.Response;
using WebApplication2.Interfaces;
using WebApplication2.Model;
using WebApplication2.Repositories;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] IMediator mediator)
        {
            var response = await mediator.Send(new GetAllProductsResponse());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromServices] IMediator mediator, [FromBody] GetProductByIdResponse command)    
        {
            var response = mediator.Send(command);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Create([FromServices] IMediator mediator, [FromBody] CreateProductResponse command)
        {
            mediator.Send(command);
            return StatusCode(200);
        }

        [HttpPut]
        public IActionResult UpDate([FromServices] IMediator mediator, [FromBody] UpdateProductRequest command)
        {
            mediator.Send(command);
            return StatusCode(200);
        }

        [HttpDelete]
        public IActionResult Delete([FromServices] IMediator mediator, [FromBody] DeleteProductRequest command)
        {
            mediator.Send(command);
            return StatusCode(200);
        }
    }
}

