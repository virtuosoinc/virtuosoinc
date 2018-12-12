<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="UpdateMotel.aspx.cs" Inherits="MyMotel.UpdateMotel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblupdatemessage" runat="server" Text="Label"></asp:Label>
    <fieldset>
    <legend>Update Motel</legend>
        <asp:GridView ID="MotelDetailsGrid" AutoGenerateColumns="false" OnRowDeleting="MotelDetailsGrid_RowDeleting"
            runat="server" DataKeyNames="MotelId" Width="900">
            <Columns>
                <asp:BoundField DataField="MotelName" HeaderText="Motel Name" ItemStyle-Width="190" />
                <asp:BoundField DataField="Address" HeaderText="Motel Address" ItemStyle-Width="190" />
                <asp:BoundField DataField="City" HeaderText="City" ItemStyle-Width="80" />
                <asp:BoundField DataField="State" HeaderText="State" ItemStyle-Width="80" />
                <asp:BoundField DataField="Pincode" HeaderText="Zipcode" ItemStyle-Width="50" />
                <asp:BoundField DataField="TelephoneNumber" HeaderText="Contact Number" ItemStyle-Width="120" />
                <asp:BoundField DataField="StarCategory" HeaderText="Rating" ItemStyle-Width="50" />
                <%--<asp:BoundField DataField="Cost" HeaderText="Cost per Night($)" ItemStyle-Width="120"/>--%>
                <%--<asp:BoundField DataField="Cost" HeaderText="Cost" />--%>
                <%--<asp:BoundField DataField="Website" HeaderText="Website" />
                        <asp:BoundField DataField="MobileNumber" HeaderText="MobileNumber" />    --%>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("~/EditMotel.aspx?motelId={0}", HttpUtility.UrlEncode(Eval("MotelId").ToString()))%>'
                            Text="Update"></asp:HyperLink>
                        <%--<asp:ImageButton ID="imgbtnDelete" CommandName="Delete" Text="Edit" runat="server"
                     ImageUrl="~/Images/Cancel.jpg" ToolTip="Cancel" Height="20px" Width="20px" />      --%>
                        <asp:LinkButton ID="lnkDelete" CommandName="Delete" Text="Delete" runat="server"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="btnHome" runat="server" Text="Home" PostBackUrl="~/Home.aspx" CssClass="button" />
    </fieldset>
</asp:Content>
