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
        public async Task<bool> Add(tbl_NHACUNGCAP ef)
        {
            try
            {
                DB_.tbl_NHACUNGCAP.Add(ef);
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
            return await DB_.tbl_NHACUNGCAP.CountAsync();
        }
        public async Task<List<tbl_NHACUNGCAP>> GetAll()
        {
            return await DB_.tbl_NHACUNGCAP.ToListAsync();
        }

        public async Task<tbl_NHACUNGCAP> GetSingleByID(string ID)
        {
            return await DB_.tbl_NHACUNGCAP.FindAsync(ID);
        }

        public async Task<bool> Remove(string ID)
        {
            try
            {
                //xoa rang buoc
                var productOfStaff = await DB_.tbl_HANGHOA.Where(ct => ct.MaNCC.Equals(ID)).ToListAsync();
                DB_.tbl_HANGHOA.RemoveRange(productOfStaff);
                await DB_.SaveChangesAsync();
                var ef = await GetSingleByID(ID);
                if (ef != null)
                {
                    DB_.tbl_NHACUNGCAP.Remove(ef);
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

        public async Task<bool> Update(tbl_NHACUNGCAP ef)
        {
            var ef_ = await GetSingleByID(ef.MaNCC);
            if (ef_ != null)
            {
                ef_.MaNCC = ef.MaNCC;
                ef_.TenNCC = ef.TenNCC;
                ef_.DiaChi = ef.DiaChi;
                ef_.LoaiHang = ef.LoaiHang;
                ef_.SDT = ef.SDT;
                await DB_.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}