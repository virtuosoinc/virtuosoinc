<%@ Page Title="Login" Language="C#" MasterPageFile="~/SiteHome.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="Test.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Customer Login
    </h2>
    <p>
               
    </p>
   
            <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="LoginUserValidationGroup"/>
            <div class="accountInfo">
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="failureNotification"></asp:Label>
                <fieldset class="login">
                    <legend>Enter your Login Credentials</legend>
                    <p>
                        <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail">User Id :</asp:Label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="TextBox" Height="22px" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="txtEmail" 
                        CssClass="failureNotification" ErrorMessage="Email is required." ToolTip="Email is required." 
                        ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                       <%-- <asp:RegularExpressionValidator id="EmailRequired" ControlToValidate="txtEmail"
                        Text="Invalid email" CssClass="failureNotification" ToolTip="E-mail is required." ErrorMessage="Invalid email"
                        ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                        ValidationGroup="LoginUserValidationGroup" Runat="server" />--%>
                    </p>
                    <p>
                        <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword">Password :</asp:Label>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="TextBox" TextMode="Password" Height="22px" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtPassword" 
                             CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>  
                    
                    <br />
                    
                    <p style="margin-left:20px;">
                        <asp:Button ID="btnHome" runat="server" Text="Home" PostBackUrl="~/Home.aspx" CssClass="button" Font-Bold="True" 
                Font-Size="Medium"  />     
                        <asp:Button ID="btnLogin" runat="server" Text="Login" ValidationGroup="LoginUserValidationGroup" onclick="btnLogin_Click"  
                            CssClass="button" Font-Bold="True" Font-Size="Medium"  />
                        <asp:Button ID="Button1" runat="server" Text="Back" OnClientClick="window.history.back();" CssClass="button" Font-Bold="True" 
                Font-Size="Medium"  />
            
                    </p>   
                    
                    <p class="submitButton">
                     
                    <a href="~/ForgotPassword.aspx?Role=User" ID="HeadLoginStatus" runat="server">Forgot Password?</a>
                </p>
                                  
                </fieldset>

                    <h2>If you are not a registered customer,Please <asp:HyperLink ID="RegisterHyperLink" runat="server" EnableViewState="False">Register</asp:HyperLink></h2>.
                
                
            </div>  
            
    
</asp:Content>
