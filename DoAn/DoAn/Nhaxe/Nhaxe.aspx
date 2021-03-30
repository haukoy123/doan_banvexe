<%@ Page Title="" Language="C#" MasterPageFile="~/Nhaxe/Nhaxe.Master" AutoEventWireup="true" CodeBehind="Nhaxe.aspx.cs" Inherits="DoAn.Nhaxe.Nhaxe1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Thongtinnhaxe" runat="server">
    <link href="../CSS/slideshow.css" rel="stylesheet" />
    <script src="../js/slideshow.js"></script>
    <div class="tt_ct_nx">
        <h3>1. Thông tin xe Văn Minh</h3>
        <p>
            Hãng xe Văn Minh chuyên cung cấp xe giường nằm cao cấp chạy tuyến Hà Nội – Hà Tĩnh, 
       Hà Nội – Cửa Lò – Vinh (Nghệ An). Nhà xe Văn Minh luôn giữ chữ tín, thân thiện với khách hàng, 
       bảo đảm xe chạy đúng giờ, không bắt khách dọc đường, bán vé trước, không nhồi nhét khách.
       Hãng xe Văn Minh cũng luôn giữ những quy định nghiêm khắc với đội ngũ tài xế lái xe để đảm bảo tối đa an toàn cho khách hàng.
        </p>
        <div class="slideshow-container">
            <div class="mySlides fade">
                <div class="numbertext">1 / 3</div>
                <a href="../img/vanminh.jfif">../img/vanminh.jfif</a>
            </div>
            <div class="mySlides fade">
                <div class="numbertext">2 / 3</div>
                <img src="../img/vanminh2.jpg" />
            </div>
            <div class="mySlides fade">
                <div class="numbertext">3 / 3</div>
                <img src="../img/vanminh3.jpg" />
            </div>
            <a class="prev" onclick="plusSlides(-1)">❮</a>
            <a class="next" onclick="plusSlides(1)">❯</a>
        </div>
        <h3>2. Số điện thoại - địa chỉ</h3>
        <div class="tt_nx">
            <table>
                <tr>
                    <th>Văn phòng nhà xe Văn Minh ở Hà Nội</th>
                    <th>Liên hệ</th>
                </tr>
                <tr>
                    <td>Phòng vé Xã Đàn - 242 Xã Đàn, Đống Đa</td>
                    <td><i class="fa fa-phone" style="font-size: 20px; margin-right: 10px;"></i>1900 888684</td>
                </tr>
                <tr>
                    <td>Phòng vé Trần Duy Hưng - 170A Trần Duy Hưng, Q. Cầu Giấy</td>
                    <td><i class="fa fa-phone" style="font-size: 20px; margin-right: 10px;"></i>1900 888684</td>
                </tr>
                <tr>
                    <td>Phòng vé Trần Bình - 172 Trần Bình, Q.Cầu Giấy</td>
                    <td><i class="fa fa-phone" style="font-size: 20px; margin-right: 10px;"></i>1900 888684</td>
                </tr>
                <tr>
                    <td>Phòng vé Xuân Mai - Xuân Thủy, Xã Thủy Xuân Tiên, Chương Mỹ</td>
                    <td><i class="fa fa-phone" style="font-size: 20px; margin-right: 10px;"></i>1900 888684</td>
                </tr>
                <tr>
                    <td>Phòng vé BX Nước Ngầm - Bến xe Nước Ngầm – Q. Hoàng Mai</td>
                    <td><i class="fa fa-phone" style="font-size: 20px; margin-right: 10px;"></i>1900 888684</td>
                </tr>
                <tr>
                    <td>Phòng vé BX Gia Lâm - Bến xe Gia Lâm – Gia Lâm</td>
                    <td><i class="fa fa-phone" style="font-size: 20px; margin-right: 10px;"></i>1900 888684</td>
                </tr>
                <tr>
                    <td>Phòng vé BX Yên Nghĩa - Bến xe Yên Nghĩa – Q. Hà Đông</td>
                    <td><i class="fa fa-phone" style="font-size: 20px; margin-right: 10px;"></i>1900 888684</td>
                </tr>
            </table>
        </div>
        <h3 style="margin-top: 10px;">3. Đánh giá chi tiết của khách hàng</h3>
        <div runat="server" class="binhluan">
            <asp:DataList runat="server" ID="dlDSBinhluan" RepeatColumns="1" GridLines="Vertical" RepeatDirection="Vertical" CellPadding="2" BorderStyle="None" ItemStyle-BorderStyle="None" Width="100%">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblNoidung" Text=""></asp:Label>
                    <asp:Label runat="server" ID="lblTenKh" Text=""></asp:Label>
                    <asp:Label runat="server" ID="lblThoigian" Text=""></asp:Label>
                    <hr />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <center>
            <div runat="server" class="them_bl">
                <asp:TextBox runat ="server" CssClass="txtnoidung"></asp:TextBox>
                <asp:LinkButton runat="server" Text="Gửi" CssClass="btnGui"></asp:LinkButton>
            </div>
        </center>
    </div>
</asp:Content>
