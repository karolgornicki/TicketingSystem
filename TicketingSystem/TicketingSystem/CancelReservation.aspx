<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CancelReservation.aspx.cs" Inherits="TicketingSystem.CancelReservation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            text-align: right;
            width: 375px;
        }
        .style3
        {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1>Cancellation</h1>
    <table class="style1">
        <tr>
            <td class="style2">
                Enter order code:</td>
            <td class="style3">
                <asp:TextBox ID="TxCode" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:Button ID="BtAuthorize" runat="server" onclick="BtAuthorize_Click" 
                    Text="Authorize" />
&nbsp;<asp:Label ID="LbError" runat="server" ForeColor="Red" Text="Entered code is not valid." 
                    Visible="False"></asp:Label>
            </td>
        </tr>
    </table>

</asp:Content>
