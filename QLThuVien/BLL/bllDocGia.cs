using QLThuVien.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuVien.BLL
{
    class bllDocGia
    {
        LopDungChung lopchung;
        DAL.dalDocGia dalDocGia = new DAL.dalDocGia();
        frm_DocGia frm_DocGia;
        public bllDocGia(frm_DocGia frm_DocGia)
        {
            this.frm_DocGia = frm_DocGia;
            lopchung = new LopDungChung();
        }

        public void BllLoad()
        {
            frm_DocGia.dataGridView1.DataSource = dalDocGia.DalLoadDocGia();
        }

        public void BllThem()
        {
            dalDocGia.DalThem(this.frm_DocGia.txt_maDocGia.Text, this.frm_DocGia.txt_hoTen.Text, this.frm_DocGia.txt_diaChi.Text, this.frm_DocGia.txt_sdt.Text);
        }

        public void BllSua()
        {
            dalDocGia.DalSua(this.frm_DocGia.txt_hoTen.Text, this.frm_DocGia.txt_diaChi.Text, this.frm_DocGia.txt_sdt.Text, this.frm_DocGia.txt_maDocGia.Text);
        }

        public void BllXoa()
        {
            dalDocGia.DalXoa(this.frm_DocGia.txt_maDocGia.Text);
        }

        public void BllTim()
        {
            frm_DocGia.dataGridView1.DataSource = dalDocGia.DalTim(this.frm_DocGia.txt_tim.Text);
        }
    }
}
