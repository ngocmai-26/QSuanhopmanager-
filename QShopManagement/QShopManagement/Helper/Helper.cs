using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QShopManagement.Helper
{
    public static class Helper
    {
        public static void ClearDataSource(ref Guna.UI2.WinForms.Guna2DataGridView dgv)
        {
            dgv.DataSource = null;
            dgv.Refresh();
        }
    }
}
