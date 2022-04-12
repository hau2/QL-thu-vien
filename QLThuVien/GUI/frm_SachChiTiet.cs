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

namespace QLThuVien
{
    public partial class frm_SachChiTiet : Form
    {
        //LopDungChung lopchung;
        BLL.bllSachChiTiet bllSachChiTiet;
        public frm_SachChiTiet()
        {
            bllSachChiTiet = new BLL.bllSachChiTiet(this);
            //lopchung = new LopDungChung();
            InitializeComponent();
            this.Text = "Chi tiết sách";
        }

        private void loadLaiBang()
        {
            bllSachChiTiet.BllLoad();
        }

        private void frm_SachChiTiet_Load(object sender, EventArgs e)
        {
            bllSachChiTiet.BllLoad();
        }

        private void rbt_Con_CheckedChanged(object sender, EventArgs e)
        {
            bllSachChiTiet.BllCheckCon();
            txt_Tim.Text = "";
            txt_KetQua.Text = "Kết quả tìm";
        }

        private void rbt_DangMuon_CheckedChanged(object sender, EventArgs e)
        {
            bllSachChiTiet.BllCheckDangMuon();
            txt_Tim.Text = "";
            txt_KetQua.Text = "Kết quả tìm";
        }

        private void btn_XemTatCa_Click(object sender, EventArgs e)
        {
            bllSachChiTiet.BllLoad();
            txt_Tim.Text = "";
            txt_KetQua.Text = "Kết quả tìm";
        }

        private void btn_KiemTra_Click(object sender, EventArgs e)
        {
            bllSachChiTiet.BllKiemTra();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            bllSachChiTiet.BllLXoa();
            bllSachChiTiet.BllLoad();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_MaMuonSach.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_Menu frm_Menu = new frm_Menu();
            frm_Menu.Show();
            this.Hide();
        }
    }
}
