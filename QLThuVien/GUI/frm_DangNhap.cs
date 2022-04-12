using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLThuVien.GUI
{
    public partial class frm_DangNhap : Form
    {
        LopDungChung lopchung;
        public frm_DangNhap()
        {
            InitializeComponent();
            lopchung = new LopDungChung();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có muốn đóng không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
                Application.Exit();
        }

        private void btn_dangNhap_Click(object sender, EventArgs e)
        {
            string chuoiketnoi = lopchung.chuoiketnoi;
            SqlConnection cnn = new SqlConnection(chuoiketnoi);
            String sqlDangNhap = "select count (*) from TaiKhoan where TENDANGNHAP = '" + txt_tenDangNhap.Text + "' and MATKHAU = '" + txt_matKhau.Text + "'";
            SqlCommand comm = new SqlCommand(sqlDangNhap, cnn);
            cnn.Open();
            int ketqua = (int)comm.ExecuteScalar();
            cnn.Close();
            if (ketqua >= 1)
            {
                this.Hide();
                frm_Menu ql = new frm_Menu();
                ql.Show();
            }
            else MessageBox.Show("Loi dang nhap");
        }
    }
}
