using CUST.MKG;
using CUST.Tools;
using Sys;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace CUST.WKG
{
    public partial class KS_KS : System.Web.UI.Page
    {
        private UserState _usState;
        private SJK sjk;
        private DJK djk;
        private static long dj_id;
        private static DataTable dt_xzt;
        private static DataTable dt_dxt;
        private static DataTable dt_tkt;
        private static DataTable dt_pdt;
        private static DataTable dt_djk;
        private static int Total_XZT;
        private static int Total_DXT;
        private static int Total_TKT;
        private static int Total_PDT;
        protected static long JSSJ;//理论上的结束时间，以秒为单位
        private static DateTime KSSJ;//开始时间
        private static long MM_KSSJ;//开始时间的时间戳，以秒为单位
        private static double HS;//耗时
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            sjk = new SJK(_usState);
            djk = new DJK(_usState);
            if (!IsPostBack)
            {

                dj_id = Convert.ToInt64(Request.Params["id"].ToString().Trim());
                dt_xzt = sjk.Select_SJK_by_dj_id("" + dj_id, "0");
                dt_dxt = sjk.Select_SJK_by_dj_id("" + dj_id, "3");
                dt_pdt = sjk.Select_SJK_by_dj_id("" + dj_id, "1");
                dt_tkt = sjk.Select_SJK_by_dj_id("" + dj_id, "2");
                Total_XZT = dt_xzt.Rows.Count;
                Total_DXT = dt_dxt.Rows.Count;
                Total_PDT = dt_pdt.Rows.Count;
                Total_TKT = dt_tkt.Rows.Count;
               //如果 题数量为0，则不显示
                tr_xz.Visible = Total_XZT == 0 ? false : true;
                tr_dx.Visible = Total_DXT == 0 ? false : true;
                tr_pd.Visible = Total_PDT == 0 ? false : true;
                tr_tk.Visible = Total_TKT == 0 ? false : true;
                //确定考试开始和结束时间
                dt_djk = djk.Select_DJK_Detail(Convert.ToInt64(dj_id));
                KSSJ = Convert.ToDateTime(dt_djk.Rows[0]["kssj"].ToString());
                MM_KSSJ = (KSSJ.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
                double sc = Convert.ToDouble(dt_djk.Rows[0]["sc"].ToString());
                HS = Convert.ToDouble(dt_djk.Rows[0]["hs"].ToString());
                JSSJ = (KSSJ.AddMinutes(sc - HS).ToUniversalTime().Ticks - 621355968000000000) / 10000000;//获取最终结束的时间戳，秒为单位
                lbl_mc.Text = dt_djk.Rows[0]["mc"].ToString();
            }
            //确定试卷包含题的细节
            for (int i = 0; i < Total_XZT; i++)
            {
                DymanicallyGenerateXZT(i + 1);
            }
            for (int i = 0; i < Total_DXT; i++)
            {
                DymanicallyGenerateDXT(i + 1);
            }
            for (int i = 0; i < Total_TKT; i++)
            {
                DymanicallyGenerateTKT(i + 1);
            }
            for (int i = 0; i < Total_PDT; i++)
            {
                DymanicallyGeneratePDT(i + 1);
            }
        }
        #region 动态生成页面试题
        private void DymanicallyGenerateXZT(int totalControls)
        {
            //Label
            DataRow dr_St = dt_xzt.Rows[totalControls - 1];
            Label st_tg = new Label();
            st_tg.ID = "lbl_xzt_" + dr_St["st_bh"];
            st_tg.Text = dr_St["st_bh"] + " . " + dr_St["tg"];
            this.ph_xz.Controls.Add(st_tg);
            //回车
            ph_xz.Controls.Add(new LiteralControl("<br>"));
            //RadioButtonList
            RadioButtonList rbtl_xx = new RadioButtonList();
            rbtl_xx.ID = "rbtl_xzt_" + Left_fillWith0(dr_St["st_bh"].ToString(), 3);
            DataTable dt_xx = sjk.Select_XZT_XX(dr_St["st_id"].ToString());
            rbtl_xx.DataTextField = "xxnr";
            rbtl_xx.DataValueField = "xx";
            rbtl_xx.DataSource = dt_xx;
            rbtl_xx.DataBind();
            if (rbtl_xx.Items.FindByValue(dr_St["ks_da"].ToString()) != null)
            {
                rbtl_xx.Items.FindByValue(dr_St["ks_da"].ToString()).Selected = true;
            }

            //为每一个试题添加事件
            rbtl_xx.AutoPostBack = true;
            rbtl_xx.SelectedIndexChanged += new System.EventHandler(this.xzt_Change);

            this.ph_xz.Controls.Add(rbtl_xx);
        }
        private void DymanicallyGenerateDXT(int totalControls)
        {
            //Label
            DataRow dr_St = dt_dxt.Rows[totalControls - 1];
            Label st_tg = new Label();
            st_tg.ID = "lbl_dxt_" + dr_St["st_bh"];
            st_tg.Text = dr_St["st_bh"] + " . " + dr_St["tg"];
            this.ph_dx.Controls.Add(st_tg);
            //回车
            ph_dx.Controls.Add(new LiteralControl("<br>"));
            //checkboxlist
            CheckBoxList cbxl_xx = new CheckBoxList();
            cbxl_xx.ID = "cbxl_xx_dxt_" + Left_fillWith0(dr_St["st_bh"].ToString(), 3);
            DataTable dt_xx = sjk.Select_XZT_XX(dr_St["st_id"].ToString());
            cbxl_xx.DataTextField = "xxnr";
            cbxl_xx.DataValueField = "xx";
            cbxl_xx.DataSource = dt_xx;
            cbxl_xx.DataBind();
            string ks_da = dr_St["ks_da"].ToString();
            string[] arr_ks_da = ks_da.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arr_ks_da.Length; i++)
            {
                cbxl_xx.Items.FindByValue(arr_ks_da[i]).Selected=true;
            }
            //为每一个试题添加事件
            cbxl_xx.AutoPostBack = true;
            cbxl_xx.SelectedIndexChanged += new System.EventHandler(this.dxt_Change);
            this.ph_dx.Controls.Add(cbxl_xx);
        }
        private void DymanicallyGenerateTKT(int totalControls)
        {
            //1.Label
            DataRow dr_St = dt_tkt.Rows[totalControls - 1];
            Label st_tg = new Label();
            st_tg.ID = "lbl_tkt_" + dr_St["st_bh"];
            st_tg.Text = dr_St["st_bh"] + " . " + dr_St["tg"].ToString().Replace("##&&##", "_______");
            this.ph_tk.Controls.Add(st_tg);
            //2.回车
            ph_tk.Controls.Add(new LiteralControl("<br>"));
            //3.textbox
            PlaceHolder ph_tbxs = new PlaceHolder();
            ph_tbxs.ID = "ph_tks_" + Left_fillWith0(dr_St["st_bh"].ToString(), 3);
            string[] das = dr_St["da"].ToString().Split(new string[] { "##&&##" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < das.Length; i++)
            {
                TextBox tbx = new TextBox();
                tbx.ID = "tbxs_" + totalControls + "_tbx_" + i;
                tbx.Text = dr_St["ks_da"].ToString();
                //为每一个试题添加事件
                tbx.AutoPostBack = true;
                tbx.TextChanged += new System.EventHandler(this.tkt_Change);
                ph_tbxs.Controls.Add(tbx);
            }
            ph_tk.Controls.Add(ph_tbxs);
            //4.回车
            ph_tk.Controls.Add(new LiteralControl("<br>"));
        }
        private void DymanicallyGeneratePDT(int totalControls)
        {
            //Label
            DataRow dr_St = dt_pdt.Rows[totalControls - 1];
            Label st_tg = new Label();
            st_tg.ID = "lbl_pdt_" + dr_St["st_bh"];
            st_tg.Text = dr_St["st_bh"] + " . " + dr_St["tg"];
            this.ph_pd.Controls.Add(st_tg);
            ph_pd.Controls.Add(new LiteralControl("<br>"));
            //RadioButtonList
            RadioButtonList rbtl_xx = new RadioButtonList();
            rbtl_xx.ID = "rbtl_pdt_" + Left_fillWith0(dr_St["st_bh"].ToString(), 3);
            rbtl_xx.Items.Add(new ListItem("正确", "1"));
            rbtl_xx.Items.Add(new ListItem("错误", "0"));
            if (rbtl_xx.Items.FindByValue(dr_St["ks_da"].ToString()) != null)
            {
                rbtl_xx.Items.FindByValue(dr_St["ks_da"].ToString()).Selected = true;
            }
            //为每一个试题添加事件
            rbtl_xx.AutoPostBack = true;
            rbtl_xx.SelectedIndexChanged += new System.EventHandler(this.pdt_Change);

            this.ph_pd.Controls.Add(rbtl_xx);
        }

      
        protected void xzt_Change(object sender, EventArgs e)
        {
            try
            {
                string ID_Control = ((Control)sender).ID;
                int st_bh = Convert.ToInt32(ID_Control.Substring(ID_Control.Length - 3)) - 1;
                Struct_SJK struct_sjk = new Struct_SJK();
                struct_sjk.p_czfs = "03";
                struct_sjk.p_czxx = "位置：在线培训->考试管理->开始考试   记录考生选择题答案 并算分  答卷id ：" + struct_sjk.p_dj_id;
                struct_sjk.p_id = Convert.ToInt64(dt_xzt.Rows[st_bh]["sj_id"].ToString());
                RadioButtonList rbtl = (RadioButtonList)this.ph_xz.Controls[st_bh * 3 + 2];
                struct_sjk.p_ks_da = rbtl.SelectedValue;
                struct_sjk.p_df = dt_xzt.Rows[st_bh]["da"].ToString().Trim() == struct_sjk.p_ks_da ? Convert.ToDouble(dt_xzt.Rows[st_bh]["st_fz"].ToString()) : 0;
                struct_sjk.p_czxx += "试题id " + struct_sjk.p_id + "  考生答案： " + struct_sjk.p_ks_da + " 得分" + struct_sjk.p_df;
                sjk.Update_SJK(struct_sjk);


                //更新当前用时
                updateHS();
            }
            catch (EMException ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));
                return;
            }
        }
        protected void dxt_Change(object sender, EventArgs e)
        {
            try
            {
                string ID_Control = ((Control)sender).ID;
                int st_bh = Convert.ToInt32(ID_Control.Substring(ID_Control.Length - 3)) - 1;
                Struct_SJK struct_sjk = new Struct_SJK();
                struct_sjk.p_czfs = "03";
                struct_sjk.p_czxx = "位置：在线培训->考试管理->开始考试   记录考生选择题答案 并算分  答卷id ：" + struct_sjk.p_dj_id;
                struct_sjk.p_id = Convert.ToInt64(dt_dxt.Rows[st_bh]["sj_id"].ToString());
                string da = "";
                CheckBoxList cbxl_dx = (CheckBoxList)this.ph_dx.Controls[st_bh * 3 + 2];
                for (int i = 0; i < cbxl_dx.Items.Count; i++)
                {
                    if (cbxl_dx.Items[i].Selected)
                    {
                        da+=cbxl_dx.Items[i].Value+";";
                    }
                }
                struct_sjk.p_ks_da = da;
                struct_sjk.p_df = dt_dxt.Rows[st_bh]["da"].ToString().Trim() == struct_sjk.p_ks_da ? Convert.ToDouble(dt_dxt.Rows[st_bh]["st_fz"].ToString()) : 0;
                struct_sjk.p_czxx += "试题id " + struct_sjk.p_id + "  考生答案： " + struct_sjk.p_ks_da + " 得分" + struct_sjk.p_df;
                sjk.Update_SJK(struct_sjk);
                //更新当前用时
                updateHS();
            }
            catch (EMException ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));
                return;
            }
        }
        protected void pdt_Change(object sender, EventArgs e)
        {
            try
            {
                string ID_Control = ((Control)sender).ID;
                int st_bh = Convert.ToInt32(ID_Control.Substring(ID_Control.Length - 3)) - 1;

                Struct_SJK struct_sjk = new Struct_SJK();
                struct_sjk.p_czfs = "03";
                struct_sjk.p_czxx = "位置：在线培训->考试管理->开始考试   记录考生判断题答案 并算分  答卷id ：" + struct_sjk.p_dj_id;

                struct_sjk.p_id = Convert.ToInt64(dt_pdt.Rows[st_bh]["sj_id"].ToString());
                RadioButtonList rbtl = (RadioButtonList)this.ph_pd.Controls[st_bh * 3 + 2];
                struct_sjk.p_ks_da = rbtl.SelectedValue;
                struct_sjk.p_df = dt_pdt.Rows[st_bh]["da"].ToString().Trim() == struct_sjk.p_ks_da ? Convert.ToDouble(dt_pdt.Rows[st_bh]["st_fz"].ToString()) : 0;
                struct_sjk.p_czxx += "试题id " + struct_sjk.p_id + "  考生答案： " + struct_sjk.p_ks_da + " 得分" + struct_sjk.p_df;
                sjk.Update_SJK(struct_sjk);


                //更新当前用时
                updateHS();
            }
            catch (EMException ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));
                return;
            }
        }
        protected void tkt_Change(object sender, EventArgs e)
        {
            try
            {
                string ID_Control = ((Control)sender).Parent.ID;
                int st_bh = Convert.ToInt32(ID_Control.Substring(ID_Control.Length - 3)) - 1;

                Struct_SJK struct_sjk = new Struct_SJK();
                struct_sjk.p_czfs = "03";
                struct_sjk.p_czxx = "位置：在线培训->考试管理->开始考试   记录考生填空题答案 并算分  答卷id ：" + struct_sjk.p_dj_id;

                struct_sjk.p_id = Convert.ToInt64(dt_tkt.Rows[st_bh]["sj_id"].ToString());
                PlaceHolder ph_tbxs = (PlaceHolder)ph_tk.Controls[4 * st_bh + 2];
                struct_sjk.p_ks_da = "";
                for (int j = 0; j < ph_tbxs.Controls.Count; j++)
                {
                    TextBox tbx_temp = (TextBox)ph_tbxs.Controls[j];
                    if (j > 0)
                    {
                        struct_sjk.p_ks_da += "##&&##" + tbx_temp.Text;
                    }
                    else
                    {
                        struct_sjk.p_ks_da += tbx_temp.Text;
                    }
                }
                struct_sjk.p_df = dt_tkt.Rows[st_bh]["da"].ToString().Trim() == struct_sjk.p_ks_da ? Convert.ToDouble(dt_tkt.Rows[st_bh]["st_fz"].ToString()) : 0;
                struct_sjk.p_czxx += "试题id " + struct_sjk.p_id + "  考生答案： " + struct_sjk.p_ks_da + " 得分" + struct_sjk.p_df;
                sjk.Update_SJK(struct_sjk);


                //更新当前用时
                updateHS();
            }
            catch (EMException ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));
                return;
            }

        }
        /// <summary>
        /// 将字符串，左边填充0，使其长度达到目标长度
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <param name="aimlength">目标长度</param>
        /// <returns></returns>
        private static string Left_fillWith0(string str, int aimlength)
        {
            string result = str;
            int length = aimlength - result.Length;
            for (int i = 0; i < length; i++)
            {
                result = "0" + result;
            }
            return result;
        }

        /// <summary>
        /// 更新当前考试用时
        /// </summary>
        private void updateHS()
        {
            //1.计算总耗时
            long temp_jssj = (System.DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;//获取最终结束的时间戳，秒为单位
            double temp_hs = (temp_jssj - MM_KSSJ) / 60.0;//确定当前的耗时（分钟为单位），精确到小数
            MM_KSSJ = temp_jssj;
            HS = HS + temp_hs;
            try
            {
                //2.保存当前耗时时间
                string p_czfs = "03";
                string p_czxx = "位置：在线培训->考试管理->开始考试   保存当前考试用时  答卷id：" + dj_id;
                djk.Update_DJK_HS(dj_id, HS, p_czfs, p_czxx);
            }
            catch (EMException ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));
                return;
            }
        }

        #endregion
        /// <summary>
        /// 交卷
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_tj_Click(object sender, EventArgs e)
        {
            try
            {
                //1.将各题答案存档
                saveALLInfor();
                //2.交卷
                Struct_DJK struct_djk = new Struct_DJK();
                struct_djk.p_id = Convert.ToInt64(dj_id);
                struct_djk.p_jssj = System.DateTime.Now;

                //2.1.计算总耗时
                long temp_jssj = (System.DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;//获取最终结束的时间戳，秒为单位
                double temp_hs = (temp_jssj - MM_KSSJ) / 60.0;//确定当前的耗时（分钟为单位），精确到小数
                MM_KSSJ = temp_jssj;
                HS = HS + temp_hs;


                struct_djk.p_hs = HS;//计算耗时
                struct_djk.p_zt = "1";//完成考试
                struct_djk.p_czfs = "03";
                struct_djk.p_czxx = "位置：在线培训->考试管理->开始考试   交卷  答卷id：" + dj_id;
                djk.Update_DJK(struct_djk);
                //3.跳转到考试结果界面
                Response.Redirect("../ZXPX/KS_Result.aspx?id=" + dj_id, true);
            }
            catch (EMException ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));
                return;
            }
        }
        protected void btn_bc_Click(object sender, EventArgs e)
        {
            try
            {
                //1.将各题答案存档
                saveALLInfor();
                //2.保存当前耗时时间
                updateHS();
                //3.在前台提示最后保存时间
                DateTime BC_SJ = System.DateTime.Now.ToLocalTime();
                lbl_bc.Text = "上次保存时间 : " + BC_SJ;
            }
            catch (EMException ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));
                return;
            }
        }
        private void saveALLInfor()
        {
            try
            {
                //1.存储全部的选择题
                //1.1单选题
                Struct_SJK struct_sjk = new Struct_SJK();
                struct_sjk.p_czfs = "03";
                struct_sjk.p_czxx = "位置：在线培训->考试管理->开始考试   记录考生选择题答案 并算分  答卷id ：" + struct_sjk.p_dj_id;
                for (int i = 0; i < Total_XZT; i++)
                {
                    struct_sjk.p_id = Convert.ToInt64(dt_xzt.Rows[i]["sj_id"].ToString());
                    RadioButtonList rbtl = (RadioButtonList)this.ph_xz.Controls[i * 3 + 2];
                    struct_sjk.p_ks_da = rbtl.SelectedValue;
                    struct_sjk.p_df = dt_xzt.Rows[i]["da"].ToString().Trim() == struct_sjk.p_ks_da ? Convert.ToDouble(dt_xzt.Rows[i]["st_fz"].ToString()) : 0;
                    struct_sjk.p_czxx += "试题id " + struct_sjk.p_id + "  考生答案： " + struct_sjk.p_ks_da + " 得分" + struct_sjk.p_df;
                    sjk.Update_SJK(struct_sjk);
                }
                //1.2多选题
                struct_sjk.p_czfs = "03";
                struct_sjk.p_czxx = "位置：在线培训->考试管理->开始考试   记录考生选择题答案 并算分  答卷id ：" + struct_sjk.p_dj_id;
                for (int i = 0; i < Total_DXT; i++)
                {
                    struct_sjk.p_id = Convert.ToInt64(dt_dxt.Rows[i]["sj_id"].ToString());
                    string da = "";
                    CheckBoxList cbxl_dx = (CheckBoxList)this.ph_dx.Controls[i * 3 + 2];
                    for (int j = 0; j < cbxl_dx.Items.Count;j++)
                    {
                        if (cbxl_dx.Items[j].Selected)
                        {
                            da += cbxl_dx.Items[j].Value + ";";
                        }
                    }
                    struct_sjk.p_ks_da = da;
                    struct_sjk.p_df = dt_dxt.Rows[i]["da"].ToString().Trim() == struct_sjk.p_ks_da ? Convert.ToDouble(dt_dxt.Rows[i]["st_fz"].ToString()) : 0;
                    struct_sjk.p_czxx += "试题id " + struct_sjk.p_id + "  考生答案： " + struct_sjk.p_ks_da + " 得分" + struct_sjk.p_df;
                    sjk.Update_SJK(struct_sjk);
                }
                //2.存储全部的判断题
                struct_sjk.p_czfs = "03";
                struct_sjk.p_czxx = "位置：在线培训->考试管理->开始考试   记录考生判断题答案 并算分  答卷id ：" + struct_sjk.p_dj_id;
                for (int i = 0; i < Total_PDT; i++)
                {
                    struct_sjk.p_id = Convert.ToInt64(dt_pdt.Rows[i]["sj_id"].ToString());
                    RadioButtonList rbtl = (RadioButtonList)this.ph_pd.Controls[i * 3 + 2];
                    struct_sjk.p_ks_da = rbtl.SelectedValue;
                    struct_sjk.p_df = dt_pdt.Rows[i]["da"].ToString().Trim() == struct_sjk.p_ks_da ? Convert.ToDouble(dt_pdt.Rows[i]["st_fz"].ToString()) : 0;
                    struct_sjk.p_czxx += "试题id " + struct_sjk.p_id + "  考生答案： " + struct_sjk.p_ks_da + " 得分" + struct_sjk.p_df;
                    sjk.Update_SJK(struct_sjk);
                }
                //3.存储全部的填空题
                struct_sjk.p_czfs = "03";
                struct_sjk.p_czxx = "位置：在线培训->考试管理->开始考试   记录考生填空题答案 并算分  答卷id ：" + struct_sjk.p_dj_id;
                for (int i = 0; i < Total_TKT; i++)
                {
                    struct_sjk.p_id = Convert.ToInt64(dt_tkt.Rows[i]["sj_id"].ToString());
                    PlaceHolder ph_tbxs = (PlaceHolder)ph_tk.Controls[4 * i + 2];
                    struct_sjk.p_ks_da = "";
                    for (int j = 0; j < ph_tbxs.Controls.Count; j++)
                    {
                        TextBox tbx_temp = (TextBox)ph_tbxs.Controls[j];
                        if (j > 0)
                        {
                            struct_sjk.p_ks_da += "##&&##" + tbx_temp.Text;
                        }
                        else
                        {
                            struct_sjk.p_ks_da += tbx_temp.Text;
                        }
                    }
                    struct_sjk.p_df = dt_tkt.Rows[i]["da"].ToString().Trim() == struct_sjk.p_ks_da ? Convert.ToDouble(dt_tkt.Rows[i]["st_fz"].ToString()) : 0;
                    struct_sjk.p_czxx += "试题id " + struct_sjk.p_id + "  考生答案： " + struct_sjk.p_ks_da + " 得分" + struct_sjk.p_df;
                    sjk.Update_SJK(struct_sjk);
                }
            }
            catch (EMException ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示", EMException.ShowErrorScript(ex));
                return;
            }
        }
        #region 错误处理
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