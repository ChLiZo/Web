using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace sis
{
    public partial class Management : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (Session["id"].ToString() == "root")
            {

            }
            else Response.Redirect("Login.aspx");
        }
        protected void mag_user_Click(object sender, EventArgs e)
        {
            Response.Redirect("mag_user.aspx");
        }

        protected void mag_course_Click(object sender, EventArgs e)
        {
            Response.Redirect("mag_course.aspx");
        }

        [WebMethod]
        public static void Funct()
        {
            HttpContext.Current.Session.RemoveAll();
            HttpContext.Current.Response.Redirect("Login.aspx");
        }
    }
}