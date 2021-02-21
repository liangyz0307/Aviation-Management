using CUST;
using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using CUST.WKG;
using Sys;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class SKJS_AQWTK_Edit : System.Web.UI.Page
    {
        private UserState _us;
        private AQWTK aqwtk;
        static string zrr;
        public bool flag = true;
        public int i = 0;
        private Struct_AQWTK struct_aqwtk;
        private DataTable dt_Detail;
        private static int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_us = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时!\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            aqwtk = new AQWTK(_us);
            struct_aqwtk = new Struct_AQWTK();
            id = Convert.ToInt32(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                zrrHiddenField.Value = "0";
                Bind();
                bind_Main();

            }
        }

        private void bind_Main()
        {
            dt_Detail = aqwtk.Select_AQWTK_Detail(id);
            dt_Detail.Columns.Add("zrrxm");

            foreach (DataRow dr in dt_Detail.Rows)
            {
                string[] Array_zzr = dr["zrr"].ToString().Split(',');

                foreach (string zzrxm_bh in Array_zzr)
                {
                    dr["zrrxm"] = aqwtk.Select_YGXMbyBH(zzrxm_bh.ToString()).Rows[0][0].ToString();
                }


                ddlt_gw.Text = dt_Detail.Rows[0]["gw"].ToString();//岗位
                tbx_aqwtmc.Text = dt_Detail.Rows[0]["aqwtmc"].ToString();//安全问题名称
                tbx_fssj.Text = Convert.ToDateTime(dt_Detail.Rows[0]["fssj"]).ToString("yyyy-MM-dd");//发生时间
                ddlt_ly.Text = dt_Detail.Rows[0]["ly"].ToString();//来源
                ddlt_sjfc.Text = dt_Detail.Rows[0]["sjfc"].ToString();//涉及范畴
                ddlt_st.Text = dt_Detail.Rows[0]["st"].ToString();//时态
                ddlt_wxcd.Text = dt_Detail.Rows[0]["wxcd"].ToString();//危险程度
                ddlt_wtaqzt.Text = dt_Detail.Rows[0]["wtaqzt"].ToString();//问题安全状态
                ddlt_zgcsbzhqk.Text = dt_Detail.Rows[0]["zgcsbzhqk"].ToString();//整改措施标准化情况
                ddlt_wtkzzt.Text = dt_Detail.Rows[0]["wtkzzt"].ToString();//问题控制状态
                ddlt_zrbm.Text = dt_Detail.Rows[0]["zrbm"].ToString();//责任部门
                ddlt_zrgw.Text = dt_Detail.Rows[0]["zrgw"].ToString();//责任岗位
                ddlt_sjbm.Text = dt_Detail.Rows[0]["sjbm"].ToString();// 涉及部门
                tbx_zrr.Text = dt_Detail.Rows[0]["zrrxm"].ToString(); // 责任人

                tbx_yfyy.Text = dt_Detail.Rows[0]["yfyy"].ToString();//诱发原因分析
                tbx_knzchg.Text = dt_Detail.Rows[0]["knzchg"].ToString();//可能造成的问题或后果
                ddlt_hgyzcd.Text = dt_Detail.Rows[0]["hgyzcd"].ToString();//后果严重程度
                tbx_zgcs.Text = dt_Detail.Rows[0]["zgcs"].ToString();//整改措施
                tbx_zgsx.Text = Convert.ToDateTime(dt_Detail.Rows[0]["zgsx"]).ToString("yyyy-MM-dd");//整改时限
                tbx_dxcs.Text = dt_Detail.Rows[0]["dxcs"].ToString();//等效措施或预案
                tbx_ywxyxg.Text = dt_Detail.Rows[0]["xgsj"].ToString();//与危险源相关联的事件或典型案例 相关事件

                tbx_bz.Text = dt_Detail.Rows[0]["bz"].ToString();//备注


                ddlt_csr.SelectedValue = dt_Detail.Rows[0]["csr"].ToString();//初审人
                ddlt_zsr.SelectedValue = dt_Detail.Rows[0]["zsr"].ToString();//终审人
                ddlt_sjszbm.SelectedValue = dt_Detail.Rows[0]["bmdm"].ToString();//数据所在部门

            }
        }

        #region tbx_zrr.Text数据绑定
        protected void ddlt_bmdm_SelectedIndexChanged2(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = aqwtk.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_zrr.DataSource = dt;
            ddlt_zrr.DataTextField = "xm";
            ddlt_zrr.DataValueField = "bh";
            ddlt_zrr.DataBind();
        }
        protected void ddlt_gwdm_SelectedIndexChanged2(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            DataTable dt = new DataTable();
            dt = aqwtk.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_zrr.DataSource = dt;
            ddlt_zrr.DataTextField = "xm";
            ddlt_zrr.DataValueField = "bh";
            ddlt_zrr.DataBind();
        }
        protected void btn_bc_zrr_Click(object sender, EventArgs e)
        {
            string bmdm = ddlt_bmdm.SelectedValue.ToString();
            string gwdm = ddlt_gwdm.SelectedValue.ToString();
            string yg = ddlt_zrr.SelectedValue.ToString();
            //ddlt_syr.SelectedItem.Text获取下拉框DataTextField值
            if (ddlt_zrr.Items.Count > 0)
            {
                tbx_zrr.Text = ddlt_zrr.SelectedItem.Text;
                zrr = ddlt_zrr.SelectedValue.ToString();
            }
        }
        #endregion

        private void Bind()
        {

            //责任
            ddlt_gw.DataSource = SysData.GW().Copy();
            ddlt_gw.DataTextField = "mc";
            ddlt_gw.DataValueField = "bm";
            ddlt_gw.DataBind();
            ddlt_gw.Items.Insert(0, new ListItem("全部", "-1"));
            //来源
            ddlt_ly.DataSource = SysData.LY().Copy();
            ddlt_ly.DataTextField = "mc";
            ddlt_ly.DataValueField = "bm";
            ddlt_ly.DataBind();
            ddlt_ly.Items.Insert(0, new ListItem("全部", "-1"));
            //涉及范畴
            ddlt_sjfc.DataSource = SysData.SJFC().Copy();
            ddlt_sjfc.DataTextField = "mc";
            ddlt_sjfc.DataValueField = "bm";
            ddlt_sjfc.DataBind();
            ddlt_sjfc.Items.Insert(0, new ListItem("全部", "-1"));
            //时态
            ddlt_st.DataSource = SysData.STDM().Copy();
            ddlt_st.DataTextField = "mc";
            ddlt_st.DataValueField = "bm";
            ddlt_st.DataBind();
            ddlt_st.Items.Insert(0, new ListItem("全部", "-1"));
            //后果严重程度
            ddlt_hgyzcd.DataSource = SysData.HGYZX().Copy();
            ddlt_hgyzcd.DataTextField = "mc";
            ddlt_hgyzcd.DataValueField = "bm";
            ddlt_hgyzcd.DataBind();
            ddlt_hgyzcd.Items.Insert(0, new ListItem("全部", "-1"));
            //危险程度
            ddlt_wxcd.DataSource = SysData.WXCD().Copy();
            ddlt_wxcd.DataTextField = "mc";
            ddlt_wxcd.DataValueField = "bm";
            ddlt_wxcd.DataBind();
            ddlt_wxcd.Items.Insert(0, new ListItem("全部", "-1"));
            //问题安全状态
            ddlt_wtaqzt.DataSource = SysData.AQZT().Copy();
            ddlt_wtaqzt.DataTextField = "mc";
            ddlt_wtaqzt.DataValueField = "bm";
            ddlt_wtaqzt.DataBind();
            ddlt_wtaqzt.Items.Insert(0, new ListItem("全部", "-1"));
            //整改措施标准化情况
            ddlt_zgcsbzhqk.DataSource = SysData.ZGCSBZHQK().Copy();
            ddlt_zgcsbzhqk.DataTextField = "mc";
            ddlt_zgcsbzhqk.DataValueField = "bm";
            ddlt_zgcsbzhqk.DataBind();
            ddlt_zgcsbzhqk.Items.Insert(0, new ListItem("全部", "-1"));
            //问题控制状态
            ddlt_wtkzzt.DataSource = SysData.WTZT().Copy();
            ddlt_wtkzzt.DataTextField = "mc";
            ddlt_wtkzzt.DataValueField = "bm";
            ddlt_wtkzzt.DataBind();
            ddlt_wtkzzt.Items.Insert(0, new ListItem("全部", "-1"));
            //责任部门
            ddlt_zrbm.DataSource = SysData.BM().Copy();
            ddlt_zrbm.DataTextField = "mc";
            ddlt_zrbm.DataValueField = "bm";
            ddlt_zrbm.DataBind();
            ddlt_zrbm.Items.Insert(0, new ListItem("全部", "-1"));
            //涉及部门
            ddlt_sjbm.DataSource = SysData.BM().Copy();
            ddlt_sjbm.DataTextField = "mc";
            ddlt_sjbm.DataValueField = "bm";
            ddlt_sjbm.DataBind();
            ddlt_sjbm.Items.Insert(0, new ListItem("全部", "-1"));
            //责任岗位
            ddlt_zrgw.DataSource = SysData.GW().Copy();
            ddlt_zrgw.DataTextField = "mc";
            ddlt_zrgw.DataValueField = "bm";
            ddlt_zrgw.DataBind();
            ddlt_zrgw.Items.Insert(0, new ListItem("全部", "-1"));
            //责任人
            #region 员工选择框
            ddlt_bmdm.DataSource = SysData.BM().Copy(); ;
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
            dt = aqwtk.Select_YGbyBMGW(bmdm, gwdm);
            ddlt_zrr.DataSource = dt;
            ddlt_zrr.DataTextField = "xm";
            ddlt_zrr.DataValueField = "bh";
            ddlt_zrr.DataBind();
            #endregion



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

        protected void btn_save_Click(object sender, EventArgs e)
        {

            string fssj = @"^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$";
            string zgsx = @"^((((((0[48])|([13579][26])|([2468][048]))00)|([0-9][0-9]((0[48])|([13579][26])|([2468][048]))))-02-29)|(((000[1-9])|(00[1-9][0-9])|(0[1-9][0-9][0-9])|([1-9][0-9][0-9][0-9]))-((((0[13578])|(1[02]))-31)|(((0[1,3-9])|(1[0-2]))-(29|30))|(((0[1-9])|(1[0-2]))-((0[1-9])|(1[0-9])|(2[0-8]))))))$";
            #region label判断
            int flag = 0;

            //发生时间
            if (tbx_fssj.Text == "")
            {
                lbl_fssj.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(tbx_fssj.Text.ToString(), fssj))
                {
                    lbl_fssj.Text = "<span style=\"color:#ff0000\">" + "请输入正确的日期如（1996-01-02）" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_fssj.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
                }
            }

            //整改时限
            if (tbx_zgsx.Text == "")
            {
                lbl_zgsx.Text = "<span style=\"color:#ff0000\">" + "内容不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                if (!Regex.IsMatch(tbx_fssj.Text.ToString(), zgsx))
                {
                    lbl_zgsx.Text = "<span style=\"color:#ff0000\">" + "请输入正确的日期如（1996-01-02）" + "</span>";
                    flag = 1;
                }
                else
                {
                    lbl_zgsx.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
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
            dt_Detail = aqwtk.Select_AQWTK_Detail(id);
            if (Convert.ToInt32(zrrHiddenField.Value) == 0)
            {
                struct_aqwtk.p_zrr = dt_Detail.Rows[0]["zrr"].ToString(); // 整改责任人
            }
            else
            {
                struct_aqwtk.p_zrr = zrr.Substring(0, zrr.Length); // 整改责任人
            }
            #endregion
            #region 保存
            struct_aqwtk.p_id = Convert.ToString(id);
            struct_aqwtk.p_gw = ddlt_gw.SelectedValue.ToString().Trim();//岗位
            struct_aqwtk.p_aqwtmc = tbx_aqwtmc.Text.ToString().Trim();//安全问题名称
            struct_aqwtk.p_fssj = DateTime.Parse(tbx_fssj.Text.ToString().Trim());//发生时间
            struct_aqwtk.p_ly = ddlt_ly.SelectedValue.ToString().Trim();//来源
            struct_aqwtk.p_sjfc = ddlt_sjfc.SelectedValue.ToString().Trim();//涉及范畴
            struct_aqwtk.p_st = ddlt_st.SelectedValue.ToString().Trim();//时态
            struct_aqwtk.p_wxcd = ddlt_wxcd.SelectedValue.ToString().Trim();//危险程度
            struct_aqwtk.p_wtaqzt = ddlt_wtaqzt.SelectedValue.ToString().Trim();//问题安全状态
            struct_aqwtk.p_zgcsbzhqk = ddlt_zgcsbzhqk.SelectedValue.ToString().Trim();//整改措施标准化情况
            struct_aqwtk.p_wtkzzt = ddlt_wtkzzt.SelectedValue.ToString().Trim();//问题控制状态
            struct_aqwtk.p_zrbm = ddlt_zrbm.SelectedValue.ToString().Trim(); //责任部门
            struct_aqwtk.p_zrgw = ddlt_zrgw.SelectedValue.ToString().Trim(); //责任岗位
            struct_aqwtk.p_sjbm = ddlt_sjbm.SelectedValue.ToString().Trim(); // 涉及部门
            struct_aqwtk.p_zrr = ddlt_zrr.SelectedValue.ToString().Trim(); // 责任人

            struct_aqwtk.p_yfyy = tbx_yfyy.Text.ToString().Trim(); //诱发原因分析
            struct_aqwtk.p_knzchg = tbx_knzchg.Text.ToString().Trim(); //可能造成的问题或后果
            struct_aqwtk.p_hgyzcd = ddlt_hgyzcd.SelectedValue.ToString().Trim();//后果严重程度
            struct_aqwtk.p_zgcs = tbx_zgcs.Text.ToString().Trim();//整改措施
            struct_aqwtk.p_zgsx = DateTime.Parse(tbx_zgsx.Text.ToString().Trim());//整改时限
            struct_aqwtk.p_dxcs = tbx_dxcs.Text.ToString().Trim();//等效措施或预案
            struct_aqwtk.p_xgsj = tbx_ywxyxg.Text.ToString().Trim();//与危险源相关联的事件或典型案例 相关事件

            struct_aqwtk.p_bz = tbx_bz.Text.ToString().Trim(); //备注

            struct_aqwtk.p_lrr = _us.userLoginName;//录入人
            struct_aqwtk.p_csr = ddlt_csr.SelectedValue.ToString().Trim();//初审人
            struct_aqwtk.p_zsr = ddlt_zsr.SelectedValue.ToString().Trim();//终审人
            struct_aqwtk.p_bmdm = ddlt_sjszbm.SelectedValue.ToString().Trim();//数据所在部门

            struct_aqwtk.p_czfs = "01";
            struct_aqwtk.p_czxx = "位置：四库建设->安全问题库->添加 描述：岗位：" + struct_aqwtk.p_gw + "安全问题名称："
                + struct_aqwtk.p_aqwtmc + "发生时间：" + struct_aqwtk.p_fssj + "来源：" + struct_aqwtk.p_ly
                + "涉及范畴：" + struct_aqwtk.p_sjfc + "时态：" + struct_aqwtk.p_st + "危险程度： " + struct_aqwtk.p_wxcd + "问题安全状态：" + struct_aqwtk.p_wtaqzt
                + "整改措施标准化情况：" + struct_aqwtk.p_zgcsbzhqk + "问题控制状态：" + struct_aqwtk.p_wtkzzt + "责任部门：" + struct_aqwtk.p_zrbm + "责任岗位：" + struct_aqwtk.p_zrgw
                + "涉及部门：" + struct_aqwtk.p_sjbm + "责任人：" + struct_aqwtk.p_zrr + "诱发原因分析： " + struct_aqwtk.p_yfyy + "可能造成的问题或后果：" + struct_aqwtk.p_knzchg
                + "后果严重程度：" + struct_aqwtk.p_hgyzcd + "整改措施：" + struct_aqwtk.p_zgcs + "整改时限：" + struct_aqwtk.p_zgsx + "等效措施或预案：" + struct_aqwtk.p_dxcs
                + "与危险源相关联的事件或典型案例：" + struct_aqwtk.p_xgsj + "备注：" + struct_aqwtk.p_bz;
            try
            {
                string sjbs = Request.Params["sjbs"].ToString();

                if (sjbs.Equals("0") || sjbs.Equals("2"))
                {
                    aqwtk.Update_AQWTK(struct_aqwtk);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                    Server.Transfer("SKJS_AQWTK.aspx?ygbh=" + _us.userLoginName);

                }
                else if (sjbs.Equals("1") || sjbs.Equals("3"))
                {
                    //生成该数据的副本,并返回新的备份id
                    id = Convert.ToInt32(Request.Params["id"].ToString());
                    int id_bf = aqwtk.AQWTK_SJBF(Convert.ToInt32(id));
                    struct_aqwtk.p_id = Convert.ToString(id_bf);
                    aqwtk.Update_AQWTK(struct_aqwtk);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"修改成功！\")</script>");
                    Server.Transfer("SKJS_AQWTK.aspx?ygbh=" + _us.userLoginName);
                }
                else
                {
                    return;
                }
            }
            catch (EMException ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));
                return;
            }
            #endregion
        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SKJS/SKJS_AQWTK.aspx", true);
        }
    }
}