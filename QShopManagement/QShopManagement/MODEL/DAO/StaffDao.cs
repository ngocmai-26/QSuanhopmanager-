using QShopManagement.MODEL.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QShopManagement.MODEL.DAO
{
    class StaffDao : BaseDao, IStaffDao
    {
        public Task<bool> Add(tbl_NHANVIEN ef)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetCount()
        {
            return await DB_.tbl_NHANVIEN.CountAsync();
        }
        public Task<List<tbl_NHANVIEN>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<tbl_NHANVIEN> GetSingleByID(string ID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(string ID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(tbl_NHANVIEN ef)
        {
            throw new NotImplementedException();
        }
    }
}
