<%@ Page Title="" Language="C#" MasterPageFile="~/Front/front.Master" AutoEventWireup="true" CodeBehind="books.aspx.cs" EnableEventValidation="false" Inherits="aspSajt.Front.books" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="skripte" runat="server">
    <script>
        function sakrij(e) {
          
            var a = $('[id*=knjiga' + e + ']');
            a.hide();
            var b = $('[id*=detaljnije' + e + ']');
            b.fadeIn();
            
        }
        function zatvori(e) {

            var a = $('[id*=detaljnije' + e + ']');
            a.hide();
            var b = $('[id*=knjiga' + e + ']');
            b.fadeIn();

        }
        function oceni(e) {
            var a = $('[id*=knjiga' + e + ']');
            a.hide();
            var b = $('[id*=rating' + e + ']');
            b.fadeIn();
            
        }
        function zatvoriOcenu(e) {
            var a = $('[id*=rating' + e + ']');
            a.hide();
            var b = $('[id*=knjiga' + e + ']');
            b.fadeIn();
        }

   
        function oceniKnjigu(e) {
            var izabrano = $("#ddlOcena").find(":selected").text();
            var idKnjige = e;

            $.ajax({
                type: "post",
                url: "books.aspx/ajaxOceni",
                data: "{'ocena':'" + izabrano + "', 'id':'" + idKnjige + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    location.reload();

                },
                error: function (err) {
                    location.reload();
                }
            });
        };
    </script>
    <style>
        .aktivan{
            background-color:red;
            border-radius:2px;
            padding:10px;
            color:white;
        }
      
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="frontSadrzaj" runat="server">
   </div>
   <div class="about">
      <div class="new-product" style="width:100%">
         <div class="mens-toolbar">
            <div class="sort">
               <div class="sort-by">
                      <table >
                          <tr>
                              <td>
                                   <label>Zanr:</label>
                              </td>
                              <td>
     <asp:DropDownList ID="ddlZanr" CssClass="form-control"  runat="server" OnSelectedIndexChanged="ddlZanr_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="True">
                      <asp:ListItem Value="0">Sve</asp:ListItem>
                   </asp:DropDownList>
                              </td>
                          </tr>
                 
             
                 
                    <tr>
                    
                        <td>
                            <asp:Button ID="btnSearch" CssClass="form-control btn btn-success" OnClick="btnSearch_Click" runat="server" Text="Pretrazi"/>
                        </td>
                            <td>
                          <asp:TextBox ID="tbSearch" CssClass="form-control" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
               </div>
            </div>
            <ul class="women_pagenation dc_paginationA dc_paginationA06">
                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="BookList" PageSize="6" >
                             <Fields>
            <asp:NumericPagerField ButtonType="Link"  CurrentPageLabelCssClass="aktivan"  />
          </Fields>
                </asp:DataPager>
             
            </ul>
            <div class="clearfix"></div>
         </div>
         <div id="cbp-vm" class="cbp-vm-switcher cbp-vm-view-grid">
            <div class="pages">   
               <%--        	 <div class="limiter visible-desktop">
                  <label>Show</label>
                     <select>
                               <option value="" selected="selected">
                       9                </option>
                               <option value="">
                       15                </option>
                               <option value="">
                       30                </option>
                     </select> per page        
                  </div>--%>
            </div>
            <div class="clearfix"></div>
            <ul>
                <asp:Panel ID="noBooks" Visible="false" runat="server">
                    <div style="color:red; font-size:30px; margin:0 auto">
                        No movies of type of your query, sir!
                    </div>
                </asp:Panel>
               <asp:ListView OnItemDataBound="BookList_ItemDataBound"  ID="BookList" runat="server" OnPagePropertiesChanged="BookList_PagePropertiesChanged" >
                  <itemTemplate>
                      <li style="display:none" id="<%# string.Concat("rating",Eval("id_knjiga")) %>">
                         
                          <table class="table">
                              <tr>
                                  <td colspan="2">
                                      Ocenite knjigu:
                                  </td>
                              </tr>
                              <tr>
                                  <td colspan="2">
                                      <select id="ddlOcena" class="form-control">
                                           <option value="1">1</option>
                                           <option value="2">2</option>
                                           <option value="3">3</option>
                                           <option value="4">4</option>
                                           <option value="5">5</option>
                                      </select>
                                  </td>
                              </tr>
                              <tr>
                                  <td>
                                     
                                      <asp:Button ID="btnOcena" Text="Oceni" runat="server" CssClass="btn btn-success" OnClick='<%# "oceniKnjigu(" +Eval("id_knjiga") + " ); return false; " %>'   />
                                  </td>
                                                          
                                <td>
                                    <asp:Button Text="Zatvori" CssClass="btn btn-danger" ID="btnZatvori" OnClick='<%# "zatvoriOcenu(" +Eval("id_knjiga") + " ); return false;" %>' runat="server"/>
                                </td>
                          
                              </tr>
                              <asp:Label Text="" ID="already" runat="server"></asp:Label>
                          </table>
    
                      </li>
                     <li style="display:none" id='<%# string.Concat("detaljnije",Eval("id_knjiga")) %>'>
                        <table class="table">
                           <tr>
                              <td>Autor:</td>
                              <td><%#Eval("ime") %> <%#Eval("prezime") %></td>
                           </tr>
                           <tr>
                              <td>Biografija</td>
                              <td><%#Eval("autor_bio") %></td>
                           </tr>
                           <tr>
                              <td>Opis:</td>
                              <td><%#Eval("opis") %></td>
                           </tr>
                                                   <tr>
                              <td colspan="2">
                                  <asp:Button Text="Zatvori" CssClass="btn btn-info" ID="Button1" OnClick='<%# "zatvori(" +Eval("id_knjiga") + " ); return false;" %>'  runat="server" UseSubmitBehavior="False" />
                              </td>
                                                           
                           </tr>
                        </table>
                     </li>
                     <li id='<%# string.Concat("knjiga",Eval("id_knjiga")) %>'>
                        <table class="table">
                           <asp:Image ID="Image1"  ImageUrl='<%# string.Concat("~/", Eval("slikaMala"))%>' runat="server" />
                           <tr>
                              <td>
                                 Naziv:
                              </td>
                              <td>
                                 <%#Eval("naziv") %>
                              </td>
                           </tr>
                           <tr>
                              <td>
                                 Cena
                              </td>
                              <td>
                                 <%#Eval("cena") %> RSD
                              </td>
                           </tr>
                            
                            <tr>
                                <td>
                                    Ocena
                                </td>
                                <td>
                                    <%#Eval("ZbirnaOcena") %> <!-- ocena -->
                                </td>
                            </tr>
 
                           <tr>
                              <td>Zanr:</td>
                              <td><%#Eval("zanr") %></td>
                           </tr>
                           <tr>
                              <td>Pisac:</td>
                              <td><%#Eval("ime") %> <%#Eval("prezime") %></td>
                           </tr>

                                                       <tr>
                              <td>
                                  <asp:Button Text="Opsirnije" CssClass="btn btn-info" ID="btnMore" OnClick='<%# "sakrij(" +Eval("id_knjiga") + " ); return false;" %>'  runat="server" UseSubmitBehavior="False" />
                              </td>
                                                       
                                                           <td>
<asp:Button Text="Oceni" CssClass="btn btn-success" ID="btnRate" OnClick='<%# "oceni(" +Eval("id_knjiga") + " ); return false; " %>' CommandArgument='<%# Eval("id_knjiga") %>'   runat="server"  />
                                                           </td>
                                                       
                                                           
                           </tr>

                        </table>
                        <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-warning" Text="Dodaj u korpu" OnClick="btnAdd_Click" CommandArgument='<%# Eval("id_knjiga") %>'/>
                     </li>
                  </itemTemplate>
               </asp:ListView>
                
            </ul>
         
         </div>
           <div id="res" style="color:red"></div>
         <script src="js/cbpViewModeSwitch.js" type="text/javascript"></script>
         <script src="js/classie.js" type="text/javascript"></script>
      </div>
   </div>
   <div class="clearfix"></div>
</asp:Content>