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
    public partial class Search : System.Web.UI.Page
    {
        public List<string> list = new List<string>();

        public object[] cn;
        public object[] tn;
        public object[] cid;
        public object[] ct;
        public object[] cnt;

        ArrayList c = new ArrayList();
        ArrayList t = new ArrayList();
        ArrayList i = new ArrayList();
        ArrayList tc = new ArrayList();
        ArrayList tnc = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null) Response.Redirect("Login.aspx");

            string cs = "workstation id=oxollldb.mssql.somee.com;packet size=4096;user id=oxolll_SQLLogin_1;pwd=58x8558x85;data source=oxollldb.mssql.somee.com;persist security info=False;initial catalog=oxollldb";
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();

            string cmd1 = @"SELECT DISTINCT [teacher] FROM [course]";
            DataTable dataTable1 = new DataTable();
            SqlCommand sqlCommand1 = new SqlCommand(cmd1, conn);
            SqlDataAdapter adp1 = new SqlDataAdapter();
            adp1.SelectCommand = sqlCommand1;
            adp1.Fill(dataTable1);
            adp1.Dispose();
            for (var p = 0; p < dataTable1.Rows.Count; p++)
            {
                list.Add(dataTable1.Rows[p]["teacher"].ToString());
            }

            string cmd2 = @"SELECT * FROM [course]";
            SqlCommand sqlCommand2 = new SqlCommand(cmd2, conn);
            SqlDataReader sdr = sqlCommand2.ExecuteReader();
            while (sdr.Read())
            {
                c.Add(sdr["c_name"].ToString());
                t.Add(sdr["teacher"].ToString());
                i.Add(sdr["c_id"].ToString());
                tc.Add(sdr["c_time"].ToString());
                string ads = null;
                var ntm = sdr["c_time"].ToString();
                switch (ntm.Substring(0, 1))
                {
                    case "1":
                        ads = "(" + "一" + ")" + ntm.Substring(1, 3) + "節";
                        break;
                    case "2":
                        ads = "(" + "二" + ")" + ntm.Substring(1, 3) + "節";
                        break;
                    case "3":
                        ads = "(" + "三" + ")" + ntm.Substring(1, 3) + "節";
                        break;
                    case "4":
                        ads = "(" + "四" + ")" + ntm.Substring(1, 3) + "節";
                        break;
                    case "5":
                        ads = "(" + "五" + ")" + ntm.Substring(1, 3) + "節";
                        break;
                    case "6":
                        ads = "(" + "六" + ")" + ntm.Substring(1, 3) + "節";
                        break;
                    case "7":
                        ads = "(" + "日" + ")" + ntm.Substring(1, 3) + "節";
                        break;
                }

                tnc.Add(ads);
            }
            cid = i.ToArray();
            cn = c.ToArray();
            tn = t.ToArray();
            ct = tc.ToArray();
            cnt = tnc.ToArray();
        }
    }
}