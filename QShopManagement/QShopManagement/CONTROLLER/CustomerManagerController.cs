using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QShopManagement.DTO.UC;
using QShopManagement.MODEL.DAO;
using QShopManagement.MODEL.EF;
using System.Windows.Forms;

namespace QShopManagement.CONTROLLER
{
    class CustomerManagerController
    {
        UCCustomersManager manager;
        public CustomerManagerDao model;
        public CustomerManagerController(UCCustomersManager manager_)
        {

            manager = manager_;
            model = new CustomerManagerDao();
        }
        public async void GetListCustomer()
        {
            bool check = await model.GetListCustomers();
            if (check)
            {
                manager.LoadDataToShow(model);
            }
        }
        public async Task<bool> CheckIfHas(string ID)
        {
            try
            {
                var ef = await model.GetSingleByID(ID);
                if (ef != null)
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
        public async void AddCustomer(tbl_KHACHHANG customer)
        {
            bool isHas = await CheckIfHas(customer.MaKH);
            if (isHas)
            {
                MessageBox.Show("Nhân Viên Đã Tồn Tại Không Thể Thêm (MSNV Trùng)");
            }
            else
            {
                bool checkIsAdded = await model.AddCustomer(customer);
                if (checkIsAdded)
                {
                    manager.ReLoadSource();
                }
            }
        }
        internal async void RemoveCustomer(string ID)
        {
            if (await model.RemoveCustomer(ID))
            {
                manager.ReLoadSource();
            }
            else
            {
                MessageBox.Show("Something err");
            }
        }
        internal async void UpdateCustomer(tbl_KHACHHANG customer)
        {
            try
            {
                if (customer != null)
                {
                    bool check = await model.UpdateCustomer(customer);
                    if (check)
                    {
                        manager.ReLoadSource();
                    }
                    else
                    {
                        MessageBox.Show("Có 1 số lỗi xảy ra khi sửa dữ liệu");
                    }
                }
            }
            catch
            {

            }
        }
    }

}
