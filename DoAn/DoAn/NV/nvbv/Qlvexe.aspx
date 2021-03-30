<%@ Page Title="" Language="C#" MasterPageFile="~/NV/nvbv/nvbanve.Master" AutoEventWireup="true" CodeBehind="Qlvexe.aspx.cs" Inherits="DoAn.NV.nvbv.Qlvexe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Quản Lý Thông Tin Vé
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="link" runat="server">
    <link href="../../CSS/admin_qlnv.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="head2x" runat="server">
    <div id="menuhead" runat="server">
        <div class="tb_tk">
            <asp:Label ID="Label30" runat="server" Text="Loại Vé"></asp:Label>
            <asp:DropDownList ID="ddlloaive" runat="server" Font-Size="15px" Height="30px" Width="150px">
            <asp:ListItem Value ="nx">Nhà Xe Đặt</asp:ListItem>
            <asp:ListItem Value ="kh" Selected="True">Khách Đặt</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="tb_tk">
            <asp:Label ID="Label31" runat="server" Text="Số Điện Thoại"></asp:Label>
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
    <div id="hienttnv" visible="false" runat="server" style="margin-left: 270px;">
        <div class="vien_ttnx_nv" style="height: auto; position: fixed;">
            <div style="text-align: center; font-weight: bold;">
                Nhân Viên: 
            <asp:Label ID="lbl_manv" runat="server" Text="" Font-Size="18px"></asp:Label>
            </div>
            <div class="css_nhapnv">
                <asp:Label ID="Label4" runat="server" Text="Tên nhân viên"></asp:Label>
                <br />
                <asp:TextBox ID="tb_ten_nv" runat="server" CssClass="css_intput" Enabled="false"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label5" runat="server" Text="Ngày sinh"></asp:Label>
                <br />
                <asp:TextBox ID="tb_ns_nv" runat="server" Enabled="false" CssClass="css_intput" TextMode="Date" Height="25px"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label6" runat="server" Text="Giới tính"></asp:Label>
                <br />
                <asp:RadioButtonList ID="rd_gt_nv" runat="server" Height="29px" Enabled="false" RepeatDirection="Horizontal" Width="200px" EnableTheming="True" Font-Overline="False">
                    <asp:ListItem Value="0" Text="Nam" Selected="True" />
                    <asp:ListItem Value="1" Text="Nữ" />
                </asp:RadioButtonList>
                <br />
                <asp:Label ID="Label13" runat="server" Text="Điện thoại" Enabled="false"></asp:Label>
                <br />
                <asp:TextBox ID="tb_dt_nv" runat="server" CssClass="css_intput" Enabled="false"></asp:TextBox>
            </div>
            <div class="css_nhapnv">
                <asp:Label ID="Label10" runat="server" Text="Địa chỉ"></asp:Label>
                <br />
                <asp:TextBox ID="tb_dc_nv" runat="server" CssClass="css_intput" Enabled="false"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label11" runat="server" Text="Email"></asp:Label>
                <br />
                <asp:TextBox ID="tb_email_nv" runat="server" CssClass="css_intput" Enabled="false"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label12" runat="server" Text="CMT ND"></asp:Label>
                <br />
                <asp:TextBox ID="tb_cmt_nv" runat="server" CssClass="css_intput" Enabled="false"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label14" runat="server" Text="Bộ phận"></asp:Label>
                <br />
                <asp:TextBox ID="tb_bophan_nv" runat="server" CssClass="css_intput" Enabled="false"></asp:TextBox>

                <div class="css_intput" style="text-align: right; margin-top: 20px;">
                    <asp:LinkButton ID="btnnokenv" runat="server" CssClass="btn" OnClick="lbt_thoat_Click">OK</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
    <div id="hienttcx" visible="false" runat="server" style="margin-left: 270px;">
        <div class="vien_ttnx_nv" style="height: auto; position: fixed;">
            <div style="text-align: center; font-weight: bold;">
                Mã Chuyến Xe: 
            <asp:Label ID="lblmachuyen" runat="server" Text="" Font-Size="18px"></asp:Label>
            </div>
            <div class="css_nhapnv">
                <asp:Label ID="Label2" runat="server" Text="Chuyến Xe"></asp:Label>
                <br />
                <asp:TextBox ID="tb_cx" runat="server" CssClass="css_intput"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label3" runat="server" Text="NV Phụ Trách"></asp:Label>
                <br />
                <asp:TextBox ID="tb_nvptr" runat="server" CssClass="css_intput"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label7" runat="server" Text="Ngày Đi"></asp:Label>
                <br />
                <asp:TextBox ID="tb_ngaydi" runat="server" TextMode="Date" CssClass="css_intput"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label8" runat="server" Text="Tên Tuyến Xe"></asp:Label>
                <br />
                <asp:TextBox ID="tb_tentx" runat="server" CssClass="css_intput"></asp:TextBox>
            </div>
            <div class="css_nhapnv">
                <asp:Label ID="Label25" runat="server" Text="Khởi Hành"></asp:Label>
                <br />
                <asp:TextBox ID="tb_tinhdi" runat="server" CssClass="css_intput"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label26" runat="server" Text="Kết Thúc"></asp:Label>
                <br />
                <asp:TextBox ID="tb_tinhden" runat="server" CssClass="css_intput"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label27" runat="server" Text="Thời Gian Khởi Hành"></asp:Label>
                <br />
                <asp:TextBox ID="tb_tgkh" runat="server" CssClass="css_intput"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label28" runat="server" Text="Thời Gian Kết Thúc"></asp:Label>
                <br />
                <asp:TextBox ID="tb_tgkt" runat="server" CssClass="css_intput"></asp:TextBox>
            </div>
            <div class="css_nhapnv">
                <asp:Label ID="Label9" runat="server" Text="Biển Số Xe"></asp:Label>
                <br />
                <asp:TextBox ID="tb_bsx" runat="server" CssClass="css_intput"></asp:TextBox>
                <br />
                <br />
                <div>
                    <div style="float: left; display: inline-block">
                        <asp:Label ID="Label15" runat="server" Text="Loại Xe"></asp:Label>
                        <br />
                        <asp:TextBox ID="tb_loaixe" runat="server" CssClass="css_ghe_mau"></asp:TextBox>
                    </div>

                    <div style="display: inline-block; margin-left: 32px">
                        <asp:Label ID="Label33" runat="server" Text="Màu Xe"></asp:Label>
                        <br />
                        <asp:TextBox ID="tb_mauxe" runat="server" CssClass="css_ghe_mau"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div>
                    <div style="float: left; display: inline-block">
                        <asp:Label ID="Label16" runat="server" Text="Số Ghế"></asp:Label>
                        <br />
                        <asp:TextBox ID="tb_soghe" runat="server" CssClass="css_ghe_mau"></asp:TextBox>
                    </div>


                    <div style="display: inline-block; margin-left: 32px">
                        <asp:Label ID="Label17" runat="server" Text="Ghế Trống"></asp:Label>
                        <br />
                        <asp:TextBox ID="tb_ghetrong" runat="server" CssClass="css_ghe_mau"></asp:TextBox>
                    </div>
                </div>
                <br />
                <asp:Label ID="Label29" runat="server" Text="Lịch Trình"></asp:Label>
                <br />
                <asp:DropDownList ID="ddllichtrinh" runat="server" Font-Size="15px" Height="29px" Width="250px">
                </asp:DropDownList>
                <br />
                <br />
                <div class="css_intput" style="text-align: right; margin-top: 20px;">
                    <asp:LinkButton ID="btnnokecx" runat="server" CssClass="btn" OnClick="lbt_thoat_Click">OK</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
    <div id="hientttkdat" visible="false" runat="server" style="margin-left: 270px;">
        <div class="vien_ttnx_nv" style="height: auto; position: fixed;">
            <div style="text-align: center; font-weight: bold;">
                Mã Tài Khoản
            <asp:Label ID="lbmatkkh" runat="server" Text="" Font-Size="18px"></asp:Label>
            </div>
            <div class="css_nhapnv">
                <asp:Label ID="Label1" runat="server" Text="Mã Khách Hàng"></asp:Label>
                <br />
                <asp:TextBox ID="tb_makh" runat="server" CssClass="css_intput" Enabled="false"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label18" runat="server" Text="Tên Khách Hàng"></asp:Label>
                <br />
                <asp:TextBox ID="tb_tenkh" runat="server" CssClass="css_intput" Enabled="false"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label19" runat="server" Text="Ngày sinh"></asp:Label>
                <br />
                <asp:TextBox ID="tb_ngaysinh" runat="server" Enabled="false" CssClass="css_intput" TextMode="Date" Height="25px"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label20" runat="server" Text="Giới tính"></asp:Label>
                <br />
                <asp:RadioButtonList ID="rd_gtkh" runat="server" Height="29px" Enabled="false" RepeatDirection="Horizontal" Width="200px" EnableTheming="True" Font-Overline="False">
                    <asp:ListItem Value="0" Text="Nam" Selected="True" />
                    <asp:ListItem Value="1" Text="Nữ" />
                </asp:RadioButtonList>
            </div>
            <div class="css_nhapnv">
                <asp:Label ID="Label21" runat="server" Text="Điện thoại" Enabled="false"></asp:Label>
                <br />
                <asp:TextBox ID="tb_dienthoaikh" runat="server" CssClass="css_intput" Enabled="false"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label22" runat="server" Text="Địa chỉ"></asp:Label>
                <br />
                <asp:TextBox ID="tb_dckh" runat="server" CssClass="css_intput" Enabled="false"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label23" runat="server" Text="Email"></asp:Label>
                <br />
                <asp:TextBox ID="tb_emailkh" runat="server" CssClass="css_intput" Enabled="false"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label24" runat="server" Text="CMT ND"></asp:Label>
                <br />
                <asp:TextBox ID="tb_cmtkh" runat="server" CssClass="css_intput" Enabled="false"></asp:TextBox>

                <div class="css_intput" style="text-align: right; margin-top: 20px;">
                    <asp:LinkButton ID="btnnoketk" runat="server" CssClass="btn" OnClick="lbt_thoat_Click">OK</asp:LinkButton>
                </div>
            </div>

        </div>
    </div>
    <div id="themvexe" visible="false" runat="server" style="margin-left: 200px; position: fixed;">
        <div class="vien_ttnx_nv" style="height: auto; margin: 0px;">
            <div style="text-align: center; font-weight: bold;">
                Vé Xe:
                <asp:Label ID="lbmave" runat="server" Text=""></asp:Label>
            </div>
            <div class="css_nhapnv">
                <asp:Label ID="Label34" runat="server" Text="Tên Khách Hàng"></asp:Label>
                <br />
                <asp:TextBox ID="tbdatve_tenkh" runat="server" CssClass="css_intput"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label35" runat="server" Text="Số Điện Thoại"></asp:Label>
                <br />
                <asp:TextBox ID="tbdatve_sdt" runat="server" CssClass="css_intput"></asp:TextBox>
                <br />
                <br />
                <div>
                    <div style="float: left; display: inline-block">
                        <asp:Label ID="Label44" runat="server" Text="Số Ghế Đặt"></asp:Label>
                        <br />
                        <asp:TextBox ID="tbdatve_soghe" AutoPostBack="true" OnTextChanged="tbdatve_soghe_TextChanged" TextMode="Number" runat="server" CssClass="css_ghe_mau"></asp:TextBox>
                    </div>

                    <div style="display: inline-block; margin-left: 32px">
                        <asp:Label ID="Label46" runat="server" Text="Trạng Thái"></asp:Label>
                        <br />
                        <asp:DropDownList ID="ddltrangthai" runat="server" Height="30px" Width="108px">
                            <asp:ListItem Selected="True">Đã đặt</asp:ListItem>
                            <asp:ListItem >Đã đi</asp:ListItem>
                            <asp:ListItem >Hủy</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <br />

                <asp:Label ID="Label32" runat="server" Text="Điểm Dừng"></asp:Label>
                <br />
                <asp:DropDownList ID="ddlchondiemdung" OnSelectedIndexChanged="ddlchondiemdung_SelectedIndexChanged" AutoPostBack="true" runat="server" Font-Size="15px" Height="29px" Width="248px">
                </asp:DropDownList>
            </div>
            <div class="css_nhapnv">
                <asp:Label ID="Label38" runat="server" Text="Tên Chuyến Xe"></asp:Label>
                <br />
                <asp:TextBox ID="tbdatve_tenchuyen" Enabled="false" runat="server" CssClass="css_intput"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label39" runat="server" Text="Tên Tuyến"></asp:Label>
                <br />
                <asp:TextBox ID="tbdatve_tentuyen" Enabled="false" runat="server" CssClass="css_intput"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label40" runat="server" Text="Ngày Đi"></asp:Label>
                <br />
                <asp:TextBox ID="tbdatve_ngaydi" Enabled="false" runat="server" TextMode="Date" CssClass="css_intput" Height="25px"></asp:TextBox>
                <br />
                <br />
                <div>
                    <div style="float: left; display: inline-block">
                        <asp:Label ID="Label37" runat="server" Text="Giờ Khởi Hành"></asp:Label>
                        <br />
                        <asp:TextBox ID="tbdatve_giokh" Enabled="false" runat="server" TextMode="Time" CssClass="css_ghe_mau" Height="25px"></asp:TextBox>
                    </div>

                    <div style="display: inline-block; margin-left: 32px">
                        <asp:Label ID="Label41" runat="server" Text="Giờ Kết Thúc"></asp:Label>
                        <br />
                        <asp:TextBox ID="tbdatve_tgkt" Enabled="false" TextMode="Time" runat="server" CssClass="css_ghe_mau" Height="25px"></asp:TextBox>
                    </div>
                </div>
                <br />
                <asp:Label ID="Label36" runat="server" Text="Tổng Tiền"></asp:Label>
                <asp:TextBox ID="tb_tongtien" runat="server" Width="166px" Font-Size="19px" Height="25px"></asp:TextBox>
            </div>

        </div>
        <div class="vien_ttnx_nv" style="height: auto; margin: 0px;">
            <div style="text-align: center; font-weight: bold;">
                Tìm Chuyến
            </div>

            <div class="css_nhapnv">
                <asp:Label ID="Label42" runat="server" Text="Ngày Đi"></asp:Label>
                <br />
                <asp:TextBox ID="tbtimchuyen_ngaydi" runat="server" TextMode="Date" CssClass="css_intput" Height="25px"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label43" runat="server" Text="Điểm Đi - Điểm Đến"></asp:Label>

                <div>
                    <div style="float: left; display: inline-block">
                        <asp:TextBox ID="tbtimchuyen_diemdi" runat="server" CssClass="css_ghe_mau"></asp:TextBox>
                    </div>
                    <div style="display: inline-block; margin: 0 5px;">Đến</div>
                    <div style="display: inline-block;">
                        <asp:TextBox ID="tbtimchuyen_diemden" runat="server" CssClass="css_ghe_mau"></asp:TextBox>
                    </div>
                </div>
                <br />
                <asp:Label ID="Label45" runat="server" Text="Khoảng Thời Gian đi"></asp:Label>
                <div>
                    <div style="float: left; display: inline-block">
                        <asp:TextBox ID="tbtimchuyen_tg1" runat="server" TextMode="Time" CssClass="css_ghe_mau" Height="25px"></asp:TextBox>
                    </div>
                    <div style="display: inline-block; margin: 0 5px;">Đến</div>
                    <div style="display: inline-block;">

                        <asp:TextBox ID="tbtimchuyen_tg2" runat="server" TextMode="Time" CssClass="css_ghe_mau" Height="25px"></asp:TextBox>
                    </div>
                </div>
                <br />
                <asp:Label ID="Label47" runat="server" Text="Chuyến Xe"></asp:Label>
                <br />
                <asp:DropDownList ID="ddl_chuyenxe" OnSelectedIndexChanged="ddl_chuyenxe_SelectedIndexChanged" AutoPostBack="true" runat="server" Font-Size="15px" Height="29px" Width="250px">
                </asp:DropDownList>
                <br />
                <br />

                <div style="text-align: center; margin: 7px 0px;">
                    <asp:LinkButton ID="btn_timchuyen" CssClass="tim_cx" ForeColor="White" runat="server" OnClick="btn_timchuyen_Click"><i class="fas fa-search" ></i>Tìm</asp:LinkButton>
                </div>
            </div>
        </div>
        <div class="css_intput" style="float: right; margin-top: 20px; display: inline-block; margin-right: 34px;">
            <asp:LinkButton ID="lbt_luu" runat="server" CssClass="btn" OnClick="lbt_luu_Click">Lưu</asp:LinkButton>
            <asp:LinkButton ID="lbt_thoat" runat="server" CssClass="btn" OnClick="lbt_thoat_Click">Thoát</asp:LinkButton>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="noidung" runat="server">
    <div id="ds_nhanvien" visible="true" runat="server" style="text-align: center;">
        <asp:Label ID="lb_kdl" runat="server" Text=""></asp:Label>
        <asp:GridView ID="dsttve" PageSize="6" runat="server" AllowPaging="true"
            OnPageIndexChanging="dsttve_PageIndexChanging" AutoGenerateColumns="False"
            BorderColor="#CCCCCC" Font-Size="Medium" CellPadding="4" Font-Names="Calibri"
            Width="100%" BackColor="white" BorderStyle="Solid" BorderWidth="1px">
            <AlternatingRowStyle BorderColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:PlaceHolder runat="server" Visible='<%# DateTime.Now < Convert.ToDateTime(Eval("Ngaydi").ToString()) %>'>
                            <asp:LinkButton ID="sua" runat="server" CommandArgument='<%#Eval("mavexe") + ";" +Eval("mataikhoan")+";" +Eval("machuyenxe")+";"+Eval("manx") +";"+Eval("matuyenxe")%>' OnClick="sua_click">Sửa</asp:LinkButton>
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

                <asp:BoundField DataField="mavexe" HeaderText="Mã Vé" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>

                <asp:TemplateField HeaderText="Chuyến Xe" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnchuyenxe" runat="server" CommandArgument='<%#Eval("mavexe") %>' OnClick="btnchuyenxe_click" Text='<%#Eval("tenchuyenxe") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Nhân Viên" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnnhanvien" runat="server" CommandArgument='<%#Eval("manv") %>' OnClick="btnnhanvien_click" Text='<%#Eval("tennv") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tài Khoản Đặt" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton ID="mataikhoan" runat="server" CommandArgument='<%#Eval("makh") %>' OnClick="btntaikhoan_click" Text='<%#Eval("mataikhoan") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>

                <asp:BoundField DataField="tenKhdi" HeaderText="Khách đi" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="sdtDatve" HeaderText="SĐT Đặt Vé" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="thoigiandatve" ItemStyle-Width="100px" HeaderText="Thời Gian Đặt" ItemStyle-HorizontalAlign="Center">
                    <%--DataFormatString="{0:dd/MM/yyyy}"--%>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Ngaydi" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày Đi" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="diemden" HeaderText="Điểm Đến" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="soghedat" HeaderText="Số Ghế" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="tongtien" HeaderText="Tổng Tiền" ItemStyle-HorizontalAlign="Center">
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
