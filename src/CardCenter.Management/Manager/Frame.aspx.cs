using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardCenter.Management.Manager
{
    public partial class Frame : PageBase.UserVerifyPageManager
    {
        public static string Time = DateTime.Now.ToString("yyyy年MM月dd日");
        public static DataTable menu = new DataAccess.Sys_Menu().GetList("").Tables[0];
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}