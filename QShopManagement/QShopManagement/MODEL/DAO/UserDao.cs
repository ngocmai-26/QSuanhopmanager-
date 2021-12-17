using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QShopManagement.MODEL.EF;
namespace QShopManagement.MODEL.DAO
{
    class UserDao : BaseDao, IUserDao
    {
        public async Task<string> GetUserRole(string userName)
        {
            var ef = await DB_.tbl_TAIKHOAN.Where(tk => tk.UserNam.Equals(userName)).FirstOrDefaultAsync();
            if (ef != null)
            {
                return ef.role;
            }
            return null;
        }
        public async Task<int> GetCount()
        {
            return await DB_.tbl_TAIKHOAN.CountAsync();
        }
        public async Task<bool> Add(tbl_TAIKHOAN ef)
        {
            try
            {
                DB_.tbl_TAIKHOAN.Add(ef);
                await DB_.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<List<tbl_TAIKHOAN>> GetAll()
        {
            return await DB_.tbl_TAIKHOAN.ToListAsync();
        }

        public async Task<tbl_TAIKHOAN> GetSingleByID(string ID)
        {
            return await DB_.tbl_TAIKHOAN.FindAsync(ID);
        }

        public async Task<tbl_TAIKHOAN> GetSingleByUserNameAndPassword(string username, string password)
        {
            return await DB_.tbl_TAIKHOAN.Where(tk => tk.UserNam.Equals(username) && tk.Password.Equals(password)).FirstOrDefaultAsync();
        }

        public async Task<bool> Remove(string ID)
        {
            try
            {
                //xoa rang buoc
                var staffOfAccount = await DB_.tbl_NHANVIEN.Where(ct => ct.MSNV.Equals(ID)).ToListAsync();

                if (staffOfAccount.Count > 0)
                {
                    DB_.tbl_NHANVIEN.RemoveRange(staffOfAccount);
                    await DB_.SaveChangesAsync();
                }
                var ef = await GetSingleByID(ID);
                if (ef != null)
                {
                    DB_.tbl_TAIKHOAN.Remove(ef);
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

        public async Task<bool> Update(tbl_TAIKHOAN ef)
        {
            var ef_ = await GetSingleByID(ef.MSNV);
            if (ef_ != null)
            {
                ef_.MSNV = ef.MSNV;
                ef_.UserNam = ef.UserNam;
                ef_.Password = ef.Password;
                ef_.HieuLuc = ef.HieuLuc;
                ef_.role = ef.role;
                await DB_.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}