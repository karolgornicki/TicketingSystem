<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Home.aspx.cs" Inherits="TicketingSystem._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1>Home</h1>
    <h2>Coming up</h2>
    <asp:GridView ID="GvCommingSoon" runat="server" AutoGenerateColumns="False" 
        EmptyDataText="No entartainments fhas been scheduled." Width="100%"
        OnRowCommand="GvCommingSoon_RowCommand" CellPadding="5" 
        GridLines="None">
        <AlternatingRowStyle BackColor="Silver" />
        <Columns>
            <asp:BoundField DataField="Org" HeaderText="Organizer" />
            <asp:BoundField DataField="Date" HeaderText="Date" />
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="Runtime" HeaderText="Runtime" />
            <asp:BoundField DataField="OpenSeats" HeaderText="Open Seats" />
            <asp:ButtonField CommandName= "Select" Text="Select" />
        </Columns>
        <RowStyle HorizontalAlign="Center" />
    </asp:GridView>
</asp:Content>
