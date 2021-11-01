using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Commands.Response
{
    public class GetProductByIdResponse : IRequest<ProductResponse>
    {
        public int Id { get; set; }
    }
}
