<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsersDetails.aspx.cs" Inherits="MyMotel.UsersDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<fieldset>
<legend>Users Details</legend>
<div style="text-align:center;">
 <asp:GridView ID="UserDetailsGrid" AutoGenerateColumns="False" runat="server"
                HorizontalAlign="Center">
                <Columns>
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                    <asp:BoundField DataField="MobileNumber" HeaderText="Mobile Number" />
                    <asp:BoundField DataField="State" HeaderText="State" />
                    <asp:BoundField DataField="City" HeaderText="City" />
                    <asp:BoundField DataField="HouseNumber" HeaderText="House Number" />
                    <asp:BoundField DataField="Street" HeaderText="Street" />                    
                    <asp:BoundField DataField="Pincode" HeaderText="Zipcode" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    </Columns>
                    </asp:GridView>
                    <br />    
                    <br />    
    <asp:Button ID="btnHome" runat="server" CssClass="button" Text="Home" PostBackUrl="~/Home.aspx" /> 
    </div>
</fieldset>
</asp:Content>
