/**  版本信息模板在安装目录下，可自行修改。
* Para_FRLX.cs
*
* 功 能： N/A
* 类 名： Para_FRLX
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/3/30 10:38:02   N/A    初版
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
	/// Para_FRLX:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	[DBEntityProperty(TableName="Para_FRLX")]
	public partial class Para_FRLX
	{
		public Para_FRLX()
		{}
		#region Model
		private string _frlx_value;
		private string _frlx_name;
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="FRLX_Value", ColunmType="string", CanEmpty=false, Length=1, IsDataTableRow=true, IsPrimarykey=true, IsIncrement=false,HaveDefaultValue=false)]
		public string FRLX_Value
		{
			set{ _frlx_value=value;}
			get{return _frlx_value;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="FRLX_Name", ColunmType="string", CanEmpty=true, Length=64, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string FRLX_Name
		{
			set{ _frlx_name=value;}
			get{return _frlx_name;}
		}
		#endregion Model

	}
}

