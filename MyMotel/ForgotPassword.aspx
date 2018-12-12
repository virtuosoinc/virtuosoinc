<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ForgotPassword.aspx.cs" Inherits="MyMotel.ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ValidationSummary ID="ForgotPsswordValidationSummary" runat="server" CssClass="failureNotification"
        ValidationGroup="ForgotPsswordValidationGroup" />
    <asp:ValidationSummary ID="ForgotPsswordValidationSummary1" runat="server" CssClass="failureNotification"
        ValidationGroup="ForgotPsswordValidationGroup1" />
    <fieldset class="login">
        <legend>Forgot Password</legend>
        <div runat="server" id="divEmail">
            <p>
                <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail"> Enter your Email Address:</asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="textEntry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="txtEmail"
                    CssClass="failureNotification" ErrorMessage="Email is required." ToolTip="Email is required."
                    ValidationGroup="ForgotPsswordValidationGroup1">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="EmailRequired" ControlToValidate="txtEmail" Text="Invalid email"
                    CssClass="failureNotification" ToolTip="E-mail is required." ErrorMessage="Invalid email"
                    ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                    ValidationGroup="ForgotPsswordValidationGroup1" runat="server" />
            </p>
            <p>
                <asp:Button ID="btnNext" runat="server" Text="Next" 
                    ValidationGroup="ForgotPsswordValidationGroup1" onclick="btnNext_Click" />
            </p>
        </div>
        <div runat="server" id="divQuestions" visible="false">
            <p>
                <asp:Label ID="lblSecuritQuestion1" runat="server">Security Question1:</asp:Label>
                <asp:Label ID="lblSecuritQuestion1Val" runat="server"></asp:Label>
                <%-- <asp:DropDownList ID="ddlSecurityQuestion1" runat="server" Height="23px" Width="200px">
                    <asp:ListItem Value='0' Text='Select Question'></asp:ListItem>
                            <asp:ListItem Value='1' Text='Your birth place?'></asp:ListItem>
                                <asp:ListItem Value='2' Text='Your last name?'></asp:ListItem>                                
                                 <asp:ListItem Value='3' Text='Your nick name?'></asp:ListItem>
                                 <asp:ListItem Value='4' Text='Your first scool name?'></asp:ListItem>                                
                                 <asp:ListItem Value='5' Text='Your favorite food?'></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="SecurityQuestionRequired" runat="server" ControlToValidate="ddlSecurityQuestion1"
                        InitialValue="0" CssClass="failureNotification" ErrorMessage="Security Question1 is required."
                        ToolTip="Security Question1 is required." ValidationGroup="ForgotPasswordValidationGroup">*</asp:RequiredFieldValidator>
                --%>
            </p>
            <p>
                <asp:Label ID="lblAnswer1" runat="server" AssociatedControlID="txtAnswer1">Answer1:</asp:Label>
                <asp:TextBox ID="txtAnswer1" runat="server" Height="23px" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="txtAnswer1"
                    CssClass="failureNotification" ErrorMessage="Answer1 is required." ToolTip="Answer1 is required."
                    ValidationGroup="ForgotPasswordValidationGroup">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="lblSecuritQuestion2" runat="server">Security Question2:</asp:Label>
                <asp:Label ID="lblSecuritQuestion2Val" runat="server"></asp:Label>
                <%--<asp:DropDownList ID="ddlSecurityQuestion2" runat="server" Height="23px" Width="200px">
                         <asp:ListItem Value='0' Text='Select Question'></asp:ListItem>
                                <asp:ListItem Value='1' Text='Your birth place?'></asp:ListItem>
                                <asp:ListItem Value='2' Text='your last name'></asp:ListItem>                                
                                 <asp:ListItem Value='3' Text='your nick name'></asp:ListItem>
                                 <asp:ListItem Value='4' Text='your first scool name'></asp:ListItem>                                
                                 <asp:ListItem Value='5' Text='your favorite food'></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlSecurityQuestion2"
                            InitialValue="0" CssClass="failureNotification" ErrorMessage="Security Question2 is required."
                            ToolTip="Security Question2 is required." ValidationGroup="ForgotPasswordValidationGroup">*</asp:RequiredFieldValidator>--%>
               <%-- <br />
                <asp:CompareValidator ID="SecurityQuestionCompareValidator" runat="server" ControlToCompare="ddlSecurityQuestion1"
                    ControlToValidate="ddlSecurityQuestion2" CssClass="failureNotification" Display="Dynamic"
                    Operator="NotEqual" ErrorMessage="Please select differant question." ValidationGroup="ForgotPasswordValidationGroup"></asp:CompareValidator>--%>
            </p>
            <p>
                <asp:Label ID="lblAnswer2" runat="server" AssociatedControlID="txtAnswer2">Answer2:</asp:Label>
                <asp:TextBox ID="txtAnswer2" runat="server" Height="23px" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="Answer2Required" runat="server" ControlToValidate="txtAnswer2"
                    CssClass="failureNotification" ErrorMessage="Answer2 is required." ToolTip="Answer2 is required."
                    ValidationGroup="ForgotPasswordValidationGroup">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Button ID="btnSend" runat="server" Text="Send" ValidationGroup="ForgotPsswordValidationGroup"
                    OnClick="btnSend_Click" />
                    <asp:Button ID="btnBack" runat="server" Text="Back" 
                    onclick="btnBack_Click" />                
            </p>
        </div>
        <asp:Label ID="lblMessage" CssClass="failureNotification" runat="server"></asp:Label>
    </fieldset>
</asp:Content>
