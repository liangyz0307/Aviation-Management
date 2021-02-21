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
using System.Text.RegularExpressions;
using Sys;
using System.Globalization;

namespace CUST.WKG
{
    public partial class ZDGZXXGL_Add : System.Web.UI.Page
    {
        private UserState _usState;
        private string id;
        private ZDGZ zdgz;
        private Struct_ZDGZ struct_zdgz;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            zdgz = new ZDGZ(_usState);

            if (!IsPostBack)
            {
               texBind();
                ddltBind();
                ddlt_Bind();
                tbx_bssj.Attributes.Add("readonly", "readonly");

            }
        }
        private void texBind()
        {
            tbx_bsygbh.Text = _usState.userLoginName;
          //  tbx_bsip.Text = Page.Request.UserHostAddress;
            tbx_bsgw.Text = _usState.userGWMC;
            tbx_gzfzr.Text = zdgz.SelectBS_FZR_byBMDM(_usState.userBMDM).Rows[0]["xm"].ToString();
            //tbx_bslx.Text = SysData.BSLXByKey("05").mc;

        }
        private void ddlt_Bind()
        {
           

            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("13", _usState.userID, "130202");

            //初审人
            ddlt_csr.DataSource = dt_spr;
            ddlt_csr.DataTextField = "mc";
            ddlt_csr.DataValueField = "bm";
            ddlt_csr.DataBind();
            ddlt_csr.Items.Insert(0, new ListItem("请选择", "-1"));


            //终审人
            ddlt_zsr.DataSource = dt_spr;
            ddlt_zsr.DataTextField = "mc";
            ddlt_zsr.DataValueField = "bm";
            ddlt_zsr.DataBind();
            ddlt_zsr.Items.Insert(0, new ListItem("请选择", "-1"));


            //数据所在部门
            DataTable dt_bmdm = SysData.BM("130202", _usState.userID).Copy();
            ddlt_sjssbm.DataSource = dt_bmdm;
            ddlt_sjssbm.DataTextField = "bmmc";
            ddlt_sjssbm.DataValueField = "bmdm";
            ddlt_sjssbm.DataBind();
            ddlt_sjssbm.Items.Insert(0, new ListItem("请选择", "-1"));
        }
        private void ddltBind()
        {

            //绑定报送类型
            ddlt_bslx.DataTextField = "mc";
            ddlt_bslx.DataValueField = "bm";
            ddlt_bslx.DataSource = SysData.BSLX().Copy();
            ddlt_bslx.DataBind();
            ddlt_bslx.Items.Insert(0, new ListItem("请选择", "-1"));

            //绑定报送支线
            ddlt_bszx.DataTextField = "mc";
            ddlt_bszx.DataValueField = "bm";
            ddlt_bszx.DataSource = SysData.ZXDM().Copy();
            ddlt_bszx.DataBind();
            ddlt_bszx.Items.Insert(0, new ListItem("请选择", "-1"));


            //绑定执行支线
            ddlt_zxzx.DataTextField = "mc";
            ddlt_zxzx.DataValueField = "bm";
            ddlt_zxzx.DataSource = SysData.ZXDM().Copy();
            ddlt_zxzx.DataBind();
            ddlt_zxzx.Items.Insert(0, new ListItem("请选择", "-1"));


        }
        protected void btn_save_Click(object sender, EventArgs e)
        {

            try
            {
                struct_zdgz = new CUST.MKG.Struct_ZDGZ();
                struct_zdgz.p_bsbh = _usState.userGWDM + zdgz.SelectBS_ZDGZMaxBH();
                struct_zdgz.p_bsyg = tbx_bsygbh.Text.ToString().Trim();
                struct_zdgz.p_bsgw = _usState.userGWDM;
                struct_zdgz.p_bszx = ddlt_bszx.SelectedValue;
                //struct_zdgz.p_bslx = "05";
                struct_zdgz.p_bslx = ddlt_bslx.SelectedValue.ToString().Trim();
                struct_zdgz.p_bsip = Page.Request.UserHostAddress;
                struct_zdgz.p_bssj = Convert.ToDateTime(tbx_bssj.Text.ToString().Trim());
                struct_zdgz.p_gzbt = tbx_gzbt.Text.ToString();
                struct_zdgz.p_zdgznr = tbx_zdgznr.Text.ToString().Trim();
                struct_zdgz.p_zxzx = ddlt_zxzx.Text.ToString().Trim();
                struct_zdgz.p_gzfzr = zdgz.SelectBS_FZR_byBMDM(_usState.userBMDM).Rows[0]["fzr"].ToString();
                struct_zdgz.p_gzlc = Convert.ToInt32(tbx_gzlc.Text.ToString().Trim());
                struct_zdgz.p_spr = ddlt_zsr.SelectedValue.ToString().Trim();
                struct_zdgz.p_bz = tbx_bz.Text.ToString().Trim();

                struct_zdgz.p_bmdm = ddlt_sjssbm.SelectedValue.ToString().Trim();//数据所在部门
                struct_zdgz.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
                struct_zdgz.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
                
                struct_zdgz.p_lrr = _usState.userLoginName.ToString();//录入人
                
                //如果是初审人录入数据，则状态默认初审通过，即待终审
                if (struct_zdgz.p_lrr.Equals(struct_zdgz.p_csr))
                {
                    struct_zdgz.p_sjbs = "0";
                    struct_zdgz.p_zt = "2";
                    //给终审人添加提示
                    SysData.Insert_TSR(struct_zdgz.p_zsr, "13", "1302", -1);
                }
                //如果是终审人录入数据，则状态为审核通过
                if (struct_zdgz.p_lrr.Equals(struct_zdgz.p_zsr))
                {
                    struct_zdgz.p_sjbs = "1";
                    struct_zdgz.p_zt = "3";
                }
                if (!struct_zdgz.p_lrr.Equals(struct_zdgz.p_csr) && !struct_zdgz.p_lrr.Equals(struct_zdgz.p_zsr))
                {
                    struct_zdgz.p_sjbs = "0";
                    struct_zdgz.p_zt = "0";
                }
                struct_zdgz.p_sjc = DateTime.Now.ToString("yyyyMMddHHmmssee", DateTimeFormatInfo.InvariantInfo);//时间戳



                struct_zdgz.p_czfs = "02";
                struct_zdgz.p_czxx = "位置：航务综合报送系统->重点工作信息->添加      描述：报送员工编号：" + struct_zdgz.p_bsyg + "报送岗位："
                    + struct_zdgz.p_bsgw + "支线名称：" + struct_zdgz.p_bszx + "报送类型：" + struct_zdgz.p_bslx + "报送IP：" + struct_zdgz.p_bsip + "报送时间:" + struct_zdgz.p_bssj
                    + "重点工作内容：" + struct_zdgz.p_zdgznr + "执行支线：" + struct_zdgz.p_zxzx + "工作负责人：" + struct_zdgz.p_gzfzr
                    + "工作轮次：" + struct_zdgz.p_gzlc + "审批人" + struct_zdgz.p_spr + "备注" + struct_zdgz.p_bz;
                zdgz.InsertBS_ZDGZ(struct_zdgz);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");

                tbx_bssj.Text = string.Empty;
                ddlt_bszx.SelectedValue = "-1";
                tbx_zdgznr.Text = string.Empty;
                ddlt_zxzx.SelectedValue = "-1";
               
                tbx_gzlc.Text = string.Empty;
                tbx_bz.Text = string.Empty;
            }
            catch (EMException ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));

                return;
            }



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
            Response.Redirect("ZDGZXXGL.aspx", true);
        }
    }
}