using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Commands.Request
{
    public class CartRequest
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
