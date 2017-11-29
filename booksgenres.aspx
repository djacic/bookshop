<%@ Page Title="" Language="C#" MasterPageFile="~/bookStore.Master" enableEventValidation="false" AutoEventWireup="true" CodeBehind="booksgenres.aspx.cs" Inherits="aspSajt.booksgenres" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menus" runat="server">
    <table style="width:100%;" class="table">
        <tr>
            <td align="center"><p>List of Genres</p>&nbsp;<asp:GridView ID="zanrGrid" runat="server" AutoGenerateColumns="False" class="table table-bordered table-stripped table-condensed table-hover">
                <Columns>
                    <asp:BoundField DataField="naziv" HeaderText="Zanr" SortExpression="naziv" />
                    <asp:TemplateField HeaderText="Obrisi">
                        <ItemTemplate>
                            <asp:Button class="btn btn-danger" ID="zanrObrisiBtn" runat="server" Text="Obrisi" OnClick="zanrObrisiBtn_Click" CommandArgument='<%# Eval("id_zanr")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                </asp:GridView>
                <table class="table" style="padding:0px">
                    <tr>
                        <td colspan="2"><asp:Label ID="infoLabel" runat="server" ForeColor="#FF3300"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Dodaj zanr: <asp:TextBox ID="tbDodajZanr" ValidationGroup="addzanr" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbDodajZanr" Display="Dynamic" ErrorMessage="Zanr je obavezan!" ForeColor="Red" ValidationGroup="addzanr"></asp:RequiredFieldValidator>
                            <br />
                        </td>
                        
                    </tr>
                                        <tr>
                        <td colspan="2">  <asp:Button class="btn btn-success" ID="btnDodajZanr" runat="server" Text="Dodaj" OnClick="btnDodajZanr_Click" ValidationGroup="addzanr" /></td>
                    </tr>
                </table>
                
                
              
            </td>
        </tr>
        <tr>
                        <td align="center"><p>List of Autors</p>&nbsp;<asp:GridView ID="autorGrid" runat="server" AutoGenerateColumns="False" class="table table-bordered table-stripped table-condensed table-hover">
                <Columns>
                    <asp:BoundField DataField="ime" HeaderText="Ime" SortExpression="ime" />
                    <asp:BoundField DataField="prezime" HeaderText="Prezime" SortExpression="prezime" />
                    <asp:TemplateField HeaderText="Obrisi">
                        <ItemTemplate>
                            <asp:Button class="btn btn-danger" ID="autorObrisiBtn" runat="server" Text="Obrisi" OnClick="autorObrisiBtn_Click" CommandArgument='<%# Eval("id_autor") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                </asp:GridView>
                
                            <br />
                            <table class="table">
                                <tr>
                                    <td colspan="2"><asp:Label ID="infoLabel2" runat="server" ForeColor="#FF3300"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Ime:</td>
                                    <td><asp:TextBox ID="tbDodajIme" class="form-control" runat="server" ValidationGroup="addautor"></asp:TextBox>
                                        <br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbDodajIme" Display="Dynamic" ErrorMessage="Ime je obavezno!" ForeColor="Red" ValidationGroup="addautor"></asp:RequiredFieldValidator>
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td>Prezime:</td>
                                    <td><asp:TextBox ID="tbDodajPrezime" runat="server" CssClass="form-control" ValidationGroup="addautor"></asp:TextBox>
                                        <br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbDodajPrezime" Display="Dynamic" ErrorMessage="Prezime je obavezno!" ForeColor="Red" ValidationGroup="addautor"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                   <td>Biografija</td>
                                    <td><asp:TextBox ID="tbDodajBiografiju" runat="server" Height="132px" TextMode="MultiLine" Width="488px" CssClass="auto-style1" ValidationGroup="addautor"></asp:TextBox>
                                        <br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbDodajBiografiju" Display="Dynamic" ErrorMessage="Biografija je obavezna!" ForeColor="Red" ValidationGroup="addautor"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2"><asp:Button ID="btnDodajAutora" runat="server" Text="Dodaj" OnClick="btnDodajAutora_Click" CssClass="btn btn-success" ValidationGroup="addautor" /></td>
                                </tr>

                            </table>

                         

                
            </td>
        </tr>
        
    </table>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="skripte">
    <style type="text/css">
        .auto-style1 {
            display: block;
            font-size: 14px;
            line-height: 1.42857143;
            color: #555;
            border-radius: 0px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
            box-shadow: none;
            -webkit-transition: border-color ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            outline-width: medium;
            outline-style: none;
            outline-color: invert;
            font-family: Muli-Regular;
            border: 1px solid #ccc;
            padding: 6px 12px;
            background-color: #fff;
            background-image: none;
        }
    </style>
</asp:Content>

