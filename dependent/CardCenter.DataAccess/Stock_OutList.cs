/**  版本信息模板在安装目录下，可自行修改。
* Stock_OutList.cs
*
* 功 能： N/A
* 类 名： Stock_OutList
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/8 10:25:20   N/A    初版
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
	/// 数据访问类:Stock_OutList
	/// </summary>
	public partial class Stock_OutList : BaseDA
	{
		public Stock_OutList()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Guid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Stock_OutList");
			strSql.Append(" where Guid=@Guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,64)			};
			parameters[0].Value = Guid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(CardCenter.Entity.Stock_OutList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Stock_OutList(");
			strSql.Append("Guid,CommodityGuid,JobID,Before,After,Num,SubmitUser,SubmitTime,Remark)");
			strSql.Append(" values (");
			strSql.Append("@Guid,@CommodityGuid,@JobID,@Before,@After,@Num,@SubmitUser,@SubmitTime,@Remark)");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,64),
					new SqlParameter("@CommodityGuid", SqlDbType.NVarChar,64),
					new SqlParameter("@JobID", SqlDbType.NVarChar,64),
					new SqlParameter("@Before", SqlDbType.Int,4),
					new SqlParameter("@After", SqlDbType.Int,4),
					new SqlParameter("@Num", SqlDbType.Int,4),
					new SqlParameter("@SubmitUser", SqlDbType.NVarChar,64),
					new SqlParameter("@SubmitTime", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.NVarChar,512)};
			parameters[0].Value = model.Guid;
			parameters[1].Value = model.CommodityGuid;
			parameters[2].Value = model.JobID;
			parameters[3].Value = model.Before;
			parameters[4].Value = model.After;
			parameters[5].Value = model.Num;
			parameters[6].Value = model.SubmitUser;
			parameters[7].Value = model.SubmitTime;
			parameters[8].Value = model.Remark;

            TranHelper.AddTran(strSql, parameters);
        }
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(CardCenter.Entity.Stock_OutList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Stock_OutList set ");
			strSql.Append("CommodityGuid=@CommodityGuid,");
			strSql.Append("JobID=@JobID,");
			strSql.Append("Before=@Before,");
			strSql.Append("After=@After,");
			strSql.Append("Num=@Num,");
			strSql.Append("SubmitUser=@SubmitUser,");
			strSql.Append("SubmitTime=@SubmitTime,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where Guid=@Guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@CommodityGuid", SqlDbType.NVarChar,64),
					new SqlParameter("@JobID", SqlDbType.NVarChar,64),
					new SqlParameter("@Before", SqlDbType.Int,4),
					new SqlParameter("@After", SqlDbType.Int,4),
					new SqlParameter("@Num", SqlDbType.Int,4),
					new SqlParameter("@SubmitUser", SqlDbType.NVarChar,64),
					new SqlParameter("@SubmitTime", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.NVarChar,512),
					new SqlParameter("@Guid", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.CommodityGuid;
			parameters[1].Value = model.JobID;
			parameters[2].Value = model.Before;
			parameters[3].Value = model.After;
			parameters[4].Value = model.Num;
			parameters[5].Value = model.SubmitUser;
			parameters[6].Value = model.SubmitTime;
			parameters[7].Value = model.Remark;
			parameters[8].Value = model.Guid;

            TranHelper.AddTran(strSql, parameters);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string Guid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Stock_OutList ");
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
			strSql.Append("delete from Stock_OutList ");
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
		public CardCenter.Entity.Stock_OutList GetEntity(string Guid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Guid,CommodityGuid,JobID,Before,After,Num,SubmitUser,SubmitTime,Remark from Stock_OutList ");
			strSql.Append(" where Guid=@Guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,64)			};
			parameters[0].Value = Guid;

			CardCenter.Entity.Stock_OutList model=new CardCenter.Entity.Stock_OutList();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToEntity(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CardCenter.Entity.Stock_OutList DataRowToEntity(DataRow row)
		{
			CardCenter.Entity.Stock_OutList model=new CardCenter.Entity.Stock_OutList();
			if (row != null)
			{
				if(row["Guid"]!=null)
				{
					model.Guid=row["Guid"].ToString();
				}
				if(row["CommodityGuid"]!=null)
				{
					model.CommodityGuid=row["CommodityGuid"].ToString();
				}
				if(row["JobID"]!=null)
				{
					model.JobID=row["JobID"].ToString();
				}
				if(row["Before"]!=null && row["Before"].ToString()!="")
				{
					model.Before=int.Parse(row["Before"].ToString());
				}
				if(row["After"]!=null && row["After"].ToString()!="")
				{
					model.After=int.Parse(row["After"].ToString());
				}
				if(row["Num"]!=null && row["Num"].ToString()!="")
				{
					model.Num=int.Parse(row["Num"].ToString());
				}
				if(row["SubmitUser"]!=null)
				{
					model.SubmitUser=row["SubmitUser"].ToString();
				}
				if(row["SubmitTime"]!=null && row["SubmitTime"].ToString()!="")
				{
					model.SubmitTime=DateTime.Parse(row["SubmitTime"].ToString());
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
			strSql.Append("select Guid,CommodityGuid,JobID,Before,After,Num,SubmitUser,SubmitTime,Remark ");
			strSql.Append(" FROM Stock_OutList ");
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
			strSql.Append(" Guid,CommodityGuid,JobID,Before,After,Num,SubmitUser,SubmitTime,Remark ");
			strSql.Append(" FROM Stock_OutList ");
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
			strSql.Append("select count(1) FROM Stock_OutList ");
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
			strSql.Append(")AS Row, T.*  from Stock_OutList T ");
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
			parameters[0].Value = "Stock_OutList";
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

