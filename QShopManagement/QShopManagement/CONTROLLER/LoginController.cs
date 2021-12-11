using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using QShopManagement.DTO.UI;
using QShopManagement.MODEL.DAO;

namespace QShopManagement.CONTROLLER
{
    class LoginController
    {

        private AuthenticateDao model;
        frmControl control;
        bool isValid = false;
        string username_, password_;
        Thread LoginTh;
        public LoginController()
        {
            model = new AuthenticateDao();
            control = new frmControl();
            LoginTh = new Thread(Login);
        }

        public void getInfo(string username,string password)
        {
            username_ = username;
            password_ = password;
        }
        void ValidForm()
        {
            if (string.IsNullOrEmpty(username_) || string.IsNullOrEmpty(password_))
            {
                isValid = false;

                if (string.IsNullOrEmpty(username_))
                {
                    MessageBox.Show("Tai Khoan Khong Duoc De Trong");
                }
                else
                {

                    MessageBox.Show("Mat Khau Khong Duoc De Trong");

                }

            }
            else
            {
                isValid = true;
            }

        }
        public void ValidForLogin()
        {
            ValidForm();
            if (isValid)
            {
                LoginTh.Start();
            }
        }
        public async void Login()
        {
            if (isValid)
            {
                Thread.Sleep(380);
                bool isResult = await model.Login(username_,password_);

                if (isResult)
                {
                    control.ShowDialog();
                    control.Activate();
                }
                else
                {
                    MessageBox.Show("Tài Khoản Hoặc Mật Khẩu Không Chính Xác !");
                }

            }

        }


    }
}
