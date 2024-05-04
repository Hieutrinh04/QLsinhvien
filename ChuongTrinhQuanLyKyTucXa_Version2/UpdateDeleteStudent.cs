using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ChuongTrinhQuanLyKyTucXa_Version2
{
    public partial class UpdateDeleteStudent : Form
    {
        function fn = new function();  
        string query;

        public UpdateDeleteStudent()
        {
            InitializeComponent();
        }

        private void UpdateDeleteStudent_Load(object sender, EventArgs e)
        {
            this.Location = new Point(545, 105);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ClearAll() 
        {
            txtMobile.Clear();
            txtName.Clear();
            txtFather.Clear();
            txtMother.Clear();
            txtEmail.Clear();
            txtPermaner.Clear();
            txtCollege.Clear();
            txtIdProof.Clear();
            txtRoomNo.Clear();
            ComboxLiving.SelectedIndex = -1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            query = "SELECT * FROM newStudent WHERE mobile = '" + txtMobile.Text + "'";
            DataSet ds = fn.GetData(query);

            if (ds.Tables[0].Rows.Count != 0)
            {
                txtName.Text = ds.Tables[0].Rows[0]["name"].ToString();
                txtFather.Text = ds.Tables[0].Rows[0]["fname"].ToString();
                txtMother.Text = ds.Tables[0].Rows[0]["mname"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["email"].ToString();
                txtPermaner.Text = ds.Tables[0].Rows[0]["paddress"].ToString();
                txtCollege.Text = ds.Tables[0].Rows[0]["college"].ToString();
                txtIdProof.Text = ds.Tables[0].Rows[0]["idproof"].ToString();
                txtRoomNo.Text = ds.Tables[0].Rows[0]["roomNo"].ToString();
                ComboxLiving.Text = ds.Tables[0].Rows[0]["Living"].ToString();
            }
            else
            {
                ClearAll(); 
                MessageBox.Show("Số điện thoại này không tồn tại!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll(); 
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Int64 mobile;
            if (!Int64.TryParse(txtMobile.Text, out mobile))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Int64 roomno;
            if (!Int64.TryParse(txtRoomNo.Text, out roomno))
            {
                MessageBox.Show("Số phòng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string name = txtName.Text;
            string fname = txtFather.Text;
            string mname = txtMother.Text;
            string email = txtEmail.Text;
            string paddress = txtPermaner.Text;
            string college = txtCollege.Text;
            string idproof = txtIdProof.Text;
            string living = ComboxLiving.Text;

            query = "UPDATE newStudent SET name = '" + name + "', fname = '" + fname + "', mname = '" + mname + "', email = '" + email + "', paddress = '" + paddress + "', college = '" + college + "', idproof = '" + idproof + "', roomNo = " + roomno + ", Living = '" + living + "' WHERE mobile = " + mobile;

            // Thực hiện câu truy vấn và kiểm tra kết quả
            fn.setData(query, "Cập nhật dữ liệu thành công");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Int64 mobile;
            if (!Int64.TryParse(txtMobile.Text, out mobile))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            query = "DELETE FROM newStudent WHERE mobile = " + mobile;

            // Thực hiện câu truy vấn và kiểm tra kết quả
            fn.setData(query, "Xóa dữ liệu thành công");
        }
    }
}
