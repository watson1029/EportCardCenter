/**  版本信息模板在安装目录下，可自行修改。
* Para_Department.cs
*
* 功 能： N/A
* 类 名： Para_Department
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/13 9:24:57   N/A    初版
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
	/// Para_Department:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	[DBEntityProperty(TableName="Para_Department")]
	public partial class Para_Department
	{
		public Para_Department()
		{}
		#region Model
		private string _id;
		private string _city;
		private string _area;
		private string _gs;
		private string _zj;
		private string _sw;
		private string _hg;
		private string _wj;
		private string _wh;
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="ID", ColunmType="string", CanEmpty=false, Length=6, IsDataTableRow=true, IsPrimarykey=true, IsIncrement=false,HaveDefaultValue=false)]
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="City", ColunmType="string", CanEmpty=true, Length=64, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string City
		{
			set{ _city=value;}
			get{return _city;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="Area", ColunmType="string", CanEmpty=true, Length=64, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string Area
		{
			set{ _area=value;}
			get{return _area;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="GS", ColunmType="string", CanEmpty=true, Length=16, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string GS
		{
			set{ _gs=value;}
			get{return _gs;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="ZJ", ColunmType="string", CanEmpty=true, Length=16, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string ZJ
		{
			set{ _zj=value;}
			get{return _zj;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="SW", ColunmType="string", CanEmpty=true, Length=16, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string SW
		{
			set{ _sw=value;}
			get{return _sw;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="HG", ColunmType="string", CanEmpty=true, Length=16, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string HG
		{
			set{ _hg=value;}
			get{return _hg;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="WJ", ColunmType="string", CanEmpty=true, Length=16, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string WJ
		{
			set{ _wj=value;}
			get{return _wj;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="WH", ColunmType="string", CanEmpty=true, Length=16, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string WH
		{
			set{ _wh=value;}
			get{return _wh;}
		}
		#endregion Model

	}
}

