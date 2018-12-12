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
    public partial class UpdateMotel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblupdatemessage.Visible = false;

            if (!IsPostBack)
            {
                LoadMotelDetails();
            }
        }


        protected void MotelDetailsGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {

                lblupdatemessage.Visible = true;

                int motelId = Convert.ToInt32(MotelDetailsGrid.DataKeys[e.RowIndex].Values["MotelId"].ToString());
                int deleted = 0;
                string QryString = "Update MotelDetails SET Deleted=1 WHERE MotelId=" + motelId;
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                SqlCommand CmdObj = new SqlCommand(QryString, conn);
                conn.Open();
                deleted = CmdObj.ExecuteNonQuery();
                conn.Close();
                if (deleted > 0)
                {
                    string updatemessage;
                    lblupdatemessage.Text = "<strong>Motel deleted Successfully</strong>";
                    updatemessage = lblupdatemessage.Text;
                    ClientScript.RegisterStartupScript(this.GetType(), "yourMessage", updatemessage, true);
                    LoadMotelDetails();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void LoadMotelDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                con.Open();
                string searchQuery = string.Empty;
                searchQuery = @"select MotelId, MotelName, [Address], City, Pincode, [State], TelephoneNumber, StarCategory=
      CASE StarCategory
         WHEN '3' THEN '3 of 3'
         WHEN '2' THEN '2 of 3'
         WHEN '1' THEN '1 of 3'         
         ELSE ''
      END  from dbo.MotelDetails WHERE Deleted != 1";
                SqlCommand cmd = new SqlCommand(searchQuery, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                MotelDetailsGrid.DataSource = ds;
                MotelDetailsGrid.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}