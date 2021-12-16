using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QShopManagement.DTO.UI
{
    public partial class frmAddBill : Form
    {
        int quantity_;
        int current_quantity;
        public frmAddBill(int quantity)
        {
            InitializeComponent();
            quantity_ = quantity;
            current_quantity = 1;
            MessageBox.Show(quantity.ToString());
        }

        private void tbMaHD_TextChanged(object sender, EventArgs e)
        {

        }
        void clearInput() {
        ///clear input code gose here
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // them hoa don o day 
            // doan logic
            if (current_quantity != quantity_)
            {
                //neu chua bang thi add
                // viet ham add ow ben controller
                // add xong goi ham clear
                clearInput();
                // sau khi add thi cai current_quantity cong them 1
                current_quantity++;
            }
            else
            {
                // neu bang thi dong form
                this.Close();
                // sau khi dong form se refresh lai cai datagird view
                // su kien dong form o ben ucbill
            }
        }
    }
}
