using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Commands.Response
{
    public class ProductResponse
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}
