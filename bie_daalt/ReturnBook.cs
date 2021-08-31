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
    public partial class ReturnBook : Form
    {
        public ReturnBook()
        {
            InitializeComponent();
        }

        private void btnStudentSeacrh_Click(object sender, EventArgs e)
        {

            String eid = txtEnrollNo.Text;
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NQUCL1I\DS_MSSQLSERVER;Initial Catalog=LibraryDB;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("select * from IRBook where std_enroll = '" + eid + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Хүчингүй үнэмлэх эсвэл Ном гаргаагүй", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReturnBook_Load(object sender, EventArgs e)
        {
            txtEnrollNo.Clear();
        }

        String bname;
        String bdate;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Visible = true;

            if(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                rowid = Int64.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                bname = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                bdate = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            }
            txtBookName.Text = bname;
            txtIssueBook.Text = bdate;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-NQUCL1I\\DS_MSSQLSERVER;Initial Catalog=LibraryDB;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "update IRBook set book_return_date ='" + dateTimePicker1.Text + "' where std_enroll = '" + txtEnrollNo.Text + "' and id =" +rowid+ "";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Амжилтаа буцаалаа", "Амжилттай", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ReturnBook_Load(this, null);
        }

        private void txtEnrollNo_TextChanged(object sender, EventArgs e)
        {
            if(txtEnrollNo.Text != "")
            {
                dataGridView1.DataSource = null;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtEnrollNo.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }
    }
}
