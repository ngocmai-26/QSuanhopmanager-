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
        public async Task<bool> Add(tbl_NHANVIEN ef)
        {
            try
            {
                DB_.tbl_NHANVIEN.Add(ef);
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
            return await DB_.tbl_NHANVIEN.CountAsync();
        }
        public async Task<List<tbl_NHANVIEN>> GetAll()
        {
            return await DB_.tbl_NHANVIEN.ToListAsync();
        }

        public async Task<tbl_NHANVIEN> GetSingleByID(string ID)
        {
            return await DB_.tbl_NHANVIEN.FindAsync(ID);
        }

        public async Task<bool> Remove(string ID)
        {
            try
            {
                //xoa rang buoc
                var billOfStaff = await DB_.tbl_HOADON.Where(ct => ct.MSNV.Equals(ID)).ToListAsync();
                var accountOfStaff = await DB_.tbl_TAIKHOAN.Where(ac => ac.MSNV.Equals(ID)).ToListAsync();
                var ctBillStaff = new List<tbl_CTHOADON>();
                foreach(var item in billOfStaff)
                {
                    var ef_ = await DB_.tbl_CTHOADON.Where(ct => ct.MaHD.Equals(item.MaHD)).FirstOrDefaultAsync();
                    if (ef_ != null)
                    {
                        ctBillStaff.Add(ef_);
                    }
                }
                if (ctBillStaff.Count > 0) {
                    DB_.tbl_CTHOADON.RemoveRange(ctBillStaff);
                    await DB_.SaveChangesAsync();
                }
                DB_.tbl_TAIKHOAN.RemoveRange(accountOfStaff);
                DB_.tbl_HOADON.RemoveRange(billOfStaff);
                await DB_.SaveChangesAsync();
                var ef = await GetSingleByID(ID);
                if (ef != null)
                {
                    DB_.tbl_NHANVIEN.Remove(ef);
                    await DB_.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
           
        }

        public async Task<bool> Update(tbl_NHANVIEN ef)
        {
            var ef_ = await GetSingleByID(ef.MSNV);
            if (ef_ != null)
            {
                ef_.MSNV = ef.MSNV;
                ef_.TenNV = ef.TenNV;
                ef_.DiaChi = ef.DiaChi;
                ef_.QueQuan = ef.QueQuan;
                ef_.NamSinh = ef.NamSinh;
                ef_.SDT = ef.SDT;
                ef_.GTNV = ef.GTNV;
                ef_.ChucVu = ef.ChucVu;
                await DB_.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
