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
    class ProductManagerController
    {
        UCProductManager manager;
        public ProductManagerDao model;
        public ProductManagerController(UCProductManager manager_)
        {

            manager = manager_;
            model = new ProductManagerDao();
        }

        public async void GetListProduct()
        {
            bool check = await model.GetListProducts();
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
        public async void AddProduct(tbl_HANGHOA staff)
        {
            bool isHas = await CheckIfHas(staff.MaHH);
            if (isHas)
            {
                MessageBox.Show("Hàng Hóa Đã Tồn Tại Không Thể Thêm (MSNV Trùng)");
            }
            else
            {
                bool checkIsAdded = await model.AddProduct(staff);
                if (checkIsAdded)
                {
                    manager.ReLoadSource();
                }
            }
        }

        internal async void RemoveStaff(string ID)
        {
            if (await model.RemoveStaff(ID))
            {
                manager.ReLoadSource();
            }
            else
            {
                MessageBox.Show("Something err");
            }
        }

        internal async void UpdateProduct(tbl_HANGHOA product)
        {
            try
            {
                if (product != null)
                {
                    bool check = await model.UpdateProduct(product);
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