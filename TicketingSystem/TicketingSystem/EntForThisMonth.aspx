<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EntForThisMonth.aspx.cs" Inherits="TicketingSystem.EntForThisMonth" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        <asp:Label ID="LbHeader" runat="server" Text=""></asp:Label>
    </h1>
    <p>
        <asp:Button ID="BtPreviousMonth" runat="server" Text=" << Previous month" 
            onclick="BtPreviousMonth_Click" Width="150px" />
        <asp:Button ID="BtNextMonth" runat="server" Text="Next month >>" 
            onclick="BtNextMonth_Click" Width="150px" />
    </p>
    <asp:GridView ID="GvEntertainments" runat="server" AutoGenerateColumns="False" 
        EmptyDataText="No entartainments for this month has been scheduled." Width="100%"
        OnRowCommand="GvEntertainments_RowCommand">
        <Columns>
            <asp:BoundField DataField="Org" HeaderText="Organizer" />
            <asp:BoundField DataField="Date" HeaderText="Date" />
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="Runtime" HeaderText="Runtime" />
            <asp:BoundField DataField="OpenSeats" HeaderText="Open Seats" />
            <asp:ButtonField CommandName= "Select" Text="Select" />
        </Columns>
    </asp:GridView>
</asp:Content>
