using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardCenter.Management.Manager.User
{
    public partial class UserEdit : PageBase.UserVerifyPageManager
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = new DataAccess.Sys_Department().GetList("");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    department.Items.Add(new ListItem(dr["DepartmentName"].ToString(), dr["DepartmentID"].ToString()));
                }
                Entity.Sys_User user = new DataAccess.Sys_User().GetModel(ZWL.ObjectOperation.QueryStringHelper.GetQuery("Guid"));
                Guid.Value = user.Guid;
                userName.Text = user.UserName;
                trueName.Value = user.Name;
                department.Value = user.Department.ToString();
                phoneNum.Value = user.Phone;
            }
        }
    }
}