using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThuVien.BLL
{
    class bllMuonSach
    {
        LopDungChung lopchung;
        DAL.dalMuonSach dalMuonSach = new DAL.dalMuonSach();
        frm_MuonSach frm_MuonSach;
        public bllMuonSach(frm_MuonSach frm_MuonSach)
        {
            this.frm_MuonSach = frm_MuonSach;
            lopchung = new LopDungChung();
        }

        public void BllLoad()
        {
            frm_MuonSach.dataGridView1.DataSource = dalMuonSach.DalLoadDataNguoiMuon();
        }

        public void BllMuon()
        {
            dalMuonSach.DalMuon(this.frm_MuonSach.txt_MaMuonSach.Text, this.frm_MuonSach.txt_MaDocGia.Text);
        }

        public void BllTra()
        {
            dalMuonSach.DalTra(this.frm_MuonSach.txt_MaMuonSach.Text);
        }

        public void BllTim()
        {
            this.frm_MuonSach.dataGridView1.DataSource = dalMuonSach.DalTim(this.frm_MuonSach.txt_Tim.Text);
        }
    }
}
