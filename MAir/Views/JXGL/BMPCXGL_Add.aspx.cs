using CUST;
using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MAir.Views.JXGL
{
    public partial class BMPCXGL_Add : System.Web.UI.Page
    {
        private UserState _us;
        private PCX pcx;
        public bool flag = true;
        public int i = 0;
        private Struct_PCX struct_pcx;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_us = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时!\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            pcx = new PCX(_us);
            struct_pcx = new Struct_PCX();
            if (!IsPostBack)
            {
                Bind();
                
            }
        }
        private void Bind()
        {
            #region 
            DataTable dt_bmdm = SysData.BM().Copy();
            int count = 0;
            //查询权限
            for (; i < dt_bmdm.Rows.Count; i++)
            {

                check();
                if (dt_bmdm.Rows[i]["bm"].ToString() == "01" && SysData.HasThisQX("110602", _us.userID, "01") == false)
                {
                    dt_bmdm.Rows.RemoveAt(i);
                    count++;
                    flag = false;
                }
                if (i == dt_bmdm.Rows.Count) { break; }
                if (dt_bmdm.Rows[i]["bm"].ToString() == "02" && SysData.HasThisQX("110602", _us.userID, "02") == false)
                {
                    dt_bmdm.Rows.RemoveAt(i);
                    count++;
                    flag = false;
                }
                if (dt_bmdm.Rows[i]["bm"].ToString() == "03" && SysData.HasThisQX("110602", _us.userID, "03") == false)
                {
                    dt_bmdm.Rows.RemoveAt(i);
                    count++;
                    flag = false;
                }
                if (dt_bmdm.Rows[i]["bm"].ToString() == "04" && SysData.HasThisQX("110602", _us.userID, "04") == false)
                {
                    dt_bmdm.Rows.RemoveAt(i);
                    count++;
                    flag = false;
                }

                if (dt_bmdm.Rows[i]["bm"].ToString() == "05" && SysData.HasThisQX("110602", _us.userID, "05") == false)
                {
                    dt_bmdm.Rows.RemoveAt(i);
                    count++;
                    flag = false;
                }
                check();
            }
        }
            #endregion
        //保存按钮
        protected void btn_save_Click(object sender, EventArgs e)
        {
            struct_pcx.p_pcxbh = DateTime.Now.ToString("yyyyMMddHHmmss", DateTimeFormatInfo.InvariantInfo);
            struct_pcx.p_pcxmc = tbx_pcxmc.Text.Trim().ToString();
            struct_pcx.p_pcxzbms = tbx_pcxzbms.Text.Trim().ToString();
            struct_pcx.p_pcxjjf = " ";

            struct_pcx.p_czfs = "01";
            struct_pcx.p_czxx = "位置：绩效->评测项->添加" + struct_pcx.p_pcxbh + "评测项编号:" + struct_pcx.p_pcxmc + "评测项名称" + struct_pcx.p_pcxzbms + "评测项指标描述"
            + struct_pcx.p_pcxjjf + "评测项加减分" + struct_pcx.p_zt + "状态";
            try
            {
                if (struct_pcx.p_pcxmc == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"评测项名称不能为空！\")</script>");
                }
                else if (struct_pcx.p_pcxzbms == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"评测项描述不能为空！\")</script>");
                }
                else
                {
                    pcx.Insert_BMPCX(struct_pcx);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\")</script>");
                }
            }
            catch (Exception em)
            {
                throw em;
            }
        }
        //返回按钮
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../JXGL/BMPCXGL.aspx");
        }
        public void check()
        {
            if (flag == false)
            {
                i--;
                flag = true;
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
    }
}