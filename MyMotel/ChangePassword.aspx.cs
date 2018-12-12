using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace MyMotel
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Method to check User Id is available or not
        /// </summary>
        /// <param name="UserId"> User Id</param>
        /// <returns>Returns wether user id available or not</returns>
        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            #region
            /*Create userId variable of type int and store Userid value in it*/
            int userId = Convert.ToInt32(Session["UserId"]);
            /*Create oldPassword variable of type int and store txtoldpassword value entered by user in it*/
            string oldPassword = txtOldPassword.Text;
            /*Create newPassword variable of type int and store txtnewpassword value entered by user in it*/
            string newPassword = txtConfirmPassword.Text;   
            /*create updated variable of type int and assign 0 to it*/
            int updated = 0;
            /*Create sqlconnection objecg conn*/
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
            /*open the connection*/
            conn.Open();
            /*create string query and declre it as Empty*/
            string query = string.Empty;
            /*Check wether loggedin session person is admin or not, ,*/
            if (Convert.ToBoolean(Session["IsAdmin"]))
            {
                /*If LoggedIn session person is Admin, execute the query and selecy userid,password and adminid result in query variable*/
                query="select UserId, Password from AdminDetails where AdminId=" + userId + " and Password='" + oldPassword + "'";
            }
            else {
                /*If LoggedIn session person is userid, execute the query and selecy userid,password and userid result in query variable*/
                query="select UserId, Password from UserDetails where UserId=" + userId + " and Password='" + oldPassword + "'"; 
            }
            /*Create sqlcommand object cmd */
            SqlCommand cmd = new SqlCommand(query, conn);
            /*Create Sqldataadapter object da and pass cmd arguments*/
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            /*Create dataset object ds*/
            DataSet ds = new DataSet();
            /*Fill dataset with values from dataadapter*/
            da.Fill(ds);
            /*close the connection*/
            conn.Close();
            /*Check whether Row Count in Table zero is greaterthan 0 or not*/
            if (ds.Tables[0].Rows.Count > 0)
            {
                /*Make QryString as Empty */
                string QryString =string.Empty;
                /*convert IsAdmin variable to boolean and Check Admin or not*/
            if (Convert.ToBoolean(Session["IsAdmin"]))
            {
                /*if Yes, Update admin details with new password*/
                QryString = "Update AdminDetails set Password='" + newPassword + "' where AdminId=" + userId;
            }
            else {
                /*if No, Update User details with new password*/
                QryString = "Update UserDetails set Password='" + newPassword + "' where UserId=" + userId; 
            }
                /*Pass connection object conn to the sqlcommand*/
                SqlCommand CmdObj = new SqlCommand(QryString, conn);
                /*open the connection*/
                conn.Open();
                /*Execute the query and store result in updated variable*/
                updated = CmdObj.ExecuteNonQuery();
                /*close the connection*/
                conn.Close();
                /*Check updated variable value greaterthan zero*/
                if (updated > 0)
                {
                    /*if updated value greaterthan 0 , print success message */
                    ClientScript.RegisterStartupScript(this.GetType(), "yourMessage", "successMessage();", true);
                    //Response.Redirect("Login.aspx");
                }
            }
            else
            {/*or else, print below error message as Old Password/Security Questions are incorrect*/
                lblErrorMessage.Text = "Old Password/Security Questions are incorrect";
            }
            #endregion
        }
    }
}