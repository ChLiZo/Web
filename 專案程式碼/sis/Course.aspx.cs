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
    public partial class Course : System.Web.UI.Page
    {
        public object[] c_name;
        public object[] teacher;
        public object[] c_time;
        public object[] c_id;
        public object[,] schedule = new object[8, 9];
        public object[,] scheduleTeacher = new object[8, 9];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null) Response.Redirect("Login.aspx");

            SqlConnection conc = new SqlConnection();
            String connectionString = "workstation id=oxollldb.mssql.somee.com;packet size=4096;user id=oxolll_SQLLogin_1;pwd=58x8558x85;data source=oxollldb.mssql.somee.com;persist security info=False;initial catalog=oxollldb";
            string sql = @"SELECT [course].[c_name], [course].[teacher], [course].[c_time], [course].[c_id] FROM [course] INNER JOIN [choose] ON [course].[c_id]=[choose].[c_id] WHERE [choose].[id]=@id ORDER BY [c_id]";
            conc.ConnectionString = connectionString;
            conc.Open();
            SqlCommand mySqlCmd = new SqlCommand(sql, conc);
            mySqlCmd.Parameters.AddWithValue("@id", Session["id"].ToString());
            SqlDataReader Reader = mySqlCmd.ExecuteReader();
            ArrayList cName = new ArrayList();
            ArrayList cTeacher = new ArrayList();
            ArrayList cTime = new ArrayList();
            ArrayList cId = new ArrayList();
            string[,] schedule_temp = new string[8, 9];
            string[,] scheduleTeacher_temp = new string[8, 9];
            string time_temp;
            while (Reader.Read())
            {
                cName.Add(Reader["c_name"].ToString());
                cTeacher.Add(Reader["teacher"].ToString());
                cId.Add(Reader["c_id"].ToString());
                cTime.Add(Reader["c_time"].ToString());
                time_temp = Reader["c_time"].ToString();
                string tp1 = time_temp.Substring(1, 1), tp2 = time_temp.Substring(2, 1), tp3 = time_temp.Substring(3, 1);
                for (int i = 0; i < 8; i++)
                {
                    if (time_temp.Substring(0, 1) == i.ToString())
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            if (tp1 == j.ToString() || tp2 == j.ToString() || tp3 == j.ToString())
                            {
                                schedule_temp[i, j] = Reader["c_name"].ToString();
                                scheduleTeacher_temp[i, j] = Reader["teacher"].ToString();

                            }
                        }
                    }
                }

            }
            c_name = cName.ToArray();
            teacher = cTeacher.ToArray();
            c_time = cTime.ToArray();
            c_id = cId.ToArray();
            schedule = schedule_temp;
            scheduleTeacher = scheduleTeacher_temp;

            Reader.Close();
            conc.Close();
        }
    }
}