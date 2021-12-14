using QShopManagement.DTO.UC;
using QShopManagement.MODEL.DAO;
using QShopManagement.MODEL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QShopManagement.CONTROLLER
{
    class StaffManagerController
    {
        UCStaffManager manager;
        public StaffManagerDao model;

        public StaffManagerController(UCStaffManager manager_) {

            manager = manager_;
            model = new StaffManagerDao();
        }

        public async void GetListStaff()
        {
            bool check = await model.GetListStaffs();
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
        public async void AddStaff(tbl_NHANVIEN staff)
        {
            bool isHas = await CheckIfHas(staff.MSNV);
            if (isHas)
            {
                MessageBox.Show("Nhân Viên Đã Tồn Tại Không Thể Thêm (MSNV Trùng)");
            }else
            {
                bool checkIsAdded = await model.AddStaff(staff);
                if (checkIsAdded)
                {
                    manager.ReLoadSource();
                }
            }
        }

        internal async void RemoveStaff(string ID)
        {
            if (await model.RemoveStaff(ID)) {
                manager.ReLoadSource();
            } else
            {
                MessageBox.Show("Something err");
            }
        }

        internal async void UpdateStaff(tbl_NHANVIEN staff)
        {
            try
            {
                if (staff != null)
                {
                    bool check = await model.UpdateStaff(staff);
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
