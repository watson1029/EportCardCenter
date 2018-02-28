/**  版本信息模板在安装目录下，可自行修改。
* HandleList.cs
*
* 功 能： N/A
* 类 名： HandleList
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/7 16:40:04   N/A    初版
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
	/// HandleList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	[DBEntityProperty(TableName="HandleList")]
	public partial class HandleList
	{
		public HandleList()
		{}
		#region Model
		private string _guid;
		private string _jobid;
		private int? _no;
		private string _functionid;
		private int? _opeartionid;
		private bool _ischecked;
		private string _status;
		private string _opeartionuser;
		private DateTime? _opeartiontime;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="Guid", ColunmType="string", CanEmpty=false, Length=64, IsDataTableRow=true, IsPrimarykey=true, IsIncrement=false,HaveDefaultValue=false)]
		public string Guid
		{
			set{ _guid=value;}
			get{return _guid;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="JobID", ColunmType="string", CanEmpty=true, Length=64, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string JobID
		{
			set{ _jobid=value;}
			get{return _jobid;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="No", ColunmType="int", CanEmpty=true, Length=4, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public int? No
		{
			set{ _no=value;}
			get{return _no;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="FunctionID", ColunmType="string", CanEmpty=true, Length=8, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string FunctionID
		{
			set{ _functionid=value;}
			get{return _functionid;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="OpeartionID", ColunmType="int", CanEmpty=true, Length=4, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public int? OpeartionID
		{
			set{ _opeartionid=value;}
			get{return _opeartionid;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="IsChecked", ColunmType="bool", CanEmpty=true, Length=1, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public bool IsChecked
		{
			set{ _ischecked=value;}
			get{return _ischecked;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="Status", ColunmType="string", CanEmpty=true, Length=32, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="OpeartionUser", ColunmType="string", CanEmpty=true, Length=64, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string OpeartionUser
		{
			set{ _opeartionuser=value;}
			get{return _opeartionuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="OpeartionTime", ColunmType="DateTime", CanEmpty=true, Length=8, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public DateTime? OpeartionTime
		{
			set{ _opeartiontime=value;}
			get{return _opeartiontime;}
		}
		/// <summary>
		/// 
		/// </summary>
		[DBRowEntityProperty(ColunmName="Remark", ColunmType="string", CanEmpty=true, Length=512, IsDataTableRow=true, IsPrimarykey=false, IsIncrement=false,HaveDefaultValue=false)]
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

