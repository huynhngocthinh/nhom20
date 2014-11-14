using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormApp.ServiceReferenceNhanVien;
using WinFormApp.ServiceReferencePhanQuyen;

namespace WinFormApp
{
    public partial class FormNhanVien : Form
    {
        ServiceNhanVienClient obj = new ServiceNhanVienClient();
        ServicePhanQuyenClient qnv = new ServicePhanQuyenClient();
        public FormNhanVien()
        {
            InitializeComponent();
            load();
        }
        public void load()
        {
            dataGridView1.DataSource = obj.SelectNhanVien();
            dataGridView1.Columns["QuyenNV"].Visible = false;
            dataGridView1.Columns["PhanQuyen"].Visible = false;

            cbxQuyen.DataSource = qnv.SelectPhanQuyen();
            cbxQuyen.ValueMember = "MaPQ";
            cbxQuyen.DisplayMember = "TenPQ";
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            FormQuanLy form = new FormQuanLy();
            this.Visible = false;
            form.Visible = true;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ServiceReferenceNhanVien.NhanVien objnv = (ServiceReferenceNhanVien.NhanVien)dataGridView1.SelectedRows[0].DataBoundItem;
            txtmanv.Text = objnv.MaNV.ToString();
            txttennv.Text = objnv.TenNV.ToString();
            txtusername.Text = objnv.Username.ToString();
            txtpass.Text = objnv.Password.ToString();
            txtemail.Text = objnv.Email.ToString();
            cbxQuyen.SelectedValue = objnv.QuyenNV;           
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtmanv.Text = "";
            txttennv.Text = "";
            txtusername.Text = "";
            txtpass.Text = "";
            txtemail.Text = "";
            txttennv.Focus();

            cbxQuyen.SelectedIndex = 0;
        }

        private void btnchonsua_Click(object sender, EventArgs e)
        {
            ServiceReferenceNhanVien.NhanVien objnv = (ServiceReferenceNhanVien.NhanVien)dataGridView1.SelectedRows[0].DataBoundItem;
            txtmanv.Text = objnv.MaNV.ToString();
            txttennv.Text = objnv.TenNV.ToString();
            txtusername.Text = objnv.Username.ToString();
            txtpass.Text = objnv.Password.ToString();
            txtemail.Text = objnv.Email.ToString();

            cbxQuyen.SelectedValue = objnv.QuyenNV;  
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txttennv.Text != "")
            {
                try
                {
                    if (txtmanv.Text == "") //them
                    {
                        ServiceReferenceNhanVien.NhanVien objnv = new ServiceReferenceNhanVien.NhanVien();
                        ServiceReferencePhanQuyen.PhanQuyen objqnv = (ServiceReferencePhanQuyen.PhanQuyen)cbxQuyen.SelectedItem;
                        objnv.TenNV = txttennv.Text;
                        objnv.Username = txtusername.Text;
                        objnv.Password = txtpass.Text;
                        objnv.Email = txtemail.Text;
                        objnv.QuyenNV = objqnv.MaPQ;
                        try
                        {
                            if (obj.InsertNhanVien(objnv) == 1)
                            {
                                MessageBox.Show("Them thanh cong!");
                                txtmanv.Text = "";
                                load();
                            }
                            else MessageBox.Show("Them that bai!");
                        }
                        catch
                        {
                            MessageBox.Show("Them that bai!");
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Có lỗi xảy ra. Vui lòng thao tác lại!");
                }
            }
            else
            {
                MessageBox.Show("Chưa hoàn tất thông tin!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txttennv.Text != "")
            {
                try
                {               
                    if (txtmanv.Text !="") //update
                    {
                        ServiceReferenceNhanVien.NhanVien objnv = new ServiceReferenceNhanVien.NhanVien();
                        ServiceReferencePhanQuyen.PhanQuyen objqnv = (ServiceReferencePhanQuyen.PhanQuyen)cbxQuyen.SelectedItem;
                        objnv.MaNV = int.Parse(txtmanv.Text.ToString());
                        objnv.TenNV = txttennv.Text;
                        objnv.Username = txtusername.Text;
                        objnv.Password = txtpass.Text;
                        objnv.Email = txtemail.Text;
                        objnv.QuyenNV = objqnv.MaPQ;
                        try
                        {
                            if (obj.UpdateNhanVien(objnv) == 1)                     
                            {
                                MessageBox.Show("Sua thanh cong!");
                                txtmanv.Text = "";
                                load();
                            }
                            else MessageBox.Show("Sua that bai!");
                        }
                        catch
                        {
                            MessageBox.Show("Sua that bai!!");
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Sua that bai!!");
                }
            }
            else
            {
                MessageBox.Show("Thong tin chua hoan tat!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
           ServiceReferenceNhanVien.NhanVien objnv = (ServiceReferenceNhanVien.NhanVien)dataGridView1.SelectedRows[0].DataBoundItem;
            if (MessageBox.Show("Ban co chac xoa ?", "Thong bao", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (obj.DeleteNhanVien(objnv) == 1)
                {
                    MessageBox.Show("Xoa thanh cong!");
                    load();
                }
                else MessageBox.Show("Con rang buoc du lieu, xoa that bai!");
            }
        }
        
    }
}
