using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CUST.Sys;
using System.Data;
using CUST;
using CUST.Tools;
using CUST.MKG;
using Sys;

namespace CUST.WKG
{
    public partial class FBGG_Add : System.Web.UI.Page
    {
        private UserState _usState;
        private GG fbgg;
        private OGG.Struct_GG_Pro struct_gg;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            fbgg = new GG(_usState);
            if (!IsPostBack)
            {
                ddltBind();
            }
        }
        private void ddltBind()
        {
            //绑定公告类型ddlt_gglx
            DataTable dt_gglx = SysData.GGLX().Copy();
            ddlt_gglx.DataSource = dt_gglx;
            ddlt_gglx.DataTextField = "mc";
            ddlt_gglx.DataValueField = "bm";
            ddlt_gglx.DataBind();

            //绑定部门代码
            DataTable dt_bmdm = SysData.BM().Copy();
            for (int i = 0; i < dt_bmdm.Rows.Count; i++)
            {
                cbxl_jsbm.Items.Add(dt_bmdm.Rows[i]["mc"].ToString());
            }

            ddlt_sfdb.DataSource = SysData.SFDB().Copy();
            ddlt_sfdb.DataTextField = "mc";
            ddlt_sfdb.DataValueField = "bm";
            ddlt_sfdb.DataBind();
        }

        protected void btn_bc_Click(object sender, EventArgs e)
        {
            #region 校验
            int flag = 0;
            string bt = tbx_bt.Text.ToString().Trim();
            if (string.IsNullOrEmpty(bt))
            {
                lbl_bt.Text = "<span style=\"color:#ff0000\">" + "该项不能为空" + "</span>";
                flag = 1;
            }
            else
            {
                lbl_bt.Text = "<span style=\"color:#00ff00\">" + "正确" + "</span>";
            }
            string jsbm = "";
            DataTable dt_bmdm = SysData.BM().Copy();
            foreach (ListItem li in cbxl_jsbm.Items)
            {
                if (li.Selected)
                {
                    for (int i = 0; i < dt_bmdm.Rows.Count; i++)
                    {
                        if (li.Value == dt_bmdm.Rows[i]["mc"].ToString())
                        {
                            jsbm += dt_bmdm.Rows[i]["bm"].ToString() + ",";
                        }
                        
                    };
                }
            }
            if (jsbm.Length == 0)
            {
                lbl_jsbm.Text = "<span style=\"color:#ff0000\">" + "接收部门必选项" + "</span>";
                flag = 1;
            }
            if (flag == 1)
            {
                return;
            }
            #endregion
            struct_gg.p_sfdb=ddlt_sfdb.SelectedValue.ToString().Trim();
            if (tbx_blsx.Text== "")
            {
                DateTime date_blsx = new DateTime();
                struct_gg.p_blsx =date_blsx;
            }
            else
            {
                struct_gg.p_blsx = Convert.ToDateTime(tbx_blsx.Text);
            }
            struct_gg.p_lx = ddlt_gglx.Text.ToString().Trim();
            struct_gg.p_bt = tbx_bt.Text.ToString().Trim();
            struct_gg.p_lr = txtEditorContents.Text.ToString().Trim();
            struct_gg.p_fbr = _usState.userLoginName.ToString();
            struct_gg.p_fbsj = System.DateTime.Now;
            struct_gg.p_czfs = "01";
            struct_gg.p_jsbm = jsbm.Substring(0,jsbm.Length-1) ;
            struct_gg.p_czxx = "位置：后台管理->发布公告->添加 描述：公告类型：【" + struct_gg.p_lx + "】    " + "公告标题：【" + struct_gg.p_bt + "】  "
                 + " 发布人：【" + struct_gg.p_fbr + "】" + " 接受部门：【" + struct_gg.p_jsbm + "】";      
            fbgg.GG_insert(struct_gg);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "提示", "<script>alert(\"添加成功！\");window.top.location.href='../HouTai/FBGG.aspx'</script>");
            Response.Redirect("../HouTai/FBGG.aspx");
            
        }
       
        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("../HouTai/FBGG.aspx");
        }

    }
}