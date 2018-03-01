/**  版本信息模板在安装目录下，可自行修改。
* NoticeList.cs
*
* 功 能： N/A
* 类 名： NoticeList
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/8/15 15:02:47   N/A    初版
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
using ZWL;
namespace CardCenter.DataAccess
{
	/// <summary>
	/// 数据访问类:NoticeList
	/// </summary>
	public partial class NoticeList : BaseDA
	{
		public NoticeList()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Guid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from NoticeList");
			strSql.Append(" where Guid=@Guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,64)			};
			parameters[0].Value = Guid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(CardCenter.Entity.NoticeList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into NoticeList(");
			strSql.Append("Guid,FileName,FileExtension,FileSize,NoticeType,SavePath,CreateTime,CreateUser,IsDelete)");
			strSql.Append(" values (");
			strSql.Append("@Guid,@FileName,@FileExtension,@FileSize,@NoticeType,@SavePath,@CreateTime,@CreateUser,@IsDelete)");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,64),
					new SqlParameter("@FileName", SqlDbType.NVarChar,64),
					new SqlParameter("@FileExtension", SqlDbType.NVarChar,16),
					new SqlParameter("@FileSize", SqlDbType.Int,4),
					new SqlParameter("@NoticeType", SqlDbType.Int,4),
					new SqlParameter("@SavePath", SqlDbType.NVarChar,256),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@CreateUser", SqlDbType.NVarChar,64),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1)};
			parameters[0].Value = model.Guid;
			parameters[1].Value = model.FileName;
			parameters[2].Value = model.FileExtension;
			parameters[3].Value = model.FileSize;
			parameters[4].Value = model.NoticeType;
			parameters[5].Value = model.SavePath;
			parameters[6].Value = model.CreateTime;
			parameters[7].Value = model.CreateUser;
			parameters[8].Value = model.IsDelete;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(CardCenter.Entity.NoticeList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update NoticeList set ");
			strSql.Append("FileName=@FileName,");
			strSql.Append("FileExtension=@FileExtension,");
			strSql.Append("FileSize=@FileSize,");
			strSql.Append("NoticeType=@NoticeType,");
			strSql.Append("SavePath=@SavePath,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("CreateUser=@CreateUser,");
			strSql.Append("IsDelete=@IsDelete");
			strSql.Append(" where Guid=@Guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@FileName", SqlDbType.NVarChar,64),
					new SqlParameter("@FileExtension", SqlDbType.NVarChar,16),
					new SqlParameter("@FileSize", SqlDbType.Int,4),
					new SqlParameter("@NoticeType", SqlDbType.Int,4),
					new SqlParameter("@SavePath", SqlDbType.NVarChar,256),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@CreateUser", SqlDbType.NVarChar,64),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@Guid", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.FileName;
			parameters[1].Value = model.FileExtension;
			parameters[2].Value = model.FileSize;
			parameters[3].Value = model.NoticeType;
			parameters[4].Value = model.SavePath;
			parameters[5].Value = model.CreateTime;
			parameters[6].Value = model.CreateUser;
			parameters[7].Value = model.IsDelete;
			parameters[8].Value = model.Guid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(string Guid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from NoticeList ");
			strSql.Append(" where Guid=@Guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,64)			};
			parameters[0].Value = Guid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Guidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from NoticeList ");
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
		public CardCenter.Entity.NoticeList GetModel(string Guid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Guid,FileName,FileExtension,FileSize,NoticeType,SavePath,CreateTime,CreateUser,IsDelete from NoticeList ");
			strSql.Append(" where Guid=@Guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,64)			};
			parameters[0].Value = Guid;

			CardCenter.Entity.NoticeList model=new CardCenter.Entity.NoticeList();
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
		public CardCenter.Entity.NoticeList DataRowToModel(DataRow row)
		{
			CardCenter.Entity.NoticeList model=new CardCenter.Entity.NoticeList();
			if (row != null)
			{
				if(row["Guid"]!=null)
				{
					model.Guid=row["Guid"].ToString();
				}
				if(row["FileName"]!=null)
				{
					model.FileName=row["FileName"].ToString();
				}
				if(row["FileExtension"]!=null)
				{
					model.FileExtension=row["FileExtension"].ToString();
				}
				if(row["FileSize"]!=null && row["FileSize"].ToString()!="")
				{
					model.FileSize=int.Parse(row["FileSize"].ToString());
				}
				if(row["NoticeType"]!=null && row["NoticeType"].ToString()!="")
				{
					model.NoticeType=int.Parse(row["NoticeType"].ToString());
				}
				if(row["SavePath"]!=null)
				{
					model.SavePath=row["SavePath"].ToString();
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
				}
				if(row["CreateUser"]!=null)
				{
					model.CreateUser=row["CreateUser"].ToString();
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
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Guid,FileName,FileExtension,FileSize,NoticeType,SavePath,CreateTime,CreateUser,IsDelete ");
			strSql.Append(" FROM NoticeList ");
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
			strSql.Append(" Guid,FileName,FileExtension,FileSize,NoticeType,SavePath,CreateTime,CreateUser,IsDelete ");
			strSql.Append(" FROM NoticeList ");
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
			strSql.Append("select count(1) FROM NoticeList ");
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
			strSql.Append(")AS Row, T.*  from NoticeList T ");
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
			parameters[0].Value = "NoticeList";
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

		#endregion  ExtensionMethod
	}
}

