using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace sis
{
    public partial class Main : System.Web.UI.Page
    {
        public string aa;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null) Response.Redirect("Login.aspx");
            else if (Session["id"].ToString() == "root")
            {
                Response.Redirect("Management.aspx");
            }
            aa = Request.QueryString["aa"];
        }
        [WebMethod]
        public static void Funct()
        {
            HttpContext.Current.Session.RemoveAll();
            HttpContext.Current.Response.Redirect("Login.aspx");
        }
    }
}