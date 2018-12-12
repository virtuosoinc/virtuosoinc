<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="BookMotel.aspx.cs" Inherits="MyMotel.BookMotel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui-1.8.19.custom.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            SetDatePicker();
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(SetDatePicker);
        });
        function successMessage() {
            alert("Motel Booked Successfully");
            window.location.assign("Home.aspx")
        }
        function bookMotel() {
            var book = confirm('Booking Dates are overalpping for the selected motels. Are you sure to Book?');
            if (book) {
                var checkdates = '<%=CheckDates.ClientID %>';
                $("#" + checkdates).val(false);
                var btnId = '<%=BookRoombtn1.ClientID %>';
                $("#" + btnId).trigger('click');
            }
        }
        function goBack() {
            window.history.back();
        }       
        function SetDatePicker() {            
            $(".txtDate").datepicker({
                minDate: 0 
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <asp:Label ID="lblErrorMessage" runat="server" CssClass="failureNotification"></asp:Label>
    <asp:HiddenField ID="CheckDates" runat="server" Value="true" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Repeater ID="repeater_Motels" runat="server" OnItemDataBound="repeater_Motels_ItemDataBound">
                <ItemTemplate>
        <%--        <asp:ValidationSummary ID="RoomBookingValidationSummary" runat="server" CssClass="failureNotification"
        ValidationGroup="RoomBookingValidationSummary" />--%>
                    <table>
                        <tr>
                            <!--<td>
                                <asp:Image ID="hotelImage" runat="server" Height="200px" Width="200px" />
                            </td>-->
                            <td colspan="5" valign="top">
                               
                               <p style="font-size:medium">
                                   <asp:Label ID="lblResrved" Text="Reserved By:" runat="server" Visible="false" Font-Bold="true"></asp:Label>
                                   <asp:Label ID="lblUserName" runat="server"></asp:Label></p>
                                <br /><br />
                                             
                                <asp:Label ID="lblmotelName" runat="server"></asp:Label>
                               
                                            <asp:Label ID="lbladdress" runat="server"></asp:Label><br /><br />
                               
                                <b>Cost per Night:</b>$<asp:Label ID="lblCost" runat="server"></asp:Label><br /><br />
                                     
                                            <b>Rooms Available:</b>
                                <asp:Label ID="lblRoomsAvailable" runat="server"></asp:Label><br /><br />
                                <asp:HiddenField ID="hdnRoomsType1Count" runat="server" />
                                <asp:HiddenField ID="hdnRoomsType2Count" runat="server" />
                                <asp:HiddenField ID="hdnRoomsType3Count" runat="server" />
                                
                                <b>Persons Limit per Room: </b>
                                <asp:Label ID="lblAdults" runat="server"></asp:Label><br /><br />
                                
                                                <b>Extra Person per Room: </b>1<br /><br />
                                
                                            <b>Cost @Extra Person per Room: </b>$10
                                
                                                             
                            </td>
                        </tr>
                        <tr style="height:50px;"><td colspan="6"></td></tr>
                        <tr>
                            <td style="vertical-align: top;">
                                <br /><b>Room Type:</b>
                                <asp:Label ID="lblRoomType" runat="server" Visible="false"></asp:Label>
                                <asp:HiddenField ID="hdnRoomTypeSelected" runat="server" /><br />
                                <asp:DropDownList ID="ddlRoomType" runat="server" CssClass="TextBox" OnSelectedIndexChanged="ddlRoomType_SelectedIndexChanged"
                                    AutoPostBack="true">
                                    <%--<asp:ListItem Value='0' Text='Select Room Type'></asp:ListItem>
             <asp:ListItem Value='1' Text='Single BHK'></asp:ListItem>
             <asp:ListItem Value='2' Text='Double BHK'></asp:ListItem>
             <asp:ListItem Value='3' Text='Triple BHK'></asp:ListItem>--%>
                                </asp:DropDownList>
                                <br /><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlRoomType"
                                    InitialValue="0" CssClass="failureNotification" ErrorMessage="Room Type count is required."
                                    ToolTip="Room Type count is required." ValidationGroup="RoomBookingValidationSummary"></asp:RequiredFieldValidator>
                            </td>
                            <td style="vertical-align: top;">
                                <asp:HiddenField ID="hdnMotelId" runat="server" />
                                <b>Check-In Date:</b><br /><asp:label ID="lblDateFormat" runat="server">(ex:mm/dd/yyyy)</asp:label> 
                                <asp:Label ID="lblSelectedCheckinDate" runat="server" Visible="false"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtCheckinDate" class="txtDate" runat="server" />
                                <br /><asp:RequiredFieldValidator ID="CheckinDateRequired" runat="server" ControlToValidate="txtCheckinDate"
                                    CssClass="failureNotification" ErrorMessage="CheckinDate is required." ToolTip="CheckinDate is required."
                                    ValidationGroup="RoomBookingValidationSummary"></asp:RequiredFieldValidator>
                            </td>
                            <td style="vertical-align: top;">
                                <b>Check-Out Date:</b><br /><asp:label ID="lblDateFormat1" runat="server">(ex:mm/dd/yyyy)</asp:label>
                                <asp:Label ID="lblSelectedCheckoutDate" runat="server" Visible="false"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtCheckoutDate" class="txtDate" runat="server" />
                                <br /><asp:RequiredFieldValidator ID="CheckoutDateRequired" runat="server" ControlToValidate="txtCheckoutDate"
                                    CssClass="failureNotification" ErrorMessage="CheckoutDate is required." ToolTip="CheckoutDate is required."
                                    ValidationGroup="RoomBookingValidationSummary"></asp:RequiredFieldValidator>
                                <br /><asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="txtCheckinDate"
                                    ControlToValidate="txtCheckoutDate" CssClass="failureNotification" Display="Dynamic"
                                    Operator="GreaterThanEqual" Type="Date" ErrorMessage="Checkout date must be greater <br />than checkin date."
                                    ValidationGroup="RoomBookingValidationSummary"></asp:CompareValidator>
                            </td>
                            <td style="vertical-align: top;">
                                <br /><b>Adults:</b>
                                <asp:Label ID="lblAdultCount" runat="server" Visible="false"></asp:Label><br />
                                <asp:DropDownList ID="ddlAdultCount" runat="server" CssClass="DropDownCount">
                                    <asp:ListItem Value='0' Text=''></asp:ListItem>
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
                                <br /><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlAdultCount"
                                    InitialValue="0" CssClass="failureNotification" ErrorMessage="Adult<br />count<br /> is required."
                                    ToolTip="Adult count is required." ValidationGroup="RoomBookingValidationSummary"></asp:RequiredFieldValidator>
                            </td>
                            <td style="vertical-align: top;">
                                <br /><b>Children:</b>
                                <asp:Label ID="lblChildrenCount" runat="server" Visible="false"></asp:Label><br />
                                <asp:DropDownList ID="ddlChildrenCount" runat="server" CssClass="DropDownCount">
                                    <asp:ListItem Value='0' Text=''></asp:ListItem>
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
                                <br /><b>Rooms:</b>
                                <asp:Label ID="lblSelectedRoomCount" runat="server" Visible="false"></asp:Label>
                                <br />
                                <asp:DropDownList ID="ddlroomsCount" runat="server" CssClass="DropDownCount">
                                    <asp:ListItem Value='0' Text=''></asp:ListItem>
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
                                <br /><asp:RequiredFieldValidator ID="roomsCountRequired" runat="server" ControlToValidate="ddlroomsCount"
                                    InitialValue="0" CssClass="failureNotification" ErrorMessage="Rooms count is required."
                                    ToolTip="Rooms count is required." ValidationGroup="RoomBookingValidationSummary"></asp:RequiredFieldValidator>
                            </td>
                            <td style="vertical-align: top;">
                                <asp:Label ID="lblTotalCost" Text="Total Cost($):" runat="server" Visible="false"
                                    Font-Bold="true"></asp:Label>
                                <asp:Label ID="lblTotalCostVal" runat="server" Visible="false"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:Label ID="lblRoomLimitError" runat="server" CssClass="failureNotification"></asp:Label>
                    <hr />
                </ItemTemplate>
            </asp:Repeater>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Button ID="btnHome" runat="server" CssClass="button" Text="Home" PostBackUrl="~/Home.aspx" />
    <asp:Button ID="BookRoombtn1" runat="server" Text="Reserve" ValidationGroup="RoomBookingValidationSummary" CssClass="button"
        OnClick="BookRoombtn1_Click"/>
    <asp:Button ID="BookRoombtn" runat="server" Text="Confirm" Visible="false" OnClick="BookRoombtn_Click" CssClass="button"/>
    <asp:Button ID="btnBack" runat="server" Text="Back" OnClientClick="goBack();" CssClass="button" />
    <asp:HiddenField ID="myHidden" runat="server" Value="" />
</asp:Content>
