using System;
using System.Collections;
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
    public partial class LeavedStudent : Form
    {
        function fn = new function();
        string query;
        public LeavedStudent()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LeavedStudent_Load(object sender, EventArgs e)
        {
            this.Location = new Point(545, 105);
            query = "SELECT * FROM newStudent WHERE living = 'No'";
            DataSet ds = fn.GetData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }
    }
}
