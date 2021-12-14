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
    public partial class UCProductManager : UserControl
    {
        bool isValid = false;
        ProductManagerController ctrlProducts;
        public UCProductManager()
        {
            InitializeComponent();
            ctrlProducts = new ProductManagerController(this);
            ctrlProducts.GetListProduct();
        }
        internal void LoadDataToShow(ProductManagerDao model)
        {
            Helper.Helper.ClearDataSource(ref dgvProducts);
            dgvProducts.DataSource = model.products;
            dgvProducts.Columns["tbl_CTHOADON"].Visible = false;
            dgvProducts.Columns["tbl_CTPHIEUNHAP"].Visible = false;
            dgvProducts.Columns["tbl_NHACUNGCAP"].Visible = false;
        }
        internal void ReLoadSource()
        {
            ctrlProducts.GetListProduct();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ValidForm();
            if (isValid)
            {
                tbl_HANGHOA product = new tbl_HANGHOA()
                {
                    MaHH = txtMaHH.Text,
                    TenHH = txtProductName.Text,
                    Gia = Convert.ToInt32(txtGia.Text),
                    Loaivai = txtCl.Text,
                    Size = txtSize.Text,
                    MaNCC = txtMNCC.Text,
                    Soluong = Convert.ToInt32(txtSoLuong.Text),
                    SoluongTon = Convert.ToInt32(txtTonKho.Text),
                };
                ctrlProducts.AddProduct(product);
            }
        }
        void ValidForm()
        {
            if (string.IsNullOrEmpty(txtMaHH.Text) || string.IsNullOrEmpty(txtProductName.Text) || string.IsNullOrEmpty(txtCl.Text) ||
                string.IsNullOrEmpty(txtGia.Text) || string.IsNullOrEmpty(txtSize.Text) || string.IsNullOrEmpty(txtMNCC.Text) ||
                string.IsNullOrEmpty(txtSoLuong.Text) || string.IsNullOrEmpty(txtTonKho.Text))
            {
                isValid = false;
                if (string.IsNullOrEmpty(txtMaHH.Text))
                {
                    MessageBox.Show("Mã Hàng Hóa Không Được Để Trống!");
                    txtMaHH.Focus();
                }
                else if (string.IsNullOrEmpty(txtProductName.Text))
                {
                    MessageBox.Show("Tên Hàng Hóa Không Được Để Trống!");
                    txtProductName.Focus();

                }
                else if (string.IsNullOrEmpty(txtGia.Text))
                {
                    txtGia.Focus();
                    MessageBox.Show("Giá Hàng Hóa Không Được Để Trống!");

                }
                else if (string.IsNullOrEmpty(txtCl.Text))
                {
                    txtCl.Focus();
                    MessageBox.Show("Loại Vải Hàng Hóa Không Được Để Trống!");

                }
                else if (string.IsNullOrEmpty(txtSize.Text))
                {
                    txtSize.Focus();
                    MessageBox.Show("Size Hàng Hóa Không Được Để Trống!");

                }
                else if (string.IsNullOrEmpty(txtMNCC.Text))
                {
                    txtMNCC.Focus();
                    MessageBox.Show("Mã Nhà Cung Cấp Không Được Để Trống!");

                }
                else if (string.IsNullOrEmpty(txtSoLuong.Text))
                {
                    txtSoLuong.Focus();
                    MessageBox.Show("Số Lượng Hàng Hóa Không Được Để Trống!");

                }
                else
                {
                    txtTonKho.Focus();
                    MessageBox.Show("Số Lượng Tồn Kho Không Được Để Trống!");

                }
            }
            else
            {
                isValid = true;
            }
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvProducts.SelectedRows.Count > 0)
                {

                    var row = dgvProducts.CurrentRow;
                    txtMaHH.Text = row.Cells["MaHH"].Value.ToString();
                    txtProductName.Text = row.Cells["TenHH"].Value.ToString();
                    txtMNCC.Text = row.Cells["MaNCC"].Value.ToString();
                    txtGia.Text = row.Cells["Gia"].Value.ToString();
                    txtCl.Text = row.Cells["Loaivai"].Value.ToString();
                    txtSize.Text = row.Cells["Size"].Value.ToString();
                    txtSoLuong.Text = row.Cells["Soluong"].Value.ToString();
                    txtTonKho.Text = row.Cells["SoluongTon"].Value.ToString();
                    txtMaHH.Enabled = false;
                }

            }
            catch
            {

            } 
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProducts.SelectedRows.Count < 0)
                {
                    MessageBox.Show("Không có hàng hóa nào được chọn!");
                }
                else
                {
                    if (MessageBox.Show("Bạn Thật Sự Muốn Xóa " + dgvProducts.CurrentRow.Cells["TenHH"].Value.ToString() + "?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        string ID = dgvProducts.SelectedRows[0].Cells["MaHH"].Value.ToString();
                        ctrlProducts.RemoveStaff(ID);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Có Một Số Lỗi Xảy Ra");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ValidForm();
            if (isValid)
            {
                if (dgvProducts.SelectedRows.Count > 0 || isValid)
                {
                    tbl_HANGHOA product = new tbl_HANGHOA()
                    {
                        MaHH = txtMaHH.Text,
                        TenHH = txtProductName.Text,
                        Gia = Convert.ToInt32(txtGia.Text),
                        Loaivai = txtCl.Text,
                        Size = txtSize.Text,
                        MaNCC = txtMNCC.Text,
                        Soluong = Convert.ToInt32(txtSoLuong.Text),
                        SoluongTon = Convert.ToInt32(txtTonKho.Text),
                    };
                    ctrlProducts.UpdateProduct(product);
                }
                else
                {
                    MessageBox.Show("Thiếu Dữ Liệu!");
                }
            }
        }
    }
}
