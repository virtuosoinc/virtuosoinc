using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace MyMotel
{
    public partial class AdminRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Method to store User Registration Values
        /// </summary>
        
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                #region
                /*Label to display Empty message text*/
                lblMessage.Text = string.Empty;
                /*Creating string variable as first name and store txtFirstName value into it*/
                string firstName = txtFirstName.Text;
                /*Creating string variable as Last name and store txtLastName value into it*/
                string lastName = txtLastName.Text;
                /*Creating string variable as Last name and store txtMobileNo value into it*/
                string mobileNo = txtMobileNo.Text;
                /*Creating string variable as Email and store txtEmail value into it*/
                string email = txtEmail.Text;
                /*Creating string variable as accountId and store txtAccountId value into it*/
                string accountId = txtAccountId.Text;
                /*Creating string variable as Password and store txtPassword value into it*/
                string password = txtPassword.Text;
                /*Creating string variable as Pincode and store txtPinCode value into it*/
                string pincode = txtPinCode.Text;
                /*Creating string variable as State and store txtState value into it*/
                string state = txtState.Text;
                /*Creating string variable as City and store txtCity value into it*/
                string city = txtCity.Text;
                /*Creating string variable as houseNo and store txtHouseNo value into it*/
                string houseNo = txtHouseNo.Text;
                /*Creating string variable as street and store txtStreet value into it*/
                string street = txtStreet.Text;
                /*Creating int variable as question1Id and store  selected security question1 from dropdown into it*/
                int question1Id = Convert.ToInt32(ddlSecurityQuestion1.SelectedValue);
                /*Creating int variable as question2Id and store selected security question2 from dropdown into it*/
                int question2Id = Convert.ToInt32(ddlSecurityQuestion2.SelectedValue);
                /*Creating string variable as answer1 and store txtAnswer1 value into it*/
                string answer1 = txtAnswer1.Text;
                /*Creating string variable as answer2 for security question and store txtAnswer2 value into it*/
                string answer2 = txtAnswer2.Text;
                /*Creating string variable as securityKey for security and store txtSecurityKey value into it*/
                string securityKey = txtSecurityKey.Text;
                /*Creating int variable as inserted and store inserted variable=0  */
                int inserted = 0;
                /*Creating int variable as accountAvailable and assign accountId to AccountAvailable  */
                int accountAvailable = AccountAvailable(accountId);
                /*Check accountavailable is equal to zero or not */
                if (accountAvailable == 0)
                {
                    /*Creating int variable as isValidKey and assign securityKey to SecurityKeyCheck  */
                    int isValidKey = SecurityKeyCheck(securityKey);
                    /*Check isValidKey equal to zero or not*/
                    if (isValidKey == 0)
                    {
                        /*Creating SQLConnection object as con*/
                        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                        /*Creating qrystring string variable and inert AdminDetails values into it*/
                        string QryString = "insert into AdminDetails values('" + accountId + "','" + password + "','" + securityKey+"','" + firstName + "','" + lastName + "','" + mobileNo + "','" + email + "','" + pincode + "','" + state + "','" + city + "','" + houseNo + "','" + street + "'," + question1Id + ",'" + answer1 + "'," + question2Id + ",'" + answer2 + "')";
                        /*Creating SQLCommand object as cmdobj and assign qrystring variable into it.*/
                        SqlCommand CmdObj = new SqlCommand(QryString, conn);
                        /*open the connection*/
                        conn.Open();
                        /*execute the query and store resultset into inserted variable*/
                        inserted = CmdObj.ExecuteNonQuery();
                        /*close the connection*/
                        conn.Close();
                        /*Check whether inserted variable value greater than 0 or not*/
                        if (inserted > 0)
                        {
                            /*if yes, then print the successmessage*/
                            ClientScript.RegisterStartupScript(this.GetType(), "yourMessage", "successMessage();", true);
                            
                        }
                    }
                    else
                    {
                        /*If inserted value equal to zero, print label message as Invalid Security key*/
                        lblMessage.Text = "Invalid Security Key";
                    }
                }
                else
                {
                    
                    /*account available value is not equal to zero then,print below label text message*/
                    lblMessage.Text = "Admin Id is not Available. Please provide differant Id";
                }
                #endregion
            }
            catch (Exception ex)
            {
                /*If any error occurs in code,throw an exception of it.*/
                throw ex;
            }
        }
        /// <summary>
        /// Method to check User Id is available or not
        /// </summary>
        /// <param name="UserId"> User Id</param>
        /// <returns>Returns wether user id available or not</returns>
        public int AccountAvailable(string UserId)
        {
            try
            {
                #region
                /*Declare int datatype variable isAccountAvailable and assign it to zero */
                int isAccountAvailable = 0;
                /* create sqlconnection object conn */
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                /*create sqlcommand object cmd*/
                SqlCommand cmd = new SqlCommand("AdminAccount_Availability");
                /*assign stored procedure to sqlcommand of type cmd*/
                cmd.CommandType = CommandType.StoredProcedure;
                /*add parameter value userid to sqlcommand*/
                cmd.Parameters.AddWithValue("@UserId", UserId);
                /*pass sql connection object to command type cmd*/
                cmd.Connection = conn;
                /*open the connection*/
                conn.Open();
                /* execite query and store result in isaccountavailable */
                isAccountAvailable = Convert.ToInt32(cmd.ExecuteScalar());
                /*close the connection*/
                conn.Close();
                /*return is AccountAvailable value*/
                return isAccountAvailable;
                #endregion
            }
            catch (Exception ex)
            {
                /*throw exception if any error occurs*/
                throw ex;
            }
        }
        /// <summary>
        /// Method to check User Id is available or not
        /// </summary>
        /// <param name="UserId"> isKeyValid</param>
        /// <returns>Returns isKeyValid value</returns>
        public int SecurityKeyCheck(string SecurityKey)
        {
            try
            {
                #region
                /*create isKeyValid variable of type int and assign 0 for the variable */
                int isKeyValid = 0;
                /*create sqlconnection object conn*/
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                /*create sqlcommand object cmd*/
                SqlCommand cmd = new SqlCommand("SecurityKey_Check");
                /*add storedprocedure to sqlcommand object */
                cmd.CommandType = CommandType.StoredProcedure;
                /*Add Parameter value SecurityKey to command object cmd*/
                cmd.Parameters.AddWithValue("@SecurityKey", SecurityKey);
                /*assign conn sqlconnection to command object cmd*/
                cmd.Connection = conn;
                /*open the connection*/
                conn.Open();
                /*Execute query and store result value into isKeyValid*/
                isKeyValid = Convert.ToInt32(cmd.ExecuteScalar());
                /*Close the connection*/
                conn.Close();
                /*return isKeyValid*/
                return isKeyValid;
                #endregion
            }
            catch (Exception ex)
            {
                /*throw exception if any error occurs*/
                throw ex;
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                #region
                /*Create emailAvailable of type int and assign 0 to it */
                int emailAvailable = 0;
                /*create email variable of type string and store email address entered in txtEmail textbox*/
                string email = txtEmail.Text;
                /*Store email address entered in email available textbox*/
                emailAvailable = EmailAvailable(email);
                /*check EmailAvailable variable equal to zero  */
                if (emailAvailable == 0)
                {

                    /*keep fieldset1 visibility value false*/
                    fieldset1.Visible = false;
                    /*keep btnNext visibility value false*/
                    btnNext.Visible = false;
                    /*keep btnBack1 visibility value false*/
                    btnBack1.Visible = false;
                    /*keep fieldset2 visibility value false*/
                    fieldset2.Visible = true;
                    /*keep btnRegister visibility value false*/
                    btnRegister.Visible = true;
                    /*btnBack fieldset1 visibility value false*/
                    btnBack.Visible = true;
                }
                else
                {
                    /*Displaylabel text message as EMail is not Available. Please provide differant Email */
                    lblMessage.Text = "EMail is not Available. Please provide differant Email";
                }
                #endregion
            }
            catch (Exception ex)
            {
                /*Throw an Exception when an error occurs*/
                throw ex;
            }


        }
        /* code to send email to user */
        public int EmailAvailable(string Email)
        {
            try
            {
                #region
                /*Create emailAvailable variable of type int and assign 0 to it */
                int emailAvailable = 0;
                /*create sqlconnection object conn*/
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                /*create sqlcommand object cmd*/
                SqlCommand cmd = new SqlCommand("AdminEmail_Availability");
                /*assign stored procedure to sqlcommand type*/
                cmd.CommandType = CommandType.StoredProcedure;
                /*Add parameter value Email*/
                cmd.Parameters.AddWithValue("@Email", Email);
                /*assign sqlconnection variable conn to command type cmd*/
                cmd.Connection = conn;
                /*open the connection*/
                conn.Open();
                /*execute the query and store it in emailAvailable*/
                emailAvailable = Convert.ToInt32(cmd.ExecuteScalar());
                /*close the connection*/
                conn.Close();
                /*return emailAvailable value*/
                return emailAvailable;
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Method to check User Id is available or not
        /// </summary>
        protected void btnBack_Click(object sender, EventArgs e)
        {
            #region

            /*keep fieldset1 visibility value false*/
            fieldset1.Visible = false;
            /*keep btnNext visibility value false*/
            btnNext.Visible = false;
            /*keep btnBack1 visibility value false*/
            btnBack1.Visible = false;
            /*keep fieldset2 visibility value false*/
            fieldset2.Visible = true;
            /*keep btnRegister visibility value false*/
            btnRegister.Visible = true;
            /*btnBack fieldset1 visibility value false*/
            btnBack.Visible = true;

            #endregion
        }
    }
}