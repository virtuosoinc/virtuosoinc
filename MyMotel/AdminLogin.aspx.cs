using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace MyMotel
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Method to Display Admin Id and User Id
        /// </summary>
        /// <param name="UserId"> Admin Id,user Id</param>
        /// <returns>Display welcome Admin or welcome user</returns>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                #region
                /*Ceclaring String Variable as password,copying text from txtpassword textbox into password variable*/
                string password = txtPassword.Text;
                /*Ceclaring String Variable as userid, copying text from txtuserid into userid variable*/               
                string userId = txtUserId.Text;
                /* Ceclaring String Variable securitykey ,copying text from txtsecuritykey into securitykey variable */
                string securityKey = txtSecurityKey.Text;
                /* Ceclaring int variable as login , and assign 0 to it */
                int login = 0;
                /* Ceclaring String Variable as constr,and assign connection string to it */
                string constr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                /* Creating Sqlconnection Object */
                using (SqlConnection con = new SqlConnection(constr))
                {
                    /*Creating SQLCommand object cmd */
                    using (SqlCommand cmd = new SqlCommand("Validate_AdminUser"))
                    {
                        /* assigning one stored procedure to sqlcommand type object*/
                        cmd.CommandType = CommandType.StoredProcedure;
                        /*Add userid value to sql parameter*/
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        /*Add password value to sql parameter*/
                        cmd.Parameters.AddWithValue("@Password", password);
                        /*Add securitykey value to sql parameter*/
                        cmd.Parameters.AddWithValue("@SecurityKey", securityKey);
                        /*assigning dataconnection as con to sqlcommand*/
                        cmd.Connection = con;
                        /*open the connection*/
                        con.Open();
                        /*execute command and store resultset into login variable*/
                        login = Convert.ToInt32(cmd.ExecuteScalar());
                        /*close the connection*/
                        con.Close();
                    }
                }
                if (login == 0)
                {
                    /* creating sqlconnection object con*/ 
                    SqlConnection con = new SqlConnection(constr);
                    /*open the connection*/
                    con.Open();
                    /*creating cmd as sqlcommand object and pass the query to cmdobject*/
                    SqlCommand cmd = new SqlCommand("select * from AdminDetails where UserId='" + userId + "'", con);
                    /* creating da as dataadapter object*/
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    /*creating ds as dataset object*/
                    DataSet ds = new DataSet();
                    /*Fill  dataset with temporary data values stored in dataadapter objedct*/
                    da.Fill(ds);
                    /*close the connection*/
                    con.Close();
                    /*store adminid value given by admin into variable adminid*/
                    int adminId = Convert.ToInt32(ds.Tables[0].Rows[0]["AdminId"].ToString());
                    /* store userid value given by adminuser into variable adminuserid*/
                    string adminUserId = ds.Tables[0].Rows[0]["UserId"].ToString();
                    /*save userid session value from adminid table */
                    Session["UserId"] = adminId;
                    /*save userid session value from adminid table */
                    Session["adminUserId"] = adminUserId;
                    /*it's checking whether isadmin value true or not*/
                    Session["IsAdmin"] = true;
                    /*it's checking whether loggedin value true or not*/
                    Session["LoggedIn"] = true;

                    Response.Redirect("Home.aspx");
                }
                else
                {
                    /*label display message as invalid credentials when user enter wrong userid password*/
                    lblErrorMessage.Text = "Invalid Credentials";
                }
            }
                #endregion
            catch (Exception ex)
            {
                /*throw catch exception */
                throw ex;
            }
        }

    }
}
