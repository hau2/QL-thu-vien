using QLThuVien.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThuVien
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frm_Sach());
            
            //Application.Run(new frm_SachChiTiet());

            //Application.Run(new frm_MuonSach());

            //Application.Run(new frm_Sach());
            //Application.Run(new frm_SachChiTiet());
            //Application.Run(new frm_DangNhap());

            //Application.Run(new frm_DocGia());
            Application.Run(new frm_DangNhap());

            //LopDungChung lopchung;
            //BLL.bllSachChiTiet bllSachChiTiet;

            //bllSachChiTiet = new BLL.bllSachChiTiet(this);
            //lopchung = new LopDungChung();
        }
    }
}
