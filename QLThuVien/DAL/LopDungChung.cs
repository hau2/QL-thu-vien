using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLThuVien
{
    class LopDungChung
    {
        public string chuoiketnoi = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\_HocOnline\CS464H\do_an_nhom\QLThuVien\QLThuVien\QLThuVien.mdf;Integrated Security=True";
        SqlConnection conn;

        public LopDungChung()
        {
            conn = new SqlConnection(chuoiketnoi);
        }

        public DataTable Load(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public bool Nonquery(string sql)
        {
            SqlCommand comm = new SqlCommand(sql, conn);
            conn.Open();
            try
            {
                int ketqua = comm.ExecuteNonQuery();
                if (ketqua >= 1)
                {
                    MessageBox.Show("Thành công");
                    conn.Close();
                    return true;
                }
                else MessageBox.Show("Thất bại");
                conn.Close();
                return false;
            }
            catch
            {
                MessageBox.Show("Thất bại");
            }
            conn.Close();
            return false;
        }
        public object Scalar(string sql)
        {
            SqlCommand comm = new SqlCommand(sql, conn);
            conn.Open();
            object ketqua = comm.ExecuteScalar();
            conn.Close();
            return ketqua;
        }
    }
}
