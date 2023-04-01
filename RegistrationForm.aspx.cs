using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagement
{
    public partial class RegistrationForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source =PRABHAT_SINGH; initial catalog=HospitalManagement; integrated security=true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Show();
                ShowGender();
                ShowBloodGroup();
                ShowStatus();
                ShowDepartment();
                ShowCourse();
                ShowCountry();
            }
        }
        public void Clear()
        {
            txtname.Text = "";
            rblgender.ClearSelection();
            rblbloodgroup.ClearSelection();
            rblstatus.ClearSelection();
            ddldepartment.SelectedValue = "1";
            ddlcourse.SelectedValue = "1";
            ddlcountry.SelectedValue = "1";
        }
        public void Show()
        {
            con.Open();
            string str = "select * from RegistrationForm join employee_gender on employee_gender=gender_id join employee_bloodgroup on employee_bloodgroup=bloodgroup_id join employee_status on employee_status=status_id join employee_department on employee_department=department_id join employee_course on employee_course=course_id join employee_country on employee_country=country_id";
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            gvregistration.DataSource = dt;
            gvregistration.DataBind();
        }

        public void ShowGender()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from employee_gender", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            rblgender.DataValueField = "gender_id";
            rblgender.DataTextField = "gender_name";
            rblgender.DataSource = dt;
            rblgender.DataBind();
        }

        public void ShowBloodGroup()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from employee_bloodgroup", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            rblbloodgroup.DataValueField = "bloodgroup_id";
            rblbloodgroup.DataTextField = "bloodgroup_name";
            rblbloodgroup.DataSource = dt;
            rblbloodgroup.DataBind();
        }

        public void ShowStatus()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from employee_status", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            rblstatus.DataValueField = "status_id";
            rblstatus.DataTextField = "status_name";
            rblstatus.DataSource = dt;
            rblstatus.DataBind();
        }

        public void ShowDepartment()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from employee_department", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            ddldepartment.DataValueField = "department_id";
            ddldepartment.DataTextField = "department_name";
            ddldepartment.DataSource = dt;
            ddldepartment.DataBind();
            ddldepartment.Items.Insert(0, new ListItem("--Select--", "1"));
        }

        public void ShowCourse()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from employee_course", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            ddlcourse.DataValueField = "course_id";
            ddlcourse.DataTextField = "course_name";
            ddlcourse.DataSource = dt;
            ddlcourse.DataBind();
        }
        public void ShowCountry()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from employee_country", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            ddlcountry.DataValueField = "country_id";
            ddlcountry.DataTextField = "country_name";
            ddlcountry.DataSource = dt;
            ddlcountry.DataBind();
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text == "Save")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into RegistrationForm(employee_name,employee_gender,employee_bloodgroup,employee_status,employee_department,employee_course,employee_country)values('" + txtname.Text + "','" + rblgender.SelectedValue + "','" + rblbloodgroup.SelectedValue + "','" + rblstatus.SelectedValue + "','" + ddldepartment.SelectedValue + "','" + ddlcourse.SelectedValue + "','" + ddlcountry.SelectedValue + "')", con);
                cmd.ExecuteNonQuery();
                Clear();
                con.Close();
            }
            else if (btnsave.Text == "Update")
            {
                con.Open();
                string str = "update RegistrationForm set employee_name = '" + txtname.Text + "',employee_gender = '" + rblgender.SelectedValue + "',employee_bloodgroup = '" + rblbloodgroup.SelectedValue + "',employee_status = '" + rblstatus.SelectedValue + "',employee_department = '" + ddldepartment.SelectedValue + "',employee_course = '" + ddlcourse.SelectedValue + "',employee_country = '" + ddlcountry.SelectedValue + "' where employee_id = '" + ViewState["abc"] + "'";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                con.Close();
                Clear();
                btnsave.Text = "Save";
            }
            Show();
            Clear();
        }

        protected void gvregistration_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DEL")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from RegistrationForm where employee_id='" + e.CommandArgument + "'", con);
                cmd.ExecuteNonQuery();
                Clear();
                con.Close();
            }
            else if (e.CommandName == "EDI")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from RegistrationForm where employee_id='" + e.CommandArgument + "'" , con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();
                txtname.Text = dt.Rows[0][1].ToString();
                rblgender.SelectedValue = dt.Rows[0][2].ToString();
                rblbloodgroup.SelectedValue = dt.Rows[0][3].ToString();
                rblstatus.SelectedValue = dt.Rows[0][4].ToString();
                ddldepartment.SelectedValue = dt.Rows[0][5].ToString();
                ddlcourse.SelectedValue = dt.Rows[0][6].ToString();
                ddlcountry.SelectedValue = dt.Rows[0][7].ToString();
                btnsave.Text = "Update";
                ViewState["abc"] = e.CommandArgument;
            }
            Show();
        }
    }


}
