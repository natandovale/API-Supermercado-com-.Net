using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Commands.Response;

namespace WebApplication2.Commands.Request
{
    public class DeleteProductRequest : IRequest<ProductResponse>
    {
        public int Id { get; set; }
    }
}
