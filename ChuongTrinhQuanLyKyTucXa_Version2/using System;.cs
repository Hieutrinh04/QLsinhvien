using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QLKTX
{
    public partial class frmDangNhap : DevComponents.DotNetBar.Office2007Form
    {
        int dem;
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void butok_Click(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                MessageBox.Show("Nhập User Name", "Thông Báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtuser.Focus();
                return;
            }
            if (txtpass.Text == "")
            {
                MessageBox.Show("Nhập Pass Word", "Thông Báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtpass.Focus();
                return;
            }
            if ((txtpass.Text == "admin") && (txtuser.Text == "admin"))
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form frm = new frmMain();
                this.Hide();
                frm.Show();
            }
            else
            {
                dem = dem + 1;
                if (dem < 3)
                {
                    if (txtuser.Text != "admin")
                    {
                        MessageBox.Show("Sai User Name!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtuser.Text = ""; txtuser.Focus(); return;
                    }


                    if (txtpass.Text != "admin")
                    {
                        MessageBox.Show("Sai Pass Word!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtpass.Text = ""; txtpass.Focus(); return;
                    }
                }
                else
                {
                    MessageBox.Show("Bạn đã nhập sai 3 lần. Chương trình sẽ bị đóng!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void butthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
