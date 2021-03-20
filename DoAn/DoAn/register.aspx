<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="DoAn.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng ký tài khoản</title>
    <link href="./CSS/StyleSheet1.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <div class="container" id="dangky" runat="server">
        <form id="form1" runat="server">
            <h2>Đăng ký tài khoản</h2>
            <p style="color:red;">* Bắt buộc</p>

            <div class="form-group">
                <asp:Label runat="server"><b>Tên khách hàng:</b></asp:Label> <br />
                <asp:TextBox runat="server" CssClass="item" id="txtTenKH" name="TenKH" type="text" placeholder="Tên khách hàng"></asp:TextBox>
            </div>
            
            <div class="form-group">
                <asp:Label runat="server"><b>Email:</b></asp:Label><br />
                <asp:TextBox runat="server" CssClass="item" type="text" id="txtEmail" placeholder="Email"></asp:TextBox>
<%--                <asp:RegularExpressionValidator runat="server" ControlToValidate="txtEmail" ErrorMessage="(*)" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>--%>
            </div>
        
            <div class="form-group">
                <asp:Label runat="server"><b>Mật khẩu:</b></asp:Label><br />
                <asp:TextBox runat="server" CssClass="item" type="password" id="txtMatkhau" placeholder="Mật khẩu"></asp:TextBox>
                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="txtMatkhau" ForeColor="Red" ErrorMessage="(*)"></asp:RequiredFieldValidator>--%>
            </div>

            <div class="form-group">
                <asp:Label runat="server"><b>Nhập lại mật khẩu:</b></asp:Label><br />
                <asp:TextBox runat="server" CssClass="item" type="password" id="txtretypeMatkhau" placeholder="Nhập lại mật khẩu"></asp:TextBox>
                <%--<asp:CompareValidator runat="server" ControlToValidate="txtretypeMatkhau" ControlToCompare="txtMatkhau" Operator="Equal" Type="String" ErrorMessage="(*)" ForeColor="Red"></asp:CompareValidator>--%>
            </div>

            <div class="form-group">
                <asp:Button runat="server" CssClass="register" id="btnTieptuc" type="submit" Text="Tiếp tục" OnClick="btnTieptuc_Click"></asp:Button>
                <asp:Button runat="server" CssClass="register" id="btnHuy" type="submit" Text="Hủy" OnClick="btnHuy_Click"></asp:Button>
            </div>

            <div class="signin">
                <p>Bạn đã có tài khoản? <a href="~/register.aspx">Đăng nhập</a></p>
            </div>
        </form>
    </div>
    <div class="container" id="dangkychitiet" runat="server">
        <form id="form2" runat="server">
            <h2>Chi tiết đăng ký tài khoản</h2>
            <p style="color: red;">* Bắt buộc</p>

            <div class="form-group">
                <asp:Label runat="server"><b>Ngày sinh:</b></asp:Label><br />
                <asp:TextBox runat="server" CssClass="item" id="txtNgaysinh" name="ngaysinh" type="date"></asp:TextBox>
            </div>

            <div class="form-group" style="margin-bottom: 10px;">
                <asp:Label runat="server"><b>Giới tính:</b></asp:Label>
                <asp:RadioButtonList ID="rd_gt" runat="server">
                    <asp:ListItem Text="Nam" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Nữ" Value="1"></asp:ListItem>
                </asp:RadioButtonList>
            </div>

            <div class="form-group">
                <asp:Label runat="server"><b>Số điện thoại:</b></asp:Label><br />
                <asp:TextBox runat="server" CssClass="item" type="text" id="txtSDT" placeholder="Số điện thoại"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label  runat="server"><b>Địa chỉ:</b></asp:Label><br />
                <asp:TextBox runat="server" CssClass="item" type="text" id="txtDiachi" placeholder="Địa chỉ"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label runat="server"><b>Số CMND:</b></asp:Label><br />
                <asp:TextBox runat="server" CssClass="item" type="text" id="txtCmnd" placeholder="Số CMND"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Button runat="server" CssClass="register" id="btnDangky" type="submit" Text="Đăng ký" OnClick="btnDangky_Click1"></asp:Button>
                <asp:Button runat="server" CssClass="register" id="Button1" type="submit" Text="Hủy" OnClick="btnHuydk_Click"></asp:Button>
            </div>

            <div class="signin">
                <p>Bạn đã có tài khoản? <a href="dangnhap.html">Đăng nhập</a>.</p>
            </div>
        </form>
    </div>
</body>
</html>
