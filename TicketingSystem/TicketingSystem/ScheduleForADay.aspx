<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ScheduleForADay.aspx.cs" Inherits="TicketingSystem.RepertoireForADay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1 id="first">Schedule for a day</h1>
    <h2>Ballet</h2>
    <asp:GridView ID="GvBallet" runat="server" AutoGenerateColumns="False" 
        EmptyDataText="No entartainments for this day has been scheduled." Width="100%"
        OnRowCommand="GvBallet_RowCommand" CellPadding="5" 
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
    <h2>Opera</h2>
    <asp:GridView ID="GvOpera" runat="server" AutoGenerateColumns="False" 
        EmptyDataText="No entartainments for this day has been scheduled." Width="100%"
        OnRowCommand="GvOpera_RowCommand" CellPadding="5" 
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
    <h2>Theatre</h2>
    <asp:GridView ID="GvTheatre" runat="server" AutoGenerateColumns="False" 
        EmptyDataText="No entartainments for this day has been scheduled." Width="100%"
        OnRowCommand="GvTheatre_RowCommand" CellPadding="5" 
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
