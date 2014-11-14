using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormApp.ServiceReferenceKhachHang;

namespace WinFormApp
{
    public partial class FormKhachHang : Form
    {
        ServiceKhachHangClient obj = new ServiceKhachHangClient();
        public FormKhachHang()
        {
            InitializeComponent();
            load();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            FormQuanLy form = new FormQuanLy();
            this.Visible = false;
            form.Visible = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ServiceReferenceKhachHang.KhachHang objkh = (ServiceReferenceKhachHang.KhachHang)dataGridView1.SelectedRows[0].DataBoundItem;
            txtMaKH.Text = objkh.MaKH.ToString();
            txtUsername.Text = objkh.Username.ToString();
            txtpass.Text = objkh.Password.ToString();
            txtEmail.Text = objkh.Email.ToString();
            txtHoten.Text = objkh.HoTen.ToString();
            DateTime dt = DateTime.Parse(objkh.NgaySinh.ToString());
            txtngaysinh.Text = dt.ToShortDateString();
            txtdiachi.Text = objkh.DiaChi.ToString();
            txtdienthoai.Text = objkh.DienThoai.ToString();

            if (objkh.GioiTinh == "Nam")
            {
                cbxGioitinh.SelectedIndex = 0;
            }
            else
            {
                cbxGioitinh.SelectedIndex = 1;
            }

        }
        public void load() 
        {
            dataGridView1.DataSource = obj.SelectKhachHang();
            dataGridView1.Columns["Password"].Visible = true;
        }

        private void btnChonsua_Click(object sender, EventArgs e)
        {
            ServiceReferenceKhachHang.KhachHang objkh = (ServiceReferenceKhachHang.KhachHang)dataGridView1.SelectedRows[0].DataBoundItem;
            txtMaKH.Text = objkh.MaKH.ToString();
            txtUsername.Text = objkh.Username.ToString();
            txtpass.Text = objkh.Password.ToString();
            txtEmail.Text = objkh.Email.ToString();
            txtHoten.Text = objkh.HoTen.ToString();
            DateTime dt = DateTime.Parse(objkh.NgaySinh.ToString());
            txtngaysinh.Text = dt.ToShortDateString();
            txtdiachi.Text = objkh.DiaChi.ToString();
            txtdienthoai.Text = objkh.DienThoai.ToString();

            if (objkh.GioiTinh == "Nam")
            {
                cbxGioitinh.SelectedIndex = 0;
            }
            else
            {
                cbxGioitinh.SelectedIndex = 1;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaKH.Text = "";
            txtUsername.Text = "";
            txtpass.Text = "";
            txtEmail.Text = "";
            txtHoten.Text = "";
            txtngaysinh.Text = "";
            txtdiachi.Text = "";
            txtdienthoai.Text = "";
            cbxGioitinh.SelectedIndex = 0;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            ServiceReferenceKhachHang.KhachHang objkh = (ServiceReferenceKhachHang.KhachHang)dataGridView1.SelectedRows[0].DataBoundItem;
            if (MessageBox.Show("Ban co chac xoa ?", "Thong bao", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (obj.DeleteKhachHang(objkh) == 1)
                {
                    MessageBox.Show("Xoa thanh cong!");
                    load();
                }
                else MessageBox.Show("Con rang buoc du lieu, xoa that bai!");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtHoten.Text != "")
            {
                try
                {
                    if (txtMaKH.Text == "") //insert
                    {
                        ServiceReferenceKhachHang.KhachHang objkh = new ServiceReferenceKhachHang.KhachHang();
                        objkh.Username = txtUsername.Text;
                        objkh.Password = txtpass.Text;
                        objkh.Email = txtEmail.Text;
                        objkh.HoTen = txtHoten.Text;
                        objkh.GioiTinh = cbxGioitinh.Text;
                        objkh.NgaySinh = DateTime.Parse(txtngaysinh.Text);
                        objkh.DiaChi = txtdiachi.Text;
                        objkh.DienThoai = txtdienthoai.Text;
                        try
                        {
                            if (obj.InsertKhachHang(objkh) == 1)
                            {
                                MessageBox.Show("Them thanh cong!");
                                txtHoten.Text = "";
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
                    MessageBox.Show("Them that bai!");
                }
            }
            else
            {
                MessageBox.Show("Thong tin chua hoan tat!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
             if (txtHoten.Text != "")
            {
                try
                {
                    if (txtMaKH.Text != "") //update
                    {
                        ServiceReferenceKhachHang.KhachHang objkh = new ServiceReferenceKhachHang.KhachHang();
                        objkh.MaKH = int.Parse(txtMaKH.Text);
                        objkh.Username = txtUsername.Text;
                        objkh.Password = txtpass.Text;
                        objkh.Email = txtEmail.Text;
                        objkh.HoTen = txtHoten.Text;
                        objkh.GioiTinh = cbxGioitinh.Text;
                        objkh.NgaySinh = DateTime.Parse(txtngaysinh.Text);
                        objkh.DiaChi = txtdiachi.Text;
                        objkh.DienThoai = txtdienthoai.Text;
                        try
                        {
                            if (obj.UpdateKhachHang(objkh) == 1)
                            {
                                MessageBox.Show("Sua thanh cong!");
                                txtMaKH.Text = "";
                                load();
                            }
                            else MessageBox.Show("Sua that bai!");
                        }
                        catch
                        {
                            MessageBox.Show("Sua that bai!");
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Sua that bai!");
                }
            }
             else
             {
                 MessageBox.Show("Thong tin chua hoan tat!");
             }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            txtngaysinh.Text = dateTimePicker1.Value.Day.ToString() + "/" + dateTimePicker1.Value.Month.ToString() + "/" + dateTimePicker1.Value.Year.ToString();
        }


    }
}
