using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace CUST.WKG
{
    public partial class CL_Add : System.Web.UI.Page
    {
        private UserState _usState;
        private string id;
        private ZJ_CL zj_cl;
        private Struct_ZJ_CL struct_zj_cl;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            zj_cl = new ZJ_CL(_usState);
            if (!IsPostBack)
            {
                ddltBind();
            }
        }
        #region 下拉框绑定
        protected void ddltBind()
        {
            //试题难度
            ddlt_stnd.DataTextField = "mc";
            ddlt_stnd.DataValueField = "bm";
            ddlt_stnd.DataSource = SysData.STND().Copy();
            ddlt_stnd.DataBind();
            ddlt_stnd.Items.Insert(0, new ListItem("请选择", "-1"));
            //科目
            ddlt_km.DataTextField = "mc";
            ddlt_km.DataValueField = "bm";
            ddlt_km.DataSource = SysData.KM().Copy();
            ddlt_km.DataBind();
            ddlt_km.Items.Insert(0, new ListItem("请选择", "-1"));

            //类别
            cbxl_stlb.DataTextField = "mc";
            cbxl_stlb.DataValueField = "bm";
            cbxl_stlb.DataSource = SysData.STLB().Copy();
            cbxl_stlb.DataBind();
            //岗位
            ddlt_gw.DataTextField = "mc";
            ddlt_gw.DataValueField = "bm";
            ddlt_gw.DataSource = SysData.GW().Copy();
            ddlt_gw.DataBind();
            ddlt_gw.Items.Insert(0, new ListItem("请选择", "-1"));
        }
        #endregion
        protected void btn_save_Click(object sender, EventArgs e)
        {
            #region 数据校验
            int flag = 0;
            string reg_num3 = @"^\d{1,3}$";//可以是1-3位整数

            string reg_fz = @"^[0-9]{1,2}(.[0-9]{0,2})?$";//分值可以是2位小数，2位整数

            //1.组卷名称
            string mc = tbx_mc.Text.ToString().Trim();
            if (string.IsNullOrEmpty(mc))
            {
                lbl_mc.Text = "<span style=\"color:#ff0000\">" + "错误：组卷名称不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_mc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //2.试卷总分
            string zf = tbx_zf.Text.ToString().Trim();
            if (string.IsNullOrEmpty(zf) || !Regex.IsMatch(zf, reg_num3))
            {
                lbl_zf.Text = "<span style=\"color:#ff0000\">" + "错误：总分必须为1-3位整数" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zf.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //3.选择题数量
            string xz_sl = tbx_xz_sl.Text.ToString().Trim();
            if (string.IsNullOrEmpty(xz_sl) || !Regex.IsMatch(xz_sl, reg_num3))
            {
                lbl_xz_sl.Text = "<span style=\"color:#ff0000\">" + "错误：选择题数量范围为0-999" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_xz_sl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //4.选择分值
            string xz_fz = tbx_xz_fz.Text.ToString().Trim();
            if (string.IsNullOrEmpty(xz_fz) || !Regex.IsMatch(xz_fz, reg_fz))
            {
                lbl_xz_fz.Text = "<span style=\"color:#ff0000\">" + "错误：单题分值范围为0.01-99.99" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_xz_fz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //3.1.选择题数量
            string dx_sl = tbx_dx_sl.Text.ToString().Trim();
            if (string.IsNullOrEmpty(dx_sl) || !Regex.IsMatch(dx_sl, reg_num3))
            {
                lbl_dx_sl.Text = "<span style=\"color:#ff0000\">" + "错误：选择题数量范围为0-999" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_dx_sl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //4.1.选择分值
            string dx_fz = tbx_dx_fz.Text.ToString().Trim();
            if (string.IsNullOrEmpty(dx_fz) || !Regex.IsMatch(dx_fz, reg_fz))
            {
                lbl_dx_fz.Text = "<span style=\"color:#ff0000\">" + "错误：单题分值范围为0.01-99.99" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_dx_fz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //5.判断数量
            string pd_sl = tbx_pd_sl.Text.ToString().Trim();
            if (string.IsNullOrEmpty(pd_sl) || !Regex.IsMatch(pd_sl, reg_num3))
            {
                lbl_pd_sl.Text = "<span style=\"color:#ff0000\">" + "错误：判断题数量范围为0-999" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_pd_sl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //6.判断分值
            string pd_fz = tbx_pd_fz.Text.ToString().Trim();
            if (string.IsNullOrEmpty(pd_fz) || !Regex.IsMatch(pd_fz, reg_fz))
            {
                lbl_pd_fz.Text = "<span style=\"color:#ff0000\">" + "错误：单题分值范围为0.01-99.99" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_pd_fz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //7.填空数量
            string tk_sl = tbx_tk_sl.Text.ToString().Trim();
            if (string.IsNullOrEmpty(tk_sl) || !Regex.IsMatch(tk_sl, reg_num3))
            {
                lbl_tk_sl.Text = "<span style=\"color:#ff0000\">" + "错误：填空题数量范围为0-999" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_tk_sl.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //8.填空分值
            string tk_fz = tbx_tk_fz.Text.ToString().Trim();
            if (string.IsNullOrEmpty(tk_fz) || !Regex.IsMatch(tk_fz, reg_fz))
            {
                lbl_tk_fz.Text = "<span style=\"color:#ff0000\">" + "错误：单题分值范围为0.01-99.99" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_tk_fz.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //判断总分是否等于各题分值之和
            double countZF = Convert.ToInt32(xz_sl) * Convert.ToDouble(xz_fz)
                           + Convert.ToInt32(dx_sl) * Convert.ToDouble(dx_fz)
                           + Convert.ToInt32(pd_sl) * Convert.ToDouble(pd_fz)
                           + Convert.ToInt32(tk_sl) * Convert.ToDouble(tk_fz);
            if (countZF != Convert.ToDouble(zf))
            {
                lbl_zf.Text = "<span style=\"color:#ff0000\">" + "错误：总分不等于各题分值之和" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_zf.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //9.时长
            string sc = tbx_sc.Text.ToString().Trim();
            if (string.IsNullOrEmpty(sc) || !Regex.IsMatch(sc, reg_num3))
            {
                lbl_sc.Text = "<span style=\"color:#ff0000\">" + "错误：时长必须为1-3位整数" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_sc.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //10.试题难度
            string nd = ddlt_stnd.SelectedValue.ToString().Trim();
            if (nd == "-1")
            {
                lbl_nd.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_nd.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //11.科目
            string km = ddlt_km.SelectedValue.ToString().Trim();
            if (km == "-1")
            {
                lbl_km.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_km.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //12.岗位
            string gw = ddlt_gw.SelectedValue.ToString().Trim();
            if (gw == "-1")
            {
                lbl_gw.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_gw.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            //类别
            ArrayList arr_stlb = new ArrayList();
            for (int i = 0; i < cbxl_stlb.Items.Count; i++)
            {
                if (cbxl_stlb.Items[i].Selected)
                {
                    arr_stlb.Add(cbxl_stlb.Items[i].Value);
                }
            }
            if (arr_stlb.Count == 0)
            {
                lbl_stlb.Text = "<span style=\"color:#ff0000\">" + "请选择" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_stlb.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            if (flag == 1)
            {
                tbx_mc.Text = mc;
                tbx_zf.Text = zf;
                tbx_xz_sl.Text = xz_sl;
                tbx_xz_fz.Text = xz_fz;
                tbx_pd_sl.Text = pd_sl;
                tbx_pd_fz.Text = pd_fz;
                tbx_tk_sl.Text = tk_sl;
                tbx_tk_fz.Text = tk_fz;
                tbx_sc.Text = sc;
                ddlt_stnd.SelectedValue = nd;
                ddlt_km.SelectedValue = km;
                ddlt_gw.SelectedValue = gw;
                for (int i = 0; i < arr_stlb.Count; i++)
                {
                    cbxl_stlb.Items.FindByValue(arr_stlb[i].ToString()).Selected = true;
                }
                return;
            }
            #endregion
            #region 数据封装,添加
            try
            {
                string stlb = "";
                for (int i = 0; i < arr_stlb.Count; i++)
                {
                    stlb += arr_stlb[i].ToString() + ";";
                }
                struct_zj_cl = new Struct_ZJ_CL();
                struct_zj_cl.p_mc = mc;
                struct_zj_cl.p_zf = Convert.ToInt32(zf);
                struct_zj_cl.p_xz_sl = Convert.ToInt32(xz_sl);
                struct_zj_cl.p_xz_fz = Convert.ToDouble(xz_fz);
                struct_zj_cl.p_dx_sl = Convert.ToInt32(dx_sl);
                struct_zj_cl.p_dx_fz = Convert.ToDouble(dx_fz);
                struct_zj_cl.p_pd_sl = Convert.ToInt32(pd_sl);
                struct_zj_cl.p_pd_fz = Convert.ToDouble(pd_fz);
                struct_zj_cl.p_tk_sl = Convert.ToInt32(tk_sl);
                struct_zj_cl.p_tk_fz = Convert.ToDouble(tk_fz);
                struct_zj_cl.p_sc = Convert.ToInt32(sc);
                struct_zj_cl.p_nd = nd;
                struct_zj_cl.p_km = km;
                struct_zj_cl.p_lb = stlb;
                struct_zj_cl.p_gw = gw;
                struct_zj_cl.p_czfs = "01";
                struct_zj_cl.p_czxx = "位置：在线培训->组卷策略管理->策略添加  策略名称" + mc + "， 总分：" + zf +
                    "， 选择题数量：" + xz_sl + "，选择题分值：" + xz_fz + "， 判断数量：" + pd_sl + "， 判断分值：" + pd_fz +
                    "， 填空题数量：" + tk_sl + "，填空题分值：" + tk_fz + "， 时长：" + sc +
                    "，试题难度：" + nd + " ，适用科目：" + km + "，适用岗位：" + gw;
                zj_cl.Insert_ZJ_CL(struct_zj_cl);

                //添加成功后，验证当前题库中是否能够满足该策略
                //1.获取该策略的ID
                Struct_Select_ZJ_CL struct_CL_Select = new Struct_Select_ZJ_CL();
                struct_CL_Select.p_mc = mc;
                struct_CL_Select.p_nd = nd;
                struct_CL_Select.p_km = km;
                struct_CL_Select.p_gw = gw;
                struct_CL_Select.p_lb = stlb;
                struct_CL_Select.p_zt = "0";
                struct_CL_Select.p_currentpage = 1;
                struct_CL_Select.p_pagesize = 2;
                DataTable dt_CL = zj_cl.Select_ZJ_CL_Pro(struct_CL_Select);
                string cl_id = dt_CL.Rows[0]["id"].ToString();
                //2.判断题库中试题的数量是否足够
                SJK sjk = new SJK(_usState);
                string str_result = "";
                //2.1选择题
                DataTable dt_sum_xzt = sjk.Select_STK_By_ZJCL(cl_id, "0");
                int maxValues_xzt = dt_sum_xzt.Rows.Count;
                //如果题目中满足条件的题目数量小于策略，则给予提示
                if (Convert.ToInt32(xz_sl) > maxValues_xzt)
                {
                    str_result += "  题库中单选题数量不能满足该策略;  ";
                }
                //2.1.2多选
                DataTable dt_sum_dx = sjk.Select_STK_By_ZJCL(cl_id, "3");
                int maxValues_dx = dt_sum_dx.Rows.Count;
                //如果题目中满足条件的题目数量小于策略，则给予提示
                if (Convert.ToInt32(dx_sl) > maxValues_dx)
                {
                    str_result += "  题库中多选题数量不能满足该策略;  ";
                }
                //2.2判断题
                DataTable dt_sum_pdt = sjk.Select_STK_By_ZJCL(cl_id, "1");
                int maxValues_pdt = dt_sum_pdt.Rows.Count;
                //如果题目中满足条件的题目数量小于策略，则给予提示
                if (Convert.ToInt32(pd_sl) > maxValues_pdt)
                {
                    str_result += "题库中判断题数量不能满足该策略;  ";
                }
                //2.3填空题
                DataTable dt_sum_tkt = sjk.Select_STK_By_ZJCL(cl_id, "2");
                int maxValues_tkt = dt_sum_tkt.Rows.Count;
                //如果题目中满足条件的题目数量小于策略，则给予提示
                if (Convert.ToInt32(tk_sl) > maxValues_tkt)
                {
                    str_result += "题库中填空题数量不能满足该策略;  ";
                }
                if (str_result != "")
                {
                    str_result += "  请联系管理员，及时补充题库！";
                }
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"添加成功！" + str_result + "\")</script>");
            }
            catch (EMException ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));
                return;
            }
            #endregion
            #region 添加成功，进行清除
            tbx_mc.Text = "";
            tbx_zf.Text = "";
            tbx_xz_sl.Text = "";
            tbx_xz_fz.Text = "";
            tbx_dx_sl.Text = "";
            tbx_dx_fz.Text = "";
            tbx_pd_sl.Text = "";
            tbx_pd_fz.Text = "";
            tbx_tk_sl.Text = "";
            tbx_tk_fz.Text = "";
            tbx_sc.Text = "";
            ddlt_stnd.SelectedValue = "-1";
            ddlt_km.SelectedValue = "-1";
            ddlt_gw.SelectedValue = "-1";
            for (int i = 0; i < cbxl_stlb.Items.Count; i++)
            {
                cbxl_stlb.Items[i].Selected = false;
            }
            lbl_mc.Text = "";
            lbl_zf.Text = "";
            lbl_xz_sl.Text = "";
            lbl_xz_fz.Text = "";
            lbl_dx_sl.Text = "";
            lbl_dx_fz.Text = "";
            lbl_pd_sl.Text = "";
            lbl_pd_fz.Text = "";
            lbl_tk_sl.Text = "";
            lbl_tk_fz.Text = "";
            lbl_sc.Text = "";
            lbl_nd.Text = "";
            lbl_km.Text = "";
            lbl_gw.Text = "";
            lbl_stlb.Text = "";
            #endregion

        }
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../ZXPX/CLGL.aspx", true);
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
    }
}