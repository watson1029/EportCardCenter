using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CardCenter.Ajax.Commodity
{
    /// <summary>
    /// SelectCardNum 的摘要说明
    /// </summary>
    public class SelectCardNum : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string jobID = context.Request.Form["jobID"];
            string[] jobList = context.Request.Form["jobList"].Split(';');
            int[] carNum = new int[4];
            if (!string.IsNullOrEmpty(jobID))
            {
                //SaleBinding数据
                Entity.SaleBinding mBinding = new Entity.SaleBinding();
                DataAccess.SaleBinding dalBinding = new DataAccess.SaleBinding();
                DataTable dtBindList = dalBinding.GetList("SaleID='" + jobID + "'").Tables[0];
                if (dtBindList.Rows.Count > 0)
                {
                    mBinding = dalBinding.GetEntity(dtBindList.Rows[0][0].ToString());
                    mBinding.JobID = context.Request.Form["jobList"];
                    dalBinding.Update(mBinding);
                }
                else
                {
                    mBinding.Guid = Guid.NewGuid().ToString();
                    mBinding.SaleID = jobID;
                    mBinding.JobID = context.Request.Form["jobList"];
                    dalBinding.Add(mBinding);
                }
            }

            //获取所需安全产品数量
            foreach(string job in jobList)
            {
                if (!string.IsNullOrEmpty(job))
                {
                    DataTable dt = new DataAccess.RunProcedure().SelectCardNum(job).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        carNum[0] += int.Parse(dt.Rows[0][0].ToString());
                        carNum[1] += int.Parse(dt.Rows[0][1].ToString());
                        carNum[2] += int.Parse(dt.Rows[0][2].ToString());
                        carNum[3] += int.Parse(dt.Rows[0][3].ToString());
                    }

                }
            }
            context.Response.Write(string.Format("{0}张法人卡，{1}张操作员IC卡，{2}张操作员IKEY，{3}张报关员卡。", carNum[0], carNum[1], carNum[2], carNum[3]));
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