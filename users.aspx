<%@ Page Title="" Language="C#" MasterPageFile="~/bookStore.Master" enableEventValidation="false" AutoEventWireup="true" CodeBehind="users.aspx.cs" Inherits="aspSajt.users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menus" runat="server">
      <table style="width:100%;" class="table">
        <tr>
            <td align="center"><p align="center">Users Management</p>&nbsp;<br /><asp:button class="btn btn-info" text="Dodaj korisnika" runat="server" OnClick="prikaziUsersPanel" /></td>
        </tr>
        <tr>
            <td align="center">
                  <asp:panel runat="server" ID="insertPanel">
                    <table style="width:100%;">
                        <tr>
                            <td>Username:</td>
                            <td>
                                <asp:TextBox ID="tbUsername" runat="server" CssClass="form-control" ValidationGroup="add"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbUsername" Display="Dynamic" ErrorMessage="Username je obavezan!" ForeColor="Red" ValidationGroup="add"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Password:</td>
                            <td>
                                <asp:TextBox ID="tbPassword" runat="server" TextMode="Password" CssClass="form-control" ValidationGroup="add"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbPassword" Display="Dynamic" ErrorMessage="Password je obavezan!" ForeColor="Red" ValidationGroup="add"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                                                <tr>
                            <td class="auto-style1">Email:</td>
                            <td class="auto-style1">
                                <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control" ValidationGroup="add"></asp:TextBox>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbEmail" Display="Dynamic" ErrorMessage="Email nije u dobrom formatu!" ForeColor="Red" ValidationExpression="(?:[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+)*|&quot;(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*&quot;)@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])" ValidationGroup="add"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbEmail" Display="Dynamic" ErrorMessage="Email je obavezan!" ForeColor="Red" ValidationGroup="add"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                                              
                                              
                                  
                                                                        <tr>
                            <td>Level:</td>
                            <td>
                                <asp:DropDownList ID="odabirUloge" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </td>
                        </tr>
                                                      
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="dodajUser" runat="server" Text="Dodaj" OnClick="dodajUser_Click" CssClass="btn btn-success" ValidationGroup="add" />
                                <asp:Button ID="zatvoriPanel" onclick="zatvoriPanel_Click" runat="server" Text="Zatvori"  CssClass="btn btn-danger" />
                            </td>
                        </tr>
                    </table>
                    
                </asp:panel>
                <asp:GridView ID="userGrid" runat="server" class="table table-bordered table-stripped table-condensed table-hover"  AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="id_korisnik" HeaderText="Redni broj" SortExpression="id_korisnik" />
                        <asp:BoundField DataField="naziv" HeaderText="Uloga" SortExpression="naziv" />
                        <asp:BoundField DataField="username" HeaderText="Username" SortExpression="username" />
                      <%--  <asp:BoundField DataField="password" HeaderText="Password" SortExpression="password" />--%>
                        <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />

                        <asp:TemplateField HeaderText="Izbrisi">
                            <ItemTemplate>
                                <asp:Button ID="userDelete" runat="server" OnClick="userDeleteBtn" CssClass="btn btn-danger" Text="Izbrisi" CommandArgument='<%# Eval("id_korisnik") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="ifEmpty" runat="server" ForeColor="Red" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
              
                
            </td>
        </tr>
        </table>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="skripte">
    <style type="text/css">
        .auto-style1 {
            height: 78px;
        }
    </style>
</asp:Content>

