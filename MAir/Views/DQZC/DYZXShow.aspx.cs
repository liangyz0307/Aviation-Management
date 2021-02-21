using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Data;
using System.Web.UI.WebControls;


namespace CUST.WKG
{
    public partial class DYZXShow : System.Web.UI.Page
    {
        public int cpage;
        public int psize;
        public int zcount;
        private UserState _usState;
        public DYZX dyzx;
        public ODYZX.Struct_DYZX struct_dyzx;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            // struct_dyzx = new CUST.MKG.ODYZX.Struct_DYZX();
            dyzx = new DYZX(_usState);
            if (!IsPostBack)
            {

                tbx_kssj.Attributes.Add("readonly", "readonly");
                tbx_jssj.Attributes.Add("readonly", "readonly");
                bind_Main();
          

            }
        }
       
        private void bind_Main()
        {
            struct_dyzx.p_xm = txb_xm.Text.Trim().ToString();//姓名;
           
            if (tbx_kssj.Text.Trim().ToString() == "")
            {

                struct_dyzx.p_kssj = Convert.ToDateTime("0001-1-1 00:00:00");
            }
            else
            {
                struct_dyzx.p_kssj = DateTime.Parse(tbx_kssj.Text.Trim().ToString());//开始时间
            }
            if (tbx_jssj.Text.Trim().ToString() == "")
            {

                struct_dyzx.p_jssj = Convert.ToDateTime("9999-12-30 23:59:59");

            }
            else
            {
                struct_dyzx.p_jssj = DateTime.Parse(tbx_jssj.Text.Trim().ToString());//开始时间
            }
            int count = dyzx.Select_DYZXShow_Count(struct_dyzx);
            pg_fy.TotalRecord = count;
            struct_dyzx.p_currentpage = pg_fy.CurrentPage;
            struct_dyzx.p_pagesize = pg_fy.NumPerPage;
            DataTable dt = new DataTable();
            dt = dyzx.Select_DYZXShow(struct_dyzx);
            dt.Columns.Add("bmmc", typeof(string));
            dt.Columns.Add("gwmc", typeof(string));
            dt.Columns.Add("ztmc", typeof(string));
            dt.Columns.Add("sjmc");

            foreach (DataRow dr in dt.Rows)
            {
                dr["bmmc"] = SysData.BMByKey(dr["bmdm"].ToString()).mc;//部门
                dr["gwmc"] = SysData.GWByKey(dr["gwdm"].ToString()).mc;//岗位
                //dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dr["sjmc"] = dr["sj"].ToString().Substring(0, 10);
            }
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
        protected void btn_select_Click(object sender, EventArgs e)
        {
            bind_Main();
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
        #region 截取字符串(如果字符串的长度大于传入的规定长度，多余的部分则用...代替，否则，直接返回该字符串)
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="str">要截取的字符串</param>
        /// <param name="len">规定该字符串显示的长度</param>
        /// <returns>结果字符串</returns>
        public string GetCut(string str, int len)
        {
            //如果字符串的长度大于传入的规定长度，多余的部分则用...代替，否则，直接返回该字符串
            if (str.Length > len)
            {
                return str.Substring(0, len) + "...";

            }
            else
            {
                return str;
            }
        }
        #endregion
        protected void pg_fy_PageChanged(object sender, EventArgs e)
        {
            bind_Main();
        }
       


    }
}