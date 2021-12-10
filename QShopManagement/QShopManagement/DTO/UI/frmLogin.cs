using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using QShopManagement.MODEL.DAO;
using QShopManagement.MODEL.EF;
namespace QShopManagement.DTO.UI
{
    public partial class frmLogin : Form
    {
        frmControl control;
        bool isValid = false;
        public frmLogin()
        {
            InitializeComponent();
            control = new frmControl();
        }
        void ValidForm()
        {
            if(string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                isValid = false;
                if (string.IsNullOrEmpty(txtUserName.Text))
                {
                    txtUserName.Focus();
                }
                else
                {
                    txtPassword.Focus();
                }
            }else
            {
                isValid = true;
            }
        }
        async void Login()
        {
            Thread.Sleep(380);
            if (isValid)
            {
                UserDao us = new UserDao();
                bool check = await us.Login(txtUserName.Text, txtPassword.Text);
                if (check)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(Login));
                        return;
                    }
                    this.Hide();
                    control.ShowDialog();
                    control.Activate();
                }
                else
                {
                    MessageBox.Show("Tai Khoan Hoac Mat Khau Khong Chinh Xac");
                }
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ValidForm();
            Thread th = new Thread(Login);
            th.Start();
        }
    }
}
