using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QShopManagement.MODEL.DAO
{
    public class DashDao
    {
        UserDao users;
        ProductDao products;
        CustomerDao customers;
        StaffDao staffs;
        BillDao bills;
        ProviderDao providers;
        CTImportBillDao ctImport;
        CTBillDao ctBill;

        public int totalProducts;
        public int totalImport;
        public int totalexport;
        public int totalStaff;
        public int totalBill;
        public int totalProvider;
        public int totalUser;
        public int totalCustomer;
        public float totalIncome;
        public long totalCapital;//von;
        public float totalLoss;
        public int totalCtBill;

        
        public DashDao()
        {
            users = new UserDao();
            products = new ProductDao();
            customers = new CustomerDao();
            staffs = new StaffDao();
            bills = new BillDao();
            providers = new ProviderDao();
            ctImport = new CTImportBillDao();
            ctBill = new CTBillDao();
        }

        public async Task<bool> GetData()
        {
            try
            {
                totalUser = await users.GetCount();
                totalBill = await bills.GetCount();
                totalCustomer = await customers.GetCount();
                totalImport = await ctImport.GetCount();
                totalexport = await bills.GetCount();
                totalStaff = await staffs.GetCount();
                totalProvider = await providers.GetCount();
                totalProducts = await products.GetCount();
                totalCapital = await ctImport.GetCapital();
                float totalSold = await bills.GetTotalSold();
                totalIncome = totalSold;
                totalLoss = totalSold < 0 ? -totalSold : 0;
                totalCtBill = await ctBill.GetCount();
                return true;
            }
            catch
            {
                return false;
            }
           
        }

    }
}
