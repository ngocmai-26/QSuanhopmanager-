using QShopManagement.MODEL.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QShopManagement.MODEL.DAO
{
    class ProductDao : BaseDao, IProductDao
    {
        public async Task<int> GetCountOfProduct()
        {
            return await DB_.tbl_HANGHOA.CountAsync();
        }

        public async Task<bool> Add(tbl_HANGHOA ef)
        {
            try
            {
                DB_.tbl_HANGHOA.Add(ef);
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
            return await DB_.tbl_HANGHOA.CountAsync();
        }
        public async Task<List<tbl_HANGHOA>> GetAll()
        {
            return await DB_.tbl_HANGHOA.ToListAsync();
        }

        public async Task<tbl_HANGHOA> GetSingleByID(string ID)
        {
            return await DB_.tbl_HANGHOA.FindAsync(ID);
        }

        public async Task<bool> Remove(string ID)
        {
            try
            {
                //xoa rang buoc
                var providerOfStaff = await DB_.tbl_NHACUNGCAP.Where(ct => ct.MaNCC.Equals(ID)).ToListAsync();
                var ctImportBillStaff = new List<tbl_CTPHIEUNHAP>();
                var ctBillStaff = new List<tbl_CTHOADON>();
                if (ctBillStaff.Count > 0)
                {
                    DB_.tbl_CTHOADON.RemoveRange(ctBillStaff);
                    await DB_.SaveChangesAsync();
                }
                if (ctImportBillStaff.Count > 0)
                {
                    DB_.tbl_CTPHIEUNHAP.RemoveRange(ctImportBillStaff);
                    await DB_.SaveChangesAsync();
                }
                DB_.tbl_NHACUNGCAP.RemoveRange(providerOfStaff);
                await DB_.SaveChangesAsync();
                var ef = await GetSingleByID(ID);
                if (ef != null)
                {
                    DB_.tbl_HANGHOA.Remove(ef);
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

        public async Task<bool> Update(tbl_HANGHOA ef)
        {
            var ef_ = await GetSingleByID(ef.MaHH);
            if (ef_ != null)
            {
                ef_.MaHH = ef.MaHH;
                ef_.TenHH = ef.TenHH;
                ef_.Gia = ef.Gia;
                ef_.Loaivai = ef.Loaivai;
                ef_.Size = ef.Size;
                ef_.MaNCC = ef.MaNCC;
                ef_.Soluong = ef.Soluong;
                ef_.SoluongTon = ef.SoluongTon;
                await DB_.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
