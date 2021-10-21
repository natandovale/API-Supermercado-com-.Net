using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Interfaces
{
    public interface IResponse<T>
    {
        T HandlerGetById(int id);
        IEnumerable<T> HandlerGetAll();
    }
}
