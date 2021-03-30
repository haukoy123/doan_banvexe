using DoAn.cs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAn.NV.nvxe
{
    public partial class QLchuyendi : System.Web.UI.Page
    {
        cs.adminDAL admin = new cs.adminDAL();

        tblnx nxe = new tblnx();
        tbltk tk = new tbltk();
        tblnv nv = new tblnv();
        tblChuyenxe cx = new tblChuyenxe();
        tblKhachhang kh = new tblKhachhang();
        tblVexe vx = new tblVexe();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hien();

            }
        }
        protected void hien()
        {
            nv.Fk_manx = manx();
            string matk = admin.getmatk(Session["tendn"].ToString());
            DataTable dt = admin.ds_chuyenxe_nhaxe(nv);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (matk != dt.Rows[i]["FK_mataikhoan"].ToString())
                {
                    dt.Rows[i].Delete();
                }
            }
            dt.AcceptChanges();
            dschuyendi.DataSource = dt;
            dschuyendi.DataBind();
        }
        protected string manx()
        {
            string tendn = Session["tendn"].ToString();
            string a = "";
            DataTable tknv = admin.tk_nv_gmail(tendn);
            for (int i = 0; i < tknv.Rows.Count; i++)
            {
                if (tendn.Equals(tknv.Rows[i]["email"].ToString()))
                {
                    a = tknv.Rows[i]["FK_manx"].ToString();
                }
            }
            return a;
        }
        protected void dschuyendi_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dschuyendi.PageIndex = e.NewPageIndex;
            hien();
        }
        protected void grv_dsvechuyen_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grv_dsvechuyen.PageIndex = e.NewPageIndex;
            hien();
        }
        protected void chitiet_Click(object sender, EventArgs e)
        {
            string machuyen = (sender as LinkButton).CommandArgument.ToString();
            dsve_chuyen.Visible = true;
            allchuyendi.Visible = false;
            hiendsve(machuyen);

        }
        public void hiendsve(string machuyen)
        {
            DataTable dt = admin.get_cx_vx();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (machuyen != dt.Rows[i]["machuyenxe"].ToString())
                {
                    dt.Rows[i].Delete();
                }
            }
            dt.AcceptChanges();
            grv_dsvechuyen.DataSource = dt;
            grv_dsvechuyen.DataBind();
        }
        protected void tbloke_Click(object sender, EventArgs e)
        {
            dsve_chuyen.Visible = false;
            allchuyendi.Visible = true;
        }
        protected void xacnhanve_Click(object sender, EventArgs e)
        {
            string a = (sender as LinkButton).CommandArgument.ToString();

            string[] arg = new string[3];
            arg = a.Split(';');
            vx.mavx = arg[0];
            string trangthai = arg[1];
            cx.macx = arg[2];
            if (trangthai != "Đang đi")
            {
                Response.Write("<script>alert('Xác nhận thất bại.Chuyến xe khởi hàng mới được xác nhận vé!');</script>");
            }
            else
            {
                DataTable dt = admin.get_cx_vx();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (vx.mavx == dt.Rows[i]["mavexe"].ToString())
                    {
                        vx.diemden = dt.Rows[i]["diemden"].ToString();
                        vx.tenkh = dt.Rows[i]["tenkh"].ToString();
                        vx.sdt = dt.Rows[i]["sdt"].ToString();
                        vx.soghe = int.Parse(dt.Rows[i]["soghe"].ToString());
                        vx.tongtien = int.Parse(dt.Rows[i]["tongtien"].ToString());
                        vx.trangthai = "Đã đi";

                        if (admin.updateVexe(vx))
                        {
                            Response.Write("<script>alert('Xác nhận vé xe thành công!');</script>");
                        }
                        else Response.Write("<script>alert('Xác nhận vé xe thất bại!');</script>");
                    }
                }

            }
        }
    }
}