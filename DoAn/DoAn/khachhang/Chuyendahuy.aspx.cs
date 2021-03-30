using DoAn.cs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAn.khachhang
{
    public partial class Chuyendahuy : System.Web.UI.Page
    {
        cs.adminDAL admin = new cs.adminDAL();
        tblKhachhang kh = new tblKhachhang();
        tbltk tk = new tbltk();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hien();
            }
        }

        protected void hien()
        {
            string tt = "Đã hủy";
            kh.Makh = admin.getmakh(Session["tendn"].ToString());
            tk.Matk = int.Parse(admin.getmatk(Session["tendn"].ToString()));
            kh.Fk_matk = tk.Matk;

            DataTable dt = admin.get_chitiet_vx_kh(kh.Fk_matk);
            if (dt.Rows.Count == 0)
            {
                thongbao.Visible = true;
            }
            else
            {
                thongbao.Visible = false;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (tt != dt.Rows[i]["trangthai"].ToString() || kh.Fk_matk != int.Parse(dt.Rows[i]["FK_mataikhoan"].ToString()))
                    {
                        dt.Rows[i].Delete();
                    }
                }
            }
            dt.AcceptChanges();
            gr_chuyendahuy.DataSource = dt;
            gr_chuyendahuy.DataBind(); ;
        }

        protected void btnXong_Click(object sender, EventArgs e)
        {
            fChitiet.Visible = false;
        }
        protected void chitiet_Click(object sender, EventArgs e)
        {
            fChitiet.Visible = true;
            tk.Matk = int.Parse(admin.getmatk(Session["tendn"].ToString()));
            kh.Fk_matk = tk.Matk;

            DataTable dt = admin.get_chitiet_vx_kh(kh.Fk_matk);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txtbsx.Text = dt.Rows[i]["biensoxe"].ToString();
                txtGiokh.Text = dt.Rows[i]["giokh"].ToString();
                txtTinhdi.Text = dt.Rows[i]["tinhdi"].ToString();
                txtTgdv.Text = String.Format("{0:dd-MM-yyyy}", Convert.ToDateTime(dt.Rows[i]["thoigiandatve"].ToString()));
                txtGioden.Text = dt.Rows[i]["gioden"].ToString();
                txtDiemden.Text = dt.Rows[i]["diemden"].ToString();
            }
        }
    }
}