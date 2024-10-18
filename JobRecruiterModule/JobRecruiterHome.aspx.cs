using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace job_portal.JobRecruiter
{
    public partial class JobRecruiterHome : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=HP\\SQLEXPRESS;initial catalog=jobdb;integrated security=true");
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindJobRecruiter();
            }
        }
        public void BindJobRecruiter()
        {
            con.Open();
            cmd = new SqlCommand("select * from tblJobRecruiter join tblstate on JobRecruiterState=StateId join tblCity on JobRecruiterCity=CityId where JobRecruiterId='" + Session["RSID"] + "'", con);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            con.Close();

            lblname.Text = dt.Rows[0]["JobRecruiterName"].ToString();
            lblemail.Text = dt.Rows[0]["JobRecruiterEmail"].ToString();
            lblpwd.Text = dt.Rows[0]["JobRecruiterPassword"].ToString();
            lblstate.Text = dt.Rows[0]["StateName"].ToString();
            lblcity.Text = dt.Rows[0]["CityName"].ToString();
            lbladdress.Text = dt.Rows[0]["JobRecruiterAddress"].ToString();
            lblmobile.Text = dt.Rows[0]["JobRecruiterMobile"].ToString();
            lblimage.Text = dt.Rows[0]["JobRecruiterImage"].ToString();
            lblcomment.Text = dt.Rows[0]["JobRecruiterComments"].ToString();
            lblurl.Text = dt.Rows[0]["JobRecruiterURL"].ToString();
            lblhr.Text = dt.Rows[0]["JobRecruiterHR"].ToString();
        }
    }
}