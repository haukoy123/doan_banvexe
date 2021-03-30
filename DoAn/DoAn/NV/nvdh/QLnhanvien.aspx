<%@ Page Title="" Language="C#" MasterPageFile="~/NV/nvdh/trangchu_nvdh.Master" AutoEventWireup="true" CodeBehind="QLnhanvien.aspx.cs" Inherits="DoAn.NV.nvdh.QLnhanvien" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Quản Lý Nhân Viên
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="link" runat="server">
    <link href="../../CSS/admin_qlnv.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="head2x" runat="server">
    <div id="menuhead" runat="server">
        <div class="tb_tk">
            <asp:Label ID="Label19" runat="server" Text="Bộ Phận"></asp:Label>
            <asp:DropDownList ID="ddl_dsnhaxe" runat="server" Font-Size="15px" Height="30px" Width="150px">
                <asp:ListItem Text="---Chọn-------"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="tb_tk">
            <asp:Label ID="Label18" runat="server" Text="Số Điện Thoại"></asp:Label>
            <asp:TextBox ID="tb_tk_sdt" runat="server" Height="24px"></asp:TextBox>
        </div>

        <div id="btthem" class="bt_qlnv">
            <i class="fas fa-plus "></i>
            <asp:LinkButton ID="btnthem" runat="server" ForeColor="White" OnClick="btnthem_Click">Thêm</asp:LinkButton>
        </div>
        <div id="mautk" class="bt_qlnv">
            <i class="fas fa-search "></i>
            <asp:LinkButton ID="btntimkiem" runat="server" ForeColor="White" OnClick="btntimkiem_Click">Tìm Kiếm</asp:LinkButton>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="gd_them" runat="server">
    <div id="hien_them" visible="false" runat="server" style="margin-left: 170px;">
        <div class="vien_ttnx_nv" style="height: auto; position: fixed; width: 800px;">
            <div style="text-align: center; font-weight: bold;">Thông Tin Nhân Viên</div>
            <div class="TTNX_NV_TK">
                <div style="text-align: center; font-weight: bold; margin: 5px;">Tài Khoản</div>
                <asp:Label ID="Label7" runat="server" Text="Tên đăng nhập"></asp:Label>
                <br />
                <asp:TextBox ID="tb_tendn_tk" runat="server" CssClass="css_intput" OnTextChanged="tb_tendn_tk_TextChanged" AutoPostBack="true"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lablemk" runat="server" Text="Mật khẩu"></asp:Label>
                <br />
                <asp:TextBox ID="tb_mk_tk" runat="server" CssClass="css_intput" TextMode="Password"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label9" runat="server" Text="Quyền"></asp:Label>
                <br />
                <asp:DropDownList ID="ddl_quyen" runat="server" Height="29px" Width="240px" OnSelectedIndexChanged="ddl_quyen_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Value="Q00004" Selected ="True">Nhân viên xe</asp:ListItem>
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
            <div id="nut_gd_them" style="text-align: right; margin-left: 657px; float: right; padding: 0px 6px; margin: 10px 0px;">
                <asp:LinkButton ID="lbt_luu" runat="server" CssClass="btn" OnClick="lbt_luu_Click">Lưu</asp:LinkButton>
                <asp:LinkButton ID="lbt_thoat" runat="server" CssClass="btn" OnClick="lbt_thoat_Click">Thoát</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="noidung" runat="server">
    <div id="ds_chuyenxe" runat="server" style="text-align: center;">
        <asp:Label ID="lb_kdl" runat="server" Text=""></asp:Label>
        <div id="ds_nhanvien" runat="server" style="text-align: center;">
            <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
            <asp:GridView ID="grd_dsnv" PageSize="10" runat="server" AllowPaging="true"
                OnPageIndexChanging="gv_dsnv_PageIndexChanging" AutoGenerateColumns="False"
                BorderColor="#CCCCCC" Font-Size="Medium" CellPadding="4" Font-Names="Calibri"
                Width="100%" BackColor="white" BorderStyle="Solid" BorderWidth="1px">
                <AlternatingRowStyle BorderColor="#CCCCCC" />
                <Columns>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:PlaceHolder ID="CategoryPlaceHolder" runat="server" Visible='<%# Eval("trangthai_nv").ToString().Equals("Mở")%>'>
                                <asp:LinkButton ID="lbt_khoa" runat="server" CommandArgument='<%#Eval("mataikhoan")%>'
                                    OnClick="khoa_click" OnClientClick="return confirm('Bạn thực sự muốn khóa tài khoản?');"> 
                                Khóa 
                                </asp:LinkButton>
                            </asp:PlaceHolder>
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible='<%# Eval("trangthai_nv").ToString() == "Khóa" %>'>
                                <asp:LinkButton ID="lbt_mo" runat="server" CommandArgument='<%#Eval("mataikhoan")%>'
                                    OnClick="mo_click" OnClientClick="return confirm('Bạn thực sự muốn mở?');"> 
                                Mở 
                                </asp:LinkButton>
                            </asp:PlaceHolder>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="manv" HeaderText="Mã Nhân Viên" ItemStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="tennv" HeaderText="Tên" ItemStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="ngaysinh" HeaderText="Ngày sinh" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="gioitinh" HeaderText="Giới Tính" ItemStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="sdt_nhaxe" HeaderText="Số Điện Thoại" ItemStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="dc_nhanvien" HeaderText="Địa Chỉ" ItemStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="cmnd" HeaderText="Số CMTND" ItemStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="tenquyen" HeaderText="Bộ Phận" ItemStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="trangthai_nv" HeaderText="Trạng Thái" ItemStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                </Columns>
                <EmptyDataRowStyle HorizontalAlign="Left" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
