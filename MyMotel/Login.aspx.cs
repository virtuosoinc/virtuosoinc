using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Test.Account
{
    public partial class Login : System.Web.UI.Page
    {
        /// <summary>
        /// Method to Navigate url from uer register page to user Login page
        /// </summary>  
        protected void Page_Load(object sender, EventArgs e)
        {
            /*Navigate page url*/
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        /// <summary>
        /// Method to check User Id is available or not
        /// </summary>
        /// <param name="UserId"> User Id</param>
        /// <returns>Returns wether user id available or not</returns>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            /*Create string variable password and it store text entered in txtpassword textbox*/
            string password = txtPassword.Text;
            /*Create string variable email and it store text entered in txtemail textbox*/
            string email = txtEmail.Text;
            /*Create int variable login and iassign 0 to it*/
            int login = 0;
            /*create constr connectionstring object*/
            string constr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            /*create sqlconnection con object*/
            using (SqlConnection con = new SqlConnection(constr))
            {
                /*create sqlcommand cmd object and assigned stored procedure validate_user*/
                using (SqlCommand cmd = new SqlCommand("Validate_User"))
                {
                    /*add storedprocedure to the sqlcommand object cmd*/
                    cmd.CommandType = CommandType.StoredProcedure;
                    /*pass parameters Email to the storedprocedure validate_user*/
                    cmd.Parameters.AddWithValue("@Email", email);
                    /*pass parameters password to the storedprocedure validate_user*/
                    cmd.Parameters.AddWithValue("@Password", password);
                    /*passcommand*/
                    cmd.Connection = con;
                    /*open the connection*/
                    con.Open();
                    /*execute query and store value in login variable*/
                    login = Convert.ToInt32(cmd.ExecuteScalar());
                    /*close the Connection*/
                    con.Close();
                }
            }
            /*if login variable equal to zero*/
            if (login == 0)
            {
                /*create sqlconnection object con*/
                SqlConnection con = new SqlConnection(constr);
                /*open the connection*/
                con.Open();
                /*pass sql command to the sqlconnection*/
                SqlCommand cmd = new SqlCommand("select * from UserDetails where Email='" + email + "' or AccountId='" + email + "'", con);
                /*create sqldataadapter object da*/
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                /*create ds as dataset object*/
                DataSet ds = new DataSet();
                /*Fill the temporary data values from dataadapter into dataset*/
                da.Fill(ds);
                /*close the connection*/
                con.Close();
                /*If user logged in successfully , select lastname from table 0 of row count 0*/
                string lastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                /*If user logged in successfully , select firstname from table*/
                string firstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                /*convert userid into digit and store it in integer variable userid */
                int userId = Convert.ToInt32(ds.Tables[0].Rows[0]["UserId"].ToString());
                /*add both firstname and lastname and store it into username*/
                Session["UserName"] = firstName + " " + lastName;
                /*store userid  variable into session[userid] attribute*/
                Session["UserId"] = userId;        
                /*displaying user is loggedin and session[loggedin] is true*/
                Session["LoggedIn"] = true;

                /*pass querystring into string datatype page variable*/
                string page = Request.QueryString["page"];
                /*check wether the looking page is Booking*/
                if (page == "Booking")
                {
                    /*if yes , create motelIds and pass queryrstring MotelIds*/
                    string motelIds = Request.QueryString["MotelIds"];
                    /*Redirect page into BookMotel.aspx*/
                    Response.Redirect("BookMotel.aspx?motelIds=" + motelIds);
                }
                /*redirect page into Home.aspx*/
                Response.Redirect("Home.aspx");
                

            }
            else
            {
                /*If the credentials entered are invalid , then display message as Invalid Credentials*/
                lblErrorMessage.Text = "Invalid Credentials";
            }
        }
    }
}
