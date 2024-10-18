using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;


namespace job_portal.JobSeekerModule
{
    public partial class practice : System.Web.UI.Page
    {
       static SqlConnection con = new SqlConnection("data source=HP\\SQLEXPRESS;initial catalog=jobdb;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static void SaveData(string name,int age)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("proc_practice", con);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "INSERT");
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@age", age);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}