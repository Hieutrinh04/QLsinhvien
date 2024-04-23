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
    public partial class Dashbroad : Form
    {
        public Dashbroad()
        {
            InitializeComponent();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            UpdateDeleteStudent uds = new UpdateDeleteStudent();
            uds.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            NewStudents nst = new NewStudents();
            nst.Show();
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 fn = new Form1();
            fn.Show();
            this.Close();

        }

        private void Dashbroad_Load(object sender, EventArgs e)
        {

        }

        private void btnManageRooms_Click(object sender, EventArgs e)
        {
            AddNewRoom addNewRoomForm = new AddNewRoom();
            addNewRoomForm.Show();
        }
    }
}
