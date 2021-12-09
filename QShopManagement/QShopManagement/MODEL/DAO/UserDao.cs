using QShopManagement.MODEL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QShopManagement.MODEL.DAO
{
    class UserDao : BaseDao , IUserDao
    {
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
