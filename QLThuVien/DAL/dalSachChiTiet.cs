using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace QLThuVien.DAL
{
    class dalSachChiTiet
    {
        LopDungChung lopchung;
        public dalSachChiTiet()
        {
            lopchung = new LopDungChung();
        }

        public DataTable DalLoad()
        {
            string sql = "select MaMuonSach as 'Mã mượn sách', Sach.MaSach as 'Mã sách', Sach.TenSach as 'Tên sách', TenTrangThai as 'Trạng thái' " +
                "from SachChiTiet,Sach,TrangThai where SachChiTiet.MaSach =Sach.MaSach" +
                " and TrangThai.MaTrangThai = SachChiTiet.MaTrangThai";
            return lopchung.Load(sql);
        }

        public DataTable DalCheckCon(String tim, string ketQua)
        {
            string sql = "select MaMuonSach as 'Mã mượn sách', Sach.MaSach as 'Mã sách', Sach.TenSach as 'Tên sách', TenTrangThai as 'Trạng thái' " +
               "from SachChiTiet,Sach,TrangThai where SachChiTiet.MaSach =Sach.MaSach" +
               " and TrangThai.MaTrangThai = SachChiTiet.MaTrangThai" +
               " and TrangThai.MaTrangThai = '1'";
            tim = "";
            ketQua = "Kết quả tìm";
            return lopchung.Load(sql);
        }

        public DataTable DalCheckDangMuon(string tim, string ketQua)
        {
            string sql = "select MaMuonSach as 'Mã mượn sách', Sach.MaSach as 'Mã sách', Sach.TenSach as 'Tên sách', TenTrangThai as 'Trạng thái' " +
               "from SachChiTiet,Sach,TrangThai where SachChiTiet.MaSach =Sach.MaSach" +
               " and TrangThai.MaTrangThai = SachChiTiet.MaTrangThai" +
               " and TrangThai.MaTrangThai = '0'";
            tim = "";
            ketQua = "Kết quả tìm";
            return lopchung.Load(sql);
        }

        public DataTable DalKiemTra(string tim, Label ketQua)
        {
            string sql1 = "select count (*) " +
                 "from SachChiTiet,Sach,TrangThai where SachChiTiet.MaSach =Sach.MaSach" +
                 " and TrangThai.MaTrangThai = SachChiTiet.MaTrangThai" +
                 " and TrangThai.MaTrangThai = '0' and Sach.TenSach = N'" + tim + "'";
            string sql2 = "select count (*) " +
                "from SachChiTiet,Sach,TrangThai where SachChiTiet.MaSach =Sach.MaSach" +
                " and TrangThai.MaTrangThai = SachChiTiet.MaTrangThai" +
                " and TrangThai.MaTrangThai = '1' and Sach.TenSach = N'" + tim + "'";
            string sql3 = "select MaMuonSach as 'Mã mượn sách', Sach.MaSach as 'Mã sách', Sach.TenSach as 'Tên sách', TenTrangThai as 'Trạng thái' " +
                "from SachChiTiet,Sach,TrangThai where SachChiTiet.MaSach =Sach.MaSach" +
                " and TrangThai.MaTrangThai = SachChiTiet.MaTrangThai" +
                " and Sach.TenSach = N'" + tim + "'";
            int soSachMuon = (int)lopchung.Scalar(sql1);
            int soSachCon = (int)lopchung.Scalar(sql2);
            ketQua.Text = "Đang cho mượn " + soSachMuon + " còn lại " + soSachCon + " sách";
            return lopchung.Load(sql3);
        }

        public void DalXoa(string maMuonSach)
        {
            string sql_XoaSachChiTiet = "delete from SachChiTiet where MaMuonSach = '"+maMuonSach+"' ";
            string maSach = (string)lopchung.Scalar("select SachChiTiet.MaSach from SachChiTiet where MaMuonSach = '"+maMuonSach+"'");
            int soSachBanDau = (int)lopchung.Scalar("select SoLuong from Sach where Sach.MaSach = '"+maSach+"'");
            string sql_updateSach = " update Sach set SoLuong = '" + (soSachBanDau-1) + "' where MaSach = '" + maSach + "'";
            lopchung.Nonquery(sql_XoaSachChiTiet + sql_updateSach);
        }
    }
}
