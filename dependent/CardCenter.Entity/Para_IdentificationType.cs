/**  版本信息模板在安装目录下，可自行修改。
* Para_IdentificationType.cs
*
* 功 能： N/A
* 类 名： Para_IdentificationType
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/2/23 12:05:49   N/A    初版
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
	/// 证件类型参数表
	/// </summary>
	[Serializable]
	[DBEntityProperty(TableName="Para_IdentificationType")]
	public partial class Para_IdentificationType
	{
		public Para_IdentificationType()
		{}
		#region Model
		private int _id;
		private string _name;
		/// <summary>
		/// 自编ID
		/// </summary>
		[DBRowEntityProperty(ColunmName="ID", ColunmType="int", CanEmpty=false, Length=4, IsDataTableRow=true, IsPrimarykey=true, IsIncrement=true,HaveDefaultValue=false)]
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 证件类型名称
		/// </summary>
		[DBRowEntityProperty(ColunmName="Name", ColunmType="string", CanEmpty=true, Length=16, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		#endregion Model

	}
}

