using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardCenter.Manager
{
    public partial class Pay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ZWL.GeneralHelper.GetSettingByKey("IsOpenPay") == "YES")
                {
                    string jobID = ZWL.ObjectOperation.QueryStringHelper.GetQuery("jobID");
                    //调转至支付平台
                    if (!IsPostBack)
                        Response.Redirect(DataAccess.PayHelper.IPay(jobID), false);
                }
            }
        }
    }
}