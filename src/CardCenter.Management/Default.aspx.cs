using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardCenter.Management
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            username.Value = ZWL.ObjectOperation.CookieHelper.GetCookie("un");
            password.Attributes.Add("value", ZWL.ObjectOperation.CookieHelper.GetCookie("pw"));
        }
    }
}