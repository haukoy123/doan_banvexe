<%@ Page Title="" Language="C#" MasterPageFile="~/khachhang/Khachhang.master" AutoEventWireup="true" CodeBehind="Qlkhachhang.aspx.cs" Inherits="DoAn.khachhang.Qlkhachhang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="thongtinKH" runat="server">
    <link href="../CSS/QLKH.css" rel="stylesheet" />
    <h3 class="text">Thông Tin Khách Hàng</h3>
    <p class="text">Quản lý thông tin để bảo mật tài khoản</p>
    <hr />
        <table class="tblThongtin">
            <tr>
                <td>
                    <asp:Label runat="server">Tên đăng nhập</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtTendn" CssClass="textbox" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server">Tên khách hàng</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtTenKH" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server">Ngày sinh</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtNgaysinh" CssClass="textbox" TextMode="Date"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server">Giới tính</asp:Label>
                </td>
                <td>
                    <asp:RadioButtonList ID="rd_gt_kh" runat="server" RepeatDirection="Horizontal" EnableTheming="True" Font-Overline="False">
                        <asp:ListItem Value="0" Text=" Nam" Selected="True" />
                        <asp:ListItem Value="1" Text=" Nữ" />
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server">Số điện thoại</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtSdt" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server">Địa chỉ</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtDiachi" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server">Email</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtEmail" CssClass="textbox" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server">Số CMND</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtCmnd" CssClass="textbox"></asp:TextBox>
                </td>
            </tr>
        </table>
        <center>
            <div id="btn">
                <asp:Button runat="server" Text="Lưu" ID="btnLuu" CssClass="button" OnClick="btnLuu_Click"/>
            </div>
        </center>
</asp:Content>