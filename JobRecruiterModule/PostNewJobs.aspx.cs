using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace job_portal.JobRecruiterModule
{
    public partial class PostNewJobs : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=HP\\SQLEXPRESS;initial catalog=jobdb;integrated security=true");
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindJobProfile();
                BindJobQualifications();
            }
            if(Request.QueryString["pp"]!=null&& Request.QueryString["pp"].ToString()!="")
            {
                if (!IsPostBack)
                {
                    con.Open();
                    cmd = new SqlCommand("proc_JobPost", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@action", "EDIT");
                    cmd.Parameters.AddWithValue("@JobPostId", Request.QueryString["pp"]);
                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                    con.Close();
                    ddljobprofile.SelectedValue = dt.Rows[0]["JobPostJobProfileId"].ToString();
                    ddljobmode.SelectedValue = dt.Rows[0]["JobPostMode"].ToString();
                    rblgender.SelectedValue = dt.Rows[0]["JobPostGender"].ToString();
                   string[]arr = dt.Rows[0]["JobPostQualifications"].ToString().Split(',');
                    for(int i = 0; i <cblqualification.Items.Count; i++)
                    {
                        for(int j = 0; j < arr.Length; j++)
                        {
                            if (cblqualification.Items[i].Text == arr[j])
                            {
                                cblqualification.Items[i].Selected = true;
                            }
                        }
                    }
                    txtminexp.Text = dt.Rows[0]["JobPostMinExp"].ToString();
                    txtmaxexp.Text = dt.Rows[0]["JobPostMaxExp"].ToString();
                    txtminsalary.Text = dt.Rows[0]["JobPostMinSalary"].ToString();
                    txtmaxsalary.Text = dt.Rows[0]["JobPostMinSalary"].ToString();
                    txtvacancies.Text = dt.Rows[0]["JobPostVacancy"].ToString();
                    txtcomment.Text = dt.Rows[0]["JobPostComments"].ToString();
                    btnjobpost.Text = "Update";
                }
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

        public void BindJobQualifications()
        {
            con.Open();
            cmd = new SqlCommand("select * from tblQualifications", con);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            cblqualification.DataValueField = "QualificationId";
            cblqualification.DataTextField = "QualificationName";
            cblqualification.DataSource = dt;
            cblqualification.DataBind();
        }

        void Reset()
        {
            txtmaxsalary.Text = "";
            txtminexp.Text = "";
            txtmaxexp.Text = "";
            txtminsalary.Text = "";
            txtmaxsalary.Text = "";
            txtvacancies.Text = "";
            txtcomment.Text = "";
            ddljobprofile.SelectedIndex = 0;
            cblqualification.ClearSelection();
            ddljobmode.SelectedIndex = 0;
            rblgender.ClearSelection();
        }

        protected void btnjobpost_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtminexp.Text) < Convert.ToInt32(txtmaxexp.Text))
            {
                if(Convert.ToInt32(txtminsalary.Text) < Convert.ToInt32(txtmaxsalary.Text))
                {
                    string qq = "";
                    for (int i = 0; i < cblqualification.Items.Count; i++)
                    {
                        if (cblqualification.Items[i].Selected == true)
                        {
                            qq += cblqualification.Items[i].Text + ",";
                        }
                    }
                    qq = qq.TrimEnd(',');
                    if (btnjobpost.Text == "Post Job")
                    {
                        con.Open();
                        cmd = new SqlCommand("proc_JobPost", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@action", "INSERT");
                        cmd.Parameters.AddWithValue("@JobRecruiterId", Session["RSID"]);
                        cmd.Parameters.AddWithValue("@JobPostJobProfileId", ddljobprofile.SelectedValue);
                        cmd.Parameters.AddWithValue("@JobPostMode", ddljobmode.SelectedValue);
                        cmd.Parameters.AddWithValue("@JobPostGender", rblgender.SelectedValue);
                        cmd.Parameters.AddWithValue("@JobPostQualifications", qq);
                        cmd.Parameters.AddWithValue("@JobPostMinExp", txtminexp.Text);
                        cmd.Parameters.AddWithValue("@JobPostmaxExp", txtmaxexp.Text);
                        cmd.Parameters.AddWithValue("@JobPostMinSalary", txtminsalary.Text);
                        cmd.Parameters.AddWithValue("@JobPostMaxsalary", txtmaxsalary.Text);
                        cmd.Parameters.AddWithValue("@JobPostVacancy", txtvacancies.Text);
                        cmd.Parameters.AddWithValue("@JobPostComments", txtcomment.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Reset();
                        Response.Redirect("JobRecruiterJobPostShow.aspx");
                    }
                    else if (btnjobpost.Text == "Update")
                    {

                        con.Open();
                        cmd = new SqlCommand("proc_JobPost", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@action", "UPDATE");
                        cmd.Parameters.AddWithValue("@JobPostId", Request.QueryString["pp"]);
                        cmd.Parameters.AddWithValue("@JobPostJobProfileId", ddljobprofile.SelectedValue);
                        cmd.Parameters.AddWithValue("@JobPostMode", ddljobmode.SelectedValue);
                        cmd.Parameters.AddWithValue("@JobPostGender", rblgender.SelectedValue);
                        cmd.Parameters.AddWithValue("@JobPostQualifications", qq);
                        cmd.Parameters.AddWithValue("@JobPostMinExp", txtminexp.Text);
                        cmd.Parameters.AddWithValue("@JobPostmaxExp", txtmaxexp.Text);
                        cmd.Parameters.AddWithValue("@JobPostMinSalary", txtminsalary.Text);
                        cmd.Parameters.AddWithValue("@JobPostMaxsalary", txtmaxsalary.Text);
                        cmd.Parameters.AddWithValue("@JobPostVacancy", txtvacancies.Text);
                        cmd.Parameters.AddWithValue("@JobPostComments", txtcomment.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Reset();
                        Response.Redirect("JobRecruiterJobPostShow.aspx");
                    }
                }
                else
                {
                    lblmsg.Text = ("invalid salary input");
                }
            }
            else
            {
                lblmsg.Text = ("invalid exp input");
            }
        }
    }
}