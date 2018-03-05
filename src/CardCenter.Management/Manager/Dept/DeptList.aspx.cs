 
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardCenter.Management.Manager.Dept
{
    public partial class DeptList : PageBase.UserVerifyPageManager//System.Web.UI.Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { //绑定部门                
                DataBind();

            }
        }

        

        private void DataBind()
        {
            DataAccess.ManagerDepartment pro = new DataAccess.ManagerDepartment();
            DataSet ds = pro.GetList("");
            DataView dv =  ds.Tables[0].DefaultView;
            dv.Sort = ("IsDelete ASC");
            repeater.DataSource = dv.Table;
            repeater.DataBind();
        }
        public string GetRolesHead()
        {
            string strCols = "";
            DataAccess.Para_District pro = new DataAccess.Para_District();
            DataSet ds = pro.GetList("");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                strCols += string.Format("<th>{0}</th>", ds.Tables[0].Rows[i]["District_Name"].ToString());
            }
            return strCols;
        }
        public string GetRolesDetail(string userId)
        {
            string strCols = "";
            DataAccess.Para_District pro = new DataAccess.Para_District();
            DataSet ds = pro.GetList("");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                strCols += (string.Format("<td><input id={5}{1}{5} onclick={5}SetRoles('{1}',{2},'{3}','{4}'){5}  type='checkbox' name='radio' data-labelauty='未授权|已授权' /></td>",
                    userId, userId + "_" + ds.Tables[0].Rows[i]["District_Code"].ToString(), "this.checked"
                    , userId, ds.Tables[0].Rows[i]["District_Code"].ToString(), @""""));
            }
            return strCols;
        }


        public string GetName(string isDel, string name, string deptId)
        {
            //string deptName = this.dllGroup.Items.FindByValue(deptId).Text;
            //if (deptName != "")
            //{
            //    name = "部门:" + deptName + ";" + name;
            //}
            if (isDel.ToLower() == "1" || isDel.ToLower() == "true")
            {
                return string.Format("<s>{0}</s>", name);
            }
            return name;
        }

    }
}