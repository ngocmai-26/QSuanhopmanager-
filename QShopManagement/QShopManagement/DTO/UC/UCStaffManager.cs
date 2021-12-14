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
    public partial class UCStaffManager : UserControl
    {
        bool isValid = false;
        StaffManagerController ctrlStaffs;
        public UCStaffManager()
        {
            InitializeComponent();
            ctrlStaffs = new StaffManagerController(this);
            ctrlStaffs.GetListStaff();
        }
       
        private void guna2CustomRadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        
        internal void LoadDataToShow(StaffManagerDao model)
        {
            rbtnNam.Checked = true;
            Helper.Helper.ClearDataSource(ref dgvStaffs);
            dgvStaffs.DataSource =  model.staffs;
            dgvStaffs.Columns["tbl_HOADON"].Visible = false;
            dgvStaffs.Columns["tbl_TAIKHOAN"].Visible = false;
        }

        private void UCStaffManager_Load(object sender, EventArgs e)
        {

        }

        private void dgvStaffs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvStaffs.SelectedRows.Count > 0)
                {

                    var row = dgvStaffs.CurrentRow;
                    txtMaNV.Text = row.Cells["MSNV"].Value.ToString();
                    txtAddress.Text = row.Cells["DiaChi"].Value.ToString();
                    txtNumberPhone.Text = row.Cells["SDT"].Value.ToString();
                    txtStaffName.Text = row.Cells["TenNV"].Value.ToString();
                    txtBirthday.Text = row.Cells["NamSinh"].Value.ToString();
                    txtDepartment.Text = row.Cells["ChucVu"].Value.ToString();
                    string gender = row.Cells["GTNV"].Value.ToString();
                    txtMaNV.Enabled = false;
                    if (gender.Equals("Nam"))
                    {
                        rbtnNam.Checked = true;
                    }
                    else
                    {
                        rbtnNu.Checked = true;
                    }
                }

            }
            catch
            {

            }
        }

        internal void ReLoadSource()
        {
            ctrlStaffs.GetListStaff();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ValidForm();
            if (isValid)
            {
                tbl_NHANVIEN staff = new tbl_NHANVIEN()
                {
                    MSNV = txtMaNV.Text,
                    TenNV = txtStaffName.Text,
                    SDT = txtNumberPhone.Text,
                    DiaChi = txtAddress.Text,
                    QueQuan = dgvStaffs.CurrentRow.Cells["QueQuan"].Value.ToString(),
                    ChucVu = txtDepartment.Text,
                    NamSinh = Convert.ToDateTime(txtBirthday.Text),
                    GTNV = rbtnNam.Checked ? "Nam" : "Nữ"
                };
                ctrlStaffs.AddStaff(staff);
            }
            
        }
        void ValidForm()
        {
            DateTime test = new DateTime();
            if(string.IsNullOrEmpty(txtMaNV.Text)|| string.IsNullOrEmpty(txtAddress.Text) || string.IsNullOrEmpty(txtDepartment.Text) ||
                string.IsNullOrEmpty(txtNumberPhone.Text) || string.IsNullOrEmpty(txtStaffName.Text)) { 
                isValid = false;
                if (string.IsNullOrEmpty(txtMaNV.Text))
                {
                    MessageBox.Show("Mã Nhân Viên Không Được Để Trống!");
                    txtMaNV.Focus();
                }
                else if (string.IsNullOrEmpty(txtAddress.Text))
                {
                    MessageBox.Show("Địa Chỉ Nhân Viên Không Được Để Trống!");
                    txtAddress.Focus();

                }
                else if (string.IsNullOrEmpty(txtDepartment.Text))
                {
                    txtDepartment.Focus();
                    MessageBox.Show("Chức Vụ Nhân Viên Không Được Để Trống!");

                }
                else if (string.IsNullOrEmpty(txtNumberPhone.Text))
                {
                    txtNumberPhone.Focus();
                    MessageBox.Show("SDT Nhân Viên Không Được Để Trống!");

                }else if(string.IsNullOrEmpty(txtBirthday.Text))
                {
                    if(!DateTime.TryParse(txtBirthday.Text, out test))
                    {
                        MessageBox.Show("Định Dạng Ngày Sinh Của Nhân Viên Bị Sai!");
                        txtBirthday.Clear();
                    }
                    MessageBox.Show("Ngày Sinh Của Nhân Viên Không Được Để Trống!");

                    txtBirthday.Focus();
                }
                else
                {
                    txtStaffName.Focus();
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
                if (dgvStaffs.SelectedRows.Count > 0 || isValid)
                {
                    tbl_NHANVIEN staff = new tbl_NHANVIEN()
                    {
                        MSNV = txtMaNV.Text,
                        TenNV = txtStaffName.Text,
                        SDT = txtNumberPhone.Text,
                        DiaChi = txtAddress.Text,
                        QueQuan = dgvStaffs.CurrentRow.Cells["QueQuan"].Value.ToString(),
                        ChucVu = txtDepartment.Text,
                        NamSinh = Convert.ToDateTime(txtBirthday.Text),
                        GTNV = rbtnNam.Checked ? "Nam" : "Nữ"
                    };
                    ctrlStaffs.UpdateStaff(staff);
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
                if (dgvStaffs.SelectedRows.Count < 0)
                {
                    MessageBox.Show("Không có nhân viên nào được chọn!");
                }
                else
                {
                    if(MessageBox.Show("Bạn Thật Sự Muốn Xóa "+ dgvStaffs.CurrentRow.Cells["TenNV"].Value.ToString()+ "?","Alert", MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        string ID = dgvStaffs.SelectedRows[0].Cells["MSNV"].Value.ToString();
                        ctrlStaffs.RemoveStaff(ID);
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
            txtMaNV.Enabled = true;
            txtMaNV.Clear();
            txtAddress.Clear();
            txtNumberPhone.Clear();
            txtDepartment.Clear();
            txtStaffName.Clear();
            txtBirthday.Clear();
        }

        private void dgvStaffs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
