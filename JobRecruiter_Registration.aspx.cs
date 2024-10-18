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
    public partial class JobRecruiter_Registration : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=HP\\SQLEXPRESS;initial catalog=jobdb;integrated security=true");
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindState();
            }
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

        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCity();
        }

        public void Reset()
        {
            txtname.Text = "";
            txtemail.Text = "";
            txturl.Text = "";
            txtcomment.Text = "";
            txtaddress.Text = "";
            txtmobile.Text = "";
            txtpwd.Text = "";
            txthr.Text = "";
            ddlcity.SelectedValue = "0";
            ddlstate.SelectedValue = "0";
        }
        protected void btnjobrecruitersubmit_Click(object sender, EventArgs e)
        {
            string imagename = Path.GetFileName(fuimage.PostedFile.FileName);

            fuimage.SaveAs(Server.MapPath("JobRecruiterimage" + "\\" + imagename));

            con.Open();
            cmd = new SqlCommand("Proc_JobRecruiter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "INSERT");
            cmd.Parameters.AddWithValue("@JobRecruiterName", txtname.Text);
            cmd.Parameters.AddWithValue("@JobRecruiterEmail", txtemail.Text);
            cmd.Parameters.AddWithValue("@JobRecruiterPassword", txtpwd.Text);
            cmd.Parameters.AddWithValue("@JobRecruiterState", ddlstate.SelectedValue);
            cmd.Parameters.AddWithValue("@JobRecruiterCity", ddlcity.SelectedValue);
            cmd.Parameters.AddWithValue("@JobRecruiterAddress", txtaddress.Text);
            cmd.Parameters.AddWithValue("@JobRecruiterMobile", txtmobile.Text);
            cmd.Parameters.AddWithValue("@JobRecruiterComments", txtaddress.Text);
            cmd.Parameters.AddWithValue("@JobRecruiterURL", txturl.Text);
            cmd.Parameters.AddWithValue("@JobRecruiterHR", txthr.Text);
            cmd.Parameters.AddWithValue("@JobRecruiterImage", imagename);
            cmd.ExecuteNonQuery();
            con.Close();
            Reset();
        }
    }
}