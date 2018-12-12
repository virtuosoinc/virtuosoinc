using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Test
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["LoggedIn"]))
            {
                if (Convert.ToBoolean(Session["IsAdmin"]))
                {
                    NavigationMenu.Visible = false;
                    UserNavigationMenu.Visible = false;
                    InformationMenu.Visible = false;
                    AdminNavigationMenu.Visible = true;
                }
                else {

                    NavigationMenu.Visible = false;
                    UserNavigationMenu.Visible = true;
                    InformationMenu.Visible = false;
                    AdminNavigationMenu.Visible = false;
                }
               
            }
            else {
                NavigationMenu.Visible = true;
                UserNavigationMenu.Visible = false;
                InformationMenu.Visible = true;
                AdminNavigationMenu.Visible = false;
            }
        }
    }
}
