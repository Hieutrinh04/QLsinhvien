using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QL_Kí_túc_xá_sinh_viên
{
    internal class Function
    {
        protected SqlConnection GetConnection()
        {
            // Update your connection string here
            string connectionString = "Data Source=LAPTOP-V5TS8BLR\\HIEU;Initial Catalog=hostel;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            return con;
        }

        public DataSet GetData(string query)
        {
            DataSet ds = new DataSet(); // Create a new DataSet
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand(query, con); // Pass the query directly to the command

            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds); // Fill the DataSet with the data from the SqlDataAdapter
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                con.Close(); // Always close the connection, whether an exception occurred or not
            }

            return ds;
        }

        public void SetData(string query, string msg)
        {
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand(); // Corrected the instantiation of SqlCommand
            cmd.Connection = con;

            try
            {
                con.Open();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery(); // Corrected the method name
                MessageBox.Show(msg, "Thông tin ", MessageBoxButtons.OK, MessageBoxIcon.Information); // Corrected the method names and enum names
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
