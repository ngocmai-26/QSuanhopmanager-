using QShopManagement.DTO.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QShopManagement.DTO.UC
{
    public partial class UCBill : UserControl
    {
        public int TotalAdd = 0;
        public UCBill()
        {
            InitializeComponent();
        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {

        }
        public void GetData(int total)
        {
            this.TotalAdd = total;
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmGetQuantity frmGetQuantity = new frmGetQuantity(this);
            frmGetQuantity.StartPosition = FormStartPosition.CenterParent;
            frmGetQuantity.FormClosed += new FormClosedEventHandler(f_closed);
            frmGetQuantity.ShowDialog();
        }

        private void f_closed(object sender, FormClosedEventArgs e)
        {
            if (TotalAdd > 0)
            {
                frmAddBill frmAdd = new frmAddBill(TotalAdd);
                frmAdd.StartPosition = FormStartPosition.CenterParent;
                frmAdd.FormClosed += new FormClosedEventHandler(fa_closed);
                frmAdd.ShowDialog();
            }
        }

        private void fa_closed(object sender, FormClosedEventArgs e)
        {
            // day la su kien dong form cua addbill
            // sau khi dong form thi refresh source
            Helper.Helper.ClearDataSource(ref dgvBill);
            dgvBill.Refresh();
            // neu data ko thay doi thi co the dung doan code sau
            // dgvBill = null;
            // dgvBill.Refresh();
            // dgvBill.DataSource = data;
        }
        
        private void UCBill_Load(object sender, EventArgs e)
        {

        }

        private void dgvBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnClearInput_Click(object sender, EventArgs e)
        {

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

        }
    }
}
