using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAn.khachhang
{
    public partial class Khachhang : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tendn"].ToString().Equals(""))
            {
                btndndk.Visible = true;
                btnuser.Visible = false;
            }
            else
            {
                btndndk.Visible = false;
                btnuser.Visible = true;
            }
        }
    }
}