/**  版本信息模板在安装目录下，可自行修改。
* JobInfo.cs
*
* 功 能： N/A
* 类 名： JobInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/2/23 12:05:48   N/A    初版
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
	/// 数据访问类:JobInfo
	/// </summary>
    public partial class JobInfo : BaseDA
	{
		public JobInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string JobID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from JobInfo");
			strSql.Append(" where JobID=@JobID ");
			SqlParameter[] parameters = {
					new SqlParameter("@JobID", SqlDbType.NVarChar,64)			};
			parameters[0].Value = JobID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(CardCenter.Entity.JobInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into JobInfo(");
            strSql.Append("JobID,JobType,CreateTime,CreateUser,IsDelete,EnterpriseName,EnterpriseAddress,EnterpriseCode,AgentName,AgentIdentificationType,AgentIdentificationNum,AgentPhone,ConsigneeName,ConsigneeAddress,ConsigneePhone,Remark,ExpressFlat,FeeFlat,CustomsCode,ApprovalFile,IsOnline,InvoiceName,InvoicePhone,InvoiceAddress,InvoicePostCode,InvoiceEmail,InvoiceCode,Fee)");
			strSql.Append(" values (");
            strSql.Append("@JobID,@JobType,@CreateTime,@CreateUser,@IsDelete,@EnterpriseName,@EnterpriseAddress,@EnterpriseCode,@AgentName,@AgentIdentificationType,@AgentIdentificationNum,@AgentPhone,@ConsigneeName,@ConsigneeAddress,@ConsigneePhone,@Remark,@ExpressFlat,@FeeFlat,@CustomsCode,@ApprovalFile,@IsOnline,@InvoiceName,@InvoicePhone,@InvoiceAddress,@InvoicePostCode,@InvoiceEmail,@InvoiceCode,@Fee)");
			SqlParameter[] parameters = {
					new SqlParameter("@JobID", SqlDbType.NVarChar,64),
					new SqlParameter("@JobType", SqlDbType.NVarChar,8),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@CreateUser", SqlDbType.NVarChar,64),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@EnterpriseName", SqlDbType.NVarChar,128),
					new SqlParameter("@EnterpriseAddress", SqlDbType.NVarChar,512),
					new SqlParameter("@EnterpriseCode", SqlDbType.NVarChar,18),
					new SqlParameter("@AgentName", SqlDbType.NVarChar,32),
					new SqlParameter("@AgentIdentificationType", SqlDbType.Int,4),
					new SqlParameter("@AgentIdentificationNum", SqlDbType.NVarChar,32),
					new SqlParameter("@AgentPhone", SqlDbType.NVarChar,16),
					new SqlParameter("@ConsigneeName", SqlDbType.NVarChar,32),
					new SqlParameter("@ConsigneeAddress", SqlDbType.NVarChar,512),
					new SqlParameter("@ConsigneePhone", SqlDbType.NVarChar,32),
					new SqlParameter("@Remark", SqlDbType.NVarChar,512),
                    new SqlParameter("@ExpressFlat", SqlDbType.Bit,1),
                    new SqlParameter("@FeeFlat", SqlDbType.NVarChar,32),
                    new SqlParameter("@CustomsCode", SqlDbType.NVarChar,10),
                    new SqlParameter("@ApprovalFile", SqlDbType.NVarChar,64),
                    new SqlParameter("@IsOnline", SqlDbType.Bit,1),
                    new SqlParameter("@InvoiceName", SqlDbType.NVarChar,32),
					new SqlParameter("@InvoicePhone", SqlDbType.NVarChar,32),
					new SqlParameter("@InvoiceAddress", SqlDbType.NVarChar,512),
                    new SqlParameter("@InvoicePostCode", SqlDbType.NVarChar,6),
                    new SqlParameter("@InvoiceEmail", SqlDbType.NVarChar,64),
                    new SqlParameter("@InvoiceCode", SqlDbType.NVarChar,18),
                    new SqlParameter("@Fee", SqlDbType.Float,8)};
			parameters[0].Value = model.JobID;
			parameters[1].Value = model.JobType;
			parameters[2].Value = model.CreateTime;
			parameters[3].Value = model.CreateUser;
			parameters[4].Value = model.IsDelete;
			parameters[5].Value = model.EnterpriseName;
			parameters[6].Value = model.EnterpriseAddress;
			parameters[7].Value = model.EnterpriseCode;
			parameters[8].Value = model.AgentName;
			parameters[9].Value = model.AgentIdentificationType;
			parameters[10].Value = model.AgentIdentificationNum;
			parameters[11].Value = model.AgentPhone;
			parameters[12].Value = model.ConsigneeName;
			parameters[13].Value = model.ConsigneeAddress;
			parameters[14].Value = model.ConsigneePhone;
			parameters[15].Value = model.Remark;
            parameters[16].Value = model.ExpressFlat;
            parameters[17].Value = model.FeeFlat;
            parameters[18].Value = model.CustomsCode;
            parameters[19].Value = model.ApprovalFile;
            parameters[20].Value = model.IsOnline;
            parameters[21].Value = model.InvoiceName;
            parameters[22].Value = model.InvoicePhone;
            parameters[23].Value = model.InvoiceAddress;
            parameters[24].Value = model.InvoicePostCode;
            parameters[25].Value = model.InvoiceEmail;
            parameters[26].Value = model.InvoiceCode;
            parameters[27].Value = model.Fee;

            TranHelper.AddTran(strSql, parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(CardCenter.Entity.JobInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update JobInfo set ");
			strSql.Append("JobType=@JobType,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("CreateUser=@CreateUser,");
			strSql.Append("IsDelete=@IsDelete,");
			strSql.Append("EnterpriseName=@EnterpriseName,");
			strSql.Append("EnterpriseAddress=@EnterpriseAddress,");
			strSql.Append("EnterpriseCode=@EnterpriseCode,");
			strSql.Append("AgentName=@AgentName,");
			strSql.Append("AgentIdentificationType=@AgentIdentificationType,");
			strSql.Append("AgentIdentificationNum=@AgentIdentificationNum,");
			strSql.Append("AgentPhone=@AgentPhone,");
			strSql.Append("ConsigneeName=@ConsigneeName,");
			strSql.Append("ConsigneeAddress=@ConsigneeAddress,");
			strSql.Append("ConsigneePhone=@ConsigneePhone,");
			strSql.Append("Remark=@Remark,");
            strSql.Append("ExpressFlat=@ExpressFlat,");
            strSql.Append("FeeFlat=@FeeFlat,");
            strSql.Append("CustomsCode=@CustomsCode,");
            strSql.Append("ApprovalFile=@ApprovalFile,");
            strSql.Append("IsOnline=@IsOnline,");
            strSql.Append("InvoiceName=@InvoiceName,");
            strSql.Append("InvoicePhone=@InvoicePhone,");
            strSql.Append("InvoiceAddress=@InvoiceAddress,");
            strSql.Append("InvoicePostCode=@InvoicePostCode,");
            strSql.Append("InvoiceEmail=@InvoiceEmail,");
            strSql.Append("InvoiceCode=@InvoiceCode,");
            strSql.Append("Fee=@Fee");
			strSql.Append(" where JobID=@JobID ");
			SqlParameter[] parameters = {
					new SqlParameter("@JobType", SqlDbType.NVarChar,8),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@CreateUser", SqlDbType.NVarChar,64),
					new SqlParameter("@IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@EnterpriseName", SqlDbType.NVarChar,128),
					new SqlParameter("@EnterpriseAddress", SqlDbType.NVarChar,512),
					new SqlParameter("@EnterpriseCode", SqlDbType.NVarChar,18),
					new SqlParameter("@AgentName", SqlDbType.NVarChar,32),
					new SqlParameter("@AgentIdentificationType", SqlDbType.Int,4),
					new SqlParameter("@AgentIdentificationNum", SqlDbType.NVarChar,32),
					new SqlParameter("@AgentPhone", SqlDbType.NVarChar,16),
					new SqlParameter("@ConsigneeName", SqlDbType.NVarChar,32),
					new SqlParameter("@ConsigneeAddress", SqlDbType.NVarChar,512),
					new SqlParameter("@ConsigneePhone", SqlDbType.NVarChar,32),
					new SqlParameter("@Remark", SqlDbType.NVarChar,512),
					new SqlParameter("@JobID", SqlDbType.NVarChar,64),
                    new SqlParameter("@ExpressFlat", SqlDbType.Bit,1),
                    new SqlParameter("@FeeFlat", SqlDbType.NVarChar,32),
                    new SqlParameter("@CustomsCode", SqlDbType.NVarChar,10),
                    new SqlParameter("@ApprovalFile", SqlDbType.NVarChar,64),
                    new SqlParameter("@IsOnline", SqlDbType.Bit,1),
                    new SqlParameter("@InvoiceName", SqlDbType.NVarChar,32),
					new SqlParameter("@InvoicePhone", SqlDbType.NVarChar,32),
					new SqlParameter("@InvoiceAddress", SqlDbType.NVarChar,512),
                    new SqlParameter("@InvoicePostCode", SqlDbType.NVarChar,6),
                    new SqlParameter("@InvoiceEmail", SqlDbType.NVarChar,64),
                    new SqlParameter("@InvoiceCode", SqlDbType.NVarChar,18),
                    new SqlParameter("@Fee", SqlDbType.Float,8)};
			parameters[0].Value = model.JobType;
			parameters[1].Value = model.CreateTime;
			parameters[2].Value = model.CreateUser;
			parameters[3].Value = model.IsDelete;
			parameters[4].Value = model.EnterpriseName;
			parameters[5].Value = model.EnterpriseAddress;
			parameters[6].Value = model.EnterpriseCode;
			parameters[7].Value = model.AgentName;
			parameters[8].Value = model.AgentIdentificationType;
			parameters[9].Value = model.AgentIdentificationNum;
			parameters[10].Value = model.AgentPhone;
			parameters[11].Value = model.ConsigneeName;
			parameters[12].Value = model.ConsigneeAddress;
			parameters[13].Value = model.ConsigneePhone;
			parameters[14].Value = model.Remark;
			parameters[15].Value = model.JobID;
            parameters[16].Value = model.ExpressFlat;
            parameters[17].Value = model.FeeFlat;
            parameters[18].Value = model.CustomsCode;
            parameters[19].Value = model.ApprovalFile;
            parameters[20].Value = model.IsOnline;
            parameters[21].Value = model.InvoiceName;
            parameters[22].Value = model.InvoicePhone;
            parameters[23].Value = model.InvoiceAddress;
            parameters[24].Value = model.InvoicePostCode;
            parameters[25].Value = model.InvoiceEmail;
            parameters[26].Value = model.InvoiceCode;
            parameters[27].Value = model.Fee;

            TranHelper.AddTran(strSql, parameters);
		}

        /// <summary>
		/// 更新一条数据
		/// </summary>
		public bool UpdateEx(CardCenter.Entity.JobInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update JobInfo set ");
            strSql.Append("JobType=@JobType,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("CreateUser=@CreateUser,");
            strSql.Append("IsDelete=@IsDelete,");
            strSql.Append("EnterpriseName=@EnterpriseName,");
            strSql.Append("EnterpriseAddress=@EnterpriseAddress,");
            strSql.Append("EnterpriseCode=@EnterpriseCode,");
            strSql.Append("AgentName=@AgentName,");
            strSql.Append("AgentIdentificationType=@AgentIdentificationType,");
            strSql.Append("AgentIdentificationNum=@AgentIdentificationNum,");
            strSql.Append("AgentPhone=@AgentPhone,");
            strSql.Append("ConsigneeName=@ConsigneeName,");
            strSql.Append("ConsigneeAddress=@ConsigneeAddress,");
            strSql.Append("ConsigneePhone=@ConsigneePhone,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("ExpressFlat=@ExpressFlat,");
            strSql.Append("FeeFlat=@FeeFlat,");
            strSql.Append("CustomsCode=@CustomsCode,");
            strSql.Append("ApprovalFile=@ApprovalFile,");
            strSql.Append("IsOnline=@IsOnline,");
            strSql.Append("InvoiceName=@InvoiceName,");
            strSql.Append("InvoicePhone=@InvoicePhone,");
            strSql.Append("InvoiceAddress=@InvoiceAddress,");
            strSql.Append("InvoicePostCode=@InvoicePostCode,");
            strSql.Append("InvoiceEmail=@InvoiceEmail,");
            strSql.Append("InvoiceCode=@InvoiceCode,");
            strSql.Append("Fee=@Fee");
            strSql.Append(" where JobID=@JobID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@JobType", SqlDbType.NVarChar,8),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreateUser", SqlDbType.NVarChar,64),
                    new SqlParameter("@IsDelete", SqlDbType.Bit,1),
                    new SqlParameter("@EnterpriseName", SqlDbType.NVarChar,128),
                    new SqlParameter("@EnterpriseAddress", SqlDbType.NVarChar,512),
                    new SqlParameter("@EnterpriseCode", SqlDbType.NVarChar,18),
                    new SqlParameter("@AgentName", SqlDbType.NVarChar,32),
                    new SqlParameter("@AgentIdentificationType", SqlDbType.Int,4),
                    new SqlParameter("@AgentIdentificationNum", SqlDbType.NVarChar,32),
                    new SqlParameter("@AgentPhone", SqlDbType.NVarChar,16),
                    new SqlParameter("@ConsigneeName", SqlDbType.NVarChar,32),
                    new SqlParameter("@ConsigneeAddress", SqlDbType.NVarChar,512),
                    new SqlParameter("@ConsigneePhone", SqlDbType.NVarChar,32),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,512),
                    new SqlParameter("@JobID", SqlDbType.NVarChar,64),
                    new SqlParameter("@ExpressFlat", SqlDbType.Bit,1),
                    new SqlParameter("@FeeFlat", SqlDbType.NVarChar,32),
                    new SqlParameter("@CustomsCode", SqlDbType.NVarChar,10),
                    new SqlParameter("@ApprovalFile", SqlDbType.NVarChar,64),
                    new SqlParameter("@IsOnline", SqlDbType.Bit,1),
                    new SqlParameter("@InvoiceName", SqlDbType.NVarChar,32),
                    new SqlParameter("@InvoicePhone", SqlDbType.NVarChar,32),
                    new SqlParameter("@InvoiceAddress", SqlDbType.NVarChar,512),
                    new SqlParameter("@InvoicePostCode", SqlDbType.NVarChar,6),
                    new SqlParameter("@InvoiceEmail", SqlDbType.NVarChar,64),
                    new SqlParameter("@InvoiceCode", SqlDbType.NVarChar,18),
                    new SqlParameter("@Fee", SqlDbType.Float,8)};
            parameters[0].Value = model.JobType;
            parameters[1].Value = model.CreateTime;
            parameters[2].Value = model.CreateUser;
            parameters[3].Value = model.IsDelete;
            parameters[4].Value = model.EnterpriseName;
            parameters[5].Value = model.EnterpriseAddress;
            parameters[6].Value = model.EnterpriseCode;
            parameters[7].Value = model.AgentName;
            parameters[8].Value = model.AgentIdentificationType;
            parameters[9].Value = model.AgentIdentificationNum;
            parameters[10].Value = model.AgentPhone;
            parameters[11].Value = model.ConsigneeName;
            parameters[12].Value = model.ConsigneeAddress;
            parameters[13].Value = model.ConsigneePhone;
            parameters[14].Value = model.Remark;
            parameters[15].Value = model.JobID;
            parameters[16].Value = model.ExpressFlat;
            parameters[17].Value = model.FeeFlat;
            parameters[18].Value = model.CustomsCode;
            parameters[19].Value = model.ApprovalFile;
            parameters[20].Value = model.IsOnline;
            parameters[21].Value = model.InvoiceName;
            parameters[22].Value = model.InvoicePhone;
            parameters[23].Value = model.InvoiceAddress;
            parameters[24].Value = model.InvoicePostCode;
            parameters[25].Value = model.InvoiceEmail;
            parameters[26].Value = model.InvoiceCode;
            parameters[27].Value = model.Fee;

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
        public void Delete(string JobID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from JobInfo ");
			strSql.Append(" where JobID=@JobID ");
			SqlParameter[] parameters = {
					new SqlParameter("@JobID", SqlDbType.NVarChar,64)			};
			parameters[0].Value = JobID;

            TranHelper.AddTran(strSql, parameters);
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string JobIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from JobInfo ");
			strSql.Append(" where JobID in ("+JobIDlist + ")  ");
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
		public CardCenter.Entity.JobInfo GetModel(string JobID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 JobID,JobType,CreateTime,CreateUser,IsDelete,EnterpriseName,EnterpriseAddress,EnterpriseCode,AgentName,AgentIdentificationType,AgentIdentificationNum,AgentPhone,ConsigneeName,ConsigneeAddress,ConsigneePhone,Remark,ExpressFlat,FeeFlat,CustomsCode,ApprovalFile,IsOnline,InvoiceName,InvoicePhone,InvoiceAddress,InvoicePostCode,InvoiceEmail,InvoiceCode,Fee from JobInfo ");
			strSql.Append(" where JobID=@JobID ");
			SqlParameter[] parameters = {
					new SqlParameter("@JobID", SqlDbType.NVarChar,64)			};
			parameters[0].Value = JobID;

			CardCenter.Entity.JobInfo model=new CardCenter.Entity.JobInfo();
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
		public CardCenter.Entity.JobInfo DataRowToModel(DataRow row)
		{
			CardCenter.Entity.JobInfo model=new CardCenter.Entity.JobInfo();
			if (row != null)
			{
				if(row["JobID"]!=null)
				{
					model.JobID=row["JobID"].ToString();
				}
				if(row["JobType"]!=null)
				{
					model.JobType=row["JobType"].ToString();
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
				if(row["EnterpriseName"]!=null)
				{
					model.EnterpriseName=row["EnterpriseName"].ToString();
				}
				if(row["EnterpriseAddress"]!=null)
				{
					model.EnterpriseAddress=row["EnterpriseAddress"].ToString();
				}
				if(row["EnterpriseCode"]!=null)
				{
					model.EnterpriseCode=row["EnterpriseCode"].ToString();
				}
				if(row["AgentName"]!=null)
				{
					model.AgentName=row["AgentName"].ToString();
				}
				if(row["AgentIdentificationType"]!=null && row["AgentIdentificationType"].ToString()!="")
				{
					model.AgentIdentificationType=int.Parse(row["AgentIdentificationType"].ToString());
				}
				if(row["AgentIdentificationNum"]!=null)
				{
					model.AgentIdentificationNum=row["AgentIdentificationNum"].ToString();
				}
				if(row["AgentPhone"]!=null)
				{
					model.AgentPhone=row["AgentPhone"].ToString();
				}
				if(row["ConsigneeName"]!=null)
				{
					model.ConsigneeName=row["ConsigneeName"].ToString();
				}
				if(row["ConsigneeAddress"]!=null)
				{
					model.ConsigneeAddress=row["ConsigneeAddress"].ToString();
				}
				if(row["ConsigneePhone"]!=null)
				{
					model.ConsigneePhone=row["ConsigneePhone"].ToString();
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
                if (row["ExpressFlat"] != null && row["ExpressFlat"].ToString() != "")
				{
                    if ((row["ExpressFlat"].ToString() == "1") || (row["ExpressFlat"].ToString().ToLower() == "true"))
					{
                        model.ExpressFlat = true;
					}
					else
					{
                        model.ExpressFlat = false;
					}
				}
                if (row["FeeFlat"] != null)
                {
                    model.FeeFlat = row["FeeFlat"].ToString();
                }
                if (row["CustomsCode"] != null)
                {
                    model.CustomsCode = row["CustomsCode"].ToString();
                }
                if (row["ApprovalFile"] != null)
                {
                    model.ApprovalFile = row["ApprovalFile"].ToString();
                }
                if (row["IsOnline"] != null && row["IsOnline"].ToString() != "")
                {
                    if ((row["IsOnline"].ToString() == "1") || (row["IsOnline"].ToString().ToLower() == "true"))
                    {
                        model.IsOnline = true;
                    }
                    else
                    {
                        model.IsOnline = false;
                    }
                }
                if (row["InvoiceName"] != null)
                {
                    model.InvoiceName = row["InvoiceName"].ToString();
                }
                if (row["InvoicePhone"] != null)
                {
                    model.InvoicePhone = row["InvoicePhone"].ToString();
                }
                if (row["InvoiceAddress"] != null)
                {
                    model.InvoiceAddress = row["InvoiceAddress"].ToString();
                }
                if (row["InvoicePostCode"] != null)
                {
                    model.InvoicePostCode = row["InvoicePostCode"].ToString();
                }
                if (row["InvoiceEmail"] != null)
                {
                    model.InvoiceEmail = row["InvoiceEmail"].ToString();
                }
                if (row["InvoiceCode"] != null)
                {
                    model.InvoiceCode = row["InvoiceCode"].ToString();
                }
                if (row["Fee"] != null && row["Fee"].ToString() != "")
                {
                    model.Fee = decimal.Parse(row["Fee"].ToString());
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
            strSql.Append("select JobID,JobType,CreateTime,CreateUser,IsDelete,EnterpriseName,EnterpriseAddress,EnterpriseCode,AgentName,AgentIdentificationType,AgentIdentificationNum,AgentPhone,ConsigneeName,ConsigneeAddress,ConsigneePhone,Remark,ExpressFlat,FeeFlat,CustomsCode,ApprovalFile,IsOnline,InvoiceName,InvoicePhone,InvoiceAddress,InvoicePostCode,InvoiceEmail,InvoiceCode,Fee ");
			strSql.Append(" FROM JobInfo ");
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
            strSql.Append(" JobID,JobType,CreateTime,CreateUser,IsDelete,EnterpriseName,EnterpriseAddress,EnterpriseCode,AgentName,AgentIdentificationType,AgentIdentificationNum,AgentPhone,ConsigneeName,ConsigneeAddress,ConsigneePhone,Remark,ExpressFlat,FeeFlat,CustomsCode,ApprovalFile,IsOnline,InvoiceName,InvoicePhone,InvoiceAddress,InvoicePostCode,InvoiceEmail,InvoiceCode,Fee ");
			strSql.Append(" FROM JobInfo ");
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
			strSql.Append("select count(1) FROM JobInfo ");
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
				strSql.Append("order by T.JobID desc");
			}
			strSql.Append(")AS Row, T.*  from JobInfo T ");
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
			parameters[0].Value = "JobInfo";
			parameters[1].Value = "JobID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod
        //public string GetInsertSql(CardCenter.Entity.JobInfo model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("insert into JobInfo(");
        //    strSql.Append("JobID,JobType,CreateTime,CreateUser,IsDelete,EnterpriseName,EnterpriseAddress,EnterpriseCode,AgentName,AgentIdentificationType,AgentIdentificationNum,AgentPhone,ConsigneeName,ConsigneeAddress,ConsigneePhone,Remark,ExpressFlat,FeeFlat,CustomsCode,ApprovalFile,IsOnline,InvoiceName,InvoicePhone,InvoiceAddress,Fee)");
        //    strSql.Append(" values (");
        //    strSql.AppendFormat("'{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}','{8}',{9},'{10}','{11}','{12}','{13}','{14}','{15}',{16},'{17}','{18}','{19}',{20},'{21}','{22}','{23}',{24})"
        //        , model.JobID
        //        , model.JobType
        //        , model.CreateTime
        //        , model.CreateUser
        //        , Convert.ToInt32(model.IsDelete)
        //        , model.EnterpriseName
        //        , model.EnterpriseAddress
        //        , model.EnterpriseCode
        //        , model.AgentName
        //        , model.AgentIdentificationType == null ? "null" : model.AgentIdentificationType.ToString()
        //        , model.AgentIdentificationNum
        //        , model.AgentPhone
        //        , model.ConsigneeName
        //        , model.ConsigneeAddress
        //        , model.ConsigneePhone
        //        , model.Remark
        //        , Convert.ToInt32(model.ExpressFlat)
        //        , model.FeeFlat
        //        , model.CustomsCode
        //        , model.ApprovalFile
        //        , Convert.ToInt32(model.IsOnline)
        //        , model.InvoiceName
        //        , model.InvoicePhone
        //        , model.InvoiceAddress
        //        , model.Fee);
        //    return strSql.ToString();
        //}

        //public string GetUpdateSql(CardCenter.Entity.JobInfo model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("update JobInfo set ");
        //    strSql.AppendFormat("JobType='{0}',CreateTime='{1}',CreateUser='{2}',IsDelete={3},EnterpriseName='{4}',EnterpriseAddress='{5}',EnterpriseCode='{6}',AgentName='{7}',AgentIdentificationType={8},AgentIdentificationNum='{9}',AgentPhone='{10}',ConsigneeName='{11}',ConsigneeAddress='{12}',ConsigneePhone='{13}',Remark='{14}',ExpressFlat={15},FeeFlat='{16}',CustomsCode='{17}',ApprovalFile='{18}',IsOnline={19},InvoiceName='{20}',InvoicePhone='{21}',InvoiceAddress='{22}',Fee={23} where JobID='{24}' "
        //        , model.JobType
        //        , model.CreateTime
        //        , model.CreateUser
        //        , Convert.ToInt32(model.IsDelete)
        //        , model.EnterpriseName
        //        , model.EnterpriseAddress
        //        , model.EnterpriseCode
        //        , model.AgentName
        //        , model.AgentIdentificationType == null ? "null" : model.AgentIdentificationType.ToString()
        //        , model.AgentIdentificationNum
        //        , model.AgentPhone
        //        , model.ConsigneeName
        //        , model.ConsigneeAddress
        //        , model.ConsigneePhone
        //        , model.Remark
        //        , Convert.ToInt32(model.ExpressFlat)
        //        , model.FeeFlat
        //        , model.CustomsCode
        //        , model.ApprovalFile
        //        , Convert.ToInt32(model.IsOnline)
        //        , model.InvoiceName
        //        , model.InvoicePhone
        //        , model.InvoiceAddress
        //        , model.Fee
        //        , model.JobID);
        //    return strSql.ToString();
        //}
		#endregion  ExtensionMethod
	}
}

