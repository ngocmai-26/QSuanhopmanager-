using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QShopManagement.MODEL.EF;

namespace QShopManagement.MODEL.DAO
{
    class ProductManagerDao
    {
        public List<tbl_HANGHOA> products;

        ProductDao productDao;
        public ProductManagerDao()
        {
            productDao = new ProductDao();
        }

        public async Task<bool> GetListProducts()
        {
            try
            {
                products = await productDao.GetAll();
                if (products != null)
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
        public async Task<tbl_HANGHOA> GetSingleByID(string ID)
        {
            return await productDao.GetSingleByID(ID);
        }
        public async Task<bool> AddProduct(tbl_HANGHOA ef)
        {
            try
            {
                if (ef != null)
                {
                    return await productDao.Add(ef);
                }
                return false;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> UpdateProduct(tbl_HANGHOA product)
        {
            return await productDao.Update(product);
        }

        internal async Task<bool> RemoveStaff(string ID)
        {
            return await productDao.Remove(ID);
        }
    }
}
