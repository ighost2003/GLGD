using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WindowsFormsApp1
{
    public partial class frm_giaodien : Form
    {
        public frm_giaodien()
        {
            InitializeComponent();
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtTaiKhoan.Text;
            string matKhau = txtMatKhau.Text;

            // Kiểm tra tài khoản và mật khẩu
            if (kiemTraDangNhap(taiKhoan, matKhau))
            {
                // Đăng nhập thành công
                MessageBox.Show("Đăng nhập thành công!");
                // Thực hiện các thao tác sau khi đăng nhập thành công

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
            if (taiKhoan == "admin" && matKhau == "123456")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

