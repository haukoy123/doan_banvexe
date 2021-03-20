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
    public partial class QLnhaxe : System.Web.UI.Page
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
            }
        }

        protected void hien()
        {
            DataTable dt = admin.tt_nhaxe();
            gv_dsnx.DataSource = dt;
            gv_dsnx.DataBind();
        }
        protected void view_textbox_nx(string email_nx)
        {
            //an_textbox_nx();
            DataTable nx = admin.get_nhaxe("", email_nx);
            if (nx.Rows.Count == 1)
            {
                for (int i = 0; i < nx.Rows.Count; i++)
                {
                    //nxe.Manx = nx.Rows[i]["manx"].ToString();
                    tb_dc_nx.Text = nx.Rows[i]["diachi"].ToString();
                    tb_ten_nx.Text = nx.Rows[i]["tennx"].ToString();
                    tb_email_nx.Text = nx.Rows[i]["email"].ToString();
                    tb_dt_nx.Text = nx.Rows[i]["sdt"].ToString();

                    ddl_TT_nx.ClearSelection();

                    string ttnx = nx.Rows[i]["trangthai"].ToString();
                    if (ttnx.Equals("Mở"))
                    {

                        ddl_TT_nx.Items.FindByValue("1").Selected = true;
                    }
                    else
                    {
                        ddl_TT_nx.Items.FindByValue("0").Selected = true;
                    }

                }

            }
        }
        protected void view_textbox_tk_nv(string matk)
        {
            DataTable tknv = admin.get_tk_nhanvien(matk);
            if (tknv.Rows.Count == 1)
            {
                for (int i = 0; i < tknv.Rows.Count; i++)
                {
                    tb_tendn_tk.Text = tknv.Rows[i]["tendn"].ToString();
                    //tb_mk_tk.Text = tknv.Rows[i]["matkhau"].ToString();
                    tb_mk_tk.Attributes.Add("value", tknv.Rows[i]["matkhau"].ToString());


                    ddl_quyen.ClearSelection();
                    string quyen = tknv.Rows[i]["FK_maquyen"].ToString();
                    ddl_quyen.Items.FindByValue(quyen).Selected = true;

                    ddl_tt_taikhoan.ClearSelection();
                    string trangthai = tknv.Rows[i]["trangthai"].ToString();
                    if (trangthai.Equals("Mở"))
                    {
                        ddl_tt_taikhoan.Items.FindByValue("1").Selected = true;
                    }
                    else
                    {
                        ddl_tt_taikhoan.Items.FindByValue("0").Selected = true;
                    }
                }
            }
        }
        protected void view_textbox_tt_nv(string manv)
        {
            DataTable tknv = admin.get_tt_nhanvien(manv);
            if (tknv.Rows.Count == 1)
            {
                for (int i = 0; i < tknv.Rows.Count; i++)
                {
                    tb_ten_nv.Text = tknv.Rows[i]["tennv"].ToString();
                    string ns = tknv.Rows[i]["ngaysinh"].ToString();

                    DateTime dt = Convert.ToDateTime(ns);
                    //tb_ns_nv.Text = dt.ToString("yyyy-MM-dd");
                    tb_ns_nv.Text = String.Format("{0:yyyy-MM-dd}", dt);

                    rd_gt_nv.ClearSelection();
                    string quyen = tknv.Rows[i]["gioitinh"].ToString();
                    if (quyen.Equals("True"))
                    {
                        rd_gt_nv.Items.FindByText("Nữ").Selected = true;
                    }
                    else rd_gt_nv.Items.FindByText("Nam").Selected = true;

                    tb_dt_nv.Text = tknv.Rows[i]["sdt"].ToString(); ;
                    //ddl_TT_nx.Items.FindByValue(quyen).Selected = true;
                    tb_dc_nv.Text = tknv.Rows[i]["diachi"].ToString();
                    tb_email_nv.Text = tknv.Rows[i]["email"].ToString();
                    tb_cmt_nv.Text = tknv.Rows[i]["cmnd"].ToString();
                    tb_bophan_nv.Text = ddl_quyen.SelectedItem.ToString();
                }
            }
        }

        protected void view_texbox_sua(string ma)
        {
            DataTable dt = admin.getAll_nv_tk_nx();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (ma.Equals(dt.Rows[i]["mataikhoan"].ToString()))
                {
                    tb_dc_nx.Text = dt.Rows[i]["dc_nhaxe"].ToString();
                    tb_ten_nx.Text = dt.Rows[i]["tennx"].ToString();
                    tb_email_nx.Text = dt.Rows[i]["email"].ToString();
                    tb_dt_nx.Text = dt.Rows[i]["sdt_nhaxe"].ToString();

                    ddl_TT_nx.Items.Clear();
                    string trangthai = dt.Rows[i]["trangthai_nhaxe"].ToString();
                    ddl_TT_nx.Items.Add(new ListItem(trangthai));

                    //string value_ddl = dt.Rows[i]["maquyen"].ToString();
                    //ddl_quyen.ClearSelection();
                    //ddl_quyen.Items.FindByValue(value_ddl).Selected = true;

                }
            }
            tb_ten_nx.Enabled = false;
            tb_dc_nx.Enabled = false;
            //tb_email_nx.Enabled = false; vô hiệu hóa , hoặc dùng disabled
            //tb_email_nx.ReadOnly = true; không cho nhập dữ liệu vào textbox
        }

        protected void btntimkiem_nx_Click(object sender, EventArgs e)
        {
            nxe.Sdt = tb_tk_sdtnx.Text;
            nv.Sdt = tb_tk_sdtnv.Text;
            DataTable dstk = admin.timkiem_nx(nv, nxe);
            if (dstk.Rows.Count == 0)
            {
                lb_kdl.Text = "Không có dữ liệu!";
                gv_dsnx.DataSource = dstk;
                gv_dsnx.DataBind();
            }
            else
            {
                lb_kdl.Visible = false;
                gv_dsnx.DataSource = dstk;
                gv_dsnx.DataBind();
            }
           
        }

        protected void sua_click(object sender, EventArgs e)
        {
            Session["them_tt"] = "";
            vohieuhoa(true, false, false, false);

            string[] arg = new string[3];
            string ma = (sender as LinkButton).CommandArgument.ToString();
            arg = ma.Split(';');
            Session["Manv"] = arg[1];
            Session["Matk"] = arg[2];
            Session["Manxe"] = arg[3];
            Session["email_nx"] = arg[0];

            view_textbox_nx(arg[0]);
            view_textbox_tt_nv(arg[1]);
            view_textbox_tk_nv(arg[2]);
            tb_bophan_nv.Text = ddl_quyen.SelectedItem.ToString();
        }

        protected void tb_tendn_tk_TextChanged(object sender, EventArgs e)
        {
            tb_email_nv.Text = tb_tendn_tk.Text;
        }

        protected void lbt_thoat_Click(object sender, EventArgs e)
        {
            vohieuhoa(false, true, true, true);
            tb_null();
            
        }

        protected void btnthem_nx_Click(object sender, EventArgs e)
        {
            vohieuhoa(true, false, false, false);

            hien_textbox_nx(tb_dt_nx);
            hien_textbox_nx(tb_email_nx);
            tb_bophan_nv.Text = ddl_quyen.SelectedItem.ToString();
            Session["them_tt"] = "clickthem";
        }

        protected void vohieuhoa(Boolean Them, Boolean grid,
        Boolean btnThem, Boolean btnTimkiem)
        {
            them.Visible = Them;
            gv_dsnx.Enabled = grid;
            btnthem_nx.Enabled = btnThem;
            btntimkiem_nx.Enabled = btnTimkiem;
        }

        protected void hien_textbox_nx(TextBox textbox_an)
        {
            textbox_an.Enabled = true;
        }

        protected void lbt_luu_Click(object sender, EventArgs e)
        {
            nxe.Email = tb_email_nx.Text;
            nxe.Sdt = tb_dt_nx.Text;
            nxe.Tennx = tb_ten_nx.Text;
            nxe.Diachi = tb_dc_nx.Text;
            nxe.Trangthai = ddl_TT_nx.SelectedItem.ToString();

            tk.Fk_maquyen = ddl_quyen.SelectedValue.ToString();
            tk.Tendn = tb_tendn_tk.Text;
            tk.Matkhau = tb_mk_tk.Text;
            tk.Trangthai = ddl_tt_taikhoan.SelectedItem.ToString();

            nv.Tennv = tb_ten_nv.Text;
            nv.Ngaysinh = DateTime.Parse(tb_ns_nv.Text);
            nv.Gioitinh = double.Parse(rd_gt_nv.SelectedValue.ToString());
            nv.Sdt = tb_dt_nv.Text;
            nv.Diachi = tb_dc_nv.Text;
            nv.Email = tb_email_nv.Text;
            nv.Bophan = tb_bophan_nv.Text;
            nv.Cmt = tb_cmt_nv.Text;

            if (Session["them_tt"].ToString() != "")
            {
                //Thêm nhà xe- nv dh
                string ktra_tk = admin.getmatk(tk.Tendn);
                int ktra_nxe = 0;
                DataTable nhaxe = admin.tt_nhaxe();
                for (int i = 0; i < nhaxe.Rows.Count; i++)
                {
                    if (nxe.Email.Equals(nhaxe.Rows[i]["email"].ToString()) ||
                        nxe.Sdt.Equals(nhaxe.Rows[i]["sdt_nhaxe"].ToString()))
                    {
                        ktra_nxe = 1;
                    }
                }
                if (ktra_nxe == 1)
                {
                    Response.Write("<script>alert('Email hoặc Số điện thoại đã tồn tại, yêu cầu nhập lại!');</script>");
                    tb_dt_nx.Focus();
                }
                else
                {
                    if (admin.themnx(nxe) && admin.themtk(tk))
                    {
                        nv.Fk_matk = int.Parse(admin.getmatk(tb_tendn_tk.Text));
                        DataTable dsnx = admin.ds_nhaxe();
                        for (int i = 0; i < dsnx.Rows.Count; i++)
                        {
                            if (nxe.Email.Equals(dsnx.Rows[i]["email"].ToString()))
                            {
                                nv.Fk_manx = dsnx.Rows[i]["manx"].ToString();
                            }
                        }
                        if (admin.themnv(nv))
                        {
                            Session["them_tt"] = "";
                            Response.Write("<script>alert('Lưu thành công!');</script>");

                            vohieuhoa(false, true, true, true);
                            tb_null();
                        }
                        else Response.Write("<script>alert('Lưu thất bại');</script>");
                    }
                    else Response.Write("<script>alert('Lưu thông tin tài khoản hoặc nhà xe thất bại!');<script>");
                }
            }
            else
            {
                nxe.Manx = Session["Manxe"].ToString();
                nv.Fk_manx = nxe.Manx;
                tk.Matk = int.Parse(Session["Matk"].ToString());
                nv.Fk_matk = tk.Matk;
                nv.Manv = Session["Manv"].ToString();
                Response.Write("<script>alert('" + nxe.Manx + "; mã tài khoản: "
                    + tk.Matk + "; manv: " + nv.Manv + "');</script>");

                if (admin.updateNx(nxe) && admin.updateTk(tk) && admin.updateNv(nv))
                {
                    vohieuhoa(false, true, true, true);
                    Response.Write("<script>alert('Cập nhật thành công!');</script>");
                }
                else Response.Write("<script>alert('Cập nhật tài khoản thất bại!');</script>");
            }
        }
        protected void gv_dstk_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_dsnx.PageIndex = e.NewPageIndex;
            hien();
        }
        public void tb_null()
        {
            tb_ten_nx.Text = "";
            tb_dc_nx.Text = "";
            tb_dt_nx.Text = "";
            tb_email_nx.Text = "";
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
