using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MyMotel
{
    public partial class EditProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["UserId"] != null)
            {
                int userId = Convert.ToInt32(Session["UserId"]);
                DataSet dsUserDetails = GetUserProfileDetails(userId);
                
                lblFirstNameVal.Text = dsUserDetails.Tables[0].Rows[0]["FirstName"].ToString();
                lblLastNameVal.Text = dsUserDetails.Tables[0].Rows[0]["LastName"].ToString();
                lblHouseNumberVal.Text = dsUserDetails.Tables[0].Rows[0]["HouseNumber"].ToString();
                lblStreetVal.Text = dsUserDetails.Tables[0].Rows[0]["Street"].ToString();
                lblCityVal.Text = dsUserDetails.Tables[0].Rows[0]["City"].ToString();
                lblStateVal.Text = dsUserDetails.Tables[0].Rows[0]["State"].ToString();
                lblMobileVal.Text = dsUserDetails.Tables[0].Rows[0]["MobileNumber"].ToString();
                lblPinCodeVal.Text = dsUserDetails.Tables[0].Rows[0]["Pincode"].ToString();
                lblEmailVal.Text = dsUserDetails.Tables[0].Rows[0]["Email"].ToString();
                lblAnswer1Val.Text = dsUserDetails.Tables[0].Rows[0]["Answer1"].ToString();
                lblAnswer2Val.Text = dsUserDetails.Tables[0].Rows[0]["Answer2"].ToString();

                int question1Id = Convert.ToInt32(dsUserDetails.Tables[0].Rows[0]["Question1Id"]);
                int question2Id = Convert.ToInt32(dsUserDetails.Tables[0].Rows[0]["Question2Id"]);
                lblSecuritQuestion1Val.Text = GetQuestion(question1Id);
                lblSecuritQuestion2Val.Text = GetQuestion(question2Id);               
            }
        }

        public string GetQuestion(int QuestionId)
        {
            string question = string.Empty;
            switch (QuestionId)
            {
                case 1: question = "Your birth place?";
                    break;
                case 2: question = "Your last name?";
                    break;
                case 3: question = "Your nick name?";
                    break;
                case 4: question = "Your first scool name?";
                    break;
                case 5: question = "Your favorite food?";
                    break;
            }
            return question;
        }

        public DataSet GetUserProfileDetails(int userId)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                con.Open();
                string query = string.Empty;
                if (Convert.ToBoolean(Session["IsAdmin"]))
                {
                    query = "select * from AdminDetails where AdminId=" + userId;
                }
                else {
                    query = "select * from UserDetails where UserId=" + userId;
                }
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string firstName = txtFirstName.Text;
                string lastName = txtLastName.Text;
                string mobileNo = txtMobileNo.Text;
                string email = txtEmail.Text;
                string pincode = txtPinCode.Text;
                string state = txtState.Text;
                string city = txtCity.Text;
                string houseNo = txtHouseNo.Text;
                string street = txtStreet.Text;
                int question1Id = Convert.ToInt32(ddlSecurityQuestion1.SelectedValue);
                int question2Id = Convert.ToInt32(ddlSecurityQuestion2.SelectedValue);
                string answer1 = txtAnswer1.Text;
                string answer2 = txtAnswer2.Text;
                int inserted = 0;
                int userId = Convert.ToInt32(Session["UserId"]);
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                string QryString = "UPDATE UserDetails SET FirstName='" + firstName + "', LastName='" + lastName + "', MobileNumber='" + mobileNo + "', Email='" + email + "', Pincode='" + pincode + "',[State]='" + state + "', City='" + city + "', HouseNumber=" + houseNo + ", Street='" + street + "', Question1Id=" + question1Id + ", Answer1='" + answer1 + "', Question2Id=" + question2Id + ", Answer2='" + answer2 + "' where UserId=" + userId;
                SqlCommand CmdObj = new SqlCommand(QryString, conn);
                conn.Open();
                inserted = CmdObj.ExecuteNonQuery();
                conn.Close();
                if (inserted > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "yourMessage", "successMessage();", true);
                    //Response.Redirect("Login.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int AccountAvailable(string AccountId)
        {
            try
            {
                int isAccountAvailable = 0;
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("Account_Availability");

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountId", AccountId);
                cmd.Connection = conn;
                conn.Open();
                isAccountAvailable = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                return isAccountAvailable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            DataSet dsUserDetails = GetUserProfileDetails(userId);

            txtFirstName.Text = dsUserDetails.Tables[0].Rows[0]["FirstName"].ToString();
            txtLastName.Text = dsUserDetails.Tables[0].Rows[0]["LastName"].ToString();
            txtHouseNo.Text = dsUserDetails.Tables[0].Rows[0]["HouseNumber"].ToString();
            txtStreet.Text = dsUserDetails.Tables[0].Rows[0]["Street"].ToString();
            txtCity.Text = dsUserDetails.Tables[0].Rows[0]["City"].ToString();
            txtState.Text = dsUserDetails.Tables[0].Rows[0]["State"].ToString();
            txtMobileNo.Text = dsUserDetails.Tables[0].Rows[0]["MobileNumber"].ToString();
            txtPinCode.Text = dsUserDetails.Tables[0].Rows[0]["Pincode"].ToString();
            txtEmail.Text = dsUserDetails.Tables[0].Rows[0]["Email"].ToString();
            txtAnswer1.Text = dsUserDetails.Tables[0].Rows[0]["Answer1"].ToString();
            txtAnswer2.Text = dsUserDetails.Tables[0].Rows[0]["Answer2"].ToString();

            int question1Id = Convert.ToInt32(dsUserDetails.Tables[0].Rows[0]["Question1Id"]);
            int question2Id = Convert.ToInt32(dsUserDetails.Tables[0].Rows[0]["Question2Id"]);
            ddlSecurityQuestion1.SelectedIndex = question1Id;
            ddlSecurityQuestion2.SelectedIndex = question2Id;

            DisplayTextBoxes();
        }

        public void DisplayTextBoxes()
        {
            txtFirstName.Visible = true;
            txtLastName.Visible = true;
            txtHouseNo.Visible = true;
            txtStreet.Visible = true;
            txtCity.Visible = true;
            txtState.Visible = true;
            txtMobileNo.Visible = true;
            txtPinCode.Visible = true;
            txtEmail.Visible = true;
            txtAnswer1.Visible = true;
            txtAnswer2.Visible = true;
            ddlSecurityQuestion1.Visible = true;
            ddlSecurityQuestion2.Visible = true;

            lblFirstNameVal.Visible = false;
            lblLastNameVal.Visible = false;
            lblHouseNumberVal.Visible = false;
            lblStreetVal.Visible = false;
            lblCityVal.Visible = false;
            lblStateVal.Visible = false;
            lblMobileVal.Visible = false;
            lblPinCodeVal.Visible = false;
            lblEmailVal.Visible = false;
            lblAnswer1Val.Visible = false;
            lblAnswer2Val.Visible = false;
            lblSecuritQuestion1Val.Visible = false;
            lblSecuritQuestion2Val.Visible = false;

            btnChange.Visible = false;
            btnUpdate.Visible = true;
            btnBack.Text = "Cancel";

        }
    }
}