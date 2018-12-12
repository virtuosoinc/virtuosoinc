using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Configuration;
using System.Data;

namespace Test.Account
{
    public partial class Register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
        }
        /* After clicking Register button send code details to database */
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string firstName = txtFirstName.Text;
                string lastName = txtLastName.Text;
                string mobileNo = txtMobileNo.Text;
                string email = txtEmail.Text;
                string accountId = txtAccountId.Text;
                string password = txtPassword.Text;
                //string address = txtAddress.Text;
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
                //int emailAvailable = 0;
                int accountAvailable = 0;
                accountAvailable = AccountAvailable(accountId);
                if (accountAvailable == 0)
                {
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);                    
                    string QryString = "insert into UserDetails values('" + firstName + "','" + lastName + "','" + mobileNo + "','" + email + "','" + password + "','" + pincode + "','" + state + "','" + city + "','" + houseNo + "','" + street + "'," + question1Id + ",'" + answer1 + "'," + question2Id + ",'" + answer2 + "','" + accountId + "')";
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
                else
                {
                    lblMessage.Text = "User Id is not Available. Please provide differant Id";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /*Customer after clicking NEXT button ,send values to  next page clear all the entered values*/
        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                int emailAvailable = 0;
                string email = txtEmail.Text;
                emailAvailable = EmailAvailable(email);

                if (emailAvailable == 0)
                {
                    fieldset1.Visible = false;
                    btnNext.Visible = false;
                    btnBack1.Visible = false;

                    fieldset2.Visible = true;
                    btnRegister.Visible = true;
                    btnBack.Visible = true;
                }
                else
                {
                    lblMessage.Text = "EMail is not Available. Please provide differant Email";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        /* code to send email to user */
        public int EmailAvailable(string Email)
        {
            try
            {
                int emailAvailable = 0;
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("Email_Availability");

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Connection = conn;
                conn.Open();
                emailAvailable = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                return emailAvailable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /* code to create new account id */
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
        /*  code to create back button */
        protected void btnBack_Click(object sender, EventArgs e)
        {
            fieldset1.Visible = true;
            btnNext.Visible = true;
            btnBack1.Visible = true;

            fieldset2.Visible = false;
            btnRegister.Visible = false;
            btnBack.Visible = false;
        }

    }
}
