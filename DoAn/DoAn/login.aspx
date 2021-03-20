<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="DoAn.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập</title>
    <link href="./CSS/StyleSheet1.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <div class="container">
        <form id="form1" runat="server">
            <h2>Đăng nhập tài khoản</h2>

            <div>
                <asp:Label runat="server"><b>Tên đăng nhập:</b></asp:Label><br />
                <input class="item" type="email" id="txtTenDN" name="tendangnhap" />
            </div>
            <div>
                <asp:Label runat="server"><b>Mật khẩu:</b></asp:Label><br />
                <input class="item" type="password" id="psw" name="password" />
            </div>

            <div>
                <asp:Button runat="server" CssClass="register" type="submit" id="btnLogin" Text="Đăng nhập" Width="147px" OnClick="btnLogin_Click" ></asp:Button>
                <asp:Button runat="server" CssClass="register" type="submit" id="btnThoat" Text="Thoát" OnClick="btnThoat_Click" ></asp:Button>
            </div>

            <div class="signin">
                <asp:Label ID="lbdnsai" runat="server" Text="" ForeColor="Red" Height="1px"></asp:Label>
                <p><a href="dangnhap.html">Quên mật khẩu.</a></p>
            </div>
        </form>
    </div>
</body>
</html>
