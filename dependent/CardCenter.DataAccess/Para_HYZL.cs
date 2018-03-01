/**  版本信息模板在安装目录下，可自行修改。
* Para_HYZL.cs
*
* 功 能： N/A
* 类 名： Para_HYZL
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/3/30 10:38:03   N/A    初版
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
	/// 数据访问类:Para_HYZL
	/// </summary>
    public partial class Para_HYZL : BaseDA
	{
		public Para_HYZL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string HYZL_Value)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Para_HYZL");
			strSql.Append(" where HYZL_Value=@HYZL_Value ");
			SqlParameter[] parameters = {
					new SqlParameter("@HYZL_Value", SqlDbType.NVarChar,4)			};
			parameters[0].Value = HYZL_Value;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(CardCenter.Entity.Para_HYZL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Para_HYZL(");
			strSql.Append("HYZL_Value,HYZL_Name)");
			strSql.Append(" values (");
			strSql.Append("@HYZL_Value,@HYZL_Name)");
			SqlParameter[] parameters = {
					new SqlParameter("@HYZL_Value", SqlDbType.NVarChar,4),
					new SqlParameter("@HYZL_Name", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.HYZL_Value;
			parameters[1].Value = model.HYZL_Name;

            TranHelper.AddTran(strSql, parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(CardCenter.Entity.Para_HYZL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Para_HYZL set ");
			strSql.Append("HYZL_Name=@HYZL_Name");
			strSql.Append(" where HYZL_Value=@HYZL_Value ");
			SqlParameter[] parameters = {
					new SqlParameter("@HYZL_Name", SqlDbType.NVarChar,64),
					new SqlParameter("@HYZL_Value", SqlDbType.NVarChar,4)};
			parameters[0].Value = model.HYZL_Name;
			parameters[1].Value = model.HYZL_Value;

            TranHelper.AddTran(strSql, parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string HYZL_Value)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Para_HYZL ");
			strSql.Append(" where HYZL_Value=@HYZL_Value ");
			SqlParameter[] parameters = {
					new SqlParameter("@HYZL_Value", SqlDbType.NVarChar,4)			};
			parameters[0].Value = HYZL_Value;

            TranHelper.AddTran(strSql, parameters);
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string HYZL_Valuelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Para_HYZL ");
			strSql.Append(" where HYZL_Value in ("+HYZL_Valuelist + ")  ");
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
		public CardCenter.Entity.Para_HYZL GetModel(string HYZL_Value)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 HYZL_Value,HYZL_Name from Para_HYZL ");
			strSql.Append(" where HYZL_Value=@HYZL_Value ");
			SqlParameter[] parameters = {
					new SqlParameter("@HYZL_Value", SqlDbType.NVarChar,4)			};
			parameters[0].Value = HYZL_Value;

			CardCenter.Entity.Para_HYZL model=new CardCenter.Entity.Para_HYZL();
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
		public CardCenter.Entity.Para_HYZL DataRowToModel(DataRow row)
		{
			CardCenter.Entity.Para_HYZL model=new CardCenter.Entity.Para_HYZL();
			if (row != null)
			{
				if(row["HYZL_Value"]!=null)
				{
					model.HYZL_Value=row["HYZL_Value"].ToString();
				}
				if(row["HYZL_Name"]!=null)
				{
					model.HYZL_Name=row["HYZL_Name"].ToString();
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
			strSql.Append("select HYZL_Value,HYZL_Name ");
			strSql.Append(" FROM Para_HYZL ");
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
			strSql.Append(" HYZL_Value,HYZL_Name ");
			strSql.Append(" FROM Para_HYZL ");
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
			strSql.Append("select count(1) FROM Para_HYZL ");
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
				strSql.Append("order by T.HYZL_Value desc");
			}
			strSql.Append(")AS Row, T.*  from Para_HYZL T ");
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
			parameters[0].Value = "Para_HYZL";
			parameters[1].Value = "HYZL_Value";
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

