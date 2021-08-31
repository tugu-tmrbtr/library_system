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
    public partial class AddBook : Form
    {
        public AddBook()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtBookName.Text != "" && txtAuthorName.Text != "" && txtPublication.Text != "" && txtPrice.Text != "" && txtQuantity.Text != "") 
            {
                String bname = txtBookName.Text;
                String bauthor = txtAuthorName.Text;
                String publication = txtPublication.Text;
                String pdate = dtpPurDate.Text;
                Int64 price = Int64.Parse(txtPrice.Text);
                Int64 quantity = Int64.Parse(txtQuantity.Text);

                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NQUCL1I\DS_MSSQLSERVER;Initial Catalog=LibraryDB;Integrated Security=True");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into NewBook (bName,bAuthor,bPubl,bDate,bPrice,bQuan) values ('" + bname + "','"
                    + bauthor + "','" + publication + "','" + pdate + "'," + price + "," + quantity + ")";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Өгөгдлийг хадгалсан", "Амжилттай", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtBookName.Clear();
                txtAuthorName.Clear();
                txtPublication.Clear();
                txtPrice.Clear();
                txtQuantity.Clear();
            }
            else
            {
                MessageBox.Show("Хоосон талбарыг зөвшөөрөхгүй", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Энэ нь таны хадгалаагүй өгөгдлийг устгах болно", "Та итгэлтэй байна уу ?", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
