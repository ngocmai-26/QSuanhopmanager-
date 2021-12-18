using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QShopManagement.MODEL.EF;

namespace QShopManagement.MODEL.DAO
{
    class UserManagerDao
    {
        public List<tbl_TAIKHOAN> users;

        UserDao userDao;
        public UserManagerDao()
        {
            userDao = new UserDao();
        }
        public async Task<bool> GetListUsers()
        {
            try
            {
                users = await userDao.GetAll();
                if (users != null)
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
        public async Task<tbl_TAIKHOAN> GetSingleByID(string ID)
        {
            return await userDao.GetSingleByID(ID);
        }
        public async Task<bool> AddUser(tbl_TAIKHOAN ef)
        {
            try
            {
                if (ef != null)
                {
                    return await userDao.Add(ef);
                }
                return false;
            }
            catch
            {
                return false;
            }

        }
        public async Task<bool> UpdateUser(tbl_TAIKHOAN user)
        {
            return await userDao.Update(user);
        }
        internal async Task<bool> RemoveUser(string msnv)
        {
            return await userDao.Remove(msnv);
        }

    }
}
