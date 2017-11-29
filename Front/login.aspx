<%@ Page Title="" Language="C#" MasterPageFile="~/Front/front.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="aspSajt.Front.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="frontSadrzaj" runat="server">
    <table class="table" align="center">
        <tr>
            <td colspan="2" style="color: red"><strong>Login</strong></td>
        </tr>
        <tr>
            <td>Username:</td>
            <td><asp:TextBox ID="tbUsername" CssClass="form-control" runat="server" Width="150px" ValidationGroup="log"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbUsername" Display="Dynamic" ErrorMessage="Username je obavezan!" ForeColor="Red" ValidationGroup="log"></asp:RequiredFieldValidator>
            </td>
        </tr>
                <tr>
            <td>Password:</td>
            <td><asp:TextBox ID="tbPassword" CssClass="form-control" runat="server" TextMode="Password" Width="150px" ValidationGroup="log"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbPassword" Display="Dynamic" ErrorMessage="Password je obavezan!" ForeColor="Red" ValidationGroup="log"></asp:RequiredFieldValidator>
                    </td>
        </tr>
        <tr>
            <td colspan="2"><asp:Button ID="btnLogin" CssClass="btn btn-success" runat="server" Text="Enter" OnClick="btnLogin_Click" ValidationGroup="log"/>
                <br />
                <asp:Label ID="feedLabel" runat="server"></asp:Label></td>
        </tr>
    </table>
</asp:Content>
