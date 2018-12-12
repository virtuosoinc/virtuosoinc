<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="MyMotel.MyProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 201px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
<legend>My Profile</legend>
<table width="100%">
                
                <tr>
                 <td class="auto-style1">
                        <asp:Label ID="lblAccount" runat="server"  Font-Size="Medium">User Id:</asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblAccountVal" runat="server"></asp:Label>       
                    </td>
                <td>
                        <asp:Label ID="lblHouseNumber" runat="server" Font-Size="Medium">HouseNumber:</asp:Label>
                    </td>
                    <td>
                       <asp:Label ID="lblHouseNumberVal" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblFirstName" runat="server" Font-Size="Medium">First Name:</asp:Label>
                    </td>
                    <td>
                       <asp:Label ID="lblFirstNameVal" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblStreet" runat="server" Font-Size="Medium">Street:</asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblStreetVal" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblLastName" runat="server" Font-Size="Medium">Last Name:</asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblLastNameVal" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblCity" runat="server" Font-Size="Medium">City:</asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblCityVal" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblMobile" runat="server" Font-Size="Medium">Best Number to reach you:</asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblMobileVal" runat="server" ></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblState" runat="server" Font-Size="Medium">State:</asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblStateVal" runat="server" ></asp:Label>
                    </td>                    
                </tr>                
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblPinCode" runat="server" Font-Size="Medium">Zip Code:</asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblPinCodeVal" runat="server" ></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEmail" runat="server" Font-Size="Medium">E-mail Address:</asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEmailVal" runat="server"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblSecuritQuestion1" runat="server">Security Question1:</asp:Label>
                    </td>
                    <td>                        
                       <asp:Label ID="lblSecuritQuestion1Val" runat="server"></asp:Label>
                       </td>                
                    <td>
                        <asp:Label ID="lblAnswer1" runat="server" >Answer1:</asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblAnswer1Val" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblSecuritQuestion2" runat="server">Security Question2:</asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblSecuritQuestion2Val" runat="server"></asp:Label>
                        
                    </td>                
                    <td>
                        <asp:Label ID="lblAnswer2" runat="server">Answer2:</asp:Label>
                    </td>
                    <td>
                    <asp:Label ID="lblAnswer2Val" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            </fieldset>
            <br />
            <asp:Button ID="btnEdit" runat="server" PostBackUrl="~/EditProfile.aspx" Text="Edit" CssClass="button" />
            <asp:Button ID="btnHome" runat="server" Text="Home" PostBackUrl="~/Home.aspx" CssClass="button" /><br /><br />
<a href="~/ChangePassword.aspx" ID="HeadChangePassword" runat="server"><b>Change Password</b></a> 
</asp:Content>
