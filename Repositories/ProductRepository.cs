﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Model;

namespace WebApplication2.Repositories
{
    public class ProductRepository
    {
        private readonly StoreDataContext _context; 
        public ProductRepository(StoreDataContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> Get()
        {
            return _context.Products;
        }

        public void Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges(); 
        }
    }
}
