<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="DoAn.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="CSS/index.css" rel="stylesheet" />
    <center>
        <img src="img/xekhach.jpg" width="100%"/>
    </center>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Timve" runat="server">
    <link href="CSS/index.css" rel="stylesheet" />
    <center>
       <div class="fDV">
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
       </div>
    </center>
</asp:Content>
<asp:Content ID="content4" ContentPlaceHolderID="Uudai" runat="server">
    <script src="js/uudai.js"></script>
    <h3 class="txtuudai">Ưu đãi nổi bật</h3>
    <div id="slideshow">
        <div class="slide fade">
            <a href="#">
                <img src="img/slide1.png" /></a>
        </div>
        <div class="slide fade">
            <a href="#">
                <img src="img/slide2.png" /></a>
        </div>
        <div class="slide fade">
            <a href="#">
                <img src="img/slide3.png" /></a>
        </div>
        <div class="slide fade">
            <a href="#">
                <img src="img/slide4.png" /></a>
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
                    <span class="fa fa-bus" style="font-size: 40px;"></span>
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
<asp:Content runat="server" ID="Content6" ContentPlaceHolderID="DSNhaxe">
    <div class="tt_bx_tx_nx">
        <table>
        <tr>
            <th>Nhà xe</th>
            <th>Tuyến xe</th>
            <th>Bến xe</th>
        </tr>
        <tr>
            <td>
                <asp:LinkButton runat="server" Text="Nhà xe Văn Minh" CssClass="lbtn"></asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton runat="server" Text="Xe đi Hà Nam từ Hà Nội" CssClass="lbtn"></asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton runat="server" Text="Bến xe Nước Ngầm" CssClass="lbtn"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton runat="server" Text="Nhà xe Phương Hà" CssClass="lbtn"></asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton runat="server" Text="Xe đi Ninh Bình từ Hà Nội" CssClass="lbtn"></asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton runat="server" CssClass="lbtn" Text="Bến xe Mỹ Đình"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton runat="server" Text="Nhà xe Tuấn Đạt" CssClass="lbtn"></asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton runat="server" Text="Xe đi Hòa Bình từ Hà Nội" CssClass="lbtn"></asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton runat="server" Text="Bến xe Gia Lâm" CssClass="lbtn"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton runat="server" Text="Nhà xe Phương Dũng" CssClass="lbtn"></asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton runat="server" Text="Xe đi Nghệ An từ Hà Nội" CssClass="lbtn"></asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton runat="server" CssClass="lbtn" Text="Bến xe Yên Nghĩa"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton runat="server" Text="Nhà xe Khánh Hoàn" CssClass="lbtn"></asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton runat="server" Text="Xe đi Hải Dương từ Hà Nội" CssClass="lbtn"></asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton runat="server" Text="Bến xe Giáp Bát" CssClass="lbtn" ></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton runat="server" Text="Nhà xe Hải Âu" CssClass="lbtn"></asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton runat="server" Text="Xe đi Hải Phòng từ Hà Nội" CssClass="lbtn"></asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton runat="server" ></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton runat="server" Text="Nhà xe Quang Long" CssClass="lbtn"></asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton runat="server" ></asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton runat="server" ></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton runat="server" Text="Nhà xe Thanh Bình" CssClass="lbtn"></asp:LinkButton>
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton runat="server" Text="Nhà xe Tiến Oanh" CssClass="lbtn"></asp:LinkButton>
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton runat="server" Text="Nhà xe Quốc Đạt" CssClass="lbtn"></asp:LinkButton>
            </td>
            <td></td>
            <td></td>
        </tr>
    </table>
    </div>
</asp:Content>





