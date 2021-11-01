using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Model;

namespace WebApplication2.Commands.Response
{
    public class GetAllCartResponse : IRequest<IEnumerable<CartResponse>>
    {
    }
}
