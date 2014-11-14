using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormApp.ServiceReferenceSanPham;
using WinFormApp.ServiceReferencePhanLoai;

namespace WinFormApp

{
    public partial class FormQLSP : Form
    {
        ServiceReferenceSanPham.ServiceSanPhamClient obj = new ServiceReferenceSanPham.ServiceSanPhamClient();
        ServicePhanLoaiClient obj2 = new ServicePhanLoaiClient();
        ServiceReferencePhanLoai.PhanLoai objloai = new ServiceReferencePhanLoai.PhanLoai();
        public FormQLSP()
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
        public void load()
        {
            dataGridView1.DataSource = obj.SelectSanPham();
            dataGridView1.Columns["MaLoai"].Visible = false;
            dataGridView1.Columns["PhanLoai"].Visible = false;

            cbxloai.DataSource = obj2.SelectPhanLoai();
            cbxloai.ValueMember = "MaLoai";
            cbxloai.DisplayMember = "TenLoai";
        }
        private string NoiLuuHinhAnh = @"..\..\..\..\LapTopService\LapTopService\Images\SanPham\";

        private string NoiChonHinhAnh = "";
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ServiceReferenceSanPham.SanPham objsp = (ServiceReferenceSanPham.SanPham)dataGridView1.SelectedRows[0].DataBoundItem;

            txtmasp.Text = objsp.MaSP.ToString();
            txttensp.Text = objsp.TenSP;
            txthinhanh.Text = objsp.HinhAnh;
            txtgia.Text = objsp.Gia.ToString();
            txtmota.Text = objsp.MoTa;
            txtsoluong.Text = objsp.SoLuong.ToString();
            cbxloai.SelectedValue = objloai.MaLoai;

        }

        private void btnchonanh_Click(object sender, EventArgs e)
        {
            OpenFileDialog op1 = new OpenFileDialog();
            op1.Filter = "Images |*.jpg;*.jpeg;*.png;*.gif";
            op1.ShowDialog();
            txthinhanh.Text = op1.SafeFileName;
            NoiChonHinhAnh = op1.FileName;
        }

        private void btnChonsua_Click(object sender, EventArgs e)
        {
            ServiceReferenceSanPham.SanPham objsp = (ServiceReferenceSanPham.SanPham)dataGridView1.SelectedRows[0].DataBoundItem;

            txtmasp.Text = objsp.MaSP.ToString();
            txttensp.Text = objsp.TenSP;
            txthinhanh.Text = objsp.HinhAnh;
            txtgia.Text = objsp.Gia.ToString();
            txtmota.Text = objsp.MoTa;
            txtsoluong.Text = objsp.SoLuong.ToString();
            cbxloai.SelectedValue = objsp.MaLoai;


        }

        private void btnThem_Click(object sender, EventArgs e)
        {           
            ServiceReferencePhanLoai.PhanLoai pl_new = (ServiceReferencePhanLoai.PhanLoai)cbxloai.SelectedItem;
            int plnew = pl_new.MaLoai;

            if (txttensp.Text != "" && txtgia.Text != "" && txtsoluong.Text != "" && txtmota.Text != "")
            {
                try
                {
                    if (txtmasp.Text == "") //insert
                    {
                        ServiceReferenceSanPham.SanPham objsp = new ServiceReferenceSanPham.SanPham();
                        objsp.TenSP = txttensp.Text;
                        objsp.Gia = int.Parse(txtgia.Text.ToString());
                        objsp.SoLuong = int.Parse(txtsoluong.Text.ToString());
                        objsp.MoTa = txtmota.Text;
                        objsp.MaLoai = plnew;
                        objsp.HinhAnh = txthinhanh.Text;
                        try
                        {
                            File.Delete(NoiLuuHinhAnh + txthinhanh.Text);
                            File.Copy(NoiChonHinhAnh, NoiLuuHinhAnh + txthinhanh.Text);

                            if (obj.InsertSanPham(objsp) == 1)
                            {
                                MessageBox.Show("Them thanh cong!");
                               
                                txtmasp.Text = "";
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
                MessageBox.Show("tong tin chua hoan tat!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            ServiceReferencePhanLoai.PhanLoai pl_new = (ServiceReferencePhanLoai.PhanLoai)cbxloai.SelectedItem;
            int plnew = pl_new.MaLoai;

            if (txttensp.Text != "" && txtgia.Text != "" && txtsoluong.Text != "" && txtmota.Text != "")
            {
                try
                {
                    if (txtmasp.Text != "") //updte
                    {
                        ServiceReferenceSanPham.SanPham objsp = new ServiceReferenceSanPham.SanPham();
                        objsp.MaSP = int.Parse(txtmasp.Text.ToString());
                        objsp.TenSP = txttensp.Text;
                        objsp.Gia = int.Parse(txtgia.Text.ToString());
                        objsp.SoLuong = int.Parse(txtsoluong.Text.ToString());
                        objsp.MoTa = txtmota.Text;
                        objsp.MaLoai = plnew;
                        objsp.HinhAnh = txthinhanh.Text;
                        try
                        {
                            File.Delete(NoiLuuHinhAnh + txthinhanh.Text);
                            File.Copy(NoiChonHinhAnh, NoiLuuHinhAnh + txthinhanh.Text);

                            if (obj.InsertSanPham(objsp) == 1)
                            {
                                MessageBox.Show("Sua thanh cong!");

                                txtmasp.Text = "";
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
                MessageBox.Show("Thong tin chua hoan tat !");
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            ServiceReferenceSanPham.SanPham objsp = (ServiceReferenceSanPham.SanPham)dataGridView1.SelectedRows[0].DataBoundItem;
            if (MessageBox.Show("Ban co chac xoa ?", "Thong bao", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (obj.DeleteSanPham(objsp) == 1)
                {
                    MessageBox.Show("Xoa thanh cong!");
                    load();
                }
                else MessageBox.Show("Con rang buoc du lieu, xoa that bai!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtmasp.Text = "";
            txttensp.Text = "";
            txttensp.Focus();
            txtgia.Text = "";
            
            txtsoluong.Text = "";
            txtmota.Text = "";
            cbxloai.SelectedValue = objloai.MaLoai;
        }
        }
    }

