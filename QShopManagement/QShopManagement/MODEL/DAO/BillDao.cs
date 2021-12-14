using QShopManagement.MODEL.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QShopManagement.MODEL.DAO
{
    class BillDao : BaseDao, IBillDao
    {
        public async Task<float> GetTotalSold() {

            var ef =  await DB_.tbl_CTHOADON.SumAsync(hd => hd.Soluong * hd.tbl_HANGHOA.Gia);
            return ef;

        }
        public Task<bool> Add(tbl_HOADON ef)
        {
            throw new NotImplementedException();
        }
        public async Task<int> GetCount()
        {
            return await DB_.tbl_CTHOADON.CountAsync();
        }
        public Task<List<tbl_HOADON>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<tbl_HOADON> GetSingleByID(string ID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(string ID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(tbl_HOADON ef)
        {
            throw new NotImplementedException();
        }
    }
}
