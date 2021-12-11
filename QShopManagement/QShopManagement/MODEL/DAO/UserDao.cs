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
        public async Task<tbl_TAIKHOAN> GetSingleByUserNameAndPassword(string username,string password)
        {
            return await DB_.tbl_TAIKHOAN.Where(tk => tk.UserNam.Equals(username) && tk.Password.Equals(password)).FirstOrDefaultAsync();
        }
        public Task<bool> Add(tbl_TAIKHOAN ef)
        {
            throw new NotImplementedException();
        }

        public Task<List<tbl_TAIKHOAN>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<tbl_TAIKHOAN> GetSingleByID(string ID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(string ID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(tbl_TAIKHOAN ef)
        {
            throw new NotImplementedException();
        }
    }
}
