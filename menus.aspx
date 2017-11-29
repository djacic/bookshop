<%@ Page Title="" Language="C#" MasterPageFile="~/bookStore.Master" enableEventValidation="false" AutoEventWireup="true" CodeBehind="menus.aspx.cs" Inherits="aspSajt.menus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="menus" runat="server">
    

    
    <table style="width:100%;" class="table">
        <tr>
            <td align="center"><p align="center">Menu Management</p>&nbsp;<br /><asp:button text="Dodaj meni" runat="server" OnClick="prikaziInsertPanel" CssClass="btn btn-info" /></td>
        </tr>
        <tr>
            <td align="center">
                 <asp:panel runat="server" ID="insertPanel">
                    <table style="width:100%;">
                        <tr>
                            <td>Naslov:</td>
                            <td>
                                <asp:TextBox class="form-control" ID="naslovBtn" runat="server" ValidationGroup="add"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="naslovBtn" ForeColor="Red" Display="Dynamic"  runat="server" ErrorMessage="Naslov je obavezan" ValidationGroup="add"></asp:RequiredFieldValidator>
                                <br />
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>URL:</td>
                            <td>
                                <asp:TextBox class="form-control" ID="urlBtn" runat="server" ValidationGroup="add"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="urlBtn" ForeColor="Red" Display="Dynamic"  runat="server" ErrorMessage="URL je obavezan" ValidationGroup="add"></asp:RequiredFieldValidator>

                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>Vidljiv:</td>
                            <td>
                                <asp:CheckBoxList ID="chbList" runat="server" >
                                    <asp:ListItem Value="nereg">Neregistrovanim korisnicima</asp:ListItem>
                                    <asp:ListItem Value="reg">Registrovanim korisnicima</asp:ListItem>
                                    <asp:ListItem Value="adm">Administratorima</asp:ListItem>
                                </asp:CheckBoxList>
                              
                                <br />
                                <asp:Label ID="chbVal" runat="server" ForeColor="Red"></asp:Label>
                              
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button class="btn btn-success" ID="dodajMeni" runat="server" Text="Dodaj" OnClick="dodajMeni_Click" ValidationGroup="add" />
                                <asp:Button ID="zatvoriPanel" OnClick="zatvoriPanel_Click" runat="server" Text="Zatvori"  CssClass="btn btn-danger" />
                            </td>
                            <td align="center">&nbsp;</td>
                        </tr>
                    </table>
                    
                </asp:panel>
                <asp:GridView ID="menuGrid" runat="server" class="table table-bordered table-stripped table-condensed table-hover"  AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="id_meni" HeaderText="Redni broj" SortExpression="id_meni" />
                        <asp:BoundField DataField="naslov" HeaderText="Naslov" SortExpression="naslov" />
                        <asp:BoundField DataField="url" HeaderText="URL" SortExpression="url" />
                       
                        <asp:TemplateField HeaderText="Izbrisi">
                            <ItemTemplate>
                                <asp:Button ID="menuDelete" runat="server" OnClick="menuDeleteBtn" Text="Izbrisi" CssClass="btn btn-danger" CommandArgument='<%# Eval("id_meni") %>' />
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
<asp:Content ContentPlaceHolderID="skripte" runat="server">

</asp:Content>

