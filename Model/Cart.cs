using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        [Computed]
        public List<Product> Products { get; set; } = new List<Product>();
        [Computed]
        public decimal SomaTotal { get 
            {
                return Products.Sum(x => x.Price);
            } 
        }

        public Cart(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Cart(string nome)
        {
            Nome = nome;
        }

        public Cart()
        {

        }
    }
}
