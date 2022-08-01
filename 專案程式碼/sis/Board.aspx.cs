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
    public partial class Board : System.Web.UI.Page
    {
        public object[] newsId;
        public object[] title;
        public object[] unit;
        public object[] date;
        protected void Page_Load(object sender, EventArgs e)
        {
            string connstr = "workstation id=oxollldb.mssql.somee.com;packet size=4096;user id=oxolll_SQLLogin_1;pwd=58x8558x85;data source=oxollldb.mssql.somee.com;persist security info=False;initial catalog=oxollldb";
            SqlConnection connect = new SqlConnection(connstr);
            string command = "SELECT id,title,unit,CONVERT (CHAR , date , 111) as date FROM news order by date DESC";

            connect.Open();
            SqlCommand cmd = new SqlCommand(command, connect);
            SqlDataReader reader = cmd.ExecuteReader();

            ArrayList id_temp = new ArrayList();
            ArrayList title_temp = new ArrayList();
            ArrayList unit_temp = new ArrayList();
            ArrayList date_temp = new ArrayList();

            while (reader.Read())
            {
                id_temp.Add(reader["id"].ToString());
                title_temp.Add(reader["title"].ToString());
                unit_temp.Add(reader["unit"].ToString());
                date_temp.Add(reader["date"].ToString());
            }
            newsId = id_temp.ToArray();
            title = title_temp.ToArray();
            unit = unit_temp.ToArray();
            date = date_temp.ToArray();

            reader.Close();
            connect.Close();
        }
    }
}