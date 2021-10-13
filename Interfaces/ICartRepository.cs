using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Model;

namespace WebApplication2.Interfaces
{
    public interface ICartRepository 
    {
        IEnumerable<Cart> Get();
        void AddProductToCart(int idProduto, int idCart);
        Cart Get(int id);
        //IEnumerable<ListProduct> GetProducts();
        public Cart GetCartProduct(int id);
        void Create(Cart cart);
        public void Update(Cart cart);
        public void Delete(int id);
        public Cart GetPriceTotalProduct (int id );
    }
}
