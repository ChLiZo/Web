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
    public partial class Add : System.Web.UI.Page
    {
        public object[] cn;
        public object[] tn;
        public object[] cid;
        public object[] ct;

        public object[] c_name;
        public object[] teacher;
        public object[] c_time;
        public object[] c_id;
        public object[,] schedule = new object[8, 9];
        public object[,] scheduleTeacher = new object[8, 9];
        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList c = new ArrayList();
            ArrayList t = new ArrayList();
            ArrayList i = new ArrayList();
            ArrayList tc = new ArrayList();
            SqlConnection conc = new SqlConnection();
            String connectionString = "workstation id=oxollldb.mssql.somee.com;packet size=4096;user id=oxolll_SQLLogin_1;pwd=58x8558x85;data source=oxollldb.mssql.somee.com;persist security info=False;initial catalog=oxollldb";
            string sql = @"SELECT [c_id], [c_name], [teacher], [c_time] FROM [course]";
            string sql2 = @"SELECT [c_name], [teacher], [c_time], [course].[c_id] FROM [course] INNER JOIN [choose] ON [course].[c_id]=[choose].[c_id]";
            SqlCommand mySqlCmd = new SqlCommand(sql, conc);
            conc.ConnectionString = connectionString;
            conc.Open();
            SqlDataReader Reader = mySqlCmd.ExecuteReader();
            while (Reader.Read())
            {
                //dataReader ["欄位名稱"].ToString()    資料庫的資料
                c.Add(Reader["c_name"].ToString());
                t.Add(Reader["teacher"].ToString());
                i.Add(Reader["c_id"].ToString());
                tc.Add(Reader["c_time"].ToString());
                string ads = null;
                if (i.ToString() == Session["id"].ToString())
                {
                    switch (tc.ToString().Substring(0, 1))
                    {
                        case "1":
                            ads = "(" + "一" + ")" + tc.ToString().Substring(1, 3);
                            break;
                        case "2":
                            ads = "(" + "二" + ")" + tc.ToString().Substring(1, 3);
                            break;
                        case "3":
                            ads = "(" + "三" + ")" + tc.ToString().Substring(1, 3);
                            break;
                        case "4":
                            ads = "(" + "四" + ")" + tc.ToString().Substring(1, 3);
                            break;
                        case "5":
                            ads = "(" + "五" + ")" + tc.ToString().Substring(1, 3);
                            break;
                        case "6":
                            ads = "(" + "六" + ")" + tc.ToString().Substring(1, 3);
                            break;
                        case "7":
                            ads = "(" + "日" + ")" + tc.ToString().Substring(1, 3);
                            break;

                    }
                    tc.Add(ads);
                }
            }
            cid = i.ToArray();
            cn = c.ToArray();
            tn = t.ToArray();
            ct = tc.ToArray();

            Reader.Close();
            mySqlCmd.Cancel();
            SqlCommand mySqlCmd2 = new SqlCommand(sql2, conc);
            SqlDataReader reader2 = mySqlCmd2.ExecuteReader();
            ArrayList cName = new ArrayList();
            ArrayList cTeacher = new ArrayList();
            ArrayList cTime = new ArrayList();
            ArrayList cId = new ArrayList();
            string[,] schedule_temp = new string[8, 9];
            string[,] scheduleTeacher_temp = new string[8, 9];
            string time_temp;
            while (reader2.Read())
            {
                cName.Add(reader2["c_name"].ToString());
                cTeacher.Add(reader2["teacher"].ToString());
                cId.Add(reader2["c_id"].ToString());
                cTime.Add(reader2["c_time"].ToString());
                time_temp = reader2["c_time"].ToString();
                string tp1 = time_temp.Substring(1, 1), tp2 = time_temp.Substring(2, 1), tp3 = time_temp.Substring(3, 1);
                for (int k = 0; k < 8; k++)
                {
                    if (time_temp.Substring(0, 1) == k.ToString())
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            if (tp1 == j.ToString() || tp2 == j.ToString() || tp3 == j.ToString())
                            {
                                schedule_temp[k, j] = reader2["c_name"].ToString();
                                scheduleTeacher_temp[k, j] = reader2["teacher"].ToString();

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
            mySqlCmd2.Cancel();
            conc.Close();
            conc.Dispose();

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

            string ct = @"SELECT [c_time],[id] FROM [course] INNER JOIN [choose] ON [course].[c_id] = [choose].[c_id] WHERE [choose].[id]= @id";
            DataTable dt2 = new DataTable();
            SqlDataAdapter adp2 = new SqlDataAdapter();
            SqlCommand comm2 = new SqlCommand(ct, conn);
            comm2.Parameters.Add("@id", SqlDbType.NVarChar, 100).Value = Session["id"].ToString();
            adp2.SelectCommand = comm2;

            adp2.Fill(dt2);
            adp2.Dispose();
            List<string> list = new List<string>();
            for (var p = 0; p < dt2.Rows.Count; p++)
            {
                list.Add(dt2.Rows[p]["c_time"].ToString());
            }

            foreach (var i in itemList)
            {
                string dup = @"SELECT * FROM [choose] WHERE [id] = " + Session["id"].ToString() + " AND [c_id] = " + i.ToString();
                string st = @"SELECT [c_time] FROM [course] WHERE [c_id] = @c_id";
                DataTable dt1 = new DataTable();
                SqlDataAdapter adp1 = new SqlDataAdapter();
                SqlCommand comm1 = new SqlCommand(st, conn);
                comm1.Parameters.AddWithValue("@c_id", i.ToString());
                adp1.SelectCommand = comm1;

                adp1.Fill(dt1);

                string s1 = dt1.Rows[0]["c_time"].ToString().Substring(0, 1);
                string s2 = dt1.Rows[0]["c_time"].ToString().Substring(1, 1);
                adp1.Dispose();
                SqlCommand ifd = new SqlCommand(dup, conn);
                SqlDataReader f = ifd.ExecuteReader();

                if (!f.Read())
                {
                    f.Close();
                    int co = 0;
                    foreach (var j in list)
                    {

                        Response.Write("j1=" + j.Substring(0, 1) + "<br>" + "j2=" + j.Substring(1, 1) + "<br>");
                        if (s1 == j.Substring(0, 1) && s2 == j.Substring(1, 1))
                        {
                            co++;
                            break;
                        }
                    }
                    if (co == 0)
                    {
                        string cmd = "INSERT INTO [choose]([id],[c_id]) VALUES(@id, @c_id)";
                        using (SqlConnection connection = new SqlConnection(cs))
                        using (SqlCommand command = new SqlCommand(cmd, connection))
                        {
                            command.Parameters.Add("@id", SqlDbType.NVarChar, 100).Value = Session["id"].ToString();
                            command.Parameters.Add("@c_id", SqlDbType.NVarChar, 100).Value = i.ToString();
                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }
                }
                else f.Close();
            }
            conn.Close();
            Response.Redirect("Main.aspx?aa=1");
        }
    }
}