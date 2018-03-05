using CardCenter.PageBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardCenter.ApplyForm
{
    public partial class NewlyAddedListFR : UserVerifyPage
    {
        public string listID
        {
            set;
            get;
        }

        public string jobID
        {
            set;
            get;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitSelect();
                DataInit();
            }
        }

        private void DataInit()
        {
            listID = ZWL.ObjectOperation.QueryStringHelper.GetQuery("listID");
            jobID = ZWL.ObjectOperation.QueryStringHelper.GetQuery("jobID");
            hJobID.Value = jobID;
            hListID.Value = listID;

            if (!string.IsNullOrEmpty(listID))
            {
                Entity.NewlyAddedListFR fr = new DataAccess.NewlyAddedListFR().GetModel(listID);
                txtSHTYXYDM_QS.Value = fr.SHTYXYDM_QS;//统一社会信用代码1
                txtQYZWMC_QS.Value = fr.QYZWMC_QS;//企业中文名称4
                txtQYYWMC_QS.Value = fr.QYYWMC_QS;//企业英文名称
                txtQYDZ_QS.Value = fr.QYDZ_QS;//企业地址5
                txtFDDBR_QS.Value = fr.FDDBR_QS;//法定代表人6
                txtFRDH_QS.Value = fr.FRDH_QS;//法人电话7
                dlQYLX_QS.Value = fr.QYLX_QS;//企业类型8
                txtZCZJ_QS.Value = fr.ZCZJ_QS.ToString();//注册资金(万)9
                dlZCZJBZ_QS.Value = fr.ZCZJBZ_QS;//注册资金币制10
                txtYYQX_QS.Value = fr.YYQX_QS;//营业期限11
                dlZJLX_QS.Value = fr.ZJLX_QS_QS.ToString();//证件类型12
                txtZJHM_QS.Value = fr.ZJHM_QS;//证件号码
                dlFRLX_QS.Value = fr.FRLX_QS;//法人类型14
                txtYZBM_QS.Value = fr.YZBM_QS;//邮政编码
                txtCZ_QS.Value = fr.CZ_QS;//传真
                txtFZJGMC_QS.Value = fr.FZJGMC_QS;//发证机构名称
                dtFZRQ_QS.Value = fr.FZRQ_QS == null ? "" : Convert.ToDateTime(fr.FZRQ_QS).ToString("yyyy-MM-dd");//发证日期
                dtCLRQ_QS.Value = fr.CLRQ_QS == null ? "" : Convert.ToDateTime(fr.CLRQ_QS).ToString("yyyy-MM-dd");//成立日期
                txtJYFW_QS.Value = fr.JYFW_QS;//经营范围18
                txtHGZCH_HG.Value = fr.HGZCH_HG;//海关注册号20
                txtBAHG_HG.Value = fr.BAHG_HG;//备案海关22
                dtZCRQ_HG.Value = fr.ZCRQ_HG == null ? "" : Convert.ToDateTime(fr.ZCRQ_HG).ToString("yyyy-MM-dd");//注册日期23
                dtYXRQ_HG.Value = fr.YXRQ_HG == null ? "" : Convert.ToDateTime(fr.YXRQ_HG).ToString("yyyy-MM-dd");//企业注册有效日期24
                txtDWDZ_HG.Value = fr.DWDZ_HG;//对外英文地址29
                dlBGLB_HG.Value = fr.BGLB_HG;//报关类别34
                txtJCKQPZJG_HG.Value = fr.JCKQPZJG_HG;//进出口权批准机关37
                txtZJL_HG.Value = fr.ZJL_HG;//总经理41
                txtDH_HG.Value = fr.DH_HG;//电话42
                txtKHYH_HG.Value = fr.KHYH_HG;//开户银行43
                txtYHZH_HG.Value = fr.YHZH_HG;//银行账号44
                dlHYZL_HG.Value = fr.HYZL_HG;//行业种类46
                txtMSE_HG.Value = fr.MSE_HG.ToString();//免税额47
                txtZYCP_HG.Value = fr.ZYCP_HG;//主要产品48
                dlQYSCLX_HG.Value = fr.QYSCLX_HG;//企业生产类型51
                txtDWZBZE_HG.Value = fr.DWZBZE_HG.ToString();//到位资本总额(万)54
                txtNXBL_HG.Value = fr.NXBL_HG.ToString();//内销比例(%)55
                txtJCKQYDM_WJM.Value = fr.JCKQYDM_WJM;//进出口企业代码59
                dtFZRQ_WJM.Value = fr.FZRQ_WJM == null ? "" : Convert.ToDateTime(fr.FZRQ_WJM).ToString("yyyy-MM-dd"); //发证(备案)日期61
                txtZGBM_WJM.Value = fr.ZGBM_WJM;//主管部门68
                txtZS_WJM.Value = fr.ZS_WJM;//住所70
                txtDZYX_WJM.Value = fr.DZYX_WJM;//电子邮箱74
                dtGSDJZCRQ_WJM.Value = fr.GSDJZCRQ_WJM == null ? "" : Convert.ToDateTime(fr.GSDJZCRQ_WJM).ToString("yyyy-MM-dd");//工商登记注册日期75
                txtZCZJ_WJM.Value = fr.ZCZJ_WJM.ToString();//注册资金(折美元)84
                txtJCKSPML_WJM.Value = fr.JCKSPML_WJM;//进出口商品目录86
                txtBZ_WJM.Value = fr.BZ_WJM;//备注87
                txtHXLXR_WH.Value = fr.HXLXR_WH;//核销联系人99
                dlHYDM_WH.Value = fr.HYDM_WH;//行业代码101
                dlQYXZ_WH.Value = fr.QYXZ_WH;//企业性质103
                dtJZYXRQ_WH.Value = fr.JZYXRQ_WH == null ? "" : Convert.ToDateTime(fr.JZYXRQ_WH).ToString("yyyy-MM-dd");//截止有效日期108
                txtWMZSH_WH.Value = fr.WMZSH_WH;//外贸证书号109
                dtWMZSPZRQ_WH.Value = fr.WMZSPZRQ_WH == null ? "" : Convert.ToDateTime(fr.WMZSPZRQ_WH).ToString("yyyy-MM-dd");//外贸证书批准日期110
                dtHXKHRQ_WH.Value = fr.HXKHRQ_WH == null ? "" : Convert.ToDateTime(fr.HXKHRQ_WH).ToString("yyyy-MM-dd");//核销开户日期112
                selectNW.Value = fr.NWFlat.ToString();

                txtQYJYLX_WJM.Value = fr.QYJYLX_WJM;//2016072177企业（经营者）类型

                if (fr.NWFlat == 1)
                {
                    txtPZWH_WJM_NR.Value = fr.PZWH_WJM;//批准文号58
                    dtPZRQ_WJM_NR.Value = fr.PZRQ_WJM == null ? "" : Convert.ToDateTime(fr.PZRQ_WJM).ToString("yyyy-MM-dd");//批准日期60
                    txtJYNX_WJM_NR.Value = fr.JYNX_WJM.ToString();//经营年限78
                    txtTZZE_WJM_NR.Value = fr.TZZE_WJM.ToString();//投币总额(万)79
                    dlTZBZ_WJM_NR.Value = fr.TZBZ_WJM;//投币币制80
                    txtBADJBBH_WJM_R.Value = fr.BADJBBH_WJM;//备案登记表编号83
                    txtRMBZCZJ_WH_R.Value = fr.RMBZCZJ_WH.ToString();//人民币注册资金(万)104
                    dlWBZCBZ_WH_NR.Value = fr.WBZCBZ_WH;//外币注册币种105
                    txtWBZCZJ_WH_NR.Value = fr.WBZCZJ_WH.ToString();//外币注册资金(万)106
                }
                else
                {
                    txtPZWH_WJM_R.Value = fr.PZWH_WJM;//批准文号58
                    dtPZRQ_WJM_R.Value = fr.PZRQ_WJM == null ? "" : Convert.ToDateTime(fr.PZRQ_WJM).ToString("yyyy-MM-dd");//批准日期60
                    txtJYNX_WJM_R.Value = fr.JYNX_WJM.ToString();//经营年限78
                    txtTZZE_WJM_R.Value = fr.TZZE_WJM.ToString();//投币总额(万)79
                    dlTZBZ_WJM_R.Value = fr.TZBZ_WJM;//投币币制80
                    txtBADJBBH_WJM_NR.Value = fr.BADJBBH_WJM;//备案登记表编号83
                    txtRMBZCZJ_WH_NR.Value = fr.RMBZCZJ_WH.ToString();//人民币注册资金(万)104
                    dlWBZCBZ_WH_R.Value = fr.WBZCBZ_WH;//外币注册币种105
                    txtWBZCZJ_WH_R.Value = fr.WBZCZJ_WH.ToString();//外币注册资金(万)106
                }
            }
            else
            {
                ETGData();
                //根据统一社会信用代码取商事平台数据                
                string zch = txtSHTYXYDM_QS.Value;//统一社会信用代码1
                string name = txtQYZWMC_QS.Value;
                XSPTData(zch, name);
            }
        }

        private void InitSelect()
        {
            DataTable dt = new DataTable();
            //企业类型
            dt = new DataAccess.Para_QYLX().GetList("").Tables[0];
            foreach (DataRow dr in dt.Rows)
                dlQYLX_QS.Items.Add(new ListItem(dr["QYLX_Value"].ToString() + dr["QYLX_Name"].ToString(), dr["QYLX_Value"].ToString()));

            //币制
            dt = new DataAccess.Para_BZ().GetList("").Tables[0];
            dlTZBZ_WJM_NR.Items.Add(new ListItem("--请选择币制--", ""));
            dlWBZCBZ_WH_NR.Items.Add(new ListItem("--请选择币制--", ""));
            foreach (DataRow dr in dt.Rows)
            {
                dlZCZJBZ_QS.Items.Add(new ListItem(dr["BZ_Value"].ToString() + dr["BZ_Name"].ToString(), dr["BZ_Value"].ToString()));
                dlTZBZ_WJM_R.Items.Add(new ListItem(dr["BZ_Value"].ToString() + dr["BZ_Name"].ToString(), dr["BZ_Value"].ToString()));
                dlWBZCBZ_WH_R.Items.Add(new ListItem(dr["BZ_Value"].ToString() + dr["BZ_Name"].ToString(), dr["BZ_Value"].ToString()));
                dlTZBZ_WJM_NR.Items.Add(new ListItem(dr["BZ_Value"].ToString() + dr["BZ_Name"].ToString(), dr["BZ_Value"].ToString()));
                dlWBZCBZ_WH_NR.Items.Add(new ListItem(dr["BZ_Value"].ToString() + dr["BZ_Name"].ToString(), dr["BZ_Value"].ToString()));
            }

            //证件类型
            dt = new DataAccess.Para_IdentificationType().GetList("").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                dlZJLX_QS.Items.Add(new ListItem(dr["ID"].ToString() + dr["Name"].ToString(), dr["ID"].ToString()));
            }

            //法人类型
            dt = new DataAccess.Para_FRLX().GetList("").Tables[0];
            foreach (DataRow dr in dt.Rows)
                dlFRLX_QS.Items.Add(new ListItem(dr["FRLX_Value"].ToString() + dr["FRLX_Name"].ToString(), dr["FRLX_Value"].ToString()));

            //报关类别
            dt = new DataAccess.Para_BGLB().GetList("").Tables[0];
            foreach (DataRow dr in dt.Rows)
                dlBGLB_HG.Items.Add(new ListItem(dr["BGLB_Value"].ToString() + dr["BGLB_Name"].ToString(), dr["BGLB_Value"].ToString()));

            //行业种类
            dt = new DataAccess.Para_HYZL().GetList("").Tables[0];
            dlHYZL_HG.Items.Add(new ListItem("--请选择行业种类--", ""));
            foreach (DataRow dr in dt.Rows)
                dlHYZL_HG.Items.Add(new ListItem(dr["HYZL_Value"].ToString() + dr["HYZL_Name"].ToString(), dr["HYZL_Value"].ToString()));

            //企业生产类型
            dt = new DataAccess.Para_SCFS().GetList("").Tables[0];
            dlQYSCLX_HG.Items.Add(new ListItem("--请选择企业生产类型--", ""));
            foreach (DataRow dr in dt.Rows)
                dlQYSCLX_HG.Items.Add(new ListItem(dr["SCFS_Value"].ToString() + dr["SCFS_Name"].ToString(), dr["SCFS_Value"].ToString()));

            //企业性质
            dt = new DataAccess.Para_QYXZ().GetList("").Tables[0];
            foreach (DataRow dr in dt.Rows)
                dlQYXZ_WH.Items.Add(new ListItem(dr["QYXZ_Value"].ToString() + dr["QYXZ_Name"].ToString(), dr["QYXZ_Value"].ToString()));

            //行业代码
            dt = new DataAccess.Para_HYDM().GetList("").Tables[0];
            foreach (DataRow dr in dt.Rows)
                dlHYDM_WH.Items.Add(new ListItem(dr["HYDM_Value"].ToString() + dr["HYDM_Name"].ToString(), dr["HYDM_Value"].ToString()));
        }

        private void ETGData()
        {
            try
            {
                CompanyAllData data = CommonObject.LoginCompanyInfo;
                //社会统一代码2016-07-21
                txtSHTYXYDM_QS.Value = string.IsNullOrEmpty(data.SOCIAL_CREDIT_CODE) ? "" : data.SOCIAL_CREDIT_CODE;

                //企业注册号
                txtHGZCH_HG.Value = data.TRADE_CO;
                //企业名称
                txtQYZWMC_QS.Value = data.FULL_NAME;
                //有效日期
                dtYXRQ_HG.Value = string.IsNullOrEmpty(data.VALID_DATE) ? "" : Convert.ToDateTime(data.VALID_DATE).ToString("yyyy-MM-dd");
                //开户银行
                txtKHYH_HG.Value = data.ACCO_BANK;
                //开户账号
                txtYHZH_HG.Value = data.ACCO_NO;
                //企业邮编
                txtYZBM_QS.Value = data.MAIL_CO;
                //报关类别
                dlBGLB_HG.Value = data.BROKER_TYPE;
                //注册日期
                dtYXRQ_HG.Value = string.IsNullOrEmpty(data.RG_DATE) ? "" : Convert.ToDateTime(data.RG_DATE).ToString("yyyy-MM-dd");
                //企业英文名称
                txtQYYWMC_QS.Value = data.EN_FULL_CO;
                //企业英文地址
                txtDWDZ_HG.Value = data.EN_ADDR_CO;
                //企业中文地址
                txtQYDZ_QS.Value = data.ADDR_CO;
                //行业种类
                dlHYZL_HG.Value = data.BUSI_TYPE;
                //批准机关
                txtJCKQPZJG_HG.Value = data.APPR_DEP;
                //批准文号
                txtPZWH_WJM_R.Value = data.APPR_ID;
                txtPZWH_WJM_NR.Value = data.APPR_ID;
                //法人代表
                txtFDDBR_QS.Value = data.LAW_MAN;
                //法人电话
                txtFRDH_QS.Value = data.LAW_MAN_TEL;
                //投资总额
                txtTZZE_WJM_R.Value = data.INV_FUND_T == 0 ? "" : data.INV_FUND_T.ToString();
                txtTZZE_WJM_NR.Value = data.INV_FUND_T == 0 ? "" : data.INV_FUND_T.ToString();
                //注册资本
                txtZCZJ_QS.Value = data.RG_FUND == null ? "" : data.RG_FUND.ToString();
                //注册资本币制
                dlZCZJBZ_QS.Value = data.CURR_CODE;
                //企业生产类型
                dlQYSCLX_HG.Value = data.CO_TYPE;
                //内销比率
                txtNXBL_HG.Value = data.IN_RATIO == null ? "" : data.IN_RATIO.ToString();
                //主要产品
                txtZYCP_HG.Value = data.MAIN_PRO;
                //到位资金
                txtDWZBZE_HG.Value = data.ACT_FUND == null ? "" : data.ACT_FUND.ToString();
                //免税额
                txtMSE_HG.Value = data.DUTY_FREE_AMT == null ? "" : data.DUTY_FREE_AMT.ToString();
                //企业进出口代码
                //txtJCKQYDM_WJM.Value = data.COP_IO_CODE;
                //经营范围
                txtJYFW_QS.Value = data.COP_RANGE;
            }
            catch
            {
                return;
            }
        }


        /// <summary>
        /// pxh
        /// 2016/7/20
        /// 从商事平台中取数据 zch = "91440101MA59A0E67L";
        /// </summary>
        /// <param name="uniscid">统一代码</param>
        /// <param name="name">商品名称</param>
        private void XSPTData(string uniscid, string name)
        {

            if (string.IsNullOrEmpty(uniscid) &&string.IsNullOrEmpty(name))
            {
                return;
            }

            try
            {
                CommercialAffairsOracleDataAccess.EX_GONGSHANG_41_SSZTJCXX_DA da = new CommercialAffairsOracleDataAccess.EX_GONGSHANG_41_SSZTJCXX_DA();
                DataTable dt = null;
                if (uniscid != "")
                {
                    //根据社会统一代码查询
                      dt = da.GET_EX_GONGSHANG_41_SSZTJCXX_BYUNISCID(uniscid);
                }
                else
                {
                    //根据商品名称查询
                    dt = da.GET_EX_GONGSHANG_41_SSZTJCXX_NAME(name);
                }
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    // zch,mc,fddbr,zyxmlb,jyfw,rjzczb,basszb,clrq,yyqx,qylx,hzrq,djjg    
                    //社会统一编码
                    txtSHTYXYDM_QS.Value=dr["UNISCID"].ToString();
                               
                    //企业名称
                    txtQYZWMC_QS.Value = dr["mc"].ToString();
                    txtQYZWMC_QS.Disabled = true;
                    //法人代表
                    txtFDDBR_QS.Value = dr["fddbr"].ToString();
                    txtFDDBR_QS.Disabled = true;
                    //经营范围
                    txtJYFW_QS.Value = dr["jyfw"].ToString();
                    txtJYFW_QS.Disabled = true;
                    //注册资本币制
                    txtZCZJ_QS.Value = getQSValue(dr["rjzczb"].ToString());
                    //绑定币种
                    //SelectQSType(dr["rjzczb"].ToString());

                    // dlZCZJBZ_QS.Disabled = true;
                    //成立日期
                    dtCLRQ_QS.Value = dr["clrq"] == null ? "" : Convert.ToDateTime(dr["clrq"]).ToString("yyyy-MM-dd");//成立日期
                    dtCLRQ_QS.Disabled = true;
                    //营业期限
                    txtYYQX_QS.Value = dr["yyqx"] == null ? "长期" : dr["yyqx"].ToString() == "" ? "长期" : dr["yyqx"].ToString();  //营业期限11
                    txtYYQX_QS.Disabled = true;
                    //企业类型8
                    dlQYLX_QS.Value = dr["qylx"] == null ? "" : dr["qylx"].ToString(); //企业类型8
                    // dlQYLX_QS.Disabled = true;
                    //发证机构名称
                    //txtFKJGDM_QS.Value = dr["djjg"] == null ? "" : dr["djjg"].ToString();
                    //txtFKJGDM_QS.Disabled = true;
                    //发证日期
                    dtFZRQ_QS.Value = dr["hzrq"] == null ? "" : Convert.ToDateTime(dr["hzrq"]).ToString("yyyy-MM-dd");
                    dtFZRQ_QS.Disabled = true;

                    string zch = dr["zch"].ToString();
                    //根据注册号查询地址
                    DataTable dtAddress = da.GET_EX_GONGSHANG_43_SSZTJYCX_BYZCH(zch);
                    if(dtAddress!=null&&dtAddress.Rows.Count>0)
                    {
                        txtQYDZ_QS.Value = dr["dz"].ToString();
                        txtQYDZ_QS.Disabled = true;
                    }
                }
            }
            catch (Exception)
            {

                return;
            }

        }
        private string getQSValue(string rjzczb)
        {
            if (rjzczb.Contains("万"))
            {
                return rjzczb.Substring(0, rjzczb.IndexOf('万') - 1);
            }
            return rjzczb;
        }

        private void SelectQSType(string rjzczb)
        {

            string strType = "人民币";
            if (!rjzczb.Contains("人民币"))
            {
                strType = rjzczb.Substring(rjzczb.IndexOf('万') + 1);
            }

            for (int i = 0; i < dlZCZJBZ_QS.Items.Count; i++)
            {
                if (dlZCZJBZ_QS.Items[i].Text.Contains(strType))
                {
                    dlZCZJBZ_QS.Items[i].Selected = true;
                    break;
                }
                //else
                //{
                //    dlZCZJBZ_QS.Items[i].Selected = false;
                //}
            }

        }

    }
}