<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="DoAn.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="CSS/index.css" rel="stylesheet" />
    <div id="banner1">
        <label>VEXEONLINE - Chắc vé trong tầm tay!</label>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Timve" runat="server">
    <link href="CSS/index.css" rel="stylesheet" />
    <center>
        <form runat="server">
        <h2>Đặt vé xe trực tuyến</h2>
        <table>
            <tr>
                <td class="fTimve">
                    <asp:TextBox runat="server" ID="txtDiemdi" CssClass="text"></asp:TextBox>
                </td>
                <td class="fTimve">
                    <asp:TextBox runat="server" ID="txtDiemden" CssClass="text"></asp:TextBox>
                </td>
                <td class="fTimve">
                    <asp:TextBox runat="server" ID="txtThoigian" TextMode="Date" CssClass="text"></asp:TextBox>
                </td>
                <td class="fTimve">
                    <asp:Button runat="server" ID="btnTimve" Text="TÌM VÉ XE" CssClass="btn" OnClick="btnTimve_Click"/>
                </td>
            </tr>
        </table>
    </form>
    </center>
</asp:Content>
<asp:Content ID="content4" ContentPlaceHolderID="Uudai" runat="server">
    <script src="js/uudai.js"></script>
    <h3 class="txtuudai">Ưu đãi nổi bật</h3>
    <div id="slideshow">
        <div class="slide fade">
            <a href="#"><img src="img/slide1.png" /></a>
        </div>
        <div class="slide fade">
            <a href="#"><img src="img/slide2.png" /></a>
        </div>
        <div class="slide fade">
            <a href="#"><img src="img/slide3.png" /></a>
        </div>
        <div class="slide fade">
            <a href="#"><img src="img/slide4.png" /></a>
        </div>
        <a class="prev" onclick="prev()">&#10094;</a>
        <a class="next" onclick="next()">&#10095;</a>
    </div>
</asp:Content>
<asp:Content ID="content5" ContentPlaceHolderID="Thongtin" runat="server">
    <link href="CSS/index.css" rel="stylesheet" />
    <h3 class="txt">Hệ thống bán vé xe khách lớn nhất Việt Nam</h3>
    <table class="tableInfo">
        <tr>
            <td class="Info">
                <div class="icon">
                    <span class="fa fa-map-o" style="font-size: 40px;"></span>
                </div>
                <div class="txtThongtin">
                    <label>1000+</label>
                    <span>Tuyến đường</span>
                </div>
            </td>
            <td class="Info">
                <div class="icon">
                    <span class="fa fa-map-o" style="font-size: 40px;"></span>
                </div>
                <div class="txtThongtin">
                    <label>1000+</label>
                    <span>Nhà xe</span>
                </div>
            </td>
            <td class="Info">
                <div class="icon">
                    <span class="fa fa-map-o" style="font-size: 40px;"></span>
                </div>
                <div class="txtThongtin">
                    <label>1000+</label>
                    <span>Đại lý bán vé</span>
                </div>
            </td>
            <td class="Info">
                <div class="icon">
                    <span class="fa fa-map-o" style="font-size: 40px;"></span>
                </div>
                <div class="txtThongtin">
                    <label>300+</label>
                    <span>Bến xe</span>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

