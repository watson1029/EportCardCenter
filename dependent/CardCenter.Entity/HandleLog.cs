/**  版本信息模板在安装目录下，可自行修改。
* HandleLog.cs
*
* 功 能： N/A
* 类 名： HandleLog
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/6 10:21:51   N/A    初版
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
	/// HandleLog:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	[DBEntityProperty(TableName="HandleLog")]
	public partial class HandleLog
	{
		public HandleLog()
		{}
		#region Model
		private string _guid;
		private string _lastopeartion;
		private string _lastremark;
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="Guid", ColunmType="string", CanEmpty=false, Length=64, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string Guid
		{
			set{ _guid=value;}
			get{return _guid;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="LastOpeartion", ColunmType="string", CanEmpty=true, Length=8, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string LastOpeartion
		{
			set{ _lastopeartion=value;}
			get{return _lastopeartion;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="LastRemark", ColunmType="string", CanEmpty=true, Length=512, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string LastRemark
		{
			set{ _lastremark=value;}
			get{return _lastremark;}
		}
		#endregion Model

	}
}

