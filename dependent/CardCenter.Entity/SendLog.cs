/**  版本信息模板在安装目录下，可自行修改。
* SendLog.cs
*
* 功 能： N/A
* 类 名： SendLog
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/6 10:21:52   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using Job.Entity;
namespace CardCenter.Entity
{
	/// <summary>
	/// SendLog:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	[DBEntityProperty(TableName="SendLog")]
	public partial class SendLog
	{
		public SendLog()
		{}
		#region Model
		private string _guid;
		private bool _issend;
		private string _error;
		private string _sendphone;
		private string _sendcontext;
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="Guid", ColunmType="string", CanEmpty=false, Length=64, IsDataTableRow=true, IsPrimarykey=true, IsIncrement=false,HaveDefaultValue=false)]
		public string Guid
		{
			set{ _guid=value;}
			get{return _guid;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="IsSend", ColunmType="bool", CanEmpty=true, Length=1, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public bool IsSend
		{
			set{ _issend=value;}
			get{return _issend;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="Error", ColunmType="string", CanEmpty=true, Length=512, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string Error
		{
			set{ _error=value;}
			get{return _error;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="SendPhone", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string SendPhone
		{
			set{ _sendphone=value;}
			get{return _sendphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="SendContext", ColunmType="string", CanEmpty=true, Length=512, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string SendContext
		{
			set{ _sendcontext=value;}
			get{return _sendcontext;}
		}
		#endregion Model

	}
}

