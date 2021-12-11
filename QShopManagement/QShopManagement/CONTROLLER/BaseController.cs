using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QShopManagement.CONTROLLER
{
    interface BaseController<T>
    {

        Task<bool> Add(T ef);
        Task<bool> Update(T ef);
        Task<bool> Remove(string ID);

    }
}
