using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardCenter.Management.Manager.Authorize
{
    public partial class UserRole : PageBase.UserVerifyPageManager
    {
        public DataTable userDt = new DataAccess.Sys_User().GetList("1=1 order by CreateTime").Tables[0];
        public DataTable roleDt = new DataAccess.Sys_Role().GetList("").Tables[0];
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}