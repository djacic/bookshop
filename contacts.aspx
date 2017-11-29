<%@ Page Title="" Language="C#" MasterPageFile="~/bookStore.Master" AutoEventWireup="true" enableEventValidation="false" CodeBehind="contacts.aspx.cs" Inherits="aspSajt.contacts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="skripte" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="menus" runat="server">
    <table style="width:100%;" class="table">
        <tr>
            <td align="center">
                <asp:GridView ID="contactsGrid" runat="server" class="table table-bordered table-stripped table-condensed table-hover"  AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="id_kontakt" HeaderText="Redni broj" SortExpression="id_kontakt" />
                        <asp:BoundField DataField="ime" HeaderText="Ime" SortExpression="ime" />
                        <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                        <asp:BoundField DataField="naslov" HeaderText="Naslov" SortExpression="naslov" />
                        <asp:BoundField DataField="poruka" HeaderText="Poruka" SortExpression="poruka" />
                       
                        <asp:TemplateField HeaderText="Izbrisi">
                            <ItemTemplate>
                                <asp:Button ID="contactsDelete" runat="server" OnClick="contactsDeleteBtn" Text="Izbrisi" CssClass="btn btn-danger" CommandArgument='<%# Eval("id_kontakt") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Respond">
                            <ItemTemplate>
                                <asp:Button ID="contactsRespond" runat="server" OnClick="contactsRespondBtn" Text="Respond" CssClass="btn btn-info" CommandArgument='<%# Eval("id_kontakt") %>' />
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
                <asp:panel runat="server" ID="respondPanel">
                    <table style="width:100%;">
                        <tr>
                            <td>Poruka:</td>
                            <td>
                                <asp:TextBox class="form-control" ID="tbPoruka" runat="server" ValidationGroup="add" TextMode="MultiLine" Height="229px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="tbPoruka" ForeColor="Red" Display="Dynamic"  runat="server" ErrorMessage="Poruka je obavezna" ValidationGroup="add"></asp:RequiredFieldValidator>
                                <br />
                            </td>
                            <td></td>
                        </tr>
                                                <tr>
                            <td>Kome:</td>
                            <td>
                                <asp:TextBox class="form-control" ID="tbKome" runat="server"></asp:TextBox>
                                
                                <br />
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Label ID="emailPrenos" runat="server" Text=""></asp:Label>
                                <asp:Label ID="imePrenos" runat="server" Text=""></asp:Label>
                                <asp:Button class="btn btn-success" ID="dodajRespond" runat="server" Text="Send" OnClick="dodajRespond_Click" ValidationGroup="add" />
                            </td>
                            <td align="center">&nbsp;</td>
                        </tr>
                    </table>
                    
                </asp:panel>
                <asp:Panel ID="message" Visible="false" CssClass="lead" runat="server">Uspesno odgovoreno!</asp:Panel>
            </td>
        </tr>
        </table>
</asp:Content>
