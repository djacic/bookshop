<%@ Page Title="" Language="C#" MasterPageFile="~/bookStore.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="aspSajt.admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="skripte" runat="server">
    <script>
        $(document).ready(function () {
            $("page-wrapper").css("padding", "0px");
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="menus" runat="server">
    <asp:Image ID="Image1" runat="server" CssClass="img-responsive" ImageUrl="images/hgw.png" />
</asp:Content>
