using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;      

namespace HczWindowsDataBaseExp
{
    class Database
    {	
		//定义数据库连接配置
        private string MySqlCon = "Data Source=127.0.0.1;Initial Catalog=xiaohe;Integrated Security=True";  
		
		//数据库查询函数
        public DataTable ExecuteQuery(string sqlStr)   
        {
            SqlConnection con = new SqlConnection(@MySqlCon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlStr;
            DataTable dt = new DataTable();
            SqlDataAdapter msda;
            msda = new SqlDataAdapter(cmd);
            msda.Fill(dt);
            con.Close();
            return dt;
        }
		
		//数据库更新函数
        public int ExecuteUpdate(string sqlStr)
        {
            SqlConnection con = new SqlConnection(@MySqlCon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlStr;
            int iud = 0;
            iud = cmd.ExecuteNonQuery();
            con.Close();
            return iud;
        }
    }
}
