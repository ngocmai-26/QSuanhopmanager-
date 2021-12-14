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
using QShopManagement.MODEL.EF;

using QShopManagement.Helper;
namespace QShopManagement.DTO.UC
{
    public partial class UCCustomersManager : UserControl
    {
        bool isValid = false;
        CustomerManagerController ctrlCustomers;
        public UCCustomersManager()
        {
            InitializeComponent();
            ctrlCustomers = new CustomerManagerController(this);
            ctrlCustomers.GetListCustomer();
        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {

        }
        internal void LoadDataToShow(CustomerManagerDao model)
        {
            Helper.Helper.ClearDataSource(ref dgvCustomer);
            dgvCustomer.DataSource = model.customers;
            dgvCustomer.Columns["tbl_HOADON"].Visible = false;
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvCustomer.SelectedRows.Count > 0)
                {

                    var row = dgvCustomer.CurrentRow;
                    txtMaKH.Text = row.Cells["MaKH"].Value.ToString();
                    txtDiaChi.Text = row.Cells["DC"].Value.ToString();
                    txtSDT.Text = row.Cells["SDT"].Value.ToString();
                    txtTenKH.Text = row.Cells["TenKH"].Value.ToString();
                    txtMaKH.Enabled = false;
                }

            }
            catch
            {

            }
        }
        internal void ReLoadSource()
        {
            ctrlCustomers.GetListCustomer();
        }

        void ValidForm()
        {
            if (string.IsNullOrEmpty(txtMaKH.Text) || string.IsNullOrEmpty(txtDiaChi.Text) || string.IsNullOrEmpty(txtSDT.Text) ||
                string.IsNullOrEmpty(txtTenKH.Text))
            {
                isValid = false;
                if (string.IsNullOrEmpty(txtMaKH.Text))
                {
                    MessageBox.Show("Mã Khách Hàng Không Được Để Trống!");
                    txtMaKH.Focus();
                }
                else if (string.IsNullOrEmpty(txtDiaChi.Text))
                {
                    MessageBox.Show("Địa Chỉ Khách Hàng Không Được Để Trống!");
                    txtDiaChi.Focus();

                }
                else if (string.IsNullOrEmpty(txtSDT.Text))
                {
                    txtSDT.Focus();
                    MessageBox.Show("SDT Khách Hàng Không Được Để Trống!");

                }
                else
                {
                    txtTenKH.Focus();
                    MessageBox.Show("Tên Khách Hàng Không Được Để Trống!");

                }
            }
            else
            {
                isValid = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ValidForm();
            if (isValid)
            {
                if (dgvCustomer.SelectedRows.Count > 0 || isValid)
                {
                    tbl_KHACHHANG staff = new tbl_KHACHHANG()
                    {
                        MaKH = txtMaKH.Text,
                        TenKH = txtTenKH.Text,
                        SDT = txtSDT.Text,
                        DC = txtDiaChi.Text,
                    };
                    ctrlCustomers.UpdateCustomer(staff);
                }
                else
                {
                    MessageBox.Show("Thiếu Dữ Liệu!");
                }

            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCustomer.SelectedRows.Count < 0)
                {
                    MessageBox.Show("Không có Khách Hàng nào được chọn!");
                }
                else
                {
                    if (MessageBox.Show("Bạn Thật Sự Muốn Xóa " + dgvCustomer.CurrentRow.Cells["TenKH"].Value.ToString() + "?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        string ID = dgvCustomer.SelectedRows[0].Cells["MaKH"].Value.ToString();
                        ctrlCustomers.RemoveCustomer(ID);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Có Một Số Lỗi Xảy Ra");
            }
        }
    }
}
