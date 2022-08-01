using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections;
using System.Web.Services;
using System.Data;

namespace sis
{
    public partial class news : System.Web.UI.Page
    {
        public object[] cmt_userId;
        public object[] cmt_text;
        public object[] cmt_date;
        public string news_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string connstr = "workstation id=oxollldb.mssql.somee.com;packet size=4096;user id=oxolll_SQLLogin_1;pwd=58x8558x85;data source=oxollldb.mssql.somee.com;persist security info=False;initial catalog=oxollldb";
            SqlConnection connect = new SqlConnection(connstr);
            string command = "SELECT id,title,text,unit,CONVERT (CHAR , date , 111) as date FROM news where id=" + id;
            connect.Open();
            SqlCommand cmd = new SqlCommand(command, connect);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                title.InnerText = reader["title"].ToString();
                text.InnerText = reader["text"].ToString();
                date.InnerText = reader["date"].ToString();
                unit.InnerText = reader["unit"].ToString();
            }
            reader.Close();
            /*comment news_id	user_id	text	date	exist*/
            ArrayList userid_temp = new ArrayList();
            ArrayList text_temp = new ArrayList();
            ArrayList date_temp = new ArrayList();
            string comment = "select user_id,text,exist, date from comment where news_id=" + id + "order by date";
            SqlCommand cmt_cmd = new SqlCommand(comment, connect);
            SqlDataReader cmt_reader = cmt_cmd.ExecuteReader();

            while (cmt_reader.Read())
            {
                userid_temp.Add(cmt_reader["user_id"].ToString());
                if (cmt_reader["exist"].ToString() == "1")
                {
                    text_temp.Add(cmt_reader["text"].ToString());
                }
                else if (cmt_reader["exist"].ToString() == "0")
                {
                    text_temp.Add("此評論已刪除");
                }
                date_temp.Add(cmt_reader["date"].ToString());
            }
            cmt_userId = userid_temp.ToArray();
            cmt_text = text_temp.ToArray();
            cmt_date = date_temp.ToArray();

            news_id = id;

            cmt_reader.Close();
            connect.Close();
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            string connstr = "workstation id=oxollldb.mssql.somee.com;packet size=4096;user id=oxolll_SQLLogin_1;pwd=58x8558x85;data source=oxollldb.mssql.somee.com;persist security info=False;initial catalog=oxollldb";
            SqlConnection connect = new SqlConnection(connstr);
            connect.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "INSERT INTO [comment]([news_id], [user_id], [text], [date], [exist]) VALUES(@id,@uid,@input,@date,@exist)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", news_id);
            cmd.Parameters.AddWithValue("@uid", Session["id"].ToString());
            cmd.Parameters.AddWithValue("@input", input.InnerText);
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            cmd.Parameters.AddWithValue("@exist", "1");
            cmd.ExecuteNonQuery();
            connect.Close();
            Response.Redirect("news.aspx?id=" + news_id);
        }
    }
}