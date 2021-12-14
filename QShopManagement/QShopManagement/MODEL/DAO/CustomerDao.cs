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
        public async Task<bool> Add(tbl_KHACHHANG ef)
        {
            try
            {
                DB_.tbl_KHACHHANG.Add(ef);
                await DB_.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<int> GetCount()
        {
            return await DB_.tbl_KHACHHANG.CountAsync();
        }
        public async Task<List<tbl_KHACHHANG>> GetAll()
        {
            return await DB_.tbl_KHACHHANG.ToListAsync();
        }

        public async Task<tbl_KHACHHANG> GetSingleByID(string ID)
        {
            return await DB_.tbl_KHACHHANG.FindAsync(ID);
        }

        public async Task<bool> Remove(string ID)
        {
            try
            {
                //xoa rang buoc
                var billOfStaff = await DB_.tbl_HOADON.Where(ct => ct.MaKH.Equals(ID)).ToListAsync();
                DB_.tbl_HOADON.RemoveRange(billOfStaff);
                await DB_.SaveChangesAsync();
                var ef = await GetSingleByID(ID);
                if (ef != null)
                {
                    DB_.tbl_KHACHHANG.Remove(ef);
                    await DB_.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Update(tbl_KHACHHANG ef)
        {
            var ef_ = await GetSingleByID(ef.MaKH);
            if (ef_ != null)
            {
                ef_.MaKH = ef.MaKH;
                ef_.TenKH = ef.TenKH;
                ef_.DC = ef.DC;
                ef_.SDT = ef.SDT;
                await DB_.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
