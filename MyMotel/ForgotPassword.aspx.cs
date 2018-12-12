using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using MyMotel.Components;

namespace MyMotel
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Method to Retrieve password from database
        /// </summary>
        /// <param name="UserId"> User Id</param>
        /// <returns>Returns wether user id available or not</returns>
        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                #region
                /*Declare label text message to empty the string */
                lblMessage.Text = string.Empty;
                /*Create answer1 string variable  and store value entered in txtAnswer1 textbox*/
                string answer1 = txtAnswer1.Text;
                /*Create answer2 string variable  and store value entered in txtAnswer2 textbox*/
                string answer2 = txtAnswer2.Text;
                /*Create role string variable  and request querystring Role */
                string role = Request.QueryString["Role"].ToString();
                /*Create SQLConnection con object*/
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                /*Open the Connection*/
                con.Open();
                /*Create query string variable and empty the string*/
                string query = string.Empty;
                /*Check the person role as admin or not*/
                if (role == "Admin")
                {
                    /*Execute the command and select Adminid,password from Admindetails*/
                    query = "select AdminId, Password from AdminDetails where Email='" + txtEmail.Text + "' and Answer1='" + answer1 + "' and Answer2='" + answer2 + "'";
                }
                else
                {
                    /*Execute the command and select UserId,password from Userdetails*/
                    query = "select UserId, Password from UserDetails where Email='" + txtEmail.Text + "' and Answer1='" + answer1 + "' and Answer2='" + answer2 + "'";
                }
                /*Create the cmd as sqlcommand object*/
                SqlCommand cmd = new SqlCommand(query, con);
                /*Create Sqldataadapter da object and assign the command object cmd to it*/
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                /*Create Dataset object ds */
                DataSet ds = new DataSet();
                /*Fill dataset object ds and fill data into it*/
                da.Fill(ds);
                /*check table 0 of row count greater than 0 */
                if (ds.Tables[0].Rows.Count > 0)
                {
                    /*create password as string and store password attribute into it*/
                    string password = ds.Tables[0].Rows[0]["Password"].ToString();
                    /*create originalpassword variable and store password entered by admin or user*/
                    string originalPassword = password;
                    /*Creating object email to Email class*/
                    Email email = new Email();
                    /*Creating IsMainSent boolean variable and sending the email as password changing*/
                    bool IsMailSent = email.SendEmail("Forgot Password", "Hi,<br/>Your password is '" + originalPassword + "' .<br/>Thanks,<br/>Support Team.", txtEmail.Text);
                    if (IsMailSent)
                    {
                        /*If the mail sent display message as Emil sent to the MailId Given*/
                        lblMessage.Text = "Email sent to the MailId given";
                    }
                }
                else
                {
                    /*or else display message as provide correct answers.*/
                    lblMessage.Text = "Please provide correct amswers";
                }
                #endregion
            }
            catch (Exception ex)
            {
                /*Throw exception message when error occurs*/
                throw ex;
            }
        }
        /// <summary>
        /// Method to check User Id is available or not
        /// </summary>
        /// <param name="UserId"> User Id</param>
        /// <returns>Returns wether user id available or not</returns>
        protected void btnNext_Click(object sender, EventArgs e)
        {
            #region
            try
            {
                /*Display label message text as Empty string*/
                lblMessage.Text = string.Empty;
                /*Create Sqlconnection object con*/
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                /*Open the connection*/
                con.Open();
                /*create string query variable and empty the variable*/
                string query = string.Empty;
                /*create string role variable and request role querystring*/
                string role = Request.QueryString["Role"].ToString();
                /*If the role of loggedin person is Admin*/
                if (role == "Admin")
                {
                    /*Execute the query if the person is admin*/
                    query = "select AdminId, Password, Question1Id, Question2Id from AdminDetails where Email='" + txtEmail.Text + "'";
                }
                else
                {
                    /*Execute the query if the loggedin person is user*/
                    query = "select UserId, Password, Question1Id, Question2Id from UserDetails where Email='" + txtEmail.Text + "'";
                }
                /*create sqlcommand object cmd and oass querystring and connection object con to it*/
                SqlCommand cmd = new SqlCommand(query, con);
                /*create sqldataadapter object da and pass sqlcommand object cmd to it*/
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                /*create sqlcommand object cmd and pass querystring and connection object con to it*/
                DataSet ds = new DataSet();
                /*Fill dataset values with temporary table sqldataadapter */
                da.Fill(ds);
                /*check table 0 of row count greater than 0 */
                if (ds.Tables[0].Rows.Count > 0)
                {
                    /*set email div visibility false*/
                    divEmail.Visible = false;
                    /*set security questions division visibility true*/
                    divQuestions.Visible = true;
                    /*create question1Id variable of type int and store question 1 Id into it*/
                    int question1Id = Convert.ToInt32(ds.Tables[0].Rows[0]["Question1Id"]);
                    /*create question1Id variable of type int and store question 2 Id into it*/
                    int question2Id = Convert.ToInt32(ds.Tables[0].Rows[0]["Question2Id"]);
                    /*GetDataItem question 1 and display in lblSecuritQuestion1Val*/
                    lblSecuritQuestion1Val.Text = GetQuestion(question1Id);
                    /*GetDataItem question 2 and display in lblSecuritQuestion1Va2*/
                    lblSecuritQuestion2Val.Text = GetQuestion(question2Id);
                }
                else
                {
                    /*If row count is equal to zero then , Display label text as Email Id/Security Questions are incorrect*/
                    lblMessage.Text = "Email Id/Security Questions are incorrect";
                }
            #endregion
            }
            
            catch (Exception ex)
            {
                /*show the exception message when an error occurs*/
                throw ex;
            }
        }
        /// <summary>
        /// Method to Check security question
        /// </summary>  
        public string GetQuestion(int QuestionId)
        {
            try
            {
                #region
                /*Create question as variable of type string and empty the question the variable*/
                string question = string.Empty;
                /*check the security question which user or admin will select when he forgotpassword*/
                switch (QuestionId)
                {
                    /*Select question 1*/
                    case 1: question = "Your birth place?";
                        break;
                    /*Select question 2*/
                    case 2: question = "Your last name?";
                        break;
                    /*Select question 3*/
                    case 3: question = "Your nick name?";
                        break;
                    /*Select question 4*/
                    case 4: question = "Your first scool name?";
                        break;
                    /*Select question 5*/
                    case 5: question = "Your favorite food?";
                        break;
                }
                /*return question*/
                return question;
            }

            #endregion
            catch (Exception ex) 
            {
                /*return message if any error occurs*/
                throw ex;
            }
        }
        /// <summary>
        /// Method to click back button
        /// </summary>
        protected void btnBack_Click(object sender, EventArgs e)
        {
            /*make email div visibility as true*/
            divEmail.Visible = true;
            /*make Questions div visibility as false*/
            divQuestions.Visible = false;
        }
    }
}
