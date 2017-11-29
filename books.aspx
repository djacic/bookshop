<%@ Page Title="" Language="C#" MasterPageFile="~/bookStore.Master" enableEventValidation="false" AutoEventWireup="true" EnableViewState="true" CodeBehind="books.aspx.cs" Inherits="aspSajt.books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 92px;
        }
    </style>
   
      
</asp:Content>
<asp:Content ContentPlaceHolderID="skripte" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
           
               
            
        });
        
 
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menus" runat="server">

     <table style="width:100%;" class="table">
        <tr>
            <td align="center" class="auto-style1"><p align="center">Books Management</p>&nbsp;<br /><asp:button text="Dodaj knjigu" runat="server" OnClick="prikaziBooksPanel" CssClass="btn btn-info" /></td>
        </tr>
        <tr>
            <td align="center">
                <asp:panel runat="server" ID="insertPanel">
                    <table style="width:100%;">
                        <tr>
                            <td>Naziv:</td>
                            <td>
                                <asp:TextBox ID="nazivBtn" runat="server" CssClass="form-control" ValidationGroup="add"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ControlToValidate="nazivBtn" ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ErrorMessage="Naziv je obavezan!" ForeColor="Red" ValidationGroup="add"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Opis:</td>
                            <td>
                                <asp:TextBox ID="opisBtn" runat="server" TextMode="MultiLine" CssClass="form-control" ValidationGroup="add"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="opisBtn" Display="Dynamic" ErrorMessage="Opis je obavezan!" ForeColor="Red" ValidationGroup="add"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                                                <tr>
                            <td>Cena:</td>
                            <td>
                                <asp:TextBox ID="cenaBtn" runat="server" TextMode="Number" step="100" CssClass="form-control" ValidationGroup="add"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cenaBtn" Display="Dynamic" ErrorMessage="Cena je obavezna!" ForeColor="Red" ValidationGroup="add"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="cenaBtn" Display="Dynamic" ErrorMessage="Cena mora biti pozitivna!" ForeColor="Red" ValidationExpression="^[1-9][0-9]*$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                                              
                                                <tr>
                            <td>Godina izdavanja:</td>
                            <td>
                                <asp:TextBox ID="godinaBtn" runat="server" CssClass="form-control" ValidationGroup="add"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="godinaBtn" Display="Dynamic" ErrorMessage="Godina izdavanja je obavezna!" ForeColor="Red" ValidationGroup="add"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                                                <tr>
                            <td>Slika:</td>
                            <td>
                                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                            </td>
                        </tr>
                                                                        <tr>
                            <td>Žanr:</td>
                            <td>
                                <asp:DropDownList ID="odabirZanra" AppendDataBoundItems="true" runat="server" CssClass="form-control" ValidationGroup="add">
                                    <asp:ListItem Selected="True" Value="0">Izaberi</asp:ListItem>
                                </asp:DropDownList>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="odabirZanra" Display="Dynamic" ErrorMessage="Izaberite zanr!" ForeColor="Red" InitialValue="0" ValidationGroup="add"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                                                                        <tr>
                            <td>Autor:</td>
                            <td>
                                <asp:DropDownList ID="odabirAutora" AppendDataBoundItems="true" runat="server" CssClass="form-control" ValidationGroup="add">
                                    <asp:ListItem Selected="True" Value="0">Izaberi</asp:ListItem>
                                </asp:DropDownList>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="odabirAutora" Display="Dynamic" ErrorMessage="Izaberite autora!" ForeColor="Red" InitialValue="0" ValidationGroup="add"></asp:RequiredFieldValidator>
                                                                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="dodajKnjigu" runat="server" Text="Dodaj" OnClick="dodajKnjigu_Click" CssClass="btn btn-success" ValidationGroup="add" />
                                 <asp:Button ID="zatvoriInsertPanel" OnClick="zatvoriInsertPanel_Click" runat="server" Text="Zatvori"  CssClass="btn btn-danger" />
                            </td>

                        </tr>
                    </table>
                    
                </asp:panel>

                <!-- IZMENA -->

                 <asp:panel runat="server" ID="Panel2">
                    <table style="width:100%;">
                        <tr>
                            <td>Naziv:</td>
                            <td>
                                <asp:TextBox ID="updNaziv" runat="server" CssClass="form-control" ValidationGroup="upd"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="updNaziv" Display="Dynamic" ErrorMessage="Naziv je obavezan!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Opis:</td>
                            <td>
                                <asp:TextBox ID="updOpis" runat="server" TextMode="MultiLine" CssClass="form-control" Height="26px" ValidationGroup="upd"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="updOpis" Display="Dynamic" ErrorMessage="Opis je obavezan!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                                                <tr>
                            <td>Cena:</td>
                            <td>
                                <asp:TextBox ID="updCena" runat="server" TextMode="Number" step="100" CssClass="form-control" ValidationGroup="upd"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="updCena" Display="Dynamic" ErrorMessage="Cena je obavezna!" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="updCena" Display="Dynamic" ErrorMessage="Cena mora biti pozitivna!" ForeColor="Red" ValidationExpression="^[1-9][0-9]*$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                                              
                                                <tr>
                            <td>Godina izdavanja:</td>
                            <td>
                                <asp:TextBox ID="updGodina" runat="server" CssClass="form-control" ValidationGroup="upd"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="updGodina" Display="Dynamic" ErrorMessage="Godina izdavanja je obavezna!" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                                                <tr>
                            <td>Upload nove slike:</td>
                            <td>
                                <asp:FileUpload ID="FileUpload2" runat="server" CssClass="form-control" />
                            </td>
                        </tr>
                                                                        <tr>
                            <td>Žanr:</td>
                            <td>
                                <asp:DropDownList  ID="updZanr" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <br />
                            </td>
                        </tr>
                                                                        <tr>
                            <td>Autor:</td>
                            <td>
                                <asp:DropDownList  ID="updAutor" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <br />
                                                                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="updKnjigu" runat="server" Text="Izmeni" OnClick="updKnjigu_Click" CssClass="btn btn-warning" />
                                 <asp:Button ID="zatvoriUpdatePanel" OnClick="zatvoriUpdatePanel_Click" runat="server" Text="Zatvori"  CssClass="btn btn-danger" />
                                <asp:Label ID="hiddenUpdate" runat="server"></asp:Label>
                            </td>                
                        </tr>
                    </table>
                    
                </asp:panel>
                <asp:GridView ID="bookGrid" runat="server" class="table table-bordered table-stripped table-condensed table-hover"  AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="id_knjiga" HeaderText="Redni broj" SortExpression="id_knjiga" />
                        <asp:BoundField DataField="naziv" HeaderText="Naziv" SortExpression="naslov" />
                        <asp:BoundField DataField="ime" HeaderText="Ime pisca" SortExpression="url" />
                        <asp:BoundField DataField="cena" HeaderText="Cena" SortExpression="prikazan" />
                        <asp:BoundField DataField="zanr" HeaderText="Zanr" SortExpression="zanr" />
                        <asp:ImageField DataImageUrlField="slikaMala" HeaderText="Slika" >

                        </asp:ImageField>
                        <asp:TemplateField HeaderText="Izbrisi">
                            <ItemTemplate>
                                <asp:Button ID="bookDelete" runat="server" OnClick="bookDeleteBtn" Text="Izbrisi" CommandArgument='<%# Eval("id_knjiga") %>' CssClass="btn btn-danger" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Izmeni">
                            <ItemTemplate>
                                <asp:Button ID="btnIzmeni" runat="server" OnClick="btnIzmeni_Click" Text="Izmeni" CommandArgument='<%# Eval("id_knjiga") %>' CssClass="btn btn-warning" />
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
