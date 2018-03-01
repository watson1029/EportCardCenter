/**  版本信息模板在安装目录下，可自行修改。
* Stock_Commodity.cs
*
* 功 能： N/A
* 类 名： Stock_Commodity
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/8 10:25:18   N/A    初版
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
using System.Collections.Generic;

namespace CardCenter.DataAccess
{
	/// <summary>
	/// 数据访问类:Stock_Commodity
	/// </summary>
	public partial class Stock_Commodity : BaseDA
	{
		public Stock_Commodity()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Guid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Stock_Commodity");
			strSql.Append(" where Guid=@Guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,64)			};
			parameters[0].Value = Guid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(CardCenter.Entity.Stock_Commodity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Stock_Commodity(");
			strSql.Append("Guid,CommodityName,CommodityType,AdditionalAttributes,SellingPrice,CostPrice,StockDesplay,StockActual)");
			strSql.Append(" values (");
			strSql.Append("@Guid,@CommodityName,@CommodityType,@AdditionalAttributes,@SellingPrice,@CostPrice,@StockDesplay,@StockActual)");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,64),
					new SqlParameter("@CommodityName", SqlDbType.NVarChar,128),
					new SqlParameter("@CommodityType", SqlDbType.NVarChar,128),
                    new SqlParameter("@AdditionalAttributes", SqlDbType.NVarChar,128),
					new SqlParameter("@SellingPrice", SqlDbType.Decimal,9),
					new SqlParameter("@CostPrice", SqlDbType.Decimal,9),
					new SqlParameter("@StockDesplay", SqlDbType.Int,4),
					new SqlParameter("@StockActual", SqlDbType.Int,4)};
			parameters[0].Value = model.Guid;
			parameters[1].Value = model.CommodityName;
			parameters[2].Value = model.CommodityType;
            parameters[3].Value = model.AdditionalAttributes;
            parameters[4].Value = model.SellingPrice;
			parameters[5].Value = model.CostPrice;
			parameters[6].Value = model.StockDesplay;
			parameters[7].Value = model.StockActual;

            TranHelper.AddTran(strSql, parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(CardCenter.Entity.Stock_Commodity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Stock_Commodity set ");
			strSql.Append("CommodityName=@CommodityName,");
			strSql.Append("CommodityType=@CommodityType,");
            strSql.Append("AdditionalAttributes=@AdditionalAttributes,");
			strSql.Append("SellingPrice=@SellingPrice,");
			strSql.Append("CostPrice=@CostPrice,");
			strSql.Append("StockDesplay=@StockDesplay,");
			strSql.Append("StockActual=@StockActual");
			strSql.Append(" where Guid=@Guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@CommodityName", SqlDbType.NVarChar,128),
					new SqlParameter("@CommodityType", SqlDbType.NVarChar,128),
                    new SqlParameter("@AdditionalAttributes", SqlDbType.NVarChar,128),
					new SqlParameter("@SellingPrice", SqlDbType.Decimal,9),
					new SqlParameter("@CostPrice", SqlDbType.Decimal,9),
					new SqlParameter("@StockDesplay", SqlDbType.Int,4),
					new SqlParameter("@StockActual", SqlDbType.Int,4),
					new SqlParameter("@Guid", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.CommodityName;
			parameters[1].Value = model.CommodityType;
            parameters[2].Value = model.AdditionalAttributes;
            parameters[3].Value = model.SellingPrice;
			parameters[4].Value = model.CostPrice;
			parameters[5].Value = model.StockDesplay;
			parameters[6].Value = model.StockActual;
			parameters[7].Value = model.Guid;

            TranHelper.AddTran(strSql, parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateEx(CardCenter.Entity.Stock_Commodity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Stock_Commodity set ");
            strSql.Append("CommodityName=@CommodityName,");
            strSql.Append("CommodityType=@CommodityType,");
            strSql.Append("AdditionalAttributes=@AdditionalAttributes,");
            strSql.Append("SellingPrice=@SellingPrice,");
            strSql.Append("CostPrice=@CostPrice,");
            strSql.Append("StockDesplay=@StockDesplay,");
            strSql.Append("StockActual=@StockActual");
            strSql.Append(" where Guid=@Guid ");
            SqlParameter[] parameters = {
                    new SqlParameter("@CommodityName", SqlDbType.NVarChar,128),
                    new SqlParameter("@CommodityType", SqlDbType.NVarChar,128),
                    new SqlParameter("@AdditionalAttributes", SqlDbType.NVarChar,128),
                    new SqlParameter("@SellingPrice", SqlDbType.Decimal,9),
                    new SqlParameter("@CostPrice", SqlDbType.Decimal,9),
                    new SqlParameter("@StockDesplay", SqlDbType.Int,4),
                    new SqlParameter("@StockActual", SqlDbType.Int,4),
                    new SqlParameter("@Guid", SqlDbType.NVarChar,64)};
            parameters[0].Value = model.CommodityName;
            parameters[1].Value = model.CommodityType;
            parameters[2].Value = model.AdditionalAttributes;
            parameters[3].Value = model.SellingPrice;
            parameters[4].Value = model.CostPrice;
            parameters[5].Value = model.StockDesplay;
            parameters[6].Value = model.StockActual;
            parameters[7].Value = model.Guid;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public void Delete(string Guid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Stock_Commodity ");
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
			strSql.Append("delete from Stock_Commodity ");
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
		public CardCenter.Entity.Stock_Commodity GetEntity(string Guid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Guid,CommodityName,CommodityType,AdditionalAttributes,SellingPrice,CostPrice,StockDesplay,StockActual from Stock_Commodity ");
			strSql.Append(" where Guid=@Guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@Guid", SqlDbType.NVarChar,64)			};
			parameters[0].Value = Guid;

			CardCenter.Entity.Stock_Commodity model=new CardCenter.Entity.Stock_Commodity();
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
		public CardCenter.Entity.Stock_Commodity DataRowToEntity(DataRow row)
		{
			CardCenter.Entity.Stock_Commodity model=new CardCenter.Entity.Stock_Commodity();
			if (row != null)
			{
				if(row["Guid"]!=null)
				{
					model.Guid=row["Guid"].ToString();
				}
				if(row["CommodityName"]!=null)
				{
					model.CommodityName=row["CommodityName"].ToString();
				}
				if(row["CommodityType"]!=null)
				{
					model.CommodityType=row["CommodityType"].ToString();
				}
                if (row["AdditionalAttributes"] != null)
                {
                    model.AdditionalAttributes = row["AdditionalAttributes"].ToString();
                }
				if(row["SellingPrice"]!=null && row["SellingPrice"].ToString()!="")
				{
					model.SellingPrice=decimal.Parse(row["SellingPrice"].ToString());
				}
				if(row["CostPrice"]!=null && row["CostPrice"].ToString()!="")
				{
					model.CostPrice=decimal.Parse(row["CostPrice"].ToString());
				}
				if(row["StockDesplay"]!=null && row["StockDesplay"].ToString()!="")
				{
					model.StockDesplay=int.Parse(row["StockDesplay"].ToString());
				}
				if(row["StockActual"]!=null && row["StockActual"].ToString()!="")
				{
					model.StockActual=int.Parse(row["StockActual"].ToString());
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
			strSql.Append("select Guid,CommodityName,CommodityType,AdditionalAttributes,SellingPrice,CostPrice,StockDesplay,StockActual ");
			strSql.Append(" FROM Stock_Commodity ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            strSql.Append(" order by CommodityName ");
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
			strSql.Append(" Guid,CommodityName,CommodityType,AdditionalAttributes,SellingPrice,CostPrice,StockDesplay,StockActual ");
			strSql.Append(" FROM Stock_Commodity ");
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
			strSql.Append("select count(1) FROM Stock_Commodity ");
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
			strSql.Append(")AS Row, T.*  from Stock_Commodity T ");
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
			parameters[0].Value = "Stock_Commodity";
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
        public List<string> GetCommodityType()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct CommodityType FROM Stock_Commodity order by CommodityType desc");
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            List<string> list = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(dr[0].ToString());
            }
            return list;
        }
        #endregion  ExtensionMethod
    }
}

