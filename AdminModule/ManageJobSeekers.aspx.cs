using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace job_portal.AdminModule
{
    public partial class ManageJobSeekers : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=HP\\SQLEXPRESS;initial catalog=jobdb;integrated security=true");
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSeekers();
            }
        }
        void BindSeekers()
        {
            con.Open();
            cmd = new SqlCommand("Proc_JobSeeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "JobSeekerJoin");
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gvSek.DataSource = dt;
            gvSek.DataBind();
        }

        protected void gvSek_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "A")
            {
                con.Open();
                cmd = new SqlCommand("Proc_JobSeeker", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "JobSeekerBlock");
                cmd.Parameters.AddWithValue("@JobSeekerId", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            BindSeekers();
        }
    }
}