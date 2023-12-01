using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApp1
{
    public partial class frm_nguoidung : Form
    {
        //DBConnect db= new DBConnect();
        SqlConnection sql = new SqlConnection("Data Source = DESKTOP-UMUNA1R; Initial Catalog= QLGD; User Id=sa; Password = 123 ");
        DataSet ds_ND;
        SqlDataAdapter da_ND;
        public frm_nguoidung()
        {
            InitializeComponent();
            string str = "select*from ND";
            DataTable dt_ND = new DataTable();
            ds_ND = new DataSet();
            da_ND = new SqlDataAdapter(str,sql);
            //dt_ND=db.getDataTable(str);
            da_ND.Fill(ds_ND, "ND");


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = ds_ND.Tables["ND"];
            databiding();
        }
        void databiding()
        {
            txtTaikhoan.DataBindings.Clear();
            txtMatkhau.DataBindings.Clear();
            txtManhom.DataBindings.Clear();
            txtTaikhoan.DataBindings.Add("Text", dataGridView1.DataSource, "taikhoan");
            txtMatkhau.DataBindings.Add("Text", dataGridView1.DataSource, "pass");
            txtManhom.DataBindings.Add("Text", dataGridView1.DataSource, "manhom");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow newrow = ds_ND.Tables[0].NewRow();
            newrow["taikhoan"] = txtTaikhoan.Text;
            newrow["pass"]=txtMatkhau.Text;
            newrow["manhom"] = txtManhom.Text;
            ds_ND.Tables[0].Rows.Add(newrow);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da_ND);
            da_ND.Update(ds_ND, "ND");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_ND.Tables["ND"].Columns["taikhoan"];
            ds_ND.Tables["ND"].PrimaryKey = key;
            DataRow dr = ds_ND.Tables["ND"].Rows.Find(txtTaikhoan.Text);
            if (dr != null)
            {
                dr.Delete();
            }
            SqlCommandBuilder cmb = new SqlCommandBuilder(da_ND);
            da_ND.Update(ds_ND, "ND");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_ND.Tables["ND"].Columns["taikhoan"];
            ds_ND.Tables["ND"].PrimaryKey = key;
            DataRow dr = ds_ND.Tables["ND"].Rows.Find(txtTaikhoan.Text);
            if (dr != null)
            {
                dr["pass"]=txtMatkhau.Text;
                dr["manhom"]=txtManhom.Text;
            }
            SqlCommandBuilder cmb = new SqlCommandBuilder(da_ND);
            da_ND.Update(ds_ND, "ND");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát", "Thông báo thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(r== DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lưu thành công dcmm!!!!");
        }
    }
}

