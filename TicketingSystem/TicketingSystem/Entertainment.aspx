<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Entertainment.aspx.cs" Inherits="TicketingSystem.Entertainment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        <asp:Label ID="LbHeader" runat="server" Text=""></asp:Label>
    </h1>
    <p align="center">
        <asp:Image ID="ImStage" runat="server" ImageAlign="Baseline" 
            ImageUrl="~/Images/stage.png" style="text-align: center" />
    </p>
    <asp:Table ID="TbStage" runat="server" Width="100%">
    </asp:Table>
    <asp:Button ID="BtUpdateCart" runat="server" Text="Update shopping cart" 
        onclick="BtUpdateCart_Click" />
</asp:Content>
