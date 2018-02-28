/**  版本信息模板在安装目录下，可自行修改。
* Para_QYXZ.cs
*
* 功 能： N/A
* 类 名： Para_QYXZ
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/4/26 10:47:26   N/A    初版
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
	/// Para_QYXZ:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	[DBEntityProperty(TableName="Para_QYXZ")]
	public partial class Para_QYXZ
	{
		public Para_QYXZ()
		{}
		#region Model
		private string _qyxz_value;
		private string _qyxz_name;
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="QYXZ_Value", ColunmType="string", CanEmpty=false, Length=2, IsDataTableRow=true, IsPrimarykey=true, IsIncrement=false,HaveDefaultValue=false)]
		public string QYXZ_Value
		{
			set{ _qyxz_value=value;}
			get{return _qyxz_value;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="QYXZ_Name", ColunmType="string", CanEmpty=true, Length=64, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string QYXZ_Name
		{
			set{ _qyxz_name=value;}
			get{return _qyxz_name;}
		}
		#endregion Model

	}
}

