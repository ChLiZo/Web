using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace sis
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null) Response.Redirect("Main.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = account.Value;
            string pw = password.Value;
            DataView dataView = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            if (dataView.Count >= 1)
            {
                for (int j = 0; j < dataView.Count; j++)
                {
                    if (dataView[j][0].ToString() == id && dataView[j][1].ToString() == pw)
                    {
                        Session["id"] = id;
                        dataView.Dispose();
                        Response.Redirect("Main.aspx");
                    }
                    else error.Text = "錯誤的帳號或密碼";
                }
            }
        }
    }
}