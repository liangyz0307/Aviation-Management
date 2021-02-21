using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace CUST.WKG.ZXPX.main
{
    public partial class CL_Select : System.Web.UI.Page
    {
        private UserState _usState;
        private ZJ_CL zj_cl;
        private SJK sjk;
        private DJK djk;
        private Random random;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            zj_cl = new ZJ_CL(_usState);
            sjk = new SJK(_usState);
            djk = new DJK(_usState);
            random = new Random();
            if (!IsPostBack)
            {
                ddlt_Bind();
                tab_cz.Visible = false;
                if (!SysData.HasThisQX("190301", _usState.userID))
                {
                    tbx_ksh.Text = _usState.userLoginName;
                    tbx_ksh.Enabled = false;
                }
            }
        }
        protected void ddlt_Bind()
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
            //岗位
            ddlt_gw.DataTextField = "mc";
            ddlt_gw.DataValueField = "bm";
            ddlt_gw.DataSource = SysData.GW().Copy();
            ddlt_gw.DataBind();
            ddlt_gw.Items.Insert(0, new ListItem("全部", "-1"));
            Struct_Select_ZJ_CL struct_cl = new Struct_Select_ZJ_CL();
            struct_cl.p_mc = "";
            struct_cl.p_nd = "-1";
            struct_cl.p_km = "-1";
            struct_cl.p_gw = "-1";
            struct_cl.p_zt = "2";
            int count = zj_cl.Select_ZJ_CL_Count(struct_cl);
            struct_cl.p_currentpage = 1;
            struct_cl.p_pagesize = count;
            DataTable dt_cl = zj_cl.Select_ZJ_CL_Pro(struct_cl);
            ddlt_zj_cl.DataTextField = "mc";
            ddlt_zj_cl.DataValueField = "id";
            ddlt_zj_cl.DataSource = dt_cl;
            ddlt_zj_cl.DataBind();
            ddlt_zj_cl.Items.Insert(0, new ListItem("请选择", "-1"));
        }
        protected void table_Init()
        {
            lbl_mc.Text = "";
            lbl_zf.Text = "";
            lbl_xz_sl.Text = "";
            lbl_xz_fz.Text = "";
            lbl_pd_sl.Text = "";
            lbl_pd_fz.Text = "";
            lbl_tk_sl.Text = "";
            lbl_tk_fz.Text = "";
            lbl_sc.Text = "";
            lbl_nd.Text = "";
            lbl_km.Text = "";
            lbl_gw.Text = "";
            lbl_ctr.Text = "";
            lbl_ctsj.Text = "";
            tab_cz.Visible = false;
            dlt_djk.Visible = false;
        }
        protected void btn_ksks_Click(object sender, EventArgs e)
        {
            string D_cl_id = ddlt_zj_cl.SelectedValue.ToString();//下拉框选择的策略
            string H_cl_id = HF_cl_id.Value;//页面显示的策略
            if (D_cl_id != H_cl_id)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"请先查询考试详细信息！\")</script>");
                return;
            }
            try
            {
                //1.判断该策略下，当前考生是否有未完成的试卷
                DataTable dt_djk_WWC = djk.Select_DJK_By_KSH_CL_ZT(H_cl_id, _usState.userLoginName, "0");//未完成答卷
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
                //2.获取策略详情
                long cl_id = Convert.ToInt64(H_cl_id);
                DataTable dt_zj_cl = zj_cl.Select_ZJ_CL_Detail(cl_id);
                string mc = dt_zj_cl.Rows[0]["mc"].ToString();
                int zf = Convert.ToInt32(dt_zj_cl.Rows[0]["zf"].ToString());
                int xz_sl = Convert.ToInt32(dt_zj_cl.Rows[0]["xz_sl"].ToString());
                int xz_fz = Convert.ToInt32(dt_zj_cl.Rows[0]["xz_fz"].ToString());
                int pd_sl = Convert.ToInt32(dt_zj_cl.Rows[0]["pd_sl"].ToString());
                int pd_fz = Convert.ToInt32(dt_zj_cl.Rows[0]["pd_fz"].ToString());
                int tk_sl = Convert.ToInt32(dt_zj_cl.Rows[0]["tk_sl"].ToString());
                int tk_fz = Convert.ToInt32(dt_zj_cl.Rows[0]["tk_fz"].ToString());
                int sc = Convert.ToInt32(dt_zj_cl.Rows[0]["sc"].ToString());
                string nd = dt_zj_cl.Rows[0]["nd"].ToString();
                string km = dt_zj_cl.Rows[0]["km"].ToString();
                string gw = dt_zj_cl.Rows[0]["gw"].ToString();
                string ctr = dt_zj_cl.Rows[0]["ctr"].ToString();
                string ctsj = dt_zj_cl.Rows[0]["ctsj"].ToString();
                #region 2.先判断题库中试题的数量是否足够
                //2.先判断题库中试题的数量是否足够
                string str_result = "";
                //2.1选择题
                DataTable dt_sum_xzt = sjk.Select_STK_By_ZJCL("" + cl_id, "0");
                int maxValues_xzt = dt_sum_xzt.Rows.Count;
                //如果题目中满足条件的题目数量小于策略，则给予提示
                if (xz_sl > maxValues_xzt)
                {
                    str_result += "题库中选择题数量不足;";
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
        protected void btn_cjcx_Click(object sender, EventArgs e)
        {
            string ksh = tbx_ksh.Text;
            if (ksh.Trim() == "")
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", "<script>alert(\"请输入考生号！\")</script>");
                return;
            }
            string cl_id = HF_cl_id.Value;
            DataTable dt_djk = djk.Select_DJK_By_KSH_CL_ZT(cl_id, ksh, "1");
            dt_djk.Columns.Add("xzt");
            dt_djk.Columns.Add("pdt");
            dt_djk.Columns.Add("tkt");
            foreach (DataRow dr in dt_djk.Rows)
            {
                int xz_zq_sl = Convert.ToInt32(dr["xz_zq_sl"].ToString());
                int pd_zq_sl = Convert.ToInt32(dr["pd_zq_sl"].ToString());
                int tk_zq_sl = Convert.ToInt32(dr["tk_zq_sl"].ToString());
                int xz_sl = Convert.ToInt32(dr["xz_sl"].ToString());
                int pd_sl = Convert.ToInt32(dr["pd_sl"].ToString());
                int tk_sl = Convert.ToInt32(dr["tk_sl"].ToString());
                int xz_fz = Convert.ToInt32(dr["xz_fz"].ToString());
                int pd_fz = Convert.ToInt32(dr["pd_fz"].ToString());
                int tk_fz = Convert.ToInt32(dr["tk_fz"].ToString());
                dr["xzt"] = xz_zq_sl * xz_fz + " 分（" + xz_zq_sl + "/" + xz_sl + ")";
                dr["pdt"] = pd_zq_sl * pd_fz + " 分（" + pd_zq_sl + "/" + pd_sl + ")";
                dr["tkt"] = tk_zq_sl * tk_fz + " 分（" + tk_zq_sl + "/" + tk_sl + ")";
            }
            //绑定分页数据源  
            this.dlt_djk.DataSource = dt_djk.DefaultView;
            this.dlt_djk.DataBind();
            dlt_djk.Visible = true;
        }
        protected void ddlt_zj_cl_SelectedIndexChanged(object sender, EventArgs e)
        {
            table_Init();
        }
        protected void btn_cx_ks_detail_Click(object sender, EventArgs e)
        {
            long zj_cl_id = Convert.ToInt64(ddlt_zj_cl.SelectedValue.ToString());
            if (zj_cl_id == -1)
            {
                return;
            }
            DataTable dt_zj_cl = zj_cl.Select_ZJ_CL_Detail(zj_cl_id);
            HF_cl_id.Value = dt_zj_cl.Rows[0]["id"].ToString();//标记当前显示的是哪个策略
            lbl_mc.Text = dt_zj_cl.Rows[0]["mc"].ToString();
            lbl_zf.Text = dt_zj_cl.Rows[0]["zf"].ToString();
            lbl_xz_sl.Text = dt_zj_cl.Rows[0]["xz_sl"].ToString();
            lbl_xz_fz.Text = dt_zj_cl.Rows[0]["xz_fz"].ToString();
            lbl_pd_sl.Text = dt_zj_cl.Rows[0]["pd_sl"].ToString();
            lbl_pd_fz.Text = dt_zj_cl.Rows[0]["pd_fz"].ToString();
            lbl_tk_sl.Text = dt_zj_cl.Rows[0]["tk_sl"].ToString();
            lbl_tk_fz.Text = dt_zj_cl.Rows[0]["tk_fz"].ToString();
            lbl_sc.Text = dt_zj_cl.Rows[0]["sc"].ToString();
            lbl_nd.Text = SysData.STNDByKey(dt_zj_cl.Rows[0]["nd"].ToString()).mc;
            lbl_km.Text = SysData.KMByKey(dt_zj_cl.Rows[0]["km"].ToString()).mc;
            lbl_gw.Text = SysData.GWByKey(dt_zj_cl.Rows[0]["gw"].ToString()).mc;
            lbl_ctr.Text = dt_zj_cl.Rows[0]["ctr_xm"].ToString();
            lbl_ctsj.Text = dt_zj_cl.Rows[0]["ctsj"].ToString();
            tab_cz.Visible = true;
        }
        protected void btn_cx_ks_Click(object sender, EventArgs e)
        {
            Struct_Select_ZJ_CL struct_cl = new Struct_Select_ZJ_CL();
            struct_cl.p_mc = "";
            struct_cl.p_nd = ddlt_stnd.SelectedValue.ToString();
            struct_cl.p_km = ddlt_km.SelectedValue.ToString();
            struct_cl.p_gw = ddlt_gw.SelectedValue.ToString();
            struct_cl.p_zt = "2";
            int count = zj_cl.Select_ZJ_CL_Count(struct_cl);
            struct_cl.p_currentpage = 1;
            struct_cl.p_pagesize = count;
            DataTable dt_cl = zj_cl.Select_ZJ_CL_Pro(struct_cl);
            ddlt_zj_cl.DataTextField = "mc";
            ddlt_zj_cl.DataValueField = "id";
            ddlt_zj_cl.DataSource = dt_cl;
            ddlt_zj_cl.DataBind();
            ddlt_zj_cl.Items.Insert(0, new ListItem("请选择", "-1"));
            table_Init();
        }
    }
}