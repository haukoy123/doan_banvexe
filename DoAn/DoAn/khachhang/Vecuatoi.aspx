<%@ Page Title="" Language="C#" MasterPageFile="~/khachhang/Khachhang.master" AutoEventWireup="true" CodeBehind="Vecuatoi.aspx.cs" Inherits="DoAn.khachhang.Vecuatoi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="chitietve">
    <link href="../CSS/chitietve.css" rel="stylesheet" />
    <div id="fChitiet" style="background-color: white; border: 1px solid black; border-radius: 5px;" runat="server" visible="false">
            <h3 style="text-align: center; padding: 15px 0px 15px 0px;">Chi tiết vé xe</h3>
            <hr />
            <div class="chitiet_container" style="padding: 20px;">
                <div style="float:left;">
                    <div class="ct_ve">
                        <asp:Label runat="server" Text="Mã vé xe:" Width="120px"></asp:Label>
                        <asp:TextBox runat="server" ID="txtMavx" CssClass="txt_ct" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="ct_ve">
                        <asp:Label runat="server" Text="Biển số xe:" Width="120px"></asp:Label>
                        <asp:TextBox runat="server" ID="txtbsx" CssClass="txt_ct" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="ct_ve">
                        <asp:Label runat="server" Text="Giờ khởi hành:" Width="120px"></asp:Label>
                        <asp:TextBox runat="server" ID="txtGiokh" CssClass="txt_ct" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="ct_ve">
                        <asp:Label runat="server" Text="Tỉnh đi:" Width="120px"></asp:Label>
                        <asp:TextBox runat="server" ID="txtTinhdi" CssClass="txt_ct" Enabled="false"></asp:TextBox>
                    </div>
                </div>
                <div style="display: inline-block; padding-left: 30px;">
                    <div class="ct_ve">
                        <asp:Label runat="server" Text="Trạng thái:" Width="120px"></asp:Label>
                        <asp:TextBox runat="server" ID="txtTthai" CssClass="txt_ct" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="ct_ve">
                        <asp:Label runat="server" Text="Thời gian đặt vé" Width="120px"></asp:Label>
                        <asp:TextBox runat="server" ID="txtTgdv" CssClass="txt_ct" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="ct_ve">
                        <asp:Label runat="server" Text="Giờ đến" Width="120px"></asp:Label>
                        <asp:TextBox runat="server" ID="txtGioden" CssClass="txt_ct" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="ct_ve">
                        <asp:Label runat="server" Text="Điểm đến" Width="120px"></asp:Label>
                        <asp:TextBox runat="server" ID="txtDiemden" CssClass="txt_ct" Enabled="false"></asp:TextBox>
                    </div>
                </div>
                <center>
                    <div style="padding-top: 15px; padding-bottom: 10px;">
                        <asp:Button runat="server" ID="btnXong" Text="Xong" CssClass="btn_ctxong" OnClick="btnXong_Click"></asp:Button>
                    </div>
                </center>
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Vecuatoi" runat="server">
    <link href="../CSS/QLKH.css" rel="stylesheet" />
    <div id="fVe">
        <ul class="menuVe">
            <li><a href="Vecuatoi.aspx">Chuyến sắp đi</a></li>
            <li><a href="Chuyendadi.aspx">Chuyến đã đi</a></li>
            <li><a href="Chuyendahuy.aspx">Chuyến đã hủy</a></li>
        </ul>
        <hr />
        <div runat="server" visible="false" id="thongbao">
            <p style="padding-top: 30px; padding-left: 40px;">Bạn chưa có vé nào, hãy <a href="../Datve/datve.aspx" style="text-decoration:none;">đặt vé tại đây</a></p>
        </div>
    </div>
    
    <div id="contentVe" style="margin-top: 20px;">
        <asp:GridView runat="server" ID="gr_vecuatoi" AutoGenerateColumns="false" BackColor="White" Width="100%" CellPadding="10">
            <Columns>
                <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="tentuyenxe" HeaderText="Tên tuyến xe" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                <asp:BoundField DataField="tennx" HeaderText="Tên nhà xe" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                <asp:BoundField DataField="Ngaydi" HeaderText="Ngày đi" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>
                <asp:BoundField DataField="soghe" HeaderText="Số ghế" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                <asp:BoundField DataField="tongtien" HeaderText="Tổng tiền" ItemStyle-HorizontalAlign="Center" ></asp:BoundField>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="chitiet" Text="Chi tiết" CommandArgument='<%# Eval("mavexe") %>' OnClick="chitiet_Click"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
