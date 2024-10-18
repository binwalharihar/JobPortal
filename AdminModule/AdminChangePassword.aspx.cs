using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace job_portal.AdminModule
{
    public partial class AdminChangePassword : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=HP\\SQLEXPRESS;initial catalog=jobdb;integrated security=true;");
        SqlCommand cmd;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if(txtnp.Text == txtcnp.Text)
            {
                con.Open();
                cmd = new SqlCommand("proc_Admin ", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AdminId", Session["AID"]);
                cmd.Parameters.AddWithValue("@AdminCurrentPassword", txtcp.Text);
                cmd.Parameters.AddWithValue("@AdminNewPassword", txtnp.Text);
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