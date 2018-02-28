using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CardCenter.Entity;

namespace CardCenter.PageBase 
{
    #region 内部类


    /// <summary>
    /// 获取AccessToken对像
    /// </summary>
    public class AccessToken { public string access_token { set; get; } }

    [Serializable]
    public class CompanyAllData
    {
        public string TRADE_CO { set; get; }

        public string REG_CO { set; get; }

        public string FULL_NAME { set; get; }

        public string CUSTOMS_CODE { set; get; }

        public string CO_CLASS { set; get; }

        public string CREDIT_MAR { set; get; }

        public string EXAM_SCORE { set; get; }

        public string VALID_DATE { set; get; }

        public string ACCO_BANK { set; get; }

        public string ACCO_NO { set; get; }

        public string MAIL_CO { set; get; }

        public string BROKER_TYPE { set; get; }

        public string RG_DATE { set; get; }

        public string LICENSE_ID { set; get; }

        public string EN_FULL_CO { set; get; }

        public string EN_ADDR_CO { set; get; }

        public string ADDR_CO { set; get; }

        public string BUSI_TYPE { set; get; }

        public string CONTAC_CO { set; get; }

        public string TEL_CO { set; get; }

        public string APPR_DEP { set; get; }

        public string APPR_ID { set; get; }

        public string LAW_MAN { set; get; }

        public string LAW_MAN_TEL { set; get; }

        public decimal? INV_FUND_T { set; get; }

        public string ID_NUMBER { set; get; }

        public decimal? RG_FUND { set; get; }

        public string CURR_CODE { set; get; }

        public string TAXY_RG_NO { set; get; }

        public string CHK_DATE { set; get; }

        public string CO_TYPE { set; get; }

        public decimal? BREAK_LAW_TIME1 { set; get; }

        public decimal? BREAK_LAW_TIME2 { set; get; }

        public decimal? IN_RATIO { set; get; }

        public decimal? INSPECT_TIME { set; get; }

        public string SPE_CO { set; get; }

        public string TRADE_AREA { set; get; }

        public string MAIN_PRO { set; get; }

        public decimal? ACT_FUND { set; get; }

        public decimal? DUTY_FREE_AMT { set; get; }

        public string COP_FLAG { set; get; }

        public string COP_NOTE { set; get; }

        public string PRE_TRADE_CO { set; get; }

        public string CHK_OPER_CODE { set; get; }

        public string CHK_OPER_FLAG { set; get; }

        public string CHK_OPER_DATE { set; get; }

        public string CHK_DPT_CODE { set; get; }

        public string CHK_DPT_FLAG { set; get; }

        public string CHK_DPT_DATE { set; get; }

        public string CHK_MASTER_CODE { set; get; }

        public string CHK_MASTER_FLAG { set; get; }

        public string CHK_MASTER_DATE { set; get; }

        public decimal? CHK_EARNEST_MON { set; get; }

        public string CHK_CODE { set; get; }

        public string COP_GB_CODE { set; get; }

        public string COP_IO_CODE { set; get; }

        public string COP_END_DATE { set; get; }

        public string COP_MODIFY_DATE { set; get; }

        public string COP_RANGE { set; get; }

        public string BUSINESS_CATEGORY { set; get; }

        public string SUPERIOR_COP_GB_CODE { set; get; }

        public string SUPERIOR_FULL_NAME { set; get; }

        public string SUPERIOR_TRADE_CO { set; get; }

        public string SIGNOUT_FLAG { set; get; }

        public string ADMIN_DIVISION_CODE { set; get; }

        public string ECONOMIC_AREA_CODE { set; get; }

        public string ECONOMIC_CATEGORY_CODE { set; get; }

        public string BUSINESS_CATEGORY_BRIEF { set; get; }

        public string CORP_TYPE { set; get; }

        public string CROSS_BORDER_TRADE_FLAGS { set; get; }

        public string HOME_PAGE { set; get; }

        public string CO_CLASS_PRO { set; get; }

        public string SOCIAL_CREDIT_CODE { set; get; }

        public string SPECIAL_TRADE_ZONE { set; get; }
    }

    [Serializable]
    public class CompanyData
    {
        public string FULL_NAME { set; get; }

        public string COP_GB_CODE { get; set; }

        public string TRADE_CO { get; set; }

        public string CONTAC_CO { get; set; }

        public string TEL_CO { get; set; }

        public string CUSTOMS_CODE { get; set; }

        public string ADDR_CO { get; set; }

        public string LAW_MAN { get; set; }

        public string LAW_MAN_TEL { get; set; }
    }

    /// <summary>
    /// 用户信息
    /// </summary>
    [Serializable]
    public class UserInfoEntity
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string _id { set; get; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string email { set; get; }
        /// <summary>
        /// 手机
        /// </summary>
        public string mobile { set; get; }
        /// <summary>
        /// 简称
        /// </summary>
        public string displayName { set; get; }

        ///// <summary>
        ///// 创建时间
        ///// </summary>
        //public string Created { set; get; }
        ///// <summary>
        ///// 是否可用
        ///// </summary>
        //public string Enabled { set; get; }
        ///// <summary>
        ///// 权限
        ///// </summary>
        //public string Permission { set; get; }

        /// <summary>
        /// 公司ID
        /// </summary>
        
        public string companyId { set; get; }

        ///// <summary>
        ///// 认证用户
        ///// </summary>
        //public string Authenticated { set; get; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string SubAccounts { set; get; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string IKeyPublicKey { set; get; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string IkeySerialNo { set; get; }

        ///// <summary>
        ///// 
        ///// </summary>
        //public string Notifications { set; get; }
    }

    /// <summary>
    /// 管理用户信息
    /// </summary>
    [Serializable]
    public class ManagerUserEntity
    {

        /// <summary>
        /// 用户GUID
        /// </summary>
        public string guid { set; get; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string username { set; get; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string name { set; get; }
        /// <summary>
        /// 权限
        /// </summary>
        public string role { set; get; }
        ///// <summary>
        ///// 部门
        ///// </summary>
        public int department { set; get; }
        /// <summary>
        /// 是否超级用户
        /// </summary>
        public bool isSuperUser { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string pic { get; set; }
		/// <summary>
		/// 拥有的权限列表
		/// </summary>
		public Dictionary<int, string> roles
		{set; get;
		}
		/// <summary>
		/// 权限集对应的角色
		/// </summary>
		public List<ManagerRoleOperation>roleFunctions
		{
			set;
			get;
		}
        /// <summary>
        /// 获取用户部门对应的区域
        /// </summary>
        public List<DepartmentDistrict> DeptDistrictList
        {
            set;get;
        }
    }
    #endregion
}
 
