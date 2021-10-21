﻿using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Model;

namespace WebApplication2.Commands.Response
{
    public class ProductResponse
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}
