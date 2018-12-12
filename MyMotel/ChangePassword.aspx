<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="MyMotel.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">
    function successMessage() {
        alert("Password Changed Successfully");
        window.location.assign("Home.aspx")
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:ValidationSummary ID="ForgotPasswordValidationSummary" runat="server" CssClass="failureNotification" 
                         ValidationGroup="ForgotPasswordValidationGroup"/>
                         <asp:Label ID="lblErrorMessage" runat="server" CssClass="failureNotification"></asp:Label>
    <fieldset class="register">
        <legend>Change Password</legend>
        <p>
            <asp:Label ID="lblOldPassword" runat="server" AssociatedControlID="txtOldPassword">Enter Old Password:</asp:Label>
            <asp:TextBox ID="txtOldPassword" runat="server" CssClass="passwordEntry" TextMode="Password" Height="23px" Width="201px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="OldPasswordRequired" runat="server" ControlToValidate="txtOldPassword"
                CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
                ValidationGroup="ForgotPasswordValidationGroup">*</asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword">Create New Password:</asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="passwordEntry" TextMode="Password" Height="23px" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtPassword"
                CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
                ValidationGroup="ForgotPasswordValidationGroup">*</asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="lblConfirmPassword" runat="server" AssociatedControlID="txtConfirmPassword">Confirm Password:</asp:Label>
            <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="passwordEntry" TextMode="Password" Height="23px" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ControlToValidate="txtConfirmPassword" CssClass="failureNotification"
                Display="Dynamic" ErrorMessage="Confirm Password is required." ID="ConfirmPasswordRequired"
                runat="server" ToolTip="Confirm Password is required." ValidationGroup="ForgotPasswordValidationGroup">*</asp:RequiredFieldValidator>
            <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="txtPassword"
                ControlToValidate="txtConfirmPassword" CssClass="failureNotification" Display="Dynamic"
                ErrorMessage="The Password and Confirmation Password must match." ValidationGroup="ForgotPasswordValidationGroup">*</asp:CompareValidator>
        
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtOldPassword" Operator="NotEqual"
                ControlToValidate="txtConfirmPassword" CssClass="failureNotification" Display="Dynamic"
                ErrorMessage="The New Password and Old Password must be different." ValidationGroup="ForgotPasswordValidationGroup">*</asp:CompareValidator>
        
        </p>
     
         <p>
                            <asp:Button ID="btnChangePassword" runat="server" CommandName="MoveNext" Text="Change"                            
                                 ValidationGroup="ForgotPasswordValidationGroup" 
                                onclick="btnChangePassword_Click" Font-Bold="True" Font-Size="Medium" Height="35px" Width="100px"/>
                        </p>
    </fieldset>
</asp:Content>
