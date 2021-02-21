using CUST;
using CUST.MKG;
using CUST.Sys;
using CUST.Tools;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CUST.WKG
{
    public partial class ZZ_Detail : System.Web.UI.Page

    {

        private UserState _usState;
        public int cpage1;
        public int psize1;
        public int cpage2;
        public int psize2;
        public int cpage3;
        public int psize3;
        private string ygbh;
        private YGZZ ygzz;
        private Struct_YGZZ struct_ygzz;
        private DataTable dt_detail;
       public string  filepath;
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            ygzz = new YGZZ(_usState);
            if (!IsPostBack)
            {
                ygbh = Request.Params["ygbh"].ToString();
                bind_Main();

            }
        }
    
        private void bind_Main()
        {

            #region 英语列表

            DateTime dt = new DateTime();
            DataTable dt_yy = ygzz.Select_YGZZByYGBH(Request.Params["ygbh"].ToString(),_usState.userID).Tables[0];
            dt_yy.Columns.Add("ztmc");
            dt_yy.Columns.Add("yydjmc");
            dt_yy.Columns.Add("yyyxqmc", typeof(string));
            foreach (DataRow dr in dt_yy.Rows)
            {
               
                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dr["yydjmc"] = SysData.YYDJLBByKey(dr["yydj"].ToString()).mc;//英语等级
                if (dr["yyyxq"].ToString() == dt.ToString())
                {
                    dr["yyyxqmc"] = "";
                }
                else {
                   DateTime dt_sj = Convert.ToDateTime(dr["yyyxq"].ToString().Trim());
                    dr["yyyxqmc"] = string.Format("{0:yyyy-MM-dd}", dt_sj);
                }
            }


            //绑定分页数据源  
            this.Repeater1.DataSource = dt_yy.DefaultView;
            this.Repeater1.DataBind();
            #endregion
            #region 执照列表


            DataTable dt_zz = ygzz.Select_YGZZByYGBH(Request.Params["ygbh"].ToString(),_usState.userID).Tables[1];
            dt_zz.Columns.Add("ztmc");
            dt_zz.Columns.Add("bfrq", typeof(string));
            foreach (DataRow dr in dt_zz.Rows)
            {

                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态

                if (dr["zzbfrq"].ToString() == dt.ToString())
                {
                    dr["bfrq"] = "";
                }
                else {
                    DateTime dt_bfsj = Convert.ToDateTime(dr["zzbfrq"].ToString().Trim());
                    dr["bfrq"] = string.Format("{0:yyyy-MM-dd}", dt_bfsj);
                }
            }


            //绑定分页数据源  
            this.Repeater2.DataSource = dt_zz.DefaultView;
            this.Repeater2.DataBind();
            #endregion

            #region 签注列表


            DataTable dt_qz = ygzz.Select_YGZZByYGBH(Request.Params["ygbh"].ToString(),_usState.userID).Tables[2];
            dt_qz.Columns.Add("ztmc");
            dt_qz.Columns.Add("qzzymc");
            dt_qz.Columns.Add("qzlbmc");
            dt_qz.Columns.Add("qzxmc");
            dt_qz.Columns.Add("tjdjmc");
            dt_qz.Columns.Add("qzyxqmc", typeof(string));
            dt_qz.Columns.Add("ydqzyxqmc", typeof(string));
            dt_qz.Columns.Add("tjyxqmc", typeof(string));
            dt_qz.Columns.Add("ydqzxmc");
            dt_qz.Columns.Add("ydqzmc");
           
            foreach (DataRow dr in dt_qz.Rows)
            {

                dr["ztmc"] = SysData.ZTDMByKey(dr["zt"].ToString()).mc;//状态
                dr["qzzymc"] = SysData.QZZYByKey(dr["qzzy"].ToString()).mc;//签注专业
                dr["qzlbmc"] = SysData.ZZQZLBDMByKey(dr["qzlb"].ToString()).mc;//签注类别
                dr["qzxmc"] = SysData.ZZQZXDMByKey(dr["qzx"].ToString()).mc;//签注项
                dr["tjdjmc"] = SysData.TJDJBByKey(dr["tjdj"].ToString()).mc;//体检等级
                dr["ydqzxmc"] = SysData.ZZQZXDMByKey(dr["ydqzx"].ToString()).mc;//异地签注项
                dr["ydqzmc"] = SysData.YDQZByKey(dr["ydqz"].ToString()).mc;//异地签注项
                if (dr["qzyxq"].ToString() == dt.ToString())
                {
                    dr["qzyxqmc"] = "";
                }
                else {
                    DateTime dt_qzsj = Convert.ToDateTime(dr["qzyxq"].ToString().Trim());
                    dr["qzyxqmc"] = string.Format("{0:yyyy-MM-dd}", dt_qzsj);
                }
                if (dr["ydqzyxq"].ToString() == dt.ToString())
                {
                    dr["ydqzyxqmc"] = "";
                }
                else {
                    DateTime dt_ydsj = Convert.ToDateTime(dr["ydqzyxq"].ToString().Trim());
                    dr["ydqzyxqmc"] = string.Format("{0:yyyy-MM-dd}", dt_ydsj);
                }
                if (dr["tjyxq"].ToString() == dt.ToString())
                {
                    dr["tjyxqmc"] = "";
                }
                else {
                    DateTime dt_tjsj = Convert.ToDateTime(dr["tjyxq"].ToString().Trim());
                    dr["tjyxqmc"] = string.Format("{0:yyyy-MM-dd}", dt_tjsj);
                }
            }


            //绑定分页数据源  
            this.Repeater3.DataSource = dt_qz.DefaultView;
            this.Repeater3.DataBind();
            #endregion
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

        protected void btn_fh_Click(object sender, EventArgs e)
        {
            Response.Redirect("ZZGL.aspx");
        }

       
    }
}