using CUST.MKG;
using CUST.Sys;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class HT_Edit : System.Web.UI.Page
    {
        private UserState _usState;
        public HT ht;
        public Struct_HT struct_ht;
        public string  id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            ht = new HT(_usState);
            if (!IsPostBack)
            {
                tbx_qdrq.Attributes.Add("readonly", "readonly");
                tbx_qxkssj.Attributes.Add("readonly", "readonly");
                tbx_qxjssj.Attributes.Add("readonly", "readonly");
                bind_drop();
                select();
            }
        }
        private void bind_drop()
        {
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataSource = SysData.HTZT().Copy();
            ddlt_zt.DataBind();
        }

        private void select()
        {
            DataTable dt = new DataTable();           
            struct_ht.p_id = Request.QueryString["id"];
            dt = ht.Select_HTDetail(struct_ht);
            DateTime dt_qdrq = new DateTime();
            dt_qdrq = Convert.ToDateTime(dt.Rows[0]["qdrq"].ToString().Trim());
            DateTime dt_kssj = new DateTime();
            dt_kssj = Convert.ToDateTime(dt.Rows[0]["qxkssj"].ToString().Trim());
            DateTime dt_jssj = new DateTime();
            dt_jssj = Convert.ToDateTime(dt.Rows[0]["qxjssj"].ToString().Trim());
            tbx_htmc.Text= dt.Rows[0]["htmc"].ToString().Trim();
            tbx_qdf.Text = dt.Rows[0]["qdf"].ToString().Trim();
            tbx_ze.Text = dt.Rows[0]["ze"].ToString().Trim();
            tbx_qdrq.Text = string.Format("{0:yyyy-MM-dd }", dt_qdrq);
            tbx_qxkssj.Text = string.Format("{0:yyyy-MM-dd }", dt_kssj);
            tbx_qxjssj.Text = string.Format("{0:yyyy-MM-dd }", dt_jssj);
            ddlt_zt.SelectedValue = SysData.HTZTByKey(dt.Rows[0]["zt"].ToString().Trim()).mc;
            tbx_ztbz.Text = dt.Rows[0]["ztbz"].ToString().Trim();
            tbx_fzr.Text = dt.Rows[0]["fzr"].ToString().Trim();
            tbx_bz.Text = dt.Rows[0]["bz"].ToString().Trim();

        }
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("HTGL.aspx");
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            struct_ht.p_czxx = "位置：后台管理->合同管理->编辑  描述：";
            struct_ht.p_id = Request.QueryString["id"];
            struct_ht.p_htmc = tbx_htmc.Text.ToString().Trim();
            struct_ht.p_qdf = tbx_qdf.Text.ToString().Trim();
            struct_ht.p_qdrq = Convert.ToDateTime(tbx_qdrq.Text.ToString().Trim());

            DateTime dt_ks = new DateTime();
            if (tbx_qxkssj.Text.ToString().Trim() == "")
            {
                struct_ht.p_qxkssj = dt_ks;
            }
            else
            {
                struct_ht.p_qxkssj = Convert.ToDateTime(tbx_qxkssj.Text.ToString().Trim());
            }
            if (tbx_qxjssj.Text.ToString().Trim() == "")
            {
                struct_ht.p_qxjssj = dt_ks;
            }
            else
            {
                struct_ht.p_qxjssj = Convert.ToDateTime(tbx_qxjssj.Text.ToString().Trim());
            }
            //struct_ht.p_qxkssj = Convert.ToDateTime(tbx_qxkssj.Text.ToString().Trim());
            //struct_ht.p_qxjssj = Convert.ToDateTime(tbx_qxjssj.Text.ToString().Trim());
            struct_ht.p_fzr = tbx_fzr.Text.ToString().Trim();
            struct_ht.p_zt = ddlt_zt.SelectedValue.ToString().Trim();
            struct_ht.p_ztbz = tbx_ztbz.Text.ToString().Trim();
            struct_ht.p_bz = tbx_bz.Text.ToString().Trim();
            struct_ht.p_ze = Convert.ToDecimal(tbx_ze.Text.ToString().Trim());
            bool flag = false;
            DataTable dt = new DataTable();
            struct_ht.p_id = Request.QueryString["id"];
            dt = ht.Select_HTDetail(struct_ht);
            if (struct_ht.p_htmc != dt.Rows[0]["htmc"].ToString().Trim())
            {
                flag = true;
                struct_ht.p_czxx += "合同名称:【" + dt.Rows[0]["htmc"].ToString().Trim() + "】->【"+ struct_ht.p_htmc + "】";
            }
            if (struct_ht.p_qdf != dt.Rows[0]["qdf"].ToString().Trim())
            {
                flag = true;
                struct_ht.p_czxx +=" 签订方：【" + dt.Rows[0]["qdf"].ToString().Trim() + "】->【" + struct_ht.p_qdf + "】";
            }
            if (struct_ht.p_qxkssj != Convert.ToDateTime(dt.Rows[0]["qxkssj"].ToString().Trim()) || struct_ht.p_qxjssj!= Convert.ToDateTime(dt.Rows[0]["qxjssj"].ToString().Trim()))
            {
                flag = true;
                struct_ht.p_czxx += " 期限：【" + Convert.ToDateTime(tbx_qxkssj.Text.ToString()) + "-- 【"+ Convert.ToDateTime(tbx_qxjssj.Text.ToString()) +"】->【" + struct_ht.p_qxkssj + "--" + struct_ht.p_qxjssj + "】";
            }
            if (struct_ht.p_qdrq != Convert.ToDateTime(dt.Rows[0]["qdrq"].ToString().Trim()))
            {
                flag = true;
                struct_ht.p_czxx += " 签订日期：【" + Convert.ToDateTime(dt.Rows[0]["qdrq"].ToString().Trim()) + "】->【" + struct_ht.p_qdrq + "】";
            }
            if (struct_ht.p_fzr != dt.Rows[0]["fzr"].ToString().Trim())
            {
                flag = true;
                struct_ht.p_czxx += "负责人:【" + dt.Rows[0]["fzr"].ToString().Trim() + "】->【" + struct_ht.p_fzr + "】";
            }
            if (struct_ht.p_zt != SysData.HTZTByKey(dt.Rows[0]["zt"].ToString().Trim()).mc)
            {
                flag = true;
                struct_ht.p_czxx += "状态:【" + SysData.HTZTByKey(dt.Rows[0]["zt"].ToString().Trim()).mc + "】->【" + struct_ht.p_zt + "】";
            }
            if (struct_ht.p_ztbz != dt.Rows[0]["ztbz"].ToString().Trim())
            {
                flag = true;
                struct_ht.p_czxx += "状态:【" + dt.Rows[0]["ztbz"].ToString().Trim() + "】->【" + struct_ht.p_ztbz + "】";
            }
            if (struct_ht.p_ze !=Convert.ToDecimal( dt.Rows[0]["ze"].ToString().Trim()))
            {
                flag = true;
                struct_ht.p_czxx += "总额:【" + Convert.ToDecimal(dt.Rows[0]["ze"].ToString().Trim()) + "】->【" + struct_ht.p_ze + "】";
            }
            if (struct_ht.p_bz != dt.Rows[0]["bz"].ToString().Trim())
            {
                flag = true;
                struct_ht.p_czxx += "备注:【" + dt.Rows[0]["bz"].ToString().Trim() + "】->【" + struct_ht.p_bz + "】";
            }
            struct_ht.p_czfs = "03";
            if(flag==true)
            {
                ht.Update_HT(struct_ht);               
            }
            else
            {
                struct_ht.p_czxx = "无操作";
                ht.Update_HT(struct_ht);               
            }
            Response.Write("<script>alert(\"编辑成功！\");</script>");
        }
    }
}