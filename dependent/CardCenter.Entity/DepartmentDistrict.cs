/**  版本信息模板在安装目录下，可自行修改。
* DepartmentDistrict.cs
*
* 功 能： N/A
* 类 名： DepartmentDistrict
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/23 10:01:32   N/A    初版
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
	/// DepartmentDistrict:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	[DBEntityProperty(TableName="DepartmentDistrict")]
	public partial class DepartmentDistrict
	{
		public DepartmentDistrict()
		{}
		#region Model
		private int _id;
		private int? _departmentid;
		private string _districtid;
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="ID", ColunmType="int", CanEmpty=false, Length=4, IsDataTableRow=true, IsPrimarykey=true, IsIncrement=false,HaveDefaultValue=false)]
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="DepartmentID", ColunmType="int", CanEmpty=true, Length=4, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public int? DepartmentID
		{
			set{ _departmentid=value;}
			get{return _departmentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="DistrictID", ColunmType="string", CanEmpty=true, Length=5, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string DistrictID
		{
			set{ _districtid=value;}
			get{return _districtid;}
		}
		#endregion Model

	}
}

