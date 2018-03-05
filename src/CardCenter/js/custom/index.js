jQuery(document).ready(function () {

    ///// TRANSFORM CHECKBOX /////							
    jQuery('input:checkbox').uniform();

    ///// LOGIN FORM SUBMIT /////
    jQuery('#login').submit(function () {
        jQuery.ajax({
            type: "POST",                   //提交方式
            url: "Login.aspx/Verification",   //提交的页面/方法名
            data: "{'userName':'" + jQuery('#username').val() + "','passWord':'" + jQuery('#password').val() + "'}",
            dataType: "json",               //类型
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == 'ok') {
                    jQuery('.nousername').hide();
                    window.location.href = "Index.aspx";
                } 
                else{
                    jQuery('.nousername').fadeIn();
                    jQuery('#msg').text(msg.d);
                }
            },
            error: function (err) {
                jQuery('.nousername').fadeIn();
                jQuery('#msg').text(err);
            }
        });
        return false;
    });

    ///// ADD PLACEHOLDER /////
    jQuery('#username').attr('placeholder', 'Username');
    jQuery('#password').attr('placeholder', 'Password');
});
