using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QShopManagement.MODEL.EF;

namespace QShopManagement.MODEL.DAO
{
    class ProviderManagerDao
    {
        public List<tbl_NHACUNGCAP> providers;
        ProviderDao providerDao;
        public ProviderManagerDao()
        {
            providerDao = new ProviderDao();
        }

        public async Task<bool> GetListProviders()
        {
            try
            {
                providers = await providerDao.GetAll();
                if (providers != null)
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
        public async Task<tbl_NHACUNGCAP> GetSingleByID(string ID)
        {
            return await providerDao.GetSingleByID(ID);
        }
        public async Task<bool> AddProvider(tbl_NHACUNGCAP ef)
        {
            try
            {
                if (ef != null)
                {
                    return await providerDao.Add(ef);
                }
                return false;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> UpdateProvider(tbl_NHACUNGCAP provider)
        {
            return await providerDao.Update(provider);
        }

        internal async Task<bool> RemovePovider(string ID)
        {
            return await providerDao.Remove(ID);
        }
    }
}
