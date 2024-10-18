using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace job_portal
{
    public partial class JobSeeker_Registration : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=HP\\SQLEXPRESS;initial catalog=jobdb;integrated security=true");
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSecurityQuestion();
                BindJobProfile();
                BindState();
                BindJobQualifications();
            }
        }

        public void BindSecurityQuestion()
        {
            con.Open();
            cmd = new SqlCommand("select * from tblquestions", con);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlsecurityquestion.DataValueField = "QuestionId";
            ddlsecurityquestion.DataTextField = "QuestionName";
            ddlsecurityquestion.DataSource = dt;
            ddlsecurityquestion.DataBind();
            ddlsecurityquestion.Items.Insert(0, new ListItem("--Select--", "0"));
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

        public void BindJobQualifications()
        {
            con.Open();
            cmd = new SqlCommand("select * from tblQualifications", con);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlqualifications.DataValueField = "QualificationId";
            ddlqualifications.DataTextField = "QualificationName";
            ddlqualifications.DataSource = dt;
            ddlqualifications.DataBind();
            ddlqualifications.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        public void BindState()
        {
            con.Open();
            cmd = new SqlCommand("select * from tblState", con);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlstate.DataValueField = "StateId";
            ddlstate.DataTextField = "StateName";
            ddlstate.DataSource = dt;
            ddlstate.DataBind();
            ddlstate.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        public void BindCity()
        {
            con.Open();
            cmd = new SqlCommand("select * from tblCity where StateId='" + ddlstate.SelectedValue + "'", con);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlcity.DataValueField = "CityId";
            ddlcity.DataTextField = "CityName";
            ddlcity.DataSource = dt;
            ddlcity.DataBind();
            ddlcity.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        public void Reset()
        {
            txtname.Text = "";
            txtemail.Text = "";
            txtdob.Text = "";
            txtcomment.Text = "";
            txtanswer.Text = "";
            txtaddress.Text = "";
            txtmobile.Text = "";
            txtpwd.Text = "";
            ddlcity.SelectedValue = "0";
            ddlexp.SelectedValue = "0";
            ddljobprofile.SelectedValue = "0";
            ddlstate.SelectedValue = "0";
            ddlqualifications.SelectedValue = "0";
            ddlsecurityquestion.SelectedValue = "0";
        }

        protected void btnjobseekersubmit_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select * from tblJobSeeker where JobSeekerEmail='" + txtemail.Text + "'", con);
            da=new SqlDataAdapter(cmd1);
            dt= new DataTable();
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count==0)
            {
                string resumename = DateTime.Now.Ticks.ToString() + Path.GetFileName(furesume.PostedFile.FileName);
                string imagename = DateTime.Now.Ticks.ToString() + Path.GetFileName(fuimage.PostedFile.FileName);

                furesume.SaveAs(Server.MapPath("JobSeekerResume" + "\\" + resumename));
                fuimage.SaveAs(Server.MapPath("JobSeekerImages" + "\\" + imagename));

                con.Open();
                cmd = new SqlCommand("Proc_JobSeeker", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "INSERT");
                cmd.Parameters.AddWithValue("@JobSeekerName", txtname.Text);
                cmd.Parameters.AddWithValue("@JobSeekerEmail", txtemail.Text);
                cmd.Parameters.AddWithValue("@JobSeekerPassword", txtpwd.Text);
                cmd.Parameters.AddWithValue("@JobSeekerGender", rblgender.SelectedValue);
                cmd.Parameters.AddWithValue("@JobSeekerJobProfile", ddljobprofile.SelectedValue);
                cmd.Parameters.AddWithValue("@JobSeekerQualification", ddlqualifications.SelectedValue);
                cmd.Parameters.AddWithValue("@JobSeekerState", ddlstate.SelectedValue);
                cmd.Parameters.AddWithValue("@JobSeekerCity", ddlcity.SelectedValue);
                cmd.Parameters.AddWithValue("@JobSeekerAddress", txtaddress.Text);
                cmd.Parameters.AddWithValue("@JobSeekerMobile", txtmobile.Text);
                cmd.Parameters.AddWithValue("@JobSeekerDOB", txtdob.Text);
                cmd.Parameters.AddWithValue("@JobSeekerExp", ddlexp.SelectedValue);
                cmd.Parameters.AddWithValue("@JobSeekerComments", txtaddress.Text);
                cmd.Parameters.AddWithValue("@JobSeekerAnswer", txtmobile.Text);
                cmd.Parameters.AddWithValue("@JobSeekerQuestion", ddlsecurityquestion.SelectedValue);
                cmd.Parameters.AddWithValue("@JobSeekerResume", resumename);
                cmd.Parameters.AddWithValue("@JobSeekerImage", imagename);
                cmd.ExecuteNonQuery();
                con.Close();
                Reset();
            }
            else
            {
                lblmsg.Text = "this email already exists !!";
            }
            
        }

        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCity();
        }
    }
}