using QShopManagement.MODEL.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QShopManagement.MODEL.DAO
{
    class ProviderDao : BaseDao, IProviderDao
    {
        public Task<bool> Add(tbl_NHACUNGCAP ef)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetCount()
        {
            return await DB_.tbl_NHACUNGCAP.CountAsync();
        }
        public Task<List<tbl_NHACUNGCAP>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<tbl_NHACUNGCAP> GetSingleByID(string ID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(string ID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(tbl_NHACUNGCAP ef)
        {
            throw new NotImplementedException();
        }
    }
}
