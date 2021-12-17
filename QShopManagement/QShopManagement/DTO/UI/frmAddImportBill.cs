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
    public partial class frmAddImportBill : Form
    {
        int quantity_;
        int current_quantity;
        public frmAddImportBill(int quantity)
        {
            InitializeComponent();

            quantity_ = quantity;
            current_quantity = 1;
            MessageBox.Show(quantity.ToString());
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
