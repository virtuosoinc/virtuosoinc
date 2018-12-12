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
    public partial class RoomAvailabilty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                lblroomavail.Visible = false;

                if (!IsPostBack)
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select MotelId, MotelName from MotelDetails", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    ddlMotels.DataSource = ds;
                    ddlMotels.DataTextField = "MotelName";
                    ddlMotels.DataValueField = "MotelId";
                    ddlMotels.DataBind();
                    ddlMotels.Items.Insert(0, new ListItem("", "0"));
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {

                lblroomavail.Visible = true;

                string motelId = ddlMotels.SelectedValue;
                int singleBHKRoomsCount = Convert.ToInt32(ddlSingleBHKRooms.SelectedValue);
                int doubleBHKRoomsCount = Convert.ToInt32(ddlDoubleBHKRooms.SelectedValue);
                int tripleBHKRoomsCount = Convert.ToInt32(ddlTripleBHKRooms.SelectedValue);
                int singleBHKRoomsCost = Convert.ToInt32(txtQeenSizeCost.Text);
                int doubleBHKRoomsCost = Convert.ToInt32(txtKingSizeCost.Text);
                int tripleBHKRoomsCost = Convert.ToInt32(txtSuitesCost.Text);
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("select count(*) as Count from RoomAvailability where MotelId='" + motelId + "'", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int count = Convert.ToInt32(ds.Tables[0].Rows[0]["Count"]);
                string QryString = string.Empty;
                int inserted = 0;
                if (count > 0)
                {
                    QryString = "Update RoomAvailability set SingleBHK=" + singleBHKRoomsCount + ", DoubleBHK=" + doubleBHKRoomsCount + ", TripleBHK=" + tripleBHKRoomsCount + ", SingleBHKCost=" + singleBHKRoomsCost + ", DoubleBHKCost=" + doubleBHKRoomsCost + ", TripleBHKCost=" + tripleBHKRoomsCost + " where MotelId=" + motelId;
                }
                else
                {
                    QryString = "insert into RoomAvailability values('" + motelId + "'," + singleBHKRoomsCount + "," + doubleBHKRoomsCount + "," + tripleBHKRoomsCount + "," + singleBHKRoomsCost + "," + doubleBHKRoomsCost + "," + tripleBHKRoomsCost + ")";
                }
                SqlCommand CmdObj = new SqlCommand(QryString, conn);
                conn.Open();
                inserted = CmdObj.ExecuteNonQuery();
                conn.Close();
                //string display = "Updated Successfully";
                if (inserted > 0)
                {
                    string roomavailmessage;
                    lblroomavail.Text = "<strong>Updated Successfully</strong>";
                    roomavailmessage = lblroomavail.Text;
                    ddlMotels.SelectedIndex = 0;
                    ddlSingleBHKRooms.SelectedIndex = 0;
                    ddlDoubleBHKRooms.SelectedIndex = 0;
                    ddlTripleBHKRooms.SelectedIndex = 0;
                    txtQeenSizeCost.Text = string.Empty;
                    txtKingSizeCost.Text = string.Empty;
                    txtSuitesCost.Text = string.Empty;
                    //ClientScript.RegisterStartupScript(this.GetType(), "yourMessage", roomavailmessage, true);
                    //Response.Redirect("Home.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected void ddlMotels_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblroomavail.Text = string.Empty;
                int motelId = Convert.ToInt32(ddlMotels.SelectedValue);
                string QryString = "select * from RoomAvailability where MotelId =" + motelId;
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                SqlCommand CmdObj = new SqlCommand(QryString, conn);
                SqlDataAdapter da = new SqlDataAdapter(CmdObj);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int singleBHKRooms = Convert.ToInt32(ds.Tables[0].Rows[0]["SingleBHK"]);
                    int doubleBHKRooms = Convert.ToInt32(ds.Tables[0].Rows[0]["DoubleBHK"]);
                    int tripleBHKRooms = Convert.ToInt32(ds.Tables[0].Rows[0]["TripleBHK"]);
                    txtQeenSizeCost.Text = ds.Tables[0].Rows[0]["SingleBHKCost"].ToString();
                    txtKingSizeCost.Text = ds.Tables[0].Rows[0]["DoubleBHKCost"].ToString();
                    txtSuitesCost.Text = ds.Tables[0].Rows[0]["TripleBHKCost"].ToString();

                    foreach (ListItem item in ddlSingleBHKRooms.Items)
                    {
                        if (item.Value == singleBHKRooms.ToString())
                        {
                            item.Selected = true;
                        }
                        else
                        {
                            item.Selected = false;
                        }
                    }
                    foreach (ListItem item in ddlDoubleBHKRooms.Items)
                    {
                        if (item.Value == doubleBHKRooms.ToString())
                        {
                            item.Selected = true;
                        }
                        else
                        {
                            item.Selected = false;
                        }
                    }
                    foreach (ListItem item in ddlTripleBHKRooms.Items)
                    {
                        if (item.Value == tripleBHKRooms.ToString())
                        {
                            item.Selected = true;
                        }
                        else
                        {
                            item.Selected = false;
                        }
                    }
                }
                else {                    
                    ddlSingleBHKRooms.SelectedIndex = 0;
                    ddlDoubleBHKRooms.SelectedIndex = 0;
                    ddlTripleBHKRooms.SelectedIndex = 0;
                    txtQeenSizeCost.Text = string.Empty;
                    txtKingSizeCost.Text = string.Empty;
                    txtSuitesCost.Text = string.Empty;
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void HomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}