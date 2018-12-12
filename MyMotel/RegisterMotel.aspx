<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="RegisterMotel.aspx.cs" Inherits="MyMotel.RegisterMotel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function successMessage() {
            alert("Motel Registered Successfully");
            window.location.assign("RegisterMotel.aspx")
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%-- <asp:ScriptManager ID="ScriptManager1" runat="server">        
    </asp:ScriptManager>--%>
    <fieldset class="register">
        <legend>Register Motel</legend>
        <%--<asp:ValidationSummary ID="RegisterMotelValidationSummary" runat="server" CssClass="failureNotification" 
                         ValidationGroup="RegisterMotelValidationSummary"/>--%>
        <table cellspacing="20">
            <tr>
                <td>
                    <asp:Label ID="lblMotelName" runat="server" AssociatedControlID="txtMotelName">Motel Name:</asp:Label>
                    <asp:TextBox ID="txtMotelName" runat="server" CssClass="TextBox" TabIndex="1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="MotelNameRequired" runat="server" ControlToValidate="txtMotelName"
                        CssClass="failureNotification" ErrorMessage="Motel Name is required." Text="Motel Name is required."
                        ValidationGroup="RegisterMotelValidationSummary">*</asp:RequiredFieldValidator>
                </td>
                  <td>
                    <asp:Label ID="lblCity" runat="server" AssociatedControlID="ddlCity" TabIndex="4">City:</asp:Label>
                    <%--<asp:TextBox ID="City" runat="server" CssClass="textEntry"></asp:TextBox>--%>
                    <asp:DropDownList ID="ddlCity" runat="server" CssClass="TextBox">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="CityRequired" runat="server" ControlToValidate="ddlCity"
                        InitialValue="0" CssClass="failureNotification" ErrorMessage="City is required."
                        ToolTip="City is required." ValidationGroup="RegisterMotelValidationSummary">*</asp:RequiredFieldValidator>
                </td>            
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblAddress" runat="server" AssociatedControlID="txtAddress" TabIndex="2">Motel Address:</asp:Label>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="TextBox" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="AddressRequired" runat="server" ControlToValidate="txtAddress"
                        CssClass="failureNotification" ErrorMessage="Address is required." ToolTip="Address is required."
                        ValidationGroup="RegisterMotelValidationSummary">*</asp:RequiredFieldValidator>
                </td>
                  <td>
                    <asp:Label ID="lblState" runat="server" AssociatedControlID="ddlState" TabIndex="5">State:</asp:Label>
                    <%--<asp:TextBox ID="State" runat="server" CssClass="textEntry"></asp:TextBox>--%>
                    <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="true" CssClass="TextBox"
                        OnSelectedIndexChanged="State_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="StateRequired" runat="server" ControlToValidate="ddlState"
                        InitialValue="0" CssClass="failureNotification" ErrorMessage="State is required."
                        ToolTip="State is required." ValidationGroup="RegisterMotelValidationSummary">*</asp:RequiredFieldValidator>
                </td>
        
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTelephone" runat="server" AssociatedControlID="txtTelephone" TabIndex="3">Contact Number:</asp:Label>
                    <asp:TextBox ID="txtTelephone" runat="server" CssClass="TextBox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="TelephoneRequired" runat="server" ControlToValidate="txtTelephone"
                        CssClass="failureNotification" ErrorMessage="Telephone is required." ToolTip="Telephone is required."
                        ValidationGroup="RegisterMotelValidationSummary">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="TelephoneValidator" runat="server" ControlToValidate="txtTelephone"
                        ValidationGroup="RegisterMotelValidationSummary" Display="Dynamic" ForeColor="Red"
                        ErrorMessage="Should be 10 Digits" ValidationExpression="^\d{10}$"></asp:RegularExpressionValidator>
                </td> 
  
                <td>
                    <asp:Label ID="lblPinCode" runat="server" AssociatedControlID="txtPinCode" TabIndex="6">Zip Code:</asp:Label>
                    <asp:TextBox ID="txtPinCode" runat="server" CssClass="TextBox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PinCodeRequired" runat="server" ControlToValidate="txtPinCode"
                        CssClass="failureNotification" ErrorMessage="Pin Code is required." ToolTip="Pin Code is required."
                        ValidationGroup="RegisterMotelValidationSummary">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regexpPinCode" runat="server" ControlToValidate="txtPinCode"
                        ValidationGroup="RegisterMotelValidationSummary" Display="Dynamic" ForeColor="Red"
                        ErrorMessage="Should be 5 Digits" ValidationExpression="^\d{5}$"></asp:RegularExpressionValidator>
                </td>
                <%--<td>
  <asp:Label ID="lblCost" runat="server" AssociatedControlID="txtCost">Cost per Night:</asp:Label>
                                <asp:TextBox ID="txtCost" runat="server" CssClass="TextBox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="CostRequired" runat="server" ControlToValidate="txtCost" 
                                     CssClass="failureNotification" ErrorMessage="Cost is required." Text="Cost is required." 
                                     ValidationGroup="RegisterMotelValidationSummary">*</asp:RequiredFieldValidator>       
                                     <asp:RegularExpressionValidator ID="CostValidator1" runat="server" ControlToValidate="txtCost"
                                                        ValidationGroup="RegisterMotelValidationSummary" Display="Dynamic" ForeColor="Red" ErrorMessage="Should be Integer"
                                                        ValidationExpression="^(?!0+$)\d+$"></asp:RegularExpressionValidator>                              
    
        </td>--%>
            </tr>
            <tr>
            <td>
                    <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail" TabIndex="3">E-mail Address:</asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="TextBox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="EmailRequired1" runat="server" ControlToValidate="txtEmail"
                        CssClass="failureNotification" ErrorMessage="E-mail is required." ToolTip="E-mail is required."
                        ValidationGroup="RegisterMotelValidationSummary">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="EmailRequired" ControlToValidate="txtEmail" Text="(Invalid email)"
                        CssClass="failureNotification" ErrorMessage="Invalid email." ToolTip="Invalid email."
                        ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                        ValidationGroup="RegisterMotelValidationSummary" runat="server" />
                </td>
                <td>
                    <asp:Label ID="lblStarCategory" runat="server" AssociatedControlID="ddlStarCategory" TabIndex="8">Ratings:</asp:Label>
                    <%--<asp:TextBox ID="StarCategory" runat="server" CssClass="textEntry"></asp:TextBox>--%>
                    <asp:DropDownList ID="ddlStarCategory" runat="server" CssClass="TextBox">
                        <asp:ListItem Value='0' Text='Select Rating'></asp:ListItem>
                        <asp:ListItem Value='3' Text='3 of 3'></asp:ListItem>
                        <asp:ListItem Value='2' Text='2 of 3'></asp:ListItem>
                        <asp:ListItem Value='1' Text='1 of 3'></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="StarCategoryRequired" runat="server" ControlToValidate="ddlStarCategory"
                        InitialValue="0" CssClass="failureNotification" ErrorMessage="Star Category is required."
                        ToolTip="Star Category is required." ValidationGroup="RegisterMotelValidationSummary">*</asp:RequiredFieldValidator>
                </td>
                </tr>
            <tr>
                <td>
                    <asp:FileUpload ID="motelImageUpload" runat="server" />
                    <asp:RequiredFieldValidator ID="imageRequired" runat="server" ControlToValidate="motelImageUpload"
                        CssClass="failureNotification" ErrorMessage="Motel image is required." ToolTip="Motel image is required."
                        ValidationGroup="RegisterMotelValidationSummary">*</asp:RequiredFieldValidator>
                </td>
                <td>
                </td>
            </tr>
        </table>
        <asp:Button ID="RegisterMotelButton" runat="server" Text="Register Motel" ValidationGroup="RegisterMotelValidationSummary"
            CssClass="button" OnClick="RegisterMotelButton_Click" />
        <asp:Button ID="btnHome" runat="server" Text="Home" PostBackUrl="~/Home.aspx" CssClass="button" />
        <br />
        <asp:Label ID="lblregistermessage" runat="server"></asp:Label>
    </fieldset>
</asp:Content>
