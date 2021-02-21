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
    public partial class ZDGZXXGL_Edit : System.Web.UI.Page
    {
        private UserState _usState;
        private int id;
        private string sjc;
        private ZDGZ zdgz;
        private Struct_ZDGZ struct_zdgz;
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

            zdgz = new ZDGZ(_usState);
            struct_zdgz = new Struct_ZDGZ();
          //  bsbh = Request.Params["bsbh"].ToString();


            if (!IsPostBack)
            {
                id = Convert.ToInt32(Request.Params["id"].ToString());
                sjc = Request.Params["sjc"].ToString();
              //  bind_enable();
                ddltBind();
                ddlt_Bind();
                tbx_bssj.Attributes.Add("readonly", "readonly");
                select_detail(id);
               
            }

        }
        private void ddlt_Bind()
        {
            
            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("13", _usState.userID, "130203");
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
            DataTable dt_bmdm = SysData.BM("130203", _usState.userID).Copy();
            ddlt_sjssbm.DataSource = dt_bmdm;
            ddlt_sjssbm.DataTextField = "bmmc";
            ddlt_sjssbm.DataValueField = "bmdm";
            ddlt_sjssbm.DataBind();
            ddlt_sjssbm.Items.Insert(0, new ListItem("请选择", "-1"));
        }
        private void ddltBind()
        {


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

        protected void select_detail(int id)
        {

            DataTable dt_detail = zdgz.SelectBS_ZDGZ_Detail(id);
            tbx_bsygbh.Text = dt_detail.Rows[0]["bsyg"].ToString();
            tbx_bsgw.Text = SysData.GWByKey(dt_detail.Rows[0]["bsgw"].ToString()).mc;
            tbx_bslx.Text = SysData.BSLXByKey(dt_detail.Rows[0]["bslx"].ToString()).mc;
          //  tbx_bsip.Text = dt_detail.Rows[0]["bsip"].ToString();
            tbx_bssj.Text = Convert.ToDateTime(dt_detail.Rows[0]["bssj"]).ToString("yyyy-MM-dd");
            ddlt_bszx.Text = dt_detail.Rows[0]["bszx"].ToString();
            ddlt_zxzx.Text = dt_detail.Rows[0]["zxzx"].ToString();
            tbx_gzfzr.Text = dt_detail.Rows[0]["xm"].ToString();
            tbx_gzlc.Text = dt_detail.Rows[0]["gzlc"].ToString();
            tbx_zdgznr.Text = dt_detail.Rows[0]["zdgznr"].ToString();
            tbx_bz.Text = dt_detail.Rows[0]["bz"].ToString();
            tbx_gzbt.Text = dt_detail.Rows[0]["gzbt"].ToString();
            ddlt_csr.SelectedValue = dt_detail.Rows[0]["csr"].ToString();//初审人
            ddlt_zsr.SelectedValue = dt_detail.Rows[0]["zsr"].ToString();//终审人
            ddlt_sjssbm.SelectedValue= dt_detail.Rows[0]["bmdm"].ToString();//数据所在部门
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
          
            DataTable dt_detail = zdgz.SelectBS_ZDGZ_Detail(id);
            struct_zdgz = new CUST.MKG.Struct_ZDGZ();
            struct_zdgz.p_bsbh = bsbh;
            struct_zdgz.p_bsyg = tbx_bsygbh.Text.ToString().Trim();
            //  struct_zdgz.p_bsgw = tbx_bsgw.Text .ToString ().Trim ();
            struct_zdgz.p_bsgw = _usState.userGWDM;
            struct_zdgz.p_bslx = "05";
            struct_zdgz.p_bsip = Page.Request.UserHostAddress;
            struct_zdgz.p_bssj = Convert.ToDateTime(tbx_bssj.Text.ToString().Trim());
            struct_zdgz.p_bszx = ddlt_bszx.SelectedValue.ToString ().Trim ();
            struct_zdgz.p_zdgznr = tbx_zdgznr.Text.ToString().Trim();
            struct_zdgz.p_zxzx = ddlt_zxzx.Text.ToString().Trim();
            //  struct_zdgz.p_gzfzr = tbx_gzfzr.Text.ToString().Trim();
            struct_zdgz.p_gzfzr = _usState.userLoginName;
            struct_zdgz.p_gzbt=tbx_gzbt.Text.ToString().Trim();
            struct_zdgz.p_gzlc = Convert.ToInt32(tbx_gzlc.Text.ToString().Trim());
            struct_zdgz.p_spr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
            struct_zdgz.p_bz = tbx_bz.Text.ToString().Trim();

            struct_zdgz.p_lrr = _usState.userLoginName;//录入人
            struct_zdgz.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_zdgz.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
            struct_zdgz.p_bmdm = ddlt_sjssbm.SelectedValue.ToString().Trim();
            struct_zdgz.p_czfs = "03";
            struct_zdgz.p_czxx = "位置：航务报送->重点工作->编辑   描述：员工编号：" + _usState.userLoginName;
                
            string sjbs = Request.Params["sjbs"].ToString();
            //如果是原始数据
            if (sjbs.Equals("0"))
            {
                //初审人录入的数据，状态默认为待终审
                if (struct_zdgz.p_lrr.Equals(struct_zdgz.p_csr))
                {
                    struct_zdgz.p_zt = "2";
                    struct_zdgz.p_sjbs = "0";
                    //给终审人添加提示
                    SysData.Insert_TSR(struct_zdgz.p_zsr, "13", "1302", id);
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_zdgz.p_lrr.Equals(struct_zdgz.p_zsr))
                {
                    struct_zdgz.p_zt = "3";
                    struct_zdgz.p_sjbs = "1";
                    SysData.Delete_TSR(struct_zdgz.p_zsr, "13", "1302", id);
                }
                if (!struct_zdgz.p_lrr.Equals(struct_zdgz.p_csr) && !struct_zdgz.p_lrr.Equals(struct_zdgz.p_zsr))
                {
                    struct_zdgz.p_zt = "0";
                    struct_zdgz.p_sjbs = "0";
                }
                zdgz.UpdateBS_ZDGZ(struct_zdgz);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
               
            }
            //如果是副本数据
            else if (sjbs.Equals("2"))
            {
                //初审人录入的数据，状态默认为待终审
                if (struct_zdgz.p_lrr.Equals(struct_zdgz.p_csr))
                {
                    struct_zdgz.p_zt = "2";
                    struct_zdgz.p_sjbs = "2";
                    SysData.Insert_TSR(struct_zdgz.p_zsr, "13", "1302", id);
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_zdgz.p_lrr.Equals(struct_zdgz.p_zsr))
                {
                    //将原最终数据变为历史数据
                    sjc = Request.Params["sjc"].ToString();
                    struct_zdgz.p_sjc = sjc;
                    zdgz.Update_ZDGZ_SJBS_LSSJ_ZT(struct_zdgz);

                    struct_zdgz.p_zt = "3";
                    struct_zdgz.p_sjbs = "1";
                    SysData.Delete_TSR(struct_zdgz.p_zsr, "13", "1302", id);
                }
                if (!struct_zdgz.p_lrr.Equals(struct_zdgz.p_csr) && !struct_zdgz.p_lrr.Equals(struct_zdgz.p_zsr))
                {
                    struct_zdgz.p_zt = "0";
                    struct_zdgz.p_sjbs = "2";
                }
                zdgz.UpdateBS_ZDGZ(struct_zdgz);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                
            }
            else if (sjbs.Equals("1"))
            {
                //生成该数据的副本,并返回新的备份id
                id = Convert.ToInt32(Request.Params["id"].ToString());
                int id_bf = zdgz.ZDGZ_SJBF(Convert.ToInt32(id));
                struct_zdgz.p_id = id_bf;


                //初审人录入的数据，状态默认为待终审
                if (struct_zdgz.p_lrr.Equals(struct_zdgz.p_csr))
                {
                    struct_zdgz.p_zt = "2";
                    struct_zdgz.p_sjbs = "2";
                    SysData.Insert_TSR(struct_zdgz.p_zsr, "13", "1302", id);
                }
                //终审人录入的数据，状态默认为审核通过
                if (struct_zdgz.p_lrr.Equals(struct_zdgz.p_zsr))
                {
                    //将原最终数据变为历史数据
                    sjc = Request.Params["sjc"].ToString();
                    struct_zdgz.p_sjc = sjc;
                    zdgz.Update_ZDGZ_SJBS_LSSJ_ZT(struct_zdgz);

                    struct_zdgz.p_zt = "3";
                    struct_zdgz.p_sjbs = "1";
                    SysData.Delete_TSR(struct_zdgz.p_zsr, "13", "1302", id);
                }
                if (!struct_zdgz.p_lrr.Equals(struct_zdgz.p_csr) && !struct_zdgz.p_lrr.Equals(struct_zdgz.p_zsr))
                {
                    struct_zdgz.p_zt = "0";
                    struct_zdgz.p_sjbs = "2";
                }

                zdgz.UpdateBS_ZDGZ(struct_zdgz);
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
            }
            else
            {
                return;
            }



            //try
            //{
            //    int check_rz = 0;

            //    DataRow dt_row = dt_detail.Rows[0];
            //    struct_zdgz.p_czxx = "位置:航务综合报送系统->重点工作信息->编辑  [报送编号：" + struct_zdgz.p_bsbh + "      描述：";
            //    if (struct_zdgz.p_bszx != dt_row["bszx"].ToString())
            //    {
            //        struct_zdgz.p_czxx += "报送支线：【" + SysData.ZXDMByKey(dt_row["bszx"].ToString()).ms + "】->【" + SysData.ZXDMByKey(struct_zdgz.p_bszx).ms + "】";
            //        check_rz = 1;
            //    }
            //    //if (struct_zdgz.p_bslx != dt_row["bslx"].ToString())
            //    //{
            //    //    struct_zdgz.p_czxx += "报送类型：【" + SysData.BSLXByKey(dt_row["bslx"].ToString()).ms + "】->【" + SysData.BSLXByKey(struct_zdgz.p_bslx).ms + "】";
            //    //    check_rz = 1;
            //    //}

            //    if (struct_zdgz.p_bssj != Convert.ToDateTime(dt_row["bssj"]))
            //    {
            //        struct_zdgz.p_czxx += "报送时间：【" + dt_row["bssj"].ToString() + "】->【" + struct_zdgz.p_bssj + "】";
            //        check_rz = 1;
            //    }

            //    if (struct_zdgz.p_zdgznr != dt_row["zdgznr"].ToString())
            //    {
            //        struct_zdgz.p_czxx += "工作内容：【" + dt_row["zdgznr"].ToString() + "】->【" + struct_zdgz.p_zdgznr + "】";
            //        check_rz = 1;
            //    }
            //    if (struct_zdgz.p_zxzx != dt_row["zxzx"].ToString())
            //    {
            //        struct_zdgz.p_czxx += "执行支线：【" + SysData.ZXDMByKey(dt_row["zxzx"].ToString()).ms + "】->【" + SysData.ZXDMByKey(struct_zdgz.p_zxzx).ms + "】";
            //        check_rz = 1;
            //    }
            //    if (struct_zdgz.p_gzfzr != dt_row["gzfzr"].ToString())
            //    {
            //        struct_zdgz.p_czxx += "完成进度：【" + dt_row["gzfzr"].ToString() + "】->【" + struct_zdgz.p_gzfzr + "】";
            //        check_rz = 1;
            //    }
            //    if (struct_zdgz.p_gzlc != dt_row["gzlc"].ToString())
            //    {
            //        struct_zdgz.p_czxx += "工作轮次：【" + dt_row["gzlc"].ToString() + "】->【" + struct_zdgz.p_gzlc + "】";
            //        check_rz = 1;
            //    }
            //    if (struct_zdgz.p_bz != dt_row["bz"].ToString())
            //    {
            //        struct_zdgz.p_czxx += "备注：【" + dt_row["bz"].ToString() + "】->【" + struct_zdgz.p_bz + "】";
            //        check_rz = 1;
            //    }
            //    if (struct_zdgz.p_gzbt != dt_row["gzbt"].ToString())
            //    {
            //        struct_zdgz.p_czxx += "工作标题：【" + dt_row["gzbt"].ToString() + "】->【" + struct_zdgz.p_gzbt+ "】";
            //        check_rz = 1;
            //    }

            //    if (check_rz == 0)
            //    {
            //        Response.Write("<script>window.location.href='ZDGZXXGL.aspx';</script>");
            //    }
            //    else
            //    {
            //        struct_zdgz.p_czfs = "02";
            //        zdgz.UpdateBS_ZDGZ(struct_zdgz);
            //        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
            //        tbx_bsgw.Enabled = false; 
            //        tbx_bssj.Enabled = false;
            //        ddlt_zxzx.Enabled = false;
            //        tbx_zdgznr.Enabled = false;
            //        ddlt_bszx.Enabled = false;
            //        tbx_gzlc.Enabled = false;
            //        tbx_bz.Enabled = false;
            //        btn_save.Visible = false;
            //        tbx_gzbt.Enabled = false;
            //        ChangeFlag.Value = "false";
            //    }



            //}
            //catch (EMException ex)
            //{
            //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));


            //    return;
            //}



        }

        //protected void btn_bj_Click(object sender, EventArgs e)
        //{
        //    tbx_bsgw.Enabled = true;   
        //    tbx_bssj.Enabled = true;
        //    ddlt_bszx.Enabled = true;
        //    tbx_zdgznr.Enabled = true;
        //    ddlt_zxzx.Enabled = true;
        //    tbx_gzlc.Enabled = true;
        //    tbx_bz.Enabled = true;
        //    btn_save.Visible = true;
        //    tbx_gzbt.Enabled = true;
        //    ChangeFlag.Value = "true";
        //}
        protected void bind_enable()
        {
            tbx_bsgw.Enabled = false;
            tbx_bssj.Enabled = false;
            ddlt_zxzx.Enabled = false;
            tbx_zdgznr.Enabled = false;
            ddlt_bszx.Enabled = false;
            tbx_gzlc.Enabled = false;
            tbx_bz.Enabled = false;
            btn_save.Visible = false;
            tbx_gzbt.Enabled = false;
            ChangeFlag.Value = "false";
        }
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("ZDGZXXGL.aspx", true);
        }
    }
}