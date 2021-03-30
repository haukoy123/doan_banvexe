using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAn.NV.nvbv
{
    public partial class nvbanve : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tendn"].ToString().Equals(""))
            {
                btndangnhap.Visible = true;
                btndangxuat.Visible = false;
                lbtendn.Visible = false;
            }
            else
            {
                btndangnhap.Visible = false;
                btndangxuat.Visible = true;
                lbtendn.Visible = true;
                lbtendn.Text = "Xin chào," + Session["tendn"].ToString() + " /";
            }
        }

        protected void btndangxuat_Click(object sender, EventArgs e)
        {
            Session["tendn"] = "";
            Session["quyen"] = "";
            Response.Redirect("~/index.aspx");
        }

        protected void btndangnhap_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/login.aspx");
        }
    }
}