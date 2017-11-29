<%@ Page Title="" Language="C#" MasterPageFile="~/Front/front.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="aspSajt.Front.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="skripte" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="frontSadrzaj" runat="server">
    <table class="table" align="center">
        <tr>
            <td colspan="2"><strong style="color: red">Register</strong></td>
        </tr>
        <tr>
            <td>Username:</td>
            <td><asp:TextBox ID="tbUsername" CssClass="form-control" runat="server" Width="150px" ValidationGroup="reg"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbUsername" Display="Dynamic" ErrorMessage="Username je obavezan!" ForeColor="Red" ValidationGroup="reg"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="tbUsername" runat="server" Display="Dynamic" ErrorMessage="Mora imati bar 3 karaktera!" ForeColor="Red" ValidationExpression="^[A-z0-9]{3,15}$" ValidationGroup="reg"></asp:RegularExpressionValidator>
            </td>
        </tr>
                <tr>
            <td>Password:</td>
            <td><asp:TextBox ID="tbPassword" CssClass="form-control" runat="server" TextMode="Password" Width="150px" ValidationGroup="reg"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbPassword" Display="Dynamic" ErrorMessage="Password je obavezan!" ForeColor="Red" ValidationGroup="reg"></asp:RequiredFieldValidator>
                    </td>
        </tr>
                      <tr>
            <td>Repeat password:</td>
            <td><asp:TextBox ID="tbPassword2" CssClass="form-control" runat="server" TextMode="Password" Width="150px" ValidationGroup="reg"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="tbPassword" ControlToValidate="tbPassword2" ErrorMessage="Password se ne poklapa!" ForeColor="Red" ValidationGroup="reg"></asp:CompareValidator>
                          </td>
        </tr>
                      <tr>
            <td>Email:</td>
            <td><asp:TextBox ID="tbEmail" CssClass="form-control" runat="server" TextMode="Email" Width="150px" ValidationGroup="reg"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbEmail" Display="Dynamic" ErrorMessage="Email je obavezan!" ForeColor="Red" ValidationGroup="reg"></asp:RequiredFieldValidator>
                          </td>
        </tr>
        <tr>
            <td colspan="2"><asp:Button ID="btnRegister" CssClass="btn btn-success" runat="server" Text="Register" OnClick="btnRegister_Click" ValidationGroup="reg"/>
                <br />
                <asp:Label ID="feedLabel" runat="server"></asp:Label></td>
        </tr>
    </table>
</asp:Content>
