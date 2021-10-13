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

        public Cart GetCartProduct(int id)
        {
            Cart cart = null;

            using (var connection = new SqlConnection("Server = (localdb)\\mssqllocaldb; Database = SampleDB; Trusted_Connection = True"))
            {
                connection.Query<Cart, Product, Cart>("select c.nome as Nome, c.id as Id, p.id as Id , p.title as Title, p.price as Price, p.cart_id as CartId from cart c inner join products p on p.cart_id = c.id where c.id = @id", (c, p) =>
                {
                    cart ??= c;
                    p.Cart = c.Nome;
                    p.CartId = c.Id;
                    cart.Products.Add(p);

                    return c;

                }, new { id }
                    , splitOn: "Id");
                return cart;
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

        public Cart GetPriceTotalProduct(int id)
        {
            Cart cart = null;
            
            using (var connection = new SqlConnection("Server = (localdb)\\mssqllocaldb; Database = SampleDB; Trusted_Connection = True"))
            {
                connection.Query<Cart, Product, Cart>("select c.nome as Nome, c.id as Id, p.id as Id , p.title as Title, p.price as Price, p.cart_id as CartId from cart c inner join product p on p.cart_id = c.id where c.id = @id", (c, p) =>
                {
                    if(cart == null)
                    {
                        cart = c;
                    }
                    p.Cart = c.Nome;
                    p.CartId = c.Id;
                    cart.Products.Add(p);
                    
                    return c;

                }, new { id }
                    , splitOn: "Id");
                return cart;
            }
        }
    }
}
