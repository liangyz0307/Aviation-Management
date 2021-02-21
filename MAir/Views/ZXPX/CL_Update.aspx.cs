using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI;
namespace CUST.WKG
{
    public partial class CL_Update : System.Web.UI.Page
    {
        private UserState _usState;
        private string id;
        private ZJ_CL zj_cl;
        private Struct_ZJ_CL struct_zj_cl;
        private DataTable dt_zj_cl;
        private long zj_cl_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            zj_cl = new ZJ_CL(_usState);
            zj_cl_id = Convert.ToInt64(Request.Params["id"].ToString().Trim());
            dt_zj_cl = zj_cl.Select_ZJ_CL_Detail(zj_cl_id);
            if (!IsPostBack)
            {
                Data_Bind();
            }
        }
        protected void Data_Bind()
        {
            tbx_mc.Text = dt_zj_cl.Rows[0]["mc"].ToString();
            tbx_zf.Text = dt_zj_cl.Rows[0]["zf"].ToString();
            tbx_xz_sl.Text = dt_zj_cl.Rows[0]["xz_sl"].ToString();
            tbx_xz_fz.Text = dt_zj_cl.Rows[0]["xz_fz"].ToString();
            tbx_dx_sl.Text = dt_zj_cl.Rows[0]["dx_sl"].ToString();
            tbx_dx_fz.Text = dt_zj_cl.Rows[0]["dx_fz"].ToString();
            tbx_pd_sl.Text = dt_zj_cl.Rows[0]["pd_sl"].ToString();
            tbx_pd_fz.Text = dt_zj_cl.Rows[0]["pd_fz"].ToString();
            tbx_tk_sl.Text = dt_zj_cl.Rows[0]["tk_sl"].ToString();
            tbx_tk_fz.Text = dt_zj_cl.Rows[0]["tk_fz"].ToString();
            tbx_sc.Text = dt_zj_cl.Rows[0]["sc"].ToString();
            //试题难度
            ddlt_stnd.DataTextField = "mc";
            ddlt_stnd.DataValueField = "bm";
            ddlt_stnd.DataSource = SysData.STND().Copy();
            ddlt_stnd.DataBind();
            ddlt_stnd.SelectedValue = dt_zj_cl.Rows[0]["nd"].ToString();
            //科目
            ddlt_km.DataTextField = "mc";
            ddlt_km.DataValueField = "bm";
            ddlt_km.DataSource = SysData.KM().Copy();
            ddlt_km.DataBind();
            ddlt_km.SelectedValue = dt_zj_cl.Rows[0]["km"].ToString();
            //类别
            cbxl_stlb.DataTextField = "mc";
            cbxl_stlb.DataValueField = "bm";
            cbxl_stlb.DataSource = SysData.STLB().Copy();
            cbxl_stlb.DataBind();
            string str_stlb = dt_zj_cl.Rows[0]["lb"].ToString();
            string[] arr_stlb = str_stlb.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arr_stlb.Length; i++)
            {
                cbxl_stlb.Items.FindByValue(arr_stlb[i].ToString()).Selected = true;
            }
            //岗位
            ddlt_gw.DataTextField = "mc";
            ddlt_gw.DataValueField = "bm";
            ddlt_gw.DataSource = SysData.GW().Copy();
            ddlt_gw.DataBind();
            ddlt_gw.SelectedValue = dt_zj_cl.Rows[0]["gw"].ToString();
        }
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
            #region 数据封装
            try
            {
                string stlb = "";
                for (int i = 0; i < arr_stlb.Count; i++)
                {
                    stlb += arr_stlb[i].ToString() + ";";
                }
                struct_zj_cl = new Struct_ZJ_CL();
                struct_zj_cl.p_id = zj_cl_id;
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
                struct_zj_cl.p_czfs = "02";
                struct_zj_cl.p_czxx = "位置：在线培训->组卷策略管理->策略编辑    策略ID：[" + id + "]  描述：";
                #region 确定哪些字段进行了修改
                int check_rz = 0;
                //试题题干
                if (struct_zj_cl.p_mc != dt_zj_cl.Rows[0]["mc"].ToString())
                {
                    //已修改
                    struct_zj_cl.p_czxx += "策略名称：【" + dt_zj_cl.Rows[0]["mc"].ToString() + "】->【" + struct_zj_cl.p_mc + "】";
                    check_rz = 1;
                }
                //试卷总分
                if ("" + struct_zj_cl.p_zf != dt_zj_cl.Rows[0]["zf"].ToString())
                {
                    //已修改
                    struct_zj_cl.p_czxx += "试卷总分：【" + dt_zj_cl.Rows[0]["zf"].ToString() + "】->【" + struct_zj_cl.p_zf + "】 ";
                    check_rz = 1;
                }
                //选择题数量
                if ("" + struct_zj_cl.p_xz_sl != dt_zj_cl.Rows[0]["xz_sl"].ToString())
                {
                    //已修改
                    struct_zj_cl.p_czxx += "选择题数量：【" + dt_zj_cl.Rows[0]["xz_sl"].ToString() + "】->【" + struct_zj_cl.p_xz_sl + "】 ";
                    check_rz = 1;
                }
                //单个选择题分值
                if ("" + struct_zj_cl.p_xz_fz != dt_zj_cl.Rows[0]["xz_fz"].ToString())
                {
                    //已修改
                    struct_zj_cl.p_czxx += "单个选择题分值：【" + dt_zj_cl.Rows[0]["xz_fz"].ToString() + "】->【" + struct_zj_cl.p_xz_fz + "】 ";
                    check_rz = 1;
                }

                //多选题数量
                if ("" + struct_zj_cl.p_dx_sl != dt_zj_cl.Rows[0]["dx_sl"].ToString())
                {
                    //已修改
                    struct_zj_cl.p_czxx += "多选题数量：【" + dt_zj_cl.Rows[0]["dx_sl"].ToString() + "】->【" + struct_zj_cl.p_dx_sl + "】 ";
                    check_rz = 1;
                }
                //单个多选题分值
                if ("" + struct_zj_cl.p_dx_fz != dt_zj_cl.Rows[0]["dx_fz"].ToString())
                {
                    //已修改
                    struct_zj_cl.p_czxx += "单个多选题分值：【" + dt_zj_cl.Rows[0]["dx_fz"].ToString() + "】->【" + struct_zj_cl.p_dx_fz + "】 ";
                    check_rz = 1;
                }
                //判断题数量
                if ("" + struct_zj_cl.p_pd_sl != dt_zj_cl.Rows[0]["pd_sl"].ToString())
                {
                    //已修改
                    struct_zj_cl.p_czxx += "判断题数量：【" + dt_zj_cl.Rows[0]["pd_sl"].ToString() + "】->【" + struct_zj_cl.p_pd_sl + "】 ";
                    check_rz = 1;
                }
                //单个判断题分值
                if ("" + struct_zj_cl.p_pd_fz != dt_zj_cl.Rows[0]["pd_fz"].ToString())
                {
                    //已修改
                    struct_zj_cl.p_czxx += "单个判断题分值：【" + dt_zj_cl.Rows[0]["pd_fz"].ToString() + "】->【" + struct_zj_cl.p_pd_fz + "】 ";
                    check_rz = 1;
                }
                //填空题数量
                if ("" + struct_zj_cl.p_tk_sl != dt_zj_cl.Rows[0]["tk_sl"].ToString())
                {
                    //已修改
                    struct_zj_cl.p_czxx += "填空题数量：【" + dt_zj_cl.Rows[0]["tk_sl"].ToString() + "】->【" + struct_zj_cl.p_tk_sl + "】 ";
                    check_rz = 1;
                }
                //单个填空题分值
                if ("" + struct_zj_cl.p_tk_fz != dt_zj_cl.Rows[0]["tk_fz"].ToString())
                {
                    //已修改
                    struct_zj_cl.p_czxx += "单个填空题分值：【" + dt_zj_cl.Rows[0]["tk_fz"].ToString() + "】->【" + struct_zj_cl.p_tk_fz + "】 ";
                    check_rz = 1;
                }
                //时长
                if ("" + struct_zj_cl.p_sc != dt_zj_cl.Rows[0]["sc"].ToString())
                {
                    //已修改
                    struct_zj_cl.p_czxx += "时长：【" + dt_zj_cl.Rows[0]["sc"].ToString() + "】->【" + struct_zj_cl.p_sc + "】 ";
                    check_rz = 1;
                }
                //试题难度
                if (struct_zj_cl.p_nd != dt_zj_cl.Rows[0]["nd"].ToString())
                {
                    //已修改
                    struct_zj_cl.p_czxx += "试卷难度：【" + dt_zj_cl.Rows[0]["nd"].ToString() + "】->【" + struct_zj_cl.p_nd + "】";
                    check_rz = 1;
                }
                //适用科目
                if (struct_zj_cl.p_km != dt_zj_cl.Rows[0]["km"].ToString())
                {
                    //已修改
                    struct_zj_cl.p_czxx += "适用科目：【" + dt_zj_cl.Rows[0]["km"].ToString() + "】->【" + struct_zj_cl.p_km + "】";
                    check_rz = 1;
                }
                //适用类别
                if (struct_zj_cl.p_lb != dt_zj_cl.Rows[0]["lb"].ToString())
                {
                    //已修改
                    struct_zj_cl.p_czxx += "适用类别：【" + dt_zj_cl.Rows[0]["lb"].ToString() + "】->【" + struct_zj_cl.p_lb + "】";
                    check_rz = 1;
                }
                //适用岗位
                if (struct_zj_cl.p_gw != dt_zj_cl.Rows[0]["gw"].ToString())
                {
                    //已修改
                    struct_zj_cl.p_czxx += "适用岗位：【" + dt_zj_cl.Rows[0]["gw"].ToString() + "】->【" + struct_zj_cl.p_gw + "】";
                    check_rz = 1;
                }
                #endregion
                if (check_rz == 0)
                {
                    struct_zj_cl.p_czxx += "未修改";
                }
                zj_cl.Update_ZJ_CL(struct_zj_cl);
                Data_Bind();

                if (check_rz == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"未做改动！\")</script>");
                }
                else
                {
                    #region 编辑成功后，验证当前题库中是否能够满足该策略
                    //1.获取该策略的ID
                    string cl_id = dt_zj_cl.Rows[0]["id"].ToString();
                    //2.判断题库中试题的数量是否足够
                    SJK sjk = new SJK(_usState);
                    string str_result = "";
                    //2.1选择题
                    //2.1.1单选题
                    DataTable dt_sum_xzt = sjk.Select_STK_By_ZJCL(cl_id, "0");
                    int maxValues_xzt = dt_sum_xzt.Rows.Count;
                    //如果题目中满足条件的题目数量小于策略，则给予提示
                    if (Convert.ToInt32(xz_sl) > maxValues_xzt)
                    {
                        str_result += "  题库中选择题数量不能满足该策略;  ";
                    }
                    //2.1.2多选题
                    DataTable dt_sum_dxt = sjk.Select_STK_By_ZJCL(cl_id, "3");
                    int maxValues_dxt = dt_sum_dxt.Rows.Count;
                    //如果题目中满足条件的题目数量小于策略，则给予提示
                    if (Convert.ToInt32(dx_sl) > maxValues_dxt)
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
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"编辑成功！ " + str_result + "\")</script>");
                    #endregion
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