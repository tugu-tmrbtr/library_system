using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bie_daalt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtUsername_MouseEnter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Хэрэглэгчийн нэр")
            {
                txtUsername.Clear();
            }

        }
        private void txtPassword_MouseEnter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Нууц үг")
            {
                txtPassword.Clear();
                txtPassword.PasswordChar = '*';
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NQUCL1I\DS_MSSQLSERVER;Initial Catalog=LibraryDB;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM loginTable WHERE username='" + txtUsername.Text + "' AND pass='" + txtPassword.Text + "'", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                dashboard dsb = new dashboard();
                dsb.Show();
            }
            else
                MessageBox.Show("Хэрэглэгчийн нэр эсвэл нууц үг буруу байна", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
