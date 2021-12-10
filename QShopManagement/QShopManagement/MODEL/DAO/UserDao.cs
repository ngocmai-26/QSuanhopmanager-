using QShopManagement.MODEL.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QShopManagement.MODEL.DAO
{
    class UserDao : BaseDao , IUserDao
    {
        public async Task<bool> Login(string UserName,string Password)
        {
            var ef = await DB_.tbl_TAIKHOAN.Where(tk => tk.UserNam.Equals(UserName) && tk.Password.Equals(Password)).FirstOrDefaultAsync();
            if (ef != null)
            {
                return true;
            }
            return false;
        }
        public Task<bool> Add(tbl_TAIKHOAN entity)
        {
            throw new NotImplementedException();
        }

        public List<Task<tbl_TAIKHOAN>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<tbl_TAIKHOAN> GetSingleById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(tbl_TAIKHOAN entity)
        {
            throw new NotImplementedException();
        }
    }
}
