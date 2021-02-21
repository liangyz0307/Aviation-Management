using CUST.MKG;
using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CUST.MKG
{
    public class ZBJS : OZBJS
    {
        public ZBJS(UserState userstate) : base(userstate) { }
        public new DataSet Select_DQZC_ZBJS(Struct_zbjs struct_zbjs)
        {
            return base.Select_DQZC_ZBJS(struct_zbjs);
        }
        public new int Select_DQZC_ZBJS_Count(Struct_zbjs struct_zbjs)
        {
            return base.Select_DQZC_ZBJS_Count(struct_zbjs);
        }
        public new DataSet Select_DQZC_ZBJSShow(Struct_zbjs struct_zbjs)
        {
            return base.Select_DQZC_ZBJSShow(struct_zbjs);
        }
        public new int Select_DQZC_ZBJSShow_Count(Struct_zbjs struct_zbjs)
        {
            return base.Select_DQZC_ZBJSShow_Count(struct_zbjs);
        }
        public new void Insert_DQZC_ZBJS(Struct_zbjs struct_zbjs)
        {
            base.Insert_DQZC_ZBJS(struct_zbjs);
        }
        public new void Delete_DQZC_ZBJSid(string id)
        {
            base.Delete_DQZC_ZBJS(id);
        }
        public new void Update_DQZC_ZBJSZT(string id, string zt, string bhyy)
        {
            base.Update_DQZC_ZBJSZT(id, zt, bhyy);
        }
        public new string SelectWDBH(string id)
        {
            return base.SelectWDBH(id);
        }
        public new DataSet Select_ZLbyWDBH(string id)
        {
            return base.Select_ZLbyWDBH(id);
        }
    }
}
