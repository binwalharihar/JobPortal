using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Configuration;

namespace job_portal.JobSeeker
{
    public partial class JobSeekerHome : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=HP\\SQLEXPRESS;initial catalog=jobdb;integrated security=true");
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindJobSeeker();
            }
        }
        public void BindJobSeeker()
        {
            con.Open();
            cmd = new SqlCommand("select * from tblJobSeeker join tblJobProfile on JobSeekerJobProfile=JobProfileId join tblQualifications on JobSeekerQualification=QualificationId join tblState on JobSeekerState=StateId join tblCity on JobSeekerCity=CityId where JobSeekerId='" + Session["JSID"] + "'", con);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            lblname.Text = dt.Rows[0]["JobSeekerName"].ToString();
            lblemail.Text = dt.Rows[0]["JobSeekerEmail"].ToString();
            lblpwd.Text = dt.Rows[0]["JobSeekerPassword"].ToString();
            lblgender.Text = dt.Rows[0]["JobSeekerGender"].ToString() == "1"
                ? "Male"
                : (dt.Rows[0]["JobSeekerGender"].ToString() == "2"
                    ? "Female"
                    : "Both"); lbljobprofile.Text = dt.Rows[0]["JobProfileName"].ToString();
            lblqualifications.Text = dt.Rows[0]["QualificationName"].ToString();
            lblstate.Text = dt.Rows[0]["StateName"].ToString();
            lblcity.Text = dt.Rows[0]["CityName"].ToString();
            lbladdress.Text = dt.Rows[0]["JobSeekerAddress"].ToString();
            lblsecurityquestion.Text = dt.Rows[0]["JobSeekerQuestion"].ToString();
            lbldob.Text = dt.Rows[0]["JobSeekerDOB"].ToString();
            lblmobile.Text = dt.Rows[0]["JobSeekerMobile"].ToString();
            lblexp.Text = dt.Rows[0]["JobSeekerExp"].ToString();
            lblimage.Text = dt.Rows[0]["JobSeekerImage"].ToString();
            lblresume.Text = dt.Rows[0]["JobSeekerResume"].ToString();
            lblcomment.Text = dt.Rows[0]["JobSeekerComments"].ToString();
            lblans.Text = dt.Rows[0]["JobSeekerAnswer"].ToString();
        }
    }
}