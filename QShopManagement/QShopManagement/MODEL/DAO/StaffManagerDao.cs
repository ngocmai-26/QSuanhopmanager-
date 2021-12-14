using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QShopManagement.MODEL.EF;
namespace QShopManagement.MODEL.DAO
{
    class StaffManagerDao
    {
        public List<tbl_NHANVIEN> staffs;

        StaffDao staffDao;
        public StaffManagerDao()
        {
            staffDao = new StaffDao();
        }

        public async Task<bool> GetListStaffs()
        {
            try
            {
                staffs = await staffDao.GetAll();
                if (staffs != null)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public async Task<tbl_NHANVIEN> GetSingleByID(string ID)
        {
            return await staffDao.GetSingleByID(ID);
        }
        public async Task<bool> AddStaff(tbl_NHANVIEN ef)
        {
            try
            {
                if (ef != null)
                {
                    return await staffDao.Add(ef);
                }
                return false;
            }
            catch
            {
                return false;
            }
          
        }

        public async Task<bool> UpdateStaff(tbl_NHANVIEN staff)
        {
            return await staffDao.Update(staff);
        }

        internal async Task<bool> RemoveStaff(string ID)
        {
            return await staffDao.Remove(ID);
        }
    }
}
