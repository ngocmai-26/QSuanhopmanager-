using QShopManagement.MODEL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QShopManagement.MODEL.DAO
{
    class ImportCouponDao : BaseDao, IIMPORTCOUPONDAO
    {
        public Task<bool> Add(tbl_PHIEUNHAPKHO ef)
        {
            throw new NotImplementedException();
        }

        public Task<List<tbl_PHIEUNHAPKHO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<tbl_PHIEUNHAPKHO> GetSingleByID(string ID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(string ID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(tbl_PHIEUNHAPKHO ef)
        {
            throw new NotImplementedException();
        }
    }
}
