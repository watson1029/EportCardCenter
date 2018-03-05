using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace CardCenter.Management.Ajax
{
    /// <summary>
    /// GetCompanyName 的摘要说明
    /// </summary>
    public class GetCompanyName : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                string Code = context.Request.Form["customCode"];
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
                        context.Response.Write(JsonConvert.SerializeObject(new Data("", obj.FULL_NAME)));
                    }
                    catch (Exception ex)
                    {
                        context.Response.Write(JsonConvert.SerializeObject(new Data("转换企业对像失败:" + strCompany1 + "|" + ex.Message.ToString(), "")));
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
                        context.Response.Write(JsonConvert.SerializeObject(new Data("", obj.FULL_NAME)));
                    }
                    catch (Exception ex)
                    {
                        context.Response.Write(JsonConvert.SerializeObject(new Data("转换企业对像失败:" + strCompany2 + "|" + ex.Message.ToString(), "")));
                    }
                }
                else
                {
                    context.Response.Write(JsonConvert.SerializeObject(new Data("获取公司信息失败！", "")));
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(JsonConvert.SerializeObject(new Data(ex.Message.ToString(), "")));
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public class Data
        {
            public string error;
            public string msg;

            public Data(string error, string msg)
            {
                this.error = error;
                this.msg = msg;
            }
        }
    }
}