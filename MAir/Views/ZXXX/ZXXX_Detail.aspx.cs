using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class ZXXX_Detail : System.Web.UI.Page
    {
        public string viedo;
        public string PlayUrl;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string wjm =Request.QueryString["wjm"];
                viedo = "../../../UEdit/utf8-net/net/upload/video/" + wjm + ".mp4";
            }
         }
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../Views/ZXXX/ZXXX_SP.aspx");
        }
    }
}