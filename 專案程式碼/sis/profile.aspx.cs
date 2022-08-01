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
    public partial class profile : System.Web.UI.Page
    {
        public string _name;
        public string _grade;
        public string _sex;
        public string _email;
        public string _phone;
        public string _birth;

        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = "workstation id=oxollldb.mssql.somee.com;packet size=4096;user id=oxolll_SQLLogin_1;pwd=58x8558x85;data source=oxollldb.mssql.somee.com;persist security info=False;initial catalog=oxollldb";
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();
            string cmd = @"SELECT * FROM [profile] WHERE id=@id";
            SqlCommand sqlCommand = new SqlCommand(cmd, conn);
            sqlCommand.Parameters.Add("@id", SqlDbType.NVarChar, 100).Value = Session["id"];
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                _name = sqlDataReader["name"].ToString();
                _grade = sqlDataReader["grade"].ToString();
                _sex = sqlDataReader["sex"].ToString();
                _email = sqlDataReader["email"].ToString();
                _phone = sqlDataReader["phone"].ToString();
                _birth = sqlDataReader["birth"].ToString();
            }
            conn.Close();
        }
        protected void sure_Click(object sender, EventArgs e)
        {
            var name = Request.Form["name"];
            var grade = Request.Form["grade"];
            var sex = Request.Form["sex"];
            var id = Session["id"].ToString();
            var email = Request.Form["email"];
            var phone = Request.Form["phone"];
            var birth = Request.Form["birth"];

            string cs = "workstation id=oxollldb.mssql.somee.com;packet size=4096;user id=oxolll_SQLLogin_1;pwd=58x8558x85;data source=oxollldb.mssql.somee.com;persist security info=False;initial catalog=oxollldb";
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();

            string cmd = @"UPDATE [profile] SET [name]=@name,[grade]=@grade,[sex]=@sex,[email]=@email,[phone]=@phone,[birth]=@birth WHERE [id]=@id";
            SqlCommand sqlCommand = new SqlCommand(cmd, conn);
            sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = name;
            sqlCommand.Parameters.Add("@grade", SqlDbType.NVarChar, 100).Value = grade;
            sqlCommand.Parameters.Add("@sex", SqlDbType.NVarChar, 100).Value = sex;
            sqlCommand.Parameters.Add("@id", SqlDbType.NVarChar, 100).Value = id;
            sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar, 100).Value = email;
            sqlCommand.Parameters.Add("@phone", SqlDbType.NVarChar, 100).Value = phone;
            sqlCommand.Parameters.Add("@birth", SqlDbType.NVarChar, 100).Value = birth;
            SqlDataReader Reader = sqlCommand.ExecuteReader();
            Reader.Read();
            Reader.Close();
            sqlCommand.Cancel();
            conn.Close();
            conn.Dispose();
            Response.Redirect("Main.aspx");
        }

        protected override object LoadPageStateFromPersistenceMedium()
        {
            return null;
        }

        protected override void SavePageStateToPersistenceMedium(object viewstate)
        {

        }

    }
}