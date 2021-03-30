<%@ Page Title="" Language="C#" MasterPageFile="~/NV/nvdh/trangchu_nvdh.Master" AutoEventWireup="true" CodeBehind="QLchuyenxe.aspx.cs" Inherits="DoAn.NV.nvdh.QLchuyenxe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Quản Lý Chuyến Xe
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="link" runat="server">
    <link href="../../CSS/admin_qlnv.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="head2x" runat="server">
    <div id="menuhead" runat="server">
        <div class="tb_tk">
            <%--<asp:Label ID="Label19" runat="server" Text="Nhà Xe"></asp:Label>
            <asp:DropDownList ID="ddl_dsnhaxe" runat="server" Font-Size="15px" Height="30px" Width="150px">
            </asp:DropDownList>--%>
        </div>
        <div class="tb_tk">
            <asp:Label ID="Label18" runat="server" Text="Ngày Đi"></asp:Label>
            <asp:TextBox ID="tb_tk_sdt" runat="server" TextMode="Date" Height="24px" ></asp:TextBox>
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
    <div id="hien_them" visible="false" runat="server" style="margin-left: 270px;">
        <div class="vien_ttnx_nv" style="height: auto;position: fixed;">
            <div style="text-align: center; font-weight: bold;">
                Chuyến Xe:
            <asp:Label ID="lbl_macx" runat="server" Text="" Font-Size="18px"></asp:Label>
            </div>
            <div class="css_nhapnv" style="margin: 15px;">
                <asp:Label ID="Label5" runat="server" Text="Tên chuyến"></asp:Label>
                <br />
                <asp:TextBox ID="tb_tencx" runat="server" CssClass="css_intput" ></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" Text="Tên tuyến"></asp:Label>
                <br />
                <asp:DropDownList ID="ddl_dstuyenxe" OnSelectedIndexChanged="ddl_dstuyenxe_SelectedIndexChanged" AutoPostBack="true" runat="server" Height="29px" Width="245px">
                </asp:DropDownList>
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Text="Nhân viên phụ trách"></asp:Label>
                <br />
                <asp:TextBox ID="tb_nvxe" Enabled="false" runat="server" CssClass="css_intput" ></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label4" runat="server" Text="Xe"></asp:Label>
                <br />
                <asp:DropDownList ID="ddl_ds_xe" OnSelectedIndexChanged="ddl_ds_xe_SelectedIndexChanged" AutoPostBack="true" runat="server" Height="29px" Width="245px">
                </asp:DropDownList>
            </div>
            <div class="css_nhapnv" style="margin: 15px;">
                <asp:Label ID="Label7" runat="server" Text="Ngày đi"></asp:Label>
                <br />
                <asp:TextBox ID="tb_ngaydi" runat="server" CssClass="css_intput" TextMode="Date" Height="25px"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label6" runat="server" Text="Thời gian khởi hành"></asp:Label>
                <br />
                <asp:TextBox ID="tb_tgkh" runat="server" CssClass="css_intput" Enabled="false" Height="25px"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label13" runat="server" Text="Thời gian kết thúc"></asp:Label>
                <br />
                <asp:TextBox ID="tb_tgkt" runat="server" CssClass="css_intput" Enabled="false" Height="25px"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label3" runat="server" Text="Trạng thái"></asp:Label>
                <br />
                <asp:DropDownList ID="ddl_tt_nx" runat="server" Height="29px" Width="245px">
                    <asp:ListItem Value="1" Selected="True">Mở</asp:ListItem>
                    <asp:ListItem Value="0">Khóa</asp:ListItem>
                </asp:DropDownList>
                <div id="luu_thoat" class="css_intput" style="text-align: right; margin-top: 20px;">
                    <asp:LinkButton ID="lbt_luu" runat="server" CssClass="btn" OnClick="lbt_luu_Click">Lưu</asp:LinkButton>
                    <asp:LinkButton ID="lbt_thoat" runat="server" CssClass="btn" OnClick="lbt_thoat_Click">Thoát</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="noidung" runat="server">
    <div id="ds_chuyenxe" runat="server" style="text-align: center;">
        <asp:Label ID="lb_kdl" runat="server" Text=""></asp:Label>
        <asp:GridView ID="grv_chuyenxe" PageSize="10" runat="server" AllowPaging="true"
            OnPageIndexChanging="grv_chuyenxe_PageIndexChanging" AutoGenerateColumns="False"
            BorderColor="#CCCCCC" Font-Size="Medium" CellPadding="4" Font-Names="Calibri"
            Width="100%" BackColor="white" BorderStyle="Solid" BorderWidth="1px" >
            <AlternatingRowStyle BorderColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton ID="sua" runat="server" CommandArgument='<%#Eval("machuyenxe") %>' OnClick="sua_click">Sửa</asp:LinkButton>
                    </ItemTemplate>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:BoundField DataField="tentuyenxe" HeaderText="Tên Tuyến" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="machuyenxe" HeaderText="Mã Chuyến" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="tenchuyenxe" HeaderText="Tên Chuyến" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="biensoxe" HeaderText="Xe Phụ Trách" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="tennv" HeaderText="Nhân Viên Phụ Trách" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Ngaydi" HeaderText="Ngày Đi"  DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="giokh" HeaderText="Giờ Đi" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="gioden" HeaderText="Giờ Đến" ItemStyle-HorizontalAlign="Center">
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
