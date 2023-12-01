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
   
    public partial class frm_dangnhap : Form
    {
        DBConnect conn;
        public frm_dangnhap()
        {
            InitializeComponent();
            conn = new DBConnect();
          


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtTaiKhoan.Text;
            string matKhau = txtMatkhau.Text;

            // Kiểm tra tài khoản và mật khẩu
            if (kiemTraDangNhap(taiKhoan, matKhau))
            {
                // Đăng nhập thành công
                MessageBox.Show("Đăng nhập thành công!");

                // Thực hiện các thao tác sau khi đăng nhập thành công
                this.Hide();
                frm_Trangchu frmtc = new frm_Trangchu();
                frmtc.ShowDialog();
                // Tiếp tục xử lý chương trình
            }
            else
            {
                // Đăng nhập thất bại
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!");
            }
        }

        // Hàm kiểm tra đăng nhập
        private bool kiemTraDangNhap(string taiKhoan, string matKhau)
        {

            // Thực hiện kiểm tra tài khoản và mật khẩu
            // Ví dụ: Kiểm tra trong CSDL hoặc so sánh với giá trị cứng
            // Trả về true nếu đăng nhập thành công, ngược lại trả về false
            try
            {
                conn.open();
                using (SqlCommand cmd = new SqlCommand("select*from ND where taikhoan = @tk and pass = @mk", conn.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@tk", taiKhoan);
                    cmd.Parameters.AddWithValue("@mk", matKhau);
                    using (SqlDataReader read = cmd.ExecuteReader())
                    {
                        return read.HasRows;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi:  {ex.Message}");
                return false;
            }
            finally { conn.close(); }

        }

    }
}

