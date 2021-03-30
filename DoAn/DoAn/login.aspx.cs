using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAn
{
    public partial class login : System.Web.UI.Page
    {
        string constr = @"Data Source=TRANHAU-PC;Initial Catalog=db_QLBanve;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("dangnhap", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tendn", Request["tendangnhap"].ToString());
                    cmd.Parameters.AddWithValue("@mk", Request["password"].ToString());
                    SqlDataReader rd = cmd.ExecuteReader();

                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            string quyen = rd["FK_maquyen"].ToString();
                            //Response.Write("quyền: " + quyen);
                            Session["tendn"] = rd["tendn"].ToString();
                            Session["quyen"] = quyen;

                            //Response.Write(Session["tendn"] + "\n" + Session["quyen"]);
                            switch (quyen)
                            {
                                case "Q00001":
                                    Response.Redirect("~/NV/nvdh/trangchu_nvdh.aspx");
                                    break;
                                case "Q00002":
                                    Response.Redirect("~/admin/homeadmin.aspx");
                                    break;
                                case "Q00003": 
                                    Response.Redirect("~/index.aspx");
                                    break;
                                case "Q00004":
                                    Response.Redirect("~/NV/nvxe/trangchunvxe.aspx");
                                    break;
                                case "Q00005":
                                    Response.Redirect("~/NV/nvbv/TTcanhan.aspx");
                                    break;
                            }
                        }
                    }
                    else
                    {
                        lbdnsai.Text = "Tên đăng nhập hoặc mật khẩu sai!";
                        
                    }
                }
            }
        }

        protected void btnThoat_Click(object sender, EventArgs e)
        {

        }

      
    }
}