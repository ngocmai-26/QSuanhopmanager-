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
        bool isValid = false;
        string username_, password_;
        Thread LoginTh;
        frmLogin login_;
        public LoginController(frmLogin login)
        {
            login_ = login;
            model = new AuthenticateDao();
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
                    MessageBox.Show("Tài Khoản Không Được Để Trống!");
                }
                else
                {

                    MessageBox.Show("Mật Khẩu Không Được Để Trống!");

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
                var ef = await model.GetRoleByUserName(username_);
                if (isResult)
                {
                    frmControl control = new frmControl(ef);
                    if (control.InvokeRequired)
                    {
                        control.Invoke(new Action(Login));
                    }
                    control.FormClosed += new FormClosedEventHandler(control_closed);
                    control.ShowDialog();
                    control.Activate();
                }
                else
                {
                    MessageBox.Show("Tài Khoản Hoặc Mật Khẩu Không Chính Xác !");
                }

            }

        }

        private void control_closed(object sender, FormClosedEventArgs e)
        {
            login_.Show_();
        }
    }
}
