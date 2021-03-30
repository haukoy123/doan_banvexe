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
    public partial class QLtuyen : System.Web.UI.Page
    {
        cs.adminDAL admin = new cs.adminDAL();
        tblnx nxe = new tblnx();
        tbltk tk = new tbltk();
        tblnv nv = new tblnv();
        tblTuyenxe tx = new tblTuyenxe();
        tblLichtrinh lt = new tblLichtrinh();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hien();
            }
        }

        protected void hien()
        {
            DataTable dt = admin.dsTuyenxe();
            grv_dstuyen.DataSource = dt;
            grv_dstuyen.DataBind();
        }

        protected void grv_dstuyen_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void sua_Click(object sender, EventArgs e)
        {
            hientttkdat.Visible = true;
            string matuyen = (sender as LinkButton).CommandArgument.ToString();
            DataTable dt = admin.dsTuyenxe();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (matuyen == dt.Rows[i]["matuyenxe"].ToString())
                {
                    lbmatuyen.Text = matuyen;
                    tb_tencx.Text = dt.Rows[i]["tentuyenxe"].ToString();
                    tb_tinhdi.Text = dt.Rows[i]["tinhdi"].ToString();
                    tb_tinhden.Text = dt.Rows[i]["tinhden"].ToString();
                    DateTime giokh = Convert.ToDateTime(dt.Rows[i]["giokh"].ToString());
                    tb_giokh.Text = giokh.ToString("hh\\:mm");
                    DateTime giokt = Convert.ToDateTime(dt.Rows[i]["gioden"].ToString());
                    tb_giokt.Text = giokt.ToString("hh\\:mm");
                    ddl_diemdung.Items.Clear();
                    dsdiemdung_tuyen(matuyen);
                }
            }
        }

        protected void btnthem_Click(object sender, EventArgs e)
        {
            hientttkdat.Visible = true;

        }

        protected void btntimkiem_Click(object sender, EventArgs e)
        {

        }

        protected void lbt_luu_Click(object sender, EventArgs e)
        {
            tx.tentx = tb_tencx.Text;
            tx.tinhdi = tb_tinhdi.Text;
            tx.tinhden = tb_tinhden.Text;
            tx.giokh = Convert.ToDateTime(tb_giokh.Text);
            tx.gioden = Convert.ToDateTime(tb_giokt.Text);

            if (lbmatuyen.Text == "")
            {
                DataTable dt = admin.dsTuyenxe();
                if (admin.themtuyen(tx))
                {
                    DataTable dt1 = admin.dsTuyenxe();
                    Response.Write("<script>alert('Thêm tuyến thành công!');</script>");
                    lbmatuyen.Text = matuyenmoi(dt1, dt);
                }
                else Response.Write("<script>alert('Thêm tuyến thất bại!');</script>");
            }
            else
            {
                tx.matx = lbmatuyen.Text;
                if(admin.updatetuyen(tx)){
                    Response.Write("<script>alert('Cập nhật tuyến thành công!');</script>");
                }
                else Response.Write("<script>alert('Cạp nhật tuyến thất bại!');</script>");
            }
        }

        public string matuyenmoi(DataTable table1, DataTable table2)
        {
            string matuyen = "";
            for (int i = 0; i < table1.Rows.Count; i++)
            {
                int ktra = 1;

                for (int j = 0; j < table2.Rows.Count; j++)
                {
                    if (table1.Rows[i]["matuyenxe"].ToString() == table2.Rows[j]["matuyenxe"].ToString())
                    {
                        ktra++;
                    }
                }
                if (ktra == 1)
                {
                    matuyen = table1.Rows[i]["matuyenxe"].ToString();
                }
            }
            return matuyen;
        }

        protected void lbt_thoat_Click(object sender, EventArgs e)
        {
            hientttkdat.Visible = false;
            tb_diemdung.Text = "";
            tb_gia.Text = "";
            lbmatuyen.Text = "";
            tb_tencx.Text = "";
            tb_tinhdi.Text = "";
            tb_tinhden.Text = "";
            tb_giokh.Text = "";
            tb_giokt.Text = "";
            ddl_diemdung.Items.Clear();
        }

        protected void lbtthemlt_Click(object sender, EventArgs e)
        {
            anhienthemlt(true, false, true, true, true);
        }

        protected void lbtsave_Click(object sender, EventArgs e)
        {
            anhienthemlt(false, true, false, false, false);
            lt.diemden = tb_diemdung.Text;
            lt.giave = int.Parse(tb_gia.Text);
            lt.trangthai = "Mở";
            lt.Fk_matx = lbmatuyen.Text;
            ddl_diemdung.Items.Clear();
            if (admin.themlichtrinh(lt))
            {
                dsdiemdung_tuyen(lbmatuyen.Text);
                tb_diemdung.Text = "";
                tb_gia.Text = "";
            }
            else Response.Write("<script>alert('Thêm lịch trình thất bại!');</script>");
        }

        public void dsdiemdung_tuyen(string matuyen)
        {
            DataTable diemdung = admin.get_dslichtrinh();
            for (int i = 0; i < diemdung.Rows.Count; i++)
            {
                if (matuyen == diemdung.Rows[i]["FK_matuyenxe"].ToString() 
                    && diemdung.Rows[i]["trangthai"].ToString()=="Mở")
                {
                    ddl_diemdung.Items.Add(new ListItem(diemdung.Rows[i]["diemden"].ToString()
                        + "; Giá:" + diemdung.Rows[i]["giave"].ToString() + " .đ",
                    diemdung.Rows[i]["malichtrinh"].ToString()));
                    //diemdung.Rows[i].Delete();
                }
            }
            //diemdung.AcceptChanges();
        }

        protected void lbtxoa_Click(object sender, EventArgs e)
        {
            anhienthemlt(false, true, false, false, false);
            lt.malt = ddl_diemdung.SelectedValue.ToString();
            DataTable ltr = admin.get_dslichtrinh();
            lt.trangthai = "Khóa";
            for (int i = 0; i < ltr.Rows.Count; i++)
            {
                if (lt.malt == ltr.Rows[i]["malichtrinh"].ToString())
                {
                    string matuyen =  ltr.Rows[i]["FK_matuyenxe"].ToString();
                    if (admin.updateltr(lt))
                    {
                        ddl_diemdung.Items.Clear();
                        dsdiemdung_tuyen(matuyen);
                        tb_diemdung.Text = "";
                        tb_gia.Text = "";
                    }
                }
            }
        }

        public void anhienthemlt(bool luu, bool them, bool xoa, bool gia, bool diemdung)
        {
            lbtsave.Visible = luu;
            lbtthemlt.Visible = them;
            lbtxoa.Visible = xoa;
            tb_gia.Enabled = gia;
            tb_diemdung.Enabled = diemdung;
        }

        protected void ddl_diemdung_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maltr = ddl_diemdung.SelectedValue.ToString();
             DataTable ltr = admin.get_dslichtrinh();
             for (int i = 0; i < ltr.Rows.Count; i++)
             {
                 if (maltr == ltr.Rows[i]["malichtrinh"].ToString())
                 {
                     tb_diemdung.Text = ltr.Rows[i]["diemden"].ToString();
                     tb_gia.Text = ltr.Rows[i]["giave"].ToString();
                 }
             }
        }

    }
}