using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZWL;

namespace CardCenter
{
    public partial class BuildingPage : System.Web.UI.Page
    {
        public string pageName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                pageName = ZWL.ObjectOperation.QueryStringHelper.GetQuery("pageName");
        }
    }
}