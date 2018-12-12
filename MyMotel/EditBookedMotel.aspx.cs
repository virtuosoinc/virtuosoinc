using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using MyMotel.Components;

namespace MyMotel
{
    public partial class EditBookedMotel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int motelId = Convert.ToInt32(Request.QueryString["motelId"]);
                int bookingId = Convert.ToInt32(Request.QueryString["bookingId"]);
                DataSet dsMotelDetails = GetRoomsAvailabilityDetails(motelId);
                int singleBHKCount = Convert.ToInt32(dsMotelDetails.Tables[0].Rows[0]["SingleBHK"]);
                int doubleBHKCount = Convert.ToInt32(dsMotelDetails.Tables[0].Rows[0]["DoubleBHK"]);
                int tripleBHKCount = Convert.ToInt32(dsMotelDetails.Tables[0].Rows[0]["TripleBHKCost"]);
                int singleBHKCost = Convert.ToInt32(dsMotelDetails.Tables[0].Rows[0]["SingleBHKCost"]);
                int doubleBHKCost = Convert.ToInt32(dsMotelDetails.Tables[0].Rows[0]["DoubleBHKCost"]);
                int tripleBHKCost = Convert.ToInt32(dsMotelDetails.Tables[0].Rows[0]["TripleBHKCost"]);
                DataSet dsBookingDetails = GetRoomBookingDetails(bookingId);

                string motelName = dsBookingDetails.Tables[0].Rows[0]["MotelName"].ToString();
                string motelAddess = dsBookingDetails.Tables[0].Rows[0]["Address"].ToString();
                string cost = string.Empty;
                string roomsAvailable = string.Empty;
                //string imageFolder = dsBookingDetails.Tables[0].Rows[0]["ImageFolder"].ToString();
                int roomTypeId = Convert.ToInt32(dsBookingDetails.Tables[0].Rows[0]["RoomTypeId"]);
                int personLimit = 0;
                if (roomTypeId == 1)
                {
                    roomsAvailable = singleBHKCount.ToString();
                    cost = singleBHKCost.ToString();
                    personLimit = 2;
                    //if (singleBHKCount == 0)
                    //{
                    //    DisableFields();
                    //}
                }
                else
                    if (roomTypeId == 2)
                    {
                        roomsAvailable = doubleBHKCount.ToString();
                        cost = doubleBHKCost.ToString();
                        personLimit = 4;
                        //if (doubleBHKCount == 0)
                        //{
                        //    DisableFields();
                        //}
                    }
                    else
                        if (roomTypeId == 3)
                        {
                            roomsAvailable = tripleBHKCount.ToString();
                            cost = tripleBHKCost.ToString();
                            personLimit = 6;
                            //if (tripleBHKCount == 0)
                            //{
                            //    DisableFields();
                            //}
                        }
                lblAdults.Text = personLimit.ToString();
                lblmotelName.Text = motelName;
                lbladdress.Text = motelAddess;
                lblCost.Text = cost;
                lblRoomsAvailable.Text = roomsAvailable;
                //string strpath = Server.MapPath("~/MotelImages/" + imageFolder);
                //string[] folders = Directory.GetFiles(strpath, "*", SearchOption.AllDirectories);
                //string[] fileParts = folders[0].Split('\\');
                //hotelImage.ImageUrl = "~/MotelImages/" + imageFolder + "/" + fileParts[fileParts.Length - 1];
                ddlRoomType.SelectedIndex = roomTypeId;
                txtCheckinDate.Text = dsBookingDetails.Tables[0].Rows[0]["CheckinDate"].ToString().Substring(0, 10).Trim();
                txtCheckoutDate.Text = dsBookingDetails.Tables[0].Rows[0]["CheckoutDate"].ToString().Substring(0, 10).Trim();
                ddlAdultCount.SelectedIndex = Convert.ToInt32(dsBookingDetails.Tables[0].Rows[0]["AdultCount"]);
                ddlChildrenCount.SelectedIndex = Convert.ToInt32(dsBookingDetails.Tables[0].Rows[0]["ChildrenCount"]);
                ddlroomsCount.SelectedIndex = Convert.ToInt32(dsBookingDetails.Tables[0].Rows[0]["RoomsBooked"]);
                hdnRoomsCount.Value = dsBookingDetails.Tables[0].Rows[0]["RoomsBooked"].ToString();
                lblTotalCostVal.Text = dsBookingDetails.Tables[0].Rows[0]["TotalCost"].ToString();
            }
        }

        //public void DisableFields()
        //{
        //    txtCheckinDate.Enabled = false;
        //    txtCheckoutDate.Enabled = false;
        //    ddlAdultCount.Enabled = false;
        //    ddlChildrenCount.Enabled = false;
        //    ddlroomsCount.Enabled = false;
        //}

        //public void EnableFields()
        //{
        //    txtCheckinDate.Enabled = true;
        //    txtCheckoutDate.Enabled = true;
        //    ddlAdultCount.Enabled = true;
        //    ddlChildrenCount.Enabled = true;
        //    ddlroomsCount.Enabled = true;
        //}

        public DataSet GetRoomBookingDetails(int bookingId)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select M.MotelName,M.[Address],R.* from MotelDetails M,RoomBooking R where R.MotelId=M.MotelId and R.BookingId=" + bookingId, con);
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
        public DataSet GetRoomsAvailabilityDetails(int motelId)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from RoomAvailability where MotelId=" + motelId, con);
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

        protected void ddlRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int roomTypeId = Convert.ToInt32(ddlRoomType.SelectedValue);

            int motelId = Convert.ToInt32(Request.QueryString["motelId"]);
            DataSet dsMotelDetails = GetRoomsAvailabilityDetails(motelId);
            int singleBHKCount = Convert.ToInt32(dsMotelDetails.Tables[0].Rows[0]["SingleBHK"]);
            int doubleBHKCount = Convert.ToInt32(dsMotelDetails.Tables[0].Rows[0]["DoubleBHK"]);
            int tripleBHKCount = Convert.ToInt32(dsMotelDetails.Tables[0].Rows[0]["TripleBHK"]);
            int singleBHKCost = Convert.ToInt32(dsMotelDetails.Tables[0].Rows[0]["SingleBHKCost"]);
            int doubleBHKCost = Convert.ToInt32(dsMotelDetails.Tables[0].Rows[0]["DoubleBHKCost"]);
            int tripleBHKCost = Convert.ToInt32(dsMotelDetails.Tables[0].Rows[0]["TripleBHKCost"]);
            string cost = string.Empty;
            string roomsAvailable = string.Empty;
            int personLimit = 0;
            //EnableFields();
            if (roomTypeId == 1)
            {
                roomsAvailable = singleBHKCount.ToString();
                cost = singleBHKCost.ToString();
                personLimit = 2;
                //if (singleBHKCount == 0)
                //{
                //    DisableFields();
                //}
            }
            else
                if (roomTypeId == 2)
                {
                    roomsAvailable = doubleBHKCount.ToString();
                    cost = doubleBHKCost.ToString();
                    personLimit = 4;
                    //if (doubleBHKCount == 0)
                    //{
                    //    DisableFields();
                    //}
                }
                else
                    if (roomTypeId == 3)
                    {
                        roomsAvailable = tripleBHKCount.ToString();
                        cost = tripleBHKCost.ToString();
                        personLimit = 6;
                        //if (tripleBHKCount == 0)
                        //{
                        //    DisableFields();
                        //}
                    }
            lblCost.Text = cost;
            lblRoomsAvailable.Text = roomsAvailable;
            lblAdults.Text = personLimit.ToString();

        }

        protected void UpdateMotelButton_Click(object sender, EventArgs e)
        {
            lblRoomLimitError.Text = string.Empty;
            int bookingId = Convert.ToInt32(Request.QueryString["bookingId"]);
            string checkinDate = txtCheckinDate.Text;
            string checkoutDate = txtCheckoutDate.Text;
            int roomTypeId = Convert.ToInt32(ddlRoomType.SelectedValue);
            int adultsCount = Convert.ToInt32(ddlAdultCount.SelectedValue);
            int childrenCount = Convert.ToInt32(ddlChildrenCount.SelectedValue);
            int roomsCount = Convert.ToInt32(ddlroomsCount.SelectedValue);
            int cost = CalculateCost();
            int inserted = 0;
            int bookingMotelId = Convert.ToInt32(Request.QueryString["motelId"]);
            int personCount = 0;

            int oldroomsCount = Convert.ToInt32(hdnRoomsCount.Value);
            int availableRoomsCount = Convert.ToInt32(lblRoomsAvailable.Text);
            int roomCount = Convert.ToInt32(ddlroomsCount.SelectedValue);
            if (roomCount <= (availableRoomsCount + oldroomsCount))
            {
                switch (roomTypeId)
                {
                    case 1: personCount = 2;
                        break;
                    case 2: personCount = 4;
                        break;
                    case 3: personCount = 6;
                        break;
                }
                if ((adultsCount + childrenCount) <= ((roomsCount * personCount) + 1))
                {
                    string QryString = "update RoomBooking set RoomsBooked=" + roomsCount + ", CheckinDate='" + checkinDate + "', CheckoutDate='" + checkoutDate + "', TotalCost=" + cost + ", AdultCount=" + adultsCount + ",ChildrenCount=" + childrenCount + ",RoomTypeId=" + roomTypeId + " Where BookingId=" + bookingId;
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                    SqlCommand CmdObj = new SqlCommand(QryString, conn);
                    conn.Open();
                    inserted = CmdObj.ExecuteNonQuery();
                    if (inserted > 0)
                    {
                        int motelId = Convert.ToInt32(Request.QueryString["motelId"]);
                        UpdateRoomAvailability(motelId, roomTypeId, roomsCount, availableRoomsCount + oldroomsCount);
                        Email email = new Email();
                        int userId = Convert.ToInt32(Session["UserId"]);
                        DataSet dsMotelDetails = GetMotelDetails(motelId);
                        DataSet dsUserDetails = GetUserDetails(userId);
                        string motelName = dsMotelDetails.Tables[0].Rows[0]["MotelName"].ToString();
                        string address = dsMotelDetails.Tables[0].Rows[0]["Address"].ToString();
                        string emailAddress = dsUserDetails.Tables[0].Rows[0]["Email"].ToString();
                        bool test = email.SendEmail("Motel Booking Update Details", "Hi,<br/>Booking details updated the Motel" + motelName + ". Your Booking Details are as follows.<br/><b>Motel Name:</b>" + motelName + " <b>Address:</b>" + address + ". <b/> Thanks,<br/>Support Team.", emailAddress);
                        string motelEmail = dsMotelDetails.Tables[0].Rows[0]["Email"].ToString();
                        test = email.SendEmail("Motel Booking Update Details", "Hi,<br/>Booking details updated" + motelName + ". Your Booking Details are as follows.<br/><b>Motel Name:</b>" + motelName + " <b>Address:</b>" + address + ". <b/> Thanks,<br/>Support Team.", motelEmail);

                        ClientScript.RegisterStartupScript(this.GetType(), "yourMessage", "successMessage();", true);
                    }
                    conn.Close();
                }
                else
                {
                    lblRoomLimitError.Text = "Person count exceeding the Limit";

                }
            }
            else {
                lblRoomLimitError.Text = "Selected number of rooms not available";
            }
        }

        public int CalculateCost()
        {
            int personCount = 0;
            int roomTypeId = Convert.ToInt32(ddlRoomType.SelectedValue);
            switch (roomTypeId)
            {
                case 1: personCount = 2;
                    break;
                case 2: personCount = 4;
                    break;
                case 3: personCount = 6;
                    break;
            }
            int adultsCount = Convert.ToInt32(ddlAdultCount.SelectedValue);
            int childrenCount = Convert.ToInt32(ddlChildrenCount.SelectedValue);
            int roomsCount = Convert.ToInt32(ddlroomsCount.SelectedValue);
            int extraPersons = (Convert.ToInt32(adultsCount + childrenCount) - (personCount * Convert.ToInt32(ddlroomsCount.SelectedValue)));
            int totalCost = (Convert.ToInt32(ddlroomsCount.SelectedValue) * Convert.ToInt32(lblCost.Text));
            if (extraPersons > 0)
            {
                totalCost += extraPersons * 10;
            }
            DateTime checkinDate = Convert.ToDateTime(txtCheckinDate.Text);
            DateTime checkoutDate = Convert.ToDateTime(txtCheckoutDate.Text);
            int days = checkoutDate.Subtract(checkinDate).Days + 1;
            totalCost = (totalCost * days);
            return totalCost;
        }

        protected void UpdateCostButton_Click(object sender, EventArgs e)
        {
            int totalCost = CalculateCost();
            lblTotalCostVal.Text = totalCost.ToString();
        }

        public void UpdateRoomAvailability(int MotelId, int RoomTypeid, int Selectedcount, int existingCount)
        {
            int inserted = 0;
            string QryString = string.Empty;
            int currentAvailableCount = existingCount - Selectedcount;
            switch (RoomTypeid)
            {
                case 1: QryString = "Update RoomAvailability set SingleBHK=" + currentAvailableCount + " where MotelId=" + MotelId;
                    break;
                case 2: QryString = "Update RoomAvailability set DoubleBHK=" + currentAvailableCount + " where MotelId=" + MotelId;
                    break;
                case 3: QryString = "Update RoomAvailability set TripleBHK=" + currentAvailableCount + " where MotelId=" + MotelId;
                    break;

            }

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
            SqlCommand CmdObj = new SqlCommand(QryString, conn);
            conn.Open();
            inserted = CmdObj.ExecuteNonQuery();
            conn.Close();
        }

        public DataSet GetMotelDetails(int motelId)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select M.*,SingleBHK,DoubleBHK,TripleBHK from MotelDetails M, RoomAvailability R where M.MotelId=R.MotelId and M.MotelId=" + motelId, con);
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
    }
}