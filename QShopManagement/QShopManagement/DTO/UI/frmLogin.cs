using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QShopManagement.MODEL.DAO;
using QShopManagement.MODEL.EF;
using QShopManagement.DTO.UI;
using System.Threading;
using QShopManagement.CONTROLLER;
namespace QShopManagement.DTO.UI
{
    public partial class frmLogin : Form    
    {
       
        LoginController loginCtrl;
        public frmLogin()
        {
            InitializeComponent();
            loginCtrl = new LoginController(this);
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            loginCtrl.getInfo(txtUserName.Text, txtPassword.Text);
            loginCtrl.ValidForLogin();
        }

        internal void Show_()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(Show_));
                    return;
                }
                txtPassword.Clear();
                txtUserName.Clear();
                this.Show();
                this.Activate();
            }
            catch
            {
                
            }
           
        }
    }
}
