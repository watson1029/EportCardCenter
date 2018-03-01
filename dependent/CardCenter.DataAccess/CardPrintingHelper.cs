using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace CardCenter.DataAccess
{
	/// <summary>
	/// 订单助手
	/// </summary>
	public class CardCenterHelper
	{
		/// <summary>
		/// 防止创建类的实例
		/// </summary>
		private CardCenterHelper()
		{
		}
	 
		private static readonly object Locker = new object();
		 

		/// <summary>
		/// 生成工单编号
		/// </summary>
		/// <returns></returns>
		public static string GetCardNo()
		{
			 lock ( Locker )  //lock 关键字可确保当一个线程位于代码的临界区时，另一个线程不会进入该临界区。
			{
                 string strCounterKey=DateTime.Now.ToString("yyyyMMdd") ;
				 RunProcedure runProcedure = new RunProcedure();
				 string strCounterValue=runProcedure.GetAppCounter(strCounterKey);
				 // Thread.Sleep(100);
				 //返回工单号
				 return string.Format("{0}{1}", strCounterKey, strCounterValue.ToString().PadLeft(5, '0'));
			}
		}

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="jobID">工单号</param>
        /// <param name="flow">流程编号</param>
        public static void SendMessage(string jobID)
        {
            try
            {
                if(bool.Parse(ZWL.GeneralHelper.GetSettingByKey("IsSend")))
                {
                    DataTable dt = new RunProcedure().SMSPro(jobID).Tables[0];
                    if (dt.Rows.Count > 0)
                        IRequestSend(dt);
                }
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// 发送短信QS
        /// </summary>
        /// <param name="jobID">工单号</param>
        public static void SendMessageQS(string jobID, string content)
        {
            try
            {
                if (bool.Parse(ZWL.GeneralHelper.GetSettingByKey("IsSend")))
                {
                    DataTable dt = new RunProcedure().SMS_QS(jobID, content).Tables[0];
                    if (dt.Rows.Count > 0)
                        IRequestSend(dt);
                }
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// 发送短信DKQ
        /// </summary>
        /// <param name="jobID">工单号</param>
        public static void SendMessageDKQ(string jobID, string content)
        {
            try
            {
                if (bool.Parse(ZWL.GeneralHelper.GetSettingByKey("IsSend")))
                {
                    DataTable dt = new RunProcedure().SMS_DKQ(jobID, content).Tables[0];
                    if (dt.Rows.Count > 0)
                        IRequestSend(dt);
                }
            }
            catch
            {
                return;
            }
        }

        public static void SendPwdMessage(Entity.Sys_User user, string pwd)
        {
            try
            {
                if (bool.Parse(ZWL.GeneralHelper.GetSettingByKey("IsSend")))
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Guid");
                    dt.Columns.Add("AgentPhone");
                    dt.Columns.Add("SendTxt");
                    dt.Rows.Add(Guid.NewGuid(), user.Phone, string.Format("制卡系统(管理端)用户{0}({1})，您的初始随机密码为{2}，请及时登录系统修改密码。", user.UserName, user.Name, pwd));
                    IRequestSend(dt);
                }
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// 调用短信接口
        /// </summary>
        /// <param name="phone">手机</param>
        /// <param name="content">内容</param>
        private static void IRequestSend(DataTable dt)
        {
            Entity.SendLog log = new Entity.SendLog();
            log.Guid = dt.Rows[0]["Guid"].ToString();
            log.SendPhone = dt.Rows[0]["AgentPhone"].ToString();
            log.SendContext = dt.Rows[0]["SendTxt"].ToString();
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(ZWL.GeneralHelper.GetSettingByKey("SMS") + dt.Rows[0]["AgentPhone"].ToString() + "/" + dt.Rows[0]["SendTxt"].ToString());
                req.Method = "GET";
                WebResponse res = req.GetResponse();
                using (StreamReader sr = new StreamReader(res.GetResponseStream()))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    Info info = serializer.Deserialize<Info>(new JsonTextReader(new StringReader(sr.ReadToEnd())));
                    if (info.result == "ok")
                        log.IsSend = true;
                    else
                    {
                        log.IsSend = false;
                        log.Error = info.error;
                    }
                }
            }
            catch (Exception ex)
            {
                log.IsSend = false;
                log.Error = ex.Message;
            }
            finally
            {
                DataAccess.TranHelper.BeginTran();
                new SendLog().Add(log);
                DataAccess.TranHelper.CommitTran();
            }
        }        
	}

    public class Info
    {
        public string result { get; set; }
        public string error { get; set; }
    }
}
