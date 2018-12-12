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

namespace MyMotel
{
    public partial class EditMotel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select ROW_NUMBER() over (Order by State) as StateId, [State] from (select distinct [State] from StateAndCity) StateTable", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds1 = new DataSet();
                da.Fill(ds1);
                ddlState.DataSource = ds1;
                ddlState.DataTextField = "State";
                ddlState.DataValueField = "StateId";
                ddlState.DataBind();
                con.Close();
                ddlState.Items.Insert(0, new ListItem("Select State", "0"));
                ddlCity.Items.Insert(0, new ListItem("Select City", "0"));

                int motelId = Convert.ToInt32(Request.QueryString["motelId"]);
                DataSet ds = GetMotelDetails(motelId);
                string motelName = ds.Tables[0].Rows[0]["MotelName"].ToString();
                string address = ds.Tables[0].Rows[0]["Address"].ToString();
                string City = ds.Tables[0].Rows[0]["City"].ToString();
                string pinCode = ds.Tables[0].Rows[0]["Pincode"].ToString();
                string state = ds.Tables[0].Rows[0]["State"].ToString();
                string telephoneNumber = ds.Tables[0].Rows[0]["TelephoneNumber"].ToString();
                int starCategory = Convert.ToInt32(ds.Tables[0].Rows[0]["StarCategory"].ToString());
                //int cost = Convert.ToInt32(ds.Tables[0].Rows[0]["Cost"].ToString());
                txtMotelName.Text = motelName;
                txtAddress.Text = address;
                txtPinCode.Text = pinCode;
                txtTelephone.Text = telephoneNumber;
                //txtCost.Text = cost.ToString();
                ddlStarCategory.SelectedIndex = starCategory;
                ddlState.Items.FindByText(state).Selected = true;
                LoadCityDetails();
                ddlCity.Items.FindByText(City).Selected = true;
                string imageFolder = ds.Tables[0].Rows[0]["ImageFolder"].ToString();
                hdnImageFolder.Value = imageFolder;
            }
        }

        protected void State_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCityDetails();
        }

        public void LoadCityDetails()
        {
            string stateId = ddlState.SelectedItem.Text;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select ROW_NUMBER() over (Order by State) as CityId, City from StateAndCity where State='" + stateId + "'", con);
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

        public DataSet GetMotelDetails(int motelId)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from MotelDetails where MotelId=" + motelId, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            return ds;
        }

        protected void UpdateMotelButton_Click(object sender, EventArgs e)
        {
            string motelName = txtMotelName.Text;
            string address = txtAddress.Text;
            string city = ddlCity.SelectedItem.Text;
            string pincode = txtPinCode.Text;
            string state = ddlState.SelectedItem.Text;
            string telephoneNumber = txtTelephone.Text;
            int starCategory = Convert.ToInt32(ddlStarCategory.SelectedValue);
            //int cost = Convert.ToInt32(txtCost.Text);
            string email = txtEmail.Text;
            int inserted = 0;
            string motelId = Guid.NewGuid().ToString();
            int bookingMotelId = Convert.ToInt32(Request.QueryString["motelId"]);
            string QryString = "Update MotelDetails SET MotelName='" + motelName + "',Address='" + address + "',City='" + city + "',Pincode='" + pincode + "',State='" + state + "',TelephoneNumber='" + telephoneNumber + "',StarCategory=" + starCategory + ",Email='" + email + "' Where MotelId=" + bookingMotelId;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
            SqlCommand CmdObj = new SqlCommand(QryString, conn);
            conn.Open();
            inserted = CmdObj.ExecuteNonQuery();
            conn.Close();
            if (inserted > 0)
            {
                string directoryPath = Server.MapPath(string.Format("~/MotelImages/{0}/", hdnImageFolder.Value));
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                if (motelImageUpload.HasFile)
                {
                    string[] name = motelImageUpload.FileName.Split('.');
                    string fileName = Path.Combine(Server.MapPath("~/MotelImages/" + hdnImageFolder.Value), hdnImageFolder.Value + "." + name[1]);
                    motelImageUpload.SaveAs(fileName);
                }
                //else
                //{
                //    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Directory already exists.');", true);
                //}
                ClientScript.RegisterStartupScript(this.GetType(), "yourMessage", "successMessage();", true);
                //Response.Redirect("Home.aspx");
            }
        }
    }
}