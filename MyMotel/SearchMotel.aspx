<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SearchMotel.aspx.cs" Inherits="MyMotel.SearchMotel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="Scripts/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ValidateSearch() {
            var cityName = $("#MainContent_ddlCity").val();
            var rating = $("#MainContent_StarCategory").val();
            if (cityName == 0 && rating == 0) {
                $("#lblValidationMessage").text("Please select City Name / Rating");
                return false;
            }
            //        else if (cityName == 0) {
            //            $("#lblValidationMessage").text("Please select City Name");
            //            return false;
            //        }
            //        else if (rating == 0) {
            //            $("#lblValidationMessage").text("Please select Rating");
            //            return false;
            //        }
            else {
                $("#lblValidationMessage").text("");
            }
        }
    </script>
    <style type="text/css">
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset class="login">
        <legend>Search for a Motel either by Selecting City (or) by Rating</legend>
        <label id="lblValidationMessage" class="failureNotification" visible="false">
        </label>
        <p>
            <asp:Label ID="CityNameLabel" runat="server" AssociatedControlID="ddlCity">City:</asp:Label>
            <asp:DropDownList ID="ddlCity" runat="server" CssClass="DropDownNumber">
            </asp:DropDownList>
        </p>
        <p>&nbsp;&nbsp;&nbsp;&nbsp;(or)</p>
        <p>
            <asp:Label ID="RatingLabel" runat="server" AssociatedControlID="StarCategory">Rating:</asp:Label>
            <asp:DropDownList ID="StarCategory" runat="server" CssClass="DropDownNumber">
                <asp:ListItem Value='0' Text='Select Rating' style="color:Gray;"></asp:ListItem>
                <asp:ListItem Value='3' Text='3 of 3'></asp:ListItem>
                <asp:ListItem Value='2' Text='2 of 3'></asp:ListItem>
                <asp:ListItem Value='1' Text='1 of 3'></asp:ListItem>
            </asp:DropDownList>
        </p>        
        <p>
            <asp:Button ID="SearchButton" runat="server" CommandName="MoveNext" Text="Search"
                ValidationGroup="RegisterUserValidationGroup" OnClientClick="return ValidateSearch();"
                OnClick="SearchButton_Click" CssClass="button" Height="30px" Width="65px" />
            <asp:Button ID="btnHome" runat="server" PostBackUrl="~/Home.aspx" CssClass="button"
                Text="Home" Height="30px" Width="65px"/>
        </p>
    </fieldset>
    <fieldset id="searchField" runat="server" visible="false">
        <legend>Search Results</legend>
        <div style="text-align: center;">
            <label id="lblReserveMessage" runat="server" visible="false">
                <h2>
                    To make a reservation for a Motel select the corresponding Checkbox.</h2>
            </label>
            <asp:GridView ID="SerchResultsGrid" AutoGenerateColumns="False" runat="server" DataKeyNames="MotelId"
                HorizontalAlign="Center" Width="616px">
                <Columns>
                    <asp:BoundField DataField="MotelName" HeaderText="Motel Name" />
                    <asp:BoundField DataField="Address" HeaderText="Motel Address" />
                    <asp:BoundField DataField="City" HeaderText="City" />
                    <asp:BoundField DataField="Pincode" HeaderText="Zipcode" />
                    <asp:BoundField DataField="State" HeaderText="State" />
                    <asp:BoundField DataField="TelephoneNumber" HeaderText="Contact Number" />
                    <asp:BoundField DataField="StarCategory" HeaderText="Rating" />
                    <%--<asp:BoundField DataField="Cost" HeaderText="Cost per Night" DataFormatString="${0:d}"/>--%>
                    <%--<asp:BoundField DataField="Cost" HeaderText="Cost" />--%>
                    <%--<asp:BoundField DataField="Website" HeaderText="Website" />
                        <asp:BoundField DataField="MobileNumber" HeaderText="MobileNumber" />    --%>
                    <asp:TemplateField ItemStyle-Width="20" HeaderText="Click Here">
                        <ItemTemplate>
                            <%--<asp:HyperLink runat="server" NavigateUrl='<%# string.Format("~/BookMotel.aspx?motelId={0}", HttpUtility.UrlEncode(Eval("MotelId").ToString()))%>'
                    Text="Book"></asp:HyperLink>--%>
                            <asp:CheckBox ID="cbSelect" CssClass="gridCB" runat="server"></asp:CheckBox>
                        </ItemTemplate>

<ItemStyle Width="20px"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <p style="text-align: center; margin-top: 10px;">
                <asp:Button ID="btnReserver" runat="server" Text="Reserve" OnClick="btnReserver_Click"
                    Visible="false" Style="font-size: 18px;" />
            </p>
            <p>
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"
                    Text=""></asp:Label>
            </p>
            <p>
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </p>
        </div>
    </fieldset>
</asp:Content>
