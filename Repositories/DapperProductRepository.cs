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
    public class DapperProductRepository : IProductRepository   
    {

        public void Create(Product product)
        {
            using (var connection = new SqlConnection("Server = (localdb)\\mssqllocaldb; Database = SampleDB; Trusted_Connection = True"))
            {
                connection.Execute("insert into Products(title,price) values (@title,@price)",
                    new { price = product.Price, title = product.Title });
                //connection.Insert(product);
            }
        }

        public IEnumerable<Product> Get()
        {
            string sql = "select * from products";

            using (var connection = new SqlConnection("Server = (localdb)\\mssqllocaldb; Database = SampleDB; Trusted_Connection = True"))
            {
                var products = connection.Query<Product>(sql);
                //var products = connection.GetAll<Product>();
                return products;
            }
        }

        public Product Get(int id)
        {
            string sql = @"select p.id as Id , p.title as Title, p.price as Price, p.cart_id as CartId, c.id as Id, c.nome as Nome
                            from products p 
                            inner join cart c on c.id = p.cart_id where p.id = @id";
            Product product = null;
            using (var connection = new SqlConnection("Server = (localdb)\\mssqllocaldb; Database = SampleDB; Trusted_Connection = True"))
            {
                connection.Query<Product, Cart, Product>(sql, (p, c)=>
                {
                    product ??= p;
                    p.Cart = c;
                    return p;
                }, new { id });
                //var product = connection.Get<Product>(id);
                return product;
            }
        }

        public void Update(Product product)
        {
            using (var connection = new SqlConnection("Server = (localdb)\\mssqllocaldb; Database = SampleDB; Trusted_Connection = True"))
            {
                //connection.Execute("UPDTAE Product SET title=@title,description=@description,price=@price WHERE id = @id", 
                //    new { price = product.Price, title = product.Title, description = product.Description});
                connection.Update(product);
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection("Server = (localdb)\\mssqllocaldb; Database = SampleDB; Trusted_Connection = True"))
            {
                //connection.Execute(@"DELETE FROM Product WHERE id = @id", new { id });
                connection.Delete(new Product() { Id = id });
            }
        }

    }
}
