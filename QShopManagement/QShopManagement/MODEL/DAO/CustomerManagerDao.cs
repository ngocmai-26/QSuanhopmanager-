using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QShopManagement.MODEL.EF;

namespace QShopManagement.MODEL.DAO
{
    class CustomerManagerDao
    {
        public List<tbl_KHACHHANG> customers;

        CustomerDao customerDao;
        public CustomerManagerDao()
        {
            customerDao = new CustomerDao();
        }
        public async Task<bool> GetListCustomers()
        {
            try
            {
                customers = await customerDao.GetAll();
                if (customers != null)
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
        public async Task<tbl_KHACHHANG> GetSingleByID(string ID)
        {
            return await customerDao.GetSingleByID(ID);
        }
        public async Task<bool> AddCustomer(tbl_KHACHHANG ef)
        {
            try
            {
                if (ef != null)
                {
                    return await customerDao.Add(ef);
                }
                return false;
            }
            catch
            {
                return false;
            }

        }
        public async Task<bool> UpdateCustomer(tbl_KHACHHANG customer)
        {
            return await customerDao.Update(customer);
        }
        internal async Task<bool> RemoveCustomer(string ID)
        {
            return await customerDao.Remove(ID);
        }
    }
}
