using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuVien.BLL
{
    class bllSachChiTiet
    {
        LopDungChung lopchung;
        DAL.dalSachChiTiet dalSachChiTiet = new DAL.dalSachChiTiet();
        frm_SachChiTiet frm_SachChiTiet;
        public bllSachChiTiet(frm_SachChiTiet frm_SachChiTiet) {
            this.frm_SachChiTiet = frm_SachChiTiet;
        }
        
        public void BllLoad()
        {
            this.frm_SachChiTiet.dataGridView1.DataSource = dalSachChiTiet.DalLoad();
        }

        public void BllCheckCon()
        {
            this.frm_SachChiTiet.dataGridView1.DataSource = dalSachChiTiet.DalCheckCon(this.frm_SachChiTiet.txt_Tim.Text, this.frm_SachChiTiet.txt_KetQua.Text);
        }

        public void BllCheckDangMuon()
        {
            this.frm_SachChiTiet.dataGridView1.DataSource = dalSachChiTiet.DalCheckDangMuon(this.frm_SachChiTiet.txt_Tim.Text, this.frm_SachChiTiet.txt_KetQua.Text);
        }

        public void BllKiemTra()
        {
            this.frm_SachChiTiet.dataGridView1.DataSource = dalSachChiTiet.DalKiemTra(this.frm_SachChiTiet.txt_Tim.Text, this.frm_SachChiTiet.txt_KetQua);
        }

        public void BllLXoa()
        {
            dalSachChiTiet.DalXoa(this.frm_SachChiTiet.txt_MaMuonSach.Text);
        }
    }
}
