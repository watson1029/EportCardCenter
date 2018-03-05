using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardCenter.PageBase
{
    public class UserVerifyPageManager : CommonPageBase
    {
        protected override void OnLoad(EventArgs e)
        {
            if (!Verify)
            {
                Response.Redirect("/CardCenter.Management/Default.aspx", false);
            }
            base.OnLoad(e);
        }

        private bool Verify
        {
            get
            {
                if (CommonObject.ManagerUserInfo != null)
                    return true;
                else
                    return false;
            }
        }
    }
}
