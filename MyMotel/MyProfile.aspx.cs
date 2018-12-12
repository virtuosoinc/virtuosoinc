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
    public partial class MyProfile : System.Web.UI.Page
    {
        /// <summary>
        /// Method to check User Id is available or not
        /// </summary>
        /// <param name="UserId"> User Id</param>
        /// <returns>Returns wether user id available or not</returns>
        protected void Page_Load(object sender, EventArgs e)
        {
            //If any person Logged into system session[userId]!=null
            if (Session["UserId"] != null)
            {
                //create userid and assign session[userid] into it
                int userId = Convert.ToInt32(Session["UserId"]);
                //create dsuserdetails dataset variable and assign GetUserProfileDetails(userid) to it
                DataSet dsUserDetails = GetUserProfileDetails(userId);

                //store accountid from userdetails table into label accountvalue textbox
                lblAccountVal.Text = dsUserDetails.Tables[0].Rows[0]["AccountId"].ToString();

                //store FirstName from dsUserDetails table into label FirstNameValue textbox
                lblFirstNameVal.Text = dsUserDetails.Tables[0].Rows[0]["FirstName"].ToString();

                //store FirstName from dsUserDetails table into label FirstNameValue textbox
                lblLastNameVal.Text = dsUserDetails.Tables[0].Rows[0]["LastName"].ToString();

                //store HouseNumber from dsUserDetails table into label HouseNumberValue textbox
                lblHouseNumberVal.Text = dsUserDetails.Tables[0].Rows[0]["HouseNumber"].ToString();

                //store Street from dsUserDetails table into label StreetValue textbox
                lblStreetVal.Text = dsUserDetails.Tables[0].Rows[0]["Street"].ToString();

                //store City from dsUserDetails table into label CityValue textbox
                lblCityVal.Text = dsUserDetails.Tables[0].Rows[0]["City"].ToString();

                //store State from dsUserDetails table into label State textbox
                lblStateVal.Text = dsUserDetails.Tables[0].Rows[0]["State"].ToString();

                //store MobileNumber from dsUserDetails table into label MobileNumber textbox
                lblMobileVal.Text = dsUserDetails.Tables[0].Rows[0]["MobileNumber"].ToString();

                //store Pincode from dsUserDetails table into label Pincode textbox
                lblPinCodeVal.Text = dsUserDetails.Tables[0].Rows[0]["Pincode"].ToString();

                //store Email from dsUserDetails table into label Email textbox
                lblEmailVal.Text = dsUserDetails.Tables[0].Rows[0]["Email"].ToString();

                //store Answer1 from dsUserDetails table into label Answer1 textbox
                lblAnswer1Val.Text = dsUserDetails.Tables[0].Rows[0]["Answer1"].ToString();

                //store Answer2 from dsUserDetails table into label Answer2 textbox
                lblAnswer2Val.Text = dsUserDetails.Tables[0].Rows[0]["Answer2"].ToString();

                //create question1Id of variable int  and store first Question1 into it
                int question1Id = Convert.ToInt32(dsUserDetails.Tables[0].Rows[0]["Question1Id"]);

                //create question2Id of variable int  and store second question into it
                int question2Id = Convert.ToInt32(dsUserDetails.Tables[0].Rows[0]["Question2Id"]);

                //Display question selected by user into lblSecuritQuestion1Val1 label
                lblSecuritQuestion1Val.Text = GetQuestion(question1Id);
                lblSecuritQuestion2Val.Text = GetQuestion(question2Id);
            }
        }
        /// <summary>
        /// Method to select one of five security questions
        /// </summary>
        /// <param name="UserId"> User Id</param>
        /// <returns>Returns wether user id available or not</returns>
        public string GetQuestion(int QuestionId)
        {
            //create string variable question and empty the text
            string question = string.Empty;

            switch (QuestionId)
            {
                //security question1, to select it by user
                case 1: question = "Your birth place?";
                    break;
                //security question2, to select it by user
                case 2: question = "Your last name?";
                    break;
                //security question3, to select it by user
                case 3: question = "Your nick name?";
                    break;
                //security question4, to select it by user
                case 4: question = "Your first scool name?";
                    break;
                //security question5, to select it by user
                case 5: question = "Your favorite food?";
                    break;
            }
            //returned the question selected by user from dropdown list
            return question;
        }

        /// <summary>
        /// Method to display user details
        /// </summary>
        public DataSet GetUserProfileDetails(int userId)
        {
            try
            {
                //create the sqlconnection con
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                //open the connection
                con.Open();
                //create cmd as sqlcommand and pass the query to database
                SqlCommand cmd = new SqlCommand("select * from UserDetails where UserId=" + userId, con);
                //create da as sqldataadapterr object and assign cmd object to it
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                //create ds object for dataset
                DataSet ds = new DataSet();
                //Fill dataadapter values into dataset
                da.Fill(ds);
                //close the connection
                con.Close();
                //return values stored in dataset
                return ds;
            }
            catch (Exception ex)
            {
                //return exception if any error occurs
                throw ex;
            }
        }
    }
}