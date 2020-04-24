using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string cs = "server=127.0.0.1;port=3306;user id=root;password=;database=test;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(cs);
            string cmd = "select * from account";
            
            if (conn.State != ConnectionState.Open) conn.Open();
            string id = account.Text;
            string pw = password.Text;
            MySqlCommand result = new MySqlCommand(cmd,conn);
            MySqlDataReader data = result.ExecuteReader();
            while (data.Read())
            {
                if (id == data.GetValue(0).ToString() && pw == data.GetValue(1).ToString())
                {
                    Session["id"] = id;
                    Response.Redirect("Main.aspx");
                    break;
                }
                else error.Text="錯誤的帳號或密碼";
            }
            conn.Close();
        }
    }
}