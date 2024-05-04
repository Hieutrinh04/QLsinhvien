using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ChuongTrinhQuanLyKyTucXa_Version2
{
    public partial class NewEmployee : Form
    {
        function fn = new function();
        string query;

        public NewEmployee()
        {
            InitializeComponent();
        }

        private void NewEmployee_Load(object sender, EventArgs e)
        {
            this.Location = new Point(545, 105);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearFields()
        {
            txtMobile.Text = "";
            txtName.Text = "";
            txtFather.Text = "";
            txtMother.Text = "";
            txtEmail.Text = "";
            txtPermaner.Text = "";
            txtIdProof.Text = "";
            txtDesignation.SelectedIndex = -1;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMobile.Text != "" && txtName.Text != "" && txtFather.Text != "" && txtMother.Text != "" && txtEmail.Text != "" && txtPermaner.Text != "" && txtIdProof.Text != "" && txtDesignation.SelectedIndex != -1)
            {
                try
                {
                    Int64 mobile = Int64.Parse(txtMobile.Text);
                    string name = txtName.Text;
                    string father = txtFather.Text;
                    string mother = txtMother.Text;
                    string email = txtEmail.Text;
                    string address = txtPermaner.Text;
                    string idProof = txtIdProof.Text;
                    string designation = txtDesignation.SelectedItem.ToString(); // Lấy giá trị được chọn trong ComboBox

                    // Thực hiện lưu thông tin nhân viên vào cơ sở dữ liệu
                    query = "INSERT INTO newEmployee (emobile, ename, efname, emname, eemail, epaddress, eidproof, edesignation) " +
                            "VALUES ('" + mobile + "', '" + name + "', '" + father + "', '" + mother + "', '" + email + "', '" + address + "',  '" + idProof + "', '" + designation + "');";

                    // Gọi hàm để thực hiện truy vấn insert vào cơ sở dữ liệu
                    fn.setData(query, "Đã thêm nhân viên mới thành công. ");

                    ClearFields(); // Hàm này bạn tự định nghĩa để làm sạch các ô văn bản sau khi lưu thành công.
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin của nhân viên", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
