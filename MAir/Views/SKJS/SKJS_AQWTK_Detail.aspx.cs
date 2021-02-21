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
    public partial class SKJS_AQWTK_Detail : System.Web.UI.Page
    {
        private UserState _us;
        private AQWTK aqwtk;
        private AQYHK aqyhk;
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
            id =Convert.ToInt32( Request.QueryString["id"]);
            if (!IsPostBack)
            {
                bind_Main();
            }
        }

        private void bind_Main()
        {
            dt_Detail = aqwtk.Select_AQWTK_Detail(id);
            dt_Detail.Columns.Add("gwmc");//岗位
            dt_Detail.Columns.Add("lymc");//来源
            dt_Detail.Columns.Add("sjfcmc");//涉及范畴
            dt_Detail.Columns.Add("stmc");//时态
            dt_Detail.Columns.Add("wxcdmc");//危险程度
            dt_Detail.Columns.Add("wtaqztmc");//问题安全状态
            dt_Detail.Columns.Add("zgcsbzhmc");//整改措施标准化情况
            dt_Detail.Columns.Add("wtkzztmc");//问题控制状态
            dt_Detail.Columns.Add("zrbmmc");//责任部门
            dt_Detail.Columns.Add("zrgwmc");//责任岗位
            dt_Detail.Columns.Add("sjbmmc");//涉及部门
            dt_Detail.Columns.Add("zrrxm");//责任人
            dt_Detail.Columns.Add("hgyzcdmc");//后果严重程度
            dt_Detail.Columns.Add("sjsubmmc");

            foreach (DataRow dr in dt_Detail.Rows)
            {
                string[] Array_zzr = dr["zrr"].ToString().Split(',');

                foreach (string zzrxm_bh in Array_zzr)
                {
                    dr["zrrxm"] = aqwtk.Select_YGXMbyBH(zzrxm_bh.ToString()).Rows[0][0].ToString();
                }
                dr["gwmc"] = SysData.GWByKey(dr["gw"].ToString()).mc;//岗位
                dr["lymc"] = SysData.LYByKey(dr["ly"].ToString()).mc; //来源
                dr["sjfcmc"] = SysData.SJFCByKey(dr["sjfc"].ToString()).mc;//涉及范畴
                dr["stmc"] = SysData.STDMByKey(dr["st"].ToString()).mc;//时态
                dr["wxcdmc"] = SysData.WXCDByKey(dr["wxcd"].ToString()).mc;//危险程度
                dr["wtaqztmc"] = SysData.AQZTByKey(dr["wtaqzt"].ToString()).mc;//问题安全状态
                dr["zgcsbzhmc"] = SysData.ZGCSBZHQKByKey(dr["zgcsbzhqk"].ToString()).mc;//整改措施标准化情况
                dr["wtkzztmc"] = SysData.WTZTByKey(dr["wtkzzt"].ToString()).mc;//问题控制状态
                dr["zrbmmc"] = SysData.BMByKey(dr["zrbm"].ToString()).mc;//责任部门
                dr["zrgwmc"] = SysData.GWByKey(dr["zrgw"].ToString()).mc;//责任岗位
                dr["sjbmmc"] = SysData.BMByKey(dr["sjbm"].ToString()).mc;//涉及部门
                dr["hgyzcdmc"] = SysData.HGYZXByKey(dr["hgyzcd"].ToString()).mc;//后果严重程度
                dr["sjsubmmc"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;

                lbl_gw.Text = dt_Detail.Rows[0]["gwmc"].ToString();//岗位
                lbl_aqwtmc.Text = dt_Detail.Rows[0]["aqwtmc"].ToString();//安全问题名称
                lbl_fssj.Text = Convert.ToDateTime(dt_Detail.Rows[0]["fssj"]).ToString("yyyy-MM-dd");//发生时间
                lbl_ly.Text = dt_Detail.Rows[0]["lymc"].ToString();//来源
                lbl_sjfc.Text = dt_Detail.Rows[0]["sjfcmc"].ToString();//涉及范畴
                lbl_st.Text = dt_Detail.Rows[0]["stmc"].ToString();//时态
                lbl_wxcd.Text = dt_Detail.Rows[0]["wxcdmc"].ToString();//危险程度
                lbl_wtaqzt.Text = dt_Detail.Rows[0]["wtaqztmc"].ToString();//问题安全状态
                lbl_zgcsbzhqk.Text = dt_Detail.Rows[0]["zgcsbzhmc"].ToString();//整改措施标准化情况
                lbl_wtkzzt.Text = dt_Detail.Rows[0]["wtkzztmc"].ToString();//问题控制状态
                lbl_zrbm.Text = dt_Detail.Rows[0]["zrbmmc"].ToString();//责任部门
                lbl_zrgw.Text = dt_Detail.Rows[0]["zrgwmc"].ToString();//责任岗位
                lbl_sjbm.Text = dt_Detail.Rows[0]["sjbmmc"].ToString();// 涉及部门
                lbl_zrr.Text = dt_Detail.Rows[0]["zrrxm"].ToString(); // 责任人

                lbl_yfyy.Text = dt_Detail.Rows[0]["yfyy"].ToString();//诱发原因分析
                lbl_knzchg.Text = dt_Detail.Rows[0]["knzchg"].ToString();//可能造成的问题或后果
                lbl_hgyzcd.Text = dt_Detail.Rows[0]["hgyzcdmc"].ToString();//后果严重程度
                lbl_zgcs.Text = dt_Detail.Rows[0]["zgcs"].ToString();//整改措施
                lbl_zgsx.Text = Convert.ToDateTime(dt_Detail.Rows[0]["zgsx"]).ToString("yyyy-MM-dd");//整改时限
                lbl_dxcs.Text = dt_Detail.Rows[0]["dxcs"].ToString();//等效措施或预案
                lbl_ywxyxg.Text = dt_Detail.Rows[0]["xgsj"].ToString();//与危险源相关联的事件或典型案例 相关事件

                lbl_lrr.Text = dt_Detail.Rows[0]["lrrxm"].ToString();//录入人
                lbl_csr.Text = dt_Detail.Rows[0]["csrxm"].ToString();//初审人
                lbl_zsr.Text = dt_Detail.Rows[0]["zsrxm"].ToString();//终审人
                lbl_shjsbmmc.Text = dt_Detail.Rows[0]["sjsubmmc"].ToString();

                lbl_bz.Text = dt_Detail.Rows[0]["bz"].ToString();//备注

            }
        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SKJS/SKJS_AQWTK.aspx", true);
        }

    }
}
