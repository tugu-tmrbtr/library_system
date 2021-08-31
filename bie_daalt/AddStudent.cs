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
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Баталгаажуулах уу?", "Анхааруулга", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtStudentName.Clear();
            txtEnrollMentNo.Clear();
            txtDepartment.Clear();
            txtStudentCode.Clear();
            txtStudentContact.Clear();
            txtStudentEmail.Clear();
        }

        private void btnSaveInfo_Click(object sender, EventArgs e)
        {
            if (txtStudentName.Text != "" && txtEnrollMentNo.Text != "" && txtDepartment.Text != "" && txtStudentCode.Text != "" && txtStudentContact.Text != "" && txtStudentEmail.Text != "")
            {
                String name = txtStudentName.Text;
                String enroll = txtEnrollMentNo.Text;
                String depart = txtDepartment.Text;
                String code = txtStudentCode.Text;
                Int64 mobile = Int64.Parse(txtStudentContact.Text);
                String email = txtStudentEmail.Text;

                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NQUCL1I\DS_MSSQLSERVER;Initial Catalog=LibraryDB;Integrated Security=True");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into NewStudent (sName,enroll,dep,sCode,contact,sEmail) values ('" + name + "','"
                    + enroll + "','" + depart + "','" + code + "'," + mobile + ",'" + email + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Өгөгдлийг хадгалсан", "Амжилттай", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Хоосон талбарыг зөвшөөрөхгүй", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
