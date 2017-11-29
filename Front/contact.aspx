<%@ Page Title="" Language="C#" MasterPageFile="~/Front/front.Master" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="aspSajt.Front.contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="skripte" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="frontSadrzaj" runat="server">
     <table class="table" align="center">
        <tr>
            <td colspan="2"><strong style="color: red">Contact</strong></td>
        </tr>
        <tr>
            <td>Ime:</td>
            <td><asp:TextBox ID="tbIme" CssClass="form-control" runat="server" Width="150px" ValidationGroup="kon"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbIme" Display="Dynamic" ErrorMessage="Ime je obavezno!" ForeColor="Red" ValidationGroup="kon"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="tbIme" runat="server" Display="Dynamic" ErrorMessage="Mora imati bar 3 karaktera!" ForeColor="Red" ValidationExpression="^[A-z0-9]{3,15}$" ValidationGroup="kon"></asp:RegularExpressionValidator>
            </td>
        </tr>
                <tr>
            <td>Email:</td>
            <td><asp:TextBox ID="tbMail" CssClass="form-control" runat="server" TextMode="Email" Width="150px" ValidationGroup="kon"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbMail" Display="Dynamic" ErrorMessage="Mail je obavezan!" ForeColor="Red" ValidationGroup="kon"></asp:RequiredFieldValidator>
                    </td>
        </tr>
                      <tr>
            <td>Naslov:</td>
            <td><asp:TextBox ID="tbNaslov" CssClass="form-control" runat="server" Width="150px" ValidationGroup="kon"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbNaslov" Display="Dynamic" ErrorMessage="Naslov je obavezan!" ForeColor="Red" ValidationGroup="kon"></asp:RequiredFieldValidator>
                          </td>
        </tr>
                      <tr>
            <td>Poruka:</td>
            <td><asp:TextBox ID="tbPoruka" CssClass="form-control" runat="server" TextMode="MultiLine" Width="150px" ValidationGroup="kon"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbPoruka" Display="Dynamic" ErrorMessage="Poruka je obavezna!" ForeColor="Red" ValidationGroup="kon"></asp:RequiredFieldValidator>
                          </td>
        </tr>
        <tr>
            <td colspan="2"><asp:Button ID="btnKontakt" CssClass="btn btn-success" runat="server" Text="Send" OnClick="btnKontakt_Click" ValidationGroup="kon"/>
                <br />
                <asp:Label ID="feedLabel" runat="server"></asp:Label></td>
        </tr>
    </table>
</asp:Content>
