using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace sis
{
    public partial class create_user : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (Session["id"].ToString() == "root")
            {

            }
            else Response.Redirect("Login.aspx");
        }
        protected void create_Click(object sender, EventArgs e)
        {
            string ac = Request.Form["account"];
            string pwd = Request.Form["password"];
            SqlConnection conc = new SqlConnection();
            String connectionString = "workstation id=oxollldb.mssql.somee.com;packet size=4096;user id=oxolll_SQLLogin_1;pwd=58x8558x85;data source=oxollldb.mssql.somee.com;persist security info=False;initial catalog=oxollldb";
            string sql = @"INSERT INTO [account] ([id], [password]) VALUES(@ac, @pwd)";
            string sql2 = @"INSERT INTO [profile] ([id]) VALUES(@ac)";
            SqlCommand mySqlCmd = new SqlCommand(sql, conc);
            SqlCommand mySqlCmd2 = new SqlCommand(sql2, conc);
            mySqlCmd.Parameters.Add("@ac", SqlDbType.NVarChar, 100).Value = ac.ToString();
            mySqlCmd.Parameters.Add("@pwd", SqlDbType.NVarChar, 100).Value = pwd.ToString();
            mySqlCmd2.Parameters.Add("@ac", SqlDbType.NVarChar, 100).Value = ac.ToString();

            conc.ConnectionString = connectionString;
            conc.Open();
            SqlDataReader Reader = mySqlCmd.ExecuteReader();
            Reader.Read();
            Reader.Close();
            mySqlCmd.Cancel();
            mySqlCmd2.ExecuteNonQuery();
            mySqlCmd2.Cancel();
            conc.Close();
            conc.Dispose();
            Response.Redirect("mag_user.aspx");
        }
    }
}