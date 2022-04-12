using QLThuVien.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuVien.BLL
{
    class bllSach
    {
        LopDungChung lopchung;
        DAL.dalSach dalSach = new DAL.dalSach();
        frm_Sach frm_Sach;
        public bllSach(frm_Sach frm_Sach)
        {
            this.frm_Sach = frm_Sach;
            lopchung = new LopDungChung();
        }

        public void BllLoad()
        {
            frm_Sach.dataGridView1.DataSource = dalSach.DalLoadSach();
        }

        public void BllThem()
        {
            dalSach.DalThem(this.frm_Sach.txt_maSach.Text, this.frm_Sach.txt_tenSach.Text, this.frm_Sach.txt_tacGia.Text, this.frm_Sach.cb_theLoai.SelectedValue.ToString(), this.frm_Sach.txt_soLuong.Text);
        }

        public void BllSua()
        {
            dalSach.DalSua(this.frm_Sach.txt_tenSach.Text, this.frm_Sach.txt_tacGia.Text, this.frm_Sach.cb_theLoai.SelectedValue.ToString(), this.frm_Sach.txt_soLuong.Text, this.frm_Sach.txt_maSach.Text);
        }

        public void BllXoa()
        {
            dalSach.DalXoa(this.frm_Sach.txt_maSach.Text);
        }

        public void BllTim()
        {
            frm_Sach.dataGridView1.DataSource = dalSach.DalTim(this.frm_Sach.txt_tim.Text);
        }
    }
}
