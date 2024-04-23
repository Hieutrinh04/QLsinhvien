using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Kí_túc_xá_sinh_viên
{
    public partial class NewStudents : Form
    {
        Function fn = new Function();
        string query;

        public NewStudents()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtMobile_TextChanged(object sender, EventArgs e)
        {

        }

        private void NewStudents_Load(object sender, EventArgs e)
        {
            this.Location = new Point(545, 131);
            query = "SELECT roomNo from rooms WHERE roomStatus = 'Yes' AND Booked = 'No' ";
            DataSet ds = fn.GetData(query);

            // Kiểm tra nếu bảng có dữ liệu
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    // Lấy giá trị của room từ từng dòng trong bảng
                    Int64 room = Int64.Parse(ds.Tables[0].Rows[i][0].ToString());
                    ComboRoomNo.Items.Add(room);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMobile.Text != "" && txtName.Text != "" && txtFather.Text != "" && txtMother.Text != "" && txtEmail.Text != "" && txtPermaner.Text != "" && txtCollge.Text != "" && txtIdProof.Text != "" && ComboRoomNo.SelectedIndex != -1)
            {
                // Thực hiện lưu thông tin sinh viên vào cơ sở dữ liệu
                // Ví dụ:
                string mobile = txtMobile.Text;
                string name = txtName.Text;
                string father = txtFather.Text;
                string mother = txtMother.Text;
                string email = txtEmail.Text;
                string address = txtPermaner.Text;
                string university = txtCollge.Text;
                string idProof = txtIdProof.Text;
                Int64 roomNo = (Int64)ComboRoomNo.SelectedItem;
                // Thực hiện lưu thông tin sinh viên vào cơ sở dữ liệu
                string query = "INSERT INTO newStudent (mobile, name, fname, mname, email, paddress, college, idproof, roomNo) VALUES ('" + mobile + "', '" + name + "', '" + father + "', '" + mother + "', '" + email + "', '" + address + "', '" + university + "', '" + idProof + "', " + roomNo + ") update rooms set Booked = 'Yes' where roomNo = "+roomNo+"";

                // Gọi hàm để thực hiện truy vấn insert vào cơ sở dữ liệu
                // function.ExecuteQuery(query);


                // Gọi hàm để lưu thông tin sinh viên vào cơ sở dữ liệu
                // function.SaveStudent(mobile, name, father, mother, email, address, university, idProof, roomNo);

                // Sau khi lưu, bạn có thể thực hiện các hành động tiếp theo như hiển thị thông báo hoặc làm sạch các ô văn bản để chuẩn bị cho sinh viên mới.
                fn.SetData(query, "Sinh viên đăng ký thành công. ");
                ClearFields(); // Hàm này bạn tự định nghĩa để làm sạch các ô văn bản sau khi lưu thành công.
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin của sinh viên","Thông tin",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        // Hàm để làm sạch các ô văn bản sau khi lưu thành công.
        private void ClearFields()
        {
            txtMobile.Text = "";
            txtName.Text = "";
            txtFather.Text = "";
            txtMother.Text = "";
            txtEmail.Text = "";
            txtPermaner.Text = "";
            txtCollge.Text = "";
            txtIdProof.Text = "";
            ComboRoomNo.SelectedIndex = -1;
        }

        private void ComboRoomNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
