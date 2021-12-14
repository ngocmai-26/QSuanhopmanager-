using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QShopManagement.MODEL.EF;
namespace QShopManagement.MODEL.DAO
{
    class AuthenticateDao
    {

        protected UserDao userDao;
        public AuthenticateDao()
        {
            userDao = new UserDao();
        }
        public async Task<string> GetRoleByUserName(string userName)
        {
            return await userDao.GetUserRole(userName);
        }
        public async Task<bool> Login(string UserName,string Password)
        {

            try
            {
                var ef = await userDao.GetSingleByUserNameAndPassword(UserName, Password);
                if(ef != null)
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

    }
}
