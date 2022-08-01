using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace sis
{
    public partial class alter_user : System.Web.UI.Page
    {
        public object[] account;
        public object[] password;

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
            string tar = Request.QueryString["tar"];
            ArrayList ac = new ArrayList();
            ArrayList pwd = new ArrayList();
            SqlConnection conc = new SqlConnection();
            String connectionString = "workstation id=oxollldb.mssql.somee.com;packet size=4096;user id=oxolll_SQLLogin_1;pwd=58x8558x85;data source=oxollldb.mssql.somee.com;persist security info=False;initial catalog=oxollldb";
            string sql = @"SELECT [id], [password] FROM [account] WHERE [id]=@tar";
            SqlCommand mySqlCmd = new SqlCommand(sql, conc);
            mySqlCmd.Parameters.Add("@tar", SqlDbType.NVarChar, 100).Value = tar.ToString();

            conc.ConnectionString = connectionString;
            conc.Open();
            SqlDataReader Reader = mySqlCmd.ExecuteReader();
            while (Reader.Read())
            {
                //dataReader ["欄位名稱"].ToString()    資料庫的資料
                ac.Add(Reader["id"].ToString());
                pwd.Add(Reader["password"].ToString());

            }
            account = ac.ToArray();
            password = pwd.ToArray();
            Reader.Close();
            mySqlCmd.Cancel();
            conc.Close();
            conc.Dispose();
        }
        protected void alter_Click(object sender, EventArgs e)
        {
            string ac = Request.Form["account"];
            string pwd = Request.Form["password"];
            string tar = Request.QueryString["tar"];
            SqlConnection conc = new SqlConnection();
            String connectionString = "workstation id=oxollldb.mssql.somee.com;packet size=4096;user id=oxolll_SQLLogin_1;pwd=58x8558x85;data source=oxollldb.mssql.somee.com;persist security info=False;initial catalog=oxollldb";
            string sql = @"UPDATE [account] SET [id]=@ac, [password]=@pwd WHERE [id]=@tar";
            SqlCommand mySqlCmd = new SqlCommand(sql, conc);
            mySqlCmd.Parameters.Add("@ac", SqlDbType.NVarChar, 100).Value = ac.ToString();
            mySqlCmd.Parameters.Add("@pwd", SqlDbType.NVarChar, 100).Value = pwd.ToString();
            mySqlCmd.Parameters.Add("@tar", SqlDbType.NVarChar, 100).Value = tar.ToString();

            conc.ConnectionString = connectionString;
            conc.Open();
            SqlDataReader Reader = mySqlCmd.ExecuteReader();
            Reader.Read();
            Reader.Close();
            mySqlCmd.Cancel();
            conc.Close();
            conc.Dispose();
            Response.Redirect("mag_user.aspx");
        }
    }
}