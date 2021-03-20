using DoAn.cs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAn.admin
{
    public partial class QLtaikhoan : System.Web.UI.Page
    {
        cs.adminDAL admin = new cs.adminDAL();

        tblnx nxe = new tblnx();
        tbltk tk = new tbltk();
        tblnv nv = new tblnv();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hien();
                hien_ddl_quyen();
            }
        }

        protected void hien()
        {
            DataTable dt = admin.get_dstk();
            gv_dstk.DataSource = dt;
            gv_dstk.DataBind();
        }
        protected void hien_ddl_quyen()
        {
            ddl_quyen.Items.Clear();
            ddl_quyen.Items.Add(new ListItem("Tất cả", ""));
            ddl_quyen.Items.FindByValue("").Selected = true;
            DataTable dt = admin.get_quyen();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddl_quyen.Items.Add(new ListItem(dt.Rows[i]["tenquyen"].ToString(), dt.Rows[i]["maquyen"].ToString()));
            }
        }

        protected void btntimkiem_tk_Click(object sender, EventArgs e)
        {
            tk.Fk_maquyen = ddl_quyen.SelectedValue.ToString();
            tk.Tendn = tb_tk_tendn.Text;
            DataTable dstk = admin.timkiem_tk(tk);
            if (dstk.Rows.Count == 0)
            {
                lb_kdl.Text = "Không có dữ liệu!";
                gv_dstk.DataSource = dstk;
                gv_dstk.DataBind();
            }
            else
            {
                lb_kdl.Visible = false;
                gv_dstk.DataSource = dstk;
                gv_dstk.DataBind();
            }

        }

        protected void mo_click(object sender, EventArgs e)
        {
            mo_khoa_tk("Mở", sender);
        }

        protected void khoa_click(object sender, EventArgs e)
        {
            mo_khoa_tk("Khóa", sender);
            //Response.Write("<script>alert('" + tk.Matk + ";" + tk.Tendn + "');</script>");
        }

        public void mo_khoa_tk(string trangthai, object sender)
        {
            DataTable dstk = admin.get_dstk();
            tk.Matk = int.Parse((sender as LinkButton).CommandArgument.ToString());
            for (int i = 0; i < dstk.Rows.Count; i++)
            {
                if (tk.Matk == int.Parse(dstk.Rows[i]["mataikhoan"].ToString()))
                {
                    tk.Tendn = dstk.Rows[i]["tendn"].ToString();
                    tk.Fk_maquyen = dstk.Rows[i]["Fk_maquyen"].ToString();
                    tk.Matkhau = dstk.Rows[i]["matkhau"].ToString();
                }
            }
            tk.Trangthai = trangthai;
            if (admin.updateTk(tk))
            {
                Response.Write("<script>alert('" + trangthai + " tài khoản thành công!');</script>");
            }
            else Response.Write("<script>alert('" + trangthai + " tài khoản thất bại!');</script>");
        }

        protected void gv_dstk_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_dstk.PageIndex = e.NewPageIndex;
            hien();
        }

    }
}