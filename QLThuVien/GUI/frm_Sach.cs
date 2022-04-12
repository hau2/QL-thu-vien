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
    public partial class frm_Sach : Form
    {
        LopDungChung lopchung;
        BLL.bllSach bllSach;
        public frm_Sach()
        {
            InitializeComponent();
            lopchung = new LopDungChung();
            bllSach = new BLL.bllSach(this);
        }

        private void QL_Sach_Load(object sender, EventArgs e)
        {
            LoadSach();
            LoadComboBox();
        }
        private void LoadSach()
        {
            bllSach.BllLoad();
        }
        private void LoadComboBox()
        {
            SqlConnection conn = new SqlConnection(lopchung.chuoiketnoi);
            string sqlCombo = "select * from THELOAI";
            SqlDataAdapter daCombo = new SqlDataAdapter(sqlCombo, conn);
            DataTable dtCombo = new DataTable();
            daCombo.Fill(dtCombo);
            cb_theLoai.DataSource = dtCombo;
            cb_theLoai.DisplayMember = "TENTHELOAI";
            cb_theLoai.ValueMember = "MATHELOAI";
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            bllSach.BllThem();
            bllSach.BllLoad();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            bllSach.BllSua();
            bllSach.BllLoad();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            bllSach.BllXoa();
            bllSach.BllLoad();
        }

        private void btn_tim_Click(object sender, EventArgs e)
        {
            bllSach.BllTim();
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            LoadSach();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_maSach.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_tenSach.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_tacGia.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cb_theLoai.SelectedIndex = cb_theLoai.FindStringExact(dataGridView1.CurrentRow.Cells[3].Value.ToString());
            txt_soLuong.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_Menu frm_Menu = new frm_Menu();
            frm_Menu.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_SachChiTiet frm_SachChiTiet = new frm_SachChiTiet();
            frm_SachChiTiet.Show();
            this.Hide();
        }
    }
}
