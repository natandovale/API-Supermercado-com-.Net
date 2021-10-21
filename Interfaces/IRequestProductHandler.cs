using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Commands.Request;
using WebApplication2.Commands.Response;
using WebApplication2.Handlers;

namespace WebApplication2.Interfaces
{
    public interface IRequestProductHandler
    {
        ProductResponse HandlerCreate(ProductRequest command);
        void HandlerDelete(int id);
        void HandlerUpdate(ProductRequest command);
    }
}
