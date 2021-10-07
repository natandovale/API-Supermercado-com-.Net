using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Model;

namespace WebApplication2.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> Get();
        Product Get(int id);
        void Create(Product product);
        public void Update(Product product);
        public void Delete(int id);
    }
}
