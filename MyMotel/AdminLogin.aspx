<%@ Page Title="" Language="C#" MasterPageFile="~/SiteHome.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="MyMotel.AdminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>
        Admin Login
    </h2>
   <!-- <p>
        <b>Please enter your Login Credentials.
    </p>-->
   
            <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <%--<asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="LoginUserValidationGroup"/>--%>
            <div class="accountInfo">
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="failureNotification"></asp:Label>
                <fieldset class="login">
                    <legend>Enter your Login Credentials</legend>
                        <h2>
        All fields are mandatory</h2>
                     <p>
                         <br />
                    <asp:Label ID="lblSecurityKey" runat="server" AssociatedControlID="txtSecurityKey">Security Key:</asp:Label>
                        <asp:TextBox ID="txtSecurityKey" runat="server" CssClass="TextBox"></asp:TextBox>                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSecurityKey" 
                             CssClass="failureNotification" ErrorMessage="Security Key is required." ToolTip="Security Key is required." 
                             ValidationGroup="LoginUserValidationGroup"></asp:RequiredFieldValidator>
                    </p>
                    <p>
                         <asp:Label ID="lblUserId" runat="server" AssociatedControlID="txtUserId">Enter User Id:</asp:Label>
                        <asp:TextBox ID="txtUserId" runat="server" CssClass="TextBox"></asp:TextBox>                       
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="txtUserId" 
                        CssClass="failureNotification" ErrorMessage="User Id is required." ToolTip="User Id is required." 
                        ValidationGroup="LoginUserValidationGroup"></asp:RequiredFieldValidator> 
                    </p>
                    <p>
                        <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword">Enter Password:</asp:Label>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="TextBox" TextMode="Password"></asp:TextBox>                        
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtPassword" 
                             CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
                             ValidationGroup="LoginUserValidationGroup"></asp:RequiredFieldValidator>
                    </p>  
                    
                    <br />
                    
                    <p>
                        <asp:Button ID="btnHome" runat="server" Text="Home" PostBackUrl="~/Home.aspx" CssClass="button" Font-Bold="True" Height="30px" Width="65px" />     
            <asp:Button ID="btnLogin" runat="server" Text="Login" ValidationGroup="LoginUserValidationGroup" onclick="btnLogin_Click" CssClass="button" Font-Bold="True" Height="30px" Width="65px" />
                        <asp:Button ID="btnBack" runat="server" Text="Back" OnClientClick="window.history.back();" CssClass="button" Font-Bold="True" Height="30px" Width="65px" />

                    </p>   
                    
                                  <p>
                                  <a href="~/ForgotPassword.aspx?Role=Admin" ID="HeadLoginStatus" runat="server">Forgot Password?</a>
                                  </p>
                </fieldset>
                
                
            </div>  
    
   <!-- </b> --> 
    
</asp:Content>
