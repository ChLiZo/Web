using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections;
namespace sis
{
    public partial class Drop : System.Web.UI.Page
    {
        public object[] cn;
        public object[] tn;
        public object[] cid;

        public object[] c_name;
        public object[] teacher;
        public object[] c_time;
        public object[] c_id;
        public object[,] schedule = new object[8, 9];
        public object[,] scheduleTeacher = new object[8, 9];
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = "workstation id=oxollldb.mssql.somee.com;packet size=4096;user id=oxolll_SQLLogin_1;pwd=58x8558x85;data source=oxollldb.mssql.somee.com;persist security info=False;initial catalog=oxollldb";
            SqlConnection conn = new SqlConnection(cs);
            string cmd = "SELECT * FROM [course] INNER JOIN [choose] ON [course].[c_id]=[choose].[c_id] WHERE [choose].[id]=@id";
            conn.Open();
            SqlCommand get = new SqlCommand(cmd, conn);
            get.Parameters.AddWithValue("@id", Session["id"].ToString());
            SqlDataReader data = get.ExecuteReader();
            ArrayList c = new ArrayList();
            ArrayList t = new ArrayList();
            ArrayList i = new ArrayList();
            while (data.Read())
            {
                i.Add(data.GetValue(0));
                c.Add(data.GetValue(1));
                t.Add(data.GetValue(2));
            }
            cid = i.ToArray();
            cn = c.ToArray();
            tn = t.ToArray();

            data.Close();
            string sql = @"SELECT [course].[c_name], [course].[teacher], [course].[c_time], [course].[c_id] FROM [course] INNER JOIN [choose] ON [course].[c_id]=[choose].[c_id] WHERE [choose].[id]=@id ORDER BY [c_id]";
            SqlCommand mySqlCmd = new SqlCommand(sql, conn);
            mySqlCmd.Parameters.AddWithValue("@id", Session["id"].ToString());
            SqlDataReader reader = mySqlCmd.ExecuteReader();
            ArrayList cName = new ArrayList();
            ArrayList cTeacher = new ArrayList();
            ArrayList cTime = new ArrayList();
            ArrayList cId = new ArrayList();
            string[,] schedule_temp = new string[8, 9];
            string[,] scheduleTeacher_temp = new string[8, 9];
            string time_temp;
            while (reader.Read())
            {
                cName.Add(reader["c_name"].ToString());
                cTeacher.Add(reader["teacher"].ToString());
                cId.Add(reader["c_id"].ToString());
                cTime.Add(reader["c_time"].ToString());
                time_temp = reader["c_time"].ToString();
                string tp1 = time_temp.Substring(1, 1), tp2 = time_temp.Substring(2, 1), tp3 = time_temp.Substring(3, 1);
                for (int k = 0; k < 8; k++)
                {
                    if (time_temp.Substring(0, 1) == k.ToString())
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            if (tp1 == j.ToString() || tp2 == j.ToString() || tp3 == j.ToString())
                            {
                                schedule_temp[k, j] = reader["c_name"].ToString();
                                scheduleTeacher_temp[k, j] = reader["teacher"].ToString();

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
            reader.Close();
            conn.Close();
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            var items = Request.Form["c_id"];
            var itemList = string.IsNullOrWhiteSpace(items) ? new List<int>() :
                items.Split(',')
                    .Select(it => int.Parse(it))
                    .ToList();

            string cs = "workstation id=oxollldb.mssql.somee.com;packet size=4096;user id=oxolll_SQLLogin_1;pwd=58x8558x85;data source=oxollldb.mssql.somee.com;persist security info=False;initial catalog=oxollldb";
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();

            foreach (var i in itemList)
            {
                string cmd = "DELETE FROM [choose] WHERE [c_id]=" + i.ToString();
                SqlCommand del = new SqlCommand(cmd, conn);
                SqlDataReader MyRead = del.ExecuteReader();
                MyRead.Close();
            }
            Response.Redirect("Main.aspx?aa=2");
            conn.Close();
        }
    }
}