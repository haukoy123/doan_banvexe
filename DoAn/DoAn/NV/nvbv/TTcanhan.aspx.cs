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
    public partial class TTcanhan : System.Web.UI.Page
    {
        cs.adminDAL admin = new cs.adminDAL();
        tblnv nv = new tblnv();
        tbltk tk = new tbltk();
        tblnx nx = new tblnx();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string tendn = Session["tendn"].ToString();
                hien(tendn);
            }
        }

        protected void hien(string tendn)
        {
            DataTable dt = admin.get_ttnv_tknx(tendn);
            if (dt.Rows.Count == 1)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    txtMatk.Text = dt.Rows[i]["mataikhoan"].ToString();
                    txtTendn.Text = dt.Rows[i]["tendn"].ToString();
                    txtTennx.Text = dt.Rows[i]["tennx"].ToString();
                    txtBophan.Text = dt.Rows[i]["bophan"].ToString();

                    txtManv.Text = dt.Rows[i]["manv"].ToString();
                    txtTenv.Text = dt.Rows[i]["tennv"].ToString();
                    txtNgaysinh.Text = dt.Rows[i]["ngaysinh"].ToString();
                    DateTime ns = Convert.ToDateTime(dt.Rows[i]["ngaysinh"].ToString());
                    txtNgaysinh.Text = String.Format("{0:yyyy-MM-dd}", ns);

                    rdGioitinh.ClearSelection();
                    string gt = dt.Rows[i]["gioitinh"].ToString();
                    if (gt.Equals("True"))
                    {
                        rdGioitinh.Items.FindByText(" Nữ").Selected = true;
                    }
                    else rdGioitinh.Items.FindByText(" Nam").Selected = true;

                    txtDiachi.Text = dt.Rows[i]["diachi"].ToString();
                    txtEmail.Text = dt.Rows[i]["tendn"].ToString();
                    txtSdt.Text = dt.Rows[i]["sdt"].ToString();
                    txtCmnd.Text = dt.Rows[i]["cmnd"].ToString();
                }
            }
        }

        protected void lbtnLuu_Click(object sender, EventArgs e)
        {
            nv.Manv = admin.getmanv(Session["tendn"].ToString());
            nv.Tennv = txtTenv.Text;
            nv.Ngaysinh = DateTime.Parse(txtNgaysinh.Text);
            nv.Gioitinh = double.Parse(rdGioitinh.SelectedValue.ToString());
            nv.Sdt = txtSdt.Text;
            nv.Diachi = txtDiachi.Text;
            nv.Cmt = txtCmnd.Text;
            nv.Email = txtEmail.Text;
            nv.Fk_manx = manx();
            nv.Fk_matk = int.Parse(admin.getmatk(Session["tendn"].ToString()));
            nv.Bophan = txtBophan.Text;



            if (admin.updateNv(nv))
            {
                Response.Write("<script>alert('Cập nhật thành công!');</script>");
            }
            else
            {
                Response.Write("<script>alert('Cập nhật thất bại!');</script>");
            }
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

    }
}