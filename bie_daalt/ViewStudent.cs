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
    public partial class ViewStudent : Form
    {
        public ViewStudent()
        {
            InitializeComponent();
        }

        private void txtEno_TextChanged(object sender, EventArgs e)
        {
            if (txtEno.Text != "")
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NQUCL1I\DS_MSSQLSERVER;Initial Catalog=LibraryDB;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM NewBook WHERE sName LIKE '" + txtEno.Text + "%'", con);

                DataSet ds = new DataSet();
                sda.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NQUCL1I\DS_MSSQLSERVER;Initial Catalog=LibraryDB;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM NewStudent", con);

                DataSet ds = new DataSet();
                sda.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void ViewStudent_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NQUCL1I\DS_MSSQLSERVER;Initial Catalog=LibraryDB;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM NewStudent", con);

            DataSet ds = new DataSet();
            sda.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }
        int stuid;
        Int64 rowid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                stuid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible = true;

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NQUCL1I\DS_MSSQLSERVER;Initial Catalog=LibraryDB;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM NewStudent WHERE stuid = " + stuid + "", con);

            DataSet ds = new DataSet();
            sda.Fill(ds);

            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

            txtStudentName.Text = ds.Tables[0].Rows[0][1].ToString();
            txtEnrollmentNo.Text = ds.Tables[0].Rows[0][2].ToString();
            txtDepartment.Text = ds.Tables[0].Rows[0][3].ToString();
            txtStudentCode.Text = ds.Tables[0].Rows[0][4].ToString();
            txtStudentContact.Text = ds.Tables[0].Rows[0][5].ToString();
            txtStudentEmail.Text = ds.Tables[0].Rows[0][6].ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Өгөгдлийг шинэчлэх болно. Баталгаажуулах уу?", "Амжилттай", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                String sname = txtStudentName.Text;
                String enrollno = txtEnrollmentNo.Text;
                String dep = txtDepartment.Text;
                String scode = txtStudentCode.Text;
                Int64 contact = Int64.Parse(txtStudentContact.Text);
                String email = txtStudentEmail.Text;

                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NQUCL1I\DS_MSSQLSERVER;Initial Catalog=LibraryDB;Integrated Security=True");
                SqlDataAdapter DA = new SqlDataAdapter("UPDATE NewStudent SET sName = '" + sname + "', enroll = '" + enrollno +
                    "' ,dep = '" + dep + "' ,sCode = '" + scode + "' ,contact = " + contact + " ,sEmail = '" + email + "' WHERE stuid = " + rowid + "", con);

                DataSet ds = new DataSet();
                DA.Fill(ds);
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Өгөгдлийг устгах болно. Баталгаажуулах уу?", "Баталгаажуулах цонх", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                String sname = txtStudentName.Text;
                String enrollno = txtEnrollmentNo.Text;
                String dep = txtDepartment.Text;
                String scode = txtStudentCode.Text;
                Int64 contact = Int64.Parse(txtStudentContact.Text);
                String email = txtStudentEmail.Text;

                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NQUCL1I\DS_MSSQLSERVER;Initial Catalog=LibraryDB;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("DELETE FROM NewStudent WHERE stuid = " + rowid + "", con);

                DataSet ds = new DataSet();
                sda.Fill(ds);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtEno.Clear();
            panel2.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Энэ нь таны хадгалаагүй өгөгдлийг устгах болно", "Та итгэлтэй байна уу ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
