<%@ Page Title="" Language="C#" MasterPageFile="~/admin/trangchuadmin.Master" AutoEventWireup="true" CodeBehind="QLtuyen.aspx.cs" Inherits="DoAn.admin.QLtuyen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Quản Lý Tuyến
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="link" runat="server">
    <link href="../CSS/admin_qlnv.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="head2x" runat="server">
    <div id="menuhead" runat="server">
        <div class="tb_tk">
            <asp:Label ID="Label19" runat="server" Text="Nhà Xe"></asp:Label>
            <asp:DropDownList ID="ddl_dsnhaxe" runat="server" Font-Size="15px" Height="30px" Width="150px">
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
    <div id="hientttkdat" visible="false" runat="server" style="margin-left: 370px; margin-top: -28px;">
        <div class="vien_ttnx_nv" style="height: auto; position: fixed; padding: 10px 20px;">
            <div style="text-align: center; font-weight: bold;">
                Tuyến Xe:
            <asp:Label ID="lbmatuyen" runat="server" Text="" Font-Size="18px"></asp:Label>
            </div>
            <div class="css_nhapnv">
                <asp:Label ID="Label1" runat="server" Text="Tên Tuyến"></asp:Label>
                <br />
                <asp:TextBox ID="tb_tencx" runat="server" CssClass="css_intput_tuyenxe"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label43" runat="server" Text="Điểm Đi - Điểm Đến"></asp:Label>
                <div>
                    <div style="float: left; display: inline-block">
                        <asp:TextBox ID="tb_tinhdi" runat="server" CssClass="css_tbtuyenxe"></asp:TextBox>
                    </div>
                    <div style="display: inline-block;">Đến</div>
                    <div style="display: inline-block;">
                        <asp:TextBox ID="tb_tinhden" runat="server" CssClass="css_tbtuyenxe"></asp:TextBox>
                    </div>
                </div>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Điểm Đi - Điểm Đến"></asp:Label>
                <div>
                    <div style="float: left; display: inline-block">
                        <asp:TextBox ID="tb_giokh" Height="25px" Width="133px" runat="server" TextMode="Time" CssClass="css_tbtuyenxe"></asp:TextBox>
                    </div>
                    <div style="display: inline-block;">Đến</div>
                    <div style="display: inline-block;">
                        <asp:TextBox ID="tb_giokt" TextMode="Time" Height="25px" Width="133px" runat="server" CssClass="css_tbtuyenxe"></asp:TextBox>
                    </div>
                </div>
                <br />
                <asp:Label ID="Label47" runat="server" Text="Lịch Trình"></asp:Label>
                <br />
                <div>
                    <asp:DropDownList ID="ddl_diemdung" OnSelectedIndexChanged="ddl_diemdung_SelectedIndexChanged" AutoPostBack="true" runat="server" Font-Size="15px" Height="29px" Width="257px">
                    </asp:DropDownList>
                    <asp:LinkButton ID="lbtthemlt" Visible="true" Font-Size="20px" runat="server" OnClick="lbtthemlt_Click" ForeColor="Black"> 
                       
                        <i class="fas fa-edit" style="font-size: 25px; float: right;"></i>
                    </asp:LinkButton>
                    <asp:LinkButton ID="lbtsave" Visible="false" Font-Size="20px" runat="server" OnClick="lbtsave_Click" ForeColor="Black"> 
                    <i class="fas fa-save" style="font-size: 25px; float: right;"></i>    
                    </asp:LinkButton>
                </div>
                <br />
                <asp:Label ID="Label3" runat="server" Text="Điểm Dừng"></asp:Label>
                <div>
                    <div style="float: left; display: inline-block">
                        <asp:TextBox ID="tb_diemdung" Height="25px" Enabled="false" Width="133px" runat="server" CssClass="css_tbtuyenxe"></asp:TextBox>
                    </div>
                    <div style="display: inline-block; margin-left: 10px;">Giá</div>
                    <div style="display: inline-block;">
                        <asp:TextBox ID="tb_gia" TextMode="Number" Enabled="false" Height="25px" Width="70px" runat="server" CssClass="css_tbtuyenxe"></asp:TextBox>
                    </div>
                    <asp:LinkButton ID="lbtxoa" Visible="false" Font-Size="20px" runat="server" OnClick="lbtxoa_Click" ForeColor="Black"> 
                    <i class="fas fa-trash" style="font-size: 25px; float: right;"></i>    
                    </asp:LinkButton>
                </div>
                <div class="css_intput_tuyenxe" style="text-align: right; margin-top: 20px;">
                    <asp:LinkButton ID="lbt_luu" runat="server" CssClass="btn" OnClick="lbt_luu_Click">Lưu</asp:LinkButton>
                    <asp:LinkButton ID="lbt_thoat" runat="server" CssClass="btn" OnClick="lbt_thoat_Click">Thoát</asp:LinkButton>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="noidung" runat="server">
    <div id="ds_nhaxe" runat="server" style="text-align: center;">
        <asp:Label ID="lb_kdl" runat="server" Text=""></asp:Label>
        <asp:GridView ID="grv_dstuyen" PageSize="10" runat="server" AllowPaging="true"
            OnPageIndexChanging="grv_dstuyen_PageIndexChanging" AutoGenerateColumns="False"
            BorderColor="#CCCCCC" Font-Size="Medium" CellPadding="4" Font-Names="Calibri"
            Width="100%" BackColor="white" BorderStyle="Solid" BorderWidth="1px">
            <AlternatingRowStyle BorderColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton ID="sua" runat="server" CommandArgument='<%#Eval("matuyenxe")%>' OnClick="sua_Click">Sửa</asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:BoundField DataField="matuyenxe" HeaderText="Mã Tuyến" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="tentuyenxe" HeaderText="Tên Tuyến" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="tinhdi" HeaderText="Tỉnh Đi" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="tinhden" HeaderText="Tỉnh Đến" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="giokh" HeaderText="Giờ Khởi Hành" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="gioden" HeaderText="Giờ Kết Thúc" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
