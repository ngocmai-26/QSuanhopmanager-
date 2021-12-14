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

namespace QShopManagement.DTO.UC
{
    public partial class UCProviderManager : UserControl
    {
        bool isValid = false;
        ProviderManagerController ctrlProviders;
        public UCProviderManager()
        {
            InitializeComponent();
            ctrlProviders = new ProviderManagerController(this);
            ctrlProviders.GetListProviders();
        }
        internal void LoadDataToShow(ProviderManagerDao model)
        {
            Helper.Helper.ClearDataSource(ref dgvProviders);
            dgvProviders.DataSource = model.providers;
            dgvProviders.Columns["tbl_HANGHOA"].Visible = false;
        }
        internal void ReLoadSource()
        {
            ctrlProviders.GetListProviders();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ValidForm();
            if (isValid)
            {
                tbl_NHACUNGCAP provider = new tbl_NHACUNGCAP()
                {
                    MaNCC = txtMaCC.Text,
                    TenNCC = txtCCName.Text,
                    SDT = txtNumberPhone.Text,
                    DiaChi = txtDiaChi.Text,
                    LoaiHang = txtLoaiHang.Text,
                };
                ctrlProviders.AddProvider(provider);
            }
        }
        void ValidForm()
        {
            if (string.IsNullOrEmpty(txtMaCC.Text) || string.IsNullOrEmpty(txtDiaChi.Text) || string.IsNullOrEmpty(txtLoaiHang.Text) ||
                string.IsNullOrEmpty(txtNumberPhone.Text) || string.IsNullOrEmpty(txtCCName.Text))
            {
                isValid = false;
                if (string.IsNullOrEmpty(txtMaCC.Text))
                {
                    MessageBox.Show("Mã Nhà Cung Cấp Không Được Để Trống!");
                    txtMaCC.Focus();
                }
                else if (string.IsNullOrEmpty(txtDiaChi.Text))
                {
                    MessageBox.Show("Địa Chỉ Nhà Cung Cấp Không Được Để Trống!");
                    txtDiaChi.Focus();

                }
                else if (string.IsNullOrEmpty(txtLoaiHang.Text))
                {
                    txtLoaiHang.Focus();
                    MessageBox.Show("Loại Hàng Không Được Để Trống!");

                }
                else if (string.IsNullOrEmpty(txtNumberPhone.Text))
                {
                    txtNumberPhone.Focus();
                    MessageBox.Show("SDT Nhà Cung Cấp Không Được Để Trống!");

                }
                else
                {
                    txtCCName.Focus();
                    MessageBox.Show("Tên Nhà Cung Cấp Không Được Để Trống!");

                }
            }
            else
            {
                isValid = true;
            }
        }

        private void dgvProviders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvProviders.SelectedRows.Count > 0)
                {

                    var row = dgvProviders.CurrentRow;
                    txtMaCC.Text = row.Cells["MaNCC"].Value.ToString();
                    txtCCName.Text = row.Cells["TenNCC"].Value.ToString();
                    txtNumberPhone.Text = row.Cells["SDT"].Value.ToString();
                    txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                    txtLoaiHang.Text = row.Cells["LoaiHang"].Value.ToString();
                    txtMaCC.Enabled = false;
                }

            }
            catch
            {

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ValidForm();
            if (isValid)
            {
                if (dgvProviders.SelectedRows.Count > 0 || isValid)
                {
                    tbl_NHACUNGCAP staff = new tbl_NHACUNGCAP()
                    {
                        MaNCC = txtMaCC.Text,
                        TenNCC = txtCCName.Text,
                        SDT = txtNumberPhone.Text,
                        DiaChi = txtDiaChi.Text,
                        LoaiHang = txtLoaiHang.Text,
                    };
                    ctrlProviders.UpdateProvider(staff);
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
                if (dgvProviders.SelectedRows.Count < 0)
                {
                    MessageBox.Show("Không có nhà cung cấp nào được chọn!");
                }
                else
                {
                    if (MessageBox.Show("Bạn Thật Sự Muốn Xóa " + dgvProviders.CurrentRow.Cells["TenNCC"].Value.ToString() + "?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        string ID = dgvProviders.SelectedRows[0].Cells["MaNCC"].Value.ToString();
                        ctrlProviders.RemovePovider(ID);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Có Một Số Lỗi Xảy Ra");
            }
        }

        private void btnClearInput_Click(object sender, EventArgs e)
        {
            txtMaCC.Enabled = true;
            txtMaCC.Clear();
            txtCCName.Clear();
            txtNumberPhone.Clear();
            txtDiaChi.Clear();
            txtLoaiHang.Clear();
        }
    }
}
