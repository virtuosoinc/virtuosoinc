using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace MyMotel
{
    public partial class Home : System.Web.UI.Page
    {
        /// <summary>
        /// Method to Display Admin Id and User Id
        /// </summary>
        /// <param name="UserId"> Admin Id,user Id</param>
        /// <returns>Display welcome Admin or welcome user</returns>
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                #region
                /* Check if any person loggedIn into session,If yes check whether he or she is admin or user */
                if (Convert.ToBoolean(Session["LoggedIn"]))
                {
                    /* Check if loggedIn session is admin or not, If admin then display Welcome Admin*/
                    if (Convert.ToBoolean(Session["IsAdmin"]))
                    {
                        lblWelcome.Text = "Welcome " + Session["adminUserId"].ToString();
                    }
                    /* or else Display text as welcome Username  */
                    else
                    {
                        lblWelcome.Text = "Welcome " + Session["UserName"].ToString();
                    }

                }

                else
                {
                    /*I f no person logged into session, welcome text is Empty*/
                    lblWelcome.Text = string.Empty;
                }
            }
                #endregion

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}