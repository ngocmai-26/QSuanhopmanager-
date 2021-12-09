using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QShopManagement.MODEL.DAO
{
    public interface IBaseDao<T>
    {
        Task<T> GetSingleById(string id);
        List<Task<T>> GetAll();
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);

        Task<bool> Remove(string id);
        
    }
}
