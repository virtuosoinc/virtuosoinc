<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AdminRegister.aspx.cs" Inherits="MyMotel.AdminRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function successMessage() {
            alert("Admin Registered Successfully");
            window.location.assign("AdminLogin.aspx")
        }
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <%--<asp:CreateUserWizard ID="RegisterUser" runat="server" EnableViewState="false" OnCreatedUser="RegisterUser_CreatedUser">
        <LayoutTemplate>
            <asp:PlaceHolder ID="wizardStepPlaceholder" runat="server"></asp:PlaceHolder>
            <asp:PlaceHolder ID="navigationPlaceholder" runat="server"></asp:PlaceHolder>
        </LayoutTemplate>--%>
    <%--<WizardSteps>
            <asp:CreateUserWizardStep ID="RegisterUserWizardStep" runat="server">--%>
    <%--<ContentTemplate>--%>
    <h2>
        Admin Registration
    </h2>
    <h2>
        All fields are mandatory</h2>
    <span class="failureNotification">
        <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
    </span>
    <%--<asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification"
        ValidationGroup="RegisterUserValidationGroup" />--%>
    <%--<asp:ValidationSummary ID="RegisterUserValidationSummary1" runat="server" CssClass="failureNotification"
        ValidationGroup="RegisterUserValidationGroup1" />--%>
    <div>
        <fieldset class="register" runat="server" id="fieldset1">
            <legend>Enter Your Details</legend>
            <table width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblFirstName" runat="server" AssociatedControlID="txtFirstName">First Name:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="TextBox" Height="23px" Width="180px"
                            TabIndex="1"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="FirstNameRequired" runat="server" ControlToValidate="txtFirstName"
                            CssClass="failureNotification" ErrorMessage="First Name is required." ToolTip="First Name is required."
                            ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="lblStreet" runat="server" AssociatedControlID="txtStreet">Street Address:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtStreet" runat="server" CssClass="TextBox" Height="23px" Width="180px"
                            TabIndex="6"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="StreetRequired" runat="server" ControlToValidate="txtStreet"
                            CssClass="failureNotification" ErrorMessage="Street is required." ToolTip="Street is required."
                            ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblLastName" runat="server" AssociatedControlID="txtLastName">Last Name:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLastName" runat="server" CssClass="TextBox" Height="23px" Width="180px"
                            TabIndex="2"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="LastNameRequired" runat="server" ControlToValidate="txtLastName"
                            CssClass="failureNotification" ErrorMessage="Last Name is required." ToolTip="Last Name is required."
                            ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="lblCity" runat="server" AssociatedControlID="txtCity">City:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCity" runat="server" CssClass="TextBox" Height="23px" Width="180px"
                            TabIndex="7"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="CityRequired" runat="server" ControlToValidate="txtCity"
                            CssClass="failureNotification" ErrorMessage="City is required." ToolTip="City is required."
                            ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMobile" runat="server" AssociatedControlID="txtMobileNo">Best Number to reach you:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMobileNo" runat="server" CssClass="TextBox" Height="23px" Width="180px"
                            TabIndex="3"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="MobilrNoRequired" runat="server" ControlToValidate="txtMobileNo"
                            CssClass="failureNotification" ErrorMessage="Enter your Best Number to reach you."
                            ToolTip="Mobile No is required." ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="MobileValidator" runat="server" ControlToValidate="txtMobileNo"
                            ValidationGroup="RegisterUserValidationGroup" Display="Dynamic" ForeColor="Red"
                            ErrorMessage="Should be 10 Digits" ValidationExpression="^\d{10}$"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:Label ID="lblState" runat="server" AssociatedControlID="txtState">State:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtState" runat="server" CssClass="TextBox" Height="25px" Width="180px"
                            TabIndex="8"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="txtStateRequired" runat="server" ControlToValidate="txtState"
                            CssClass="failureNotification" ErrorMessage="State is required." ToolTip="State is required."
                            ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                    </td>
                    <%-- <td>
                        <asp:Label ID="lblAddress" runat="server" AssociatedControlID="txtAddress" Font-Size="Medium">HomeAddress:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="TextBox" TextMode="MultiLine"
                            Width="149px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="AddressRequired" runat="server" ControlToValidate="txtAddress"
                            CssClass="failureNotification" ErrorMessage="Home Address is required." ToolTip="Address is required."
                            ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                    </td> --%>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail">E-mail Address:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="TextBox" Height="23px" Width="180px"
                            TabIndex="4"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="EmailRequired1" runat="server" ControlToValidate="txtEmail"
                            CssClass="failureNotification" ErrorMessage="E-mail Address is required." ToolTip="E-mail is required."
                            ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="EmailRequired" ControlToValidate="txtEmail" Text="(Invalid email)"
                            CssClass="failureNotification" ErrorMessage="Invalid email." ToolTip="Invalid email."
                            ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                            ValidationGroup="RegisterUserValidationGroup" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblPinCode" runat="server" AssociatedControlID="txtPinCode">Zip Code:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPinCode" runat="server" CssClass="TextBox" Height="21px" Width="180px"
                            TabIndex="9"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="PinCodeRequired" runat="server" ControlToValidate="txtPinCode"
                            CssClass="failureNotification" ErrorMessage="Zip Code is required." ToolTip="Pin Code is required."
                            ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regexpcontactPinCode" runat="server" ControlToValidate="txtPinCode"
                            ValidationGroup="RegisterUserValidationGroup" Display="Dynamic" ForeColor="Red"
                            ErrorMessage="Should be 5 Digits" ValidationExpression="^\d{5}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblHouseNumber" runat="server" AssociatedControlID="txtHouseNo">HouseNumber:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtHouseNo" runat="server" CssClass="TextBox" Height="23px" Width="180px"
                            TabIndex="5"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="HouseNoRequired" runat="server" ControlToValidate="txtHouseNo"
                            CssClass="failureNotification" ErrorMessage="House Number is required." ToolTip="House Number is required."
                            ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
        </fieldset>
        <fieldset runat="server" id="fieldset2" visible="false">
            <h3>
                <strong>Create User Credentials</strong></h3>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblSecurityKey" runat="server" AssociatedControlID="txtSecurityKey">Security Key:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSecurityKey" runat="server" CssClass="TextBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSecurityKey"
                            CssClass="failureNotification" ErrorMessage="Security Key is required." ToolTip="Security Key is required."
                            ValidationGroup="RegisterUserValidationGroup1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAccount" runat="server" AssociatedControlID="txtAccountId">Create User Id:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAccountId" runat="server" CssClass="TextBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="txtAccountIdRequired" runat="server" ControlToValidate="txtAccountId"
                            CssClass="failureNotification" ErrorMessage="Account ID is required." ToolTip="Account ID is required."
                            ValidationGroup="RegisterUserValidationGroup1"></asp:RequiredFieldValidator>
                        <%--<asp:RegularExpressionValidator ID="ConfirmEmailRegex" ControlToValidate="txtConfirmEmail"
                            Text="(Invalid email)" CssClass="failureNotification" ErrorMessage="Invalid email."
                            ToolTip="Invalid email." ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                            ValidationGroup="RegisterUserValidationGroup1" runat="server" />--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword">Create Password:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="TextBox" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtPassword"
                            CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
                            ValidationGroup="RegisterUserValidationGroup1"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="PasswordExpressionValidator" runat="server" ControlToValidate="txtPassword"
                            ValidationGroup="RegisterUserValidationGroup1" Display="Dynamic" ForeColor="Red"
                            ErrorMessage="Invalid Password(6 - 10 characters required)" ValidationExpression="^.{6,10}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblConfirmPassword" runat="server" AssociatedControlID="txtConfirmPassword">Confirm Password:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="TextBox" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtConfirmPassword" CssClass="failureNotification"
                            Display="Dynamic" ErrorMessage="Confirm Password is required." ID="ConfirmPasswordRequired"
                            runat="server" ToolTip="Confirm Password is required." ValidationGroup="RegisterUserValidationGroup1"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="txtPassword"
                            ControlToValidate="txtConfirmPassword" CssClass="failureNotification" Display="Dynamic"
                            ErrorMessage="The Password and Confirmation Password must match." ValidationGroup="RegisterUserValidationGroup1">*</asp:CompareValidator>
                        <asp:RegularExpressionValidator ID="PasswordExpressionValidator1" runat="server"
                            ControlToValidate="txtConfirmPassword" ValidationGroup="RegisterUserValidationGroup1"
                            Display="Dynamic" ForeColor="Red" ErrorMessage="Invalid Password(6 - 10 characters required)"
                            ValidationExpression="^.{6,10}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSecuritQuestion1" runat="server" AssociatedControlID="ddlSecurityQuestion1">Security Question1:</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSecurityQuestion1" runat="server" CssClass="TextBox">
                            <asp:ListItem Value='0' Text='Select your Question1'></asp:ListItem>
                            <asp:ListItem Value='1' Text='What is your birth place?'></asp:ListItem>
                            <asp:ListItem Value='2' Text='What is your last name?'></asp:ListItem>
                            <asp:ListItem Value='3' Text='What is your nick name?'></asp:ListItem>
                            <asp:ListItem Value='4' Text='What is your first scool name?'></asp:ListItem>
                            <asp:ListItem Value='5' Text='What is your favorite food?'></asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="SecurityQuestionRequired" runat="server" ControlToValidate="ddlSecurityQuestion1"
                            InitialValue="0" CssClass="failureNotification" ErrorMessage="Security Question1 is required."
                            ToolTip="Security Question1 is required." ValidationGroup="RegisterUserValidationGroup1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAnswer1" runat="server" AssociatedControlID="txtAnswer1">Enter your Answer1:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAnswer1" runat="server" CssClass="TextBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="txtAnswer1"
                            CssClass="failureNotification" ErrorMessage="Answer1 is required." ToolTip="Answer1 is required."
                            ValidationGroup="RegisterUserValidationGroup1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSecuritQuestion2" runat="server" AssociatedControlID="ddlSecurityQuestion2">Security Question2:</asp:Label>
                    </td>
                    <td>
                        <%--<asp:TextBox ID="City" runat="server" CssClass="textEntry"></asp:TextBox>--%>
                        <asp:DropDownList ID="ddlSecurityQuestion2" runat="server" CssClass="TextBox">
                            <asp:ListItem Value='0' Text='Select your Question2'></asp:ListItem>
                            <asp:ListItem Value='1' Text='What is your birth place?'></asp:ListItem>
                            <asp:ListItem Value='2' Text='What is your last name?'></asp:ListItem>
                            <asp:ListItem Value='3' Text='What is your nick name?'></asp:ListItem>
                            <asp:ListItem Value='4' Text='What is your first scool name?'></asp:ListItem>
                            <asp:ListItem Value='5' Text='What is your favorite food?'></asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlSecurityQuestion2"
                            InitialValue="0" CssClass="failureNotification" ErrorMessage="Security Question2 is required."
                            ToolTip="Security Question2 is required." ValidationGroup="RegisterUserValidationGroup1"></asp:RequiredFieldValidator>
                        <br />
                        <asp:CompareValidator ID="SecurityQuestionCompareValidator" runat="server" ControlToCompare="ddlSecurityQuestion1"
                            ControlToValidate="ddlSecurityQuestion2" CssClass="failureNotification" Display="Dynamic"
                            Operator="NotEqual" ValueToCompare="0" ErrorMessage="Please select differant question."
                            ValidationGroup="RegisterUserValidationGroup1"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAnswer2" runat="server" AssociatedControlID="txtAnswer2">Enter your Answer2:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAnswer2" runat="server" CssClass="TextBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="Answer2Required" runat="server" ControlToValidate="txtAnswer2"
                            CssClass="failureNotification" ErrorMessage="Answer2 is required." ToolTip="Answer2 is required."
                            ValidationGroup="RegisterUserValidationGroup1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
        </fieldset>
        <p style="text-align: center;">
            <asp:Button ID="btnHome" runat="server" Text="Home" PostBackUrl="~/Home.aspx" CssClass="button"
                Font-Bold="True" />
            <asp:Button ID="btnNext" runat="server" Text="Next" ValidationGroup="RegisterUserValidationGroup"
                OnClick="btnNext_Click" CssClass="button" TabIndex="10" />
            <asp:Button ID="btnRegister" runat="server" Text="Register" Visible="false" OnClick="btnRegister_Click"
                ValidationGroup="RegisterUserValidationGroup1" CssClass="button" />
            <asp:Button ID="btnBack1" runat="server" Text="Back" OnClientClick="window.history.back();"
                CssClass="button" Font-Bold="True" />
            <asp:Button ID="btnBack" runat="server" Text="Back" Visible="false" OnClick="btnBack_Click"
                CssClass="button" />
        </p>
        <%--<p class="submitButton">
            <asp:Button ID="btnBack" runat="server" Text="Back" Visible="false" OnClick="btnBack_Click" Font-Bold="True" Height="30px" Width="65px" />
            <asp:Button ID="btnRegister" runat="server" Text="Register" Visible="false" OnClick="btnRegister_Click"
                ValidationGroup="RegisterUserValidationGroup1" Font-Bold="True" Height="30px" Width="65px" />
            <asp:Button ID="butnhome" runat="server" Text="Button" Height="30px" Width="65px" />
        </p>--%>
        <asp:Label ID="lblMessage" Style="color: Red;" runat="server"></asp:Label>
    </div>
    <%--</ContentTemplate>--%>
    <%--<CustomNavigationTemplate>
                </CustomNavigationTemplate>
            </asp:CreateUserWizardStep>
        </WizardSteps>--%>
    <%--</asp:CreateUserWizard>--%>
</asp:Content>
