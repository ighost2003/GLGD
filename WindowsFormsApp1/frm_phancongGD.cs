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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace WindowsFormsApp1
{
    public partial class frm_phancongGD : Form
    {

        SqlConnection conn;
        SqlDataAdapter da_PCGD;
        DataSet ds_PCGD;
        public frm_phancongGD()
        {
            InitializeComponent();
            
            string strConnect = "Data Source = DESKTOP-UMUNA1R; Initial Catalog= QLGD; User Id=sa; Password = 123 ";
            conn = new SqlConnection(strConnect);
            DataTable dt_ND = new DataTable();
            ds_PCGD = new DataSet();
            string sql = "select*from PCGD";
            da_PCGD = new SqlDataAdapter(sql,conn);
            
            //dt_ND=db.getDataTable(str);
            da_PCGD.Fill(ds_PCGD, "PCGD");
        }

        private void frm_phancongGD_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds_PCGD.Tables["PCGD"];
            databiding();
        }
        void databiding()
        {
            textBox1.DataBindings.Clear();
            textBox2.DataBindings.Clear();
            textBox3.DataBindings.Clear();
            textBox4.DataBindings.Clear();
            textBox5.DataBindings.Clear();
            textBox6.DataBindings.Clear();
            dateTimePicker1.DataBindings.Clear();
            dateTimePicker2.DataBindings.Clear();
            textBox1.DataBindings.Add("Text", dataGridView1.DataSource, "mapcgd");
            textBox2.DataBindings.Add("Text", dataGridView1.DataSource, "magv");
            textBox3.DataBindings.Add("Text", dataGridView1.DataSource, "maphong");
            textBox4.DataBindings.Add("Text", dataGridView1.DataSource, "mahocphan");
            textBox5.DataBindings.Add("Text", dataGridView1.DataSource, "tietday");
            textBox6.DataBindings.Add("Text", dataGridView1.DataSource, "malop");
            dateTimePicker1.DataBindings.Add("Text", dataGridView1.DataSource, "ngaybatdau");
            dateTimePicker2.DataBindings.Add("Text", dataGridView1.DataSource, "ngayketthuc");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow newrow = ds_PCGD.Tables[0].NewRow();
            newrow["mapcgd"] = textBox1.Text;
            newrow["magv"] = textBox2.Text;
            newrow["maphong"] = textBox3.Text;
            newrow["mahocphan"] = textBox4.Text;
            newrow["tietday"] = textBox5.Text;
            newrow["malop"] = textBox6.Text;
            newrow["ngaybatdau"] = dateTimePicker1.Value;
            newrow["ngayketthuc"] = dateTimePicker2.Value;
            ds_PCGD.Tables[0].Rows.Add(newrow);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da_PCGD);
            da_PCGD.Update(ds_PCGD, "PCGD");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_PCGD.Tables["PCGD"].Columns["mapcgd"];
            ds_PCGD.Tables["PCGD"].PrimaryKey = key;
            DataRow dr = ds_PCGD.Tables["PCGD"].Rows.Find(textBox1.Text);
            if (dr != null)
            {
                dr.Delete();
            }
            SqlCommandBuilder cmb = new SqlCommandBuilder(da_PCGD);
            da_PCGD.Update(ds_PCGD, "PCGD");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_PCGD.Tables["PCGD"].Columns["mapcgd"];
            ds_PCGD.Tables["PCGD"].PrimaryKey = key;
            DataRow dr = ds_PCGD.Tables["PCGD"].Rows.Find(textBox1.Text);
            if (dr != null)
            {
                dr["magv"] = textBox2.Text;
                dr["maphong"] = textBox3.Text;
                dr["mahocphan"] = textBox4.Text;
                dr["tietday"] = textBox5.Text;
                dr["malop"] = textBox6.Text;
                dr["ngaybatdau"] = dateTimePicker1.Value;
                dr["ngayketthuc"] = dateTimePicker2.Value;
            }
            SqlCommandBuilder cmb = new SqlCommandBuilder(da_PCGD);
            da_PCGD.Update(ds_PCGD, "PCGD");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
