using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace CardCenter.Management.Ajax
{
	/// <summary>
	/// HandleList 的摘要说明
	/// </summary>
	public class HandleList : IHttpHandler
	{

		public void ProcessRequest(HttpContext context)
		{
			  LoadData(context);
		}

		public bool IsReusable
		{
			get
			{
				return false;
			}
		}

		/// <summary>
		/// 加载数据
		/// </summary>
		/// <param name="context"></param>
		private static void LoadData(HttpContext context)
		{

			DataAccess.HandleList runProc = new DataAccess.HandleList();
			DataSet ds = runProc.GetList("");

			context.Response.Write(JsonConvert.SerializeObject(ds.Tables[0]));
		}
	}
}