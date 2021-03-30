using DoAn.cs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAn
{
    public partial class QLDatveKH : System.Web.UI.Page
    {

        cs.adminDAL admin = new cs.adminDAL();
        tblKhachhang kh = new tblKhachhang();
        tbltk tk = new tbltk();
        tblVexe vx = new tblVexe();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hiendscx();
            }
        }
        protected void hiendscx()
        {
            DataTable dt = dscxsapdi();
            if (dt.Rows.Count == 0)
            {
                a.Visible = true;
                a.Text = "Không có dữ liệu!!!";
            }
            else
            {
                a.Visible = false;
            }
            dlDsChuyenxe.DataSource = dt;
            dlDsChuyenxe.DataBind();

        }
        public DataTable dscxsapdi()
        {
            string tt = "Sắp đi";
            DataTable dt = admin.tt_chuyenxe();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (tt != dt.Rows[i]["trangthai"].ToString() || Convert.ToDateTime(dt.Rows[i]["Ngaydi"].ToString()) < DateTime.Now)
                {
                    dt.Rows[i].Delete();
                }
            }
            dt.AcceptChanges();
            return dt;
        }

        protected void btnDatve_Click(object sender, EventArgs e)
        {
            string ma = (sender as LinkButton).CommandArgument.ToString();
            string[] arg = new string[4];
            arg = ma.Split(';');
            ma = arg[0];
            string machuyen = arg[1];
            Session["Macx"] = machuyen;

            string ngay = arg[2];
            string giodi = arg[3];
            string gioden = arg[4];

            ftt_datve.Visible = true;
            ddlLichtrinh.Items.Clear();
            ddlLichtrinh.Items.Add(new ListItem("---------Lịch Trình--------", ""));
            ddlLichtrinh.Items.FindByValue("").Selected = true;

            DataTable dt = hien_ddllichtrinh(ma.ToString());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlLichtrinh.Items.Add(new ListItem(dt.Rows[i]["diemden"].ToString() + "; Giá: " + dt.Rows[i]["giave"].ToString(),
                    dt.Rows[i]["malichtrinh"].ToString()));
            }
            txtCX.Text = arg[1];
            txtNgaydi.Text = arg[2];
            txtGiodi.Text = arg[3];
            txtGioden.Text = arg[4];
            txtTrangthai.Text = "Đã đặt";
        }

        protected void btndv_Click(object sender, EventArgs e)
        {
            //vx.Fk_macx = admin.tt_chuyenxe().ToString();
            vx.Fk_macx = Session["Macx"].ToString();
            vx.Fk_matk = int.Parse(admin.getmatk(Session["tendn"].ToString()));

            vx.tenkh = txtTenkh.Text;
            vx.sdt = txtSdt.Text;
            vx.thoigiandatve = DateTime.Now;
            vx.soghe = int.Parse(txtSoluong.Text);
            string malt = ddlLichtrinh.SelectedValue.ToString();

            DataTable dt = admin.get_dslichtrinh();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (malt == dt.Rows[i]["malichtrinh"].ToString())
                {
                    vx.diemden = dt.Rows[i]["diemden"].ToString();
                }
            }
            vx.tongtien = int.Parse(txtTongtien.Text);
            vx.trangthai = txtTrangthai.Text;

            string ktra_tk = admin.getmatk(Session["tendn"].ToString());
            if (ktra_tk == "")
            {
                Response.Write("<script>alert('Bạn hãy đăng nhập để đặt vé!');</script>");
            }
            else
            {
                if (admin.themvx(vx))
                {
                    tbnull();
                    Response.Write("<script>alert('Đặt vé thành công!');</script>");
                    ftt_datve.Visible = false;
                }
                else
                {
                    Response.Write("<script>alert('Đặt vé thất bại!');</script>");
                }
            }
        }
        public void tbnull()
        {
            txtTenkh.Text = "";
            txtSdt.Text = "";
            txtCX.Text = "";
            txtNgaydi.Text = "";
            txtTrangthai.Text = "";
            txtGiodi.Text = "";
            txtGioden.Text = "";
            txtSoluong.Text = "";
            ddlLichtrinh.ClearSelection();
            txtTongtien.Text = "";

        }
        protected void btnHuy_Click(object sender, EventArgs e)
        {
            ftt_datve.Visible = false;
            tbnull();
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
            dstl.DefaultView.Sort = "giave DESC";
            return dstl;
        }
        public int hien_ghetrong(string machuyen)
        {
            DataTable dt = admin.get_cx_vx();
            int tongghe = 0;
            int ghe = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (machuyen == dt.Rows[i]["machuyenxe"].ToString())
                {
                    tongghe = tongghe + int.Parse(dt.Rows[i]["soghe"].ToString());
                    ghe = int.Parse(dt.Rows[i]["sg"].ToString());
                }
            }
            int gt = ghe - tongghe;
            return gt;
        }

        protected void ddlLichtrinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtSoluong.Text != "")
            {
                string malt = ddlLichtrinh.SelectedValue.ToString();
                int giave = 0;
                DataTable dt = admin.tt_lt();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (malt == dt.Rows[i]["malichtrinh"].ToString())
                    {
                        giave = int.Parse(dt.Rows[i]["giave"].ToString());
                    }
                }
                int soghe = int.Parse(txtSoluong.Text);
                int tong = soghe * giave;
                txtTongtien.Text = tong.ToString();
            }
        }

        public DataTable tk_diadiem(DataTable table)
        {
            if (txtDiemdi.Text == "" && txtDiemden.Text == "")
            {
                return table;
            }
            else
            {
                DataTable dscx_t = admin.get_dslichtrinh_diadiem(txtDiemdi.Text, txtDiemden.Text);
                int ktra = 0;
                DataTable dscx = table.Clone();
                for (int i = 0; i < dscx_t.Rows.Count; i++)
                {
                    for (int j = 0; j < table.Rows.Count; j++)
                    {
                        if (table.Rows[j]["matuyenxe"].ToString() == dscx_t.Rows[i]["matuyenxe"].ToString())
                        {
                            for (int n = 0; n < dscx.Rows.Count; n++)
                            {
                                if (dscx.Rows[n]["machuyenxe"].ToString() == table.Rows[j]["machuyenxe"].ToString())
                                {
                                    ktra++;
                                }
                            }
                            if (ktra == 0)
                            {
                                dscx.ImportRow(table.Rows[j]);
                                ktra = 0;
                            }
                        }
                    }
                }
                return dscx;
            }
        }

        public DataTable chuyenxe_ngaydi(DataTable table)
        {
            if (txtThoigian.Text != "")
            {
                DateTime ngaydi = Convert.ToDateTime(txtThoigian.Text);
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

        protected void btnTimve_Click(object sender, EventArgs e)
        {
            DataTable table = dscxsapdi();
            DataTable dt1 = chuyenxe_ngaydi(table);
            DataTable dt = tk_diadiem(dt1);
            if (dt.Rows.Count == 0)
            {
                a.Visible = true;
                a.Text = "Không có dữ liệu!";
            }
            else
            {
                a.Visible = false;
            }
            dlDsChuyenxe.DataSource = dt;
            dlDsChuyenxe.DataBind();
        }

        protected void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            if (ddlLichtrinh.SelectedValue.ToString() != "")
            {
                string malt = ddlLichtrinh.SelectedValue.ToString();
                int giave = 0;
                DataTable dt = admin.tt_lt();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (malt == dt.Rows[i]["malichtrinh"].ToString())
                    {
                        giave = int.Parse(dt.Rows[i]["giave"].ToString());
                    }
                }
                int soghe = int.Parse(txtSoluong.Text);
                int tong = soghe * giave;
                txtTongtien.Text = tong.ToString();
            }
        }
    }
}