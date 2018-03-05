jQuery(document).ready(function () {

    ///// TRANSFORM CHECKBOX /////							
    jQuery('input:checkbox').uniform();

    ///// LOGIN FORM SUBMIT /////
    jQuery('#login').submit(function () {
        jQuery.ajax({
            type: "POST",                   //�ύ��ʽ
            url: "Login.aspx/Verification",   //�ύ��ҳ��/������
            data: "{'userName':'" + jQuery('#username').val() + "','passWord':'" + jQuery('#password').val() + "'}",
            dataType: "json",               //����
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
