using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace CardCenter.PageBase
{
    public class UserVerifyPage : CommonPageBase
    {
        protected override void OnLoad(EventArgs e)
        {
            if (!Verify)
            {
                login();
            }
            base.OnLoad(e);
        }

        private bool Verify
        {
            get
            {
                if (string.IsNullOrEmpty(Request.QueryString["token"]))
                {
                    if (CommonObject.LoginUserInfo == null)
                        return false;
                    else
                        return true;
                }
                else
                {
                    return false;
                }
            }
        }

        #region 验证登录

        /// <summary>
        /// 获取用户信息
        /// </summary>
        private bool login()
        {
            string errorUrlUser = @"/CardPrinting/ErrPageUser.aspx?ErrorCode=";
            string errorUrlCompany = @"/CardPrinting/ErrPageCompany.aspx?ErrorCode=";
            string ErrPageCode = "";
            string companyErr = string.Empty;
            string userErr = string.Empty;
            if (!this.Page.IsPostBack)
            {
                try
                {


                    string strAppId = "CardPrinting";
                    if (string.IsNullOrEmpty(Request.QueryString["token"]))
                    {
                        Response.Redirect(errorUrlUser + Server.UrlEncode("没有url中的requestToken！"), false);
                        // Response.Redirect("ErrPage.html");
                        return false; ;
                    }

                    string requestToken = Request.QueryString["token"].ToString();
                    WebClient web = new WebClient();

                    // string requestTokenAddress=
                    string requestTokenAddress = System.Web.Configuration.WebConfigurationManager.AppSettings["requestTokenAddress"].ToString();
                    requestTokenAddress = requestTokenAddress + requestToken + @"/" + strAppId;
                    ErrPageCode = "正在换取" + requestTokenAddress;

                    //通过远程HTTP方式获取实际AccessToken
                    Stream getAccessToken = web.OpenRead(requestTokenAddress);

                    StreamReader reader = new StreamReader(getAccessToken);
                    string strAccessToken = reader.ReadToEnd();
                    getAccessToken.Close();
                    reader.Dispose();
                    web.Dispose();

                    if (string.IsNullOrEmpty(strAccessToken))
                    {
                        Response.Redirect(errorUrlUser + Server.UrlEncode("获取AccessToken失败！"), false);
                        return false;
                    }
                    else
                    {
                        //转换为AccessToken对像
                        AccessToken objAccessToken = new AccessToken();
                        try
                        {
                            JsonSerializer serializer = new JsonSerializer();
                            StringReader strReaderAccessToken = new StringReader(strAccessToken);
                            objAccessToken = serializer.Deserialize<AccessToken>(new JsonTextReader(strReaderAccessToken));

                        }
                        catch (Exception ex)
                        {

                            Response.Redirect(errorUrlUser + Server.UrlEncode("转换AccessToken对像失败！"), false);
                            return false;
                        }
                        if (objAccessToken == null || objAccessToken.access_token == null || objAccessToken.access_token == "")
                        {
                            Response.Redirect(errorUrlUser + Server.UrlEncode("获取objAccessToken.access_token失败！"), false);
                            return false;
                        }
                        //CompanyInfoEntity obj = new CompanyInfoEntity() { TEL_CO = "", CONTAC_CO = "", TRADE_CO = "", COP_GB_CODE = "", CUSTOMS_CODE = "", FULL_NAME = "" };
                        Session["CompanyAllData"] = null;
                        ErrPageCode = "正在获取企业信息";
                        //获取公司信息
                        companyErr = GetCompany(objAccessToken);
                        if (companyErr != "")
                        {
                            ErrPageCode = ErrPageCode + companyErr;
                            Response.Redirect(errorUrlCompany + companyErr, false);
                            return false;
                        }
                        Session["UserInfoEntity"] = null;
                        ErrPageCode = "正在获取用户信息";
                        //获取用户
                        userErr = GetUserInfo(objAccessToken);
                        if (userErr != "")
                        {
                            ErrPageCode = ErrPageCode + userErr;
                            Response.Redirect(errorUrlUser + userErr, false);
                            return false;
                        }

                    }
                }
                catch (Exception ex)
                {
                    string url = string.Empty;
                    if (!userErr.Trim().Equals(""))
                        url = errorUrlUser;
                    else
                        url = errorUrlCompany;
                    Response.Redirect(url + ex.Message.ToString() + "|" + ErrPageCode, false);
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 获取公司信息 
        /// </summary>
        /// <param name="objAccessToken"></param>
        private string GetCompany(AccessToken objAccessToken)
        {
            string ErrPageCode = "";
            try
            {
                WebClient web = new WebClient();
                StreamReader reader = null;
                //获取公司服务地址
                string getCompanyAddress = System.Web.Configuration.WebConfigurationManager.AppSettings["getCompanyAddress"].ToString();
                web = new WebClient();
                getCompanyAddress = getCompanyAddress + objAccessToken.access_token;
                ErrPageCode = getCompanyAddress;
                //远程获取公司信息
                System.IO.Stream getCompany = web.OpenRead(getCompanyAddress);

                reader = new StreamReader(getCompany);
                string strCompany = reader.ReadToEnd();
                getCompany.Close();
                reader.Dispose();

                if (!strCompany.Equals("{}"))
                {
                    try
                    {
                        //转换为公司对像
                        JsonSerializer serializer = new JsonSerializer();
                        StringReader sr = new StringReader(strCompany);
                        CompanyAllData obj = serializer.Deserialize<CompanyAllData>(new JsonTextReader(sr));
                        if (!obj.CUSTOMS_CODE.StartsWith("51"))
                            return "非广州关区企业不能办理此项业务";
                        else
                            Session["CompanyAllData"] = obj;
                    }
                    catch (Exception ex)
                    {
                        return "转换企业对像失败:" + strCompany + "|" + ex.Message.ToString() + "|" + ErrPageCode;

                    }

                }
                else
                {
                    Session["CompanyAllData"] = null;
                    return Server.UrlEncode("获取公司信息失败！" + "" + ErrPageCode);

                }
            }
            catch (Exception ex)
            {

                return ex.Message.ToString() + ErrPageCode;
            }
            return "";

        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="objAccessToken">TOKEN对像</param>
        /// <returns></returns>
        private string GetUserInfo(AccessToken objAccessToken)
        {
            string ErrPageCode = "";
            try
            {

                StreamReader reader = null;
                WebClient web = new WebClient();
                //获取用户信息服务地址
                string getUserAddress = System.Web.Configuration.WebConfigurationManager.AppSettings["getUserAddress"].ToString();
                web = new WebClient();
                getUserAddress = getUserAddress + objAccessToken.access_token;
                ErrPageCode = getUserAddress;
                //远程获取公司信息
                System.IO.Stream getUser = web.OpenRead(getUserAddress);

                reader = new StreamReader(getUser);
                string strgetUser = reader.ReadToEnd();
                getUser.Close();
                reader.Dispose();

                if (!string.IsNullOrEmpty(strgetUser))
                {
                    try
                    {
                        //转换为公司对像
                        JsonSerializer serializer = new JsonSerializer();
                        StringReader sr = new StringReader(strgetUser);
                        UserInfoEntity obj = serializer.Deserialize<UserInfoEntity>(new JsonTextReader(sr));
                        if (string.IsNullOrEmpty(obj.companyId))
                        {
                            obj.companyId = "";
                        }
                        Session["UserInfoEntity"] = obj;
                    }
                    catch (Exception ex)
                    {

                        return "转换用户对像失败:" + strgetUser + "|" + ex.Message.ToString() + "|" + ErrPageCode;
                    }

                }
                else
                {
                    Session["UserInfoEntity"] = null;
                    return Server.UrlEncode("获取用户信息失败！" + ErrPageCode);
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString() + ErrPageCode;
            }

            return "";
        }

        #endregion
    }
}
