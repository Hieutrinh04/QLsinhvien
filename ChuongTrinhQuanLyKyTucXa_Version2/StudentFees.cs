using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ChuongTrinhQuanLyKyTucXa_Version2
{
    public partial class StudentFees : Form
    {
        function fn = new function(); // Sửa từ "function" thành "Function" để phù hợp với chuẩn đặt tên
        string query;

        public StudentFees()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StudentFees_Load(object sender, EventArgs e)
        {
            this.Location = new Point(545, 105);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMMM yyyy";
        }

        public void SetDataGrid(Int64 mobile) // Sửa tên phương thức từ "setDataGrid" thành "SetDataGrid" để phù hợp với chuẩn đặt tên
        {
            query = "SELECT * FROM fees WHERE mobileNo =" + mobile;
            DataSet ds = fn.GetData(query);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                guna2DataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                guna2DataGridView1.DataSource = null;
            }
        }

        private void ClearAll()
        {
            txtMobile.Clear();
            txtName.Clear();
            txtAmount.Clear();
            txtRoomNo.Clear();
            txtEmail.Clear();
            guna2DataGridView1.DataSource = null; // Xóa dữ liệu trong DataGridView
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtMobile.Text))
            {
                query = "SELECT name, email, roomNo FROM newStudent WHERE mobile = '" + txtMobile.Text + "'";
                DataSet ds = fn.GetData(query);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    txtName.Text = ds.Tables[0].Rows[0]["name"].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0]["email"].ToString();
                    txtRoomNo.Text = ds.Tables[0].Rows[0]["roomNo"].ToString();
                    SetDataGrid(Convert.ToInt64(txtMobile.Text));
                }
                else
                {
                    ClearAll(); // Xóa dữ liệu hiển thị nếu không tìm thấy hồ sơ
                    MessageBox.Show("Hồ sơ này không tồn tại.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        
    }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (txtMobile.Text != "" && txtAmount.Text != "")
            {
                query = "SELECT * FROM fees WHERE mobileNo = " + Int64.Parse(txtMobile.Text) + "and fmonth=' " + dateTimePicker1 + "'";

                DataSet ds = fn.GetData(query);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 0)
                {
                    Int64 mobile = Int64.Parse(txtMobile.Text);
                    String month = dateTimePicker1.Text;
                    Int64 amount = Int64.Parse(txtAmount.Text);
                    query = "insert into fees values (" + mobile + ",'" + month + "', " + amount + ")";
                    fn.setData(query, "Phí đã trả ");
                    ClearAll();

                }
                else
                {
                    MessageBox.Show("Không có lệ phí của " + dateTimePicker1.Text + "Còn lại.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
    }
}
