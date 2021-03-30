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
    public partial class QLxe : System.Web.UI.Page
    {
        cs.adminDAL admin = new cs.adminDAL();

        tblnx nxe = new tblnx();
        tbltk tk = new tbltk();
        tblnv nv = new tblnv();
        tblChuyenxe cx = new tblChuyenxe();
        tblnx_tx nx_tx = new tblnx_tx();
        tblXe xe = new tblXe();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hien();

            }
        }

        protected void hien()
        {
            nxe.Manx = manx();
            DataTable dt = admin.dsxe_nhaxe(nxe);
            grv_dsxe.DataSource = dt;
            grv_dsxe.DataBind();
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

        protected void btnthem_Click(object sender, EventArgs e)
        {
            Session["them_tt"] = "them_click";
            //xe.Fk_manv = 
            hien_ddlnvlaixe();
            anhientb(true);
            vohieuhoa(true, false, false, false);
        }
        protected void vohieuhoa(Boolean Them, Boolean grid,
           Boolean btnThem, Boolean btnTimkiem)
        {
            hien_them.Visible = Them;
            grv_dsxe.Enabled = grid;
            btnthem.Enabled = btnThem;
            btntimkiem.Enabled = btnTimkiem;
        }
        protected void btntimkiem_Click(object sender, EventArgs e)
        {

        }

        protected void sua_click(object sender, EventArgs e)
        {
            Session["them_tt"] = "";
            hien_ddlnvlaixe();
            xe.maxe = (sender as LinkButton).CommandArgument.ToString();
            Session["Maxe"] = xe.maxe;
            nxe.Manx = manx();
            anhientb(false);

            DataTable dsxe = admin.dsxe_nhaxe(nxe);
            for (int i = 0; i < dsxe.Rows.Count; i++)
            {
                if (xe.maxe == dsxe.Rows[i]["maxe"].ToString())
                {
                    tb_biensoxe.Text = dsxe.Rows[i]["biensoxe"].ToString();
                    ddl_nhanvien.ClearSelection();
                    ddl_nhanvien.Items.FindByValue(dsxe.Rows[i]["manv"].ToString()).Selected = true;
                    ddl_loaixe.ClearSelection();
                    ddl_loaixe.Items.FindByText(dsxe.Rows[i]["loaixe"].ToString()).Selected = true;

                    tb_mauxe.Text = dsxe.Rows[i]["mauxe"].ToString();
                    tb_soghe.Text = dsxe.Rows[i]["soghe"].ToString();

                    string trangthai = dsxe.Rows[i]["trangthai"].ToString();
                    ddl_trangthai.ClearSelection();

                    if (trangthai.Equals("Mở"))
                    {
                        ddl_trangthai.Items.FindByValue("1").Selected = true;
                    }
                    else
                    {
                        ddl_trangthai.Items.FindByValue("0").Selected = true;
                    }
                }
            }
            vohieuhoa(true, false, false, false);
        }
        public void anhientb( bool a)
        {
            tb_biensoxe.Enabled = a;
            ddl_loaixe.Enabled = a;
            tb_mauxe.Enabled = a;
            tb_soghe.Enabled = a;
        }

        public void hien_ddlnvlaixe()
        {
            xe.Fk_manx = manx();

            DataTable dslaixe = admin.getAll_nv_tk_nx();

            ddl_nhanvien.Items.Clear();
            ddl_nhanvien.Items.Add(new ListItem("---Chọn Lái Xe---", ""));
            ddl_nhanvien.Items.FindByValue("").Selected = true;

            for (int i = 0; i < dslaixe.Rows.Count; i++)
            {
                if ("Q00004" == dslaixe.Rows[i]["maquyen"].ToString() &&
                     dslaixe.Rows[i]["manx"].ToString() == xe.Fk_manx &&
                    dslaixe.Rows[i]["trangthai_nv"].ToString() == "Mở")
                {
                    ddl_nhanvien.Items.Add(new ListItem(dslaixe.Rows[i]["tennv"].ToString(),
                        dslaixe.Rows[i]["manv"].ToString()));
                }
            }
        }

        public void mo_khoa_xe(string trangthai, object sender)
        {
            DataTable dstk = admin.get_dstk();
            xe.maxe = (sender as LinkButton).CommandArgument.ToString();
            xe.trangthai = trangthai;
            if (admin.updatexe(xe))
            {
                Response.Write("<script>alert('" + trangthai + "xe thành công!');</script>");
            }
            else Response.Write("<script>alert('" + trangthai + " xe thất bại!');</script>");
        }

        protected void grv_dsxe_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grv_dsxe.PageIndex = e.NewPageIndex;
            hien();
        }

        protected void lbt_luu_Click(object sender, EventArgs e)
        {
            xe.biensoxe = tb_biensoxe.Text;
            xe.Fk_manv = ddl_nhanvien.SelectedValue.ToString();
            xe.loaixe = ddl_loaixe.SelectedItem.ToString();
            xe.mauxe = tb_mauxe.Text ;
            xe.soghe = int.Parse(tb_soghe.Text);
            xe.trangthai = ddl_trangthai.SelectedItem.ToString();
            xe.Fk_manx = manx();

            if (Session["them_tt"].ToString() == "")
            {
                xe.maxe = Session["Maxe"].ToString();
                if (admin.updatexe(xe))
                {
                    tbnull();
                    vohieuhoa(false, true, true, true);
                    Response.Write("<script>alert('Cập nhật xe thành công!');</script>");
                }
                else Response.Write("<script>alert('Cập nhật xe thất bại!');</script>");

            }
            else
            {
                   //Response.Write("<script>alert('"+xe.biensoxe+";"+xe.Fk_manv+";"+xe.loaixe
                   //    ";"+xe.soghe+";"+xe.trangthai+";"+xe.fk+"');</script>");

                if (admin.themxe(xe))
                {

                    Session["them_tt"] = "";
                    Response.Write("<script>alert('Thêm xe thành công!');</script>");
                    vohieuhoa(false, true, true, true);
                    tbnull();
                }
                else Response.Write("<script>alert('Thêm xe thất bại!');</script>");
                           
            }


        }
        protected void lbt_thoat_Click(object sender, EventArgs e)
        {
            tbnull();
            vohieuhoa(false, true, true, true);
        }
        public void tbnull()
        {
            tb_biensoxe.Text = "";
            ddl_nhanvien.Items.Clear();
            ddl_loaixe.Items.FindByText("Ghế Ngồi").Selected = true;
            tb_mauxe.Text = "";
            tb_soghe.Text = "";
            ddl_trangthai.Items.FindByValue("1").Selected = true;
        }


    }
}