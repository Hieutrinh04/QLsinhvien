using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuongTrinhQuanLyKyTucXa_Version2
{
    public partial class AllStudents : Form
    {
        function fn = new function(); 
        string query;
        public AllStudents()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AllStudents_Load(object sender, EventArgs e)
        {
            this.Location = new Point(545, 105);
            query = "SELECT * FROM newStudent WHERE living = 'Yes'";
            DataSet ds = fn.GetData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

       
    }
}
