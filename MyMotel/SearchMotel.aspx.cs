using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace MyMotel
{
    public partial class SearchMotel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadCities();
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = string.Empty;
                string city = ddlCity.SelectedItem.Text;
                int citySelected = Convert.ToInt32(ddlCity.SelectedValue);
                int rating = Convert.ToInt32(StarCategory.SelectedValue);

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                con.Open();
                string searchQuery = string.Empty;
                if (citySelected != 0 && rating != 0)
                {
                    searchQuery = @"select M.MotelId, MotelName, [Address], City, Pincode, [State], TelephoneNumber, StarCategory = CASE StarCategory
         WHEN '3' THEN '3 of 3'
         WHEN '2' THEN '2 of 3'
         WHEN '1' THEN '1 of 3'        
         ELSE ''
      END  from dbo.MotelDetails  M, RoomAvailability R 
                            where R.MotelId = M.MotelId and (SingleBHK > 0 or DoubleBHK > 0 or TripleBHK > 0) and City like '%" + city + "%' and StarCategory=" + rating;
                }
                else if (citySelected != 0)
                {
                    searchQuery = @"select M.MotelId, MotelName, [Address], City, Pincode, [State], TelephoneNumber, StarCategory = CASE StarCategory
         WHEN '3' THEN '3 of 3'
         WHEN '2' THEN '2 of 3'
         WHEN '1' THEN '1 of 3'         
         ELSE ''
      END  from dbo.MotelDetails  M, RoomAvailability R 
                            where R.MotelId = M.MotelId and (SingleBHK > 0 or DoubleBHK > 0 or TripleBHK > 0) and City like '%" + city + "%'";
                }
                else if (rating != 0)
                {
                    searchQuery = @"select M.MotelId, MotelName, [Address], City, Pincode, [State], TelephoneNumber, StarCategory =  CASE StarCategory
         WHEN '3' THEN '3 of 3'
         WHEN '2' THEN '2 of 3'
         WHEN '1' THEN '1 of 3'         
         ELSE ''
      END  from dbo.MotelDetails M, RoomAvailability R 
                            where R.MotelId = M.MotelId and (SingleBHK > 0 or DoubleBHK > 0 or TripleBHK > 0) and StarCategory=" + rating;
                }

                if (rating != 0)
                {
                    SerchResultsGrid.Columns[6].Visible = false;
                }
                else
                {
                    SerchResultsGrid.Columns[6].Visible = true;
                }
                SqlCommand cmd = new SqlCommand(searchQuery, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                SerchResultsGrid.DataSource = ds;
                SerchResultsGrid.DataBind();
                if (ds.Tables[0].Rows.Count == 0)
                {
                    lblMessage.Text = "No Data Found";
                    btnReserver.Visible = false;
                    lblReserveMessage.Visible = false;
                    searchField.Visible = false;
                }
                else
                {
                    lblReserveMessage.Visible = true;
                    btnReserver.Visible = true;
                    searchField.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LoadCities()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select ROW_NUMBER() over (Order by State) as CityId, City from StateAndCity", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                ddlCity.DataSource = ds;
                ddlCity.DataTextField = "City";
                ddlCity.DataValueField = "CityId";
                ddlCity.DataBind();
                ddlCity.Items.Insert(0, new ListItem("Select City", "0"));
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnReserver_Click(object sender, EventArgs e)
        {
            try
            {

                string bookingIds = string.Empty;
                // Iterate through the Products.Rows property
                foreach (GridViewRow row in SerchResultsGrid.Rows)
                {
                    // Access the CheckBox
                    CheckBox cb = (CheckBox)row.FindControl("cbSelect");
                    if (cb != null && cb.Checked)
                    {
                        int BookingId =
                            Convert.ToInt32(SerchResultsGrid.DataKeys[row.RowIndex].Values["MotelId"]);
                        bookingIds += BookingId + ",";
                    }
                }
                if (bookingIds.Length > 0)
                {
                    bookingIds = bookingIds.Substring(0, bookingIds.Length - 1);
                    Session["MotelIds"] = bookingIds;
                    Response.Redirect("BookMotel.aspx?motelIds=" + bookingIds);
                }
                else
                {
                    Label1.Text = "Please select atleast one motel";
                }

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        //protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int citySelected = Convert.ToInt32(ddlCity.SelectedValue);
        //    if (citySelected > 0)
        //    {
        //        StarCategory.Enabled = true;
        //    }
        //    else {
        //        StarCategory.Enabled = false;
        //    }
            
        //}

        //protected void StarCategory_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int rating = Convert.ToInt32(StarCategory.SelectedValue);
        //    if (rating > 0)
        //    {
        //        ddlCity.Enabled = false;
        //    }
        //    else
        //    {
        //        ddlCity.Enabled = true;
        //    }
        //}
    }
}