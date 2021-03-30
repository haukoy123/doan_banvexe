using DoAn.cs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAn.NV.nvbv
{
    public partial class Qlvexe : System.Web.UI.Page
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
                //hien_ddl_dsnhaxe();
            }
        }

        public void hien()
        {
            DataTable dt = dsvexe_nx();
            dsttve.DataSource = dt;
            dsttve.DataBind();
        }
        protected DataTable dsvexe_nx()
        {
            nv.Fk_manx = manx();
            DataTable dsvx = admin.dschitietve();

            DataTable dsvxnv = admin.dschitietve_nv();
            for (int j = 0; j < dsvxnv.Rows.Count; j++)
            {
                dsvx.ImportRow(dsvxnv.Rows[j]);
            }
            dsvx.AcceptChanges();

            for (int i = 0; i < dsvx.Rows.Count; i++)
            {
                if (nv.Fk_manx != dsvx.Rows[i]["manx"].ToString())
                {
                    dsvx.Rows[i].Delete();
                }
            }
            dsvx.AcceptChanges();
            return dsvx;
        }
        public DataTable dscxsapdi_nx()
        {
            nv.Fk_manx = manx();
            DataTable dscx = admin.ds_chuyenxe_nhaxe(nv);
            for (int i = 0; i < dscx.Rows.Count; i++)
            {
                if (DateTime.Now >= Convert.ToDateTime(dscx.Rows[i]["Ngaydi"].ToString()))
                {
                    dscx.Rows[i].Delete();
                }
            }
            dscx.AcceptChanges();
            return dscx;
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
        protected void dsttve_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dsttve.PageIndex = e.NewPageIndex;
            hien();
        }
        protected void sua_click(object sender, EventArgs e)
        {
            float ktra = 0;
            Session["them_tt"] = "";
            string malichtr = "";
            vohieuhoa(false, true, false, false, false);
            DataTable a = dsvexe_nx();
            string cmdsua = (sender as LinkButton).CommandArgument.ToString();
            string[] arg = new string[3];
            arg = cmdsua.Split(';');
            string mave = arg[0];
            string matk = arg[1];
            string machuyen = arg[2];
            string manx = arg[3];
            string matuyenxe = arg[4];
            DataTable dscx = dsvexe_nx();
            for (int i = 0; i < dscx.Rows.Count; i++)
            {
                if (mave == dscx.Rows[i]["mavexe"].ToString())
                {
                    lbmave.Text = mave;
                    tbdatve_tenkh.Text = dscx.Rows[i]["tenKhdi"].ToString();
                    tbdatve_sdt.Text = dscx.Rows[i]["sdtDatve"].ToString();
                    tbdatve_soghe.Text = dscx.Rows[i]["soghedat"].ToString();
                    //string ttnx = nx.Rows[i]["trangthai"].ToString();

                    //if (ttnx.Equals("Mở"))
                    //{

                    //    ddl_TT_nx.Items.FindByValue("1").Selected = true;
                    //}
                    //else
                    //{
                    //    ddl_TT_nx.Items.FindByValue("0").Selected = true;
                    //}
                    tbdatve_tenchuyen.Text = dscx.Rows[i]["tenchuyenxe"].ToString();
                    tbdatve_tentuyen.Text = dscx.Rows[i]["tenchuyenxe"].ToString();

                    DateTime ngaydi = Convert.ToDateTime(dscx.Rows[i]["Ngaydi"].ToString());
                    tbdatve_ngaydi.Text = String.Format("{0:yyyy-MM-dd}", ngaydi);

                    DateTime giokh = Convert.ToDateTime(dscx.Rows[i]["giokh"].ToString());
                    tbdatve_giokh.Text = giokh.ToString("hh\\:mm");

                    DateTime gioden = Convert.ToDateTime(dscx.Rows[i]["gioden"].ToString());
                    tbdatve_tgkt.Text = gioden.ToString("hh\\:mm");

                    tb_tongtien.Text = dscx.Rows[i]["tongtien"].ToString() + ".đ";

                    ddlchondiemdung.Items.Clear();
                    ddlchondiemdung.Items.Add(new ListItem("----Lịch Trình---------", ""));
                    DataTable lt = hien_ddllichtrinh(matuyenxe);
                    for (int j = 0; j < lt.Rows.Count; j++)
                    {
                        ddlchondiemdung.Items.Add(new ListItem(lt.Rows[j]["diemden"].ToString() + "; Giá: " + lt.Rows[j]["giave"].ToString() + ".đ",
                            lt.Rows[j]["malichtrinh"].ToString()));
                        ktra = float.Parse(dscx.Rows[i]["tongtien"].ToString()) / float.Parse(dscx.Rows[i]["soghedat"].ToString());
                        if (lt.Rows[j]["giave"].ToString() == ktra.ToString())
                        {
                            malichtr = lt.Rows[j]["malichtrinh"].ToString();
                        }
                    }
                    if (malichtr != "")
                    {
                        ddlchondiemdung.Items.FindByValue(malichtr).Selected = true;

                    }
                    else
                    {
                        ddlchondiemdung.Items.FindByValue("").Selected = true;
                    }
                }
            }
        }

        protected void btnnhanvien_click(object sender, EventArgs e)
        {
            nv.Manv = (sender as LinkButton).CommandArgument.ToString();
            DataTable dsnv = admin.get_tt_nhanvien(nv.Manv);
            for (int i = 0; i < dsnv.Rows.Count; i++)
            {
                if (nv.Manv == dsnv.Rows[i]["manv"].ToString())
                {
                    lbl_manv.Text = dsnv.Rows[i]["manv"].ToString();
                    //tb_makh.Text = dsnv.Rows[i]["makh"].ToString();
                    tb_ten_nv.Text = dsnv.Rows[i]["tennv"].ToString();

                    DateTime ns = Convert.ToDateTime(dsnv.Rows[i]["ngaysinh"].ToString());
                    tb_ns_nv.Text = String.Format("{0:yyyy-MM-dd}", ns);

                    rd_gt_nv.ClearSelection();
                    string gt = dsnv.Rows[i]["gioitinh"].ToString();
                    if (gt.Equals("True"))
                    {
                        rd_gt_nv.Items.FindByText("Nữ").Selected = true;
                    }
                    else rd_gt_nv.Items.FindByText("Nam").Selected = true;

                    tb_dt_nv.Text = dsnv.Rows[i]["sdt"].ToString();
                    tb_dc_nv.Text = dsnv.Rows[i]["diachi"].ToString();
                    tb_email_nv.Text = dsnv.Rows[i]["email"].ToString();
                    tb_cmt_nv.Text = dsnv.Rows[i]["cmnd"].ToString();
                    tb_bophan_nv.Text = dsnv.Rows[i]["bophan"].ToString();
                }
            }
            vohieuhoa(true, false, false, false, false);
        }

        protected void btnchuyenxe_click(object sender, EventArgs e)
        {
            string mave = (sender as LinkButton).CommandArgument.ToString();
            DataTable dscx = dsvexe_nx();
            for (int i = 0; i < dscx.Rows.Count; i++)
            {
                if (mave == dscx.Rows[i]["mavexe"].ToString())
                {
                    lblmachuyen.Text = dscx.Rows[i]["machuyenxe"].ToString();
                    tb_cx.Text = dscx.Rows[i]["tenchuyenxe"].ToString();
                    tb_nvptr.Text = dscx.Rows[i]["tennv"].ToString();
                    DateTime a = Convert.ToDateTime(dscx.Rows[i]["Ngaydi"].ToString());
                    tb_ngaydi.Text = String.Format("{0:yyyy-MM-dd}", a);

                    tb_tentx.Text = dscx.Rows[i]["tentuyenxe"].ToString();
                    tb_tinhdi.Text = dscx.Rows[i]["tinhdi"].ToString();
                    tb_tinhden.Text = dscx.Rows[i]["tinhden"].ToString();
                    tb_tgkh.Text = dscx.Rows[i]["giokh"].ToString();
                    tb_tgkt.Text = dscx.Rows[i]["gioden"].ToString();
                    tb_bsx.Text = dscx.Rows[i]["biensoxe"].ToString();
                    tb_loaixe.Text = dscx.Rows[i]["loaixe"].ToString();
                    tb_mauxe.Text = dscx.Rows[i]["mauxe"].ToString();
                    tb_soghe.Text = dscx.Rows[i]["gheXe"].ToString();

                    ddllichtrinh.Items.Clear();
                    ddllichtrinh.Items.Add(new ListItem("----Lịch Trình---------", ""));
                    ddllichtrinh.Items.FindByValue("").Selected = true;

                    DataTable dt = hien_ddllichtrinh(dscx.Rows[i]["matuyenxe"].ToString());
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        ddllichtrinh.Items.Add(new ListItem(dt.Rows[j]["diemden"].ToString() + "; Giá: " + dt.Rows[j]["giave"].ToString() + ".đ",
                            dt.Rows[j]["malichtrinh"].ToString()));
                    }
                    int ghecon = ghetrong(dscx.Rows[i]["machuyenxe"].ToString());
                    tb_ghetrong.Text = ghecon.ToString();
                }
            }
            vohieuhoa(false, false, false, true, false);
        }

        public int ghetrong(string machuyen)
        {
            int tong = 0;
            DataTable dscx = dsvexe_nx();
            for (int i = 0; i < dscx.Rows.Count; i++)
            {
                if (machuyen == dscx.Rows[i]["machuyenxe"].ToString())
                {
                    tong = tong + int.Parse(dscx.Rows[i]["soghedat"].ToString());
                }
            }
            return tong;
        }

        public DataTable hien_ddllichtrinh(string matuyen)
        {
            DataTable dstl = admin.get_dslichtrinh();
            for (int i = 0; i < dstl.Rows.Count; i++)
            {
                if (matuyen != dstl.Rows[i]["FK_matuyenxe"].ToString())
                {
                    dstl.Rows[i].Delete();
                }
            }
            dstl.AcceptChanges();
            return dstl;
        }

        protected void btntaikhoan_click(object sender, EventArgs e)
        {
            kh.Makh = (sender as LinkButton).CommandArgument.ToString();
            DataTable dstk = admin.get_ttkh(kh);
            DataTable dstk1 = admin.get_tt_nhanvien(kh.Makh);
            if (dstk.Rows.Count != 0)
            {
                for (int i = 0; i < dstk.Rows.Count; i++)
                {
                    if (kh.Makh == dstk.Rows[i]["makh"].ToString())
                    {
                        lbmatkkh.Text = dstk.Rows[i]["mataikhoan"].ToString();
                        tb_makh.Text = dstk.Rows[i]["makh"].ToString();
                        tb_tenkh.Text = dstk.Rows[i]["tenkh"].ToString();

                        DateTime ns = Convert.ToDateTime(dstk.Rows[i]["ngaysinh"].ToString());
                        tb_ngaysinh.Text = String.Format("{0:yyyy-MM-dd}", ns);

                        rd_gtkh.ClearSelection();
                        string gt = dstk.Rows[i]["gioitinh"].ToString();
                        if (gt.Equals("True"))
                        {
                            rd_gtkh.Items.FindByText("Nữ").Selected = true;
                        }
                        else rd_gtkh.Items.FindByText("Nam").Selected = true;

                        tb_dienthoaikh.Text = dstk.Rows[i]["sdt"].ToString();
                        tb_dckh.Text = dstk.Rows[i]["diachi"].ToString();
                        tb_emailkh.Text = dstk.Rows[i]["email"].ToString();
                        tb_cmtkh.Text = dstk.Rows[i]["cmnd"].ToString();
                    }
                }
            }
            else
            {
                for (int i = 0; i < dstk1.Rows.Count; i++)
                {
                    if (kh.Makh == dstk1.Rows[i]["manv"].ToString())
                    {
                        lbmatkkh.Text = dstk1.Rows[i]["FK_mataikhoan"].ToString() + " (Nhân Viên)";
                        tb_makh.Text = dstk1.Rows[i]["manv"].ToString();
                        tb_tenkh.Text = dstk1.Rows[i]["tennv"].ToString();

                        DateTime ns = Convert.ToDateTime(dstk1.Rows[i]["ngaysinh"].ToString());
                        tb_ngaysinh.Text = String.Format("{0:yyyy-MM-dd}", ns);

                        rd_gtkh.ClearSelection();
                        string gt = dstk1.Rows[i]["gioitinh"].ToString();
                        if (gt.Equals("True"))
                        {
                            rd_gtkh.Items.FindByText("Nữ").Selected = true;
                        }
                        else rd_gtkh.Items.FindByText("Nam").Selected = true;

                        tb_dienthoaikh.Text = dstk1.Rows[i]["sdt"].ToString();
                        tb_dckh.Text = dstk1.Rows[i]["diachi"].ToString();
                        tb_emailkh.Text = dstk1.Rows[i]["email"].ToString();
                        tb_cmtkh.Text = dstk1.Rows[i]["cmnd"].ToString();
                    }
                }
            }
            vohieuhoa(false, false, false, false, true);
        }

        protected void lbt_thoat_Click(object sender, EventArgs e)
        {
            tbnull();
            ddl_chuyenxe.Items.Clear();
            vohieuhoa(false, false, true, false, false);
        }

        public void tbnull()
        {
            tbtimchuyen_ngaydi.Text = "";
            tbdatve_tenkh.Text = "";
            tbdatve_sdt.Text = "";
            tbdatve_soghe.Text = "";
            ddltrangthai.Items.FindByText("Đã đặt").Selected = true;
            tbdatve_tenchuyen.Text = "";
            tbdatve_tentuyen.Text = "";
            tbdatve_ngaydi.Text = "";
            tbdatve_giokh.Text = "";
            tbdatve_tgkt.Text = "";
            tbtimchuyen_diemdi.Text = "";
            tbtimchuyen_diemden.Text = "";
            tbtimchuyen_tg1.Text = "";
            tbtimchuyen_tg2.Text = "";
            tb_soghe.Text = "";
            tb_tongtien.Text = "";
            ddlchondiemdung.Items.Clear();
        }


        protected void vohieuhoa(Boolean Them, Boolean themve, Boolean grid, Boolean chuyenxe, Boolean tkdat)
        {
            hienttnv.Visible = Them;
            hienttcx.Visible = chuyenxe;
            hientttkdat.Visible = tkdat;
            dsttve.Enabled = grid;
            themvexe.Visible = themve;
        }

        protected void btnthem_Click(object sender, EventArgs e)
        {
            Session["them_tt"] = "themclick";
            lbmave.Text = "";
            ddl_chuyenxe.Items.Clear();
            DataTable a = dscxsapdi_nx();
            ddl_chuyenxe.Items.Add(new ListItem("---Chọn Chuyến---", ""));
            ddl_chuyenxe.Items.FindByValue("").Selected = true;

            for (int i = 0; i < a.Rows.Count; i++)
            {
                ddl_chuyenxe.Items.Add(new ListItem(a.Rows[i]["tenchuyenxe"].ToString(),
                    a.Rows[i]["machuyenxe"].ToString()));
            }

            vohieuhoa(false, true, false, false, false);
        }


        public DataTable chuyenxe_ngaydi(DataTable table)
        {
            if (tbtimchuyen_ngaydi.Text != "")
            {
                DateTime ngaydi = Convert.ToDateTime(tbtimchuyen_ngaydi.Text);
                //table = dscxsapdi_nx();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    if (ngaydi != Convert.ToDateTime(table.Rows[i]["Ngaydi"].ToString()))
                    {
                        table.Rows[i].Delete();
                    }
                }
                table.AcceptChanges();
            }
            else
            {
                return table;
            }
            return table;
        }
        public DataTable chuyenxe_giodi(DataTable table)
        {
            if (tbtimchuyen_tg1.Text != "" && tbtimchuyen_tg2.Text != "")
            {
                DateTime tg1 = Convert.ToDateTime(tbtimchuyen_tg1.Text);
                DateTime tg2 = Convert.ToDateTime(tbtimchuyen_tg2.Text);
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    if (tg1 <= Convert.ToDateTime(table.Rows[i]["giokh"].ToString()) && tg2 >= Convert.ToDateTime(table.Rows[i]["giokh"].ToString()))
                    {
                        //table.AcceptChanges();

                    }
                    else
                    {
                        table.Rows[i].Delete();
                    }
                }
                table.AcceptChanges();
            }
            else
            {
                return table;
            }

            return table;
        }
        public DataTable chuyenxe_diadiem(DataTable table)
        {
            if (tbtimchuyen_diemdi.Text == "" && tbtimchuyen_diemden.Text == "")
            {
                return table;
            }
            else
            {
                DataTable a = table.Clone();
                int ktra = 0;
                DataTable dsltcx = admin.get_dslichtrinh_diadiem(tbtimchuyen_diemdi.Text, tbtimchuyen_diemden.Text);

                for (int i = 0; i < dsltcx.Rows.Count; i++)
                {
                    for (int j = 0; j < table.Rows.Count; j++)
                    {
                        if (dsltcx.Rows[i]["matuyenxe"].ToString() == table.Rows[j]["Fk_matuyenxe"].ToString())
                        {
                            for (int n = 0; n < a.Rows.Count; n++)
                            {
                                if (a.Rows[n]["Fk_matuyenxe"].ToString() == table.Rows[j]["Fk_matuyenxe"].ToString())
                                {
                                    ktra++;
                                }
                            }
                            if (ktra == 0)
                            {
                                a.ImportRow(table.Rows[j]);
                                ktra = 0;
                            }
                        }
                    }
                }
                return a;
            }
        }

        protected void btntimkiem_Click(object sender, EventArgs e)
        {

        }
        protected void lbt_luu_Click(object sender, EventArgs e)
        {

            vx.tenkh = tbdatve_tenkh.Text;
            vx.sdt = tbdatve_sdt.Text;
            vx.soghe = int.Parse(tbdatve_soghe.Text);
            string tien = tb_tongtien.Text;
            vx.trangthai = ddltrangthai.SelectedItem.ToString();

            DataTable dt = admin.get_dslichtrinh();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (ddlchondiemdung.SelectedValue.ToString() == dt.Rows[i]["malichtrinh"].ToString())
                {
                    vx.diemden = dt.Rows[i]["diemden"].ToString();
                }
            }

            vx.thoigiandatve = DateTime.Now;

            vx.tongtien = int.Parse(tien.Remove(tien.LastIndexOf(".đ")));

            if (Session["them_tt"].ToString() == "")
            {
                vx.mavx = lbmave.Text;

                if (admin.updateVexe(vx))
                {
                    Response.Write("<script>alert('Cập nhật thành công!');</script>");
                    tbnull();
                    vohieuhoa(false, false, true, false, false);
                }
                else Response.Write("<script>alert('Cập nhật vé xe thất bại!');</script>");
            }
            else
            {
                vx.Fk_macx = ddl_chuyenxe.SelectedValue.ToString();
                vx.Fk_matk = int.Parse(admin.getmatk(Session["tendn"].ToString()));

                if (admin.themvx(vx))
                {
                    Session["them_tt"] = "";
                    Response.Write("<script>alert('Thêm thành công!');</script>");
                    tbnull();
                    vohieuhoa(false, false, true, false, false);
                }
                else Response.Write("<script>alert('Thêm vé xe thất bại!');</script>");
            }
        }

        protected void btn_timchuyen_Click(object sender, EventArgs e)
        {
            DataTable dtt = dscxsapdi_nx();
            DataTable dtt1 = chuyenxe_ngaydi(dtt);
            DataTable dtt2 = chuyenxe_giodi(dtt1);
            DataTable dt = chuyenxe_diadiem(dtt2);
            ddl_chuyenxe.Items.Clear();
            ddl_chuyenxe.Items.Add(new ListItem("---Chọn Chuyến---", ""));
            ddl_chuyenxe.Items.FindByValue("").Selected = true;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddl_chuyenxe.Items.Add(new ListItem(dt.Rows[i]["tenchuyenxe"].ToString(),
                    dt.Rows[i]["machuyenxe"].ToString()));
            }
        }

        protected void ddl_chuyenxe_SelectedIndexChanged(object sender, EventArgs e)
        {

            string machuyen = ddl_chuyenxe.SelectedValue.ToString();

            nv.Fk_manx = manx();
            DataTable dt = admin.ds_chuyenxe_nhaxe(nv);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (machuyen == dt.Rows[i]["machuyenxe"].ToString())
                {
                    tbdatve_tenchuyen.Text = dt.Rows[i]["tenchuyenxe"].ToString();
                    tbdatve_tentuyen.Text = dt.Rows[i]["tentuyenxe"].ToString();
                    DateTime ngaydi = Convert.ToDateTime(dt.Rows[i]["Ngaydi"].ToString());
                    tbdatve_ngaydi.Text = String.Format("{0:yyyy-MM-dd}", ngaydi);

                    DateTime giokh = Convert.ToDateTime(dt.Rows[i]["giokh"].ToString());
                    tbdatve_giokh.Text = giokh.ToString("hh\\:mm");

                    DateTime giokt = Convert.ToDateTime(dt.Rows[i]["gioden"].ToString());
                    tbdatve_tgkt.Text = giokt.ToString("hh\\:mm");

                    ddlchondiemdung.Items.Clear();

                    ddlchondiemdung.Items.Add(new ListItem("----Lịch Trình---------", ""));
                    ddlchondiemdung.Items.FindByValue("").Selected = true;

                    DataTable lt = hien_ddllichtrinh(dt.Rows[i]["Fk_matuyenxe"].ToString());
                    for (int j = 0; j < lt.Rows.Count; j++)
                    {
                        ddlchondiemdung.Items.Add(new ListItem(lt.Rows[j]["diemden"].ToString() + "; Giá: " + lt.Rows[j]["giave"].ToString() + ".đ",
                            lt.Rows[j]["malichtrinh"].ToString()));
                    }
                }
            }
            if (ddl_chuyenxe.Items.FindByValue("").Selected)
            {
                tbnull();
            }
        }

        protected void ddlchondiemdung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbdatve_soghe.Text != "")
            {
                int soghe = int.Parse(tbdatve_soghe.Text);
                string malichtrinh = ddlchondiemdung.SelectedValue.ToString();
                int giave = 0;
                DataTable dt = admin.get_dslichtrinh();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (malichtrinh == dt.Rows[i]["malichtrinh"].ToString())
                    {
                        giave = int.Parse(dt.Rows[i]["giave"].ToString());
                    }
                }
                int tong = giave * soghe;
                tb_tongtien.Text = tong.ToString() + ".đ";
            }
        }

        protected void tbdatve_soghe_TextChanged(object sender, EventArgs e)
        {
            if (ddlchondiemdung.SelectedValue.ToString() != "")
            {
                int soghe = int.Parse(tbdatve_soghe.Text);
                string malichtrinh = ddlchondiemdung.SelectedValue.ToString();
                int giave = 0;
                DataTable dt = admin.get_dslichtrinh();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (malichtrinh == dt.Rows[i]["malichtrinh"].ToString())
                    {
                        giave = int.Parse(dt.Rows[i]["giave"].ToString());
                    }
                }
                int tong = giave * soghe;
                tb_tongtien.Text = tong.ToString() + ".đ";
            }
        }
    }
}