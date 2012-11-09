<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CancelOrder.aspx.cs" Inherits="TicketingSystem.CancelOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        <asp:Label ID="LbHeader" runat="server" Text=""></asp:Label>
    </h1>
    <asp:GridView ID="GvOrders" runat="server" AutoGenerateColumns="False" 
        EmptyDataText="Your shopping cart is empty." Width="100%"
        OnRowCommand="GvOrders_RowCommand" CellPadding="5" 
        GridLines="None">
        <AlternatingRowStyle BackColor="Silver" />
        <Columns>
            <asp:BoundField DataField="date" HeaderText="Date" />
            <asp:BoundField DataField="title" HeaderText="Title" />
            <asp:BoundField DataField="row" HeaderText="Row" />
            <asp:BoundField DataField="number" HeaderText="Number" />
            <asp:ButtonField CommandName= "Delete" Text="Delete" />
        </Columns>
        <RowStyle HorizontalAlign="Center" />
    </asp:GridView>
    <asp:Label ID="LbInfo" runat="server" Visible="False"></asp:Label>
</asp:Content>
