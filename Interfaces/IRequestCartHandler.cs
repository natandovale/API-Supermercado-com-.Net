using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Commands.Request;
using WebApplication2.DTOs;

namespace WebApplication2.Interfaces
{
    public interface IRequestCartHandler : IRequest<CartRequest>
    {
        void AssociateProduct(int a , int b);

    }
}
