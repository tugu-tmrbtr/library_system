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
    public partial class ViewBook : Form
    {
        public ViewBook()
        {
            InitializeComponent();
        }

        private void ViewBook_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NQUCL1I\DS_MSSQLSERVER;Initial Catalog=LibraryDB;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM NewBook", con);

            DataSet ds = new DataSet();
            sda.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        int bid;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible = true;

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NQUCL1I\DS_MSSQLSERVER;Initial Catalog=LibraryDB;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM NewBook WHERE bid = " +bid+ "", con);

            DataSet ds = new DataSet();
            sda.Fill(ds);

            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

            txtBookName.Text = ds.Tables[0].Rows[0][1].ToString();
            txtAuthorName.Text = ds.Tables[0].Rows[0][2].ToString();
            txtPublication.Text = ds.Tables[0].Rows[0][3].ToString();
            dtpPurDate.Text = ds.Tables[0].Rows[0][4].ToString();
            txtPrice.Text = ds.Tables[0].Rows[0][5].ToString();
            txtQuantity.Text = ds.Tables[0].Rows[0][6].ToString();
        }

        private void txtBName_TextChanged(object sender, EventArgs e)
        {
            if(txtBName.Text != "")
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NQUCL1I\DS_MSSQLSERVER;Initial Catalog=LibraryDB;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM NewBook WHERE bName LIKE '"+txtBName.Text+"%'", con);

                DataSet ds = new DataSet();
                sda.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NQUCL1I\DS_MSSQLSERVER;Initial Catalog=LibraryDB;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM NewBook", con);

                DataSet ds = new DataSet();
                sda.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtBName.Clear();
            panel2.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Өгөгдлийг шинэчлэх болно. Баталгаажуулах уу?", "Амжилттай", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                String bname = txtBookName.Text;
                String bauthor = txtAuthorName.Text;
                String publication = txtPublication.Text;
                String pdate = dtpPurDate.Text;
                Int64 price = Int64.Parse(txtPrice.Text);
                Int64 quantity = Int64.Parse(txtQuantity.Text);

                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NQUCL1I\DS_MSSQLSERVER;Initial Catalog=LibraryDB;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("UPDATE NewBook SET bName = '" + bname + "', bAuthor = '" + bauthor +
                    "' ,bPubl = '" + publication + "' ,bDate = '" + pdate + "' ,bPrice = " + price + " ,bQuan = " + quantity + " WHERE bid = " + rowid + "", con);

                DataSet ds = new DataSet();
                sda.Fill(ds);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Өгөгдлийг устгах болно. Баталгаажуулах уу?", "Баталгаажуулах цонх", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                String bname = txtBookName.Text;
                String bauthor = txtAuthorName.Text;
                String publication = txtPublication.Text;
                String pdate = dtpPurDate.Text;
                Int64 price = Int64.Parse(txtPrice.Text);
                Int64 quantity = Int64.Parse(txtQuantity.Text);

                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NQUCL1I\DS_MSSQLSERVER;Initial Catalog=LibraryDB;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("DELETE FROM NewBook WHERE bid = " + rowid + "", con);

                DataSet ds = new DataSet();
                sda.Fill(ds);
            }
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
