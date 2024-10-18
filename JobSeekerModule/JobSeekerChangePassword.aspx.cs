using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace job_portal.JobSeekerModule
{
    public partial class JobSeekerChangePassword : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=HP\\SQLEXPRESS;initial catalog=jobdb;integrated security=true");
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btncp_Click(object sender, EventArgs e)
        {
            if (txtnp.Text == txtcnp.Text)
            {
                con.Open();
                cmd = new SqlCommand("proc_JobSeeker", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "CP");
                cmd.Parameters.AddWithValue("@JobSeekerId", Session["JSID"]);
                cmd.Parameters.AddWithValue("@JobSeekerNewPassword", txtnp.Text);
                cmd.Parameters.AddWithValue("@JobSeekerCurrentPassword", txtcp.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                lblmsg.Text = "Password has been changed successfully !!";
            }
            else
            {
                lblmsg.Text = "Password do not match!!";
            }
        }
    }
}