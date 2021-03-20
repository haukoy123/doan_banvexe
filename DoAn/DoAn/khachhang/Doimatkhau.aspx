<%@ Page Title="" Language="C#" MasterPageFile="~/khachhang/Khachhang.master" AutoEventWireup="true" CodeBehind="Doimatkhau.aspx.cs" Inherits="DoAn.khachhang.Doimatkhau" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Doimatkhau" runat="server">
    <link href="../CSS/QLKH.css" rel="stylesheet" />
    <h3 class="text">Đổi mật khẩu</h3>
    <p class="text">Để bảo mật tài khoản, vui lòng không chia sẻ mật khẩu cho người khác.</p>
    <hr />
    <form runat="server" id="fDoimk">
        <table class="tblThongtin">
            <tr>
                <td>
                    <asp:Label runat="server">Mật Khẩu Hiện Tại</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtMKcu" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server">Mật Khẩu Mới</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtMKmoi" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server">Nhập Lại Mật Khẩu</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtrpMK" CssClass="textbox"></asp:TextBox>
                </td>
                <td>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtMKmoi" ControlToValidate="txtrpMK" ForeColor="Red">(*)</asp:CompareValidator>
                </td>
            </tr>
        </table>
        <center>
            <div id="btn">
                <asp:Button runat="server" Text="Xác nhận" ID="btnXacnhan" CssClass="button" OnClick="btnXacnhan_Click"/>
                <asp:Button runat="server" Text="Hủy" ID="btnHuy" CssClass="button" OnClick="btnHuy_Click"/>
            </div>
        </center>
    </form>
</asp:Content>
