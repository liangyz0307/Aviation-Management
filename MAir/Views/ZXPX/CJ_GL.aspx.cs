using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace CUST.WKG.ZXPX.main
{
    public partial class CJ_GL : System.Web.UI.Page
    {
        private UserState _usState;
        public int cpage;
        public int psize;
        private ZJ_CL zj_cl;
        private SJK sjk;
        private DJK djk;
        private Random random;
        static DataTable dt_cl;
        private Struct_Select_ZJ_CL struct_cl;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            cpage = pg_fy.CurrentPage;
            psize = pg_fy.NumPerPage;
            zj_cl = new ZJ_CL(_usState);
            sjk = new SJK(_usState);
            djk = new DJK(_usState);
            random = new Random();
            if (!IsPostBack)
            {
                ddltBind();
                Bind_Select();
            }
        }
        private void ddltBind()
        {
            //试题难度
            ddlt_stnd.DataTextField = "mc";
            ddlt_stnd.DataValueField = "bm";
            ddlt_stnd.DataSource = SysData.STND().Copy();
            ddlt_stnd.DataBind();
            ddlt_stnd.Items.Insert(0, new ListItem("全部", "-1"));
            //科目
            ddlt_km.DataTextField = "mc";
            ddlt_km.DataValueField = "bm";
            ddlt_km.DataSource = SysData.KM().Copy();
            ddlt_km.DataBind();
            ddlt_km.Items.Insert(0, new ListItem("全部", "-1"));
            //类别
            ddlt_lb.DataTextField = "mc";
            ddlt_lb.DataValueField = "bm";
            ddlt_lb.DataSource = SysData.STLB().Copy();
            ddlt_lb.DataBind();
            ddlt_lb.Items.Insert(0, new ListItem("全部", "-1"));
            //岗位
            ddlt_gw.DataTextField = "mc";
            ddlt_gw.DataValueField = "bm";
            ddlt_gw.DataSource = SysData.GW().Copy();
            ddlt_gw.DataBind();
            ddlt_gw.Items.Insert(0, new ListItem("全部", "-1"));
        }
        private void Bind_Select()
        {
            struct_cl = new Struct_Select_ZJ_CL();
            struct_cl.p_mc = tbx_mc.Text.Trim();
            struct_cl.p_nd = ddlt_stnd.SelectedValue.ToString();
            struct_cl.p_km = ddlt_km.SelectedValue.ToString();
            struct_cl.p_lb = ddlt_lb.SelectedValue.ToString();
            struct_cl.p_gw = ddlt_gw.SelectedValue.ToString();
            struct_cl.p_zt = "2";//---审核通过的
            struct_cl.p_currentpage = pg_fy.CurrentPage;
            struct_cl.p_pagesize = pg_fy.NumPerPage;
            int count = zj_cl.Select_ZJ_CL_Count(struct_cl);
            dt_cl = zj_cl.Select_ZJ_CL_Pro(struct_cl);
            pg_fy.TotalRecord = count;
            dt_cl.Columns.Add("stnd");
            dt_cl.Columns.Add("sykm");
            dt_cl.Columns.Add("stlb");
            dt_cl.Columns.Add("sygw");
            foreach (DataRow dr in dt_cl.Rows)
            {
                dr["stnd"] = SysData.STNDByKey(dr["nd"].ToString()).mc;
                dr["sykm"] = SysData.KMByKey(dr["km"].ToString()).mc;
                dr["sygw"] = SysData.GWByKey(dr["gw"].ToString()).mc;
                //类别
                string str_stlb = dr["lb"].ToString();
                string[] arr_stlb = str_stlb.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                string stlb = "";
                for (int i = 0; i < arr_stlb.Length; i++)
                {
                    stlb += SysData.STLBByKey(arr_stlb[i]).mc + ";";
                }
                dr["stlb"] = stlb;
            }
            //绑定分页数据源  
            this.dlt_cl.DataSource = dt_cl.DefaultView;
            this.dlt_cl.DataBind();
        }
        protected void btn_select_Click(object sender, EventArgs e)
        {
            Bind_Select();
        }
        protected void dlt_cl_ItemCommand(object source, DataListCommandEventArgs e)
        {
            string zj_cl_id = e.CommandArgument.ToString();
            if (e.CommandName == "CJ_CX")
            {
                Response.Redirect("../ZXPX/CJ_Detial.aspx?id=" + zj_cl_id, true);
            }
            else if (e.CommandName == "KS_KS")
            {
                try
                {
                    #region 1.判断该策略下，当前考生是否有未完成的试卷
                    DataTable dt_djk_WWC = djk.Select_DJK_By_KSH_CL_ZT(zj_cl_id, _usState.userLoginName, "0");//未完成答卷
                    //能够继续考试有两个条件：1.考生尚未交卷，2.考试的时间未结束
                    if (dt_djk_WWC.Rows.Count != 0)
                    {//考生尚未交卷
                        string Temp_dj_id = dt_djk_WWC.Rows[0]["id"].ToString();
                        int Temp_sc = Convert.ToInt32(dt_djk_WWC.Rows[0]["sc"].ToString());
                        double hs = Convert.ToDouble(dt_djk_WWC.Rows[0]["hs"].ToString());
                        DateTime Temp_JSSJ = Convert.ToDateTime(dt_djk_WWC.Rows[0]["kssj"].ToString()).AddMinutes(hs);
                        if (hs < Temp_sc)//如果还在考试的时间范围内，则允许其继续考试
                        {
                            //更新开始考试时间
                            string t_czfs = "03";
                            string t_czxx = "位置：在线培训->考试管理->开始考试 重新考试  答卷id：" + Temp_dj_id;
                            djk.Update_DJK_KSSJ(Temp_dj_id, t_czfs, t_czxx);
                            //给予提示
                            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"当前考试尚未结束，请继续答题！  \")</script>");
                            // 跳转到指定界面
                            Response.Write("<script>window.open('../ZXPX/KS_KS.aspx?id=" + Temp_dj_id + "','_blank',' resizable=yes,directories=no,resizable=no,top=0,left=0,width=10000,height=10000',true)</script>");
                            return;
                        }
                        else
                        { //如果已经过了考试的时间了，将自动交卷---然后重新组卷，让考生答题
                            Struct_DJK struct_djk_end = new Struct_DJK();
                            struct_djk_end.p_id = Convert.ToInt64(Temp_dj_id);
                            struct_djk_end.p_jssj = Temp_JSSJ;
                            struct_djk_end.p_zt = "1";
                            struct_djk_end.p_czfs = "03";
                            struct_djk_end.p_czxx = "位置：在线培训->考试管理->开始考试 分数统计  答卷id：" + Temp_dj_id;
                            djk.Update_DJK(struct_djk_end);
                        }
                    }
                    #endregion
                    //获取策略详情
                    long cl_id = Convert.ToInt64(zj_cl_id);
                    DataTable dt_zj_cl = zj_cl.Select_ZJ_CL_Detail(cl_id);
                    string mc = dt_zj_cl.Rows[0]["mc"].ToString();
                    int zf = Convert.ToInt32(dt_zj_cl.Rows[0]["zf"].ToString());
                    int xz_sl = Convert.ToInt32(dt_zj_cl.Rows[0]["xz_sl"].ToString());
                    double xz_fz = Convert.ToDouble(dt_zj_cl.Rows[0]["xz_fz"].ToString());
                    int dx_sl = Convert.ToInt32(dt_zj_cl.Rows[0]["dx_sl"].ToString());
                    double dx_fz = Convert.ToDouble(dt_zj_cl.Rows[0]["dx_fz"].ToString());
                    int pd_sl = Convert.ToInt32(dt_zj_cl.Rows[0]["pd_sl"].ToString());
                    double pd_fz = Convert.ToDouble(dt_zj_cl.Rows[0]["pd_fz"].ToString());
                    int tk_sl = Convert.ToInt32(dt_zj_cl.Rows[0]["tk_sl"].ToString());
                    double tk_fz = Convert.ToDouble(dt_zj_cl.Rows[0]["tk_fz"].ToString());
                    int sc = Convert.ToInt32(dt_zj_cl.Rows[0]["sc"].ToString());
                    string nd = dt_zj_cl.Rows[0]["nd"].ToString();
                    string km = dt_zj_cl.Rows[0]["km"].ToString();
                    string lb = dt_zj_cl.Rows[0]["lb"].ToString();
                    string gw = dt_zj_cl.Rows[0]["gw"].ToString();
                    #region 2.判断 题库中试题的数量是否足够
                    //2.先判断题库中试题的数量是否足够
                    string str_result = "";
                    //2.1选择题
                    //2.1.1单选题
                    DataTable dt_sum_xzt = sjk.Select_STK_By_ZJCL("" + cl_id, "0");
                    int maxValues_xzt = dt_sum_xzt.Rows.Count;
                    //如果题目中满足条件的题目数量小于策略，则给予提示
                    if (xz_sl > maxValues_xzt)
                    {
                        str_result += "题库中单选题数量不足;";
                    }
                    //2.1.2多选题
                    DataTable dt_sum_dxt = sjk.Select_STK_By_ZJCL("" + cl_id, "3");
                    int maxValues_dxt = dt_sum_dxt.Rows.Count;
                    //如果题目中满足条件的题目数量小于策略，则给予提示
                    if (dx_sl > maxValues_dxt)
                    {
                        str_result += "题库中多选题数量不足;";
                    }
                    //2.2判断题
                    DataTable dt_sum_pdt = sjk.Select_STK_By_ZJCL("" + cl_id, "1");
                    int maxValues_pdt = dt_sum_pdt.Rows.Count;
                    //如果题目中满足条件的题目数量小于策略，则给予提示
                    if (pd_sl > maxValues_pdt)
                    {
                        str_result += "题库中判断题数量不足;";
                    }
                    //2.3填空题
                    DataTable dt_sum_tkt = sjk.Select_STK_By_ZJCL("" + cl_id, "2");
                    int maxValues_tkt = dt_sum_tkt.Rows.Count;
                    //如果题目中满足条件的题目数量小于策略，则给予提示
                    if (tk_sl > maxValues_tkt)
                    {
                        str_result += "题库中填空题数量不足;";
                    }
                    if (str_result != "")
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"当前考试不能进行 ： " + str_result + " 请联系管理员！  \")</script>");
                        return;
                    }
                    #endregion
                    //3.生成答题
                    string p_zj_cl_id = "" + cl_id;
                    string p_czfs = "01";
                    string p_czxx = "位置：在线培训->考试管理->开始考试  答卷库添加  策略ID：" + cl_id + " 考生号： " + _usState.userLoginName;
                    long dj_id = Convert.ToInt64(djk.Insert_DJK(p_zj_cl_id, p_czfs, p_czxx));
                    #region 4.随机组卷
                    //4.1随机抽取满足组卷策略的选择题
                    //4.1.1单选题
                    int[] arr_xzt_flag = new int[maxValues_xzt];
                    int temp_index_xzt = 0;
                    Struct_SJK struct_sjk = new Struct_SJK();
                    struct_sjk.p_dj_id = dj_id;
                    struct_sjk.p_st_lx = "0";
                    struct_sjk.p_st_fz = xz_fz;
                    struct_sjk.p_ks_da = "";
                    struct_sjk.p_df = 0;
                    struct_sjk.p_czfs = "01";
                    for (int i = 0; i < xz_sl; )
                    {
                        temp_index_xzt = random.Next(maxValues_xzt);
                        if (arr_xzt_flag[temp_index_xzt] != 1)
                        {
                            struct_sjk.p_st_id = Convert.ToInt64(dt_sum_xzt.Rows[temp_index_xzt]["id"].ToString());
                            struct_sjk.p_st_bh = i + 1;
                            struct_sjk.p_czxx = "位置：在线培训->考试管理->开始考试  试卷库添加  考试名称：" + mc
                                + " 考生号： " + _usState.userLoginName
                                + "试题编号：" + i + 1
                                + " 试题id：" + struct_sjk.p_st_id;
                            sjk.Insert_SJK(struct_sjk);
                            //标识该题号已经被取走
                            arr_xzt_flag[temp_index_xzt] = 1;
                            i++;
                        }
                    }
                    //4.1.2多选题
                    int[] arr_dxt_flag = new int[maxValues_dxt];
                    int temp_index_dxt = 0;
                    struct_sjk.p_dj_id = dj_id;
                    struct_sjk.p_st_lx = "3";
                    struct_sjk.p_st_fz = dx_fz;
                    struct_sjk.p_ks_da = "";
                    struct_sjk.p_df = 0;
                    struct_sjk.p_czfs = "01";
                    for (int i = 0; i < dx_sl; )
                    {
                        temp_index_dxt = random.Next(maxValues_dxt);
                        if (arr_dxt_flag[temp_index_dxt] != 1)
                        {
                            struct_sjk.p_st_id = Convert.ToInt64(dt_sum_dxt.Rows[temp_index_dxt]["id"].ToString());
                            struct_sjk.p_st_bh = i + 1;
                            struct_sjk.p_czxx = "位置：在线培训->考试管理->开始考试  试卷库添加  考试名称：" + mc
                                + " 考生号： " + _usState.userLoginName
                                + "试题编号：" + i + 1
                                + " 试题id：" + struct_sjk.p_st_id;
                            sjk.Insert_SJK(struct_sjk);
                            //标识该题号已经被取走
                            arr_dxt_flag[temp_index_dxt] = 1;
                            i++;
                        }
                    }
                    //4.2随机抽取满足组卷策略的判断题
                    int[] arr_pdt_flag = new int[maxValues_pdt];
                    int temp_index_pdt = random.Next(maxValues_pdt);
                    Struct_SJK struct_sjk_pdt = new Struct_SJK();
                    struct_sjk_pdt.p_dj_id = dj_id;
                    struct_sjk_pdt.p_st_lx = "1";
                    struct_sjk_pdt.p_st_fz = pd_fz;
                    struct_sjk_pdt.p_ks_da = "";
                    struct_sjk_pdt.p_df = 0;
                    struct_sjk_pdt.p_czfs = "01";
                    for (int i = 0; i < pd_sl; )
                    {
                        temp_index_pdt = random.Next(maxValues_pdt);
                        if (arr_pdt_flag[temp_index_pdt] != 1)
                        {
                            struct_sjk_pdt.p_st_id = Convert.ToInt64(dt_sum_pdt.Rows[temp_index_pdt]["id"].ToString());
                            struct_sjk_pdt.p_st_bh = i + 1;
                            struct_sjk_pdt.p_czxx = "位置：在线培训->考试管理->开始考试  试卷库添加  考试名称：" + mc
                                + " 考生号： " + _usState.userLoginName
                                + "试题编号：" + i + 1
                                + " 试题id：" + struct_sjk_pdt.p_st_id;
                            sjk.Insert_SJK(struct_sjk_pdt);
                            //标识该题号已经被取走
                            arr_pdt_flag[temp_index_pdt] = 1;
                            i++;
                        }
                    }
                    //4.3随机抽取满足组卷策略的填空题
                    int[] arr_tkt_flag = new int[maxValues_tkt];
                    int temp_index_tkt = random.Next(maxValues_tkt);
                    Struct_SJK struct_sjk_tkt = new Struct_SJK();
                    struct_sjk_tkt.p_dj_id = dj_id;
                    struct_sjk_tkt.p_st_lx = "2";
                    struct_sjk_tkt.p_st_fz = tk_fz;
                    struct_sjk_tkt.p_ks_da = "";
                    struct_sjk_tkt.p_df = 0;
                    struct_sjk_tkt.p_czfs = "01";
                    for (int i = 0; i < tk_sl; )
                    {
                        temp_index_tkt = random.Next(maxValues_tkt);
                        if (arr_tkt_flag[temp_index_tkt] != 1)
                        {
                            struct_sjk_tkt.p_st_id = Convert.ToInt64(dt_sum_tkt.Rows[temp_index_tkt]["id"].ToString());
                            struct_sjk_tkt.p_st_bh = i + 1;
                            struct_sjk_tkt.p_czxx = "位置：在线培训->考试管理->开始考试  试卷库添加  考试名称：" + mc
                                + " 考生号： " + _usState.userLoginName
                                + "试题编号：" + i + 1
                                + " 试题id：" + struct_sjk_tkt.p_st_id;
                            sjk.Insert_SJK(struct_sjk_tkt);
                            //标识该题号已经被取走
                            arr_tkt_flag[temp_index_tkt] = 1;
                            i++;
                        }
                    }
                    #endregion
                    // 跳转到指定界面
                    Response.Write("<script>window.open('../ZXPX/KS_KS.aspx?id=" + dj_id + "','_blank',' resizable=yes,directories=no,resizable=no,top=0,left=0,width=10000,height=10000',true)</script>");
                }
                catch (EMException ex)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));
                    return;
                }
            }
            Bind_Select();
        }
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            Bind_Select();
        }
        #region 错误信息
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
        #endregion
    }
}