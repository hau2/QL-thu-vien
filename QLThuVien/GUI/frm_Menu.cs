using QLThuVien.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThuVien
{
    public partial class frm_Menu : Form
    {
        public frm_Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_DocGia frm_DocGia = new frm_DocGia();
            frm_DocGia.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_Sach frm_Sach = new frm_Sach();
            frm_Sach.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_SachChiTiet frm_SachChiTiet = new frm_SachChiTiet();
            frm_SachChiTiet.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frm_MuonSach frm_MuonSach = new frm_MuonSach();
            frm_MuonSach.Show();
            this.Hide();
        }
    }
}
