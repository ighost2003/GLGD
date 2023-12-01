using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace WindowsFormsApp1
{
    class DBConnect
    {
        SqlConnection connect;
        public SqlConnection Connection { get; set; }
        string strConnect = "Data Source = DESKTOP-UMUNA1R; Initial Catalog= QLGD; User Id=sa; Password = 123 ";
        public DBConnect()
        {
            connect = new SqlConnection(strConnect);
        }
        public SqlConnection GetConnection()
        {
            return connect;
        }
        public void open()
        {
            if(connect.State==ConnectionState.Closed)
                connect.Open();
        }
        public void close()
        {
            if (connect.State == ConnectionState.Open)
                connect.Close();
        }
        public int getNonQuery(string sql)
        {
            open();
            SqlCommand cmd = new SqlCommand(sql,connect);
            int kq=cmd.ExecuteNonQuery();
            close();
            return kq;
        }
        public object getScalar(string sql)
        {
            open();
            SqlCommand cmd = new SqlCommand(sql, connect);
            object kq = cmd.ExecuteScalar();
            close();
            return kq;
        }
        public DataTable getDataTable(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, connect);
            da.Fill(dt);
            return dt;
        }
        public int updateDataBasse(string sql, DataTable dt)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, connect);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da);
            int kq = da.Update(dt);
            return kq;
        }    
    }
}
