<%@ Page Title="" Language="C#" MasterPageFile="/SiteHome.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="MyMotel.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"> 
 <style type="text/css">                       
            #div1{
    background-image:url('https://storageaccounts3.blob.core.windows.net/container2/images/MyMotel.jpg');
    background-repeat:no-repeat;
    height:440px;
    width:100%;
    background-size:cover;
 text-align:center;
 padding-top:100px;   
}

.main
{
    padding:0px;
    margin:0px;
    min-height: 420px;
    }
label 
{
color:white; 
font-weight:bold; 
font-size:30px; 
text-align:center;
vertical-align:middle;
     }
     
     .welcomeMessage
     {
color:white; 
font-weight:bold; 
font-size:20px; 
vertical-align:top;
     }
            
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server" style="margin:0;">                                 
                <div id="div1"><asp:Label ID="lblWelcome" CssClass="welcomeMessage" runat="server"></asp:Label><br /> <label>Welcome To Motel Management System</label>   </div>   
</asp:Content>
