using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;

namespace MyMotel
{
    public partial class RegisterMotel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                lblregistermessage.Visible = false;

                if (!IsPostBack)
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select ROW_NUMBER() over (Order by State) as StateId, [State] from (select distinct [State] from StateAndCity) StateTable", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    ddlState.DataSource = ds;
                    ddlState.DataTextField = "State";
                    ddlState.DataValueField = "StateId";
                    ddlState.DataBind();
                    ddlState.Items.Insert(0, new ListItem("Select State", "0"));
                    con.Close();
                    ddlCity.Items.Insert(0, new ListItem("Select City", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected void RegisterMotelButton_Click(object sender, EventArgs e)
        {
            try
            {
                lblregistermessage.Visible = true;

                string regmotelmessage;
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
                string QryString = "insert into MotelDetails values('" + motelName + "','" + address + "','" + city + "','" + pincode + "','" + state + "','" + telephoneNumber + "'," + starCategory + ",'" + motelId + "','" + email + "',0)";
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                SqlCommand CmdObj = new SqlCommand(QryString, conn);
                conn.Open();
                inserted = CmdObj.ExecuteNonQuery();
                conn.Close();
                if (inserted > 0)
                {
                    string directoryPath = Server.MapPath(string.Format("~/MotelImages/{0}/", motelId.Trim()));
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                        if (motelImageUpload.HasFile)
                        {
                            string[] name = motelImageUpload.FileName.Split('.');
                            string fileName = Path.Combine(Server.MapPath("~/MotelImages/" + motelId), motelId + "." + name[1]);
                            motelImageUpload.SaveAs(fileName);
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Directory already exists.');", true);
                    }
                    lblregistermessage.Text = "<br /><strong>Motel Registered Successfully</strong>";
                    regmotelmessage = lblregistermessage.Text;
                    ClientScript.RegisterStartupScript(this.GetType(), "yourMessage", regmotelmessage, true);
                    //Response.Redirect("Home.aspx");
                    txtMotelName.Text = string.Empty;
                    txtAddress.Text = string.Empty;
                    //ddlCity.SelectedValue = "0";
                    ddlCity.Items.Clear();
                    txtPinCode.Text = string.Empty;
                    ddlState.SelectedValue = "0";
                    txtTelephone.Text = string.Empty;
                    ddlStarCategory.SelectedValue = "0";
                    txtEmail.Text = string.Empty;
                    //txtCost.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected void State_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}