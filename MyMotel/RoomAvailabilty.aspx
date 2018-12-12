<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="RoomAvailabilty.aspx.cs" Inherits="MyMotel.RoomAvailabilty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">        
    </asp:ScriptManager>--%>
    <fieldset style="width:45%;">
    <legend>Rooms Availability</legend>
        <h2>
        All fields are mandatory</h2>
        <%--<asp:ValidationSummary ID="RoomsAvailableValidationSummary" runat="server" CssClass="failureNotification"
            ValidationGroup="RoomsAvailableValidationSummary" />--%>
        <table>
            <tr>
                <td valign="top">
                    Motel Name
                </td>
                <td>
                    <asp:DropDownList ID="ddlMotels" runat="server" CssClass="TextBox" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlMotels_SelectedIndexChanged">
                    </asp:DropDownList> <br />
                    <asp:RequiredFieldValidator ID="MotelRequired" runat="server" ControlToValidate="ddlMotels"
                        InitialValue="0" CssClass="failureNotification" ErrorMessage="Motel is required."
                        ToolTip="Motel is required." ValidationGroup="RoomsAvailableValidationSummary"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    Queen Size Rooms
                </td>
                <td>
                    <asp:DropDownList ID="ddlSingleBHKRooms" runat="server" CssClass="TextBox">
                        <asp:ListItem Value='0' Text='0'></asp:ListItem>
                        <asp:ListItem Value='1' Text='1'></asp:ListItem>
                        <asp:ListItem Value='2' Text='2'></asp:ListItem>
                        <asp:ListItem Value='3' Text='3'></asp:ListItem>
                        <asp:ListItem Value='4' Text='4'></asp:ListItem>
                        <asp:ListItem Value='5' Text='5'></asp:ListItem>
                        <asp:ListItem Value='6' Text='6'></asp:ListItem>
                        <asp:ListItem Value='7' Text='7'></asp:ListItem>
                        <asp:ListItem Value='8' Text='8'></asp:ListItem>
                        <asp:ListItem Value='9' Text='9'></asp:ListItem>
                        <asp:ListItem Value='10' Text='10'></asp:ListItem>
                    </asp:DropDownList><br /><br />
                    <%--<asp:RequiredFieldValidator ID="SingleBHKRoomsRequired" runat="server" ControlToValidate="ddlSingleBHKRooms"
                    InitialValue="0" CssClass="failureNotification" ErrorMessage="Single BHK  count is required."
                    ToolTip="Single BHK Rooms count is required." ValidationGroup="RoomsAvailableValidationSummary">*</asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    King Size Rooms
                </td>
                <td>
                    <asp:DropDownList ID="ddlDoubleBHKRooms" runat="server" CssClass="TextBox">
                        <asp:ListItem Value='0' Text='0'></asp:ListItem>
                        <asp:ListItem Value='1' Text='1'></asp:ListItem>
                        <asp:ListItem Value='2' Text='2'></asp:ListItem>
                        <asp:ListItem Value='3' Text='3'></asp:ListItem>
                        <asp:ListItem Value='4' Text='4'></asp:ListItem>
                        <asp:ListItem Value='5' Text='5'></asp:ListItem>
                        <asp:ListItem Value='6' Text='6'></asp:ListItem>
                        <asp:ListItem Value='7' Text='7'></asp:ListItem>
                        <asp:ListItem Value='8' Text='8'></asp:ListItem>
                        <asp:ListItem Value='9' Text='9'></asp:ListItem>
                        <asp:ListItem Value='10' Text='10'></asp:ListItem>
                    </asp:DropDownList><br /><br />
                    <%--<asp:RequiredFieldValidator ID="DoubleBHKRoomsRequired" runat="server" ControlToValidate="ddlDoubleBHKRooms"
                    InitialValue="0" CssClass="failureNotification" ErrorMessage="Double BHK Rooms count is required."
                    ToolTip="Double BHK Rooms count is required." ValidationGroup="RoomsAvailableValidationSummary">*</asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    Double size Rooms
                </td>
                <td>
                    <asp:DropDownList ID="ddlTripleBHKRooms" runat="server" CssClass="TextBox">
                        <asp:ListItem Value='0' Text='0'></asp:ListItem>
                        <asp:ListItem Value='1' Text='1'></asp:ListItem>
                        <asp:ListItem Value='2' Text='2'></asp:ListItem>
                        <asp:ListItem Value='3' Text='3'></asp:ListItem>
                        <asp:ListItem Value='4' Text='4'></asp:ListItem>
                        <asp:ListItem Value='5' Text='5'></asp:ListItem>
                        <asp:ListItem Value='6' Text='6'></asp:ListItem>
                        <asp:ListItem Value='7' Text='7'></asp:ListItem>
                        <asp:ListItem Value='8' Text='8'></asp:ListItem>
                        <asp:ListItem Value='9' Text='9'></asp:ListItem>
                        <asp:ListItem Value='10' Text='10'></asp:ListItem>
                    </asp:DropDownList><br /><br />
                    <%-- <asp:RequiredFieldValidator ID="TripleBHKRoomsRequired" runat="server" ControlToValidate="ddlTripleBHKRooms" InitialValue="0"
                                     CssClass="failureNotification" ErrorMessage="Triple BHK Rooms count is required." ToolTip="Triple BHK Rooms count is required." 
                                     ValidationGroup="RoomsAvailableValidationSummary">*</asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    Queen Size Rooms Cost($)
                </td>
                <td>
                    <asp:TextBox ID="txtQeenSizeCost" runat="server" CssClass="TextBox"></asp:TextBox> 
                   <br /> <asp:RequiredFieldValidator ID="CostRequired" runat="server" ControlToValidate="txtQeenSizeCost"
                        CssClass="failureNotification" ErrorMessage="Queen Size Rooms Cost is required."
                        Text="Queen Size Rooms Cost is required." ValidationGroup="RoomsAvailableValidationSummary"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="CostValidator1" runat="server" ControlToValidate="txtQeenSizeCost"
                        ValidationGroup="RoomsAvailableValidationSummary" Display="Dynamic" ForeColor="Red"
                        ErrorMessage="Should be Integer" ValidationExpression="^(?!0+$)\d+$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    King Size Rooms Cost($)
                </td>
                <td>
                    <asp:TextBox ID="txtKingSizeCost" runat="server" CssClass="TextBox"></asp:TextBox> 
                    <br /><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtKingSizeCost"
                        CssClass="failureNotification" ErrorMessage="King Size Rooms Cost is required."
                        Text="King Size Rooms Cost is required." ValidationGroup="RoomsAvailableValidationSummary"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtKingSizeCost"
                        ValidationGroup="RoomsAvailableValidationSummary" Display="Dynamic" ForeColor="Red"
                        ErrorMessage="Should be Integer" ValidationExpression="^(?!0+$)\d+$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    Double Size Rooms Cost($)
                </td>
                <td>
                    <asp:TextBox ID="txtSuitesCost" runat="server" CssClass="TextBox"></asp:TextBox> 
                    <br /><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSuitesCost"
                        CssClass="failureNotification" ErrorMessage="Suites Cost is required." Text="Suites Cost is required."
                        ValidationGroup="RoomsAvailableValidationSummary"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtSuitesCost"
                        ValidationGroup="RoomsAvailableValidationSummary" Display="Dynamic" ForeColor="Red"
                        ErrorMessage="Should be Integer" ValidationExpression="^(?!0+$)\d+$"></asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>
                     <asp:Button ID="UpdateButton" runat="server" CommandName="MoveNext" Text="Update"
                        ValidationGroup="RoomsAvailableValidationSummary" OnClick="UpdateButton_Click" CssClass="button" /> 
                        
                        <asp:Button ID="btnHome" runat="server" Text="Home" PostBackUrl="~/Home.aspx" CssClass="button" />                                       
 
        <asp:Label ID="lblroomavail" runat="server" Text="Label"></asp:Label>
    </fieldset>
</asp:Content>
