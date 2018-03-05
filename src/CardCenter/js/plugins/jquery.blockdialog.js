; (function($) {

    var _dialogzIndex = 1000;
    var _depth = 0;
    var _currectTag;

    $.open = function(opts) {               

        var fullOpts = $.extend({}, $.defaults, opts || {});

        var _div = "<div id='" + fullOpts.tag + "' style='height:" + fullOpts.height + "px;width:" + fullOpts.width + "px' title='" + fullOpts.title + "'><iframe id='" + fullOpts.tag + "' frameborder='0' height='" + fullOpts.height + "' width='" + fullOpts.width + "' scrolling='no' src='" + fullOpts.url + "'></iframe></div>";

        $.addDialogzIndex(2);

        $.dialogElement(fullOpts.tag).remove();

        //alert($.dialogzIndex());

        $.dialogElement(fullOpts.tag).css('height',fullOpts.height + 45);

        $.maskBody().append(_div);
        $.dialogElement(fullOpts.tag).dialog({
            bgiframe: true,
            autoOpen: false,
            zIndex: $.dialogzIndex(),
            stack: false,
            width: fullOpts.width + 50,
            height: fullOpts.height + 45,
            resizable: false,
            closeOnEscape: true,
            modal: false,
            close: function(event, ui) {
                closeDlg(fullOpts.tag);
                if (fullOpts.isReload != undefined && fullOpts.isReload) {

                    var theForm = self.document.forms[0];
                    if (!theForm) {
                        theForm = self.document.aspnetForm;
                    }

                    if (fullOpts.reloadMode == '' || fullOpts.reloadMode == 'Form') {
                        if (top == self) {
                            self.window.location.href = window.location.href;                         
                        }
                        else {
                             top.$('iframe:eq(' + $.depth() + ')').attr('src', window.location.href);
                             var e = event || window.event;
                              e.returnValue = false;              
                        }
                        
                    }
                    else if (fullOpts.reloadMode == 'postback') {
                            theForm.submit();
                    }
                    else if (fullOpts.reloadMode == 'func') {
                        if (typeof (fullOpts.reloadFunc) == 'function') {
                            fullOpts.reloadFunc();
                        }
                    }
                }
            }
        });

        $.dialogElement(fullOpts.tag).css('height',fullOpts.height + 45);

        if ($.depth() == 0) {
            $.installMask($.dialogzIndex() - 1);
        }
        else {
            $.setMaskzIndex($.dialogzIndex() - 1);
        }

        $.dialogElement(fullOpts.tag).dialog("open");


        $.dialogElement(fullOpts.tag).css('height',fullOpts.height + 45);

        _currectTag = fullOpts.tag;

        $.addDepth(1);
    };

    $.close = function(tag) {
        $.dialogElement(tag).dialog("close",{data:"test"});
    };

    function closeDlg(tag) {

        $.addDepth(-1);
        $.addDialogzIndex(-2);

        //alert($.dialogzIndex() + " " + $.depth());

        if ($.depth() == 0) {
            $.uninstallMask();
        }
        else {
            $.setMaskzIndex($.dialogzIndex() - 1);
        }

        $.dialogElement(tag).dialog("destroy");
        $.dialogElement(tag).remove();
    }

    $.dialogzIndex = function() {
        if (top == self) {
            return _dialogzIndex;
        }
        else {
            return top.$.dialogzIndex();
        }
    };

    $.addDialogzIndex = function(num) {
        if (num != undefined) {
            if (top == self) {
                _dialogzIndex = _dialogzIndex + num;
            }
            else {
                top.$.addDialogzIndex(num);
            }
        }

    };

    $.depth = function() {
        if (top == self) {
            return _depth;
        }
        else {
            return top.$.depth();
        }
    };

    $.addDepth = function(num) {
        if (num != undefined) {
            if (top == self) {
                _depth = _depth + num;
            }
            else {
                top.$.addDepth(num);
            }
        }
    };

    $.dialogElement = function(tag) {
        if (top == self)
            return $("#" + tag);
        else
            return top.$("#" + tag);
    };

    $.maskBody = function() {
        if (top == self)
            return $("body:eq(0)");
        else
            return top.$("body:eq(0)");
    };

    $.maskElement = function() {
        if (top == self)
            return $('.ui-overlay:first');
        else
            return $('.ui-overlay:first', top.document);
    };

    $.installMask = function(zindex) {
        try {



            var overlay = top.$('<div class="ui-overlay"  style="position: absolute; top: 0pt; left: 0pt; display: inline-block; overflow: hidden;"><div class="ui-widget-overlay" style="top: 0pt; left: 0pt;"></div></div>').hide().appendTo(top.$("body:eq(0)"));
            overlay.width($(top.document).width());
            overlay.height($(top.document).height());
            overlay.css('z-index', zindex);
            $(overlay).show();

            $(window).resize(function() {
                overlay.width($(top.document).width());
                overlay.height($(top.document).height());
            });
        }
        catch (e) {
            alert(e);
        }
    };

    $.uninstallMask = function() {
        $.maskElement().hide();
        $.maskElement().remove();
    };

    $.setMaskzIndex = function(zindex) {
        $.maskElement().css('z-index', zindex);
    };

    $.defaults = {
        width: 500,
        height: 500,
        title: 'notitle',
        url: '#',
        tag: 'notag',
        isReload: true,
        reloadMode: '',
        reloadFunc: ''
    };

})(jQuery);