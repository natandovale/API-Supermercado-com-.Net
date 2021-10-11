using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Interfaces;
using WebApplication2.Model;

namespace WebApplication2.Repositories
{
    public class DapperCartRepository : ICartRepository
    {
        public void AddProductToCart(int idProduto, int idCart)
        {
            using (var connection = new SqlConnection("Server = (localdb)\\mssqllocaldb; Database = SampleDB; Trusted_Connection = True"))
            {
                connection.Execute("update products set cart_id=@idCart where id=@product_id", new { idCart = idCart, product_id = idProduto });
            }
        }

        public void Create(Cart cart)
        {
            using (var connection = new SqlConnection("Server = (localdb)\\mssqllocaldb; Database = SampleDB; Trusted_Connection = True"))
            {
                //connection.Execute("insert into Product(title,price) values (@title,@price)",
                //    new { price = product.Price, title = product.Title });
                connection.Insert(cart);
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection("Server = (localdb)\\mssqllocaldb; Database = SampleDB; Trusted_Connection = True"))
            {
                //connection.Execute(@"DELETE FROM Product WHERE id = @id", new { id });
                connection.Delete(new Cart() { Id = id });
            }
        }

        public IEnumerable<Cart> Get()
        {
            using (var connection = new SqlConnection("Server = (localdb)\\mssqllocaldb; Database = SampleDB; Trusted_Connection = True"))
            {
                //var carts = connection.Query<Cart>(sql);
                var carts = connection.GetAll<Cart>();
                return carts;
            }
        }

        public Cart Get(int id)
        {
            using (var connection = new SqlConnection("Server = (localdb)\\mssqllocaldb; Database = SampleDB; Trusted_Connection = True"))
            {
                //var product = connection.QueryFirst<Product>(sql, new { id });
                var cart = connection.Get<Cart>(id);
                return cart;
            }
        }

        public void Update(Cart cart)
        {
            using (var connection = new SqlConnection("Server = (localdb)\\mssqllocaldb; Database = SampleDB; Trusted_Connection = True"))
            {
                //connection.Execute("UPDTAE Product SET title=@title,description=@description,price=@price WHERE id = @id", 
                //    new { price = product.Price, title = product.Title, description = product.Description});
                connection.Update(cart);
            }
        }
    }
}
