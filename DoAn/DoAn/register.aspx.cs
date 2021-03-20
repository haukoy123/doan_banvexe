using DoAn.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAn
{
    public partial class register : System.Web.UI.Page
    {
        cs.adminDAL admin = new cs.adminDAL();
        tblKhachhang kh = new tblKhachhang();
        tbltk tk = new tbltk();
        protected void Page_Load(object sender, EventArgs e)
        {
            dangky.Visible = true;
            dangkychitiet.Visible = false;
        }

        protected void btnTieptuc_Click(object sender, EventArgs e)
        {
            dangky.Visible = false;
            dangkychitiet.Visible = true;
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/index.aspx");
        }

        protected void btnHuydk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/index.aspx");
        }

        protected void btnDangky_Click1(object sender, EventArgs e)
        {
            tk.Fk_maquyen = "Q00003";
            tk.Tendn = txtEmail.Text;
            tk.Matkhau = txtMatkhau.Text;
            tk.Trangthai = "Mở";

            kh.tenkh = txtTenKH.Text;
            kh.ngaysinh = DateTime.Parse(txtNgaysinh.Text);
            kh.gioitinh = double.Parse(rd_gt.SelectedValue.ToString());
            kh.sdt = txtSDT.Text;
            kh.diachi = txtDiachi.Text;
            kh.email = txtEmail.Text;
            kh.cmnd = txtCmnd.Text;

            string ktra_tk = admin.getmatk(txtEmail.Text);
            if (ktra_tk != "")
            {
                Response.Write("<script>alert('Email đã tồn tại, yêu cầu nhập email khác!');</script>");
                txtEmail.Text = "";
                txtEmail.Focus();
            }
            else
            {
                if (admin.themtk(tk))
                {
                    kh.Fk_matk = int.Parse(admin.getmatk(tk.Tendn));
                    kh.Fk_matk = tk.Matk;
                    if (admin.themkh(kh))
                    {
                        Response.Write("<script>alert('Đăng ký thành công!');</script>");
                        Response.Redirect("~/login.aspx");
                    }
                    else Response.Write("<script>alert('Đăng ký thất bại');</script>");
                }
                else Response.Write("<script>alert('Đăng ký tài khoản thất bại!');</script>");
            }
        }
    }
}