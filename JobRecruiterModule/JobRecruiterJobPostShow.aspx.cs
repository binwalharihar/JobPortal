using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace job_portal.JobRecruiterModule
{
    public partial class ListofJob : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=HP\\SQLEXPRESS;initial catalog=jobdb;integrated security=true");
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindJobPost();
            }
        }
        public void BindJobPost()
        {
            con.Open();
            cmd = new SqlCommand("proc_JobPost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "JOINJOBPOST");
            cmd.Parameters.AddWithValue("@JobRecruiterId", Session["RSID"]);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gvjobpost.DataSource = dt;
            gvjobpost.DataBind();
        }

        protected void gvjobpost_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "A")
            {
                con.Open();
                cmd = new SqlCommand("proc_JobPost", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "DELETE");
                cmd.Parameters.AddWithValue("@JobPostId", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                BindJobPost();
            }else if (e.CommandName == "B")
            {
                Response.Redirect("PostNewJobs.aspx?pp="+e.CommandArgument);
            }
        }
    }
}