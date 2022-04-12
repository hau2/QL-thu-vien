using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace QLThuVien.DAL
{
    class dalMuonSach
    {
        LopDungChung lopchung;
        public dalMuonSach()
        {
            lopchung = new LopDungChung();
        }
        public DataTable DalLoadDataNguoiMuon()
        {
            string sql = "select DocGia.MaDocGia as 'Mã độc giả', DocGia.HoTen as 'Họ tên', DocGia.SDT as 'Số điện thoại'," +
                " PhieuMuon.MaMuonSach as 'Mã mượn sách', TenSach as 'Tên sách',TacGia as 'Tác giả', NgayMuon as 'Ngày mượn'" +
                " from PhieuMuon, DocGia, Sach, SachChiTiet where PhieuMuon.MaDocGia = DocGia.MaDocGia" +
                " and PhieuMuon.MaMuonSach = SachChiTiet.MaMuonSach and Sach.MaSach = SachChiTiet.MaSach";
            return lopchung.Load(sql);
        }

        public void DalMuon(string maMuonSach, string maDocGia)
        {
            string sql_check = "select count (*) from SachChiTiet where MaMuonSach = '" + maMuonSach + "' and MaTrangThai = '0'";
            int i = (int)lopchung.Scalar(sql_check);
            if (i != 0)
            {
                MessageBox.Show("Sách này đã có người mượn");
            }
            else
            {
                string sql = "insert into PhieuMuon values ('" + maDocGia + "','" + maMuonSach + "', '" + DateTime.Now + "') " +
                    "update SachChiTiet set MaTrangThai = '0' where MaMuonSach = '" + maMuonSach + "'";
                lopchung.Nonquery(sql);
            }
        }

        public void DalTra(string maMuonSach)
        {
            string sql = "update SachChiTiet set MaTrangThai = '1' where MaMuonSach = '" + maMuonSach + "' " +
                "delete PhieuMuon where MaMuonSach = '" + maMuonSach + "'";
            lopchung.Nonquery(sql);
        }

        public DataTable DalTim(String tim)
        {
            string sql = "select DocGia.MaDocGia as 'Mã độc giả', DocGia.HoTen as 'Họ tên', DocGia.SDT as 'Số điện thoại'," +
                " PhieuMuon.MaMuonSach as 'Mã mượn sách', TenSach as 'Tên sách',TacGia as 'Tác giả', NgayMuon as 'Ngày mượn'" +
                " from PhieuMuon, DocGia, Sach, SachChiTiet where PhieuMuon.MaDocGia = DocGia.MaDocGia" +
                " and PhieuMuon.MaMuonSach = SachChiTiet.MaMuonSach and Sach.MaSach = SachChiTiet.MaSach" +
                " and DocGia.SDT = '" + tim + "'";
            return lopchung.Load(sql);
        }
    }
}
