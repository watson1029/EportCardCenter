using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CardCenter.Ajax
{
    /// <summary>
    /// PageLogicHelper 的摘要说明
    /// </summary>
    public class PageLogicHelper : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {

                string strAction = context.Request.QueryString["Action"];
                switch (strAction)
                {
                    case "GetXSPTData":
                        GetXSPTData(context);
                        break;


                    default:
                        break;
                }

            }
            catch (Exception ex)
            {

                context.Response.Write("获取数据失败" + ex.Message);
            }
        }
        private void GetXSPTData(HttpContext context)
        {
            string struniscid = context.Request["uniscid"];
            if (string.IsNullOrEmpty(struniscid.Trim()))
            {
                context.Response.Write("获取数据失败" + "统一社会信用代码为空!");
                return;
            }
            CardCenter.CommercialAffairsOracleDataAccess.EX_GONGSHANG_41_SSZTJCXX_DA da = new CardCenter.CommercialAffairsOracleDataAccess.EX_GONGSHANG_41_SSZTJCXX_DA();
            DataTable dt = da.GET_EX_GONGSHANG_41_SSZTJCXX_BYUNISCID(struniscid.Trim());
            if (dt != null && dt.Rows.Count > 0)
            {
                dt.Columns.Add("DZ");
                //再去查询地址信息
                string zch = dt.Rows[0]["zch"].ToString();
                //根据注册号查询地址
                DataTable dtAddress = da.GET_EX_GONGSHANG_43_SSZTJYCX_BYZCH(zch);
                if (dtAddress != null && dtAddress.Rows.Count > 0)
                {
                    dt.Rows[0]["DZ"] = dtAddress.Rows[0]["dz"].ToString();
                }
                else
                {
                    dt.Rows[0]["DZ"] = "";
                }
            }
            context.Response.Write(JsonConvert.SerializeObject(dt));
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