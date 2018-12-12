using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyMotel
{
    public partial class SiteHome : System.Web.UI.MasterPage
    {
        
        /// <summary>
        /// Method to Check Loggedin person admin or user
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                #region
                /*Check any person is LoggedIn */
                if (Convert.ToBoolean(Session["LoggedIn"]))
                {
                    /*If the LoggedIn person is Admin*/
                    if (Convert.ToBoolean(Session["IsAdmin"]))
                    {
                        /*keep AdminNavigationMenu visibility true*/
                        AdminNavigationMenu.Visible = true;
                    }
                    else
                    {
                        /*keep UserNavigationMenu visibility true*/
                        UserNavigationMenu.Visible = true;
                    }
                }
                else
                {
                    /*If No person is LoggedIn then NavigationMenu Visibility true*/
                    NavigationMenu.Visible = true;
                }
                /*If the LoggedIn person is Admin*/
                if (Convert.ToBoolean(Session["LoggedIn"]))
                {
                    /*keep UserNavigationMenu visibility true*/                
                    HeadLogoutStatus.Visible = true;
                    /*If the LoggedIn person is Admin*/
                    if (!Convert.ToBoolean(Session["IsAdmin"]))
                    {
                        /*HeadMyProfile Visibility is true*/
                        HeadMyProfile.Visible = true;
                        
                    }
                }
                else
                {
                    //HeadLogoutStatus Visibilityis true;                
                    HeadLogoutStatus.Visible = false;
                    //HeadMyprofile Visibilityis true;
                    HeadMyProfile.Visible = false;
                    
                }
                #endregion
            }

            catch (Exception ex)
            {
                /*Display ex message when an error occurs*/
                throw ex;
            }
        }
    }
}