using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CardCenter.Management.Ajax
{
    /// <summary>
    /// SaveSaleBinding 的摘要说明
    /// </summary>
    public class SaveSaleBinding : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";
                Entity.SaleBinding mBinding = new Entity.SaleBinding();
                DataAccess.SaleBinding dalBinding = new DataAccess.SaleBinding();
                DataTable dtBindList = dalBinding.GetList("SaleID='" + context.Request.Form["jobID"] + "'").Tables[0];
                if (dtBindList.Rows.Count > 0)
                {
                    mBinding = dalBinding.GetEntity(dtBindList.Rows[0][0].ToString());
                    mBinding.JobID = context.Request.Form["jobList"];
                    dalBinding.Update(mBinding);
                }
                else
                {
                    mBinding.Guid = Guid.NewGuid().ToString();
                    mBinding.SaleID = context.Request.Form["jobID"];
                    mBinding.JobID = context.Request.Form["jobList"];
                    dalBinding.Add(mBinding);
                }
                context.Response.Write("");
            }
            catch (Exception ex)
            {
                context.Response.Write("保存绑定信息错误！" + ex.ToString());
            }
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