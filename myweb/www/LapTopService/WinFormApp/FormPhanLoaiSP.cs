using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormApp.ServiceReferencePhanLoai;

namespace WinFormApp
{
    public partial class FormPhanLoaiSP : Form
    {

        
        ServicePhanLoaiClient obj = new ServicePhanLoaiClient();

        
        public FormPhanLoaiSP()
        {
            InitializeComponent();
            load();
        }

        public void load()
        {
            dataGridView1.DataSource = obj.SelectPhanLoai();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            FormQuanLy form = new FormQuanLy();
            this.Visible = false;
            form.Visible = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Disable();
            Enable();
            PhanLoai objpl = (PhanLoai)dataGridView1.SelectedRows[0].DataBoundItem;
            txtmaloai.Text = objpl.MaLoai.ToString();
            txttenloai.Text = objpl.TenLoai.ToString();
            txttenloai.Focus();
            txttenloai.Enabled = true;
            

        }
        private void Disable()
        {
            txttenloai.Enabled = false;

            txtmaloai.Text = "";
            txttenloai.Text = "";
           
        }

        private void Enable()
        {
            txttenloai.Enabled = true;          
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txttenloai.Text != "")
            {
                try
                {
                    if (txtmaloai.Text == "") //insert
                    {
                        PhanLoai objpl = new PhanLoai();
                        objpl.TenLoai = txttenloai.Text;
                        try
                        {
                            if (obj.InsertPhanLoai(objpl) == 1)
                            {
                                MessageBox.Show("Thêm thành công!");
                                txtmaloai.Text = "";
                                load();
                            }
                            else MessageBox.Show("Có lỗi xảy ra. Vui lòng thao tác lại!");
                        }
                        catch
                        {
                            MessageBox.Show("khong them duoc. kiem tra va lam lai");
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("oh oh loi roi!");
                }
            }
            else
            {
                MessageBox.Show("Kiem tra lai thong tin ban dien!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            PhanLoai objpl =(PhanLoai)dataGridView1.SelectedRows[0].DataBoundItem;
            if (MessageBox.Show("Ban co chac xoa ?", "Thong bao", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (obj.DeletePhanLoai(objpl) == 1)
                {
                    MessageBox.Show("Xoa thanh cong!");
                    load();
                }
                else MessageBox.Show("Con rang buoc du lieu, xoa that bai!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txttenloai.Text != "")
            {
                try
                {
                    if (txtmaloai.Text != "") //update
                    {
                        PhanLoai objpl = (PhanLoai)dataGridView1.SelectedRows[0].DataBoundItem;
                        txtmaloai.Text = objpl.MaLoai.ToString();
                        txttenloai.Text = objpl.TenLoai.ToString();
                        objpl.MaLoai = int.Parse(txtmaloai.Text.ToString());
                        objpl.TenLoai = txttenloai.Text;
                        try
                        {
                            if (obj.UpdatePhanLoai(objpl) == 1)
                            {
                                MessageBox.Show("Sua thanh cong!");
                                txtmaloai.Text = "";
                                load();
                            }
                            else MessageBox.Show("khong sua duoc. kiem tra va lam lai!");
                        }
                        catch
                        {
                            MessageBox.Show("khong sua duoc. kiem tra va lam lai!");
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("oh oh loi roi!");
                }
            }
            else
            {
                MessageBox.Show("Kiem tra lai thong tin ban dien!");
            }                        
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Disable();
            Enable();
            txtmaloai.Text = "";
            txttenloai.Text = "";
            txttenloai.Focus();
        }

        private void btnChonsua_Click(object sender, EventArgs e)
        {
            Disable();
            Enable();
            PhanLoai objpl = (PhanLoai)dataGridView1.SelectedRows[0].DataBoundItem;
            txtmaloai.Text = objpl.MaLoai.ToString();
            txttenloai.Text = objpl.TenLoai.ToString();
        }

      
    }
}
