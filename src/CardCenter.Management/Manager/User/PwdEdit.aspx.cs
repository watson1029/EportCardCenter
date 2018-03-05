using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardCenter.Management.Manager.User
{
    public partial class PwdEdit : PageBase.UserVerifyPageManager
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Guid.Value = PageBase.CommonObject.ManagerUserInfo.guid;
            }
        }
    }
}