<%@ Page Title="" Language="C#" MasterPageFile="~/admin/trangchuadmin.Master" AutoEventWireup="true" CodeBehind="QLtaikhoan.aspx.cs" Inherits="DoAn.admin.QLtaikhoan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Quản Lý Nhân Viên
</asp:Content>
<asp:Content ID="content4" ContentPlaceHolderID="link" runat="server">
    <link href="../CSS/admin_qlnv.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="content3" ContentPlaceHolderID="head2x" runat="server">
    <div id="menuhead" runat="server">
        <div class="tb_tk">
            <asp:Label ID="Label1" runat="server" Text="Quyền"></asp:Label>
            <asp:DropDownList ID="ddl_quyen" runat="server" Font-Size="15px" Height="30px" Width="150px">
            </asp:DropDownList>
        </div>
        <div class="tb_tk">
            <asp:Label ID="Label18" runat="server" Text="Tên Đăng Nhập"></asp:Label>
            <asp:TextBox ID="tb_tk_tendn" runat="server" Height="24px"></asp:TextBox>
        </div>
        <div id="mautk" class="bt_qlnv">
            <i class="fas fa-search "></i>
            <asp:LinkButton ID="btntimkiem_tk" runat="server" ForeColor="White" OnClick="btntimkiem_tk_Click">Tìm Kiếm</asp:LinkButton>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="noidung" runat="server">
    <div id="ds_tk" runat="server" style="display: block; text-align: center;">
        <asp:Label ID="lb_kdl" runat="server" Text=""></asp:Label>
        <asp:GridView ID="gv_dstk" PageSize="10" runat="server" AllowPaging="true"
            OnPageIndexChanging="gv_dstk_PageIndexChanging" AutoGenerateColumns="False"
            BorderColor="#CCCCCC" Font-Size="Medium" CellPadding="4" Font-Names="Calibri"
            Width="100%" BackColor="white" BorderStyle="Solid" BorderWidth="1px">
            <AlternatingRowStyle BorderColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:PlaceHolder ID="CategoryPlaceHolder" runat="server" Visible='<%# Eval("trangthai").ToString().Equals("Mở")%>'>
                            <asp:LinkButton ID="lbt_khoa" runat="server" CommandArgument='<%#Eval("mataikhoan")%>'
                                 OnClick="khoa_click" OnClientClick="return confirm('Bạn thực sự muốn khóa tài khoản?');" > 
                                Khóa 
                            </asp:LinkButton>
                        </asp:PlaceHolder>
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible='<%# Eval("trangthai").ToString() == "Khóa" %>'>
                            <asp:LinkButton ID="lbt_mo" runat="server" CommandArgument='<%#Eval("mataikhoan")%>' 
                                OnClick="mo_click" OnClientClick="return confirm('Bạn thực sự muốn mở?');"> 
                                Mở 
                            </asp:LinkButton>
                        </asp:PlaceHolder>
                    </ItemTemplate>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:BoundField DataField="mataikhoan" HeaderText="Mã Tài Khoản" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="tendn" HeaderText="Tên Đăng Nhập" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="tenquyen" HeaderText="Quyền" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="trangthai" HeaderText="Trạng Thái" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
            </Columns>
            <EmptyDataRowStyle HorizontalAlign="Left" />
        </asp:GridView>
    </div>
</asp:Content>
<asp:Content ID="content5" ContentPlaceHolderID="gd_them" runat="server">
</asp:Content>
