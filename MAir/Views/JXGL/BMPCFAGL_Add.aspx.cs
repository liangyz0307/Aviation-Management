using CUST;
using CUST.MKG;
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
    public partial class BMPCFAGL_Add : System.Web.UI.Page
    {
        private UserState _us;
        private PCFA pcfa;
        private PCX pcx;
        public bool flag = true;
        public int i = 0;
        protected DataTable dtpcx;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_us = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时!\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            pcx = new PCX(_us);
            pcfa = new PCFA(_us);
            dtpcx = new DataTable();
            if (!IsPostBack)
            {
                Bind();
            }
        }
        public void Bind()
        {
            dtpcx = pcx.Select_BMPCXMC().Tables[0];

            //绑定数据源  
            this.dlt_pcfa_add.DataSource = dtpcx.DefaultView;
            this.dlt_pcfa_add.DataBind();
        }
        //添加
        protected void btn_save_Click(object sender, EventArgs e)
        {
            Struct_PCFA_Pro struct_pcfa_pro = new Struct_PCFA_Pro();
            double qz = 0;
            string pcfabh = DateTime.Now.ToString("yyyyMMddHHmmss", DateTimeFormatInfo.InvariantInfo);
            struct_pcfa_pro.p_pcfamc = tbx_pcfamc.Text.ToString();//评测方案名称
            if (struct_pcfa_pro.p_pcfamc == "")
            {
                Response.Write("<script language='javascript'>alert('评测方案名称不能为空！');</script>");
            }
            else
            {
                foreach (DataListItem li in dlt_pcfa_add.Items)//首先遍历选中的CheckBox对应行填写的的权重是否符合条件
                {
                    CheckBox cbx_pcfa = (CheckBox)li.FindControl("cbx_pcfa");
                    TextBox tbx_pcxqz = (TextBox)li.FindControl("tbx_pcxqz");
                    if (cbx_pcfa.Checked == true)
                    {
                        if ((tbx_pcxqz.Text.ToString() == ""))//检查选中的CheckBox的权重是否为空
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"权重不能为空！\")</script>");
                            return;
                        }
                        else
                        {
                            qz = qz + Convert.ToInt32(tbx_pcxqz.Text.ToString());//类型转换,选中权重加和
                        }
                    }
                }
                if (qz != 100)//检查权重之和是否为100
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"选中的权重之和不为100！\")</script>");
                    return;
                }
                else//当权重符合条件时，执行插入操作
                {
                    foreach (DataListItem li in dlt_pcfa_add.Items)
                    {
                        CheckBox cbx_pcfa = (CheckBox)li.FindControl("cbx_pcfa");
                        TextBox tbx_pcxqz = (TextBox)li.FindControl("tbx_pcxqz");
                        Label lbl_pcxmc = (Label)li.FindControl("lbl_pcxmc");
                        Label lbl_pcxbh = (Label)li.FindControl("lbl_pcxbh");

                        if (cbx_pcfa.Checked == true)//前面校验通过，一次插入每一个选中行
                        {
                            struct_pcfa_pro.p_pcfabh = pcfabh;//评测方案编号
                            struct_pcfa_pro.p_pcxbh = lbl_pcxbh.Text.Trim();//评测项编号
                            struct_pcfa_pro.p_pcxmc = lbl_pcxmc.Text.Trim();//评测项名称
                            struct_pcfa_pro.p_pcxqz = tbx_pcxqz.Text.ToString();//评测项权重

                            pcfa.Insert_BMPCFA_Pro(struct_pcfa_pro);
                        }
                    }
                    Response.Write("<script language='javascript'>alert('添加成功！'); location=' ../JXGL/BMPCFAGL.aspx';</script>");
                }
            }
        }
        //返回
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../JXGL/BMPCFAGL.aspx");
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