using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace sis
{
    public partial class mag_course : System.Web.UI.Page
    {
        public object[] course_name;
        public object[] course_teacher;
        public object[] course_time;
        public object[] course_id;

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
            ArrayList ci = new ArrayList();
            ArrayList cn = new ArrayList();
            ArrayList ct = new ArrayList();
            ArrayList cti = new ArrayList();
            SqlConnection conc = new SqlConnection();
            String connectionString = "workstation id=oxollldb.mssql.somee.com;packet size=4096;user id=oxolll_SQLLogin_1;pwd=58x8558x85;data source=oxollldb.mssql.somee.com;persist security info=False;initial catalog=oxollldb";
            string sql = @"SELECT [c_id], [c_name], [teacher], [c_time] FROM [course]";
            SqlCommand mySqlCmd = new SqlCommand(sql, conc);
            conc.ConnectionString = connectionString;
            conc.Open();
            SqlDataReader Reader = mySqlCmd.ExecuteReader();
            while (Reader.Read())
            {
                //dataReader ["欄位名稱"].ToString()    資料庫的資料
                ci.Add(Reader["c_id"]).ToString();
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
                        target2 = i.ToString().Substring(1, i.Length - 1);

                        break;
                    }
                }
            }
            string cs = "workstation id=oxollldb.mssql.somee.com;packet size=4096;user id=oxolll_SQLLogin_1;pwd=58x8558x85;data source=oxollldb.mssql.somee.com;persist security info=False;initial catalog=oxollldb";
            SqlConnection conn = new SqlConnection(cs);

            string ct = @"DELETE FROM [course] WHERE [c_id] =@c_id ";
            SqlCommand comm1 = new SqlCommand(ct, conn);
            comm1.Parameters.Add("@c_id", SqlDbType.NVarChar, 100).Value = target1.ToString();

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
                Response.Redirect("alter_course.aspx?tar=" + target2.ToString());
            }

            conn.Close();
            conn.Dispose();
            Response.Redirect("mag_course.aspx");
        }

        protected void create_Click(object sender, EventArgs e)
        {
            Response.Redirect("create_course.aspx");
        }
    }
}