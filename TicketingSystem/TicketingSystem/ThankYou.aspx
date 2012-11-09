<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ThankYou.aspx.cs" Inherits="TicketingSystem.ThankYou" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1 >&nbsp;</h1>
    <h1 >&nbsp;</h1>
    <h1 >&nbsp;</h1>
    <h1 align="center" class="style1" >Thank you for shopping with us!</h1>
    <h1 align="center" class="style1" >
        <asp:Button ID="BtPrint" runat="server" Text="Print ticket to PDF" 
            onclick="BtPrint_Click" /></h1>
</asp:Content>
