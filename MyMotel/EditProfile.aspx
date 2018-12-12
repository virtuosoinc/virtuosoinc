<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="MyMotel.EditProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
 <script type="text/javascript">
     function successMessage() {
         alert("User Profile Updated Successfully");
         window.location.assign("EditProfile.aspx")
     }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <fieldset class="register" runat="server" id="fieldset1">
            <legend>Update your Profile</legend>
<asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification"
        ValidationGroup="RegisterUserValidationGroup" />
            <table width="100%">
                
                <tr>
                  <td>
                        <asp:Label ID="lblFirstName" runat="server" AssociatedControlID="txtFirstName" Font-Size="Medium">First Name:</asp:Label>
                    </td>
                    <td>
                    <asp:Label ID="lblFirstNameVal" runat="server"></asp:Label>
                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="TextBox" Height="23px" Width="180px"
                            TabIndex="1" Visible="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="FirstNameRequired" runat="server" ControlToValidate="txtFirstName"
                            CssClass="failureNotification" ErrorMessage="First Name is required." ToolTip="First Name is required."
                            ValidationGroup="RegisterUserValidationGroup" Display="None"></asp:RequiredFieldValidator>
                    </td>                 
                <td>
                        <asp:Label ID="lblHouseNumber" runat="server" AssociatedControlID="txtHouseNo" Font-Size="Medium">House Number:</asp:Label>
                    </td>
                    <td>
                    <asp:Label ID="lblHouseNumberVal" runat="server" ></asp:Label>
                        <asp:TextBox ID="txtHouseNo" runat="server" CssClass="TextBox" Height="23px" Width="180px"
                            TabIndex="5" Visible="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="HouseNoRequired" runat="server" ControlToValidate="txtHouseNo"
                            CssClass="failureNotification" ErrorMessage="House Number is required." ToolTip="House Number is required."
                            ValidationGroup="RegisterUserValidationGroup" Display="None"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                  <td>
                        <asp:Label ID="lblLastName" runat="server" AssociatedControlID="txtLastName" Font-Size="Medium">Last Name:</asp:Label>
                    </td>
                    <td>
                    <asp:Label ID="lblLastNameVal" runat="server"></asp:Label>
                        <asp:TextBox ID="txtLastName" runat="server" CssClass="TextBox" Height="23px" Width="180px"
                            TabIndex="2" Visible="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="LastNameRequired" runat="server" ControlToValidate="txtLastName"
                            CssClass="failureNotification" ErrorMessage="Last Name is required." ToolTip="Last Name is required."
                            ValidationGroup="RegisterUserValidationGroup" Display="None"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="lblStreet" runat="server" AssociatedControlID="txtStreet" Font-Size="Medium">Street:</asp:Label>
                    </td>
                    <td>
                    <asp:Label ID="lblStreetVal" runat="server"></asp:Label>
                        <asp:TextBox ID="txtStreet" runat="server" CssClass="TextBox" Height="23px" Width="180px"
                            TabIndex="6" Visible="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="StreetRequired" runat="server" ControlToValidate="txtStreet"
                            CssClass="failureNotification" ErrorMessage="Street is required." ToolTip="Street is required."
                            ValidationGroup="RegisterUserValidationGroup" Display="None"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMobile" runat="server" AssociatedControlID="txtMobileNo" Font-Size="Medium">Best Number to reach you:</asp:Label>
                    </td>
                    <td>
                    <asp:Label ID="lblMobileVal" runat="server"></asp:Label>
                        <asp:TextBox ID="txtMobileNo" runat="server" CssClass="TextBox" Height="23px" Width="180px"
                            TabIndex="3" Visible="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="MobilrNoRequired" runat="server" ControlToValidate="txtMobileNo"
                            CssClass="failureNotification" ErrorMessage="Enter your Best Number to reach you."
                            ToolTip="Mobile No is required." ValidationGroup="RegisterUserValidationGroup"
                            Display="None"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="MobileValidator" runat="server" ControlToValidate="txtMobileNo"
                            ValidationGroup="RegisterUserValidationGroup" Display="Dynamic" ForeColor="Red"
                            ErrorMessage="Should be 10 Digits" ValidationExpression="^\d{10}$"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:Label ID="lblCity" runat="server" AssociatedControlID="txtCity" Font-Size="Medium">City:</asp:Label>
                    </td>
                    <td>
                    <asp:Label ID="lblCityVal" runat="server"></asp:Label>
                        <asp:TextBox ID="txtCity" runat="server" CssClass="TextBox" Height="23px" Width="180px"
                            TabIndex="7" Visible="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="CityRequired" runat="server" ControlToValidate="txtCity"
                            CssClass="failureNotification" ErrorMessage="City is required." ToolTip="City is required."
                            ValidationGroup="RegisterUserValidationGroup" Display="None"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPinCode" runat="server" AssociatedControlID="txtPinCode" Font-Size="Medium">Zip Code:</asp:Label>
                    </td>
                    <td>
                    <asp:Label ID="lblPinCodeVal" runat="server"></asp:Label>
                        <asp:TextBox ID="txtPinCode" runat="server" CssClass="TextBox" Height="21px" Width="180px"
                            TabIndex="9" Visible="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PinCodeRequired" runat="server" ControlToValidate="txtPinCode"
                            CssClass="failureNotification" ErrorMessage="Zip Code is required." ToolTip="Pin Code is required."
                            ValidationGroup="RegisterUserValidationGroup" Display="None"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regexpcontactPinCode" runat="server" ControlToValidate="txtPinCode"
                            ValidationGroup="RegisterUserValidationGroup" Display="Dynamic" ForeColor="Red"
                            ErrorMessage="Should be 5 Digits" ValidationExpression="^\d{5}$"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:Label ID="lblState" runat="server" AssociatedControlID="txtState" Font-Size="Medium">State:</asp:Label>
                    </td>
                    <td>
                    <asp:Label ID="lblStateVal" runat="server"></asp:Label>
                        <asp:TextBox ID="txtState" runat="server" CssClass="TextBox" Height="25px" Width="180px"
                            TabIndex="8" Visible="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="txtStateRequired" runat="server" ControlToValidate="txtState"
                            CssClass="failureNotification" ErrorMessage="State is required." ToolTip="State is required."
                            ValidationGroup="RegisterUserValidationGroup" Display="None"></asp:RequiredFieldValidator>
                    </td>                    
                </tr>                
                <tr>                    
                    <td>
                        <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail" Font-Size="Medium">E-mail Address:</asp:Label>
                    </td>
                    <td>
                    <asp:Label ID="lblEmailVal" runat="server"></asp:Label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="TextBox" Height="23px" Width="180px"
                            TabIndex="4" Visible="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="EmailRequired1" runat="server" ControlToValidate="txtEmail"
                            CssClass="failureNotification" ErrorMessage="E-mail Address is required." ToolTip="E-mail is required."
                            ValidationGroup="RegisterUserValidationGroup" Display="None"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="EmailRequired" ControlToValidate="txtEmail" Text="(Invalid email)"
                            CssClass="failureNotification" ErrorMessage="Invalid email." ToolTip="Invalid email."
                            ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                            ValidationGroup="" runat="server" />
                    </td>
                    <td></td>
                    <td></td>
                    </tr>
                     <tr>
                    <td>
                        <asp:Label ID="lblSecuritQuestion1" runat="server" Font-Size="Medium">Security Question1:</asp:Label>
                    </td>
                    <td>                        
                    <asp:Label ID="lblSecuritQuestion1Val" runat="server"></asp:Label>
                        <asp:DropDownList ID="ddlSecurityQuestion1" runat="server" CssClass="TextBox"  Visible="false">
                        <asp:ListItem Value='0' Text='Select Question'></asp:ListItem>
                                <asp:ListItem Value='1' Text='Your birth place?'></asp:ListItem>
                                <asp:ListItem Value='2' Text='your last name'></asp:ListItem>                                
                                 <asp:ListItem Value='3' Text='your nick name'></asp:ListItem>
                                 <asp:ListItem Value='4' Text='your first scool name'></asp:ListItem>                                
                                 <asp:ListItem Value='5' Text='your favorite food'></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="SecurityQuestionRequired" runat="server" ControlToValidate="ddlSecurityQuestion1"
                            InitialValue="0" CssClass="failureNotification" ErrorMessage="Security Question1 is required."
                            ToolTip="Security Question1 is required." ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                    </td>    
                     <td>
                        <asp:Label ID="lblSecuritQuestion2" runat="server" AssociatedControlID="ddlSecurityQuestion2" Font-Size="Medium">Security Question2:</asp:Label>
                    </td>
                    <td>
                    <asp:Label ID="lblSecuritQuestion2Val" runat="server"></asp:Label>
                        <%--<asp:TextBox ID="City" runat="server" CssClass="textEntry"></asp:TextBox>--%>
                        <asp:DropDownList ID="ddlSecurityQuestion2" runat="server" CssClass="TextBox"  Visible="false">
                         <asp:ListItem Value='0' Text='Select Question'></asp:ListItem>
                                <asp:ListItem Value='1' Text='Your birth place?'></asp:ListItem>
                                <asp:ListItem Value='2' Text='your last name'></asp:ListItem>                                
                                 <asp:ListItem Value='3' Text='your nick name'></asp:ListItem>
                                 <asp:ListItem Value='4' Text='your first scool name'></asp:ListItem>                                
                                 <asp:ListItem Value='5' Text='your favorite food'></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlSecurityQuestion2"
                            InitialValue="0" CssClass="failureNotification" ErrorMessage="Security Question2 is required."
                            ToolTip="Security Question2 is required." ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                    <br /><asp:CompareValidator ID="SecurityQuestionCompareValidator" runat="server" ControlToCompare="ddlSecurityQuestion1"
                            ControlToValidate="ddlSecurityQuestion2" CssClass="failureNotification" Display="Dynamic" Operator="NotEqual"
                            ErrorMessage="Please select differant question." ValidationGroup="RegisterUserValidationGroup"></asp:CompareValidator>
                        
                    </td>            
                    
                </tr>
                <tr>
                <td>
                        <asp:Label ID="lblAnswer1" runat="server" AssociatedControlID="txtAnswer1">Answer1:</asp:Label>
                    </td>
                    <td>
                    <asp:Label ID="lblAnswer1Val" runat="server"></asp:Label>
                        <asp:TextBox ID="txtAnswer1" runat="server" CssClass="TextBox" Visible="false"></asp:TextBox>                        
                        <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="txtAnswer1"
                            CssClass="failureNotification" ErrorMessage="Answer1 is required." ToolTip="Answer1 is required."
                            ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="lblAnswer2" runat="server" AssociatedControlID="txtAnswer2">Answer2:</asp:Label>
                    </td>
                    <td>
                    <asp:Label ID="lblAnswer2Val" runat="server"></asp:Label>
                     <asp:TextBox ID="txtAnswer2" runat="server" CssClass="TextBox" Visible="false"></asp:TextBox>                     
                                <asp:RequiredFieldValidator ID="Answer2Required" runat="server" ControlToValidate="txtAnswer2" 
                                     CssClass="failureNotification" ErrorMessage="Answer2 is required." ToolTip="Answer2 is required." 
                                     ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                    </td>
                </tr>                
            </table>
        </fieldset>
         <p class="submitButton">
         <asp:Button ID="btnChange" runat="server" Text="Change" CssClass="button" 
                 onclick="btnChange_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update"
                ValidationGroup="RegisterUserValidationGroup" onclick="btnUpdate_Click" CssClass="button" Visible="false" />  
                <asp:Button ID="btnHome" runat="server" Text="Home" PostBackUrl="~/Home.aspx" CssClass="button" />     
                <asp:Button ID="btnBack" runat="server" Text="Back" OnClientClick="window.history.back();" CssClass="button"/> 
                <br /><br />
                <a href="~/ChangePassword.aspx" ID="HeadChangePassword" runat="server"><b>Change Password</b></a>     
        </p><br /><br />        
        <asp:Label ID="lblMessage" Style="color: Red;" runat="server"></asp:Label>
</asp:Content>
