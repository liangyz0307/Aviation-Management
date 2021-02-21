using Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CUST.MKG
{
    public class GHGL : OGHGL
    {
        public GHGL(UserState userstate) : base(userstate) { }
        public new DataSet Select_DQZC_GHGL(Struct_ghgl struct_ghgl)
        {
            return base.Select_DQZC_GHGL(struct_ghgl);
        }
        public new DataSet Select_GHGLShow_Pro(Struct_ghgl struct_ghgl)
        {
            return base.Select_GHGLShow_Pro(struct_ghgl);
        }
        public new int Select_DQZC_GHGL_Count(Struct_ghgl struct_ghgl)
        {
            return base.Select_DQZC_GHGL_Count(struct_ghgl);
        }
        public new int Select_GHGLShow_Count(Struct_ghgl struct_ghgl)
        {
            return base.Select_GHGLShow_Count(struct_ghgl);
        }
        public new DataSet Select_DQZC_GHGLShow(Struct_ghgl struct_ghgl)
        {
            return base.Select_DQZC_GHGLShow(struct_ghgl);
        }
        public new int Select_DQZC_GHGLShow_Count(Struct_ghgl struct_ghgl)
        {
            return base.Select_DQZC_GHGLShow_Count(struct_ghgl);
        }
        public new void Insert_DQZC_GHGL(Struct_ghgl struct_ghgl)
        {
            base.Insert_DQZC_GHGL(struct_ghgl);
        }
        public new void Delete_DQZC_GHGL(string id)
        {
            base.Delete_DQZC_GHGL(id);
        }
        public new void Update_DQZC_GHGLZT(string id, string zt, string bhyy)
        {
            base.Update_DQZC_GHGLZT(id, zt, bhyy);
        }
        public new string SelectWDBH(string id)
        {
            return base.SelectWDBH(id);
        }
        public new DataSet Select_ZLbyWDBH(string id)
        {
            return base.Select_ZLbyWDBH(id);
        }
        public new DataTable Find_GHGL_ById()
        {
            return base.Find_GHGL_ById();
        }
    }
}
