<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="MyMotel.ContactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 21px;
        }
        .auto-style2 {
            height: 21px;
            width: 210px;
        }
        .auto-style3 {
            width: 210px;
        }
        .auto-style4 {
            height: 21px;
            width: 115px;
        }
        .auto-style5 {
            width: 115px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend>Contact Us</legend>
        <table border="1" width="570" style="border-collapse: collapse;">
            <tr>
                <th class="auto-style2" style="text-align:center">Name</th>
                <th class="auto-style4" style="text-align:center">Phone Number</th>
                <th class="auto-style1" style="text-align:center">Email</th>
            </tr>
            <tr>
                <td class="auto-style3">Vinay Kumar Jakkula</td>
                <td class="auto-style5">203-434-8285</td>
                <td><a href="mailto:j4vinay@gmail.com">j4vinay@gmail.com</a></td>
            </tr>
            <tr>
                <td class="auto-style3">Kranti Kumar Reddy Kommidy</td>
                <td class="auto-style5">860-841-8644</td>
                <td><a href="mailto:Reddy.Kranthi25@gmail.com">reddy.Kranthi25@gmail.com</a></td>
            </tr>
            <tr>
                <td class="auto-style3">Shekar Reddy Kuntiyellannagari</td>
                <td class="auto-style5">203-551-0926</td>
                <td><a href="mailto:Shekareddy1992@gmail.com">shekareddy1992@gmail.com</a></td>
            </tr>
            <tr>
                <td class="auto-style3">Rajavardhan Reddy Mandala</td>
                <td class="auto-style5">475-243-9406</td>
                <td><a href="mailto:rajavardhanmandala@gmail.com">rajavardhanmandala@gmail.com</a></td>
            </tr>
            </table>
    </fieldset>
               
</asp:Content>
