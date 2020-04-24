using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;

public partial class Default2 : System.Web.UI.Page
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
        MySqlConnection conn = new MySqlConnection("server = localhost; User Id =root; password=; database = test;charset=utf8");
        string SQL = "SELECT course.c_name, course.teacher, course.c_time, course.c_id FROM course INNER JOIN choose ON course.c_id=choose.c_id WHERE choose.id=" + Session["id"] + " order by c_id";
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(SQL, conn);
        MySqlDataReader reader = cmd.ExecuteReader();
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
            for (int i = 0; i < 8; i++)
            {
                if (time_temp.Substring(0, 1) == i.ToString())
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (tp1 == j.ToString() || tp2 == j.ToString() || tp3 == j.ToString())
                        {
                            schedule_temp[i, j] = reader["c_name"].ToString();
                            scheduleTeacher_temp[i, j] = reader["teacher"].ToString();

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
}
