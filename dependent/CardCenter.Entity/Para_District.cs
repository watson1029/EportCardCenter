/**  版本信息模板在安装目录下，可自行修改。
* Para_District.cs
*
* 功 能： N/A
* 类 名： Para_District
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/18 11:22:43   N/A    初版
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
	/// Para_District:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	[DBEntityProperty(TableName="Para_District")]
	public partial class Para_District
	{
		public Para_District()
		{}
		#region Model
		private string _district_code;
		private string _district_name;
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="District_Code", ColunmType="string", CanEmpty=false, Length=5, IsDataTableRow=true, IsPrimarykey=true, IsIncrement=false,HaveDefaultValue=false)]
		public string District_Code
		{
			set{ _district_code=value;}
			get{return _district_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="District_Name", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string District_Name
		{
			set{ _district_name=value;}
			get{return _district_name;}
		}
		#endregion Model

	}
}

