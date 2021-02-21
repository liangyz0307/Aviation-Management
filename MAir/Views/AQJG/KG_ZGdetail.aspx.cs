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
    public partial class KG_ZGdetail : System.Web.UI.Page
    {
        private UserState _usState;
        private int id;
        private KG_ZG kg_zg;
        private DataTable dt_detail;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((_usState = (Session["UserState"] as UserState)) == null)
            {
                Response.Write("<script>alert(\"您还没有登陆或已超时！\");window.top.location.href='../../Login.aspx';</script>");
                Response.End();
                return;
            }
            kg_zg = new KG_ZG(_usState);
            if (!IsPostBack)
            {
                id =int.Parse(Request.Params["id"].ToString());
                select_detail();
            }
        }

        protected void select_detail()
        {
            id =int.Parse(Request.Params["id"].ToString());
            dt_detail = kg_zg.Select_ZG_Detail(id);
            lbl_zrr.Text = dt_detail.Rows[0]["zrrxm"].ToString();//责任人
            lbl_zgsx.Text = DateTime.Parse(dt_detail.Rows[0]["zgsx"].ToString()).ToString("yyyy-MM-dd");//整改时间
            lbl_zgxm.Text = dt_detail.Rows[0]["zgxm"].ToString();//受罚人
            lbl_zgfa.Text = dt_detail.Rows[0]["zgfa"].ToString();//简要经历和原因
            lbl_zgjd.Text = dt_detail.Rows[0]["zgjd"].ToString();//承担责任
            lbl_wtly.Text = dt_detail.Rows[0]["wtly"].ToString();//处理意见
            lbl_wtlb.Text =dt_detail.Rows[0]["wtlb"].ToString();//处理意见
            lbl_fxkzcs.Text = dt_detail.Rows[0]["fxkzcs"].ToString();//处理意见
            lbl_zt.Text = SysData.ZGZTByKey(dt_detail.Rows[0]["zt"].ToString()).mc;//状态
            lbl_bhyy.Text = dt_detail.Rows[0]["bhyy"].ToString();//驳回原因
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
            Response.Redirect("KG_ZG_select.aspx");
            //Server.Transfer("KG_ZG_add.aspx");
        }

        protected void btn_xz_Click(object sender, EventArgs e)
        {

            id = int.Parse(Request.Params["id"].ToString());
            string ck = kg_zg.Select_ZG_Detail(id).Rows[0]["filepath"].ToString();
            //Response.Redirect(ck);

            // string fileName = "AQJG.xlsx";                               //客户端保存的文件名
            int start = ck.LastIndexOf("\\");                               //客户端保存的文件名
            string fileName = ck.Substring(start + 1, ck.Length - (start + 1));
            string filePath = ck;//Server.MapPath("../AQJG/JCJLPic/" + _usState.userLB + _usState.userLoginName + "/") + fileName;    //目标文件路径
            FileInfo fileInfo = new FileInfo(filePath);
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
            Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            Response.AddHeader("Content-Transfer-Encoding", "binary");
            Response.ContentType = "application/octet-stream";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            Response.WriteFile(fileInfo.FullName);
            Response.Flush();
            Response.End();
        }
    }
}