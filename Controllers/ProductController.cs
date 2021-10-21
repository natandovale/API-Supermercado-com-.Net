﻿using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public IActionResult GetAll([FromServices] IResponseProductHandler handler)
        {
            var response = handler.HandlerGetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromServices] IResponseProductHandler handler, int id)    
        {
            var response = handler.HandlerGetById(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Create([FromServices] IRequestProductHandler handler,[FromBody] ProductRequest command)
        {
            handler.HandlerCreate(command);
            return StatusCode(200);
        }

        [HttpPut]
        public IActionResult UpDate([FromServices] IRequestProductHandler handler, [FromBody] ProductRequest command)
        {
            handler.HandlerUpdate(command);
            return StatusCode(200);
        }

        [HttpDelete]
        public IActionResult Delete([FromServices] IRequestProductHandler handler, int id)
        {
            handler.HandlerDelete(id);
            return StatusCode(200);
        }
    }
}

