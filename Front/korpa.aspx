<%@ Page Title="" Language="C#" enableEventValidation="false" MasterPageFile="~/Front/front.Master" AutoEventWireup="true" CodeBehind="korpa.aspx.cs" Inherits="aspSajt.Front.korpa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="skripte" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="frontSadrzaj" runat="server">
      <table class="table" align="center">
        <tr>
            <td colspan="2"><strong>Vaša korpa: <asp:Label ID="jePrazna" ForeColor="red" Text="" runat="server"></asp:Label></strong></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView CssClass="table table-bordered table-stripped table-condensed table-hover" ID="korpaGrid" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="naziv" HeaderText="Naziv" SortExpression="naziv" />
                        <asp:BoundField DataField="cena" HeaderText="Cena" SortExpression="cena" />
                        <asp:TemplateField HeaderText="Ukloni">
                            <ItemTemplate>
                                <asp:Button ID="ukloniIzKorpe" runat="server" Text="Ukloni" CssClass="btn btn-danger" align="center"  OnClick="ukloniIzKorpe_Click" CommandArgument='<%# Eval("id_knjiga") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                 <table>
                    <tr>
                        <td colspan="2">Ukupna cena: <asp:Label ID="ukupnaCena" Text="" ForeColor="blue" runat="server"></asp:Label></td>
                        
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="naruci" runat="server" Text="Naruci" CssClass="btn btn-success" />
                        </td>
                    </tr>
              
                </table>
            </td>
        </tr>
    </table>    
</asp:Content>
