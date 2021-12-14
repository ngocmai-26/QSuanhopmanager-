using QShopManagement.MODEL.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QShopManagement.MODEL.DAO
{
    class CTImportBillDao : BaseDao, ICTIMPORTBILLDAO
    {
        public Task<bool> Add(tbl_CTPHIEUNHAP ef)
        {
            throw new NotImplementedException();
        }
        public async Task<long> GetCapital()
        {
            
            var ef =  await DB_.tbl_CTPHIEUNHAP.SumAsync(ct => ct.DonGiaNhap * ct.SLNhap);
            return ef;
        }
        public async Task<int> GetCount()
        {
            return await DB_.tbl_CTPHIEUNHAP.CountAsync();
        }
        public Task<List<tbl_CTPHIEUNHAP>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<tbl_CTPHIEUNHAP> GetSingleByID(string ID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(string ID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(tbl_CTPHIEUNHAP ef)
        {
            throw new NotImplementedException();
        }
    }
}
