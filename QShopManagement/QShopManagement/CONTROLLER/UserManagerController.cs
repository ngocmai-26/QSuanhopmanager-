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
    class UserManagerController
    {
        UCUserManager manager;
        public UserManagerDao model;

        public UserManagerController(UCUserManager manager_)
        {

            manager = manager_;
            model = new UserManagerDao();
        }
        public async void GetListUser()
        {
            bool check = await model.GetListUsers();
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
        public async void AddUser(tbl_TAIKHOAN user)
        {
            bool isHas = await CheckIfHas(user.MSNV);
            if (isHas)
            {
                MessageBox.Show("Nhân Viên Đã Tồn Tại Không Thể Thêm (MSNV Trùng)");
            }
            else
            {
                bool checkIsAdded = await model.AddUser(user);
                if (checkIsAdded)
                {
                    manager.ReLoadSource();
                }
            }
        }
        internal async void UpdateUser(tbl_TAIKHOAN user)
        {
            try
            {
                if (user != null)
                {
                    bool check = await model.UpdateUser(user);
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
        internal async void RemoveUser(string msnv)
        {
            if (await model.RemoveUser(msnv))
            {
                manager.ReLoadSource();
            }
            else
            {
                MessageBox.Show("Something err");
            }
        }
    }
}
