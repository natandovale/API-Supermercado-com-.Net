using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Model;

namespace WebApplication2.Commands.Response
{
    public class CartResponse
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Product> Products { get; set; }
        public decimal SomaTotal { get; set; }
    }
}
