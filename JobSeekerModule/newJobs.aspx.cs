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
    public partial class newJobs : System.Web.UI.Page
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
                BindJobProfile();
            }
        }

        public void BindJobProfile()
        {
            con.Open();
            cmd = new SqlCommand("select * from tblJobProfile", con);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddljobprofile.DataValueField = "JobProfileId";
            ddljobprofile.DataTextField = "JobProfileName";
            ddljobprofile.DataSource = dt;
            ddljobprofile.DataBind();
            ddljobprofile.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        public void BindJobPost()
        {
            con.Open();
            cmd = new SqlCommand("proc_JobPost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "JOINJOBPOSTADMIN");
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gvjobpost.DataSource = dt;
            gvjobpost.DataBind();
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("proc_JobPost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "JOBPOSTSEARCH");
            cmd.Parameters.AddWithValue("@JobPostJobProfileId", ddljobprofile.SelectedValue);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gvjobpost.DataSource = dt;
            gvjobpost.DataBind();
        }
    }
}