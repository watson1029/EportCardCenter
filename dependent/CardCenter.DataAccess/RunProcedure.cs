using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ZWL;

namespace CardCenter.DataAccess
{
	public class RunProcedure : BaseDA
	{
		/// <summary>
		/// 根据工单号获取对应的操作列表
		/// </summary>
		/// <param name="jobId">工单ID</param>
		/// <returns></returns>
		public DataSet GetHandleListByJobID(string jobId)
		{
			SqlParameter[] para = {
                new SqlParameter("@JobID", SqlDbType.NVarChar,64),
            };
			para[0].Value = jobId;
			return DbHelperSQL.RunProcedure("GetHandleListByJobID", para, "GetHandleListByJobID");
		}

        /// <summary>
		/// 添加用户与角色关系
		/// </summary>
		/// <param name="rowType">是否添加类型</param>		 
		/// <returns></returns>
		public bool UserRoleAdd(int rowType, Guid UserRoleId, string UserId, int RoleId)
		{
			SqlParameter[] para = {
                new SqlParameter("@RowType", SqlDbType.NVarChar, 50),
				 new SqlParameter("@UserRoleId", SqlDbType.UniqueIdentifier),
				  new SqlParameter("@UserId", SqlDbType.NVarChar,64),
				  new SqlParameter("@RoleId", SqlDbType.Int) 
				  
            };
			para[0].Value = rowType;
			para[1].Value = UserRoleId;
			para[2].Value = UserId.ToString();
			para[3].Value = RoleId;
			 
			int outafter = 0;
			return DbHelperSQL.RunProcedure("ManagerUserRoleAdd", para, out outafter) > 0;

		}
		/// <summary>
		/// 获取权限操作列表
		/// </summary>
		/// <param name="roleId">权限ID</param>
		/// <returns></returns>
		public DataSet GetUserRole()
		{
			SqlParameter[] para = {
               
            };

			return DbHelperSQL.RunProcedure("GetUserRole", para, "GetUserRole");
		}
		/// <summary>
		/// 获取权限操作列表
		/// </summary>
		/// <param name="roleId">权限ID</param>
		/// <returns></returns>
		public DataSet GetRoleOperationByRoleId(int roleId)
		{
			SqlParameter[] para = {
                new SqlParameter("@RoleId", SqlDbType.Int),
            };
			para[0].Value = roleId;
			return DbHelperSQL.RunProcedure("GetRoleOperatonByRoleId", para, "GetRoleOperatonByRoleId");
		}

		/// <summary>
		/// 添加账号
		/// </summary>
		/// <param name="rowType">是否添加类型</param>
		/// <param name="operationEntity">实体</param>
		/// <returns></returns>
		public bool RoleOperationAdd(int rowType, Entity.ManagerRoleOperation operationEntity)
		{
			SqlParameter[] para = {
                new SqlParameter("@RowType", SqlDbType.NVarChar, 50),
				 new SqlParameter("@OperationId", SqlDbType.UniqueIdentifier),
				  new SqlParameter("@RoleId", SqlDbType.Int),
				   new SqlParameter("@MemuName", SqlDbType.NVarChar, 50),
				    new SqlParameter("@MemuCode", SqlDbType.NVarChar, 50),
					 new SqlParameter("@OperationCode", SqlDbType.NVarChar, 50),
				new SqlParameter("@OperationName", SqlDbType.NVarChar, 50),
				    new SqlParameter("@OperationType", SqlDbType.NVarChar, 50),
					 new SqlParameter("@OperationNumber", SqlDbType.Int, 50),
            };
			para[0].Value = rowType;
			para[1].Value = operationEntity.OperationId;
			para[2].Value = operationEntity.RoleId;
			para[3].Value = operationEntity.MemuName;
			para[4].Value = operationEntity.MemuCode;
			para[5].Value = operationEntity.OperationCode;
			para[6].Value = operationEntity.OperationName;
			para[7].Value = operationEntity.OperationType;
			para[8].Value = operationEntity.OperationNumber;
			int outafter = 0;
			return DbHelperSQL.RunProcedure("ManagerRoleOperationAdd", para, out outafter) > 0;

		}

		/// <summary>
		/// pxh
		/// 2010630
		/// 根据计算器KEY来获取序号
		/// 为了保证唯一，代表获取后考虑并发问题
		/// </summary>
		/// <param name="counterKey">计算器KEY</param>
		/// <returns>返回CounterValue值</returns>
		public string GetAppCounter(string counterKey)
		{
			SqlParameter[] para = {
                new SqlParameter("@CounterKey", SqlDbType.NVarChar, 50),
            };
			para[0].Value = counterKey;
			DataSet ds = DbHelperSQL.RunProcedure("GetAppCounter", para, "GetAppCounter");
			return ds.Tables[0].Rows[0][0].ToString();
		}


		public DataSet SelectFileTypeByJobType(string jobType)
		{
			SqlParameter[] para = {
                new SqlParameter("@JobType", SqlDbType.NVarChar, 8),
            };
			para[0].Value = jobType;
			return DbHelperSQL.RunProcedure("SelectFileTypeByJobType", para, "SelectFileTypeByJobType");
		}

		public DataSet ManagerList(string userID)
		{
			SqlParameter[] para = {
                new SqlParameter("@UserID", SqlDbType.NVarChar, 64),
            };
			para[0].Value = userID;
			return DbHelperSQL.RunProcedure("ManagerList", para, "ManagerList");
		}

        public DataSet SaleJobList(string userID)
        {
            SqlParameter[] para = {
                new SqlParameter("@UserID", SqlDbType.NVarChar, 64),
            };
            para[0].Value = userID;
            return DbHelperSQL.RunProcedure("SaleJobList", para, "SaleJobList");
        }

        public DataSet SaleJobListView(string saleID)
        {
            SqlParameter[] para = {
                new SqlParameter("@SaleID", SqlDbType.NVarChar, 64),
            };
            para[0].Value = saleID;
            return DbHelperSQL.RunProcedure("SaleJobListView", para, "SaleJobListView");
        }

        public DataSet HistoryList(string where)
        {
            SqlParameter[] para = {
                new SqlParameter("@where", SqlDbType.NVarChar),
            };
            para[0].Value = where;
            return DbHelperSQL.RunProcedure("HistoryList", para, "HistoryList");
        }

        public string GetListDbName(string jobID)
		{
			SqlParameter[] para = {
                new SqlParameter("@JobID", SqlDbType.NVarChar, 64),
            };
			para[0].Value = jobID;
			DataSet ds = DbHelperSQL.RunProcedure("GetListDbName", para, "GetListDbName");
			if ( ds.Tables[0].Rows.Count == 0 )
				return null;
			else
				return ds.Tables[0].Rows[0]["JobDbName"].ToString();
		}

		public DataSet JobView(string jobID, string dbName)
		{
			SqlParameter[] para = {
                new SqlParameter("@JobID", SqlDbType.NVarChar, 64),
                new SqlParameter("@DbName", SqlDbType.NVarChar, 64),
            };
			para[0].Value = jobID;
			para[1].Value = dbName;
			return DbHelperSQL.RunProcedure("JobView", para, "JobView");
		}

		public bool JobDelete(string jobID, string dbName)
		{
			SqlParameter[] para = {
                new SqlParameter("@JobID", SqlDbType.NVarChar, 64),
                new SqlParameter("@DbName", SqlDbType.NVarChar, 64),
            };
			para[0].Value = jobID;
			para[1].Value = dbName;
			int rowsAffected = 0;
			DbHelperSQL.RunProcedure("JobDelete", para, out rowsAffected);
			if ( rowsAffected > 0 )
				return true;
			else
				return false;
		}

		public bool HeadInput(string jobInfoSql, string fileListSql, string flowInfoSql)
		{
			SqlParameter[] para = {
                new SqlParameter("@JobInfoSql", SqlDbType.NVarChar, jobInfoSql.Length),
                new SqlParameter("@FileListSql", SqlDbType.NVarChar, fileListSql.Length),
                new SqlParameter("@FlowInfoSql", SqlDbType.NVarChar, flowInfoSql.Length),
            };
			para[0].Value = jobInfoSql;
			para[1].Value = fileListSql;
			para[2].Value = flowInfoSql;
			int rowsAffected = 0;
			DbHelperSQL.RunProcedure("HeadInput", para, out rowsAffected);
			if ( rowsAffected > 0 )
				return true;
			else
				return false;
		}

		public bool ListInput(string listSql)
		{
			SqlParameter[] para = {
                new SqlParameter("@ListSql", SqlDbType.NVarChar, listSql.Length),
            };
			para[0].Value = listSql;
			int rowsAffected = 0;
			DbHelperSQL.RunProcedure("ListInput", para, out rowsAffected);
			if ( rowsAffected > 0 )
				return true;
			else
				return false;
		}

		public bool RIListDelete(string listID)
		{
			SqlParameter[] para = {
                new SqlParameter("@ListID", SqlDbType.NVarChar, 64),
            };
			para[0].Value = listID;
			int rowsAffected = 0;
			DbHelperSQL.RunProcedure("RIListDelete", para, out rowsAffected);
			if ( rowsAffected > 0 )
				return true;
			else
				return false;
		}
		public bool RMListDelete(string listID)
		{
			SqlParameter[] para = {
                new SqlParameter("@ListID", SqlDbType.NVarChar, 64),
            };
			para[0].Value = listID;
			int rowsAffected = 0;
			DbHelperSQL.RunProcedure("RMListDelete", para, out rowsAffected);
			if ( rowsAffected > 0 )
				return true;
			else
				return false;
		}

		public bool NAListDelete(string listID)
		{
			SqlParameter[] para = { 
                new SqlParameter("@ListID", SqlDbType.NVarChar, 64), 
            };
			para[0].Value = listID;
			int rowsAffected = 0;
			DbHelperSQL.RunProcedure("NAListDelete", para, out rowsAffected);
			if ( rowsAffected > 0 )
				return true;
			else
				return false;
		}

		public bool MDListDelete(string listID)
		{
			SqlParameter[] para = {
                new SqlParameter("@ListID", SqlDbType.NVarChar, 64),
            };
			para[0].Value = listID;
			int rowsAffected = 0;
			DbHelperSQL.RunProcedure("MDListDelete", para, out rowsAffected);
			if ( rowsAffected > 0 )
				return true;
			else
				return false;
		}

		public bool UUListDelete(string listID)
		{
			SqlParameter[] para = {
                new SqlParameter("@ListID", SqlDbType.NVarChar, 64),
            };
			para[0].Value = listID;
			int rowsAffected = 0;
			DbHelperSQL.RunProcedure("UUListDelete", para, out rowsAffected);
			if ( rowsAffected > 0 )
				return true;
			else
				return false;
		}

		public bool SLListDelete(string listID)
		{
			SqlParameter[] para = {
                new SqlParameter("@ListID", SqlDbType.NVarChar, 64),
            };
			para[0].Value = listID;
			int rowsAffected = 0;
			DbHelperSQL.RunProcedure("SLListDelete", para, out rowsAffected);
			if ( rowsAffected > 0 )
				return true;
			else
				return false;
		}

		public DataSet GetFlowStatus(string jobType)
		{
			SqlParameter[] para = {
                new SqlParameter("@JobType", SqlDbType.NVarChar, 8),
            };
			para[0].Value = jobType;
			return DbHelperSQL.RunProcedure("GetFlowStatus", para, "GetFlowStatus");
		}

		public bool ListOperation(string listID, int operationSign, string operationContent, string dbName)
		{
			SqlParameter[] para = {
                new SqlParameter("@ListID", SqlDbType.NVarChar, 64),
                new SqlParameter("@OperationSign", SqlDbType.Int, 4),
                new SqlParameter("@OperationContent", SqlDbType.NVarChar, 512),
                new SqlParameter("@DbName", SqlDbType.NVarChar, 64),
            };
			para[0].Value = listID;
			para[1].Value = operationSign;
			para[2].Value = operationContent;
			para[3].Value = dbName;

			int rowsAffected = 0;
			DbHelperSQL.RunProcedure("ListOperation", para, out rowsAffected);
			if ( rowsAffected > 0 )
				return true;
			else
				return false;
		}

		public DataSet JobFeeDetal(string jobID, string dbName)
		{
			SqlParameter[] para = {
                new SqlParameter("@JobID", SqlDbType.NVarChar, 64),
            };
			para[0].Value = jobID;
			return DbHelperSQL.RunProcedure("JobFeeDetal", para, "JobFeeDetal");
		}

		public bool IsFeeComplete(string jobID, string jobType)
		{
			SqlParameter[] para = {
                new SqlParameter("@JobID", SqlDbType.NVarChar, 64),
                new SqlParameter("@JobType", SqlDbType.NVarChar, 8),
            };
			para[0].Value = jobID;
			para[1].Value = jobType;
			if ( DbHelperSQL.RunProcedure("IsFeeComplete", para, "IsFeeComplete").Tables[0].Rows.Count == 0 )
				return true;
			else
				return false;
		}

		public bool CanFinish(string jobID, string dbName)
		{
			SqlParameter[] para = {
                new SqlParameter("@JobID", SqlDbType.NVarChar, 64),
                new SqlParameter("@DbName", SqlDbType.NVarChar, 64),
            };
			para[0].Value = jobID;
			para[1].Value = dbName;

			if ( DbHelperSQL.RunProcedure("CanFinish", para, "CanFinish").Tables[0].Rows.Count == 0 )
				return true;
			else
				return false;
		}

		public DataSet Receipt(string listID, string dbName)
		{
			SqlParameter[] para = {
                new SqlParameter("@ListID", SqlDbType.NVarChar, 64),
                new SqlParameter("@DbName", SqlDbType.NVarChar, 64),
            };
			para[0].Value = listID;
			para[1].Value = dbName;
			return DbHelperSQL.RunProcedure("Receipt", para, "Receipt");
		}

		public DataSet SMSPro(string jobID)
		{
			SqlParameter[] para = {
                new SqlParameter("@JobID", SqlDbType.NVarChar, 64),
            };
			para[0].Value = jobID;
			return DbHelperSQL.RunProcedure("SMS", para, "SMS");
		}

        public DataSet SMS_QS(string jobID, string content)
        {
            SqlParameter[] para = {
                new SqlParameter("@JobID", SqlDbType.NVarChar, 64),
                new SqlParameter("@content", SqlDbType.NVarChar, 256),
            };
            para[0].Value = jobID;
            para[1].Value = content;
            return DbHelperSQL.RunProcedure("SMS_QS", para, "SMS_QS");
        }

        public DataSet SMS_DKQ(string jobID, string content)
        {
            SqlParameter[] para = {
                new SqlParameter("@JobID", SqlDbType.NVarChar, 64),
                new SqlParameter("@content", SqlDbType.NVarChar, 256),
            };
            para[0].Value = jobID;
            para[1].Value = content;
            return DbHelperSQL.RunProcedure("SMS_DKQ", para, "SMS_DKQ");
        }

        public DataSet InvoiceList()
        {
            SqlParameter[] para = { };
            return DbHelperSQL.RunProcedure("InvoiceList", para, "InvoiceList");
        }

        /// <summary>
        /// Author:	P.Z
        /// Create date: 2016.11.14
        /// Description: 统计各类型业务数量，制卡点工单处理数量。条件：时间段。
        /// </summary>
        public DataSet Statistics1(DateTime beginDate, DateTime endDate)
        {
            SqlParameter[] para = {
                new SqlParameter("@beginDate", SqlDbType.DateTime),
                new SqlParameter("@endDate", SqlDbType.DateTime),
            };
            para[0].Value = beginDate;
            para[1].Value = endDate;
            DataSet ds = DbHelperSQL.RunProcedure("Statistics1", para, "Statistics1", 0);
            ds.Tables[0].TableName = "常规业务量统计";
            ds.Tables[1].TableName = "制卡点工单处理统计";
            return ds;

        }
        /// <summary>
        /// Author:	P.Z
        /// Create date: 2016.09.21
        /// Description: 统计已支付工单总数、网上(微信)支付笔数、网上(微信)支付总金额、现场支付笔数、现场支付总金额、未开发票数及明细，条件：时间段。
        /// </summary>
        public DataSet Statistics2(DateTime beginDate, DateTime endDate)
        {
            SqlParameter[] para = {
                new SqlParameter("@beginDate", SqlDbType.DateTime),
                new SqlParameter("@endDate", SqlDbType.DateTime),
            };
            para[0].Value = beginDate;
            para[1].Value = endDate;
            DataSet ds = DbHelperSQL.RunProcedure("Statistics2", para, "Statistics2");
            ds.Tables[0].TableName = "支付统计-汇总";
            ds.Tables[1].TableName = "支付统计-明细";
            return ds;
        }

        /// <summary>
        /// Author:	P.Z
        /// Create date: 2016.09.21
        /// Description: 工单总数、参与网上投票数，条件：时间段。
        /// </summary>
        public DataSet Statistics3(DateTime beginDate, DateTime endDate)
        {
            SqlParameter[] para = {
                new SqlParameter("@beginDate", SqlDbType.DateTime),
                new SqlParameter("@endDate", SqlDbType.DateTime),
            };
            para[0].Value = beginDate;
            para[1].Value = endDate;
            DataSet ds = DbHelperSQL.RunProcedure("Statistics3", para, "Statistics3");
            ds.Tables[0].TableName = "问卷调查统计-汇总";
            ds.Tables[1].TableName = "问卷调查统计-明细";
            return ds;
        }

        /// <summary>
        /// Author:	P.Z
        /// Create date: 2017.03.09
        /// Description: 统计东方和南方支付信息。条件：时间段。
        /// </summary>
        public DataSet Statistics4(DateTime beginDate, DateTime endDate)
        {
            SqlParameter[] para = {
                new SqlParameter("@beginDate", SqlDbType.DateTime),
                new SqlParameter("@endDate", SqlDbType.DateTime),
            };
            para[0].Value = beginDate;
            para[1].Value = endDate;
            DataSet ds = DbHelperSQL.RunProcedure("Statistics4", para, "Statistics4");
            ds.Tables[0].TableName = "汇总表";
            ds.Tables[1].TableName = "东方口岸-网上支付";
            ds.Tables[2].TableName = "东方口岸-现场支付";
            ds.Tables[3].TableName = "南方信息-网上支付";
            ds.Tables[4].TableName = "南方信息-现场支付";
            return ds;
        }

        /// <summary>
        /// Author:	P.Z
        /// Create date: 2017.11.20
        /// Description: 统计业务工单详细信息（所有）。条件：时间段。输出结果：所有更新、解锁、变更工单
        /// </summary>
        public DataSet Statistics5(DateTime beginDate, DateTime endDate)
        {
            SqlParameter[] para = {
                new SqlParameter("@beginDate", SqlDbType.DateTime),
                new SqlParameter("@endDate", SqlDbType.DateTime),
            };
            para[0].Value = beginDate;
            para[1].Value = endDate;
            DataSet ds = DbHelperSQL.RunProcedure("Statistics5", para, "Statistics5");
            ds.Tables[0].TableName = "业务工单详细信息统计（所有）";
            return ds;
        }

        /// <summary>s
        /// Author:	P.Z
        /// Create date: 2017.11.20
        /// Description: 统计业务工单详细信息（其他关区）。条件：时间段。输出结果：市政以外关区处理的更新、解锁、变更工单
        /// </summary>
        public DataSet Statistics6(DateTime beginDate, DateTime endDate)
        {
            SqlParameter[] para = {
                new SqlParameter("@beginDate", SqlDbType.DateTime),
                new SqlParameter("@endDate", SqlDbType.DateTime),
            };
            para[0].Value = beginDate;
            para[1].Value = endDate;
            DataSet ds = DbHelperSQL.RunProcedure("Statistics6", para, "Statistics6");
            ds.Tables[0].TableName = "业务工单详细信息统计（其他关区）";
            return ds;
        }

        public DataSet SelectCardNum(string JobID)
        {
            SqlParameter[] para = {
                new SqlParameter("@JobID", SqlDbType.NVarChar, 64),
            };
            para[0].Value = JobID;
            return DbHelperSQL.RunProcedure("SelectCardNum", para, "SelectCardNum");
        }

        public DataSet SpotGetSaleList(string JobTypeID)
        {
            SqlParameter[] para = {
                new SqlParameter("@JobTypeID", SqlDbType.NVarChar, 64),
            };
            para[0].Value = JobTypeID;
            return DbHelperSQL.RunProcedure("SpotGetSaleList", para, "SpotGetSaleList");
        }

        /// <summary>
        /// 新增业务逻辑校验-法人卡
        /// </summary>
        /// <param name="IDType">证件类型</param>
        /// <param name="IDNum">证件号码</param>
        /// <param name="companyID">海关编码</param>
        /// <param name="jobID">工单编号</param>
        /// <returns></returns>
        public DataSet NALogicalCheckFR(int IDType, string IDNum, string companyID, string jobID, string listID)
        {
            SqlParameter[] para = {
                new SqlParameter("@IDType", SqlDbType.Int, 4),
                new SqlParameter("@IDNum", SqlDbType.NVarChar, 32),
                new SqlParameter("@companyID", SqlDbType.NVarChar, 10),
                new SqlParameter("@jobID", SqlDbType.NVarChar, 64),
                new SqlParameter("@listID", SqlDbType.NVarChar, 64),
            };
            para[0].Value = IDType;
            para[1].Value = IDNum;
            para[2].Value = companyID;
            para[3].Value = jobID;
            para[4].Value = listID;
            return DbHelperSQL.RunProcedure("NALogicalCheckFR", para, "NALogicalCheckFR");
        }

        /// <summary>
        /// 新增业务逻辑校验-其他卡
        /// </summary>
        /// <param name="IDType">证件类型</param>
        /// <param name="IDNum">证件号码</param>
        /// <param name="companyID">海关编码</param>
        /// <param name="jobID">工单编号</param>
        /// <returns></returns>
        public DataSet NALogicalCheckQT(int IDType, string IDNum, string companyID, string jobID, string listID)
        {
            SqlParameter[] para = {
                new SqlParameter("@IDType", SqlDbType.Int, 4),
                new SqlParameter("@IDNum", SqlDbType.NVarChar, 32),
                new SqlParameter("@companyID", SqlDbType.NVarChar, 10),
                new SqlParameter("@jobID", SqlDbType.NVarChar, 64),
                new SqlParameter("@listID", SqlDbType.NVarChar, 64),
            };
            para[0].Value = IDType;
            para[1].Value = IDNum;
            para[2].Value = companyID;
            para[3].Value = jobID;
            para[4].Value = listID;
            return DbHelperSQL.RunProcedure("NALogicalCheckQT", para, "NALogicalCheckQT");
        }

        public DataTable CloseList()
        {
            SqlParameter[] para = {
            };
            return DbHelperSQL.RunProcedure("CloseList", para, "CloseList").Tables[0];
        }
    }
}
