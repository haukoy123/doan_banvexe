<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="QLDatveKH.aspx.cs" Inherits="DoAn.QLDatveKH" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Datve.css" rel="stylesheet" />
    <link href="CSS/index.css" rel="stylesheet" />
</asp:Content>
<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="gd_tk_cx">
    <div class="fDV">
        <h2>Đặt vé xe trực tuyến</h2>
        <table>
            <tr>
                <td class="fTimve">
                    <asp:TextBox ID="txtDiemdi" CssClass="text" Text="" runat="server"></asp:TextBox>
                </td>
                <td class="fTimve">
                    <asp:TextBox runat="server" ID="txtDiemden" CssClass="text"></asp:TextBox>
                </td>
                <td class="fTimve">
                    <asp:TextBox runat="server" ID="txtThoigian" CssClass="text" TextMode="Date"></asp:TextBox>
                </td>
                <td class="fTimve">
                    <asp:Button runat="server" ID="btnTimve" Text="TÌM VÉ XE" CssClass="btnTv" OnClick="btnTimve_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

<asp:Content runat="server" ID="Content3" ContentPlaceHolderID="dv_boloc">
    <div class="lblBoloc">
        <p style="text-align: center; font-size: 18px; font-weight: 400;">Bộ lọc tìm kiếm</p>
        <hr />
        <p style="padding-top: 10px; padding-bottom: 10px;">Nhà xe</p>
        <asp:CheckBoxList runat="server">
            <asp:ListItem>Văn Minh</asp:ListItem>
            <asp:ListItem>Cúc Mừng</asp:ListItem>
            <asp:ListItem>Phương Dũng</asp:ListItem>
            <asp:ListItem>Tràng An</asp:ListItem>
            <asp:ListItem>Khánh Hoàn</asp:ListItem>
        </asp:CheckBoxList>
        <p style="padding-top: 10px; padding-bottom: 10px;">Điểm trả</p>
        <asp:CheckBoxList runat="server">
            <asp:ListItem >Chùa Tam Chúc</asp:ListItem>
            <asp:ListItem>Lý Nhân</asp:ListItem>
            <asp:ListItem>Phủ Lý</asp:ListItem>
            <asp:ListItem>Thanh Liêm</asp:ListItem>
            <asp:ListItem>Duy Tiên</asp:ListItem>
        </asp:CheckBoxList>
        <p style="padding-top: 10px; padding-bottom: 10px;">Giờ đón</p>
        <asp:DropDownList runat="server">
            <asp:ListItem>6:00</asp:ListItem>
            <asp:ListItem>8:00</asp:ListItem>
            <asp:ListItem>10:00</asp:ListItem>
            <asp:ListItem>12:00</asp:ListItem>
            <asp:ListItem>14:00</asp:ListItem>
            <asp:ListItem>16:00</asp:ListItem>
            <asp:ListItem>18:00</asp:ListItem>
            <asp:ListItem>20:00</asp:ListItem>
            <asp:ListItem>22:00</asp:ListItem>
        </asp:DropDownList>
        <p style="padding-top: 10px; padding-bottom: 10px;">Loại ghế/ xe</p>
        <asp:CheckBoxList runat="server">
            <asp:ListItem>Ghế ngồi</asp:ListItem>
            <asp:ListItem>Giường nằm</asp:ListItem>
        </asp:CheckBoxList>
    </div>
</asp:Content>

<asp:Content runat="server" ID="Content4" ContentPlaceHolderID="gd_ttkh">
    <div id="ftt_datve" runat="server" visible="false" style="border: 1px solid darkgrey;">
        <h3 style="text-align: center; padding-top: 15px; padding-bottom: 15px;">Thông tin đặt vé</h3>
        <hr />
        <div class="tt_container">
            <div style="float: left;">
                <div class="thongtin">
                    <asp:Label runat="server" Text="Họ tên:" Width="120px"></asp:Label>
                    <asp:TextBox runat="server" ID="txtTenkh" CssClass="txt"></asp:TextBox>
                </div>
                <div class="thongtin">
                    <asp:Label runat="server" Width="120px">Số điện thoại:</asp:Label>
                    <asp:TextBox runat="server" ID="txtSdt" CssClass="txt"></asp:TextBox>
                </div>
                <div class="thongtin">
                    <asp:Label runat="server" Width="120px">Mã Chuyến Xe:</asp:Label>
                    <asp:TextBox runat="server" ID="txtCX" CssClass="txt" Enabled="false"></asp:TextBox>
                </div>
                <div class="thongtin">
                    <asp:Label runat="server" Width="120px">Ngày đi:</asp:Label>
                    <asp:TextBox runat="server" ID="txtNgaydi" CssClass="txt" Enabled="false"></asp:TextBox>
                </div>
                <div class="thongtin">
                    <asp:Label runat="server" Width="120px">Trạng thái:</asp:Label>
                    <asp:TextBox runat="server" ID="txtTrangthai" CssClass="txt" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div style="padding-left: 20px; display: inline-block;">
                <div class="thongtin">
                    <asp:Label runat="server" Width="120px">Giờ đi:</asp:Label>
                    <asp:TextBox runat="server" ID="txtGiodi" CssClass="txt" Enabled="false"></asp:TextBox>
                </div>
                <div class="thongtin">
                    <asp:Label runat="server" Width="120px">Giờ đến:</asp:Label>
                    <asp:TextBox runat="server" ID="txtGioden" CssClass="txt" Enabled="false"></asp:TextBox>
                </div>
                <div class="thongtin">
                    <asp:Label runat="server" Width="120px">Số lượng ghế:</asp:Label>
                    <asp:TextBox runat="server" ID="txtSoluong" CssClass="txt" OnTextChanged="txtSoluong_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>
                </div>
                <div class="thongtin">
                    <asp:Label runat="server" Width="120px">Điểm đến:</asp:Label>
                    <asp:DropDownList runat="server" ID="ddlLichtrinh" CssClass="txt" OnSelectedIndexChanged="ddlLichtrinh_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </div>
                <div class="thongtin">
                    <asp:Label runat="server" Width="120px">Tổng tiền:</asp:Label>
                    <asp:TextBox runat="server" ID="txtTongtien" CssClass="txt" Enabled="false"></asp:TextBox>
                </div>
            </div>
        </div>
        <center>
             <div style="padding-top: 20px; padding-bottom: 20px;">
                 <asp:Button runat="server" ID="btndv" Text="Đặt chỗ" CssClass="btn" OnClick="btndv_Click"></asp:Button>
                 <asp:Button runat="server" ID="btnHuy" Text="Hủy" CssClass="btn" OnClick="btnHuy_Click"></asp:Button>
             </div> 
        </center>
    </div>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="gd_datve" runat="server">
    <link href="../CSS/Datve.css" rel="stylesheet" />
    <asp:Label runat="server" CssClass="lblSapxep">Thông tin các chuyến xe</asp:Label>
    <div class="sapxep">
        <ul>
            <li>
                <asp:Label runat="server" CssClass="lblrange">Sắp xếp theo:</asp:Label></li>
            <li>
                <asp:LinkButton runat="server">Giờ sớm nhất</asp:LinkButton></li>
            <li>
                <asp:LinkButton runat="server">Giờ muộn nhật</asp:LinkButton></li>
            <li>
                <asp:LinkButton runat="server">Giá rẻ nhất</asp:LinkButton></li>
            <li>
                <asp:LinkButton runat="server">Giá đắt nhất</asp:LinkButton></li>
        </ul>
    </div>

    <asp:Label ID="a" runat="server" Text="" ForeColor="Red"></asp:Label>

    <asp:DataList Visible="true" runat="server" ID="dlDsChuyenxe" RepeatColumns="1" GridLines="Vertical" RepeatDirection="Vertical" CellPadding="2" BorderStyle="None" ItemStyle-BorderStyle="None" Width="100%">
        <ItemTemplate>
            <div id="gd_ct_dv" runat="server" style="border: 1px solid black; padding: 10px; border-radius: 10px;">
                <div class="gd_ct_dv_left" style="float: left;">
                    <img src="../img/xekhach2.jpg" alt="Hình ảnh nhà xe" style="width: 150px; height: 150px;" />
                </div>
                <div class="gd_ct_dv_right">
                    <div class="gd_ct_dv_right_1" style="float: left; padding-left: 20px;">
                        <div class="thongtin">
                            <asp:Label runat="server" Width="100px"><b>Nhà xe:</b></asp:Label>
                            <asp:Label ID="lblTennx" runat="server" Text='<%# Eval("tennx") %>' CssClass="lbl_ct_dv"></asp:Label>
                        </div>

                        <div class="thongtin">
                            <asp:Label ID="Label2" runat="server" Width="100px"><b>Chuyến xe:</b></asp:Label>
                            <asp:Label runat="server" ID="lblMacx" Text='<%# Eval("machuyenxe") %>' CssClass="lbl_ct_dv"></asp:Label>
                        </div>

                        <div class="thongtin">
                            <asp:Label ID="Label4" runat="server" Width="100px"><b>Giờ đi:</b></asp:Label>
                            <asp:Label ID="lblGiokh" runat="server" Text='<%# Eval("giokh") %>' CssClass="lbl_ct_dv"></asp:Label>
                        </div>

                        <div class="thongtin">
                            <asp:Label ID="Label6" runat="server" Width="100px"><b>Ghế trống:</b></asp:Label>
                            <asp:Label runat="server" ID="txtGhetrong" Text='<%# hien_ghetrong(Eval("machuyenxe").ToString()).ToString() %>' CssClass="txtghetrong" Height="30px" BorderStyle="None" Enabled="false" Width="50px"></asp:Label>
                        </div>
                    </div>
                    <div class="gd_ct_dv_right_2" style="display: inline-block; padding-left: 20px;">
                        <div class="thongtin">
                            <asp:Label ID="Label1" runat="server" Width="100px"><b>Tuyến xe:</b></asp:Label>
                            <asp:Label ID="lblTentx" runat="server" Text='<%# Eval("tentuyenxe") %>' CssClass="lbl_ct_dv"></asp:Label>
                        </div>
                        <div class="thongtin">
                            <asp:Label ID="Label3" runat="server" Width="100px"><b>Ngày đi:</b></asp:Label>
                            <asp:Label ID="lblNgaydi" runat="server" CssClass="lbl_ct_dv" Text='<%# String.Format("{0:dd/MM/yyyy}", Convert.ToDateTime( Eval("ngaydi").ToString())) %>'></asp:Label>
                        </div>
                        <div class="thongtin">
                            <asp:Label ID="Label5" runat="server" Width="100px"><b>Giờ đến:</b></asp:Label>
                            <asp:Label ID="lblGioden" runat="server" CssClass="lbl_ct_dv" Text='<%# Eval("gioden") %>'></asp:Label>
                        </div>
                        <div style="padding-top: 10px;">
                            <asp:Label ID="Label7" runat="server" Width="100px"></asp:Label>
                            <asp:LinkButton ID="btnDatve" runat="server" Text="Đặt vé" CssClass="btnDatve" OnClick="btnDatve_Click" CommandArgument='<%# Eval("matuyenxe") + ";" + Eval("machuyenxe") + ";" + Eval("Ngaydi") + ";" + Eval("giokh") + ";" + Eval("gioden") %>'></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            <br />
        </ItemTemplate>
    </asp:DataList>
</asp:Content>