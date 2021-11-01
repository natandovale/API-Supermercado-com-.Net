using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Model;

namespace WebApplication2.Commands.Response
{
    public class GetCartByIdResponse : IRequest<CartResponse>
    {
        public int Id { get; set; }
       
    }
}
