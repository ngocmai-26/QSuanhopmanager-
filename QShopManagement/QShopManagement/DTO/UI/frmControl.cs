using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using QShopManagement.DTO.UC;

namespace QShopManagement.DTO.UI
{
    public partial class frmControl : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
       (
             int nLeftRect,
             int nTopRect,
             int nRightRect,
             int nBottomRect,
             int nWidthEllipse,
             int nHeightEllipse

       );
        UCUserManager userM;
        UCProductManager productM;
        UCProviderManager providerM;
        UCStaffManager staffM;
        UCBill bill;
        UCImportBill importBill;
        bool isVoken = false;
        UCDashboard dash;
        UCBillManager billM;
        UCImportBillManager importBillM;
        UCCustomersManager customerM;
        string role_;
        public frmControl(string role)
        {

            InitializeComponent();
            role_ = role;
            dash = new UCDashboard();
            userM = new UCUserManager();
            staffM = new UCStaffManager();
            productM = new UCProductManager();
            providerM = new UCProviderManager();
            billM = new UCBillManager();
            importBillM = new UCImportBillManager();
            customerM = new UCCustomersManager();
            plnContent.Controls.Clear();
            plnContent.Controls.Add(dash);
            /*Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 16, 16));*/
        }

        private void frmControl_Load(object sender, EventArgs e)
        {
            pnlNavActive.Height = btnDashboard.Height + 10;
            pnlNavActive.Location = new Point(0,btnDashboard.Location.Y);
            dtpTime.Value = DateTime.Now;
            dtpTime.Value = DateTime.Now;

            btnAccountManager.Enabled = false;
            btnBills.Enabled = false;
            btnImportBills.Enabled = false;
            btnProductManager.Enabled = false;
            btnProviderManager.Enabled = false;
            btnStaffManager.Enabled = false;
            btnCustomerManager.Enabled = false;
            if (role_.Equals("Ketoan")) {
                btnBills.Enabled = true;
                MessageBox.Show("Bạn Đã Đăng Nhập Dưới Quyền Kế Toán!");

            }
            else if (role_.Equals("Quankho"))
            {
                btnProductManager.Enabled = true;
                MessageBox.Show("Bạn Đã Đăng Nhập Dưới Quản Kho !");


            }
            else if (role_.Equals("Quanly"))
            {
                btnProductManager.Enabled = true;
                btnProviderManager.Enabled = true;
                btnStaffManager.Enabled = true;
                btnCustomerManager.Enabled = true;
                MessageBox.Show("Bạn Đã Đăng Nhập Dưới Quyền Quản Lý !");


            }
            else if (role_.Equals("Admin"))
            {
                btnAccountManager.Enabled = true;
                MessageBox.Show("Bạn Đã Đăng Nhập Dưới Quyền Admin !");

            }
            else
            {
                // role nhanvien
                MessageBox.Show("Bạn Đã Đăng Nhập Dưới Quyền Nhân Viên !");
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(LoadDashboard);
            pnlNavActive.Height = btnDashboard.Height + 10;
            pnlNavActive.Top = btnDashboard.Top;
            pnlNavActive.Left = 0;
            MessageBox.Show(btnDashboard.Location.Y.ToString());

            AddLoadding();
            th.Start();
        }

        private void btnStaffManager_Click(object sender, EventArgs e)
        {
            Thread staffThread = new Thread(LoadStaffManagerControl);
            pnlNavActive.Height = btnStaffManager.Height + 10;
            pnlNavActive.Location = new Point(0, btnStaffManager.Location.Y);
            AddLoadding();
            staffThread.Start();

        }
       
        private void btnAccountManager_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(LoadUserManagerControl);
            th.IsBackground = true;
            pnlNavActive.Height = btnAccountManager.Height + 10;
            pnlNavActive.Location = new Point(0, btnAccountManager.Location.Y);
            AddLoadding();
            th.Start();

        }
        
        private void btnProviderManager_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(LoadProviderManagerControl);
            pnlNavActive.Height = btnProviderManager.Height + 10;
            pnlNavActive.Location = new Point(0, btnProviderManager.Location.Y);
            AddLoadding();
            th.Start();
        }

        private void btnProductManager_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(LoadProductManagerControl);
            pnlNavActive.Height = btnProductManager.Height + 10;
            pnlNavActive.Location = new Point(0, btnProductManager.Location.Y);
            AddLoadding();
            th.Start();
        }

        private void plnContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ctbClosed_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBills_Click(object sender, EventArgs e)
        {
            // tao  luong moi 
            // luong nay chay song song voi luong main
            pnlNavActive.Height = btnBills.Height + 10;
            pnlNavActive.Location = new Point(0, btnBills.Location.Y);
            Thread th = new Thread(LoadBillManageControl);
            th.IsBackground = true;
            AddLoadding();
            // add loading
            th.Start();
        }



        private void btnImportBills_Click(object sender, EventArgs e)
        {
            pnlNavActive.Height = btnImportBills.Height + 10;
            pnlNavActive.Location = new Point(0, btnImportBills.Location.Y);
            Thread th = new Thread(LoadIMportBillManagerControl);
            th.IsBackground = true;
            AddLoadding();
            th.Start();
        }


        private void CustomerManager_Click(object sender, EventArgs e)
        {
            pnlNavActive.Height = btnCustomerManager.Height + 10;
            pnlNavActive.Location = new Point(0, btnCustomerManager.Location.Y);
            Thread th = new Thread(LoadCustomerManagerControl);
            th.IsBackground = true;
            AddLoadding();
            th.Start();
        }
        void LoadIMportBillManagerControl() {
            //add control
            try
            {
                if (!isVoken)
                {
                    Thread.Sleep(3000);
                    // delay to loadding animate
                }
                if (plnContent.InvokeRequired)// check thread overload
                {
                    isVoken = true;
                    plnContent.Invoke(new Action(LoadIMportBillManagerControl));
                    return;
                }
                plnContent.Controls.Clear();
                plnContent.Controls.Add(importBillM);
            }
            catch
            {
                MessageBox.Show("Some err when loading");
            }

        }
        void LoadBillManageControl() {

            try
            {

                if (!isVoken)
                {
                    Thread.Sleep(3000);
                }
                if (plnContent.InvokeRequired)
                {
                    isVoken = true;
                    plnContent.Invoke(new Action(LoadBillManageControl));
                    return;
                }
                plnContent.Controls.Clear();
                plnContent.Controls.Add(billM);
            }
            catch
            {
                MessageBox.Show("Some err when loading");
            }

        }
        void LoadStaffManagerControl()
        {
            try
            {

                if (!isVoken)
                {
                    Thread.Sleep(3000);
                }
                if (plnContent.InvokeRequired)
                {
                    isVoken = true;
                    plnContent.Invoke(new Action(LoadStaffManagerControl));
                    return;
                }
                plnContent.Controls.Clear();
                plnContent.Controls.Add(staffM);
            }
            catch
            {
                MessageBox.Show("Some err when loading");
            }
        }
        void LoadUserManagerControl()
        {
            try
            {

                if (!isVoken)
                {
                    Thread.Sleep(3000);
                }

                if (plnContent.InvokeRequired)
                {
                    isVoken = true;
                    plnContent.Invoke(new Action(LoadUserManagerControl));
                    return;
                }
                plnContent.Controls.Clear();
                plnContent.Controls.Add(userM);
            }
            catch
            {
                MessageBox.Show("Some err when loading");
            }

        }
        void LoadProviderManagerControl()
        {
            try
            {

                if (!isVoken)
                {
                    Thread.Sleep(3000);
                }

                if (plnContent.InvokeRequired)
                {
                    isVoken = true;
                    plnContent.Invoke(new Action(LoadProviderManagerControl));
                    return;
                }
                plnContent.Controls.Clear();
                plnContent.Controls.Add(providerM);
            }
            catch
            {
                MessageBox.Show("Some err when loading");
            }
        }
        void LoadDashboard()
        {
            try
            {

                if (!isVoken)
                {
                    Thread.Sleep(3000);
                }

                if (plnContent.InvokeRequired)
                {
                    isVoken = true;
                    plnContent.Invoke(new Action(LoadDashboard));
                    return;
                }
                plnContent.Controls.Clear();
                plnContent.Controls.Add(dash);
            }
            catch
            {
                MessageBox.Show("Some err when loading");
            }
        }
        void LoadCustomerManagerControl()
        {
            try
            {

                if (!isVoken)
                {
                    Thread.Sleep(3000);
                }

                if (plnContent.InvokeRequired)
                {
                    isVoken = true;
                    plnContent.Invoke(new Action(LoadCustomerManagerControl));
                    return;
                }
                plnContent.Controls.Clear();
                plnContent.Controls.Add(customerM);
            }
            catch
            {
                MessageBox.Show("Some err when loading");
            }
        }
        void LoadProductManagerControl()
        {
            try
            {

                if (!isVoken)
                {
                    Thread.Sleep(3000);
                }

                if (plnContent.InvokeRequired)
                {
                    isVoken = true;
                    plnContent.Invoke(new Action(LoadProductManagerControl));
                    return;
                }
                plnContent.Controls.Clear();
                plnContent.Controls.Add(productM);
            }
            catch
            {
                MessageBox.Show("Some err when loading");
            }
        }
        void AddLoadding()
        {

            plnContent.Controls.Clear();
            loadding load = new loadding();
            load.BackColor = plnContent.BackColor;
            load.Location = new Point((plnContent.Width - load.Width) / 2, (plnContent.Height - load.Height) / 2);
            plnContent.Controls.Add(load);

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn Muốn Đăng Xuất ? ","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

    }
}
