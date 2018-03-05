using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardCenter.Management.Manager.User
{
    public partial class UserList : PageBase.UserVerifyPageManager
    {
        public DataTable userDt = new DataAccess.Sys_User().GetList("IsDelete=0 order by CreateTime").Tables[0];
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}