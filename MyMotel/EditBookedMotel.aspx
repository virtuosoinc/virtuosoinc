<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="EditBookedMotel.aspx.cs" Inherits="MyMotel.EditBookedMotel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
 <link href="css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui-1.8.19.custom.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".txtDate").datepicker({
                minDate: 0
            });
        });

        function successMessage() {
            alert("Motel Reservation Updated Successfully");
            window.location.assign("BookingDetails.aspx")
        }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset class="register">
        <legend>Update your Reservation</legend>
        <asp:Label ID="lblRoomLimitError" runat="server" CssClass="failureNotification"></asp:Label>
        <table>
                        <tr>
                            <!--<td>
                                <asp:Image ID="hotelImage" runat="server" Height="200px" Width="200px" />
                            </td>-->
                            <td valign="top">
                                <asp:Label ID="lblmotelName" runat="server"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lbladdress" runat="server"></asp:Label><br />
                                <br />
                                <b>Cost per Night:</b>
                                <asp:Label ID="lblCost" runat="server"></asp:Label><br />
                                <br />
                                <b>Rooms Available:</b>
                                <asp:Label ID="lblRoomsAvailable" runat="server"></asp:Label><br />
                                <asp:HiddenField ID="hdnRoomsType1Count" runat="server" />
                                <asp:HiddenField ID="hdnRoomsType2Count" runat="server" />
                                <asp:HiddenField ID="hdnRoomsType3Count" runat="server" />
                                <br />
                                <b>Person Limit: </b>
                                <asp:Label ID="lblAdults" runat="server"></asp:Label><br /><br />
                                <b>Extra Person: </b>1
                                <br /><br />
                                <b>Cost @Extra Person: </b>$10
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top;">
                                <b>Room Type:</b>
                                <asp:Label ID="lblRoomType" runat="server" Visible="false"></asp:Label>
                                <asp:HiddenField ID="hdnRoomTypeSelected" runat="server" /><br />
                                <asp:DropDownList ID="ddlRoomType" runat="server" CssClass="TextBox" OnSelectedIndexChanged="ddlRoomType_SelectedIndexChanged"
                                    AutoPostBack="true">
                                    <asp:ListItem Value='0' Text='Select Room Type'></asp:ListItem>
             <asp:ListItem Value='1' Text='Single BHK'></asp:ListItem>
             <asp:ListItem Value='2' Text='Double BHK'></asp:ListItem>
             <asp:ListItem Value='3' Text='Triple BHK'></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlRoomType"
                                    InitialValue="0" CssClass="failureNotification" ErrorMessage="Room Type count is required."
                                    ToolTip="Room Type count is required." ValidationGroup="RoomBookingValidationSummary">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="vertical-align: top;">
                                <asp:HiddenField ID="hdnMotelId" runat="server" />
                                <b>Check-In Date:</b>
                                <asp:Label ID="lblSelectedCheckinDate" runat="server" Visible="false"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtCheckinDate" class="txtDate" runat="server" />
                                <asp:RequiredFieldValidator ID="CheckinDateRequired" runat="server" ControlToValidate="txtCheckinDate"
                                    CssClass="failureNotification" ErrorMessage="CheckinDate is required." ToolTip="CheckinDate is required."
                                    ValidationGroup="RoomBookingValidationSummary">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="vertical-align: top;">
                                <b>Check-Out Date:</b>
                                <asp:Label ID="lblSelectedCheckoutDate" runat="server" Visible="false"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtCheckoutDate" class="txtDate" runat="server" />
                                <asp:RequiredFieldValidator ID="CheckoutDateRequired" runat="server" ControlToValidate="txtCheckoutDate"
                                    CssClass="failureNotification" ErrorMessage="CheckoutDate is required." ToolTip="CheckoutDate is required."
                                    ValidationGroup="RoomBookingValidationSummary">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="txtCheckinDate"
                                    ControlToValidate="txtCheckoutDate" CssClass="failureNotification" Display="Dynamic"
                                    Operator="GreaterThanEqual" Type="Date" ErrorMessage="Checkout date must be greater than checkin date."
                                    ValidationGroup="RoomBookingValidationSummary">*</asp:CompareValidator>
                            </td>
                            <td style="vertical-align: top;">
                                <b>Adults:</b>
                                <asp:Label ID="lblAdultCount" runat="server" Visible="false"></asp:Label><br />
                                <asp:DropDownList ID="ddlAdultCount" runat="server" CssClass="DropDownCount">
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
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlAdultCount"
                                    InitialValue="0" CssClass="failureNotification" ErrorMessage="Adult count is required."
                                    ToolTip="Adult count is required." ValidationGroup="RoomBookingValidationSummary">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="vertical-align: top;">
                                <b>Children:</b>
                                <asp:Label ID="lblChildrenCount" runat="server" Visible="false"></asp:Label><br />
                                <asp:DropDownList ID="ddlChildrenCount" runat="server" CssClass="DropDownCount">
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
                                </asp:DropDownList>
                            </td>
                            <td style="vertical-align: top;">
                                <b>Rooms:</b>
                                <asp:Label ID="lblSelectedRoomCount" runat="server" Visible="false"></asp:Label>
                                <asp:HiddenField ID="hdnRoomsCount" runat="server" />
                                <br />
                                <asp:DropDownList ID="ddlroomsCount" runat="server" CssClass="DropDownCount">
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
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="roomsCountRequired" runat="server" ControlToValidate="ddlroomsCount"
                                    InitialValue="0" CssClass="failureNotification" ErrorMessage="Rooms count is required."
                                    ToolTip="Rooms count is required." ValidationGroup="RoomBookingValidationSummary">*</asp:RequiredFieldValidator>
                            </td>
                            <td style="vertical-align: top;">
                                <asp:Label ID="lblTotalCost" Text="Total Cost($):" runat="server"
                                    Font-Bold="true"></asp:Label>
                                <asp:Label ID="lblTotalCostVal" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:Button ID="UpdateCostButton" runat="server" Text="Calculate Total Cost" 
                                 ValidationGroup="RoomBookingValidationSummary" 
            onclick="UpdateCostButton_Click" CssClass="button" />
        <asp:Button ID="UpdateMotelButton" runat="server" Text="Update" 
                                 ValidationGroup="RoomBookingValidationSummary" 
            onclick="UpdateMotelButton_Click" CssClass="button" />
            <asp:Button ID="btnHome" runat="server" CssClass="button" Text="Home" PostBackUrl="~/Home.aspx" /> 
            <asp:Button ID="btnBack" runat="server" Text="Cancel" PostBackUrl="~/BookingDetails.aspx" CssClass="button"/>
    </fieldset>
</asp:Content>
