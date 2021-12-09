using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QShopManagement.MODEL.EF;
namespace QShopManagement.MODEL.DAO
{
    class BaseDao
    {
        protected QLCHEntities DB_;
        public BaseDao()
        {
            DB_ = new QLCHEntities();
        }
    }
}
