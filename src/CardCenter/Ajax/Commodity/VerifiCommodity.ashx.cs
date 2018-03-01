using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CardCenter.Ajax.Commodity
{
    /// <summary>
    /// VerifiCommodity 的摘要说明
    /// </summary>
    public class VerifiCommodity : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string jobID = context.Request.Form["jobID"];
            string[] jobList = context.Request.Form["jobList"].Split(';');
            string msg = string.Empty;
            if (!string.IsNullOrEmpty(jobID))
            {
                int[] CardNum = new int[4];
                DataTable dt = new DataAccess.RunProcedure().SelectCardNum(jobID).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    CardNum[0] = int.Parse(dt.Rows[0][0].ToString());
                    CardNum[1] = int.Parse(dt.Rows[0][1].ToString());
                    CardNum[2] = int.Parse(dt.Rows[0][2].ToString());
                    CardNum[3] = int.Parse(dt.Rows[0][3].ToString());
                }
                int[] needCardNum = new int[4];
                foreach (string job in jobList)
                {
                    if (!string.IsNullOrEmpty(job))
                    {
                        DataTable selectDt = new DataAccess.RunProcedure().SelectCardNum(job).Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            needCardNum[0] += int.Parse(selectDt.Rows[0][0].ToString());
                            needCardNum[1] += int.Parse(selectDt.Rows[0][1].ToString());
                            needCardNum[2] += int.Parse(selectDt.Rows[0][2].ToString());
                            needCardNum[3] += int.Parse(selectDt.Rows[0][3].ToString());
                        }

                    }
                }
                if (CardNum[0] != needCardNum[0] || CardNum[1] != needCardNum[1] || CardNum[2] != needCardNum[2] || CardNum[3] != needCardNum[3])
                    msg = string.Format("根据您绑定的业务申请单，您需要添加：{0}张法人卡；{1}张操作员IC卡；{2}张操作员IKEY；{3}张报关员卡；请检查已添加的安全产品数量是否不足或过多。", needCardNum[0], needCardNum[1], needCardNum[2], needCardNum[3]);

                if (msg.Equals(string.Empty))
                {
                    DataSet ds = new DataAccess.RunProcedure().JobView(jobID, "SaleList");
                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        if (int.Parse(dr["Num"].ToString()) > int.Parse(dr["StockDesplay"].ToString()))
                            msg += string.Format("{0}{1}（{2}）库存不足；", dr["AdditionalAttributes"], dr["CommodityName"], dr["CommodityType"]);
                    }
                    if (!msg.Equals(string.Empty))
                        msg += "请更换库存充足的安全产品厂商或稍后再试";
                }
            }
            context.Response.Write(msg);
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