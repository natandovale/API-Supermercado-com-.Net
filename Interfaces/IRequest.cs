using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Interfaces
{
    public interface IRequest<T>
    {
        void HandlerCreate(T command);
        void HandlerDelete(int id);
        void HandlerUpdate(T command);
    }
}
