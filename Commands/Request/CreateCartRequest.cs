using Dapper.Contrib.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Commands.Response;

namespace WebApplication2.Commands.Request
{
    public class CreateCartRequest : IRequest<CartResponse>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
