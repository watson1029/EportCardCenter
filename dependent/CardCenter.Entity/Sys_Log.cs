/**  版本信息模板在安装目录下，可自行修改。
* Sys_Log.cs
*
* 功 能： N/A
* 类 名： Sys_Log
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/8 15:59:40   N/A    初版
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
	/// Sys_Log:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	[DBEntityProperty(TableName="Sys_Log")]
	public partial class Sys_Log
	{
		public Sys_Log()
		{}
		#region Model
		private string _guid;
		private DateTime? _logtime;
		private string _logcontent;
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
		[DBRowEntityProperty(ColunmName="LogTime", ColunmType="DateTime", CanEmpty=true, Length=8, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public DateTime? LogTime
		{
			set{ _logtime=value;}
			get{return _logtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="LogContent", ColunmType="string", CanEmpty=true, Length=0, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string LogContent
		{
			set{ _logcontent=value;}
			get{return _logcontent;}
		}
		#endregion Model

	}
}

