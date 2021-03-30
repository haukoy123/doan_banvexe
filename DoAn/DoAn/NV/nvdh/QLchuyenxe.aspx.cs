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
    public partial class QLchuyenxe : System.Web.UI.Page
    {
        cs.adminDAL admin = new cs.adminDAL();

        tblnx nxe = new tblnx();
        tbltk tk = new tbltk();
        tblnv nv = new tblnv();
        tblChuyenxe cx = new tblChuyenxe();
        tblnx_tx nx_tx = new tblnx_tx();
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

            DataTable dt = admin.ds_chuyenxe_nhaxe(nv);
            grv_chuyenxe.DataSource = dt;
            grv_chuyenxe.DataBind();
        }
        protected void sua_click(object sender, EventArgs e)
        {
            Session["them_tt"] = "";
            vohieuhoa(true, false, false, false);

            //string[] arg = new string[2];
            string ma = (sender as LinkButton).CommandArgument.ToString();
            //arg = ma.Split(';');
            Session["macx"] = ma;
            cx.macx = ma;
            hien_ddl_dstuyenxe();
            nv.Fk_manx = manx();
            //ds_nvxe_nx();
            hien_ddl_dsxe();

            DataTable cx_nx = admin.ds_chuyenxe_nhaxe(nv);

            for (int i = 0; i < cx_nx.Rows.Count; i++)
            {
                if (cx.macx.Equals(cx_nx.Rows[i]["machuyenxe"].ToString()))
                {
                    tb_tencx.Text = cx_nx.Rows[i]["tenchuyenxe"].ToString();

                    //tb_tentx.Text = cx_nx.Rows[i]["tentuyenxe"].ToString();
                    //DateTime tgkh = Convert.ToDateTime();

                    tb_tgkh.Text = cx_nx.Rows[i]["giokh"].ToString();
                    //DateTime tgkt = Convert.ToDateTime(cx_nx.Rows[i]["gioden"]);
                    //tb_tgkt.Text = tgkt.ToString("hh\\:mm");
                    DateTime ngaydi = Convert.ToDateTime(cx_nx.Rows[i]["Ngaydi"]);
                    tb_ngaydi.Text = String.Format("{0:yyyy-MM-dd}", ngaydi);

                    tb_tgkt.Text = cx_nx.Rows[i]["gioden"].ToString();

                    lbl_macx.Text = cx.macx;

                    tb_nvxe.Text = cx_nx.Rows[i]["tennv"].ToString();
                    //ddl_nv.ClearSelection();
                    //ddl_nv.Items.FindByValue(cx_nx.Rows[i]["Fk_manv"].ToString()).Selected = true;

                    ddl_dstuyenxe.ClearSelection();
                    ddl_dstuyenxe.Items.FindByValue(cx_nx.Rows[i]["Fk_matuyenxe"].ToString()).Selected = true;

                    ddl_tt_nx.ClearSelection();
                    string trangthai = cx_nx.Rows[i]["trangthai"].ToString();

                    ddl_ds_xe.ClearSelection();
                    ddl_ds_xe.Items.FindByValue(cx_nx.Rows[i]["maxe"].ToString()).Selected = true;

                    if (trangthai.Equals("Mở"))
                    {
                        ddl_tt_nx.Items.FindByValue("1").Selected = true;
                    }
                    else
                    {
                        ddl_tt_nx.Items.FindByValue("0").Selected = true;
                    }
                }
            }
        }

        protected void vohieuhoa(Boolean Them, Boolean grid,
           Boolean btnThem, Boolean btnTimkiem)
        {
            hien_them.Visible = Them;
            grv_chuyenxe.Enabled = grid;
            btnthem.Enabled = btnThem;
            btntimkiem.Enabled = btnTimkiem;
        }
        protected DataTable ds_nv()
        {
            nv.Fk_manx = manx();
            DataTable dsnv = admin.getAll_nv_tk_nx();
            for (int i = 0; i < dsnv.Rows.Count; i++)
            {
                if (nv.Fk_manx != dsnv.Rows[i]["manx"].ToString() || dsnv.Rows[i]["maquyen"].ToString() != "Q00004")
                {
                    dsnv.Rows[i].Delete();
                }
            }
            dsnv.AcceptChanges();
            return dsnv;
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

        protected void view_texbox_ttchuyen()
        {

        }
        protected void btntimkiem_Click(object sender, EventArgs e)
        {

        }

        protected void btnthem_Click(object sender, EventArgs e)
        {
            vohieuhoa(true, false, false, false);
            tb_tencx.Enabled = true;
            //tb_tentx.Enabled = true;
            hien_ddl_dstuyenxe();
            //ds_nvxe_nx();

            hien_ddl_dsxe();
            //cx.trangthai = ddl_dstuyenxe.SelectedItem.ToString();
            Session["them_tt"] = "clickthem";
            ddl_tt_nx.Items.FindByValue("1").Selected = true;
        }

        protected void lbt_luu_Click(object sender, EventArgs e)
        {
            cx.trangthai = ddl_tt_nx.SelectedItem.ToString();
            cx.tencx = tb_tencx.Text;
            cx.Ngaydi = DateTime.Parse(tb_ngaydi.Text);
            cx.Fk_maxe = ddl_ds_xe.SelectedValue.ToString();
            cx.trangthai = ddl_tt_nx.SelectedItem.ToString();

            nxe.Manx = manx();
            nx_tx.manx = nxe.Manx;
            nx_tx.matx = ddl_dstuyenxe.SelectedValue.ToString();
            nx_tx.trangthai = "Mở";
            int ktratuyen = 1;

            if (Session["them_tt"].ToString() != "")
            {
                DataTable dsnx_tx = admin.ds_tuyenxe_nhaxe(nxe);
                for (int i = 0; i < dsnx_tx.Rows.Count; i++)
                {
                    if (ddl_dstuyenxe.SelectedValue.ToString().Equals(dsnx_tx.Rows[i]["matuyenxe"].ToString()))
                    {
                        // ĐÃ CÓ TUYẾN XE TRONG NHÀ XE
                        ktratuyen++;
                        cx.Fk_manx_tx = dsnx_tx.Rows[i]["manx_tx"].ToString();

                        if (admin.themcx(cx))
                        {
                            Session["them_tt"] = "";
                            Response.Write("<script>alert('Thêm thành công!');</script>");
                            vohieuhoa(false, true, true, true);
                            tb_null();
                        }
                        else Response.Write("<script>alert('Thêm thất bại!');</script>");
                    }
                }
                //   NHÀ XE CHƯA CÓ TUYẾN THỰC HIỆN THÊM TUYẾN MỚI THÊM CX
                if (ktratuyen == 1)
                {
                    if (admin.themnx_tx(nx_tx))
                    {
                        DataTable dsnx_tx2 = admin.ds_tuyenxe_nhaxe(nxe);
                        for (int i = 0; i < dsnx_tx2.Rows.Count; i++)
                        {
                            if (ddl_dstuyenxe.SelectedValue.ToString().Equals(dsnx_tx2.Rows[i]["matuyenxe"].ToString()))
                            {
                                // ĐÃ CÓ TUYẾN XE TRONG NHÀ XE
                                ktratuyen++;
                                cx.Fk_manx_tx = dsnx_tx2.Rows[i]["manx_tx"].ToString();

                                if (admin.themcx(cx))
                                {
                                    Session["them_tt"] = "";
                                    Response.Write("<script>alert('Thêm thành công!');</script>");
                                    vohieuhoa(false, true, true, true);
                                    tb_null();
                                }
                                else Response.Write("<script>alert('Thêm thất bại!');</script>");
                            }
                        }
                    }
                    else Response.Write("<script>alert('Thêm Nhà xe - Tuyến xe thất bại!');</script>");
                }
            }
            else
            {
                cx.macx = Session["macx"].ToString();
                if (admin.update_cx(cx))
                {
                    vohieuhoa(false, true, true, true);

                    Response.Write("<script>alert('Cập nhật thành công!');</script>");
                }
                else Response.Write("<script>alert('Cập nhật chuyến xe thất bại!');</script>");

            }
        }

        protected void lbt_thoat_Click(object sender, EventArgs e)
        {
            vohieuhoa(false, true, true, true);
            tb_null();
        }
        protected void grv_chuyenxe_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grv_chuyenxe.PageIndex = e.NewPageIndex;
            hien();
        }
        public void tb_null()
        {
            lbl_macx.Text = "";
            tb_tgkh.Text = "";
            tb_tgkt.Text = "";
            tb_tencx.Text = "";
            tb_ngaydi.Text = "";
            tb_nvxe.Text = "";
            //ddl_nv.ClearSelection();
            ddl_dstuyenxe.ClearSelection();
            ddl_tt_nx.ClearSelection();
            ddl_ds_xe.ClearSelection();
        }
        protected void hien_ddl_dstuyenxe()
        {
            ddl_dstuyenxe.Items.Clear();
            ddl_dstuyenxe.Items.Add(new ListItem("----Chọn----", ""));
            ddl_dstuyenxe.Items.FindByValue("").Selected = true;

            DataTable dt = admin.dsTuyenxe();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddl_dstuyenxe.Items.Add(new ListItem(dt.Rows[i]["tentuyenxe"].ToString(),
                    dt.Rows[i]["matuyenxe"].ToString()));
            }
        }
        //protected void ds_nvxe_nx()
        //{
        //    ddl_nv.Items.Clear();
        //    ddl_nv.Items.Add(new ListItem("---Chọn---", ""));
        //    ddl_nv.Items.FindByValue("").Selected = true;

        //    DataTable dt = ds_nv();
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        ddl_nv.Items.Add(new ListItem(dt.Rows[i]["tennv"].ToString(),
        //            dt.Rows[i]["manv"].ToString()));
        //    }
        //}
        protected void hien_ddl_dsxe()
        {
            ddl_ds_xe.Items.Clear();
            ddl_ds_xe.Items.Add(new ListItem("----Chọn----", ""));
            ddl_ds_xe.Items.FindByValue("").Selected = true;

            DataTable dsnv_nx_tk = admin.getAll_nv_tk_nx();
            for (int i = 0; i < dsnv_nx_tk.Rows.Count; i++)
            {
                if (Session["tendn"].ToString().Equals(dsnv_nx_tk.Rows[i]["tendn"].ToString()))
                {
                    nxe.Manx = dsnv_nx_tk.Rows[i]["manx"].ToString();
                }
            }
            DataTable dt = admin.dsxe_nhaxe(nxe);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddl_ds_xe.Items.Add(new ListItem(dt.Rows[i]["biensoxe"].ToString(),
                    dt.Rows[i]["maxe"].ToString()));
            }
        }

        protected void ddl_dstuyenxe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_dstuyenxe.SelectedValue.ToString() == "")
            {
                tb_tgkh.Text = "";
                tb_tgkt.Text = "";
            }
            else
            {
                DataTable ds_tx = admin.dsTuyenxe();
                for (int i = 0; i < ds_tx.Rows.Count; i++)
                {
                    if (ddl_dstuyenxe.SelectedValue.ToString().Equals(ds_tx.Rows[i]["matuyenxe"].ToString()))
                    {
                        tb_tgkh.Text = ds_tx.Rows[i]["giokh"].ToString();
                        tb_tgkt.Text = ds_tx.Rows[i]["gioden"].ToString();
                    }
                }
            }
        }

        protected void ddl_ds_xe_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maxe = ddl_ds_xe.SelectedValue.ToString();
            nxe.Manx = manx();
            string manv = "";
            DataTable dt = admin.dsxe_nhaxe(nxe);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (maxe == dt.Rows[i]["maxe"].ToString())
                {
                    manv = dt.Rows[i]["Fk_manv"].ToString();
                }
            }
            DataTable dt1 = admin.get_tt_nhanvien(manv);
            if (dt1.Rows.Count == 1)
            {
                tb_nvxe.Text = dt1.Rows[0]["tennv"].ToString();
            }
            else
            {
                tb_nvxe.Text = "";

            }
        }

        //protected void ddl_dstuyenxe_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Response.Write("<script>alert('"+ddl_dstuyenxe.SelectedValue.ToString()+"');</script>");

        //}
    }
}