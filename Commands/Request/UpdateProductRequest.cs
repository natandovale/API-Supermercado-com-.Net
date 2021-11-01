using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Commands.Response;

namespace WebApplication2.Commands.Request
{
    public class UpdateProductRequest : IRequest<ProductResponse>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}
