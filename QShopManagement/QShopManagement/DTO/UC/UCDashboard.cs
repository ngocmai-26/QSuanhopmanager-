using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QShopManagement.CONTROLLER;
using QShopManagement.MODEL.DAO;
using System.Globalization;
namespace QShopManagement.DTO.UC
{
    public partial class UCDashboard : UserControl
    {

        DashboardController crtlDashBoard;
        
        public UCDashboard()
        {
            InitializeComponent();
            lblTime1.Text = lblTime2.Text = lblTime3.Text = DateTime.Now.ToShortDateString();
            crtlDashBoard = new DashboardController(this);
        }

       
        private void UCDashboard_Load(object sender, EventArgs e)
        {
            crtlDashBoard.LoadData();
        }
        public string FormatMoney(float money)
        {
            CultureInfo culture = new CultureInfo("en-US");
            decimal value = decimal.Parse(money.ToString(), NumberStyles.AllowThousands);
            string result = String.Format(culture, "{0:N0}", value);
            return result;

        }
        public string FormatMoney(long money)
        {
            CultureInfo culture = new CultureInfo("en-US");
            decimal value = decimal.Parse(money.ToString(), NumberStyles.AllowThousands);
            string result = String.Format(culture, "{0:N0}", value);
            return result;
        }
        public void LoadDataToControl(DashDao model)
        {
            lblImport.Text = model.totalImport.ToString();
            lblexport.Text = model.totalexport.ToString();
            lblIncome.Text = FormatMoney(model.totalIncome);
            lblCapital.Text = FormatMoney(model.totalCapital);
            lbltotalUser.Text = model.totalUser.ToString();
            lbltotalProvider.Text = model.totalProvider.ToString();
            lblTotalStaff.Text =model.totalStaff.ToString();
            lblTotalCustomer.Text = model.totalCustomer.ToString();
            lblLoss.Text = FormatMoney(model.totalLoss);
            
        }
        private void guna2Panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
