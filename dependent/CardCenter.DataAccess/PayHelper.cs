using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace CardCenter.DataAccess
{
    public class PayHelper
    {
        /// <summary>
        /// 调用支付下单接口
        /// </summary>
        /// <param name="jobID"></param>
        /// <returns></returns>
        public static string IPay(string jobID)
        {
            try
            {
                DataSet viewDt;
                DataAccess.RunProcedure run = new DataAccess.RunProcedure();
                string dbName = run.GetListDbName(jobID);
                if (string.IsNullOrEmpty(dbName))
                    throw new Exception("获取数据失败!");
                else
                    viewDt = run.JobView(jobID, dbName);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                //正式环境
                dic.Add("OrderId", jobID);
                dic.Add("Amount", (int.Parse(viewDt.Tables[0].Rows[0]["Fee"].ToString()) * 100).ToString());
                //测试环境
                //dic.Add("OrderId", jobID);
                //dic.Add("Amount", "1");
                dic.Add("Description", string.Format("数据分中心－{0}－制卡收费", viewDt.Tables[0].Rows[0]["JobName"].ToString()));
                dic.Add("ApplicantName", viewDt.Tables[0].Rows[0]["EnterpriseName"].ToString());
                dic.Add("AppId", ZWL.GeneralHelper.GetSettingByKey("AppId"));
                dic.Add("CallbackUrl", ZWL.GeneralHelper.GetSettingByKey("CallbackUrl"));
                dic.Add("NotifyUrl", ZWL.GeneralHelper.GetSettingByKey("NotifyUrl"));
                dic.Add("Account", "haicheng");
                dic.Add("Note", "");
                dic.Add("NonceStr", Guid.NewGuid().ToString().Replace("-", ""));
                return ZWL.GeneralHelper.GetSettingByKey("Pay") + Signature(dic);
            }
            catch (Exception ex)
            {
                DataAccess.TranHelper.BeginTran();
                new Sys_Log().AddLog(string.Format("Function:CardPrintHelper.IPay;Param:{0};ErrorMsg:{1}", jobID, ex.ToString()));
                DataAccess.TranHelper.CommitTran();
                return null;
            }
        }

        /// <summary>
        /// 调用支付查询接口
        /// </summary>
        /// <param name="jobID">工单号</param>
        /// <returns>支付结果</returns>
        public static Dictionary<string, string> IPaySearch(string jobID)
        {
            try
            {
                string url = ZWL.GeneralHelper.GetSettingByKey("PaySearch");
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("OrderId", jobID);
                dic.Add("AppId", ZWL.GeneralHelper.GetSettingByKey("AppId"));
                dic.Add("NonceStr", Guid.NewGuid().ToString().Replace("-", ""));
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(ZWL.GeneralHelper.GetSettingByKey("PaySearch") + Signature(dic));
                req.Method = "GET";
                req.Timeout = 5000;
                WebResponse res = req.GetResponse();
                using (StreamReader sr = new StreamReader(res.GetResponseStream()))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    return serializer.Deserialize<Dictionary<string, string>>(new JsonTextReader(new StringReader(sr.ReadToEnd())));
                    //if (Verify(returnDic))
                    //    return returnDic;
                    //else
                    //{
                    //    DataAccess.TranHelper.BeginTran();
                    //    new Sys_Log().AddLog(string.Format("Function:CardPrintHelper.IRequestPay;Param:{0};ErrorMsg:{1}", jobID, "数据验签失败!"));
                    //    DataAccess.TranHelper.CommitTran();
                    //    return null;
                    //}
                }
            }
            catch (Exception ex)
            {
                DataAccess.TranHelper.BeginTran();
                new Sys_Log().AddLog(string.Format("Function:CardPrintHelper.IRequestPay;Param:{0};ErrorMsg:{1}", jobID, ex.ToString()));
                DataAccess.TranHelper.CommitTran();
                return null;
            }
        }

        private static string GetParamStr(Dictionary<string, string> dic)
        {
            string param = string.Empty;
            var dicSort = from objDic in dic orderby objDic.Key select objDic;
            foreach (KeyValuePair<string, string> kvp in dicSort)
            {
                if (!string.IsNullOrEmpty(kvp.Value) && kvp.Key != "Signature")
                {
                    param += kvp.Key + "=" + kvp.Value + "&";
                }
            }
            return param;
        }

        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="dic">数据</param>
        /// <returns></returns>
        public static string Signature(Dictionary<string, string> dic)
        {
            string param = GetParamStr(dic);
            string signature = ZWL.Encrypt.AbstractHelper.EncryptMD5(param + "key=" + ZWL.GeneralHelper.GetSettingByKey("Key")).ToUpper();
            return param + "Signature=" + signature;
        }

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="dic">数据</param>
        /// <returns></returns>
        public static bool Verify(Dictionary<string, string> dic)
        {
            string signature = dic["Signature"];
            if (string.IsNullOrEmpty(signature))
                throw new Exception("数据缺少签名!");
            else
            {
                string param = GetParamStr(dic);
                if (signature == ZWL.Encrypt.AbstractHelper.EncryptMD5(param + "key=" + ZWL.GeneralHelper.GetSettingByKey("Key")).ToUpper())
                    return true;
                else
                    return false;
            }
        }
    }
}
