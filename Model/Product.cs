using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
