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
    public partial class mag_user : System.Web.UI.Page
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
            ArrayList ac = new ArrayList();
            ArrayList pwd = new ArrayList();
            SqlConnection conc = new SqlConnection();
            String connectionString = "workstation id=oxollldb.mssql.somee.com;packet size=4096;user id=oxolll_SQLLogin_1;pwd=58x8558x85;data source=oxollldb.mssql.somee.com;persist security info=False;initial catalog=oxollldb";
            string sql = @"SELECT [id], [password] FROM [account]";
            SqlCommand mySqlCmd = new SqlCommand(sql, conc);
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
        protected void sure_Click(object sender, EventArgs e)
        {
            var delete = Request.Form["delete"];
            string target1 = "";
            var alter = Request.Form["alter"];
            string target2 = "";

            if (delete != null)
            {
                foreach (var i in delete.Split(',').ToList())
                {
                    if (i.ToString().Substring(0, 1) == "b")
                    {
                        target1 = i.ToString().Substring(1, i.ToString().Length - 1);

                        break;
                    }
                }
            }


            if (alter != null)
            {
                foreach (var i in alter.Split(',').ToList())
                {
                    if (i.ToString().Substring(0, 1) == "c")
                    {
                        target2 = i.ToString().Substring(1, i.ToString().Length - 1);

                        break;
                    }
                }
            }
            string cs = "workstation id=oxollldb.mssql.somee.com;packet size=4096;user id=oxolll_SQLLogin_1;pwd=58x8558x85;data source=oxollldb.mssql.somee.com;persist security info=False;initial catalog=oxollldb";
            SqlConnection conn = new SqlConnection(cs);

            string ct = @"DELETE FROM [account] WHERE [id] =@id ";
            SqlCommand comm1 = new SqlCommand(ct, conn);
            comm1.Parameters.Add("@id", SqlDbType.NVarChar, 100).Value = target1.ToString();

            if (target1 != "")
            {
                conn.Open();
                SqlDataReader Reader = comm1.ExecuteReader();
                Reader.Read();
                Reader.Close();
                comm1.Cancel();
            }
            if (target2 != "")
            {
                conn.Close();
                conn.Dispose();
                Response.Redirect("alter_user.aspx?tar=" + target2.ToString());
            }

            conn.Close();
            conn.Dispose();
            Response.Redirect("mag_user.aspx");
        }

        protected void create_Click(object sender, EventArgs e)
        {
            Response.Redirect("create_user.aspx");
        }
    }
}