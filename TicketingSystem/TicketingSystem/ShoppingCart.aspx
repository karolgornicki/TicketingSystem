<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="TicketingSystem.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        <asp:Label ID="LbHeader" runat="server" Text="Label"></asp:Label>
    </h1>
    <asp:GridView ID="GvShoppingCart" runat="server" AutoGenerateColumns="False" 
        EmptyDataText="Your shopping cart is empty." Width="100%"
        OnRowCommand="GvShoppingCart_RowCommand" CellPadding="5" 
        GridLines="None">
        <AlternatingRowStyle BackColor="Silver" />
        <Columns>
            <asp:BoundField DataField="stage" HeaderText="Organizer" />
            <asp:BoundField DataField="date" HeaderText="Date" />
            <asp:BoundField DataField="title" HeaderText="Title" />
            <asp:BoundField DataField="row" HeaderText="Row" />
            <asp:BoundField DataField="number" HeaderText="Number" />
            <asp:BoundField DataField="price" HeaderText="Price" />
            <asp:ButtonField CommandName= "Delete" Text="Delete" />
        </Columns>
        <RowStyle HorizontalAlign="Center" />
    </asp:GridView>
    <h2>
        <asp:Label ID="LbTotal" runat="server" Text=""></asp:Label>
        <asp:DropDownList ID="DdlCurrency" runat="server">
        <asp:ListItem>GBP</asp:ListItem>
        <asp:ListItem>CHF</asp:ListItem>
        <asp:ListItem>EUR</asp:ListItem>
        <asp:ListItem>JPY</asp:ListItem>
        <asp:ListItem>USD</asp:ListItem>
    </asp:DropDownList>
        <asp:Button ID="BtRecalculate" runat="server" onclick="BtRecalculate_Click" 
            Text="Recalculate" />
    </h2>
    <asp:Button ID="BtCheckout" runat="server" Text="Checkout" 
        onclick="BtCheckout_Click" />
</asp:Content>
