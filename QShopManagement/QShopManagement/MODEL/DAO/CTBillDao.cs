using QShopManagement.MODEL.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QShopManagement.MODEL.DAO
{
    class CTBillDao : BaseDao, ICTBILLDAO
    {
        public Task<bool> Add(tbl_CTHOADON ef)
        {
            throw new NotImplementedException();
        }
        public async Task<int> GetCount()
        {
            return await DB_.tbl_CTHOADON.CountAsync();
        }
        public Task<List<tbl_CTHOADON>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<tbl_CTHOADON> GetSingleByID(string ID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(string ID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(tbl_CTHOADON ef)
        {
            throw new NotImplementedException();
        }
    }
}
