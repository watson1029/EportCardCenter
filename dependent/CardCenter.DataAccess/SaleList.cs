/**  版本信息模板在安装目录下，可自行修改。
* SaleList.cs
*
* 功 能： N/A
* 类 名： SaleList
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/8/25 15:53:58   N/A    初版
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
	/// 数据访问类:SaleList
	/// </summary>
	public partial class SaleList : BaseDA
	{
		public SaleList()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ListID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SaleList");
			strSql.Append(" where ListID=@ListID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ListID", SqlDbType.NVarChar,64)			};
			parameters[0].Value = ListID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(CardCenter.Entity.SaleList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SaleList(");
			strSql.Append("ListID,JobID,JobType,ProductType,Num,IsDelete,Remark,ManagerFlag,ManagerUser,ManagerTime)");
			strSql.Append(" values (");
			strSql.Append("@ListID,@JobID,@JobType,@ProductType,@Num,@IsDelete,@Remark,@ManagerFlag,@ManagerUser,@ManagerTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@ListID", SqlDbType.NVarChar,64),
					new SqlParameter("@JobID", SqlDbType.NVarChar,64),
					new SqlParameter("@JobType", SqlDbType.NVarChar,8),
					new SqlParameter("@ProductType", SqlDbType.NVarChar,64),
					new SqlParameter("@Num", SqlDbType.Int,4),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@Remark", SqlDbType.NVarChar,512),
					new SqlParameter("@ManagerFlag", SqlDbType.Int,4),
					new SqlParameter("@ManagerUser", SqlDbType.NVarChar,64),
					new SqlParameter("@ManagerTime", SqlDbType.DateTime)};
			parameters[0].Value = model.ListID;
			parameters[1].Value = model.JobID;
			parameters[2].Value = model.JobType;
			parameters[3].Value = model.ProductType;
			parameters[4].Value = model.Num;
			parameters[5].Value = model.IsDelete;
			parameters[6].Value = model.Remark;
			parameters[7].Value = model.ManagerFlag;
			parameters[8].Value = model.ManagerUser;
			parameters[9].Value = model.ManagerTime;

            TranHelper.AddTran(strSql, parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(CardCenter.Entity.SaleList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SaleList set ");
			strSql.Append("JobID=@JobID,");
			strSql.Append("JobType=@JobType,");
			strSql.Append("ProductType=@ProductType,");
			strSql.Append("Num=@Num,");
			strSql.Append("IsDelete=@IsDelete,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("ManagerFlag=@ManagerFlag,");
			strSql.Append("ManagerUser=@ManagerUser,");
			strSql.Append("ManagerTime=@ManagerTime");
			strSql.Append(" where ListID=@ListID ");
			SqlParameter[] parameters = {
					new SqlParameter("@JobID", SqlDbType.NVarChar,64),
					new SqlParameter("@JobType", SqlDbType.NVarChar,8),
					new SqlParameter("@ProductType", SqlDbType.NVarChar,64),
					new SqlParameter("@Num", SqlDbType.Int,4),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@Remark", SqlDbType.NVarChar,512),
					new SqlParameter("@ManagerFlag", SqlDbType.Int,4),
					new SqlParameter("@ManagerUser", SqlDbType.NVarChar,64),
					new SqlParameter("@ManagerTime", SqlDbType.DateTime),
					new SqlParameter("@ListID", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.JobID;
			parameters[1].Value = model.JobType;
			parameters[2].Value = model.ProductType;
			parameters[3].Value = model.Num;
			parameters[4].Value = model.IsDelete;
			parameters[5].Value = model.Remark;
			parameters[6].Value = model.ManagerFlag;
			parameters[7].Value = model.ManagerUser;
			parameters[8].Value = model.ManagerTime;
			parameters[9].Value = model.ListID;

            TranHelper.AddTran(strSql, parameters);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string ListID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SaleList ");
			strSql.Append(" where ListID=@ListID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ListID", SqlDbType.NVarChar,64)			};
			parameters[0].Value = ListID;

            TranHelper.AddTran(strSql, parameters);
        }
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string ListIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SaleList ");
			strSql.Append(" where ListID in ("+ListIDlist + ")  ");
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
		public CardCenter.Entity.SaleList GetModel(string ListID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ListID,JobID,JobType,ProductType,Num,IsDelete,Remark,ManagerFlag,ManagerUser,ManagerTime from SaleList ");
			strSql.Append(" where ListID=@ListID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ListID", SqlDbType.NVarChar,64)			};
			parameters[0].Value = ListID;

			CardCenter.Entity.SaleList model=new CardCenter.Entity.SaleList();
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
		public CardCenter.Entity.SaleList DataRowToModel(DataRow row)
		{
			CardCenter.Entity.SaleList model=new CardCenter.Entity.SaleList();
			if (row != null)
			{
				if(row["ListID"]!=null)
				{
					model.ListID=row["ListID"].ToString();
				}
				if(row["JobID"]!=null)
				{
					model.JobID=row["JobID"].ToString();
				}
				if(row["JobType"]!=null)
				{
					model.JobType=row["JobType"].ToString();
				}
				if(row["ProductType"]!=null)
				{
					model.ProductType=row["ProductType"].ToString();
				}
				if(row["Num"]!=null && row["Num"].ToString()!="")
				{
					model.Num=int.Parse(row["Num"].ToString());
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
				if(row["ManagerFlag"]!=null && row["ManagerFlag"].ToString()!="")
				{
					model.ManagerFlag=int.Parse(row["ManagerFlag"].ToString());
				}
				if(row["ManagerUser"]!=null)
				{
					model.ManagerUser=row["ManagerUser"].ToString();
				}
				if(row["ManagerTime"]!=null && row["ManagerTime"].ToString()!="")
				{
					model.ManagerTime=DateTime.Parse(row["ManagerTime"].ToString());
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
			strSql.Append("select ListID,JobID,JobType,ProductType,Num,IsDelete,Remark,ManagerFlag,ManagerUser,ManagerTime ");
			strSql.Append(" FROM SaleList ");
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
			strSql.Append(" ListID,JobID,JobType,ProductType,Num,IsDelete,Remark,ManagerFlag,ManagerUser,ManagerTime ");
			strSql.Append(" FROM SaleList ");
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
			strSql.Append("select count(1) FROM SaleList ");
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
				strSql.Append("order by T.ListID desc");
			}
			strSql.Append(")AS Row, T.*  from SaleList T ");
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
			parameters[0].Value = "SaleList";
			parameters[1].Value = "ListID";
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

