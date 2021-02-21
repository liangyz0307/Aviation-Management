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
using System.Text.RegularExpressions;
using System.Globalization;

namespace CUST.WKG
{
    public partial class SKJS_WXY_Edit : System.Web.UI.Page
    {
        private UserState _usState;
        private WXY wxy;
        private Struct_WXY struct_wxy;
        private static int id;
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
            wxy = new WXY(_usState);
            if (!IsPostBack)
            {
                zrrxmHiddenField.Value = "0";
                id = Convert.ToInt32(Request.QueryString["id"]);
                bind_drop();
                ddltBind();
                select_detail();
                dt_detail = wxy.Select_WXY_Detail(id);
                syrbh = dt_detail.Rows[0]["zrr"].ToString();
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

        protected void btn_bc_Click(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            //dt_detail = wxy.Select_WXY_Detail(bh);
            //syrbh=dt_detail.Rows[0]["zrr"].ToString();
            if (ddlt_syr.Items.Count > 0)
            {
                tbx_syr.Text += ddlt_syr.SelectedItem.Text + ",";
                syrbh += ddlt_syr.SelectedValue.ToString() + ",";
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
            DataTable dt = new DataTable();
            dt = wxy.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_syr.DataSource = dt;
            ddlt_syr.DataTextField = "xm";
            ddlt_syr.DataValueField = "bh";
            ddlt_syr.DataBind();


        }
        protected void ddlt_bmdm_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = wxy.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_syr.DataSource = dt;
            ddlt_syr.DataTextField = "xm";
            ddlt_syr.DataValueField = "bh";
            ddlt_syr.DataBind();
        }

        protected void ddlt_gwdm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = wxy.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_syr.DataSource = dt;
            ddlt_syr.DataTextField = "xm";
            ddlt_syr.DataValueField = "bh";
            ddlt_syr.DataBind();
        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SKJS/SKJS_WXY.aspx", true);
        }



        protected void select_detail()
        {

            dt_detail = wxy.Select_WXY_Detail(id);           
            dt_detail.Columns.Add("syrxm");
            foreach (DataRow dr in dt_detail.Rows)
            {
                string[] Array_syr = dr["zrr"].ToString().Split(',');
                foreach (string syrxm_dm in Array_syr)
                {
                    dr["syrxm"] += wxy.Select_YGXMbyBH(syrxm_dm.ToString()).Rows[0][0].ToString() + ",";
                }
            }
            
          
            tbx_syr.Text = dt_detail.Rows[0]["syrxm"].ToString();
            tbx_mc.Text = dt_detail.Rows[0]["mc"].ToString();
            ddlt_gw.Text = dt_detail.Rows[0]["gw"].ToString();
            ddlt_fc.SelectedValue = dt_detail.Rows[0]["fc"].ToString();
            tbx_yy.Text = dt_detail.Rows[0]["yy"].ToString();
            tbx_hg.Text = dt_detail.Rows[0]["zchg"].ToString();
            tbx_xgal.Text = dt_detail.Rows[0]["xgal"].ToString();
            tbx_yf.Text = dt_detail.Rows[0]["yf"].ToString();
            ddlt_st.SelectedValue = dt_detail.Rows[0]["st"].ToString();
            ddlt_knx.SelectedValue = dt_detail.Rows[0]["knx"].ToString();
            ddlt_yzx.SelectedValue = dt_detail.Rows[0]["yzx"].ToString();
            ddlt_fxcd.SelectedValue = dt_detail.Rows[0]["fxcd"].ToString();
            tbx_yj.Text = dt_detail.Rows[0]["yjcs"].ToString();
            ddlt_kzzt.SelectedValue = dt_detail.Rows[0]["kzzt"].ToString();
            ddlt_bzh.SelectedValue = dt_detail.Rows[0]["bzhqk"].ToString();
            tbx_ya.Text = dt_detail.Rows[0]["ya"].ToString();
            ddlt_bmej.SelectedValue = dt_detail.Rows[0]["zrej"].ToString();
            ddlt_bmsj.SelectedValue = dt_detail.Rows[0]["zrsj"].ToString();
            ddlt_phbm.SelectedValue = dt_detail.Rows[0]["phbm"].ToString();

            ddlt_csr.SelectedValue = dt_detail.Rows[0]["csr"].ToString();//初审人
            ddlt_zsr.SelectedValue = dt_detail.Rows[0]["zsr"].ToString();//终审人
            ddlt_sjszbm.SelectedValue = dt_detail.Rows[0]["bmdm"].ToString();//数据所在部门

        }


        protected void btn_save_Click(object sender, EventArgs e)
        {
            int flag = 0;
            string mc = tbx_mc.Text.Trim();
            string gw = ddlt_gw.SelectedValue.ToString().Trim();
            string fc = ddlt_fc.SelectedValue.ToString().Trim();
            string yy = tbx_yy.Text.Trim();
            string hg = tbx_hg.Text.Trim(); ;
            string xgal = tbx_xgal.Text.Trim();
            string yf = @"^(0?[[1-9]|1[0-2])$";
            string st = ddlt_st.SelectedValue.ToString().Trim();
            string knx = ddlt_knx.SelectedValue.ToString().Trim();
            string yzx = ddlt_yzx.SelectedValue.ToString().Trim();
            string fxcd = ddlt_fxcd.SelectedValue.ToString().Trim();
            string yj = tbx_yj.Text.Trim();
            string kzzt = ddlt_kzzt.SelectedValue.ToString().Trim();
            string bzhqk = ddlt_bzh.SelectedValue.ToString().Trim();
            string ya = tbx_ya.Text.Trim();
            string bmej = ddlt_bmej.SelectedValue.ToString().Trim();
            string bmsj = ddlt_bmsj.SelectedValue.ToString().Trim();
            string phbm = ddlt_phbm.SelectedValue.ToString().Trim();
            string zrr = syrbh.Substring(0, syrbh.Length - 1);

            if (string.IsNullOrEmpty(mc))
            {
                lbl_mc.Text = "<span style=\"color:#ff0000\">" + "错误：危险源名称不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_mc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(fc))
            {
                lbl_fc.Text = "<span style=\"color:#ff0000\">" + "错误：危险源范畴不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_fc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(gw))
            {
                lbl_gw.Text = "<span style=\"color:#ff0000\">" + "错误：岗位不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_gw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //月份
            if (tbx_yf.Text == "")
            {
                lbl_yf.Text = "<span style=\"color:#ff0000\">" + "月份不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(tbx_yf.Text.ToString(), yf))
                {
                    lbl_yf.Text = "<span style=\"color:#ff0000\">" + "月份格式不正确" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_yf.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }
            if (string.IsNullOrEmpty(st))
            {
                lbl_st.Text = "<span style=\"color:#ff0000\">" + "错误：时态不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_st.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(knx))
            {
                lbl_knx.Text = "<span style=\"color:#ff0000\">" + "错误：风险发生的可能性不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_knx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(yzx))
            {
                lbl_yzx.Text = "<span style=\"color:#ff0000\">" + "错误：后果的严重性不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_yzx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(fxcd))
            {
                lbl_fxcd.Text = "<span style=\"color:#ff0000\">" + "错误：风险程度不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_fxcd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(kzzt))
            {
                lbl_kzzt.Text = "<span style=\"color:#ff0000\">" + "错误：控制状态不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_kzzt.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(yy))
            {
                lbl_yy.Text = "<span style=\"color:#ff0000\">" + "错误：诱发原因不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_yy.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(hg))
            {
                lbl_hg.Text = "<span style=\"color:#ff0000\">" + "错误：后果不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_hg.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(ya))
            {
                lbl_ya.Text = "<span style=\"color:#ff0000\">" + "错误：风险控制预案不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_ya.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (string.IsNullOrEmpty(yj))
            {
                lbl_yj.Text = "<span style=\"color:#ff0000\">" + "错误：应急措施不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_yj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
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
            lbl_xgal.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            lbl_bzh.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            lbl_bmej.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            lbl_bmsj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            lbl_phbm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            lbl_csr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            lbl_zsr.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            lbl_sjszbm.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            if (flag == 1)
                return;
            int check_rz = 0;
            if (Convert.ToInt32(zrrxmHiddenField.Value) == 0)
            {
                struct_wxy.p_zrr = dt_detail.Rows[0]["zrr"].ToString(); // 整改责任人
            }
            else
            {
                struct_wxy.p_zrr = syrbh.Substring(0, syrbh.Length); // 整改责任人
            }
            struct_wxy.p_id = id;
            struct_wxy.p_mc= mc;
            struct_wxy.p_gw=gw;
            struct_wxy.p_fc=fc;
            struct_wxy.p_yy =yy; 
            struct_wxy.p_hg = hg;
            struct_wxy.p_xgal = xgal ;
            struct_wxy.p_yf =Convert.ToInt32(tbx_yf.Text);
            struct_wxy.p_st=st;
            struct_wxy.p_knx=knx;
            struct_wxy.p_yzx=yzx;
            struct_wxy.p_fxcd=fxcd;
            struct_wxy.p_yj =yj; 
            struct_wxy.p_kzzt=kzzt;
            struct_wxy.p_bzhqk=bzhqk;
            struct_wxy.p_ya = ya; 
            struct_wxy.p_bmej=bmej;
            struct_wxy.p_bmsj=bmsj;
            struct_wxy.p_phbm=phbm;

            struct_wxy.p_lrr = _usState.userLoginName;//录入人
            struct_wxy.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_wxy.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
            struct_wxy.p_bmdm = ddlt_sjszbm.SelectedValue.ToString().Trim();//数据所在部门

            struct_wxy.p_czfs = "02";
            struct_wxy.p_czxx = "位置：三库建设系统->危险源->编辑     报送编号：[" + struct_wxy.p_id + "] 描述：";
            //dt_detail = yg.Select_YGDetail(Request.Params["BH"].ToString());
            //岗位
            if (struct_wxy.p_gw != dt_detail.Rows[0]["gw"].ToString())
            {
                //已修改
                struct_wxy.p_czxx += "岗位：【" + dt_detail.Rows[0]["gw"].ToString() + "】->【" + struct_wxy.p_gw + "】";
                check_rz = 1;
            }
            //风 险 源 名 称
            if (struct_wxy.p_mc != tbx_mc.Text.ToString().Trim())
            {
                //已修改
                struct_wxy.p_czxx += "风 险 源 名 称：【" + dt_detail.Rows[0]["mc"].ToString() + "】->【" + struct_wxy.p_mc + "】";
                check_rz = 1;
            }
            //诱发原因
            if (struct_wxy.p_yy != tbx_yy.Text.ToString().Trim())
            {
                //已修改
                struct_wxy.p_czxx += "诱发原因：【" + dt_detail.Rows[0]["yy"].ToString() + "】->【" + struct_wxy.p_yy + "】";
                check_rz = 1;
            }
            //后果
            if (struct_wxy.p_hg != tbx_hg.Text.ToString().Trim())
            {
                //已修改
                struct_wxy.p_czxx += "后果：【" + dt_detail.Rows[0]["zchg"].ToString() + "】->【" + struct_wxy.p_hg + "】";
                check_rz = 1;
            }
            //相关案例
            if (struct_wxy.p_xgal != tbx_xgal.Text.ToString().Trim())
            {
                //已修改
                struct_wxy.p_czxx += "相关案例：【" + dt_detail.Rows[0]["xgal"].ToString() + "】->【" + struct_wxy.p_xgal + "】";
                check_rz = 1;
            }
         
            //风 险 源 范 畴
            if (struct_wxy.p_fc != ddlt_fc.SelectedValue.ToString().Trim())
            {
                //已修改
                struct_wxy.p_czxx += "风 险 源 范 畴：【" + dt_detail.Rows[0]["fc"].ToString() + "】->【" + struct_wxy.p_fc + "】";
                check_rz = 1;
            }
            //月份
            if (struct_wxy.p_yf !=Convert.ToInt32( tbx_yf.Text.ToString()))
            {
                //已修改
                struct_wxy.p_czxx += "月份：【" + dt_detail.Rows[0]["yf"].ToString() + "】->【" + struct_wxy.p_yf + "】";
                check_rz = 1;
            }
            //时 态
            if (struct_wxy.p_st!= ddlt_st.SelectedValue.ToString().Trim())
            {
                //已修改
                struct_wxy.p_czxx += "时 态：【" + dt_detail.Rows[0]["st"].ToString() + "】->【" + struct_wxy.p_st + "】";
                check_rz = 1;
            }
            //风险情景发生的可能性
            if (struct_wxy.p_knx != ddlt_knx.SelectedValue.ToString().Trim())
            {
                //已修改
                struct_wxy.p_czxx += "风险情景发生的可能性：【" + dt_detail.Rows[0]["knx"].ToString() + "】->【" + struct_wxy.p_knx + "】";
                check_rz = 1;
            }
            //风险情景发生的严重性
            if (struct_wxy.p_yzx != ddlt_yzx.SelectedValue.ToString().Trim())
            {
                //已修改
                struct_wxy.p_czxx += "风险情景发生的严重性：【" + dt_detail.Rows[0]["yzx"].ToString() + "】->【" + struct_wxy.p_yzx + "】";
                check_rz = 1;
            }
            //风 险 程 度
            if (struct_wxy.p_fxcd != ddlt_fxcd.SelectedValue.ToString().Trim())
            {
                //已修改
                struct_wxy.p_czxx += "风 险 程 度：【" + dt_detail.Rows[0]["fxcd"].ToString() + "】->【" + struct_wxy.p_fxcd + "】";
                check_rz = 1;
            }
            //控 制 状 态
            if (struct_wxy.p_kzzt != ddlt_kzzt.SelectedValue.ToString().Trim())
            {
                //已修改
                struct_wxy.p_czxx += "控 制 状 态：【" + dt_detail.Rows[0]["kzzt"].ToString() + "】->【" + struct_wxy.p_kzzt + "】";
                check_rz = 1;
            }
            //控制措施标准化情况
            if (struct_wxy.p_bzhqk != ddlt_bzh.SelectedValue.ToString().Trim())
            {
                //已修改
                struct_wxy.p_czxx += "控制措施标准化情况：【" + dt_detail.Rows[0]["bzhqk"].ToString() + "】->【" + struct_wxy.p_bzhqk + "】";
                check_rz = 1;
            }

            //应急措施
            if (struct_wxy.p_yj != tbx_yj.Text.ToString().Trim())
            {
                //已修改
                struct_wxy.p_czxx += "应急措施：【" + dt_detail.Rows[0]["yjcs"].ToString() + "】->【" + struct_wxy.p_yj + "】";
                check_rz = 1;
            }
            //风险控制措施或预案
            if (struct_wxy.p_ya != tbx_ya.Text.ToString().Trim())
            {
                //已修改
                struct_wxy.p_czxx += "风险控制措施或预案：【" + dt_detail.Rows[0]["ya"].ToString() + "】->【" + struct_wxy.p_ya + "】";
                check_rz = 1;
            }
            //责任部门（二级）
            if (struct_wxy.p_bmej != dt_detail.Rows[0]["zrej"].ToString())
            {
                //已修改
                struct_wxy.p_czxx += "责任部门（二级）：【" + dt_detail.Rows[0]["zrej"].ToString() + "】->【" + struct_wxy.p_bmej + "】";
                check_rz = 1;
            }
            //责任部门（三级）
            if (struct_wxy.p_bmsj != dt_detail.Rows[0]["zrsj"].ToString())
            {
                //已修改
                struct_wxy.p_czxx += "责任部门（三级）：【" + dt_detail.Rows[0]["zrsj"].ToString() + "】->【" + struct_wxy.p_bmsj + "】";
                check_rz = 1;
            }
            //配合部门
            if (struct_wxy.p_phbm != dt_detail.Rows[0]["phbm"].ToString())
            {
                //已修改
                struct_wxy.p_czxx += "配合部门：【" + dt_detail.Rows[0]["phbm"].ToString() + "】->【" + struct_wxy.p_phbm + "】";
                check_rz = 1;
            }
            //责任人
            if (struct_wxy.p_zrr != tbx_syr.Text.ToString().Trim())
            {
                //已修改
                struct_wxy.p_czxx += "责任人：【" + dt_detail.Rows[0]["zrr"].ToString() + "】->【" + struct_wxy.p_zrr + "】";
                check_rz = 1;
            }
            if (check_rz == 0)
            {
                struct_wxy.p_czxx += "未修改";
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert('编辑成功！');</script>");

            }
            else
            {
                string sjbs = Request.Params["sjbs"].ToString();

                if (sjbs.Equals("0") || sjbs.Equals("2"))
                {
                    wxy.Update_WXY(struct_wxy);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                    Server.Transfer("SKJS_WXY.aspx?ygbh=" + _usState.userLoginName);

                }
                else if (sjbs.Equals("1") || sjbs.Equals("3"))
                {
                    //生成该数据的副本,并返回新的备份id
                    id = Convert.ToInt32(Request.Params["id"].ToString());
                    int id_bf = wxy.WXY_SJBF(Convert.ToInt32(id));
                    struct_wxy.p_id = id_bf;
                    wxy.Update_WXY(struct_wxy);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                    Server.Transfer("SKJS_WXY.aspx?ygbh=" + _usState.userLoginName);
                }
                else
                {
                    return;
                }
  
            }

           
        }
        private void ddltBind()
        {
            //岗位
            ddlt_gw.DataSource = SysData.GW().Copy();
            ddlt_gw.DataTextField = "mc";
            ddlt_gw.DataValueField = "bm";
            ddlt_gw.DataBind();
            ddlt_gw.Items.Insert(0, new ListItem("全部", "-1"));
            //严重性
            ddlt_yzx.DataSource = SysData.YZCD().Copy();
            ddlt_yzx.DataTextField = "mc";
            ddlt_yzx.DataValueField = "bm";
            ddlt_yzx.DataBind();
            ddlt_yzx.Items.Insert(0, new ListItem("全部", "-1"));
            //危险源范畴
            ddlt_fc.DataSource = SysData.WXYFC().Copy();
            ddlt_fc.DataTextField = "mc";
            ddlt_fc.DataValueField = "bm";
            ddlt_fc.DataBind();
            ddlt_fc.Items.Insert(0, new ListItem("全部", "-1"));
            //时态
            ddlt_st.DataSource = SysData.STDM().Copy();
            ddlt_st.DataTextField = "mc";
            ddlt_st.DataValueField = "bm";
            ddlt_st.DataBind();
            ddlt_st.Items.Insert(0, new ListItem("全部", "-1"));
            //风险情景发生的可能性
            ddlt_knx.DataSource = SysData.FXFSKN().Copy();
            ddlt_knx.DataTextField = "mc";
            ddlt_knx.DataValueField = "bm";
            ddlt_knx.DataBind();
            ddlt_knx.Items.Insert(0, new ListItem("全部", "-1"));
            //风险程度
            ddlt_fxcd.DataSource = SysData.FXCD().Copy();
            ddlt_fxcd.DataTextField = "mc";
            ddlt_fxcd.DataValueField = "bm";
            ddlt_fxcd.DataBind();
            ddlt_fxcd.Items.Insert(0, new ListItem("全部", "-1"));
            //控制状态
            ddlt_kzzt.DataSource = SysData.FXKZZT().Copy();
            ddlt_kzzt.DataTextField = "mc";
            ddlt_kzzt.DataValueField = "bm";
            ddlt_kzzt.DataBind();
            ddlt_kzzt.Items.Insert(0, new ListItem("全部", "-1"));
            //控制措施标准化情况
            ddlt_bzh.DataSource = SysData.ZGCSBZHQK().Copy();
            ddlt_bzh.DataTextField = "mc";
            ddlt_bzh.DataValueField = "bm";
            ddlt_bzh.DataBind();
            ddlt_bzh.Items.Insert(0, new ListItem("全部", "-1"));
            //控制部门（二级）
            ddlt_bmej.DataSource = SysData.BM().Copy();
            ddlt_bmej.DataTextField = "mc";
            ddlt_bmej.DataValueField = "bm";
            ddlt_bmej.DataBind();
            ddlt_bmej.Items.Insert(0, new ListItem("全部", "-1"));
            //控制部门（三级）
            ddlt_bmsj.DataSource = SysData.BM().Copy();
            ddlt_bmsj.DataTextField = "mc";
            ddlt_bmsj.DataValueField = "bm";
            ddlt_bmsj.DataBind();
            ddlt_bmsj.Items.Insert(0, new ListItem("全部", "-1"));
            //配合部门
            ddlt_phbm.DataSource = SysData.BM().Copy();
            ddlt_phbm.DataTextField = "mc";
            ddlt_phbm.DataValueField = "bm";
            ddlt_phbm.DataBind();
            ddlt_phbm.Items.Insert(0, new ListItem("全部", "-1"));

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
        }
    }
}