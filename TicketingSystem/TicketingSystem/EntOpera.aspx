<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EntOpera.aspx.cs" Inherits="TicketingSystem.EntOpera" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        <asp:Label ID="LbHeader" runat="server" Text=""></asp:Label>
    </h1>
    <p>
        <asp:Button ID="BtPreviousMonth" runat="server" Text=" << Previous month" 
            Width="150px" onclick="BtPreviousMonth_Click" />
        <asp:Button ID="BtNextMonth" runat="server" Text="Next month >>" 
            Width="150px" onclick="BtNextMonth_Click" />
    </p>
    <asp:GridView ID="GvEntOpera" runat="server" AutoGenerateColumns="False" 
        EmptyDataText="No entartainments for this month has been scheduled." Width="100%"
        OnRowCommand="GvEntOpera_RowCommand" CellPadding="5" 
        GridLines="None">
        <AlternatingRowStyle BackColor="Silver" />
        <Columns>
            <asp:BoundField DataField="Date" HeaderText="Date" />
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="Runtime" HeaderText="Runtime" />
            <asp:BoundField DataField="OpenSeats" HeaderText="Open Seats" />
            <asp:ButtonField CommandName= "Select" Text="Select" />
        </Columns>
        <RowStyle HorizontalAlign="Center" />
    </asp:GridView>
</asp:Content>
