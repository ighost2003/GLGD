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

namespace WindowsFormsApp1
{
    public partial class frm_Trangchu : Form
    {
        DBConnect conn;
        public frm_Trangchu()
        {
            InitializeComponent();
            conn = new DBConnect();
        }

        

        private void quảnLíNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_nguoidung frmnd = new frm_nguoidung();
            frmnd.ShowDialog();
        }

        private void chươngTrìnhĐàoTạoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_chuongtrinhDT frmctdt = new frm_chuongtrinhDT();
            frmctdt.ShowDialog();
        
        }

        private void phânCôngGiảngDạyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_phancongGD frmpcgd = new frm_phancongGD();
            frmpcgd.ShowDialog();
        }

        private void hồSơGiảngViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_hosoGV frmdsgv = new frm_hosoGV();
            frmdsgv.ShowDialog();
        }

        private void lớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_Lop frml = new frm_Lop();
            frml.ShowDialog();
        }

        private void mônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_monhoc frmmh = new frm_monhoc();
            frmmh.ShowDialog();
        }

        private void giámSátGiảngDạyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_GSGD frmgsgd = new frm_GSGD();
            frmgsgd.ShowDialog();
        }

        private void phòngHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_Phonghoc frmph = new frm_Phonghoc();
            frmph.ShowDialog();
        }
    }
}

