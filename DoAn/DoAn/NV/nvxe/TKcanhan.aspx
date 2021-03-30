<%@ Page Title="" Language="C#" MasterPageFile="~/NV/nvxe/trangchunvxe.Master" AutoEventWireup="true" CodeBehind="TKcanhan.aspx.cs" Inherits="DoAn.NV.nvxe.TKcanhan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Thông Tin Cá Nhân
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="link" runat="server">
    <link href="../../CSS/Thongtincanhan.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="head2x" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="gd_them" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="noidung" runat="server">
    <div id="gd_ttnv">
        <h3 class="text">Thông tin Nhân viên</h3>
        <p class="text">Quản lý thông tin để bảo mật tài khoản</p>
        <hr style="margin: 0px;" />
        <div id="thongtin">
            <div class="gd_ttnv_left">
                <asp:Label ID="lblMatk" runat="server" Text="Mã tài khoản:" CssClass="lbl_tt"></asp:Label><br />
                <asp:TextBox ID="txtMatk" runat="server" Enabled="false" CssClass="textbox"></asp:TextBox><br />
                <asp:Label ID="lblTendn" runat="server" Text="Tên đăng nhập:" CssClass="lbl_tt"></asp:Label><br />
                <asp:TextBox ID="txtTendn" runat="server" Enabled="false" CssClass="textbox"></asp:TextBox><br />
                <asp:Label runat="server" ID="lblTennx" Text="Tên nhà xe:" CssClass="lbl_tt"></asp:Label><br />
                <asp:TextBox runat="server" ID="txtTennx" Enabled="false" CssClass="textbox"></asp:TextBox><br />
                <asp:Label runat="server" ID="lblBophan" Text="Bộ phận:" CssClass="lbl_tt"></asp:Label><br />
                <asp:TextBox runat="server" ID="txtBophan" Enabled="false" CssClass="textbox"></asp:TextBox><br />
            </div>
            <div class="gd_ttnv_right">
                <div class="gd_ttnv_right_1">
                    <asp:Label runat="server" ID="lblManv" Text="Mã nhân viên:" CssClass="lbl_tt"></asp:Label><br />
                    <asp:TextBox runat="server" ID="txtManv" Enabled="false" CssClass="textbox"></asp:TextBox><br />
                    <asp:Label runat="server" ID="lblTennv" Text="Tên nhân viên:" CssClass="lbl_tt"></asp:Label><br />
                    <asp:TextBox runat="server" ID="txtTenv" CssClass="textbox"></asp:TextBox><br />
                    <asp:Label runat="server" ID="lblNgaysinh" Text="Ngày sinh:" CssClass="lbl_tt"></asp:Label><br />
                    <asp:TextBox runat="server" ID="txtNgaysinh" TextMode="Date" CssClass="textbox"></asp:TextBox><br />
                    <asp:Label runat="server" ID="lblGioitinh" Text="Giới tính:" CssClass="lbl_tt"></asp:Label><br />
                    <asp:RadioButtonList runat="server" ID="rdGioitinh" RepeatDirection="Horizontal" EnableTheming="true" Font-Overline="false" CssClass="rd_gt">
                        <asp:ListItem Value="0" Text=" Nam" Selected="True" />
                        <asp:ListItem Value="1" Text=" Nữ" />
                    </asp:RadioButtonList>
                </div>
                <div class="gd_ttnv_right_2">
                    <asp:Label runat="server" ID="lblDiachi" Text="Địa chỉ:" CssClass="lbl_tt"></asp:Label><br />
                    <asp:TextBox runat="server" ID="txtDiachi" CssClass="textbox"></asp:TextBox><br />
                    <asp:Label runat="server" ID="lblEmail" Text="Email:" CssClass="lbl_tt"></asp:Label><br />
                    <asp:TextBox runat="server" ID="txtEmail" Enabled="false" CssClass="textbox"></asp:TextBox><br />
                    <asp:Label runat="server" ID="lblSdt" Text="Số điện thoại:" CssClass="lbl_tt"></asp:Label><br />
                    <asp:TextBox runat="server" ID="txtSdt" CssClass="textbox"></asp:TextBox><br />
                    <asp:Label runat="server" ID="lblCmnd" Text="Số CMND:" CssClass="lbl_tt"></asp:Label><br />
                    <asp:TextBox runat="server" ID="txtCmnd" CssClass="textbox"></asp:TextBox><br />
                </div>
            </div>
            <center>
                <div class="btn">
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="linkbtn" OnClick="lbtnLuu_Click">Lưu</asp:LinkButton>
                </div>
            </center>
        </div>
    </div>
</asp:Content>
