using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAn.khachhang
{
    public partial class Khachhang : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tendn"].ToString().Equals(""))
            {
                btndndk.Visible = true;
                btnuser.Visible = false;
            }
            else
            {
                btndndk.Visible = false;
                btnuser.Visible = true;
            }
        }

        protected void linkbtn_Click(object sender, EventArgs e)
        {
            Session["tendn"] = "";
            Session["quyen"] = "";
            Response.Redirect("~/index.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        protected void btnDoimk_Click(object sender, EventArgs e)
        {
            Response.Redirect("../khachhang/Doimatkhau.aspx");
        }

        protected void btnNhanxe_Click(object sender, EventArgs e)
        {
            Response.Redirect("../khachhang/Nhanxet.aspx");
        }

        protected void btnVecuatoi_Click(object sender, EventArgs e)
        {
            Response.Redirect("../khachhang/Vecuatoi.aspx");
        }

        protected void btnQLKH_Click(object sender, EventArgs e)
        {
            Response.Redirect("../khachhang/QLkhachhang.aspx");
        }
    }
}