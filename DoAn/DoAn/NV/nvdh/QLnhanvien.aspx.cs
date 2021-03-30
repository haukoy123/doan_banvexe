using DoAn.cs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAn.NV.nvdh
{
    public partial class QLnhanvien : System.Web.UI.Page
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
                //hien_ddl_dsnhaxe();
            }
        }
        protected DataTable dsnv_nx()
        {
            string manxe = manx();
            DataTable dt = admin.getAll_nv_tk_nx();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (manxe != dt.Rows[i]["manx"].ToString())
                {
                    dt.Rows[i].Delete();
                }
            }

            dt.AcceptChanges();
            return dt;
        }
        protected void hien()
        {
            DataTable dt = dsnv_nx();
            grd_dsnv.DataSource = dt;
            grd_dsnv.DataBind();
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
        protected void gv_dsnv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_dsnv.PageIndex = e.NewPageIndex;
            hien();
        }

        protected void lbt_luu_Click(object sender, EventArgs e)
        {
            tk.Fk_maquyen = ddl_quyen.SelectedValue.ToString();
            tk.Tendn = tb_tendn_tk.Text;
            tk.Matkhau = tb_mk_tk.Text;
            tk.Trangthai = ddl_tt_taikhoan.SelectedItem.ToString();

            nv.Tennv = tb_ten_nv.Text;
            nv.Fk_manx = manx();
            nv.Ngaysinh = DateTime.Parse(tb_ns_nv.Text);

            nv.Gioitinh = double.Parse(rd_gt_nv.SelectedValue.ToString());
            nv.Sdt = tb_dt_nv.Text;
            nv.Diachi = tb_dc_nv.Text;
            nv.Email = tb_email_nv.Text;
            nv.Bophan = tb_bophan_nv.Text;
            nv.Cmt = tb_cmt_nv.Text;

            string ktra_tk = admin.getmatk(tk.Tendn);
            if (ktra_tk != "")
            {
                Response.Write("<script>alert('Tên đăng nhập đã tồn tại, yêu cầu nhập tên khác!');</script>");
                tb_tendn_tk.Text = "";
                tb_tendn_tk.Focus();
            }
            else
            {
                if (admin.themtk(tk))
                {
                    nv.Fk_matk = int.Parse(admin.getmatk(tb_tendn_tk.Text));
                    if (admin.themnv(nv))
                    {
                        Response.Write("<script>alert('Thêm thành công!');</script>");
                        tb_null();
                        hien_them.Visible = false;
                    }
                    else Response.Write("<script>alert('Thêm thất bại');</script>");
                }
                else Response.Write("<script>alert('Thêm tài khoản thất bại!');</script>");
            }
        }

        protected void btnthem_Click(object sender, EventArgs e)
        {
            hien_them.Visible = true;

            
            }

        
        protected void btntimkiem_Click(object sender, EventArgs e)
        {
        }
        protected void mo_click(object sender, EventArgs e)
        {
            mo_khoa_tk("Mở", sender);
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

        protected void khoa_click(object sender, EventArgs e)
        {
            mo_khoa_tk("Khóa", sender);
            //Response.Write("<script>alert('" + tk.Matk + ";" + tk.Tendn + "');</script>");
        }

        protected void tb_tendn_tk_TextChanged(object sender, EventArgs e)
        {
            tb_email_nv.Text = tb_tendn_tk.Text;
        }

        protected void ddl_quyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_bophan_nv.Text = ddl_quyen.SelectedItem.ToString();

        }

        protected void lbt_thoat_Click(object sender, EventArgs e)
        {
            hien_them.Visible = false;
            tb_null();
        }
        public void tb_null()
        {
            tb_mk_tk.Text = "";
            tb_tendn_tk.Text = "";
            tb_bophan_nv.Text = "";
            tb_cmt_nv.Text = "";
            tb_dc_nv.Text = "";
            tb_dt_nv.Text = "";
            tb_email_nv.Text = "";
            tb_ns_nv.Text = "";
            tb_ten_nv.Text = "";
        }

    }
}