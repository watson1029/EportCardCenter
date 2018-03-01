/**  版本信息模板在安装目录下，可自行修改。
* StatusType.cs
*
* 功 能： N/A
* 类 名： StatusType
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/2/23 12:05:50   N/A    初版
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
	/// 数据访问类:StatusType
	/// </summary>
    public partial class StatusType : BaseDA
	{
		public StatusType()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("StatusID", "StatusType"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int StatusID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from StatusType");
			strSql.Append(" where StatusID=@StatusID");
			SqlParameter[] parameters = {
					new SqlParameter("@StatusID", SqlDbType.Int,4)
			};
			parameters[0].Value = StatusID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(CardCenter.Entity.StatusType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into StatusType(");
			strSql.Append("StatusName)");
			strSql.Append(" values (");
			strSql.Append("@StatusName)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@StatusName", SqlDbType.NVarChar,16)};
			parameters[0].Value = model.StatusName;

            TranHelper.AddTran(strSql, parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(CardCenter.Entity.StatusType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update StatusType set ");
			strSql.Append("StatusName=@StatusName");
			strSql.Append(" where StatusID=@StatusID");
			SqlParameter[] parameters = {
					new SqlParameter("@StatusName", SqlDbType.NVarChar,16),
					new SqlParameter("@StatusID", SqlDbType.Int,4)};
			parameters[0].Value = model.StatusName;
			parameters[1].Value = model.StatusID;

            TranHelper.AddTran(strSql, parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int StatusID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StatusType ");
			strSql.Append(" where StatusID=@StatusID");
			SqlParameter[] parameters = {
					new SqlParameter("@StatusID", SqlDbType.Int,4)
			};
			parameters[0].Value = StatusID;

            TranHelper.AddTran(strSql, parameters);
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string StatusIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StatusType ");
			strSql.Append(" where StatusID in ("+StatusIDlist + ")  ");
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
		public CardCenter.Entity.StatusType GetModel(int StatusID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 StatusID,StatusName from StatusType ");
			strSql.Append(" where StatusID=@StatusID");
			SqlParameter[] parameters = {
					new SqlParameter("@StatusID", SqlDbType.Int,4)
			};
			parameters[0].Value = StatusID;

			CardCenter.Entity.StatusType model=new CardCenter.Entity.StatusType();
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
		public CardCenter.Entity.StatusType DataRowToModel(DataRow row)
		{
			CardCenter.Entity.StatusType model=new CardCenter.Entity.StatusType();
			if (row != null)
			{
				if(row["StatusID"]!=null && row["StatusID"].ToString()!="")
				{
					model.StatusID=int.Parse(row["StatusID"].ToString());
				}
				if(row["StatusName"]!=null)
				{
					model.StatusName=row["StatusName"].ToString();
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
			strSql.Append("select StatusID,StatusName ");
			strSql.Append(" FROM StatusType ");
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
			strSql.Append(" StatusID,StatusName ");
			strSql.Append(" FROM StatusType ");
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
			strSql.Append("select count(1) FROM StatusType ");
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
				strSql.Append("order by T.StatusID desc");
			}
			strSql.Append(")AS Row, T.*  from StatusType T ");
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
			parameters[0].Value = "StatusType";
			parameters[1].Value = "StatusID";
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

