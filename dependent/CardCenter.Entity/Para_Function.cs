/**  版本信息模板在安装目录下，可自行修改。
* Para_Function.cs
*
* 功 能： N/A
* 类 名： Para_Function
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
	/// Para_Function:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	[DBEntityProperty(TableName="Para_Function")]
	public partial class Para_Function
	{
		public Para_Function()
		{}
		#region Model
		private string _id;
		private string _name;
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="ID", ColunmType="string", CanEmpty=false, Length=8, IsDataTableRow=true, IsPrimarykey=true, IsIncrement=false,HaveDefaultValue=false)]
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="Name", ColunmType="string", CanEmpty=true, Length=64, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		#endregion Model

	}
}

