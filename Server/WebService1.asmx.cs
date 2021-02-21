using CUST;
using Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Server
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
   
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod(true, Description = "用户登录验证")]
        public bool Login(string loginname, string password)
        {
            try
            {
                Struct_UserContext S_userContext = new Struct_UserContext(this.Context.Request.UserHostAddress, this.Session.SessionID);
                UserState userstate = new UserState(loginname, password, S_userContext);
                this.Session["UserState"] = userstate;
                return true;
            }
            catch (EMException ex)
            {
                throw (EMException.ThrowException(ex));
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
}
