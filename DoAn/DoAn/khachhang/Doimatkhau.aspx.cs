using DoAn.cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAn.khachhang
{
    public partial class Doimatkhau : System.Web.UI.Page
    {
        cs.adminDAL admin = new cs.adminDAL();
        tbltk tk = new tbltk();
        tblKhachhang kh = new tblKhachhang();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnXacnhan_Click(object sender, EventArgs e)
        {
            tk.Matk = int.Parse(admin.getmatk(Session["tendn"].ToString()));
            tk.Tendn = Session["Tendn"].ToString();
            tk.Fk_maquyen = Session["quyen"].ToString();
            tk.Trangthai = Session["them_tt"].ToString();
            tk.Matkhau = txtMKmoi.Text;
            if (admin.updateTk(tk))
            {
                Response.Write("<script>alert('Thay đổi mật khẩu thành công!');</script>");
            }
            else
            {
                Response.Write("<script>alert('Thay đổi mật khẩu không thành công!');</script>");
            }
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            Response.Redirect("../khachhang/QLkhachhang.aspx");
        }
    }
}