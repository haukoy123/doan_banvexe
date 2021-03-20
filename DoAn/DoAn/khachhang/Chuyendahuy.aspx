<%@ Page Title="" Language="C#" MasterPageFile="~/khachhang/Khachhang.master" AutoEventWireup="true" CodeBehind="Chuyendahuy.aspx.cs" Inherits="DoAn.khachhang.Chuyendahuy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="thongtinKH" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Doimatkhau" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Vecuatoi" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Chuyendahuy" runat="server">
    <link href="../CSS/QLKH.css" rel="stylesheet" />
    <div id="fVe">
        <ul class="menuVe">
            <li><a href="Vecuatoi.aspx">Chuyến sắp đi</a></li>
            <li><a href="Chuyendadi.aspx">Chuyến đã đi</a></li>
            <li><a href="Chuyendahuy.aspx">Chuyến đã hủy</a></li>
        </ul>
        <hr />
    </div>
</asp:Content>
