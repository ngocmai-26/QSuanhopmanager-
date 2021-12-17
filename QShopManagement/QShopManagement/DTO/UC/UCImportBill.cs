using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QShopManagement.DTO.UI;

namespace QShopManagement.DTO.UC
{
    public partial class UCImportBill : UserControl
    {
        public int TotalAdd = 0;
        public UCImportBill()
        {
            InitializeComponent();
        }
        public void GetData(int total)
        {
            this.TotalAdd = total;
        }


        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmGetQuantily2 frmGetQuantily2 = new frmGetQuantily2(this);
            frmGetQuantily2.StartPosition = FormStartPosition.CenterParent;
            frmGetQuantily2.FormClosed += new FormClosedEventHandler(f_closed);
            frmGetQuantily2.ShowDialog();

        }
        private void f_closed(object sender, FormClosedEventArgs e)
        {
            if (TotalAdd > 0)
            {
                frmAddImportBill frmAddImportBill = new frmAddImportBill(TotalAdd);
                frmAddImportBill.StartPosition = FormStartPosition.CenterParent;
                frmAddImportBill.FormClosed += new FormClosedEventHandler(fa_closed);
                frmAddImportBill.ShowDialog();
            }
        }
        private void fa_closed(object sender, FormClosedEventArgs e)
        {
            // day la su kien dong form cua addbill
            // sau khi dong form thi refresh source
            Helper.Helper.ClearDataSource(ref dgvImportBill);
            dgvImportBill.Refresh();
            // neu data ko thay doi thi co the dung doan code sau
            // dgvBill = null;
            // dgvBill.Refresh();
            // dgvBill.DataSource = data;
        }
    }
}
