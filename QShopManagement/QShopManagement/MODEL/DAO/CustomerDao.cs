using QShopManagement.MODEL.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QShopManagement.MODEL.DAO
{
    class CustomerDao : BaseDao, ICustomersDao
    {
        public Task<bool> Add(tbl_KHACHHANG ef)
        {
            throw new NotImplementedException();
        }
        public async Task<int> GetCount()
        {
            return await DB_.tbl_KHACHHANG.CountAsync();
        }
        public Task<List<tbl_KHACHHANG>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<tbl_KHACHHANG> GetSingleByID(string ID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(string ID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(tbl_KHACHHANG ef)
        {
            throw new NotImplementedException();
        }
    }
}
