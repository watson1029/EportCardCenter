using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Newtonsoft.Json;


namespace CardCenter.Management.Ajax
{
    /// <summary>
    /// 处理授权逻辑
    /// </summary>
    public class Dept : IHttpHandler, IRequiresSessionState
    {

        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            try
            {

                string strAction = context.Request.QueryString["Action"];
                switch (strAction)
                {
                    case "UpdateData":
                        UpdateData(context);
                        break;
                    case "LoadData":
                        LoadData(context);
                        break;

                    default:
                        break;
                }

            }
            catch (Exception ex)
            {

                context.Response.Write("保存失败" + ex.Message);
            }



        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="context"></param>
        private static void LoadData(HttpContext context)
        {

            DataAccess.DepartmentDistrict runProc = new DataAccess.DepartmentDistrict();
            DataSet ds = runProc.GetList("");

            context.Response.Write(JsonConvert.SerializeObject(ds.Tables[0]));
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="context"></param>
        private static void UpdateData(HttpContext context)
        {
            string strRowType = context.Request["RowType"];
            string strRoleId = context.Request["RoleId"];
            string strUserId = context.Request["UserId"];

            string id = "0";
            DataAccess.DepartmentDistrict runProc = new DataAccess.DepartmentDistrict();
            DataSet ds = runProc.GetList(string.Format(" DepartmentID={0} and DistrictID='{1}' ", strUserId, strRoleId));
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    id = ds.Tables[0].Rows[0]["ID"].ToString();
                }
            }
            DataAccess.TranHelper.BeginTran();
            if (int.Parse(strRowType) == 1)
            {
                runProc.Delete(int.Parse(id));
                runProc.Add(new Entity.DepartmentDistrict() { DepartmentID = int.Parse(strUserId), DistrictID = strRoleId });
            }
            else
            {
                runProc.Delete(int.Parse(id));
            }
            try
            {
                DataAccess.TranHelper.CommitTran();
            }
            catch (Exception ex)
            {
                context.Response.Write("保存失败!" + ex.ToString());
            }
            context.Response.Write("保存成功");

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
