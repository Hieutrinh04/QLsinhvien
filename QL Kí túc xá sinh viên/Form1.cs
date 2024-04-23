using System;
using System.Windows.Forms;

namespace QL_Kí_túc_xá_sinh_viên
{
    public partial class Form1 : Form
    {
        // Set default username and password
        private string defaultUsername = "Hieu";
        private string defaultPassword = "Pass";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Save the username and password in variables
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Check username and password
            if (username == defaultUsername && password == defaultPassword)
            {
                // If username and password are correct, show the Dashboard form and hide Form1
                this.Hide();
                Dashbroad frm = new Dashbroad(); // Corrected form2 -> Form2
                frm.ShowDialog();
            }
            else
            {
                // If username or password is incorrect, show error message
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!");
                // Message translated: "Username or password is incorrect!"
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
