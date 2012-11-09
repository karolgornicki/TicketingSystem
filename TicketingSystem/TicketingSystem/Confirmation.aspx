<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="TicketingSystem.Confirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            text-align: right;
            width: 385px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1>Checkout</h1>

    <br />
    <table class="style1">
        <tr>
            <td class="style2">
                Cart type</td>
            <td style="text-align: left">
                <asp:RadioButtonList id="RbCardList" runat="server">
                    <asp:ListItem Value="Master Card"> </asp:ListItem>
                    <asp:ListItem Value="Visa"></asp:ListItem>
                    <asp:ListItem Value="Visa Debit"></asp:ListItem>
                    <asp:ListItem Value="Visa Electron"></asp:ListItem>
                    <asp:ListItem Value="Maestro"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Card holder</td>
            <td>
                <asp:TextBox ID="TxCardHolder" runat="server" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ValidatorCardHolder" runat="server" 
                    ControlToValidate="TxCardHolder" 
                    ErrorMessage="Card holder is a required field." ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Card number</td>
            <td>
                <asp:TextBox ID="TxCardNumber" runat="server" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ValidatorCardNumber" runat="server" 
                    ControlToValidate="TxCardNumber" 
                    ErrorMessage="Card number is a required field." ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Card security code</td>
            <td>
                <asp:TextBox ID="TxCardSecurityCode" runat="server" Width="60px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ValidatorCardSecurityCode" runat="server" 
                    ControlToValidate="TxCardSecurityCode" 
                    ErrorMessage="Card security code is a required field." ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Expiry date (MM/ YYYY)</td>
            <td>
                <asp:DropDownList ID="DdlExpiryMonth" runat="server">
                    <asp:ListItem>01</asp:ListItem>
                    <asp:ListItem>02</asp:ListItem>
                    <asp:ListItem>03</asp:ListItem>
                    <asp:ListItem>04</asp:ListItem>
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>06</asp:ListItem>
                    <asp:ListItem>07</asp:ListItem>
                    <asp:ListItem>08</asp:ListItem>
                    <asp:ListItem>09</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                </asp:DropDownList>
                &nbsp;<asp:DropDownList ID="DDlExpiryYear" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Start date (MM/ YYYY)</td>
            <td>
                <asp:DropDownList ID="DDlStartMonth" runat="server">
                    <asp:ListItem>01</asp:ListItem>
                    <asp:ListItem>02</asp:ListItem>
                    <asp:ListItem>03</asp:ListItem>
                    <asp:ListItem>04</asp:ListItem>
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>06</asp:ListItem>
                    <asp:ListItem>07</asp:ListItem>
                    <asp:ListItem>08</asp:ListItem>
                    <asp:ListItem>09</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                </asp:DropDownList>
                &nbsp;<asp:DropDownList ID="DDlStartYear" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Button ID="BtCheckout" runat="server" Text="Proceed to Checkout" 
                    onclick="BtCheckout_Click" />
            </td>
        </tr>
    </table>
    <asp:Label ID="LbError" runat="server" Text=""></asp:Label>
    <br />
    <asp:Label ID="LbMessage" runat="server" Text=""></asp:Label>
</asp:Content>
