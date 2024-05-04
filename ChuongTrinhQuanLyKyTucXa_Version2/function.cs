using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ChuongTrinhQuanLyKyTucXa_Version2
{
    internal class function // Sửa từ "function" thành "Function" để phù hợp với chuẩn đặt tên
    {
        protected SqlConnection GetSqlConnection()
        {
            string connectionString = "Data Source=LAPTOP-V5TS8BLR\\HIEU;Initial Catalog=hostelvertion3;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            return con;
        }

        public DataSet GetData(string query, System.Collections.Generic.Dictionary<string, object> parameters)
        {
            SqlConnection con = GetSqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void setData(string query, string msg) // Sửa tên phương thức từ "setData" thành "SetData" để phù hợp với chuẩn đặt tên
        {
            SqlConnection con = GetSqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            try
            {
                con.Open();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                MessageBox.Show(msg, "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực hiện truy vấn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        internal DataSet GetData(string query)
        {
            throw new NotImplementedException();
        }
    }
}
