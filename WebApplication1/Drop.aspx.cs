using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;

namespace WebApplication1
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        public object[] cn;
        public object[] tn;
        public object[] cid;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = "server=127.0.0.1;port=3306;user id=root;password=;database=test;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(cs);
            string cmd = "select * from course inner join choose on course.c_id=choose.c_id where choose.id="+Session["id"].ToString();
            if (conn.State != ConnectionState.Open) conn.Open();
            MySqlCommand get = new MySqlCommand(cmd, conn);
            MySqlDataReader data = get.ExecuteReader();
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

            conn.Close();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            var items = Request.Form["c_id"];
            var itemList = string.IsNullOrWhiteSpace(items) ? new List<int>() :
                items.Split(',')
                    .Select(it => int.Parse(it))
                    .ToList();

            string cs = "server=127.0.0.1;port=3306;user id=root;password=;database=test;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(cs);
            if (conn.State != ConnectionState.Open) conn.Open();

            foreach (var i in itemList)
            {
                string cmd = "delete from choose where c_id="+i.ToString();
                MySqlCommand del = new MySqlCommand(cmd, conn);
                MySqlDataReader MyRead = del.ExecuteReader();
                MyRead.Close();
            }
            Response.Redirect("Main.aspx");
            conn.Close();
        }
    }
}