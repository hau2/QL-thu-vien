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
    public partial class frm_MuonSach : Form
    {
        
        LopDungChung lopchung;
        BLL.bllMuonSach bllMuonSach;
        public frm_MuonSach()
        {
            bllMuonSach = new BLL.bllMuonSach(this);
            InitializeComponent();
            lopchung = new LopDungChung();
            this.Text = "Mượn / trả sách";
        }

        private void loadDataNguoiMuon()
        {
            bllMuonSach.BllLoad();
        }

        private void btn_Muon_Click(object sender, EventArgs e)
        {
            bllMuonSach.BllMuon();
            bllMuonSach.BllLoad();
        }

        private void btn_TraSach_Click(object sender, EventArgs e)
        {
            bllMuonSach.BllTra();
            bllMuonSach.BllLoad();
        }

        private void frm_MuonSach_Load(object sender, EventArgs e)
        {
            bllMuonSach.BllLoad();
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            bllMuonSach.BllTim();
        }

        private void btn_XemTatCa_Click(object sender, EventArgs e)
        {
            loadDataNguoiMuon();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_MaDocGia.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();
            txt_MaMuonSach.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString().Trim();
        }

        private void txt_MaMuonSach_TextChanged(object sender, EventArgs e)
        {
            string query = "select TenSach from Sach, SachChiTiet where Sach.MaSach = SachChiTiet.MaSach and MaMuonSach = '" + txt_MaMuonSach.Text + "'";
            string tenSach = (string)lopchung.Scalar(query);
            txt_TenSach.Text = tenSach;
        }

        private void txt_MaDocGia_TextChanged(object sender, EventArgs e)
        {
            string query = "select HoTen from DocGia where MaDocGia = '" + txt_MaDocGia.Text + "'";
            string tenDocGia = (string)lopchung.Scalar(query);
            txt_TenDocGia.Text = tenDocGia;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_SachChiTiet frm_SachChiTiet = new frm_SachChiTiet();
            frm_SachChiTiet.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_Menu frm_Menu = new frm_Menu();
            frm_Menu.Show();
            this.Hide();
        }
    }
}
