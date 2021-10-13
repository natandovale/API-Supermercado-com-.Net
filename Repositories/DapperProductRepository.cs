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
            //string sql = "select * from products where id = @id";

            using (var connection = new SqlConnection("Server = (localdb)\\mssqllocaldb; Database = SampleDB; Trusted_Connection = True"))
            {
                //var product = connection.QueryFirst<Product>(sql, new { id });
                var product =connection.Get<Product>(id);
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
