using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormApp
{
    public partial class FormQuanLy : Form
    {
        public FormQuanLy()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormPhanLoaiSP form = new FormPhanLoaiSP();
            this.Visible = false;
            form.Visible = true;
        }       

        private void btnQLNV_Click(object sender, EventArgs e)
        {
            FormNhanVien form = new FormNhanVien();
            this.Visible = false;
            form.Visible = true;
        }
        private void FormQuanLy_Load(object sender, EventArgs e)
        {

        }

        private void btnQLSP_Click(object sender, EventArgs e)
        {
            FormQLSP form = new FormQLSP();
            this.Visible = false;
            form.Visible = true;
        }

        private void btnQLKH_Click(object sender, EventArgs e)
        {
            FormKhachHang form = new FormKhachHang();
            this.Visible = false;
            form.Visible = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
