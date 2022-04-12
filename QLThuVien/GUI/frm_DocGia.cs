using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace QLThuVien.GUI
{
    public partial class frm_DocGia : Form
    {
        LopDungChung lopchung;
        BLL.bllDocGia bllDocGia;
        public frm_DocGia()
        {
            InitializeComponent();
            lopchung = new LopDungChung();
            bllDocGia = new BLL.bllDocGia(this);
        }

        private void QL_DocGia_Load(object sender, EventArgs e)
        {
            bllDocGia.BllLoad();
        }
        private void LoadDocGia()
        {
            bllDocGia.BllLoad();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            bllDocGia.BllThem();
            bllDocGia.BllLoad();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            bllDocGia.BllSua();
            bllDocGia.BllLoad();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            bllDocGia.BllXoa();
            bllDocGia.BllLoad();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_maDocGia.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_hoTen.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_diaChi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_sdt.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void btn_tim_Click(object sender, EventArgs e)
        {
            bllDocGia.BllTim();
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            LoadDocGia();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_MuonSach frm_MuonSach = new frm_MuonSach();
            frm_MuonSach.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_Menu frm_Menu = new frm_Menu();
            frm_Menu.Show();
            this.Hide();
        }
    }
}
