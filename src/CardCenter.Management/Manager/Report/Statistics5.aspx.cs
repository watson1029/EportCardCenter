using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardCenter.Management.Manager.Report
{
    public partial class Statistics5 : System.Web.UI.Page
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

            ds = new DataAccess.RunProcedure().Statistics5(begin, end);
            ds.Tables[0].Columns.Add("关区代码");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                ds.Tables[0].Rows[i][7] = GetCustomCode(ds.Tables[0].Rows[i][3].ToString());
            filename = string.Format("{0}-{1}-{2}.xls", begin.ToString("yyyyMMdd"), end.ToString("yyyyMMdd"), "工单详细信息统计（广州关区）");

            var bytes = PageBase.ExcelHelper.GetExcelFileByte(ds);
            Response.ContentType = "application/vnd.ms-excel;charset=utf-8";
            if (Request.Browser.Browser == "InternetExplorer")
            {
                filename = Server.UrlEncode(filename);
            }
            Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", filename));
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.Clear();
            Response.BinaryWrite(bytes);
            Response.End();
        }

        private string GetCustomCode(string Code)
        {
            try
            {
                WebClient web = new WebClient();
                StreamReader reader = null;
                //获取公司服务地址
                string getCompanyAddress1 = System.Web.Configuration.WebConfigurationManager.AppSettings["getCompanyAddress1"].ToString();
                string getCompanyAddress2 = System.Web.Configuration.WebConfigurationManager.AppSettings["getCompanyAddress2"].ToString();
                web = new WebClient();
                getCompanyAddress1 = getCompanyAddress1 + Code;
                getCompanyAddress2 = getCompanyAddress2 + Code;
                //远程获取公司信息
                System.IO.Stream getCompany1 = web.OpenRead(getCompanyAddress1);
                System.IO.Stream getCompany2 = web.OpenRead(getCompanyAddress2);

                reader = new StreamReader(getCompany1);
                string strCompany1 = reader.ReadToEnd();
                getCompany1.Close();

                reader = new StreamReader(getCompany2);
                string strCompany2 = reader.ReadToEnd();
                getCompany2.Close();

                reader.Dispose();

                if (!strCompany1.Equals(""))
                {
                    try
                    {
                        //转换为公司对像
                        JsonSerializer serializer = new JsonSerializer();
                        StringReader sr = new StringReader(strCompany1);
                        PageBase.CompanyData obj = serializer.Deserialize<PageBase.CompanyData>(new JsonTextReader(sr));
                        return obj.CUSTOMS_CODE;
                    }
                    catch
                    {
                        return "";
                    }
                }
                else if (!strCompany2.Equals(""))
                {
                    try
                    {
                        //转换为公司对像
                        JsonSerializer serializer = new JsonSerializer();
                        StringReader sr = new StringReader(strCompany2);
                        PageBase.CompanyData obj = serializer.Deserialize<PageBase.CompanyData>(new JsonTextReader(sr));
                        return obj.CUSTOMS_CODE;
                    }
                    catch
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                return "";
            }
        }
    }
}