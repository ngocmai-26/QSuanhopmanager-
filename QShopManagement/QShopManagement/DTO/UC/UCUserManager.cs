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
    public partial class UCUserManager : UserControl
    {
        bool isValid = false;
        UserManagerController ctrlUsers;
        public UCUserManager()
        {
            InitializeComponent();
            ctrlUsers = new UserManagerController(this);
            ctrlUsers.GetListUser();
        }

        private void UCUserManager_Load(object sender, EventArgs e)
        {

        }
        internal void LoadDataToShow(UserManagerDao model)
        {
            Helper.Helper.ClearDataSource(ref dgvAccount);
            dgvAccount.DataSource = model.users;
            dgvAccount.Columns["tbl_NHANVIEN"].Visible = false;
        }

        private void dgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvAccount.SelectedRows.Count > 0)
                {

                    var row = dgvAccount.CurrentRow;
                    txtMaNV.Text = row.Cells["MSNV"].Value.ToString();
                    txtUserName.Text = row.Cells["UserNam"].Value.ToString();
                    txtPassword.Text = row.Cells["Password"].Value.ToString();
                    txtHieuluc.Text = row.Cells["|HieuLuc"].Value.ToString();
                    txtrole.Text = row.Cells["role"].Value.ToString();
                    txtMaNV.Enabled = false;
                }

            }
            catch
            {

            }

        }
        internal void ReLoadSource()
        {
            ctrlUsers.GetListUser();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ValidForm();
            if (isValid)
            {
                tbl_TAIKHOAN user = new tbl_TAIKHOAN()
                {
                    MSNV = txtMaNV.Text,
                    UserNam = txtUserName.Text,
                    Password = txtPassword.Text,
                    HieuLuc = txtHieuluc.Text,
                    role = txtrole.Text,
                };
                ctrlUsers.AddUser(user);
            }

        }
        void ValidForm()
        {
            if (string.IsNullOrEmpty(txtMaNV.Text) || string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text) ||
                string.IsNullOrEmpty(txtrole.Text) || string.IsNullOrEmpty(txtHieuluc.Text))
            {
                isValid = false;
                if (string.IsNullOrEmpty(txtMaNV.Text))
                {
                    MessageBox.Show("Mã Nhân Viên Không Được Để Trống!");
                    txtMaNV.Focus();
                }
                else if (string.IsNullOrEmpty(txtUserName.Text))
                {
                    MessageBox.Show("Địa Chỉ Nhân Viên Không Được Để Trống!");
                    txtUserName.Focus();

                }
                else if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    txtPassword.Focus();
                    MessageBox.Show("Chức Vụ Nhân Viên Không Được Để Trống!");

                }
                else if (string.IsNullOrEmpty(txtrole.Text))
                {
                    txtrole.Focus();
                    MessageBox.Show("SDT Nhân Viên Không Được Để Trống!");

                }
                else
                {
                    txtHieuluc.Focus();
                    MessageBox.Show("Tên Nhân Viên Không Được Để Trống!");

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
                if (dgvAccount.SelectedRows.Count > 0 || isValid)
                {
                    tbl_TAIKHOAN user = new tbl_TAIKHOAN()
                    {
                        MSNV = txtMaNV.Text,
                        UserNam = txtUserName.Text,
                        Password = txtPassword.Text,
                        HieuLuc = txtHieuluc.Text,
                        role = txtrole.Text,
                    };
                    ctrlUsers.UpdateUser(user);
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
                if (dgvAccount.SelectedRows.Count < 0)
                {
                    MessageBox.Show("Không có nhân viên nào được chọn!");
                }
                else
                {
                    if (MessageBox.Show("Bạn Thật Sự Muốn Xóa " + dgvAccount.CurrentRow.Cells["UserNam"].Value.ToString() + "?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        string msnv = dgvAccount.CurrentRow.Cells["MSNV"].Value.ToString();
                        ctrlUsers.RemoveUser(msnv);
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
