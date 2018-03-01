using CardCenter.PageBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace CardCenter.Ajax
{
    /// <summary>
    /// NAListSaveFR 的摘要说明
    /// </summary>
    public class NAListSaveFR : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";
                string jobID = context.Request.Form["hJobID"];
                string listID = context.Request.Form["hListID"];//工单
                DataAccess.RunProcedure run = new DataAccess.RunProcedure();
                DataSet view = run.JobView(jobID, "NewlyAddedList");
                if (view.Tables[3].Rows[0]["StatusName"].Equals("未提交."))
                {
                    Entity.NewlyAddedList na = new Entity.NewlyAddedList();
                    DataAccess.NewlyAddedList da = new DataAccess.NewlyAddedList();
                    DateTime time = DateTime.Now;

                    //工单项
                    if (string.IsNullOrEmpty(listID))
                    {
                        na.JobType = "NA001";
                        na.ListID = na.JobType + "-" + time.ToString("yyyyMMddhhmmssfff") + (new Random().Next(1, 10000)).ToString().PadLeft(4, '0');
                        na.JobID = jobID;
                        na.CardType = "法人卡";
                    }
                    else
                    {
                        na = da.GetModel(listID);
                    }
                    na.CardholderName = context.Request.Form["txtFDDBR_QS"];
                    na.CardholderPhone = context.Request.Form["txtFRDH_QS"];
                    na.CardholderIdentificationType = Convert.ToInt32(context.Request.Form["dlZJLX_QS"]);
                    na.CardholderIdentificationNum = context.Request.Form["txtZJHM_QS"];
                    na.IsDelete = false;
                    na.Remark = "";

                    //工单项法人卡（新证）详细资料
                    Entity.NewlyAddedListFR fr = new Entity.NewlyAddedListFR();
                    DataAccess.NewlyAddedListFR dafr = new DataAccess.NewlyAddedListFR();
                    if (string.IsNullOrEmpty(listID))
                        fr.ListID = na.ListID;
                    else
                        fr = dafr.GetModel(listID);
                    #region 法人卡新证实体
                    //前三字
                    fr.SHTYXYDM_QS = context.Request.Form["txtSHTYXYDM_QS"].Trim();//1统一社会信用代码
                    Entity.Para_Department department = new DataAccess.Para_Department().GetModel(fr.SHTYXYDM_QS.Substring(2, 6));
                    fr.ZTSBM_QS = context.Request.Form["txtSHTYXYDM_QS"].Trim().Substring(8, 9);//2主体识别码
                    fr.XZQYHM_QS = context.Request.Form["txtSHTYXYDM_QS"].Trim().Substring(2, 6);//3登记管理机关行政区域划码
                    fr.QYZWMC_QS = context.Request.Form["txtQYZWMC_QS"].Trim();//4企业中文名称
                    fr.QYYWMC_QS = context.Request.Form["txtQYYWMC_QS"].Trim();//企业英文名称
                    fr.QYDZ_QS = context.Request.Form["txtQYDZ_QS"].Trim();//5企业地址
                    fr.FDDBR_QS = context.Request.Form["txtFDDBR_QS"].Trim();//6法定代表人
                    fr.FRDH_QS = context.Request.Form["txtFRDH_QS"].Trim();//7法人电话
                    fr.QYLX_QS = context.Request.Form["dlQYLX_QS"].Trim();//8企业类型
                    fr.ZCZJ_QS = string.IsNullOrEmpty(context.Request.Form["txtZCZJ_QS"].Trim()) ? (decimal?)null : Convert.ToDecimal(context.Request.Form["txtZCZJ_QS"].Trim());//9注册资金
                    fr.ZCZJBZ_QS = context.Request.Form["dlZCZJBZ_QS"].Trim();//10注册资金币值
                    fr.YYQX_QS = context.Request.Form["txtYYQX_QS"].Trim();//11营业期限
                    fr.ZJLX_QS_QS = string.IsNullOrEmpty(context.Request.Form["dlZJLX_QS"].Trim()) ? (int?)null : Convert.ToInt32(context.Request.Form["dlZJLX_QS"].Trim());//12证件类型
                    fr.ZJHM_QS = context.Request.Form["txtZJHM_QS"].Trim();//证件号码
                    fr.FKJGDM_QS = "26";//13发卡机构代码
                    fr.FRLX_QS = context.Request.Form["dlFRLX_QS"].Trim();//14法人类型
                    fr.YZBM_QS = context.Request.Form["txtYZBM_QS"].Trim();//邮政编码
                    fr.CZ_QS = context.Request.Form["txtCZ_QS"].Trim();//传真
                    fr.FZJGMC_QS = context.Request.Form["txtFZJGMC_QS"].Trim();//发证机构名称
                    fr.FZRQ_QS = string.IsNullOrEmpty(context.Request.Form["dtFZRQ_QS"].Trim()) ? (DateTime?)null : Convert.ToDateTime(context.Request.Form["dtFZRQ_QS"].Trim());//发证日期
                    fr.CLRQ_QS = string.IsNullOrEmpty(context.Request.Form["dtCLRQ_QS"].Trim()) ? (DateTime?)null : Convert.ToDateTime(context.Request.Form["dtCLRQ_QS"].Trim());//成立日期
                    fr.GSSPDWDM_QS = department == null ? fr.SHTYXYDM_QS.Substring(2, 4) + "00" : department.GS;//15工商审核单位代码
                    fr.ZJSPDWDM_QS = department == null ? fr.SHTYXYDM_QS.Substring(2, 4) + "00" : department.ZJ;//16技监审核单位代码
                    fr.SWSPDWDM_QS = department == null ? "1" + fr.SHTYXYDM_QS.Substring(2, 4) + "0000" : department.SW;//17税务审核单位代码
                    fr.JYFW_QS = context.Request.Form["txtJYFW_QS"].Trim();//18经营范围
                                                                           //海关字段
                    fr.ZZJGDM_HG = context.Request.Form["txtSHTYXYDM_QS"].Trim().Substring(8, 9);//19组织机构代码
                    fr.HGZCH_HG = context.Request.Form["txtHGZCH_HG"].Trim();//20海关注册号
                    fr.ZGHG_HG = CommonObject.LoginCompanyInfo.CUSTOMS_CODE;//21主管海关
                    fr.BAHG_HG = context.Request.Form["txtBAHG_HG"].Trim();//22备案海关
                    fr.ZCRQ_HG = string.IsNullOrEmpty(context.Request.Form["dtZCRQ_HG"].Trim()) ? (DateTime?)null : Convert.ToDateTime(context.Request.Form["dtZCRQ_HG"].Trim());//23注册日期
                    fr.YXRQ_HG = string.IsNullOrEmpty(context.Request.Form["dtYXRQ_HG"].Trim()) ? (DateTime?)null : Convert.ToDateTime(context.Request.Form["dtYXRQ_HG"].Trim());//24企业注册有效日期
                    fr.GSZCQC_HG = context.Request.Form["txtQYZWMC_QS"].Trim();//25工商注册全称
                    fr.HGZCMC_HG = context.Request.Form["txtQYZWMC_QS"].Trim();//26海关注册名称
                    fr.DWMC_HG = context.Request.Form["txtQYYWMC_QS"].Trim();//27对外(英文)名称
                    fr.GSZCDZ_HG = context.Request.Form["txtQYDZ_QS"].Trim();//28工商注册地址
                    fr.DWDZ_HG = context.Request.Form["txtDWDZ_HG"].Trim();//29对外(英文)地址
                    fr.YYZZZCH_HG = context.Request.Form["txtSHTYXYDM_QS"].Trim();//30营业执照注册号
                    fr.YZBM_HG = context.Request.Form["txtYZBM_QS"].Trim();//31邮政编码
                    fr.FRDB_HG = context.Request.Form["txtFDDBR_QS"].Trim();//32法人代表
                    fr.FRDH_HG = context.Request.Form["txtFRDH_QS"].Trim();//33法人电话
                    fr.BGLB_HG = context.Request.Form["dlBGLB_HG"].Trim();//34报关类别
                    fr.ZJLX_HG = string.IsNullOrEmpty(context.Request.Form["dlZJLX_QS"].Trim()) ? (int?)null : Convert.ToInt32(context.Request.Form["dlZJLX_QS"].Trim());//35证件类别
                    fr.FRZJHM_HG = context.Request.Form["txtZJHM_QS"].Trim();//36法人证件号码
                    fr.JCKQPZJG_HG = context.Request.Form["txtJCKQPZJG_HG"].Trim();//37进出口权批准机关
                    fr.ZCZBBZ_HG = context.Request.Form["dlZCZJBZ_QS"].Trim();//39注册资本币制
                    fr.ZCZB_HG = string.IsNullOrEmpty(context.Request.Form["txtZCZJ_QS"].Trim()) ? (decimal?)null : Convert.ToDecimal(context.Request.Form["txtZCZJ_QS"].Trim());//40注册资本(万)
                    fr.ZJL_HG = context.Request.Form["txtZJL_HG"].Trim();//41总经理
                    fr.DH_HG = context.Request.Form["txtDH_HG"].Trim();//42电话
                    fr.KHYH_HG = context.Request.Form["txtKHYH_HG"].Trim();//43开户银行
                    fr.YHZH_HG = context.Request.Form["txtYHZH_HG"].Trim();//44银行帐号
                    fr.SWDJH_HG = context.Request.Form["txtSHTYXYDM_QS"].Trim();//45税务登记号
                    fr.HYZL_HG = context.Request.Form["dlHYZL_HG"].Trim();//46行业种类
                    fr.MSE_HG = string.IsNullOrEmpty(context.Request.Form["txtMSE_HG"].Trim()) ? (decimal?)null : Convert.ToDecimal(context.Request.Form["txtMSE_HG"].Trim());
                    fr.ZYCP_HG = context.Request.Form["txtZYCP_HG"].Trim();//48主要产品
                    fr.JYFWJBZ_HG = context.Request.Form["txtJYFW_QS"].Trim();//49经营范围及备注
                    fr.JCKQYDM_HG = context.Request.Form["txtJCKQYDM_WJM"].Trim();//50进出口企业代码
                    fr.QYSCLX_HG = context.Request.Form["dlQYSCLX_HG"].Trim();//51企业生产类型
                    fr.DWZBZE_HG = string.IsNullOrEmpty(context.Request.Form["txtDWZBZE_HG"].Trim()) ? (decimal?)null : Convert.ToDecimal(context.Request.Form["txtDWZBZE_HG"].Trim());//54到位资本总额(万)
                    fr.NXBL_HG = string.IsNullOrEmpty(context.Request.Form["txtNXBL_HG"].Trim()) ? (decimal?)null : Convert.ToDecimal(context.Request.Form["txtNXBL_HG"].Trim());//55内销比率(%)
                    fr.ZCYXRQ_HG = string.IsNullOrEmpty(context.Request.Form["dtYXRQ_HG"].Trim()) ? (DateTime?)null : Convert.ToDateTime(context.Request.Form["dtYXRQ_HG"].Trim());//56注册有效日期
                                                                                                                                                                                   //外经贸
                    fr.ZZJGDM_WJM = context.Request.Form["txtSHTYXYDM_QS"].Trim().Substring(8, 9);//57组织机构代码
                    fr.JCKQYDM_WJM = context.Request.Form["txtJCKQYDM_WJM"].Trim();//59进出口企业代码
                    fr.FZRQ_WJM = string.IsNullOrEmpty(context.Request.Form["dtFZRQ_WJM"].Trim()) ? (DateTime?)null : Convert.ToDateTime(context.Request.Form["dtFZRQ_WJM"].Trim());//61发证（备案）日期_外经贸
                    fr.FZJG_WJM = "外贸主管部门";//62发证（备案）机关_外经贸
                    fr.ZGWJM_WJM = department == null ? fr.SHTYXYDM_QS.Substring(2, 4) : department.WJ;//63主管外经委_外经贸
                    fr.QYZWMC_WJM = context.Request.Form["txtQYZWMC_QS"].Trim();//64企业（经营者）中文名称_外经贸
                    fr.YWDZ_WJM = context.Request.Form["txtQYYWMC_QS"].Trim();//65英文对照（经营者英文名称）_外经贸
                    fr.QYDZ_WJM = context.Request.Form["txtQYDZ_QS"].Trim();//66企业地址（经营场所）_外经贸
                    fr.JYCS_WJM = context.Request.Form["txtDWDZ_HG"].Trim();//67经营场所（英文）_外经贸
                    fr.ZGBM_WJM = context.Request.Form["txtZGBM_WJM"].Trim();//68主管部门_外经贸
                    fr.FDDBR_WJM = context.Request.Form["txtFDDBR_QS"].Trim();//69法定代表人（个体工商负责人）_外经贸
                    fr.ZS_WJM = context.Request.Form["txtZS_WJM"].Trim();//70住所_外经贸
                    fr.LXDH_WJM = context.Request.Form["txtFRDH_QS"].Trim();//71联系电话_外经贸
                    fr.LXCZ_WJM = context.Request.Form["txtCZ_QS"].Trim();//72联系传真_外经贸
                    fr.YZBM_WJM = context.Request.Form["txtYZBM_QS"].Trim();//73邮政编码_外经贸
                    fr.DZYX_WJM = context.Request.Form["txtDZYX_WJM"].Trim();//74电子邮箱_外经贸
                    fr.GSDJZCRQ_WJM = string.IsNullOrEmpty(context.Request.Form["dtGSDJZCRQ_WJM"].Trim()) ? (DateTime?)null : Convert.ToDateTime(context.Request.Form["dtGSDJZCRQ_WJM"].Trim());//75工商登记注册日期_外经贸
                    fr.GSDJZCH_WJM = context.Request.Form["txtSHTYXYDM_QS"].Trim();//76工商登记注册号
                    fr.QYJYLX_WJM = context.Request.Form["txtQYJYLX_WJM"].Trim();//77企业（经营者）类型
                    fr.ZCZB_WJM = string.IsNullOrEmpty(context.Request.Form["txtZCZJ_QS"].Trim()) ? (decimal?)null : Convert.ToDecimal(context.Request.Form["txtZCZJ_QS"].Trim());//81注册资本（万）
                    fr.ZCZBBZ_WJM = context.Request.Form["dlZCZJBZ_QS"].Trim();//82注册资本币制
                    fr.ZCZJ_WJM = string.IsNullOrEmpty(context.Request.Form["txtZCZJ_WJM"].Trim()) ? (decimal?)null : Convert.ToDecimal(context.Request.Form["txtZCZJ_WJM"].Trim());//84注册资金（折美元)
                    fr.JYFW_WJM = context.Request.Form["txtJYFW_QS"].Trim();//85经营范围_外经贸
                    fr.JCKSPML_WJM = context.Request.Form["txtJCKSPML_WJM"].Trim();//86进出口商品目录_外经贸
                    fr.BZ_WJM = context.Request.Form["txtBZ_WJM"].Trim();//87备注_外经贸
                                                                         //外汇
                    fr.ZZJGDM_WH = context.Request.Form["txtSHTYXYDM_QS"].Trim().Substring(8, 9);//88组织机构代码_外汇
                    fr.GSZCH_WH = context.Request.Form["txtSHTYXYDM_QS"].Trim();//89工商注册号_外汇
                    fr.HGZCH_WH = context.Request.Form["txtHGZCH_HG"].Trim();//90海关注册号_外汇
                    fr.HGZCYXQ_WH = string.IsNullOrEmpty(context.Request.Form["dtYXRQ_HG"].Trim()) ? (DateTime?)null : Convert.ToDateTime(context.Request.Form["dtYXRQ_HG"].Trim());//91海关注册有效期_外汇
                    fr.ZGWHJ_WH = department == null ? fr.SHTYXYDM_QS.Substring(2, 4) + "00" : department.WH;//92主管外汇局_外汇
                    fr.QYZWMC_WH = context.Request.Form["txtQYZWMC_QS"].Trim();//93企业中文全称_外汇
                    fr.QYDZ_WH = context.Request.Form["txtQYDZ_QS"].Trim();//94企业地址_外汇
                    fr.CZ_WH = context.Request.Form["txtCZ_QS"].Trim();//95传真_外汇
                    fr.DH_WH = context.Request.Form["txtFRDH_QS"].Trim();//96电话_外汇
                    fr.DZYX_WH = context.Request.Form["txtDZYX_WJM"].Trim();//97电子信箱_外汇
                    fr.FDDBR_WH = context.Request.Form["txtFDDBR_QS"].Trim();//98法定代表人_外汇
                    fr.HXLXR_WH = context.Request.Form["txtHXLXR_WH"].Trim();//99核销联系人_外汇
                    fr.JYFW_WH = context.Request.Form["txtJYFW_QS"].Trim();//100经营范围_外汇
                    fr.HYDM_WH = context.Request.Form["dlHYDM_WH"].Trim();//101行业代码_外汇
                    fr.QYYB_WH = context.Request.Form["txtYZBM_QS"].Trim();//102企业邮编_外汇
                    fr.QYXZ_WH = context.Request.Form["dlQYXZ_WH"].Trim();//103企业性质_外汇
                    fr.ZCSLRQ_WH = string.IsNullOrEmpty(context.Request.Form["dtCLRQ_QS"].Trim()) ? (DateTime?)null : Convert.ToDateTime(context.Request.Form["dtCLRQ_QS"].Trim());//107最初设立日期_外汇
                    fr.JZYXRQ_WH = string.IsNullOrEmpty(context.Request.Form["dtJZYXRQ_WH"].Trim()) ? (DateTime?)null : Convert.ToDateTime(context.Request.Form["dtJZYXRQ_WH"].Trim());//108截止有效日期_外汇
                    fr.WMZSH_WH = context.Request.Form["txtWMZSH_WH"].Trim();//109外贸证书号_外汇
                    fr.WMZSPZRQ_WH = string.IsNullOrEmpty(context.Request.Form["dtWMZSPZRQ_WH"].Trim()) ? (DateTime?)null : Convert.ToDateTime(context.Request.Form["dtWMZSPZRQ_WH"].Trim());//110外贸证书批准日期_外汇
                    fr.WMJYFW_WH = context.Request.Form["txtJYFW_QS"].Trim();//111外贸经营范围_外汇
                    fr.HXKHRQ_WH = string.IsNullOrEmpty(context.Request.Form["dtHXKHRQ_WH"].Trim()) ? (DateTime?)null : Convert.ToDateTime(context.Request.Form["dtHXKHRQ_WH"].Trim());//112核销开户日期_外汇
                    fr.QYLXMC_WH = new CardCenter.DataAccess.Para_QYLX().GetModel(context.Request.Form["dlQYLX_QS"].Trim()).QYLX_Name;//113企业类型名称_外汇
                    fr.NWFlat = string.IsNullOrEmpty(context.Request.Form["selectNW"].Trim()) ? (int?)null : Convert.ToInt32(context.Request.Form["selectNW"].Trim());//内资或外资标记
                    if (fr.NWFlat == 1)
                    {
                        fr.PZWH_HG = context.Request.Form["txtPZWH_WJM_NR"].Trim();//38批准文号
                        fr.BZ_HG = context.Request.Form["dlTZBZ_WJM_NR"].Trim();//52投资总额币制
                        fr.TZZE_HG = string.IsNullOrEmpty(context.Request.Form["txtTZZE_WJM_NR"].Trim()) ? (decimal?)null : Convert.ToDecimal(context.Request.Form["txtTZZE_WJM_NR"].Trim());//53投资总额(万)

                        fr.PZWH_WJM = context.Request.Form["txtPZWH_WJM_NR"].Trim();//58批准文号
                        fr.PZRQ_WJM = string.IsNullOrEmpty(context.Request.Form["dtPZRQ_WJM_NR"].Trim()) ? (DateTime?)null : Convert.ToDateTime(context.Request.Form["dtPZRQ_WJM_NR"].Trim());//60批准日期
                        fr.JYNX_WJM = string.IsNullOrEmpty(context.Request.Form["txtJYNX_WJM_NR"].Trim()) ? (int?)null : Convert.ToInt32(context.Request.Form["txtJYNX_WJM_NR"].Trim());//78经营年限
                        fr.TZZE_WJM = string.IsNullOrEmpty(context.Request.Form["txtTZZE_WJM_NR"].Trim()) ? (decimal?)null : Convert.ToDecimal(context.Request.Form["txtTZZE_WJM_NR"].Trim());//79投资总额（万）
                        fr.TZBZ_WJM = context.Request.Form["dlTZBZ_WJM_NR"].Trim();//80投资币制
                        fr.BADJBBH_WJM = context.Request.Form["txtBADJBBH_WJM_R"].Trim();//83备案登记表编号
                        fr.RMBZCZJ_WH = string.IsNullOrEmpty(context.Request.Form["txtRMBZCZJ_WH_R"].Trim()) ? (decimal?)null : Convert.ToDecimal(context.Request.Form["txtRMBZCZJ_WH_R"].Trim());//104人民币注册资金_外汇
                        fr.WBZCBZ_WH = context.Request.Form["dlWBZCBZ_WH_NR"].Trim();//105外币注册币种_外汇
                        fr.WBZCZJ_WH = string.IsNullOrEmpty(context.Request.Form["txtWBZCZJ_WH_NR"].Trim()) ? (decimal?)null : Convert.ToDecimal(context.Request.Form["txtWBZCZJ_WH_NR"].Trim());//106外币注册资金（万）_外汇
                    }
                    else
                    {
                        fr.PZWH_HG = context.Request.Form["txtPZWH_WJM_R"].Trim();//38批准文号
                        fr.BZ_HG = context.Request.Form["dlTZBZ_WJM_R"].Trim();//52投资总额币制
                        fr.TZZE_HG = string.IsNullOrEmpty(context.Request.Form["txtTZZE_WJM_R"].Trim()) ? (decimal?)null : Convert.ToDecimal(context.Request.Form["txtTZZE_WJM_R"].Trim());//53投资总额(万)

                        fr.PZWH_WJM = context.Request.Form["txtPZWH_WJM_R"].Trim();//58批准文号
                        fr.PZRQ_WJM = string.IsNullOrEmpty(context.Request.Form["dtPZRQ_WJM_R"].Trim()) ? (DateTime?)null : Convert.ToDateTime(context.Request.Form["dtPZRQ_WJM_R"].Trim());//60批准日期
                        fr.JYNX_WJM = string.IsNullOrEmpty(context.Request.Form["txtJYNX_WJM_R"].Trim()) ? (int?)null : Convert.ToInt32(context.Request.Form["txtJYNX_WJM_R"].Trim());//78经营年限
                        fr.TZZE_WJM = string.IsNullOrEmpty(context.Request.Form["txtTZZE_WJM_R"].Trim()) ? (decimal?)null : Convert.ToDecimal(context.Request.Form["txtTZZE_WJM_R"].Trim());//79投资总额（万）
                        fr.TZBZ_WJM = context.Request.Form["dlTZBZ_WJM_R"].Trim();//80投资币制
                        fr.BADJBBH_WJM = context.Request.Form["txtBADJBBH_WJM_NR"].Trim();//83备案登记表编号
                        fr.RMBZCZJ_WH = string.IsNullOrEmpty(context.Request.Form["txtRMBZCZJ_WH_NR"].Trim()) ? (decimal?)null : Convert.ToDecimal(context.Request.Form["txtRMBZCZJ_WH_NR"].Trim());//104人民币注册资金_外汇
                        fr.WBZCBZ_WH = context.Request.Form["dlWBZCBZ_WH_R"].Trim();//105外币注册币种_外汇
                        fr.WBZCZJ_WH = string.IsNullOrEmpty(context.Request.Form["txtWBZCZJ_WH_R"].Trim()) ? (decimal?)null : Convert.ToDecimal(context.Request.Form["txtWBZCZJ_WH_R"].Trim());//106外币注册资金（万）_外汇
                    }
                    #endregion

                    //提交数据到后台存储过程事务
                    DataAccess.TranHelper.BeginTran();
                    new DataAccess.NADataAccess().InsertListData(na, fr);
                    try
                    {
                        DataAccess.TranHelper.CommitTran();
                        context.Response.Write("");
                    }
                    catch (Exception ex)
                    {
                        context.Response.Write("\n数据提交出错!" + ex.Message);
                    }
                }
                else
                    context.Response.Write("该工单状态为已提交，无法继续修改工单信息!");
            }
            catch (Exception ex)
            {
                context.Response.Write("\n" + ex.ToString());
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}