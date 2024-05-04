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
    public partial class DashBroad : Form
    {
        public DashBroad()
        {
            InitializeComponent();
        }

        private void btnAllStudents_Click(object sender, EventArgs e)
        {
            AllStudents ast = new AllStudents();
            ast.Show();
        }

        private void btnStudentFees_Click(object sender, EventArgs e)
        {
            StudentFees stf = new StudentFees();
            stf.Show();
        }

        private void btnLeavedStudent_Click(object sender, EventArgs e)
        {
            LeavedStudent lvt = new LeavedStudent();
            lvt.Show();
        }

        private void UpdateDeletedEmployee_Click(object sender, EventArgs e)
        {
            UpdateDeleteEmployee ude = new UpdateDeleteEmployee();
            ude.Show();
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Close();
        }

        private void btnManageRooms_Click(object sender, EventArgs e)
        {
            AddNewRooms anr = new AddNewRooms();
            anr.Show();
        }

        private void DashBroad_Load(object sender, EventArgs e)
        {

        }

        private void btnNewStudents_Click(object sender, EventArgs e)
        {
            NewStudent nsd = new NewStudent();
            nsd.Show();
        }

        private void btnUpdateDeletedStudent_Click(object sender, EventArgs e)
        {
            UpdateDeleteStudent uds = new UpdateDeleteStudent();
            uds.Show();
        }

        private void btnNewEmployee_Click(object sender, EventArgs e)
        {
            NewEmployee nee = new NewEmployee();
            nee.Show();
        }
    }
}
