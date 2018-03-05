jQuery(document).ready(function () {

    ///// TRANSFORM CHECKBOX /////							
    jQuery('input:checkbox').uniform();

    ///// LOGIN FORM SUBMIT /////
    jQuery('#login').submit(function () {
        var remember = jQuery('#remember').parent("span").attr("class");
        jQuery.ajax({
            type: "POST",                   //提交方式
            url: "Ajax/Login.ashx",   //提交的页面/方法名
            data: "username=" + jQuery('#username').val() + "&password=" + jQuery('#password').val() + "&remember=" + remember,
            dataType: "json",               //类型
            success: function (data) {
                if (data.error == '') {
                    jQuery('.nousername').hide();
                    window.location.href = "Manager/Frame.aspx";
                } 
                else {
                    jQuery('.nousername').fadeIn();
                    jQuery('#errormsg').html(data.error);
                }
            },
            error: function (err) {
                jQuery('.nousername').fadeIn();
                jQuery('#errormsg').html(err);
            }
        });
        return false;
    });

    ///// ADD PLACEHOLDER /////
    jQuery('#username').attr('placeholder', 'Username');
    jQuery('#password').attr('placeholder', 'Password');
});
