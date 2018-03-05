using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardCenter.Management.Manager
{
	public partial class loginOut : PageBase.UserVerifyPageManager//System.Web.UI.Page 
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			PageBase.CommonObject.ManagerUserInfo = null;

            Response.Redirect("../Default.aspx", false);
		}
	}
}