/**  版本信息模板在安装目录下，可自行修改。
* Flow.cs
*
* 功 能： N/A
* 类 名： Flow
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/6/30 16:50:28   N/A    初版
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
	/// 数据访问类:Flow
	/// </summary>
    public partial class Flow : BaseDA
	{
		public Flow()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Flow"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Flow");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(CardCenter.Entity.Flow model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Flow(");
			strSql.Append("JobType,FlowOrder,FlowStatus,IsSend,SendTxt)");
			strSql.Append(" values (");
			strSql.Append("@JobType,@FlowOrder,@FlowStatus,@IsSend,@SendTxt)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@JobType", SqlDbType.NVarChar,16),
					new SqlParameter("@FlowOrder", SqlDbType.Int,4),
					new SqlParameter("@FlowStatus", SqlDbType.Int,4),
					new SqlParameter("@IsSend", SqlDbType.Bit,1),
					new SqlParameter("@SendTxt", SqlDbType.NVarChar,1024)};
			parameters[0].Value = model.JobType;
			parameters[1].Value = model.FlowOrder;
			parameters[2].Value = model.FlowStatus;
			parameters[3].Value = model.IsSend;
			parameters[4].Value = model.SendTxt;

            TranHelper.AddTran(strSql, parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(CardCenter.Entity.Flow model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Flow set ");
			strSql.Append("JobType=@JobType,");
			strSql.Append("FlowOrder=@FlowOrder,");
			strSql.Append("FlowStatus=@FlowStatus,");
			strSql.Append("IsSend=@IsSend,");
			strSql.Append("SendTxt=@SendTxt");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@JobType", SqlDbType.NVarChar,16),
					new SqlParameter("@FlowOrder", SqlDbType.Int,4),
					new SqlParameter("@FlowStatus", SqlDbType.Int,4),
					new SqlParameter("@IsSend", SqlDbType.Bit,1),
					new SqlParameter("@SendTxt", SqlDbType.NVarChar,1024),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.JobType;
			parameters[1].Value = model.FlowOrder;
			parameters[2].Value = model.FlowStatus;
			parameters[3].Value = model.IsSend;
			parameters[4].Value = model.SendTxt;
			parameters[5].Value = model.ID;

            TranHelper.AddTran(strSql, parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Flow ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

            TranHelper.AddTran(strSql, parameters);
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Flow ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
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
		public CardCenter.Entity.Flow GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,JobType,FlowOrder,FlowStatus,IsSend,SendTxt from Flow ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			CardCenter.Entity.Flow model=new CardCenter.Entity.Flow();
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
		public CardCenter.Entity.Flow DataRowToModel(DataRow row)
		{
			CardCenter.Entity.Flow model=new CardCenter.Entity.Flow();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["JobType"]!=null)
				{
					model.JobType=row["JobType"].ToString();
				}
				if(row["FlowOrder"]!=null && row["FlowOrder"].ToString()!="")
				{
					model.FlowOrder=int.Parse(row["FlowOrder"].ToString());
				}
				if(row["FlowStatus"]!=null && row["FlowStatus"].ToString()!="")
				{
					model.FlowStatus=int.Parse(row["FlowStatus"].ToString());
				}
				if(row["IsSend"]!=null && row["IsSend"].ToString()!="")
				{
					if((row["IsSend"].ToString()=="1")||(row["IsSend"].ToString().ToLower()=="true"))
					{
						model.IsSend=true;
					}
					else
					{
						model.IsSend=false;
					}
				}
				if(row["SendTxt"]!=null)
				{
					model.SendTxt=row["SendTxt"].ToString();
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
			strSql.Append("select ID,JobType,FlowOrder,FlowStatus,IsSend,SendTxt ");
			strSql.Append(" FROM Flow ");
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
			strSql.Append(" ID,JobType,FlowOrder,FlowStatus,IsSend,SendTxt ");
			strSql.Append(" FROM Flow ");
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
			strSql.Append("select count(1) FROM Flow ");
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
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from Flow T ");
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
			parameters[0].Value = "Flow";
			parameters[1].Value = "ID";
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

