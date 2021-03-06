﻿/**  版本信息模板在安装目录下，可自行修改。
* FileList.cs
*
* 功 能： N/A
* 类 名： FileList
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/2/23 12:05:47   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZWL;//Please add references
namespace CardCenter.DataAccess
{
	/// <summary>
	/// 数据访问类:FileList
	/// </summary>
	public partial class FileList : BaseDA
	{
		public FileList()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Guid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from FileList");
			strSql.Append(" where Guid=@Guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,64)			};
			parameters[0].Value = Guid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(CardCenter.Entity.FileList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into FileList(");
			strSql.Append("Guid,FileType,FileName,JobID,ListID,IsDelete,Remark)");
			strSql.Append(" values (");
			strSql.Append("@Guid,@FileType,@FileName,@JobID,@ListID,@IsDelete,@Remark)");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,64),
					new SqlParameter("@FileType", SqlDbType.NVarChar,8),
					new SqlParameter("@FileName", SqlDbType.NVarChar,128),
					new SqlParameter("@JobID", SqlDbType.NVarChar,64),
					new SqlParameter("@ListID", SqlDbType.NVarChar,64),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@Remark", SqlDbType.NVarChar,512)};
			parameters[0].Value = model.Guid;
			parameters[1].Value = model.FileType;
			parameters[2].Value = model.FileName;
			parameters[3].Value = model.JobID;
			parameters[4].Value = model.ListID;
			parameters[5].Value = model.IsDelete;
			parameters[6].Value = model.Remark;

            TranHelper.AddTran(strSql, parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(CardCenter.Entity.FileList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update FileList set ");
			strSql.Append("FileType=@FileType,");
			strSql.Append("FileName=@FileName,");
			strSql.Append("JobID=@JobID,");
			strSql.Append("ListID=@ListID,");
			strSql.Append("IsDelete=@IsDelete,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where Guid=@Guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@FileType", SqlDbType.NVarChar,8),
					new SqlParameter("@FileName", SqlDbType.NVarChar,128),
					new SqlParameter("@JobID", SqlDbType.NVarChar,64),
					new SqlParameter("@ListID", SqlDbType.NVarChar,64),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@Remark", SqlDbType.NVarChar,512),
					new SqlParameter("@Guid", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.FileType;
			parameters[1].Value = model.FileName;
			parameters[2].Value = model.JobID;
			parameters[3].Value = model.ListID;
			parameters[4].Value = model.IsDelete;
			parameters[5].Value = model.Remark;
			parameters[6].Value = model.Guid;

            TranHelper.AddTran(strSql, parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string Guid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from FileList ");
			strSql.Append(" where Guid=@Guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,64)			};
			parameters[0].Value = Guid;

            TranHelper.AddTran(strSql, parameters);
		}

		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Guidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from FileList ");
			strSql.Append(" where Guid in ("+Guidlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CardCenter.Entity.FileList GetModel(string Guid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Guid,FileType,FileName,JobID,ListID,IsDelete,Remark from FileList ");
			strSql.Append(" where Guid=@Guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,64)			};
			parameters[0].Value = Guid;

			CardCenter.Entity.FileList model=new CardCenter.Entity.FileList();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CardCenter.Entity.FileList DataRowToModel(DataRow row)
		{
			CardCenter.Entity.FileList model=new CardCenter.Entity.FileList();
			if (row != null)
			{
				if(row["Guid"]!=null)
				{
					model.Guid=row["Guid"].ToString();
				}
				if(row["FileType"]!=null)
				{
					model.FileType=row["FileType"].ToString();
				}
				if(row["FileName"]!=null)
				{
					model.FileName=row["FileName"].ToString();
				}
				if(row["JobID"]!=null)
				{
					model.JobID=row["JobID"].ToString();
				}
				if(row["ListID"]!=null)
				{
					model.ListID=row["ListID"].ToString();
				}
				if(row["IsDelete"]!=null && row["IsDelete"].ToString()!="")
				{
					if((row["IsDelete"].ToString()=="1")||(row["IsDelete"].ToString().ToLower()=="true"))
					{
						model.IsDelete=true;
					}
					else
					{
						model.IsDelete=false;
					}
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Guid,FileType,FileName,JobID,ListID,IsDelete,Remark ");
			strSql.Append(" FROM FileList ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Guid,FileType,FileName,JobID,ListID,IsDelete,Remark ");
			strSql.Append(" FROM FileList ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM FileList ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.Guid desc");
			}
			strSql.Append(")AS Row, T.*  from FileList T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "FileList";
			parameters[1].Value = "Guid";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod
        //public string GetInsertSql(Entity.FileList model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("insert into FileList(");
        //    strSql.Append("Guid,FileType,FileName,JobID,ListID,IsDelete,Remark)");
        //    strSql.Append(" values (");
        //    strSql.AppendFormat("'{0}','{1}','{2}','{3}','{4}',{5},'{6}');"
        //        , model.Guid
        //        , model.FileType
        //        , model.FileName
        //        , model.JobID
        //        , model.ListID
        //        , Convert.ToInt32(model.IsDelete)
        //        , model.Remark);
        //    return strSql.ToString();
        //}

        //public string GetUpdateSql(Entity.FileList model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.AppendFormat("update FileList set Guid='{0}',FileName='{1}',IsDelete={2},Remark='{3}' where FileType='{4}' and JobID='{5}' and ListID='{6}';"
        //        , model.Guid
        //        , model.FileName
        //        , Convert.ToInt32(model.IsDelete)
        //        , model.Remark
        //        , model.FileType
        //        , model.JobID
        //        , model.ListID);
        //    return strSql.ToString();
        //}
		#endregion  ExtensionMethod
	}
}

