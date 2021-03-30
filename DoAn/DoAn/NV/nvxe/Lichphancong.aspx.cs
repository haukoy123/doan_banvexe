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
    public partial class Lichphancong : System.Web.UI.Page
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
                if (matk != dt.Rows[i]["FK_mataikhoan"].ToString()
                    //||
                    // Convert.ToDateTime(dt.Rows[i]["Ngaydi"].ToString())<DateTime.Now
                    || dt.Rows[i]["trangthai"].ToString() == "Hủy"
                    || dt.Rows[i]["trangthai"].ToString() == "Hoàn thành")
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

        protected void chitiet_Click(object sender, EventArgs e)
        {
            string machuyen = (sender as LinkButton).CommandArgument.ToString();
            dsve_chuyen.Visible = true;
            chuyendi.Visible = false;
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

        protected void grv_dsvechuyen_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grv_dsvechuyen.PageIndex = e.NewPageIndex;
            hien();
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

        protected void tbloke_Click(object sender, EventArgs e)
        {
            dsve_chuyen.Visible = false;
            chuyendi.Visible = true;
        }

        protected void xacnhankh_Click(object sender, EventArgs e)
        {
            string machuyen = (sender as LinkButton).CommandArgument.ToString();
            string[] arg = new string[3];
            arg = machuyen.Split(';');
            string ngaydi = arg[0];
            string giokh = arg[1];
            cx.macx = arg[2];
            DateTime ngaydi1 = Convert.ToDateTime(ngaydi);
            DateTime giokh2 = Convert.ToDateTime(giokh);
            DateTime tgkh = new DateTime(ngaydi1.Year, ngaydi1.Month, ngaydi1.Day, giokh2.Hour, giokh2.Minute, giokh2.Millisecond);

            DataTable dt = admin.tt_chuyenxe();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (cx.macx == dt.Rows[i]["machuyenxe"].ToString())
                {
                    cx.Ngaydi = Convert.ToDateTime(dt.Rows[i]["Ngaydi"].ToString());
                }
            }
            if (tgkh < DateTime.Now)
            {
                cx.trangthai = "Đang đi";

                if (admin.update_cx(cx))
                {
                    Response.Write("<script>alert('Xác nhận khởi hành chuyến xe thành công!');</script>");
                }
                else Response.Write("<script>alert('Xác nhận hởi hành thất bại!');</script>");
            }
            else Response.Write("<script>alert('Xác nhận thất bại.Chưa đến thời gian khởi hành!');</script>");
        }
        
        protected void xacnhanht_Click(object sender, EventArgs e)
        {
            cx.macx = (sender as LinkButton).CommandArgument.ToString();
            int ktra1 = 1;
            int ktra2 = 1;
            DataTable dsve = admin.get_cx_vx();
            for (int j = 0; j < dsve.Rows.Count; j++)
            {
                if (cx.macx == dsve.Rows[j]["machuyenxe"].ToString() && dsve.Rows[j]["tt_ve"].ToString() == "Đã đặt")
                {
                    vx.mavx = dsve.Rows[j]["mavexe"].ToString();
                    vx.diemden = dsve.Rows[j]["diemden"].ToString();
                    vx.tenkh = dsve.Rows[j]["tenkh"].ToString();
                    vx.sdt = dsve.Rows[j]["sdt"].ToString();
                    vx.soghe = int.Parse(dsve.Rows[j]["soghe"].ToString());
                    vx.tongtien = int.Parse(dsve.Rows[j]["tongtien"].ToString());
                    vx.trangthai = "Hủy";
                    ktra1++;
                    if (admin.updateVexe(vx))
                    {
                        ktra2++;
                    }
                }
            }
            if (ktra1 == ktra2)
            {
                DataTable dt = admin.tt_chuyenxe();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (cx.macx == dt.Rows[i]["machuyenxe"].ToString())
                    {
                        cx.Ngaydi = Convert.ToDateTime(dt.Rows[i]["Ngaydi"].ToString());
                    }
                }
                cx.trangthai = "Hoàn thành";
                if (admin.update_cx(cx))
                {
                    Response.Write("<script>alert('Đã xác nhận khởi hành chuyến xe.');</script>");
                }
                else Response.Write("<script>alert('Xác nhận khởi hành thất bại');</script>");
            }
            else Response.Write("<script>alert('Xác nhận khởi hành thất bại');</script>");
            
        }

    }
}