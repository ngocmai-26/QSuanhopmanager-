using QShopManagement.MODEL.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QShopManagement.MODEL.DAO
{
    class ProductDao : BaseDao, IProductDao
    {
        public async Task<int> GetCountOfProduct()
        {
            return await DB_.tbl_HANGHOA.CountAsync();
        }

        public Task<bool> Add(tbl_HANGHOA ef)
        {
            throw new NotImplementedException();
        }
        public async Task<int> GetCount()
        {
            return await DB_.tbl_HANGHOA.CountAsync();
        }
        public Task<List<tbl_HANGHOA>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<tbl_HANGHOA> GetSingleByID(string ID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(string ID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(tbl_HANGHOA ef)
        {
            throw new NotImplementedException();
        }
    }
}
