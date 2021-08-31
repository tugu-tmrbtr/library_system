using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bie_daalt
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private void гарахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Та гарахдаа итгэлтэй байна уу ?", "Баталгаажуулах", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void номНэмэхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBook ab = new AddBook();
            ab.Show();
        }

        private void номҮзэхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewBook vb = new ViewBook();
            vb.Show();
        }

        private void оюутанНэмэхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudent ast = new AddStudent();
            ast.Show();
        }

        private void оюутныМэдээллийгҮзэхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewStudent vst = new ViewStudent();
            vst.Show();
        }

        private void гаргасанНомуудToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueBooks ibs = new IssueBooks();
            ibs.Show();
        }

        private void буцахНомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnBook rtnb = new ReturnBook();
            rtnb.Show();
        }

        private void номынДэлгэрэнгүйМэдээлэлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompleteBookDetails cbd = new CompleteBookDetails();
            cbd.Show();
        }
    }
}
