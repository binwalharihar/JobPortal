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
    public partial class ManageJobRecruiters : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=HP\\SQLEXPRESS;initial catalog=jobdb;integrated security=true;");
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRecruiters();
            }
        }
        void BindRecruiters()
        {
            con.Open();
            cmd = new SqlCommand("proc_JobRecruiter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "JOINRECRUITERS");
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gvRec.DataSource = dt;
            gvRec.DataBind();
        }

        protected void gvRec_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "A")
            {
                con.Open();
                cmd = new SqlCommand("Proc_JobRecruiter", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "JobRecruiterBlock");
                cmd.Parameters.AddWithValue("@JobRecruiterId", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            BindRecruiters();
        }
    }
}