<%@ Page Title="" Language="C#" MasterPageFile="~/NV/nvxe/trangchunvxe.Master" AutoEventWireup="true" CodeBehind="QLchuyendi.aspx.cs" Inherits="DoAn.NV.nvxe.QLchuyendi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="link" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="head2x" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="gd_them" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="noidung" runat="server">
    <div id="allchuyendi" visible="true" runat="server" style="text-align: center;">
        <asp:Label ID="lb_kdl" runat="server" Text=""></asp:Label>
        <asp:GridView ID="dschuyendi" PageSize="10" runat="server" AllowPaging="true"
            OnPageIndexChanging="dschuyendi_PageIndexChanging" AutoGenerateColumns="False"
            BorderColor="#CCCCCC" Font-Size="Medium" CellPadding="4" Font-Names="Calibri"
            Width="100%" BackColor="white" BorderStyle="Solid" BorderWidth="1px">
            <AlternatingRowStyle BorderColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton ID="chitiet" runat="server" CommandArgument='<%#Eval("machuyenxe") %>' OnClick="chitiet_Click">Xem</asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>

                <asp:BoundField DataField="Ngaydi" HeaderText="Ngày Đi" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="machuyenxe" HeaderText="Mã Chuyến" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="tenchuyenxe" HeaderText="Tên Chuyến" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="tentuyenxe" HeaderText="Tên Tuyến" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="biensoxe" HeaderText="Biển Số Xe" ItemStyle-HorizontalAlign="Center">
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
                <asp:BoundField DataField="trangthai" HeaderText="Trạng Thái" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
            </Columns>
            <EmptyDataRowStyle HorizontalAlign="Left" />
        </asp:GridView>
    </div>
     <div id="dsve_chuyen" visible="false" runat="server" style="text-align: center;">
        <div style="float: left;">
            <asp:LinkButton ID="tbloke" runat="server" CssClass="btn" OnClick="tbloke_Click"><i class="fas fa-angle-double-left"></i>Trở Lại</asp:LinkButton>
        </div>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <asp:GridView ID="grv_dsvechuyen" PageSize="10" runat="server" AllowPaging="true"
            OnPageIndexChanging="grv_dsvechuyen_PageIndexChanging" AutoGenerateColumns="False"
            BorderColor="#CCCCCC" Font-Size="Medium" CellPadding="4" Font-Names="Calibri"
            Width="100%" BackColor="white" BorderStyle="Solid" BorderWidth="1px">
            <AlternatingRowStyle BorderColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:PlaceHolder ID="CategoryPlaceHolder" runat="server" Visible='<%# Eval("tt_ve").ToString().Equals("Đã đặt")%>'>
                            <asp:LinkButton ID="xacnhanve" runat="server" CommandArgument='<%#Eval("mavexe") + ";" + Eval("trangthai")+";"+Eval("machuyenxe") %>' OnClick="xacnhanve_Click">Xác nhận vé</asp:LinkButton>
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
                <asp:BoundField DataField="machuyenxe" HeaderText="Mã Chuyến" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="mavexe" HeaderText="Mã Vé" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="tenkh" HeaderText="Tên Khách Đi" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="sdt" HeaderText="Số Điện Thoại" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="thoigiandatve" HeaderText="Thời Gian Đặt Vé" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="diemden" HeaderText="Điểm Đến" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="soghe" HeaderText="Số Ghế" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="tt_ve" HeaderText="Trạng Thái" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
            </Columns>
            <EmptyDataRowStyle HorizontalAlign="Left" />
        </asp:GridView>
    </div>
</asp:Content>
