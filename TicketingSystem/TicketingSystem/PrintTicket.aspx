<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PrintTicket.aspx.cs" Inherits="TicketingSystem.PrintTicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<p>
    <asp:Label ID="LbInfo" runat="server" Text="Please enter valid ticket code" 
        style="text-align: center"></asp:Label>
</p>
<p class="style1">
    <asp:TextBox ID="TxCode" runat="server"></asp:TextBox>
</p>
    <p class="style1">
    <asp:Button ID="BbRun" runat="server" Text="Authoirise" onclick="BbRun_Click" />
        <asp:Label ID="LbError" runat="server" Text="Entered code is not valid" 
            ForeColor="Red" Visible="False"></asp:Label>
</p>
</asp:Content>
