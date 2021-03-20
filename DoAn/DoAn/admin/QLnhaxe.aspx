<%@ Page Title="" Language="C#" MasterPageFile="~/admin/trangchuadmin.Master" AutoEventWireup="true" CodeBehind="QLnhaxe.aspx.cs" Inherits="DoAn.admin.QLnhaxe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Quản Lý Nhân Viên
</asp:Content>
<asp:Content ID="content4" ContentPlaceHolderID="link" runat="server">
    <link href="../CSS/admin_qlnv.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="content3" ContentPlaceHolderID="head2x" runat="server">
    <div id="menuhead" runat="server">
        <div class="tb_tk">
            <asp:Label ID="Label18" runat="server" Text="Số ĐT Nhà Xe"></asp:Label>
            <asp:TextBox ID="tb_tk_sdtnx" runat="server" Height="24px"></asp:TextBox>
        </div>
        <div class="tb_tk">
            <asp:Label ID="Label19" runat="server" Text="Số ĐT Nhân Viên"></asp:Label>
            <asp:TextBox ID="tb_tk_sdtnv" runat="server" Height="24px"></asp:TextBox>
        </div>

        <div id="btthem" class="bt_qlnv">
            <i class="fas fa-plus "></i>
            <asp:LinkButton ID="btnthem_nx" runat="server" ForeColor="White" OnClick="btnthem_nx_Click">Thêm</asp:LinkButton>
        </div>
        <div id="mautk" class="bt_qlnv">
            <i class="fas fa-search "></i>
            <asp:LinkButton ID="btntimkiem_nx" runat="server" ForeColor="White" OnClick="btntimkiem_nx_Click">Tìm Kiếm</asp:LinkButton>
        </div>
    </div>
    <%--<input id="btthem"class="bt_qlnv" type="button" value="Thêm" runat="server" />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="noidung" runat="server">
    <div id="ds_nhaxe" runat="server" style="text-align: center;">
        <asp:Label ID="lb_kdl" runat="server" Text=""></asp:Label>
        <asp:GridView ID="gv_dsnx" PageSize="10" runat="server" AllowPaging="true"
            OnPageIndexChanging="gv_dstk_PageIndexChanging" AutoGenerateColumns="False"
            BorderColor="#CCCCCC" Font-Size="Medium" CellPadding="4" Font-Names="Calibri"
            Width="100%" BackColor="white" BorderStyle="Solid" BorderWidth="1px">
            <AlternatingRowStyle BorderColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton ID="sua" runat="server" CommandArgument='<%#Eval("email") + ";" +Eval("manv")+";" +Eval("mataikhoan")+";"+Eval("manx")%>' OnClick="sua_click">Sửa</asp:LinkButton>
                    </ItemTemplate>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:BoundField DataField="manx" HeaderText="Mã Nhà Xe" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="tennx" HeaderText="Tên Nhà Xe" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="sdt_nhaxe" HeaderText="Số Điện Thoại" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="dc_nhaxe" HeaderText="Địa Chỉ" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="email" HeaderText="Email" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="trangthai_nhaxe" HeaderText="Trạng Thái" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="mataikhoan" HeaderText="Mã Tài Khoản NV" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="manv" HeaderText="Mã NV Điều Hành" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="tennv" HeaderText="Tên NV" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
            </Columns>
            <%--<EmptyDataRowStyle HorizontalAlign="right" />--%>
        </asp:GridView>
    </div>
</asp:Content>
<asp:Content ID="content5" ContentPlaceHolderID="gd_them" runat="server">
    <div id="them" visible="false" runat="server">
        <div class="vien_ttnx_nv" runat="server">
            <div style="text-align: center; font-weight: bold; margin: 5px;">Nhà Xe</div>
            <asp:Label ID="Label1" runat="server" Text="Tên nhà xe"></asp:Label>
            <br />
            <asp:TextBox ID="tb_ten_nx" runat="server" CssClass="css_intput inp_nhaxe "></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Điện thoại"></asp:Label>
            <br />
            <asp:TextBox ID="tb_dt_nx" runat="server" CssClass="css_intput inp_nhaxe"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Địa chỉ"></asp:Label>
            <br />
            <asp:TextBox ID="tb_dc_nx" runat="server" CssClass="css_intput inp_nhaxe"></asp:TextBox>
            <br />
            <asp:Label ID="Label16" runat="server" Text="Email"></asp:Label>
            <br />
            <asp:TextBox ID="tb_email_nx" runat="server" CssClass="css_intput inp_nhaxe"></asp:TextBox>
            <br />
            <asp:Label ID="Label17" runat="server" Text="Trạng Thái"></asp:Label>
            <br />
            <asp:DropDownList ID="ddl_TT_nx" runat="server" Height="30px" Width="240px">
                <asp:ListItem Value="1">Mở</asp:ListItem>
                <asp:ListItem Value="0">Khóa</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div id="nhap_nhanvien" class="vien_ttnx_nv">
            <div style="text-align: center; font-weight: bold;">Thông Tin Nhân Viên</div>
            <div class="TTNX_NV_TK">
                <div style="text-align: center; font-weight: bold; margin: 5px;">Tài Khoản</div>
                <asp:Label ID="Label7" runat="server" Text="Tên đăng nhập"></asp:Label>
                <br />
                <asp:TextBox ID="tb_tendn_tk" runat="server" CssClass="css_intput" OnTextChanged="tb_tendn_tk_TextChanged" AutoPostBack="true"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label8" runat="server" Text="Mật khẩu"></asp:Label>
                <br />
                <asp:TextBox ID="tb_mk_tk" runat="server" CssClass="css_intput" TextMode="Password"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label9" runat="server" Text="Quyền"></asp:Label>
                <br />
                <asp:DropDownList ID="ddl_quyen" runat="server" Height="29px" Width="240px" Enabled="false">
                    <asp:ListItem Value="Q00001" Selected="True">Nhân viên điều hành</asp:ListItem>
                    <asp:ListItem Value="Q00004">Nhân viên xe</asp:ListItem>
                    <asp:ListItem Value="Q00005">Nhân viên bán vé</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <asp:Label ID="Label15" runat="server" Text="Trạng Thái"></asp:Label>
                <br />
                <asp:DropDownList ID="ddl_tt_taikhoan" runat="server" Height="29px" Width="240px">
                    <asp:ListItem Value="1" Selected="True">Mở</asp:ListItem>
                    <asp:ListItem Value="0">Khóa</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="TTNX_NV_TK">
                <div style="text-align: center; font-weight: bold; margin: 5px;">Thông Tin Cá Nhân</div>
                <div class="css_nhapnv">
                    <asp:Label ID="Label4" runat="server" Text="Tên nhân viên"></asp:Label>
                    <br />
                    <asp:TextBox ID="tb_ten_nv" runat="server" CssClass="css_intput"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="Ngày sinh"></asp:Label>
                    <br />
                    <asp:TextBox ID="tb_ns_nv" runat="server" CssClass="css_intput" TextMode="Date" Height="25px"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label6" runat="server" Text="Giới tính"></asp:Label>
                    <br />
                    <asp:RadioButtonList ID="rd_gt_nv" runat="server" Height="29px" RepeatDirection="Horizontal" Width="200px" EnableTheming="True" Font-Overline="False">
                        <asp:ListItem Value="0" Text="Nam" Selected="True" />
                        <asp:ListItem Value="1" Text="Nữ" />
                    </asp:RadioButtonList>

                    <%--<asp:TextBox ID="TextBox6" runat="server" CssClass="css_intput"></asp:TextBox>--%>
                    <br />
                    <asp:Label ID="Label13" runat="server" Text="Điện thoại"></asp:Label>
                    <br />
                    <asp:TextBox ID="tb_dt_nv" runat="server" CssClass="css_intput"></asp:TextBox>
                </div>
                <div class="css_nhapnv">
                    <asp:Label ID="Label10" runat="server" Text="Địa chỉ"></asp:Label>
                    <br />
                    <asp:TextBox ID="tb_dc_nv" runat="server" CssClass="css_intput"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label11" runat="server" Text="Email"></asp:Label>
                    <br />
                    <asp:TextBox ID="tb_email_nv" runat="server" CssClass="css_intput" Enabled="false"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label12" runat="server" Text="CMT ND"></asp:Label>
                    <br />
                    <asp:TextBox ID="tb_cmt_nv" runat="server" CssClass="css_intput"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="Label14" runat="server" Text="Bộ phận"></asp:Label>
                    <br />
                    <asp:TextBox ID="tb_bophan_nv" runat="server" CssClass="css_intput" Enabled="false"></asp:TextBox>
                </div>
            </div>
        </div>
        <div id="nut_gd_them" style="text-align: right">
            <asp:LinkButton ID="lbt_luu" runat="server" CssClass="btn" OnClick="lbt_luu_Click">Lưu</asp:LinkButton>
            <asp:LinkButton ID="lbt_thoat" runat="server" CssClass="btn" OnClick="lbt_thoat_Click">Thoát</asp:LinkButton>
        </div>
    </div>
</asp:Content>
