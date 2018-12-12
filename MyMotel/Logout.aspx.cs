using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyMotel
{
    public partial class Logout : System.Web.UI.Page
    {
        /// <summary>
        /// Method to check User Id is available or not
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                /*Code to close the session */
                Session.Abandon();
                /*Code to Redirect page after clicking Logout into Home.aspx page*/
                Response.Redirect("Home.aspx");
            }
            catch (Exception ex)
            {
               /*throw exception when an error occurs*/
                throw ex;
            }
        }
    }
}