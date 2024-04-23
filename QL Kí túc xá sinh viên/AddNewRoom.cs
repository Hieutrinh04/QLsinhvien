using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QL_Kí_túc_xá_sinh_viên
{
    public partial class AddNewRoom : Form
    {
        Function fn = new Function();
        string query;

        public AddNewRoom()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNewRoom_Load(object sender, EventArgs e)
        {
            labelRoom.Visible = false;
            labelRoomExist.Visible = false;
            LoadRooms(); // Load existing rooms when the form loads

            // Canh form ra giữa màn hình
            this.CenterToScreen();
        }

        private void LoadRooms()
        {
            query = "SELECT * FROM rooms";
            DataSet ds = fn.GetData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            query = "SELECT * FROM rooms WHERE roomNo='" + txtRoomNo1.Text + "'";
            DataSet ds = fn.GetData(query);

            if (ds.Tables[0].Rows.Count == 0)
            {
                string status = checkBox1.Checked ? "Yes" : "No";
                labelRoomExist.Visible = false;
                query = "INSERT INTO rooms (roomNo, roomStatus) VALUES ('" + txtRoomNo1.Text + "','" + status + "')";
                fn.SetData(query, "Đã thêm phòng.");
                LoadRooms(); // Reload rooms after adding a new room
            }
            else
            {
                labelRoomExist.Text = "Phòng đã có ";
                labelRoomExist.Visible = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            query = "SELECT * FROM rooms WHERE roomNo = '" + txtRoomNo2.Text + "'";
            DataSet ds = fn.GetData(query);
            if (ds.Tables[0].Rows.Count == 0)
            {
                labelRoom.Text = "Phòng này không tồn tại ";
                labelRoom.Visible = true;
                checkBox2.Checked = false;
            }
            else
            {
                labelRoom.Text = "Phòng này đã tìm thấy ";
                labelRoom.Visible = true;
                dataGridView1.DataSource = ds.Tables[0]; // Display the found room in the DataGridView
                if (ds.Tables[0].Rows[0]["roomStatus"].ToString() == "Yes")
                {
                    checkBox2.Checked = true;
                }
                else
                {
                    checkBox2.Checked = false;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string status = checkBox2.Checked ? "Yes" : "No";
            query = "UPDATE rooms SET roomStatus='" + status + "' WHERE roomNo = '" + txtRoomNo2.Text + "'";
            fn.SetData(query, "Cập nhật chi tiết thành công!");
            LoadRooms(); // Reload rooms after updating
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            query = "SELECT * FROM rooms WHERE roomNo = '" + txtRoomNo2.Text + "'";
            DataSet ds = fn.GetData(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                query = "DELETE FROM rooms WHERE roomNo = '" + txtRoomNo2.Text + "'";
                fn.SetData(query, "Đã xóa chi tiết phòng!");
                LoadRooms(); // Reload rooms after deleting
            }
            else
            {
                MessageBox.Show("Phòng không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
