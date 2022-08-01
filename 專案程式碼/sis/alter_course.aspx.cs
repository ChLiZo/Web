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
    public partial class alter_course : System.Web.UI.Page
    {
        public object[] course_id;
        public object[] course_name;
        public object[] course_teacher;
        public object[] course_time;

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
            ArrayList ci = new ArrayList();
            ArrayList cn = new ArrayList();
            ArrayList ct = new ArrayList();
            ArrayList cti = new ArrayList();

            SqlConnection conc = new SqlConnection();
            String connectionString = "workstation id=oxollldb.mssql.somee.com;packet size=4096;user id=oxolll_SQLLogin_1;pwd=58x8558x85;data source=oxollldb.mssql.somee.com;persist security info=False;initial catalog=oxollldb";
            string sql = @"SELECT [c_id], [c_name], [teacher], [c_time] FROM [course] WHERE [c_id]=@tar";
            SqlCommand mySqlCmd = new SqlCommand(sql, conc);
            mySqlCmd.Parameters.Add("@tar", SqlDbType.NVarChar, 100).Value = tar.ToString();

            conc.ConnectionString = connectionString;
            conc.Open();
            SqlDataReader Reader = mySqlCmd.ExecuteReader();
            while (Reader.Read())
            {
                //dataReader ["欄位名稱"].ToString()    資料庫的資料
                ci.Add(Reader["c_id"].ToString());
                cn.Add(Reader["c_name"].ToString());
                ct.Add(Reader["teacher"].ToString());
                cti.Add(Reader["c_time"].ToString());

            }
            course_id = ci.ToArray();
            course_name = cn.ToArray();
            course_teacher = ct.ToArray();
            course_time = cti.ToArray();
            Reader.Close();
            mySqlCmd.Cancel();
            conc.Close();
            conc.Dispose();
        }

        protected void alter_Click(object sender, EventArgs e)
        {
            string ci = Request.Form["course_id"];
            string cn = Request.Form["course_name"];
            string ct = Request.Form["course_teacher"];
            string cti = Request.Form["course_time"];

            string tar = Request.QueryString["tar"];
            SqlConnection conc = new SqlConnection();
            String connectionString = "workstation id=oxollldb.mssql.somee.com;packet size=4096;user id=oxolll_SQLLogin_1;pwd=58x8558x85;data source=oxollldb.mssql.somee.com;persist security info=False;initial catalog=oxollldb";
            string sql = @"UPDATE [course] SET [c_id]=@ci, [c_name]=@cn, [teacher]=@ct, [c_time]=@cti WHERE [c_id]=@tar";
            SqlCommand mySqlCmd = new SqlCommand(sql, conc);
            mySqlCmd.Parameters.Add("@ci", SqlDbType.NVarChar, 100).Value = ci.ToString();
            mySqlCmd.Parameters.Add("@cn", SqlDbType.NVarChar, 100).Value = cn.ToString();
            mySqlCmd.Parameters.Add("@ct", SqlDbType.NVarChar, 100).Value = ct.ToString();
            mySqlCmd.Parameters.Add("@cti", SqlDbType.NVarChar, 100).Value = cti.ToString();
            mySqlCmd.Parameters.Add("@tar", SqlDbType.NVarChar, 100).Value = tar.ToString();

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