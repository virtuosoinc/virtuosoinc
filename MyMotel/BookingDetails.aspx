<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookingDetails.aspx.cs" Inherits="MyMotel.BookingDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<fieldset>
<legend>Reservation Deatils</legend>
<div style="text-align:center;">
    <asp:GridView ID="BookingDetailsGrid" AutoGenerateColumns="False"  onrowdeleting="BookingDetailsGrid_RowDeleting"
        DataKeyNames="BookingId,MotelName" runat="server" AllowPaging="True"
            OnPageIndexChanging="BookingDetailsGrid_PageIndexChanging" HorizontalAlign="Center"
            OnRowDataBound="BookingDetailsGrid_rowDataBound">
                    <Columns>
                    <asp:BoundField DataField="MotelName" HeaderText="Motel Name" >
                        </asp:BoundField>
                        <asp:BoundField DataField="Address" HeaderText="Motel Address" >
                        </asp:BoundField>
                        <asp:BoundField DataField="StarCategory" HeaderText="Ratings" >
                        </asp:BoundField>
                        <asp:BoundField DataField="CheckinDate" HeaderText="Check-In Date" DataFormatString="{0:MM/dd/yyyy}">
                        </asp:BoundField>
                        <asp:BoundField DataField="CheckoutDate" HeaderText="Check-Out Date" DataFormatString="{0:MM/dd/yyyy}">
                        </asp:BoundField>
                        <asp:BoundField DataField="RoomsBooked" HeaderText="Number of Rooms Reserved" >                      
                        </asp:BoundField>
                       <asp:TemplateField HeaderText="Reserved By">
    <ItemTemplate>
        <%= Session["UserName"]%>
    </ItemTemplate>
</asp:TemplateField>
        <asp:TemplateField ItemStyle-Width="10">
        <ItemTemplate>

        <asp:HyperLink ID="lnkUpdate" runat="server" NavigateUrl='<%# string.Format("~/EditBookedMotel.aspx?motelId={0}&&bookingId={1}", HttpUtility.UrlEncode(Eval("MotelId").ToString()),HttpUtility.UrlEncode(Eval("BookingId").ToString()))%>'
                    Text="Update"></asp:HyperLink>
        <asp:LinkButton ID="lnkUpdate1" runat="server" NavigateUrl='<%# string.Format("~/EditBookedMotel.aspx?motelId={0}&&bookingId={1}", HttpUtility.UrlEncode(Eval("MotelId").ToString()),HttpUtility.UrlEncode(Eval("BookingId").ToString()))%>'
                    Text="Update"></asp:LinkButton>
        <asp:LinkButton ID="lnkCancel" CommandName="Delete" Text="Cancel" runat="server" OnClientClick="return confirm('Do you want to cancel your reservation ?');"></asp:LinkButton>
        </ItemTemplate>

<ItemStyle Width="10px"></ItemStyle>
        </asp:TemplateField>
        </Columns>
        </asp:GridView>        <br />                       
        <asp:Label ID="messagelbl" runat="server"></asp:Label>
    <br />    
    <asp:Button ID="btnHome" runat="server" CssClass="button" Text="Home" PostBackUrl="~/Home.aspx" /> 
    <br />
        <asp:Label ID="lblSuccessMessage" runat="server"></asp:Label>
        </div>
        </fieldset>
</asp:Content>
