using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardCenter.Management.Manager.Stock
{
    public partial class StockList : PageBase.UserVerifyPageManager
    {
        public DataTable stockDt = new DataAccess.Stock_Commodity().GetList("").Tables[0];
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}