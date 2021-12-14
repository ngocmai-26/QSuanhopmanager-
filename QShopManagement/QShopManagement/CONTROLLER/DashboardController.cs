using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QShopManagement.DTO.UC;
using QShopManagement.DTO.UI;
using QShopManagement.MODEL.DAO;
namespace QShopManagement.CONTROLLER
{
    class DashboardController
    {
        UCDashboard ucDash;
        DashDao model;
        public DashboardController(UCDashboard dash)
        {
            ucDash = dash;
            model = new DashDao();
        }

        public async void LoadData()
        {

            bool check = await model.GetData();
            if (check)
            {
                ucDash.LoadDataToControl(model);
            }else
            {
                MessageBox.Show("Có Một Số Lỗi Xảy Ra Khi Khởi Tạo Dữ Liệu!");
            }
        }

    }
}
