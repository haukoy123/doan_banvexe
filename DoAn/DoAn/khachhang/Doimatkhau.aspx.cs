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
            tk.Matk = int.Parse(Session["Matk"].ToString());
            tk.Tendn = Session["Tendn"].ToString();

        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            Response.Redirect("QLkhachhang.aspx");
        }
    }
}