using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Model;

namespace WebApplication2.Interfaces
{
    public interface IProductRepository
    {
        public void Create(Product product);

        IEnumerable<Product> Get();
        //IEnumerable<Product> Get(int id);
        Product Get(int id);
        public void Update(Product product);
        public void Delete(int id);
    }
}
