using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QShopManagement.MODEL.DAO
{
    public interface IBaseDao<T>
    {
        Task<T> GetSingleByID(string ID);
        Task<List<T>> GetAll();
        Task<bool> Add(T ef);
        Task<bool> Update(T ef);
        Task<bool> Remove(string ID);

    }
}
