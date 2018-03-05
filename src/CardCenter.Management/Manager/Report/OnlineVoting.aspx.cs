using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardCenter.Management.Manager.Report
{
    public partial class OnlineVoting : PageBase.UserVerifyPageManager
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void submit_Click(object sender, EventArgs e)
        {
            DateTime begin = DateTime.Parse(dtBegin.Value);
            DateTime end = DateTime.Parse(dtEnd.Value);
            DataSet ds = new DataSet();
            string filename = string.Empty;
            switch (dlStatistics.Value)
            {
                case "Statistics1":
                    ds = new DataAccess.RunProcedure().Statistics1(begin, end);
                    filename = string.Format("{0}-{1}-{2}.xls", begin.ToString("yyyyMMdd"), end.ToString("yyyyMMdd"), "常规业务量统计");
                    break;
                case "Statistics2":
                    ds = new DataAccess.RunProcedure().Statistics2(begin, end);
                    filename = string.Format("{0}-{1}-{2}.xls", begin.ToString("yyyyMMdd"), end.ToString("yyyyMMdd"), "支付统计");
                    break;
                case "Statistics3":
                    ds = new DataAccess.RunProcedure().Statistics3(begin, end);
                    filename = string.Format("{0}-{1}-{2}.xls", begin.ToString("yyyyMMdd"), end.ToString("yyyyMMdd"), "问卷调查统计");
                    break;
                case "Statistics4":
                    ds = new DataAccess.RunProcedure().Statistics4(begin, end);
                    filename = string.Format("{0}-{1}-{2}.xls", begin.ToString("yyyyMMdd"), end.ToString("yyyyMMdd"), "东方和南方支付信息");
                    break;
            }
            

            var bytes = PageBase.ExcelHelper.GetExcelFileByte(ds);
            Response.ContentType = "application/vnd.ms-excel;charset=utf-8";
            if (Request.Browser.Browser == "InternetExplorer")
            {
                filename = Server.UrlEncode(filename);
            }
            Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}",  filename));
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.Clear();
            Response.BinaryWrite(bytes);
            Response.End();
        }
    }
}