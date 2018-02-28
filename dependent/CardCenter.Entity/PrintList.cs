/**  版本信息模板在安装目录下，可自行修改。
* PrintList.cs
*
* 功 能： N/A
* 类 名： PrintList
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/6/28 10:31:24   N/A    初版
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
	/// PrintList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	[DBEntityProperty(TableName="PrintList")]
	public partial class PrintList
	{
		public PrintList()
		{}
		#region Model
		private int _id;
		private string _value;
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="ID", ColunmType="int", CanEmpty=false, Length=4, IsDataTableRow=true, IsPrimarykey=true, IsIncrement=true,HaveDefaultValue=false)]
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="Value", ColunmType="string", CanEmpty=true, Length=8, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string Value
		{
			set{ _value=value;}
			get{return _value;}
		}
		#endregion Model

	}
}

