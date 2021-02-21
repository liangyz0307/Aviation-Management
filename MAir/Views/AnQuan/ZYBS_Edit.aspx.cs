using CUST.MKG;
using CUST.Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using Sys;


namespace CUST.WKG
{
    public partial class ZYBS_Edit : System.Web.UI.Page
    {
        private UserState _usState;
        private ZYBS zybs;
        private Struct_ZYBS struct_zybs;
        private string bsbh;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            //if (_usState.userSFSCDL == "0")
            //{
            //    Response.Write("<script>alert(\"您当前是首次登陆本系统，只有修改密码后才能使用。！\");window.top.location.href='PersonPwdXG.aspx';</script>");
            //    Response.End();
            //    return;
            //}

            zybs = new ZYBS(_usState);
            struct_zybs = new Struct_ZYBS();
            bsbh = Request.Params["bsbh"].ToString();
            if (!IsPostBack)
            {
                bind_drop();
                select_detail(bsbh);
            }

        }
        protected void bind_drop()
        {
            //报送类型
            ddlt_bslx.DataTextField = "mc";
            ddlt_bslx.DataValueField = "bm";
            ddlt_bslx.DataSource = SysData.BSLX().Copy();
            ddlt_bslx.DataBind();
            ddlt_bslx.Items.Insert(0, new ListItem("全部", "-1"));
        }
        protected void select_detail(string sbbh)
        {
            lbl_bsyg.Text = _usState.userXM;
            lbl_bsgw.Text = _usState.userGWMC;
            DataTable dt_detail = zybs.SelectBS_ZYBS_Detail(bsbh);
            ddlt_bslx.SelectedValue= SysData.BSLXByKey(dt_detail.Rows[0]["bslx"].ToString()).mc;
            tbx_bssj.Text = Convert.ToDateTime(dt_detail.Rows[0]["bssj"]).ToString("yyyy-MM-dd");
            tbx_bsms.Text = dt_detail.Rows[0]["bsms"].ToString();
            tbx_jjfa.Text = dt_detail.Rows[0]["jjfa"].ToString(); 
            tbx_bz.Text = dt_detail.Rows[0]["bz"].ToString();

        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            DataTable dt_detail = zybs.SelectBS_ZYBS_Detail(bsbh);
            struct_zybs = new CUST.MKG.Struct_ZYBS();
            struct_zybs.p_bsbh = bsbh;
            struct_zybs.p_bsyg = "";// tbx_bsygbh.Text.ToString().Trim();
            struct_zybs.p_bsgw = "";// tbx_bsgw.Text.ToString().Trim();
            struct_zybs.p_bslx = dt_detail.Rows[0]["bslx"].ToString();
            struct_zybs.p_bsip = "";// tbx_bsip.Text.ToString().Trim();
            struct_zybs.p_bssj = Convert.ToDateTime(tbx_bssj.Text.ToString().Trim());
            struct_zybs.p_bsms = tbx_bsms.Text.ToString().Trim();
            struct_zybs.p_jjfa = tbx_jjfa.Text.ToString().Trim();

            struct_zybs.p_spr = "";
            struct_zybs.p_bz = tbx_bz.Text.ToString().Trim();
            try
            {
                int check_rz = 0;
              
                DataRow dt_row = dt_detail.Rows[0];
                struct_zybs.p_czxx = "位置:航务综合报送系统->自愿报送信息->编辑  [报送编号：" + struct_zybs.p_bsbh + "      描述：";
          
                if (struct_zybs.p_bssj != Convert.ToDateTime(dt_row["bssj"]))
                {
                    struct_zybs.p_czxx += "报送时间：【" + dt_row["bssj"].ToString() + "】->【" + struct_zybs.p_bssj + "】";
                    check_rz = 1;
                }
                if (struct_zybs.p_bsms != dt_row["bsms"].ToString())
                {
                    struct_zybs.p_czxx += "报送模式：【" + dt_row["bsms"].ToString() + "】->【" + struct_zybs.p_bsms + "】";
                    check_rz = 1;
                }
                if (struct_zybs.p_jjfa != dt_row["jjfa"].ToString())
                {
                    struct_zybs.p_czxx += "解决方案：【" + dt_row["jjfa"].ToString() + "】->【" + struct_zybs.p_jjfa + "】";
                    check_rz = 1;
                }
              
                if (struct_zybs.p_bz != dt_row["bz"].ToString())
                {
                    struct_zybs.p_czxx += "备注：【" + dt_row["bz"].ToString() + "】->【" + struct_zybs.p_bz + "】";
                    check_rz = 1;
                }

                if (check_rz == 0)
                {
                    Response.Write("<script>window.location.href='GZJZXXGL.aspx';</script>");
                }
                else
                {
                    struct_zybs.p_czfs = "02";
                    zybs.UpdateBS_ZYBS(struct_zybs);
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                  
                }



            }
            catch (EMException ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));


                return;
            }
        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("ZYBSGL.aspx", true);
        }
    }
}