using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardCenter.Management.Manager
{
    public partial class InvoiceList : PageBase.UserVerifyPageManager
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBind();
            }
        }

        private void DataBind()
        {
            DataAccess.RunProcedure pro = new DataAccess.RunProcedure();
            repeater.DataSource = pro.InvoiceList();
            repeater.DataBind();
        }
    }
}