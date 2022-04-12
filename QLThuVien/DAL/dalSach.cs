using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThuVien.DAL
{
    class dalSach
    {
        LopDungChung lopchung;
        Random random = new Random();
        public dalSach()
        {
            lopchung = new LopDungChung();
        }

        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public DataTable DalLoadSach()
        {
            string sql = "select MaSach as 'Mã sách', TenSach as 'Tên sách', TacGia as 'Tác giả'," +
                " TenTheLoai as 'Thể loại', SoLuong as 'Số lượng' from SACH, THELOAI where Sach.MaTheLoai = TheLoai.MaTheLoai";
            return lopchung.Load(sql);
        }

        public void DalThem(string maSach, string tenSach, string tacGia, string theLoai, string soLuong)
        {
            Random rnd = new Random();
            string sql = "insert into SACH values('" + maSach + "', N'" + tenSach + "', N'" + tacGia + "', N'" + theLoai + "', '" + soLuong + "') ";

            for(int i=0; i<Int32.Parse(soLuong); i++)
            {
                int maMuonSach = rnd.Next(10000, 100000);
                string randomStr = RandomString(4);
                string sql1 = "insert into SachChiTiet values('" + randomStr+ maMuonSach + "','" + maSach + "','1') ";
                sql = sql + sql1;
            }
            
            lopchung.Nonquery(sql);
        }

        public void DalSua(string tenSach, string tacGia, string theLoai, string soLuong, string maSach)
        {
            int soLuongBanDau = (int)lopchung.Scalar("select SoLuong from Sach where MaSach = '"+maSach+"'");
            if (Int32.Parse(soLuong) < soLuongBanDau)
            {
                MessageBox.Show("Không được cập nhật số lượng sách ít hơn số lượng ban đầu");
                return;
            }
            else
            {
                string sql = "update SACH set TENSACH = N'" + tenSach + "', TACGIA = N'" + tacGia + "', MATHELOAI = N'" + theLoai + "', SOLUONG = '" + soLuong + "' where MASACH = '" + maSach + "' ";
                for (int i = 0; i < Int32.Parse(soLuong)-soLuongBanDau; i++)
                {
                    Random rnd = new Random();
                    int maMuonSach = rnd.Next(10000, 100000);
                    string randomStr = RandomString(4);
                    string sql1 = "insert into SachChiTiet values('" + randomStr+ maMuonSach + "','" + maSach + "','1') ";
                    sql = sql + sql1;
                }
                lopchung.Nonquery(sql);
                MessageBox.Show("Đã tạo thêm " + (Int32.Parse(soLuong) - soLuongBanDau) + " sách");
            }
        }

        public void DalXoa(string maSach)
        {
            string sql_XoaSachChuaChoMuon = "DELETE FROM SachChiTiet " +
                " where SachChiTiet.MASACH = '" + maSach + "' and MaTrangThai = '1'";

            string sql1 = "select count (*) from SachChiTiet where SachChiTiet.MASACH = '" + maSach + "' and MaTrangThai = '0'";
            int soSachDangChoMuon = (int)lopchung.Scalar(sql1);

            string sql_updateSach;
            if (soSachDangChoMuon == 0)
            {
                sql_updateSach = " delete from Sach where MaSach = '" + maSach + "'";
            }
            else
            {
                sql_updateSach = " update Sach set SoLuong = '" + soSachDangChoMuon + "' where MaSach = '" + maSach + "'";
            }
            lopchung.Nonquery(sql_XoaSachChuaChoMuon + sql_updateSach);
            MessageBox.Show("Những sách đang cho mượn sẽ không bị xoá");
        }

        public DataTable DalTim(string tim)
        {
            string sql = "select * from SACH where TENSACH like N'%" + tim + "%' ";
            return lopchung.Load(sql);
        }
    }
}
