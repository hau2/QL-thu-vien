using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace QLThuVien.DAL
{
    class dalDocGia
    {
        LopDungChung lopchung;
        public dalDocGia()
        {
            lopchung = new LopDungChung();
        }

        public DataTable DalLoadDocGia()
        {
            string sql = "select MaDocGia as 'Mã độc giả', HoTen as 'Họ tên', DiaChi as 'Địa chỉ', SDT as 'Số điện thoại' from DocGia";
            return lopchung.Load(sql);
        }

        public void DalThem(string maDocGia, string hoTen, string diaChi, string sdt)
        {
            string sql = "insert into DOCGIA values('" + maDocGia + "', N'" + hoTen + "', N'" + diaChi + "','" + sdt + "')";
            lopchung.Nonquery(sql);
        }

        public void DalSua(string hoTen, string diaChi, string sdt, string maDocGia)
        {
            string sql = "update DOCGIA set HOTEN= N'" + hoTen + "', DIACHI= N'" + diaChi + "', SDT= '" + sdt + "'where MADOCGIA='" + maDocGia + "' ";
            lopchung.Nonquery(sql);
        }

        public void DalXoa(string maDocGia)
        {
            string sql = "delete from DOCGIA where MADOCGIA = '" + maDocGia + "'";
            if (!lopchung.Nonquery(sql))
            {
                MessageBox.Show("Độc giả này đang mượn sách nên không thể xoá");
            }
        }

        public DataTable DalTim(string tim)
        {
            string sql = "select * from DOCGIA where HOTEN like N'%" + tim + "%' ";
            return lopchung.Load(sql);
        }
    }
}
