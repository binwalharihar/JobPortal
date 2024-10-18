using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace job_portal
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=HP\\SQLEXPRESS;initial catalog=jobdb;integrated security=true");
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            if (ddlusertype.SelectedValue == "1")
            {
                con.Open();
                cmd = new SqlCommand("select * from tblAdmin where AdminEmail='" + txtemail.Text + "'and AdminPassword='" + txtpwd.Text + "'", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count == 0)
                {
                    lblmsg.Text = "Login failed !!";
                }
                else
                {
                    Session["AID"] = dt.Rows[0]["AdminId"];
                    Response.Redirect("~/AdminModule/AdminHome.aspx");
                }

            }
            else if (ddlusertype.SelectedValue == "2")
            {
                con.Open();
                cmd = new SqlCommand("select * from tblJobSeeker where JobSeekerEmail='" + txtemail.Text + "'and JobSeekerPassword='"+txtpwd.Text+"' and JobSeekerStatus=0", con);
                da = new SqlDataAdapter(cmd);
                dt= new DataTable();
                da.Fill(dt);
                con.Close();
                if(dt.Rows.Count == 0)
                {
                    lblmsg.Text="Login failed !!";
                }
                else
                {
                    Session["JSID"] = dt.Rows[0]["JobSeekerId"];
                    Response.Redirect("~/JobSeekerModule/JobSeekerHome.aspx");
                }
            }
            else if (ddlusertype.SelectedValue == "3")
            {
                con.Open();
                cmd = new SqlCommand("select * from tblJobRecruiter where JobRecruiterEmail='" + txtemail.Text + "'and JobRecruiterPassword='" + txtpwd.Text + "'and JobRecruiterStatus=0", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count == 0)
                {
                    lblmsg.Text = "Login failed !!";
                }
                else
                {
                    Session["RSID"] = dt.Rows[0]["JobRecruiterId"];
                    Response.Redirect("~/JobRecruiterModule/JobRecruiterHome.aspx");
                }
            }
        }
    }
}