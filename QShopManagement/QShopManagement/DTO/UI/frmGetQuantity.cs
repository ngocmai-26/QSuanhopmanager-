using QShopManagement.DTO.UC;
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
    public partial class frmGetQuantity : Form
    {
        UCBill bill_;
        public frmGetQuantity(UCBill bill)
        {
            InitializeComponent();
            bill_ = bill;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                txtQuantity.Focus();
            }
            else
            {
                int quantity;
                if (int.TryParse(txtQuantity.Text, out quantity))
                {
                    bill_.GetData(int.Parse(txtQuantity.Text));
                    this.Close();
                }
            }
          
        }
        
    }
}
