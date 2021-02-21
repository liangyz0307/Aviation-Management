using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using CUST.WKG;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class SKJS_SBBLK_Edit : System.Web.UI.Page
    {
        private UserState _usState;
       // private UserState _us;
        private SBBLK sbblk;
        private Struct_SBBLK struct_sbblk;
       // private static string  p_id;
        private int id;
        private static DataTable dt_detail;
        static string wxrybh;
        static string syrbh;
        protected void Page_Load(object sender, EventArgs e)
        {
            if((_usState = (Session["UserState"]as UserState))==null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时!\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            sbblk = new SBBLK(_usState);
            struct_sbblk = new Struct_SBBLK();
            if(!IsPostBack)
            {
                // id = Request.QueryString["id"];
                id = Convert.ToInt32(Request.Params["id"].ToString());
                ddltBind();
                bind_drop();
                select_detail();

            }
        }
        private void ddltBind()
        {
            //保养频次
            ddlt_bypc.DataSource = SysData.BYPC().Copy();
            ddlt_bypc.DataTextField = "mc";
            ddlt_bypc.DataValueField = "bm";
            ddlt_bypc.DataBind();


            //初始化审批人
            DataTable dt_spr = SysData.HasThisZXT_SPR("20");
            //初审人
            ddlt_csr.DataSource = dt_spr;
            ddlt_csr.DataTextField = "mc";
            ddlt_csr.DataValueField = "bm";
            ddlt_csr.DataBind();

            //终审人
            ddlt_zsr.DataSource = dt_spr;
            ddlt_zsr.DataTextField = "mc";
            ddlt_zsr.DataValueField = "bm";
            ddlt_zsr.DataBind();

            //数据所在部门
            ddlt_sjszbm.DataSource = SysData.BM().Copy();
            ddlt_sjszbm.DataTextField = "mc";
            ddlt_sjszbm.DataValueField = "bm";
            ddlt_sjszbm.DataBind();
            ddlt_sjszbm.Items.Insert(0, new ListItem("全部", "-1"));

        }
        protected void btn_bc_syr_Click(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            string yg = ddlt_syr.SelectedValue.ToString();
            //ddlt_syr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_syr.Items.Count > 0)
            {
                tbx_syr.Text += ddlt_syr.SelectedItem.Text + ",";
                syrbh += ddlt_syr.SelectedValue.ToString() + ",";
            }
        }
        protected void btn_bc_wxry_Click(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm_wxry.SelectedValue.ToString();
            string gwdm = ddlt_gwdm_wxry.SelectedValue.ToString();
            string yg = ddlt_wxry.SelectedValue.ToString();
            //ddlt_syr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_wxry.Items.Count > 0)
            {
                tbx_wxry.Text += ddlt_wxry.SelectedItem.Text + ",";
                wxrybh += ddlt_wxry.SelectedValue.ToString() + ",";
            }
        }
        private void bind_drop()
        {
            ddlt_bmdm.DataSource = SysData.BM().Copy();
            ddlt_bmdm.DataTextField = "mc";
            ddlt_bmdm.DataValueField = "bm";
            ddlt_bmdm.DataBind();
            ddlt_bmdm.Items.Insert(0, new ListItem("全部", "-1"));
            //岗位代码
            ddlt_gwdm.DataSource = SysData.GW().Copy();
            ddlt_gwdm.DataTextField = "mc";
            ddlt_gwdm.DataValueField = "bm";
            ddlt_gwdm.DataBind();
            ddlt_gwdm.Items.Insert(0, new ListItem("全部", "-1"));

            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            string bmdm_wxry = ddlt_bmdm_wxry.SelectedValue.ToString();
            string gwdm_wxry = ddlt_gwdm_wxry.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = sbblk.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_syr.DataSource = dt;
            ddlt_syr.DataTextField = "xm";
            ddlt_syr.DataValueField = "bh";
            ddlt_syr.DataBind();

            DataTable dt2 = new DataTable();
            dt2 = sbblk.Select_YGbyBMGW(bmdm_wxry, gwdm_wxry);
            ddlt_wxry.DataSource = dt;
            ddlt_wxry.DataTextField = "xm";
            ddlt_wxry.DataValueField = "bh";
            ddlt_wxry.DataBind();

            ddlt_bmdm_wxry.DataSource = SysData.BM().Copy();
            ddlt_bmdm_wxry.DataTextField = "mc";
            ddlt_bmdm_wxry.DataValueField = "bm";
            ddlt_bmdm_wxry.DataBind();
            ddlt_bmdm_wxry.Items.Insert(0, new ListItem("全部", "-1"));
            //岗位代码
            ddlt_gwdm_wxry.DataSource = SysData.GW().Copy();
            ddlt_gwdm_wxry.DataTextField = "mc";
            ddlt_gwdm_wxry.DataValueField = "bm";
            ddlt_gwdm_wxry.DataBind();
            ddlt_gwdm_wxry.Items.Insert(0, new ListItem("全部", "-1"));

        }
        protected void ddlt_bmdm_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = sbblk.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_syr.DataSource = dt;
            ddlt_syr.DataTextField = "xm";
            ddlt_syr.DataValueField = "bh";
            ddlt_syr.DataBind();
        }
        protected void ddlt_bmdm_SelectedIndexChanged2(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm_wxry.SelectedValue.ToString();
            string gwdm = ddlt_gwdm_wxry.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = sbblk.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_wxry.DataSource = dt;
            ddlt_wxry.DataTextField = "xm";
            ddlt_wxry.DataValueField = "bh";
            ddlt_wxry.DataBind();
        }
        protected void ddlt_gwdm_SelectedIndexChanged2(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm_wxry.SelectedValue.ToString();
            string gwdm = ddlt_gwdm_wxry.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = sbblk.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_wxry.DataSource = dt;
            ddlt_wxry.DataTextField = "xm";
            ddlt_wxry.DataValueField = "bh";
            ddlt_wxry.DataBind();
        }
        protected void ddlt_gwdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = sbblk.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_syr.DataSource = dt;
            ddlt_syr.DataTextField = "xm";
            ddlt_syr.DataValueField = "bh";
            ddlt_syr.DataBind();
        }
        

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SKJS/SKJS_SBBLK.aspx", true);
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            #region 赋值
            string sbmc = tbx_sbmc.Text.Trim().ToString();
            string dd = tbx_dd.Text.Trim().ToString();
            string synx = @"^[0-9]+(\.[0-9]{0,2})?$";//只能输入整数和小数
            string bypc = ddlt_bypc.SelectedValue.Trim().ToString();
            string sygw = tbx_sygw.Text.Trim().ToString();
            string gzsj = @"^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$";
            string xx = tbx_xx.Text.Trim().ToString();
            string yy = tbx_yy.Text.Trim().ToString();
            string pgfs = tbx_pgfs.Text.Trim().ToString();
            string bz = tbx_bz.Text.Trim().ToString();
            string pgsj = @"^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$";
            #endregion
            #region lable判断输入
            int flag = 0;
            //设备名称
            if (tbx_sbmc.Text == "")
            {
                lbl_sbmc.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sbmc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //使用年限
            if (tbx_synx.Text == "")
            {
                lbl_synx.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(tbx_synx.Text.ToString(), synx))
                {
                    lbl_synx.Text = "<span style=\"color:#ff0000\">" + "请输入整数" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_synx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }
            //保养频次
            if (ddlt_bypc.SelectedValue == "-1")
            {
                lbl_bypc.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_bypc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //使用岗位
            if (tbx_sygw.Text == "")
            {
                lbl_sygw.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sygw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //原因
            if (tbx_yy.Text == "")
            {
                lbl_yy.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_yy.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //现象
            if (tbx_xx.Text == "")
            {
                lbl_xx.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_xx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //故障时间
            if (tbx_gzsj.Text == "")
            {
                lbl_gzsj.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(tbx_gzsj.Text.ToString(), gzsj))
                {
                    lbl_gzsj.Text = "<span style=\"color:#ff0000\">" + "请输入正确的日期如（1996-01-02）" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_gzsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }
            //备注
            if (tbx_bz.Text == "")
            {

                lbl_bz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            else
                lbl_bz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            //排故时间
            if (tbx_pgsj.Text == "")
            {
                lbl_pgsj.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (tbx_pgsj.Text == "")
                {
                    lbl_pgsj.Text = "<span style=\"color:#ff0000\">" + "日期不能为空" + "</span>";
                    flag = 1;
                }
                else
                {
                    if (!Regex.IsMatch(tbx_pgsj.Text.ToString(), pgsj))
                    {
                        lbl_pgsj.Text = "<span style=\"color:#ff0000\">" + "请输入正确的日期如（1996-01-02）" + "</span>";
                        flag = 1;
                    }
                    DateTime sbnf1 = DateTime.Parse(tbx_gzsj.Text.ToString());
                    DateTime wcsj2 = DateTime.Parse(tbx_pgsj.Text.ToString());
                    if (sbnf1 > wcsj2)
                    {
                        lbl_pgsj.Text = "<span style=\"color:#ff0000\">" + "登记日期不能小于维修日期" + "</span>";
                        flag = 1;
                    }
                    else
                    {
                        lbl_pgsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                    }
                }
            }
            //数据所在部门
            if (ddlt_sjszbm.SelectedValue.Trim() == "-1")
            {

                lbl_sjszbm.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sjszbm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //初审人
            if (ddlt_csr.SelectedValue.Trim() == "-1")
            {

                lbl_csr.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_csr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            //终审人
            if (ddlt_zsr.SelectedValue.Trim() == "-1")
            {

                lbl_zsr.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zsr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";

            }
            if (flag == 1)
            { return; }
            #endregion
            #region 判断修改
            int check_rz = 0;
            struct_sbblk.p_id = Convert.ToInt32(id);
            DataTable dt_detail = sbblk.Select_SBBLK_Detail(Convert.ToInt32(id));
            struct_sbblk.p_sbmc = sbmc;
            struct_sbblk.p_dd = tbx_dd.Text.Trim().ToString();
            struct_sbblk.p_sygw = sygw;
            struct_sbblk.p_syr = ddlt_syr.SelectedValue.ToString().Trim();
            struct_sbblk.p_synx = tbx_synx.Text.Trim().ToString();
            struct_sbblk.p_xx = xx;
            struct_sbblk.p_yy = yy;
            struct_sbblk.p_gzsj = tbx_gzsj.Text.Trim().ToString();
            struct_sbblk.p_pgfs = tbx_pgfs.Text.Trim().ToString();
            struct_sbblk.p_wxry = ddlt_wxry.SelectedValue.ToString().Trim();
            struct_sbblk.p_pgsj = tbx_pgsj.Text.Trim().ToString();
            struct_sbblk.p_bz = bz;
            struct_sbblk.p_bypc = bypc;
            struct_sbblk.p_bmdm =ddlt_sjszbm.SelectedValue.ToString().Trim();//数据所属部门
            struct_sbblk.p_lrr = _usState.userLoginName;//录入人
            struct_sbblk.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_sbblk.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
            struct_sbblk.p_czfs = "02";
            struct_sbblk.p_czxx = "位置：三库建设->设备病例库->编辑    序号：[" + struct_sbblk.p_id + "]  ";

            string sjbs = Request.Params["sjbs"].ToString();

            if (sjbs.Equals("0") || sjbs.Equals("2"))
            {
                sbblk.Update_SBBLK(struct_sbblk);
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert('编辑成功！');</script>");
               // Server.Transfer("JLGL.aspx?ygbh=" + _usState.userLoginName);
               
            }
            else if (sjbs.Equals("1") || sjbs.Equals("3"))
            {
                //生成该数据的副本,并返回新的备份id
                id = Convert.ToInt32(Request.Params["id"].ToString());
                int id_bf = sbblk.SBBLK_SJBF(Convert.ToInt32(id));
                struct_sbblk.p_id = id_bf;
                sbblk.Update_SBBLK(struct_sbblk);
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert('编辑成功！');</script>");
              //  Server.Transfer("JLGL.aspx?ygbh=" + _usState.userLoginName);
                
            }
            else
            {
                return;
            }
            #endregion
            #region 清空提示语
            lbl_sbmc.Text = "";
            lbl_dd.Text = "";
            lbl_sygw.Text = "";
            lbl_bypc.Text = "";
            lbl_syr.Text = "";
            lbl_synx.Text = "";
            lbl_gzsj.Text = "";
            lbl_xx.Text = "";
            lbl_yy.Text = "";
            lbl_gzsj.Text = "";
            lbl_pgfs.Text = "";
            lbl_pgsj.Text = "";
            lbl_bz.Text = "";
            lbl_wxry.Text = "";
            #endregion

        }

        protected void select_detail()
        {
            dt_detail = sbblk.Select_SBBLK_Detail(Convert.ToInt32(id));
            dt_detail.Columns.Add("syrxm");
            dt_detail.Columns.Add("wxryxm");
            foreach(DataRow dr in dt_detail.Rows)
            {
                string[] Array_syr = dr["syr"].ToString().Split(',');
                string[] Array_wxry = dr["wxry"].ToString().Split(',');
                foreach (string syrxm_dm in Array_syr)
                {
                    dr["syrxm"] += sbblk.Select_YGXMbyBH(syrxm_dm.ToString()).Rows[0][0].ToString() + ",";
                }
                foreach (string wxryxm_dm in Array_wxry)
                {
                    dr["wxryxm"] += sbblk.Select_YGXMbyBH(wxryxm_dm.ToString()).Rows[0][0].ToString() + ",";
                }
            }
            
            tbx_sbmc.Text = dt_detail.Rows[0]["sbmc"].ToString();
            tbx_dd.Text = dt_detail.Rows[0]["dd"].ToString();
            ddlt_bypc.SelectedValue = dt_detail.Rows[0]["bypc"].ToString();
            tbx_sygw.Text = dt_detail.Rows[0]["sygw"].ToString();
            tbx_syr.Text = dt_detail.Rows[0]["syrxm"].ToString();
            tbx_gzsj.Text = Convert.ToDateTime(dt_detail.Rows[0]["gzsj"]).ToString("yyyy-MM-dd");
            tbx_synx.Text = dt_detail.Rows[0]["synx"].ToString();
            tbx_xx.Text = dt_detail.Rows[0]["xx"].ToString();
            tbx_yy.Text = dt_detail.Rows[0]["yy"].ToString();
            tbx_pgfs.Text = dt_detail.Rows[0]["pgfs"].ToString();
            tbx_bz.Text = dt_detail.Rows[0]["bz"].ToString();
            tbx_wxry.Text = dt_detail.Rows[0]["wxryxm"].ToString();
            tbx_pgsj.Text = Convert.ToDateTime(dt_detail.Rows[0]["pgsj"]).ToString("yyyy-MM-dd");
            ddlt_csr.SelectedValue = dt_detail.Rows[0]["csr"].ToString();//初审人
            ddlt_zsr.SelectedValue = dt_detail.Rows[0]["zsr"].ToString();//终审人
            ddlt_sjszbm.SelectedValue = dt_detail.Rows[0]["bmdm"].ToString();//数据所在部门
        }
    }
}