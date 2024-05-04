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
    public partial class UpdateDeleteEmployee : Form
    {
        function fn = new function();
        string query;

        public UpdateDeleteEmployee()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateDeleteEmployee_Load(object sender, EventArgs e)
        {
            this.Location = new Point(545, 105);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMobile.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            query = "SELECT * FROM newEmployee WHERE emobile = @Mobile";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Mobile", txtMobile.Text);
            DataSet ds = fn.GetData(query, parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtName.Text = ds.Tables[0].Rows[0]["ename"].ToString();
                txtFather.Text = ds.Tables[0].Rows[0]["efname"].ToString();
                txtMother.Text = ds.Tables[0].Rows[0]["emname"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["eemail"].ToString();
                txtPermaner.Text = ds.Tables[0].Rows[0]["epaddress"].ToString();
                txtIdProof.Text = ds.Tables[0].Rows[0]["eidproof"].ToString();
                txtDesignation.Text = ds.Tables[0].Rows[0]["edesignation"].ToString();
                txtWorking.Text = ds.Tables[0].Rows[0]["working"].ToString();
            }
            else
            {
                MessageBox.Show("Số điện thoại này không tồn tại!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
