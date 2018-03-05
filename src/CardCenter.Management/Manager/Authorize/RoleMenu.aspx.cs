using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardCenter.Management.Manager.Authorize
{
    public partial class RoleMenu : System.Web.UI.Page
    {
        public DataTable roleDt = new DataAccess.Sys_Role().GetList("").Tables[0];
        public DataTable menuDt = new DataAccess.Sys_Menu().GetList("MenuUrl!='#'").Tables[0];
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}