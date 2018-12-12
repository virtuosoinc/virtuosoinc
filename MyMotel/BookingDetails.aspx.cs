using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using MyMotel.Components;

namespace MyMotel
{
    public partial class BookingDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = GetBookingDetails();
                LoadBookingDetails(ds);
            }

        }

        protected void BookingDetailsGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int bookingId = Convert.ToInt32(BookingDetailsGrid.DataKeys[e.RowIndex].Values["BookingId"].ToString());
                int inserted = 0;
                string QryString = "Update RoomBooking set BookingStatus=0 where BookingId=" + bookingId;
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                SqlCommand CmdObj = new SqlCommand(QryString, conn);
                conn.Open();
                inserted = CmdObj.ExecuteNonQuery();
                conn.Close();
                if (inserted > 0)
                {
                    int userId = Convert.ToInt32(Convert.ToString(Session["UserId"]));
                    string motelName = BookingDetailsGrid.DataKeys[e.RowIndex].Values["MotelName"].ToString();
                    DataSet dsUserDetails = GetUserDetails(userId);
                    string emailAddress = dsUserDetails.Tables[0].Rows[0]["Email"].ToString();
                    Email email = new Email();
                    bool test = email.SendEmail("Motel Cancellation", "Hi,<br/>Your booking for the hotel has been cancelled" + motelName + ". <br/> Thanks,<br/>Support Team.", emailAddress);

                    lblSuccessMessage.Text = "<h2>Motel Cancelled Successfully</h2>";
                    DataSet dsMotelDetails = GetBookingDetails();
                    LoadBookingDetails(dsMotelDetails);
                    //Response.Redirect("Home.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LoadBookingDetails(DataSet ds)
        {
            try
            {

                if (ds.Tables[0].Rows.Count == 0)
                {
                    messagelbl.Text = "No Bookings";
                }
                BookingDetailsGrid.DataSource = ds;
                BookingDetailsGrid.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetBookingDetails()
        {
            try
            {
                string userId = Convert.ToString(Session["UserId"]);
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(@"select BookingId, MotelDetails1.MotelId, RoomsBooked, CheckinDate, CheckoutDate, BookingStatus, MotelName, [Address], StarCategory=
      CASE StarCategory
         WHEN '3' THEN '3 of 3'
         WHEN '2' THEN '2 of 3'
         WHEN '1' THEN '1 of 3'         
         ELSE ''
      END from RoomBooking
                                            left join (select MotelId, MotelName, [Address], StarCategory  from dbo.MotelDetails) as MotelDetails1 ON RoomBooking.MotelId = MotelDetails1.MotelId
                                             where UserId=" + userId + " and BookingStatus=1", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetUserDetails(int userId)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from UserDetails where UserId=" + userId, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void BookingDetailsGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {

                BookingDetailsGrid.PageIndex = e.NewPageIndex;
                DataSet ds = GetBookingDetails();
                LoadBookingDetails(ds);
            }

         catch (Exception ex)
            {
                throw ex;
            }   
        
    }

        protected void BookingDetailsGrid_rowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    TableCell statusCell = e.Row.Cells[3];
                    TableCell statusCell1 = e.Row.Cells[7];
                    LinkButton lnkCancel = (LinkButton)statusCell1.FindControl("lnkCancel");
                    HyperLink lnkUpdate = (HyperLink)statusCell1.FindControl("lnkUpdate");
                    LinkButton lnkUpdate1 = (LinkButton)statusCell1.FindControl("lnkUpdate1");
                    DateTime checkinDate = Convert.ToDateTime(statusCell.Text);
                    int dateDiff = checkinDate.Subtract(System.DateTime.Now).Days;
                    if (dateDiff < 1)
                    {
                        //lnkCancel.Visible = false;
                        lnkCancel.OnClientClick = "alert('You can cancel motel reservation only before 24Hours');return false;";
                        lnkUpdate1.OnClientClick = "alert('You can update motel reservation only before 24Hours');return false;";
                        lnkUpdate.Visible = false;
                    }
                    else {
                        lnkUpdate1.Visible = false;
                    }             
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
        
    }
    
}