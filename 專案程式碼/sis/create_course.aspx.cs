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
    public partial class create_course : System.Web.UI.Page
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
            string ci = Request.Form["course_id"];
            string cn = Request.Form["course_name"];
            string ct = Request.Form["course_teacher"];
            string cti = Request.Form["course_time"];

            SqlConnection conc = new SqlConnection();
            String connectionString = "workstation id=oxollldb.mssql.somee.com;packet size=4096;user id=oxolll_SQLLogin_1;pwd=58x8558x85;data source=oxollldb.mssql.somee.com;persist security info=False;initial catalog=oxollldb";
            string sql = @"INSERT INTO [course] ([c_id], [c_name], [teacher], [c_time]) VALUES(@ci, @cn, @ct, @cti)";
            SqlCommand mySqlCmd = new SqlCommand(sql, conc);
            mySqlCmd.Parameters.Add("@ci", SqlDbType.NVarChar, 100).Value = ci.ToString();
            mySqlCmd.Parameters.Add("@cn", SqlDbType.NVarChar, 100).Value = cn.ToString();
            mySqlCmd.Parameters.Add("@ct", SqlDbType.NVarChar, 100).Value = ct.ToString();
            mySqlCmd.Parameters.Add("@cti", SqlDbType.NVarChar, 100).Value = cti.ToString();

            conc.ConnectionString = connectionString;
            conc.Open();
            SqlDataReader Reader = mySqlCmd.ExecuteReader();
            Reader.Read();
            Reader.Close();
            mySqlCmd.Cancel();
            conc.Close();
            conc.Dispose();
            Response.Redirect("mag_course.aspx");
        }
    }
}