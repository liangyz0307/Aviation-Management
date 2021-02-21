using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class HT_Add : System.Web.UI.Page
    {
        private UserState _usState;
        public HT ht;
        public Struct_HT struct_ht;
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
                //tbx_qdrq.Attributes.Add("readonly", "readonly");
                tbx_qxkssj.Attributes.Add("readonly", "readonly");
                tbx_qxjssj.Attributes.Add("readonly", "readonly");
                bind_drop();
            }
        }
        private void bind_drop()
        {
            ddlt_zt.DataTextField = "mc";
            ddlt_zt.DataValueField = "bm";
            ddlt_zt.DataSource = SysData.HTZT().Copy();
            ddlt_zt.DataBind();
            ddlt_zt.Items.Insert(0, new ListItem("请选择", "-1"));
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
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
            if (tbx_qxjssj.Text.ToString().Trim()=="")
            {
            struct_ht.p_qxjssj =dt_ks;
            }
            else
            {
              struct_ht.p_qxjssj = Convert.ToDateTime(tbx_qxjssj.Text.ToString().Trim());
            }
           
          
            struct_ht.p_fzr = tbx_fzr.Text.ToString().Trim();
            struct_ht.p_zt = ddlt_zt.SelectedValue.ToString().Trim();
            struct_ht.p_ztbz = tbx_ztbz.Text.ToString().Trim();
            struct_ht.p_bz = tbx_bz.Text.ToString().Trim();
            if (tbx_ze.Text.ToString().Trim() == "")
            {
                Decimal zee = new Decimal();
                struct_ht.p_ze = zee;
            }
            else
            {
                struct_ht.p_ze = Convert.ToDecimal(tbx_ze.Text.ToString().Trim());
            }
          
            struct_ht.p_czfs = "01";
            struct_ht.p_czxx = "位置：后台管理->合同管理->添加  描述：合同名称:["+ struct_ht.p_htmc+"] 签订方：【" + struct_ht.p_qdf + "】 签订日期：【"
                + struct_ht.p_qdrq+"】 期限：【" + struct_ht.p_qxkssj + "--"+ struct_ht.p_qxjssj +"】负责人：【"+ struct_ht.p_fzr+"】 状态：【"+ struct_ht.p_zt
                +"】 状态备注：【" + struct_ht.p_ztbz+"】 总额：【" + struct_ht.p_ze+"】 备注：【" + struct_ht.p_bz + "】";
            ht.Insert_HT(struct_ht);
            Response.Write("<script>alert(\"添加成功！\");</script>");
        }

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("HTGL.aspx");
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