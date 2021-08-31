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
    public partial class IssueBooks : Form
    {
        public IssueBooks()
        {
            InitializeComponent();
        }

        private void IssueBooks_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NQUCL1I\DS_MSSQLSERVER;Initial Catalog=LibraryDB;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            cmd = new SqlCommand("SELECT bName FROM NewBook", con);
            SqlDataReader Sdr = cmd.ExecuteReader();

            while (Sdr.Read())
            {
                for (int i = 0; i < Sdr.FieldCount; i++)
                {
                    comboBoxBook.Items.Add(Sdr.GetString(i));
                }
            }
            Sdr.Close();
            con.Close();
        }

        int count;
        private void btnStudentSeacrh_Click(object sender, EventArgs e)
        {
            if(txtEnrollNo.Text != "")
            {
                String eid = txtEnrollNo.Text;
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NQUCL1I\DS_MSSQLSERVER;Initial Catalog=LibraryDB;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM NewStudent WHERE enroll = '" + eid + "'", con);

                DataSet ds = new DataSet();
                sda.Fill(ds);

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select count(std_enroll) from IRBook where std_enroll = '" + eid + "' and book_return_date IS NULL";
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataSet ds1 = new DataSet();
                sda.Fill(ds1);

                
                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtStudentName.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtDepartment.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtStudentCode.Text = ds.Tables[0].Rows[0][4].ToString();
                    txtStudentContact.Text = ds.Tables[0].Rows[0][5].ToString();
                    txtStudentEmail.Text = ds.Tables[0].Rows[0][6].ToString();
                }
                else
                {
                    txtStudentName.Clear();
                    txtDepartment.Clear();
                    txtStudentCode.Clear();
                                      txtStudentEmail.Clear();
                    txtStudentContact.Clear();

                    MessageBox.Show("Бүртгэлийн дугаар буруу байна", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }   
        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            if(txtStudentName.Text != "")
            {
                if(comboBoxBook.SelectedIndex != -1 && count <= 2)
                { 
                    String enroll = txtEnrollNo.Text;
                    String sname = txtStudentName.Text;
                    String sdep = txtDepartment.Text;
                    String scode = txtStudentCode.Text;
                    String semail = txtStudentEmail.Text;
                    Int64 scontact = Int64.Parse(txtStudentContact.Text);
                    String bookname = comboBoxBook.Text;
                    String bookIssueDate = dateTimePicker1.Text;

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "Data Source=DESKTOP-NQUCL1I\\DS_MSSQLSERVER;Initial Catalog=LibraryDB;Integrated Security=True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = cmd.CommandText = "insert into IRBook (std_enroll,std_name,std_dep,std_code,std_email,std_contact,book_name,book_issue_date) values ('" + enroll + "','" + sname + "','" + sdep + "','" + scode + "','" + semail + "'," + scontact + ",'" + bookname + "','" + bookIssueDate + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Ном гаргасан", "Амжилттай", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Ном сонгоно уу. Эсвэл номын тоо дууссан байна", "Ном сонгоогүй", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            else
            {
                MessageBox.Show("Зөв бүртгэлийн дугаар оруулна уу", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEnrollNo_TextChanged(object sender, EventArgs e)
        {
            if(txtStudentName.Text != "")
            {
                txtStudentName.Clear();
                txtDepartment.Clear();
                txtStudentCode.Clear();
                txtStudentEmail.Clear();
                txtStudentContact.Clear();             
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtEnrollNo.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Энэ нь таны хадгалаагүй өгөгдлийг устгах болно", "Та итгэлтэй байна уу ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
