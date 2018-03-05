//添加错误样式
function addError(obj) {
    jQuery("#" + obj).addClass("error");
    jQuery("#" + obj).focus();
    
}
//移除错误样式
function removeError(obj) {
    jQuery("#" + obj).removeClass("error");
}

//检查是否为空
function IsEmpty(obj, name) {
    var val = jQuery("#" + obj).val();
    if (val == "") {
        jAlert(name + "不能为空!", "提示", function () {
            addError(obj);
        });
        return true;
    }
    else {
        removeError(obj);
        return false;
    }
}

//检查是否超出长度
function IsMore(obj, len, name) {
    var val = jQuery("#" + obj).val();
    if (val.length > len) {
        jAlert(name + "超出" + len + "位长度限制!", "提示", function () {
            addError(obj);
        });
        return true;
    }
    else {
        removeError(obj);
        return false;
    }
}

//检查长度是否符合
function IsLenMatch(obj, len, name) {
    var val = jQuery("#" + obj).val();
    if (val.length != len) {
        jAlert(name + "为" + len + "位字符!", "提示", function () {
            addError(obj);
        });
        return false;
    }
    else {
        removeError(obj);
        return true;
    }
}

//检查是否选择下拉框
function IsSelect(obj, name) {
    var val = jQuery("#" + obj).val();
    if (val == "") {
        jAlert("请下拉选择" + name + "!", "提示", function () {
            addError(obj + "_chzn");
        });
        return false;
    }
    else {
        removeError(obj + "_chzn");
        return true;
    }
}
/**
*检查手机号码或者电话号码
*
*/
function isPhone(str) {
    var reg = /^1[3|4|5|7|8]\d{9}$/;
    return reg.test(str);
}

function IsPhoneSpan(id, len, name) {
    var val = document.getElementById(id);
    if (IsEmpty(id, name)) {
        return false;
    }
    else if (IsMore(id, len, name)) {
        return false;
    }
    else if (!isPhone(val.value)) {
        jAlert(name + "格式不正确!", "提示", function () {
            addError(id);
        });
        return false;
    }
    else {
        removeError(id);
        return true;
    }
}

/**
*检查是否为数字
*
*/
function isDecimal(str) {
   
    var reg = /^\d+(\.\d+)?$/;
    return reg.test(str);
}

function isNum(str) {
    var reg = /^[\d]+$/;
    return reg.test(str);
}

function IsDecimalSpan(id, name) {
    var val = document.getElementById(id);
    if (IsEmpty(id, name)) {
        return false;
    } else if (!isDecimal(val.value)) {
        jAlert(name + "格式不正确!", "提示", function () {
            addError(id);
        });
        return false;
    }
    else {
        removeError(id);
        return true;
    }
}

function IsNumSpan(id, name) {
    var val = document.getElementById(id);
    if (IsEmpty(id, name)) {
        return false;
    } else if (!isNum(val.value)) {
        jAlert(name + "格式不正确!", "提示", function () {
            addError(id);
        });
        return false;
    }
    else {
        removeError(id);
        return true;
    }
}


/**  
* 检查是否为电子邮件  
*  
* @param {}  
*            str  
* @return {Boolean} true：电子邮件，false:<b>不是</b>电子邮件;  
*/
function isEmail(str) {
    var reg = /^([a-zA-Z0-9]+[_|\-|\.]?)*[a-zA-Z0-9]+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return reg.test(str);
}

function IsEmailSpan(id, len, name) {
    var val = document.getElementById(id);
    if (IsEmpty(id, name)) {
        return false;
    }
    else if (IsMore(id, len, name)) {
        return false;
    }
    else if (!isEmail(val.value)) {
        jAlert(name + "格式不正确!", "提示", function () {
            addError(id);
        });
        return false;
    } else {
        removeError(id);
        return true;
    }
}

function IsEmailSpanEx(id, len, name) {
    var val = document.getElementById(id);
    if (IsEmpty(id, name)) {
        return false;
    }
    else if (IsMore(id, len, name)) {
        return false;
    }
    else if (!isEmail(val.value)) {
        jAlert("仅限使用163、126、qq、sina、sohu邮箱接收电子发票信息！", "提示", function () {
            addError(id);
        });
        return false;
    } else {
        removeError(id);
        return true;
    }
}

//判断日期大小(id1早于id2返回true)
function DateCompare(id1, name1, id2, name2) {
    if (Date.parse(jQuery("#" + id1).val()) > Date.parse(jQuery("#" + id2).val())) {
        jAlert(name1 + "必须早于" + name2 + "!", "提示", function () {
            addError(id2);
            addError(id1);
        });
        return false;
    }
    else {
        removeError(id1);
        removeError(id2);
        return true;
    }
}


//..自己加还需要的校验方法

function JobHeadStep2Verifi() {
    //表头第二步表单逻辑校验
    if (IsEmpty("agentName", "经办人姓名")) 
        return false;
    if (IsMore("agentName", 32, "经办人姓名"))
        return false;
    //if (IsEmpty("agentID", "经办人证件号码"))
    //    return false;
    //if (IsMore("agentID", 32, "经办人证件号码"))
    //    return false;
    if (!IsPhoneSpan("agentPhone", 32, "经办人手机"))
        return false;
    //if (IsEmpty("companyName", "企业名称"))
    //    return false;
    //if (IsMore("companyName", 256, "企业名称"))
    //    return false;
    //if (IsEmpty("companyAddress", "企业地址"))
    //    return false;
    //if (IsMore("companyAddress", 256, "企业地址"))
    //    return false;
    //if (jQuery("#typeSelect").val() == "1") {
    //    if (!IsLenMatch("companyCode", 9, "企业代码（组织机构代码）"))
    //        return false;
    //}
    //else {
    //    if (!IsLenMatch("companyCode", 18, "企业代码（社会统一信用编号）"))
    //        return false;
    //}
    
    return true;
}

function JobHeadStep3Verifi() {
    //表头第三步表单逻辑校验
    if (IsEmpty("consigneeName", "收货人姓名"))
        return false;
    if (IsMore("consigneeName", 32, "收货人姓名"))
        return false;
    if (!IsPhoneSpan("consigneePhone", 32, "收货人手机"))
        return false;
    if (IsEmpty("consigneeAddress", "收货人地址"))
        return false;
    if (IsMore("consigneeAddress", 512, "收货人地址"))
        return false;
    return true;
}

function JobHeadInvoiceVerifi() {
    if (IsEmpty("txtInvoiceName", "发票收件人"))
        return false;
    if (IsMore("txtInvoiceName", 32, "发票收件人"))
        return false;
    if (!IsPhoneSpan("txtInvoicePhone", 32, "发票收件人手机"))
        return false;
    if (IsEmpty("txtInvoiceAddress", "发票收件地址"))
        return false;
    if (IsMore("txtInvoiceAddress", 512, "发票收件地址"))
        return false;
    if (!IsLenMatch("txtInvoicePostCode", 6, "发票收件地址邮政编码"))
        return false;
    if (IsEmpty("txtInvoiceCode", "纳税人识别号（18位统一社会信用代码）"))
        return false;
    if (IsMore("txtInvoiceCode", 18, "纳税人识别号（18位统一社会信用代码）"))
        return false;
    if (!IsEmailSpanEx("txtInvoiceEmail", 64, "发票电子邮箱"))
        return false;
    return true;
}

function JobHeadSaveVerifi() {
    //表头保存表单逻辑校验
    if (!JobHeadStep2Verifi())
        return false;
    if ($("input:radio[name='expressflat']:checked").val() != "上门领取") {
        if (!JobHeadStep3Verifi())
            return false;
    }
    return true;
}

function JobHeadSaveVerifiEx() {
    //表头保存表单逻辑校验
    if (!JobHeadStep2Verifi())
        return false;
    return true;
}

function UUJobListSaveVerifi() {
    //更新解锁表体保存表单逻辑校验
    if (!IsLenMatch("txtCardNum", 13, "卡号"))
        return false;
    if (IsEmpty("holdName", "持卡人姓名"))
        return false;
    if (IsMore("holdName", 32, "持卡人姓名"))
        return false;
    return true;
}

function MDJobListSaveVerifi() {
    //变更表体保存表单逻辑校验
    if (IsEmpty("holdName", "新持卡人姓名"))
        return false;
    if (IsMore("holdName", 32, "新持卡人姓名"))
        return false;
    if (!IsLenMatch("txtCardNum", 13, "卡号"))
        return false;
    return true;
}

function RIJobListSaveVerifi() {
    //补办表体保存表单逻辑校验
    if (IsEmpty("holdName", "持卡人姓名"))
        return false;
    if (IsMore("holdName", 32, "持卡人姓名"))
        return false;
    return true;
}

function RMJobListSaveVerifi() {
    //重制表体保存表单逻辑校验
    if (IsEmpty("holdName", "持卡人姓名"))
        return false;
    if (IsMore("holdName", 32, "持卡人姓名"))
        return false;
    return true;
}

function SLJobListSaveVerifi() {
    //销售表体保存表单逻辑校验
    if (IsEmpty("hCommodityID", "安全产品类型"))
        return false;
    return true;
}

function NAJobListSaveVerifi() {
    //新增其他卡表体保存表单逻辑校验
    if (IsEmpty("holdName", "持卡人姓名"))
        return false;
    if (IsMore("holdName", 32, "持卡人姓名"))
        return false;
    if (!IsPhoneSpan("txtCardholderPhone", 32, "持卡人手机号"))
        return false;
    if (IsEmpty("holdID", "持卡人证件号码"))
        return false;
    if (IsMore("holdID", 32, "持卡人证件号码"))
        return false;
    return true;
}


function FRSaveVerifi() {
    //必填项校验
    if (!IsLenMatch("txtSHTYXYDM_QS", 18, "统一社会信用代码"))
        return false;
    if (IsEmpty("txtQYZWMC_QS", "企业中文名称"))
        return false;
    if (IsMore("txtQYZWMC_QS", 256, "企业中文名称"))
        return false;
    if (IsEmpty("txtQYDZ_QS", "企业地址"))
        return false;
    if (IsMore("txtQYDZ_QS", 512, "企业地址"))
        return false;
    if (IsEmpty("txtFDDBR_QS", "法定代表人"))
        return false;
    if (IsMore("txtFDDBR_QS", 32, "法定代表人"))
        return false;
    if (!IsDecimalSpan("txtZCZJ_QS", "注册资金（万）"))
        return false;
    if (IsEmpty("txtZJHM_QS", "证件号码"))
        return false;
    if (IsMore("txtZJHM_QS", 32, "证件号码"))
        return false;
    if (IsEmpty("txtYYQX_QS", "营业期限"))
        return false;
    if (IsMore("txtYYQX_QS", 32, "营业期限"))
        return false;
    if (IsEmpty("dtFZRQ_QS", "发证日期"))
        return false;
    if (IsEmpty("dtCLRQ_QS", "成立日期"))
        return false;
    if (!DateCompare("dtCLRQ_QS", "成立日期", "dtFZRQ_QS", "发证日期"))
        return false;
    if (IsEmpty("txtJYFW_QS", "经营范围"))
        return false;
    if (IsMore("txtJYFW_QS", 4000, "经营范围"))
        return false;
    if (IsEmpty("txtQYJYLX_WJM", "企业（经营者）类型"))
        return false;
    if (IsMore("txtQYJYLX_WJM", 32, "企业（经营者）类型"))
        return false;
    if (IsEmpty("txtKHYH_HG", "开户银行"))
        return false;
    if (IsMore("txtKHYH_HG", 256, "开户银行"))
        return false;
    if (IsEmpty("txtYHZH_HG", "银行账号"))
        return false;
    if (IsMore("txtYHZH_HG", 32, "银行账号"))
        return false;
    if (IsEmpty("txtJCKQYDM_WJM", "进出口企业代码"))
        return false;
    if (IsMore("txtJCKQYDM_WJM", 32, "进出口企业代码"))
        return false;
    if (IsEmpty("dtFZRQ_WJM", "发证（备案）日期"))
        return false;
    //内资外资标记校验
    if (jQuery("#selectNW").val() == "1")
    {
        if (IsEmpty("txtBADJBBH_WJM_R", "备案登记表编号"))
            return false;
        if (IsMore("txtBADJBBH_WJM_R", 32, "备案登记表编号"))
            return false;
        if (IsEmpty("txtRMBZCZJ_WH_R", "人民币注册资金（万）"))
            return false;
       if (!IsDecimalSpan("txtRMBZCZJ_WH_R", "人民币注册资金（万）"))
            return false;
    }
    else
    {
        if (IsEmpty("txtPZWH_WJM_R", "批准文号"))
            return false;
        if (IsMore("txtPZWH_WJM_R", 256, "批准文号"))
            return false;
        if (IsEmpty("dtPZRQ_WJM_R", "批准日期"))
            return false;
        if (IsEmpty("txtJYNX_WJM_R", "经营年限（年）"))
            return false;
        if (!IsNumSpan("txtJYNX_WJM_R", "经营年限（年）"))
            return false;
        if (IsEmpty("txtTZZE_WJM_R", "投资总额（万）"))
            return false;
        if (!IsDecimalSpan("txtTZZE_WJM_R", "投资总额（万）"))
            return false;
        if (IsEmpty("txtWBZCZJ_WH_R", "外币注册资金（万）"))
            return false;
        if (!IsDecimalSpan("txtWBZCZJ_WH_R", "外币注册资金（万）"))
            return false;
    }
    //非必填项校验
    if (IsMore("txtQYYWMC_QS", 256, "企业英文名称"))
        return false;
    if (jQuery("#txtFRDH_QS").val() != "") {
        if (!IsPhoneSpan("txtFRDH_QS", 32, "法人电话"))
            return false;
    }
    if (jQuery("#txtYZBM_QS").val() != "") {
        if (!IsLenMatch("txtYZBM_QS", 6, "邮政编码"))
            return false;
    }
    if (jQuery("#txtCZ_QS").val() != "") {
        if (!IsPhoneSpan("txtCZ_QS", 32, "传真"))
            return false;
    }
    if (IsMore("txtFZJGMC_QS", 256, "发证机构名称"))
        return false;
    if (jQuery("#txtHGZCH_HG").val() != "") {
        if (!IsLenMatch("txtHGZCH_HG", 10, "海关注册号"))
            return false;
    }
    if (jQuery("#txtBAHG_HG").val() != "") {
        if (!IsLenMatch("txtBAHG_HG", 4, "备案海关"))
            return false;
    }
    if (IsMore("txtDWDZ_HG", 512, "对外英文地址"))
        return false;
    if (IsMore("txtJCKQPZJG_HG", 256, "进出口权批准机关"))
        return false;
    if (IsMore("txtZJL_HG", 32, "总经理"))
        return false;
    if (jQuery("#txtDH_HG").val() != "") {
        if (!IsPhoneSpan("txtDH_HG", 32, "电话"))
            return false;
    }
    if (jQuery("#txtMSE_HG").val() != "") {
        if (!IsDecimalSpan("txtMSE_HG", "免税额"))
            return false;
    }
    if (IsMore("txtZYCP_HG", 4000, "主要产品"))
        return false;
    if (jQuery("#txtDWZBZE_HG").val() != "") {
        if (!IsDecimalSpan("txtDWZBZE_HG", "到位资本总额（万）"))
            return false;
    }
    if (jQuery("#txtNXBL_HG").val() != "") {
        if (!IsDecimalSpan("txtNXBL_HG", "内销比例"))
            return false;
    }
    if (IsMore("txtZGBM_WJM", 256, "主管部门"))
        return false;
    if (IsMore("txtZS_WJM", 512, "住所"))
        return false;
    if (jQuery("#txtDZYX_WJM").val() != "") {
        if (!IsEmailSpan("txtDZYX_WJM", 256, "电子邮箱"))
            return false;
    }
    if (jQuery("#txtZCZJ_WJM").val() != "") {
        if (!IsDecimalSpan("txtZCZJ_WJM", "注册资金（折美元）"))
            return false;
    }
    if (IsMore("txtJCKSPML_WJM", 4000, "进出口商品目录"))
        return false;
    if (IsMore("txtBZ_WJM", 4000, "备注"))
        return false;
    if (IsMore("txtHXLXR_WH", 32, "核销联系人"))
        return false;
    if (IsMore("txtWMZSH_WH", 32, "外贸证书号"))
        return false;
    if (jQuery("#selectNW").val() == "1")
    {
        if (IsMore("txtPZWH_WJM_NR", 256, "批准文号"))
            return false;
        if (jQuery("#txtJYNX_WJM_NR").val() != "") {
            if (!IsNumSpan("txtJYNX_WJM_NR", "经营年限（年）"))
                return false;
        }
        if (jQuery("#txtTZZE_WJM_NR").val() != "") {
            if (!IsDecimalSpan("txtTZZE_WJM_NR", "投资总额（万）"))
                return false;
            if (!IsSelect("dlTZBZ_WJM_NR", "投资币制"))
                return false;
        }
        if (jQuery("#txtWBZCZJ_WH_NR").val() != "") {
            if (!IsDecimalSpan("txtWBZCZJ_WH_NR", "外币注册资金（万）"))
                return false;
            if (!IsSelect("dlWBZCBZ_WH_NR", "外币注册币种"))
                return false;
        }
    }
    else
    {
        if (IsMore("txtBADJBBH_WJM_NR", 32, "备案登记表编号"))
            return false;
        if (jQuery("#txtRMBZCZJ_WH_NR").val() != "") {
            if (!IsDecimalSpan("txtRMBZCZJ_WH_NR", "人民币注册资金（万）"))
                return false;
        }
    }
    return true;
}

function NWChange(id) {
    if (id == 1) {
        jQuery(".itemRequiredNZ").show();
        jQuery(".itemRequiredWZ").hide();
        jQuery(".itemNotRequiredNZ").hide();
        jQuery(".itemNotRequiredWZ").show();
    }
    else {
        jQuery(".itemRequiredNZ").hide();
        jQuery(".itemRequiredWZ").show();
        jQuery(".itemNotRequiredNZ").show();
        jQuery(".itemNotRequiredWZ").hide();
    }
}