/**  版本信息模板在安装目录下，可自行修改。
* Para_FileType.cs
*
* 功 能： N/A
* 类 名： Para_FileType
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/2/23 12:05:49   N/A    初版
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
	/// 数据访问类:Para_FileType
	/// </summary>
    public partial class Para_FileType : BaseDA
	{
		public Para_FileType()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string FileTypeID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Para_FileType");
			strSql.Append(" where FileTypeID=@FileTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@FileTypeID", SqlDbType.NVarChar,8)			};
			parameters[0].Value = FileTypeID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(CardCenter.Entity.Para_FileType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Para_FileType(");
			strSql.Append("FileTypeID,FileTypeName)");
			strSql.Append(" values (");
			strSql.Append("@FileTypeID,@FileTypeName)");
			SqlParameter[] parameters = {
					new SqlParameter("@FileTypeID", SqlDbType.NVarChar,8),
					new SqlParameter("@FileTypeName", SqlDbType.NVarChar,128)};
			parameters[0].Value = model.FileTypeID;
			parameters[1].Value = model.FileTypeName;

            TranHelper.AddTran(strSql, parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(CardCenter.Entity.Para_FileType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Para_FileType set ");
			strSql.Append("FileTypeName=@FileTypeName");
			strSql.Append(" where FileTypeID=@FileTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@FileTypeName", SqlDbType.NVarChar,128),
					new SqlParameter("@FileTypeID", SqlDbType.NVarChar,8)};
			parameters[0].Value = model.FileTypeName;
			parameters[1].Value = model.FileTypeID;

            TranHelper.AddTran(strSql, parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string FileTypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Para_FileType ");
			strSql.Append(" where FileTypeID=@FileTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@FileTypeID", SqlDbType.NVarChar,8)			};
			parameters[0].Value = FileTypeID;

            TranHelper.AddTran(strSql, parameters);
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string FileTypeIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Para_FileType ");
			strSql.Append(" where FileTypeID in ("+FileTypeIDlist + ")  ");
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
		public CardCenter.Entity.Para_FileType GetModel(string FileTypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FileTypeID,FileTypeName from Para_FileType ");
			strSql.Append(" where FileTypeID=@FileTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@FileTypeID", SqlDbType.NVarChar,8)			};
			parameters[0].Value = FileTypeID;

			CardCenter.Entity.Para_FileType model=new CardCenter.Entity.Para_FileType();
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
		public CardCenter.Entity.Para_FileType DataRowToModel(DataRow row)
		{
			CardCenter.Entity.Para_FileType model=new CardCenter.Entity.Para_FileType();
			if (row != null)
			{
				if(row["FileTypeID"]!=null)
				{
					model.FileTypeID=row["FileTypeID"].ToString();
				}
				if(row["FileTypeName"]!=null)
				{
					model.FileTypeName=row["FileTypeName"].ToString();
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
			strSql.Append("select FileTypeID,FileTypeName ");
			strSql.Append(" FROM Para_FileType ");
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
			strSql.Append(" FileTypeID,FileTypeName ");
			strSql.Append(" FROM Para_FileType ");
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
			strSql.Append("select count(1) FROM Para_FileType ");
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
				strSql.Append("order by T.FileTypeID desc");
			}
			strSql.Append(")AS Row, T.*  from Para_FileType T ");
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
			parameters[0].Value = "Para_FileType";
			parameters[1].Value = "FileTypeID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

