/**  版本信息模板在安装目录下，可自行修改。
* Para_WHJ.cs
*
* 功 能： N/A
* 类 名： Para_WHJ
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/3/30 10:38:04   N/A    初版
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
	/// Para_WHJ:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	[DBEntityProperty(TableName="Para_WHJ")]
	public partial class Para_WHJ
	{
		public Para_WHJ()
		{}
		#region Model
		private string _whj_value;
		private string _whj_name;
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="WHJ_Value", ColunmType="string", CanEmpty=false, Length=6, IsDataTableRow=true, IsPrimarykey=true, IsIncrement=false,HaveDefaultValue=false)]
		public string WHJ_Value
		{
			set{ _whj_value=value;}
			get{return _whj_value;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="WHJ_Name", ColunmType="string", CanEmpty=true, Length=64, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string WHJ_Name
		{
			set{ _whj_name=value;}
			get{return _whj_name;}
		}
		#endregion Model

	}
}

