using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CUST.Sys;
using System.Data;
using CUST;
using CUST.Tools;
using CUST.MKG;
using Sys;
using System.Collections;

namespace CUST.WKG
{
    public partial class YLGL_Detail : System.Web.UI.Page
    {
        private UserState _usState;
        private YLGL ylgl;
        private Struct_YLGL struct_ylgl;
        private string sjc;
        private int ylbh;
        private int bh;
        private static DataTable dt_detail;
        private static string syrbh;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            ylgl = new YLGL(_usState);
            struct_ylgl = new Struct_YLGL();
            ylbh = Convert.ToInt32(Request.Params["bh"]);
            bh = Convert.ToInt32(Request.Params["bh"]);
            if (!IsPostBack)
            {
                
                select_detail(ylbh);
                
            }
        }
        protected void select_detail(int bh)
        {
            dt_detail = ylgl.Select_Ylgl_Detail(bh);
            dt_detail.Columns.Add("syrxm");
            string yh = dt_detail.Rows[0]["cyry"].ToString();
            yh = yh.Substring(0, yh.Length - 1);
            foreach (DataRow dr in dt_detail.Rows)
            {
                string[] Array_syr = yh.Split(',');
                foreach (string syrxm_dm in Array_syr)
                {
                    dr["syrxm"] += ylgl.Select_YGXMbyBH(syrxm_dm.ToString()).Rows[0][0].ToString() + ",";
                }
            }
            lbl_cyry.Text = dt_detail.Rows[0]["syrxm"].ToString();
            lbl_ylsj.Text = Convert.ToDateTime(dt_detail.Rows[0]["ylsj"]).ToString("yyyy-MM-dd");
            lbl_zxmc.Text = SysData.ZXDMByKey(dt_detail.Rows[0]["dq"].ToString()).mc;
            lbl_ylxs.Text = SysData.YLXSByKey(dt_detail.Rows[0]["ylxs"].ToString()).mc;
            //ddlt_yam.SelectedValue = dt_detail.Rows[0]["yam"].ToString();
            lbl_yam.Text = dt_detail.Rows[0]["mc"].ToString();
            lbl_sjszbm.Text = dt_detail.Rows[0]["bmmc"].ToString();
            lbl_lrr.Text = dt_detail.Rows[0]["lrrxm"].ToString();//录入人
            lbl_csr.Text = dt_detail.Rows[0]["csrxm"].ToString();//初审人
            lbl_zsr.Text = dt_detail.Rows[0]["zsrxm"].ToString();//终审人
            lbl_ylnr.Text = dt_detail.Rows[0]["ylnr"].ToString();
            lbl_ylzj.Text = dt_detail.Rows[0]["ylzj"].ToString();
            lbl_bhyy.Text = dt_detail.Rows[0]["bhyy"].ToString();
            lbl_yanr.Text = dt_detail.Rows[0]["yanr"].ToString();
            lbl_zt.Text = SysData.ZTDMByKey(dt_detail.Rows[0]["zt"].ToString()).mc;//状态
        }
        protected void Page_Error(object sender, EventArgs e)
        {
            try
            {
                Response.Clear();
                Response.Write(EMException.ShowErrorScript(Server.GetLastError()));
                Response.Write(StrConvert.ShowScript("history.back();"));
                Response.End();
            }
            finally
            {
                Server.ClearError();
            }
        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Yingji/YLGL_GL.aspx");

        }
    }
}