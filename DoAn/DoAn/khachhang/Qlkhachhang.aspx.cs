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
    public partial class Qlkhachhang : System.Web.UI.Page
    {
        cs.adminDAL admin = new cs.adminDAL();
        tblKhachhang kh = new tblKhachhang();
        tbltk tk = new tbltk();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string tendn = Session["tendn"].ToString();
                view_textbox_ttkh(tendn);
            }

        }

        protected void view_textbox_ttkh(string tendn)
        {
            DataTable ttkh = admin.get_tt_khachhang(tendn);
            if (ttkh.Rows.Count == 1)
            {
                for (int i = 0; i < ttkh.Rows.Count; i++)
                {
                    txtTendn.Text = ttkh.Rows[i]["tendn"].ToString();
                    txtTenKH.Text = ttkh.Rows[i]["tenkh"].ToString();
                    string ns = ttkh.Rows[i]["ngaysinh"].ToString();

                    DateTime dt = Convert.ToDateTime(ns);
                    txtNgaysinh.Text = String.Format("{0:yyyy-MM-dd}", dt);

                    rd_gt_kh.ClearSelection();
                    string quyen = ttkh.Rows[i]["gioitinh"].ToString();
                    if (quyen.Equals("True"))
                    {
                        rd_gt_kh.Items.FindByText(" Nữ").Selected = true;
                    }
                    else rd_gt_kh.Items.FindByText(" Nam").Selected = true;

                    txtSdt.Text = ttkh.Rows[i]["sdt"].ToString();
                    txtDiachi.Text = ttkh.Rows[i]["diachi"].ToString();
                    txtEmail.Text = ttkh.Rows[i]["tendn"].ToString();
                    txtCmnd.Text = ttkh.Rows[i]["cmnd"].ToString();
                }

            }
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            kh.Makh = admin.getmakh(Session["tendn"].ToString());
            //Response.Write("<script>alert('" + kh.Makh + "');</script>");

            kh.tenkh = txtTenKH.Text;
            kh.ngaysinh = DateTime.Parse(txtNgaysinh.Text);
            kh.gioitinh = double.Parse(rd_gt_kh.SelectedValue.ToString());
            kh.sdt = txtSdt.Text;
            kh.diachi = txtDiachi.Text;
            kh.cmnd = txtCmnd.Text;

            if (admin.updateKH(kh))
            {
                Response.Write("<script>alert('Cập nhật thành công!');</script>");
            }
            else
            {
                Response.Write("<script>alert('Cập nhật thất bại!');</script>");
            }
        }
    }
}