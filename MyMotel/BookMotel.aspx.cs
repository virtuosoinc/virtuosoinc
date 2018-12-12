using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;
using MyMotel.Components;
using System.Collections;

namespace MyMotel
{
    public partial class BookMotel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    string motelIds = Request.QueryString["motelIds"];
                    if (!Convert.ToBoolean(Session["LoggedIn"]))
                    {
                        Response.Redirect("Login.aspx?page=Booking&&MotelIds=" + motelIds);
                    }
                    DataSet ds = GetMotelsDetails(motelIds);
                    repeater_Motels.DataSource = ds;
                    repeater_Motels.DataBind();
                    //string motelName = ds.Tables[0].Rows[0]["MotelName"].ToString();
                    //string address = ds.Tables[0].Rows[0]["Address"].ToString();
                    //string imageFolder = ds.Tables[0].Rows[0]["ImageFolder"].ToString();
                    //lblmotelName.Text = motelName;
                    //lbladdress.Text = address;
                    //lblCost.Text = ds.Tables[0].Rows[0]["Cost"].ToString();
                    //lblRoomsAvailable.Text = ds.Tables[0].Rows[0]["RoomsAvailable"].ToString();
                    //string strpath = Server.MapPath("~/MotelImages/" + imageFolder);
                    //string[] folders = Directory.GetFiles(strpath, "*", SearchOption.AllDirectories);
                    //string[] fileParts = folders[0].Split('\\');
                    //hotelImage.ImageUrl = "~/MotelImages/" + imageFolder + "/" + fileParts[fileParts.Length - 1];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected void BookRoombtn1_Click(object sender, EventArgs e)
        {
            try
            {

                bool isDatesOverlapping = false;
                if (Convert.ToBoolean(CheckDates.Value))
                {
                    int count = repeater_Motels.Items.Count;
                    List<DateTime>[] list = new List<DateTime>[count];
                    int i = 0;
                    foreach (RepeaterItem item in repeater_Motels.Items)
                    {
                        TextBox txtCheckinDate = (TextBox)item.FindControl("txtCheckinDate");
                        TextBox txtCheckoutDate = (TextBox)item.FindControl("txtCheckoutDate");
                        list[i] = new List<DateTime>();
                        list[i].Add(Convert.ToDateTime(txtCheckinDate.Text));
                        list[i].Add(Convert.ToDateTime(txtCheckoutDate.Text));
                        i++;
                    }
                    for (int j = 0; j < list.Length; j++)
                    {
                        for (int k = 0; k < list.Length; k++)
                        {
                            if (j != k)
                            {
                                List<DateTime> list1 = list[j];
                                List<DateTime> list2 = list[k];
                                if ((list1[0] >= list2[0] && list1[0] <= list2[1]) || (list1[1] >= list2[0] && list1[1] <= list2[1]))
                                {
                                    isDatesOverlapping = true;
                                }
                            }
                        }

                    }
                }
                bool invalidData = false;
                //if (isDatesOverlapping)
                //{
                //    ClientScript.RegisterStartupScript(typeof(Page), "exampleScript", "if(confirm('Booking Dates are overalpping for the selected motels. Are you sure to Book?')) { bookMotel(); } ", true);
                //}
                //else
                //{
                //    ClientScript.RegisterStartupScript(typeof(Page), "exampleScript", "bookMotel();", true);
                //}
                if (isDatesOverlapping)
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "exampleScript", "bookMotel();", true);
                }
                else
                {
                    foreach (RepeaterItem item in repeater_Motels.Items)
                    {
                        Label lblRoomsAvailable = (Label)item.FindControl("lblRoomsAvailable");
                        DropDownList ddlroomsCount = (DropDownList)item.FindControl("ddlroomsCount");
                        int availableRoomsCount = Convert.ToInt32(lblRoomsAvailable.Text);
                        int roomCount = Convert.ToInt32(ddlroomsCount.SelectedValue);
                        Label lblRoomLimitError = (Label)item.FindControl("lblRoomLimitError");
                        if (roomCount <= availableRoomsCount)
                        {
                            lblRoomLimitError.Text = string.Empty;
                        }
                        else
                        {
                            invalidData = true;
                            lblRoomLimitError.Text = "Selected number of rooms not available";
                        }
                        if (!invalidData)
                        {
                            DropDownList ddlAdultCount = (DropDownList)item.FindControl("ddlAdultCount");
                            DropDownList ddlChildrenCount = (DropDownList)item.FindControl("ddlChildrenCount");
                            DropDownList ddlRoomType = (DropDownList)item.FindControl("ddlRoomType");
                            int roomTypeId = Convert.ToInt32(ddlRoomType.SelectedValue);
                            int personCount = 0;

                            switch (roomTypeId)
                            {
                                case 1: personCount = 2;
                                    break;
                                case 2: personCount = 4;
                                    break;
                                case 3: personCount = 6;
                                    break;
                            }
                            int adultCount = Convert.ToInt32(ddlAdultCount.SelectedValue);
                            int childrenCount = Convert.ToInt32(ddlChildrenCount.SelectedValue);
                            if ((adultCount + childrenCount) <= (roomCount * (personCount + 1)))
                            {
                                lblRoomLimitError.Text = string.Empty;
                            }
                            else
                            {
                                invalidData = true;
                                lblRoomLimitError.Text = "Person count exceeding the Limit";
                            }
                        }
                    }

                    if (!invalidData)
                    {
                        foreach (RepeaterItem item in repeater_Motels.Items)
                        {
                            Label lblRoomsAvailable = (Label)item.FindControl("lblRoomsAvailable");
                            DropDownList ddlroomsCount = (DropDownList)item.FindControl("ddlroomsCount");
                            int availableRoomsCount = Convert.ToInt32(lblRoomsAvailable.Text);
                            int roomCount = Convert.ToInt32(ddlroomsCount.SelectedValue);

                            //if (roomCount <= availableRoomsCount && !invalidData)
                            //{
                            DropDownList ddlAdultCount = (DropDownList)item.FindControl("ddlAdultCount");
                            DropDownList ddlChildrenCount = (DropDownList)item.FindControl("ddlChildrenCount");
                            DropDownList ddlRoomType = (DropDownList)item.FindControl("ddlRoomType");
                            int roomTypeId = Convert.ToInt32(ddlRoomType.SelectedValue);
                            int personCount = 0;

                            switch (roomTypeId)
                            {
                                case 1: personCount = 2;
                                    break;
                                case 2: personCount = 4;
                                    break;
                                case 3: personCount = 6;
                                    break;
                            }
                            int adultCount = Convert.ToInt32(ddlAdultCount.SelectedValue);
                            int childrenCount = Convert.ToInt32(ddlChildrenCount.SelectedValue);
                            //if ((adultCount + childrenCount) <= (roomCount * (personCount + 1)) && !invalidData)
                            //{
                            TextBox txtCheckinDate = (TextBox)item.FindControl("txtCheckinDate");
                            TextBox txtCheckoutDate = (TextBox)item.FindControl("txtCheckoutDate");
                            Label lblSelectedCheckinDate = (Label)item.FindControl("lblSelectedCheckinDate");
                            Label lblSelectedCheckoutDate = (Label)item.FindControl("lblSelectedCheckoutDate");
                            Label lblSelectedRoomCount = (Label)item.FindControl("lblSelectedRoomCount");
                            Label lblCost = (Label)item.FindControl("lblCost");
                            Label lblTotalCost = (Label)item.FindControl("lblTotalCost");
                            Label lblTotalCostVal = (Label)item.FindControl("lblTotalCostVal");
                            Label lblRoomType = (Label)item.FindControl("lblRoomType");
                            Label lblAdultCount = (Label)item.FindControl("lblAdultCount");
                            Label lblChildrenCount = (Label)item.FindControl("lblChildrenCount");
                            HiddenField hdnRoomTypeSelected = (HiddenField)item.FindControl("hdnRoomTypeSelected");
                            hdnRoomTypeSelected.Value = ddlRoomType.SelectedValue;

                            int extraPersons = (Convert.ToInt32(adultCount + childrenCount) - (personCount * Convert.ToInt32(ddlroomsCount.SelectedValue)));
                            int totalCost = (Convert.ToInt32(ddlroomsCount.SelectedValue) * Convert.ToInt32(lblCost.Text));
                            if (extraPersons > 0)
                            {
                                totalCost += extraPersons * 10;
                            }
                            DateTime checkinDate = Convert.ToDateTime(txtCheckinDate.Text);
                            DateTime checkoutDate = Convert.ToDateTime(txtCheckoutDate.Text);
                            int days = checkoutDate.Subtract(checkinDate).Days + 1;
                            totalCost = (totalCost * days);
                            lblTotalCostVal.Text = totalCost.ToString();
                            lblSelectedCheckinDate.Text = txtCheckinDate.Text;
                            lblSelectedCheckoutDate.Text = txtCheckoutDate.Text;
                            lblSelectedRoomCount.Text = ddlroomsCount.SelectedValue;
                            lblRoomType.Text = ddlRoomType.SelectedItem.Text;
                            lblAdultCount.Text = ddlAdultCount.SelectedItem.Text;
                            txtCheckinDate.Visible = false;
                            txtCheckoutDate.Visible = false;
                            lblSelectedCheckinDate.Visible = true;
                            lblSelectedCheckoutDate.Visible = true;
                            BookRoombtn1.Visible = false;
                            BookRoombtn.Visible = true;
                            ddlroomsCount.Visible = false;
                            lblSelectedRoomCount.Visible = true;
                            lblTotalCost.Visible = true;
                            lblTotalCostVal.Visible = true;
                            lblRoomType.Visible = true;
                            lblAdultCount.Visible = true;
                            ddlRoomType.Visible = false;
                            ddlAdultCount.Visible = false;
                            ddlChildrenCount.Visible = false;
                            lblChildrenCount.Visible = true;
                            lblChildrenCount.Text = ddlChildrenCount.SelectedItem.Text;
                            Label lblRoomLimitError = (Label)item.FindControl("lblRoomLimitError");
                            lblRoomLimitError.Text = string.Empty;
                            Label lblUserName = (Label)item.FindControl("lblUserName");
                            lblUserName.Text = Session["UserName"].ToString();
                            Label lblDateFormat = (Label)item.FindControl("lblDateFormat");
                            Label lblDateFormat1 = (Label)item.FindControl("lblDateFormat1");
                            Label lblResrved = (Label)item.FindControl("lblResrved");
                            lblDateFormat.Visible = false;
                            lblDateFormat1.Visible = false;
                            lblResrved.Visible = true;
                            //}
                            //else
                            //{
                            //    invalidData = true;
                            //    if (!((adultCount + childrenCount) <= (roomCount * (personCount + 1))))
                            //    {
                            //        Label lblRoomLimitError = (Label)item.FindControl("lblRoomLimitError");
                            //        lblRoomLimitError.Text = "Person count exceeding the Limit";
                            //    }

                            //}
                            //}
                            //else
                            //{
                            //    invalidData = true;
                            //    if (!(roomCount <= availableRoomsCount))
                            //    {
                            //        Label lblRoomLimitError = (Label)item.FindControl("lblRoomLimitError");
                            //        lblRoomLimitError.Text = "Slected rooms count is not available";
                            //    }
                            //}
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void BookRoombtn_Click(object sender, EventArgs e)
        {
            try
            {
                int count = repeater_Motels.Items.Count;
                BookRoombtn1.Visible = true;
                BookRoombtn.Visible = false;
                foreach (RepeaterItem item in repeater_Motels.Items)
                {
                    Label lblMotelName = (Label)item.FindControl("lblmotelName");
                    Label lbladdress = (Label)item.FindControl("lbladdress");
                    Label lblCost = (Label)item.FindControl("lblCost");
                    Label lblRoomsAvailable = (Label)item.FindControl("lblRoomsAvailable");
                    TextBox txtCheckinDate = (TextBox)item.FindControl("txtCheckinDate");
                    TextBox txtCheckoutDate = (TextBox)item.FindControl("txtCheckoutDate");
                    DropDownList ddlroomsCount = (DropDownList)item.FindControl("ddlroomsCount");
                    HiddenField hdnMotelId = (HiddenField)item.FindControl("hdnMotelId");
                    Label lblTotalCostVal = (Label)item.FindControl("lblTotalCostVal");
                    int totalCost = Convert.ToInt32(lblTotalCostVal.Text);
                    Label lblAdultCount = (Label)item.FindControl("lblAdultCount");
                    Label lblChildrenCount = (Label)item.FindControl("lblChildrenCount");
                    HiddenField hdnRoomTypeSelected = (HiddenField)item.FindControl("hdnRoomTypeSelected");

                    int motelId = Convert.ToInt32(hdnMotelId.Value);
                    DateTime checkinDate = Convert.ToDateTime(txtCheckinDate.Text);
                    DateTime checkoutDate = Convert.ToDateTime(txtCheckoutDate.Text);
                    bool isBookingOverlaping = CheckBookingHistory(motelId, checkinDate, checkoutDate);
                    if (!isBookingOverlaping)
                    {
                        int roomsCount = Convert.ToInt32(ddlroomsCount.SelectedValue);
                        int userId = Convert.ToInt32(Session["UserId"]);

                        int inserted = 0;
                        string QryString = "insert into RoomBooking values(" + userId + "," + motelId + "," + roomsCount + ",'" + checkinDate + "','" + checkoutDate + "'," + 1 + "," + totalCost + "," + Convert.ToInt32(lblAdultCount.Text) + "," + Convert.ToInt32(lblChildrenCount.Text) + "," + Convert.ToInt32(hdnRoomTypeSelected.Value) + ")";
                        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                        SqlCommand CmdObj = new SqlCommand(QryString, conn);
                        conn.Open();
                        inserted = CmdObj.ExecuteNonQuery();
                        conn.Close();
                        if (inserted > 0)
                        {

                            Email email = new Email();
                            DataSet dsMotelDetails = GetMotelDetails(motelId);
                            int roomTypeId = Convert.ToInt32(hdnRoomTypeSelected.Value);
                            int existingRoomCount = 0;
                            switch (roomTypeId)
                            {
                                case 1: existingRoomCount = Convert.ToInt32(dsMotelDetails.Tables[0].Rows[0]["SingleBHK"]);
                                    break;
                                case 2: existingRoomCount = Convert.ToInt32(dsMotelDetails.Tables[0].Rows[0]["DoubleBHK"]);
                                    break;
                                case 3: existingRoomCount = Convert.ToInt32(dsMotelDetails.Tables[0].Rows[0]["TripleBHK"]);
                                    break;

                            }
                            UpdateRoomAvailability(motelId, roomTypeId, roomsCount, existingRoomCount);
                            DataSet dsUserDetails = GetUserDetails(userId);
                            string motelName = dsMotelDetails.Tables[0].Rows[0]["MotelName"].ToString();
                            string address = dsMotelDetails.Tables[0].Rows[0]["Address"].ToString();
                            string emailAddress = dsUserDetails.Tables[0].Rows[0]["Email"].ToString();
                            bool test = email.SendEmail("Motel Booking Details", "Hi,<br/>Thanks for choosing the Motel" + motelName + ". Your Booking Details are as follows.<br/><b>Motel Name:</b>" + motelName + " <b>Address:</b>" + address + ". <b/> Thanks,<br/>Support Team.", emailAddress);
                            string motelEmail = dsMotelDetails.Tables[0].Rows[0]["Email"].ToString();
                            test = email.SendEmail("Motel Booking Details", "Hi,<br/>Thanks for choosing the Motel" + motelName + ". Your Booking Details are as follows.<br/><b>Motel Name:</b>" + motelName + " <b>Address:</b>" + address + ". <b/> Thanks,<br/>Support Team.", motelEmail);
                            ClientScript.RegisterStartupScript(this.GetType(), "yourMessage", "successMessage();", true);
                            //Response.Redirect("Home.aspx");
                        }
                    }
                    else
                    {
                        lblErrorMessage.Text = "Same Motel booked for same dates";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        public DataSet GetMotelsDetails(string motelIds)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select M.*,SingleBHK,DoubleBHK,TripleBHK from MotelDetails M, RoomAvailability R where M.MotelId=R.MotelId and M.MotelId in (" + motelIds + ")", con);
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

        public bool CheckBookingHistory(int motelId, DateTime checkinDate, DateTime checkoutDate)
        {
            try
            {
                int userId = Convert.ToInt32(Convert.ToString(Session["UserId"]));
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(@" select * from dbo.RoomBooking where MotelId=" + motelId + @" and BookingStatus=1 and UserId = " + userId + @"
            and ((CheckinDate <= '" + checkinDate + "' and CheckoutDate >='" + checkinDate + "') or (CheckinDate <= '" + checkoutDate + "' and CheckoutDate >='" + checkoutDate + "'))", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void repeater_Motels_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    DataRowView dataRow = (DataRowView)e.Item.DataItem;
                    string motelName = dataRow.Row.ItemArray[1].ToString();
                    string motelAddess = dataRow.Row.ItemArray[2].ToString();
                    //string cost = dataRow.Row.ItemArray[8].ToString();
                    //string roomsAvailable = dataRow.Row.ItemArray[11].ToString();
                    string imageFolder = dataRow.Row.ItemArray[8].ToString();
                    Label lblMotelName = (Label)e.Item.FindControl("lblmotelName");
                    Label lbladdress = (Label)e.Item.FindControl("lbladdress");
                    //Label lblCost = (Label)e.Item.FindControl("lblCost");
                    //                    Label lblRoomsAvailable = (Label)e.Item.FindControl("lblRoomsAvailable");
                    //Image hotelImage = (Image)e.Item.FindControl("hotelImage");
                    HiddenField hdnMotelId = (HiddenField)e.Item.FindControl("hdnMotelId");
                    HiddenField hdnRoomsType1Count = (HiddenField)e.Item.FindControl("hdnRoomsType1Count");
                    HiddenField hdnRoomsType2Count = (HiddenField)e.Item.FindControl("hdnRoomsType2Count");
                    HiddenField hdnRoomsType3Count = (HiddenField)e.Item.FindControl("hdnRoomsType3Count");
                    hdnRoomsType1Count.Value = dataRow.Row.ItemArray[10].ToString();
                    hdnRoomsType2Count.Value = dataRow.Row.ItemArray[11].ToString();
                    hdnRoomsType3Count.Value = dataRow.Row.ItemArray[12].ToString();
                    DropDownList ddlRoomType = (DropDownList)e.Item.FindControl("ddlRoomType");
                    ddlRoomType.Items.Add(new ListItem("", "0"));
                    if (Convert.ToInt32(dataRow.Row.ItemArray[10]) > 0)
                    {
                        ddlRoomType.Items.Add(new ListItem("Queen Size Rooms", "1"));
                    }
                    if (Convert.ToInt32(dataRow.Row.ItemArray[11]) > 0)
                    {
                        ddlRoomType.Items.Add(new ListItem("King Size Rooms", "2"));
                    }
                    if (Convert.ToInt32(dataRow.Row.ItemArray[12]) > 0)
                    {
                        ddlRoomType.Items.Add(new ListItem("Suite Rooms", "3"));
                    }
                    hdnMotelId.Value = dataRow.Row.ItemArray[0].ToString();
                    lblMotelName.Text = motelName;
                    lbladdress.Text = motelAddess;
                    //lblCost.Text = cost;
                    //lblRoomsAvailable.Text = roomsAvailable;
                    //string strpath = Server.MapPath("~/MotelImages/" + imageFolder);
                    //string[] folders = Directory.GetFiles(strpath, "*", SearchOption.AllDirectories);
                    //string[] fileParts = folders[0].Split('\\');
                    //hotelImage.ImageUrl = "~/MotelImages/" + imageFolder + "/" + fileParts[fileParts.Length - 1];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
        protected void ddlRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlCurrentDropDownList = (DropDownList)sender;
            RepeaterItem item = (RepeaterItem)ddlCurrentDropDownList.Parent;
            Label lblAdults = (Label)item.FindControl("lblAdults");
            HiddenField hdnRoomsType1Count = (HiddenField)item.FindControl("hdnRoomsType1Count");
            HiddenField hdnRoomsType2Count = (HiddenField)item.FindControl("hdnRoomsType2Count");
            HiddenField hdnRoomsType3Count = (HiddenField)item.FindControl("hdnRoomsType3Count");
            Label lblRoomsAvailable = (Label)item.FindControl("lblRoomsAvailable");
            Label lblCost = (Label)item.FindControl("lblCost");
            int roomTypeId = Convert.ToInt32(ddlCurrentDropDownList.SelectedValue);
            int personCount = 0;
            HiddenField hdnMotelId = (HiddenField)item.FindControl("hdnMotelId");
            DataSet dsCostDetails = GetRoomCosts(Convert.ToInt32(hdnMotelId.Value));
            switch (roomTypeId)
            {
                case 1: personCount = 2;
                    lblCost.Text = dsCostDetails.Tables[0].Rows[0]["SingleBHKCost"].ToString();
                    lblRoomsAvailable.Text = hdnRoomsType1Count.Value;
                    break;
                case 2: personCount = 4;
                    lblCost.Text = dsCostDetails.Tables[0].Rows[0]["DoubleBHKCost"].ToString();
                    lblRoomsAvailable.Text = hdnRoomsType2Count.Value;
                    break;
                case 3: personCount = 6;
                    lblCost.Text = dsCostDetails.Tables[0].Rows[0]["TripleBHKCost"].ToString();
                    lblRoomsAvailable.Text = hdnRoomsType3Count.Value;
                    break;
            }
            lblAdults.Text = personCount.ToString();

        }

        public DataSet GetRoomCosts(int MotelId)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select SingleBHKCost,DoubleBHKCost,TripleBHKCost from RoomAvailability where MotelId=" + MotelId, con);
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