/**  版本信息模板在安装目录下，可自行修改。
* JobBar.cs
*
* 功 能： N/A
* 类 名： JobBar
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/4 10:46:40   N/A    初版
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
	/// 数据访问类:JobBar
	/// </summary>
	public partial class JobBar : BaseDA
	{
		public JobBar()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Guid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from JobBar");
			strSql.Append(" where Guid=@Guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,64)			};
			parameters[0].Value = Guid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(CardCenter.Entity.JobBar model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into JobBar(");
			strSql.Append("Guid,JobID,BarCode,IsDelete)");
			strSql.Append(" values (");
			strSql.Append("@Guid,@JobID,@BarCode,@IsDelete)");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,64),
					new SqlParameter("@JobID", SqlDbType.NVarChar,64),
					new SqlParameter("@BarCode", SqlDbType.NVarChar,64),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1)};
			parameters[0].Value = model.Guid;
			parameters[1].Value = model.JobID;
			parameters[2].Value = model.BarCode;
			parameters[3].Value = model.IsDelete;

            TranHelper.AddTran(strSql, parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(CardCenter.Entity.JobBar model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update JobBar set ");
			strSql.Append("JobID=@JobID,");
			strSql.Append("BarCode=@BarCode,");
			strSql.Append("IsDelete=@IsDelete");
			strSql.Append(" where Guid=@Guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@JobID", SqlDbType.NVarChar,64),
					new SqlParameter("@BarCode", SqlDbType.NVarChar,64),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@Guid", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.JobID;
			parameters[1].Value = model.BarCode;
			parameters[2].Value = model.IsDelete;
			parameters[3].Value = model.Guid;

            TranHelper.AddTran(strSql, parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string Guid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from JobBar ");
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
			strSql.Append("delete from JobBar ");
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
		public CardCenter.Entity.JobBar GetModel(string Guid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Guid,JobID,BarCode,IsDelete from JobBar ");
			strSql.Append(" where Guid=@Guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,64)			};
			parameters[0].Value = Guid;

			CardCenter.Entity.JobBar model=new CardCenter.Entity.JobBar();
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
		public CardCenter.Entity.JobBar DataRowToModel(DataRow row)
		{
			CardCenter.Entity.JobBar model=new CardCenter.Entity.JobBar();
			if (row != null)
			{
				if(row["Guid"]!=null)
				{
					model.Guid=row["Guid"].ToString();
				}
				if(row["JobID"]!=null)
				{
					model.JobID=row["JobID"].ToString();
				}
				if(row["BarCode"]!=null)
				{
					model.BarCode=row["BarCode"].ToString();
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
			strSql.Append("select Guid,JobID,BarCode,IsDelete ");
			strSql.Append(" FROM JobBar ");
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
			strSql.Append(" Guid,JobID,BarCode,IsDelete ");
			strSql.Append(" FROM JobBar ");
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
			strSql.Append("select count(1) FROM JobBar ");
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
			strSql.Append(")AS Row, T.*  from JobBar T ");
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
			parameters[0].Value = "JobBar";
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
        /// <summary>
        /// 判断是否已绑定
        /// </summary>
        /// <param name="barCode"></param>
        /// <returns></returns>
        public bool IsBind(string barCode)
        {
            JobBar da = new JobBar();
            DataTable dt = da.GetList("IsDelete=0 and BarCode='" + barCode + "'").Tables[0];
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 绑定条形码
        /// </summary>
        /// <param name="barCode">条形码</param>
        /// <param name="jobID">工单号</param>
        /// <returns></returns>
        public void BindFile(string barCode, string jobID)
        {
            try
            {
                JobBar da = new JobBar();
                DataTable dt = da.GetList("IsDelete=0 and JobID='" + jobID + "'").Tables[0];
                Entity.JobBar bar = new Entity.JobBar();
                if (dt.Rows.Count > 0)
                {
                    bar = da.DataRowToModel(dt.Rows[0]);
                    bar.BarCode = barCode;
                    da.Update(bar);
                }
                else
                {
                    bar.Guid = Guid.NewGuid().ToString();
                    bar.BarCode = barCode;
                    bar.JobID = jobID;
                    bar.IsDelete = false;
                    da.Add(bar);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 解绑条形码
        /// </summary>
        /// <param name="jobID">工单号</param>
        /// <returns></returns>
        public void DisBindFile(string jobID)
        {
            try
            {
                JobBar da = new JobBar();
                DataTable dt = da.GetList("IsDelete=0 and jobID='" + jobID + "'").Tables[0];
                Entity.JobBar bar = new Entity.JobBar();
                if (dt.Rows.Count > 0)
                {
                    bar = da.DataRowToModel(dt.Rows[0]);
                    bar.IsDelete = true;
                    da.Update(bar);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
		#endregion  ExtensionMethod
	}
}

