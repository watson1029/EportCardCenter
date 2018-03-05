function ReportInterface(type, cycle, divName, IsEx, IsDisplay) {
    jQuery.ajax({
        type: "POST",                   //提交方式
        url: "/ajax/ReportHandle.ashx?type=" + type + "&cycle=" + cycle,   //提交的页面/方法名
        dataType: "json",               //类型
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            if (IsEx == true) 
                ReportInitEx(result, divName);
            else
                ReportInit(result, divName);
            if (IsDisplay == false)
                jQuery("#" + divName).parent().parent().css("display", "none");
        },
        error: function (err) {
            alert(err);
        }
    });
}

function ReportInit(result, divID) {
    function showTooltip(x, y, contents) {
        jQuery('<div id="tooltip" class="tooltipflot">' + contents + '</div>').css({
            position: 'absolute',
            display: 'none',
            top: y - 30,
            left: x
        }).appendTo("body").fadeIn(200);
    }
    function formatDate(now) {
        var d = new Date(now);
        var month = d.getMonth() + 1;
        var date = d.getDate();
        return month + "月" + date + "号";
    }
    var plot = jQuery.plot(jQuery("#" + divID),
			   [{ 'data': result.data, 'label': result.label, 'color': result.color}], {
			       series: {
			           lines: { show: true, fill: true, fillColor: { colors: [{ opacity: 0.05 }, { opacity: 0.15}]} },
			           points: { show: true }
			       },
			       legend: { position: 'nw' },
			       grid: { hoverable: true, clickable: true, borderColor: '#ccc', borderWidth: 1, labelMargin: 10 },
			       xaxis: { mode: "time", timeformat: "%m-%d" },
			       yaxis: { min:0 }
			   });

    var previousPoint = null;
    jQuery("#" + divID).bind("plothover", function (event, pos, item) {
        jQuery("#x").text(pos.x.toFixed(2));
        jQuery("#y").text(pos.y.toFixed(2));

        if (item) {
            if (previousPoint != item.dataIndex) {
                previousPoint = item.dataIndex;

                jQuery("#tooltip").remove();
                var x = formatDate(item.datapoint[0]),
					                y = item.datapoint[1];
                showTooltip(item.pageX, item.pageY,
									x + item.series.label + " : " + y + "次");
            }

        } else {
            jQuery("#tooltip").remove();
            previousPoint = null;
        }

    });

    jQuery("#" + divID).bind("plotclick", function (event, pos, item) {
        if (item) {
            jQuery("#clickdata").text("You clicked point " + item.dataIndex + " in " + item.series.label + ".");
            plot.highlight(item.series, item.datapoint);
        }
    });
}

function ReportInitEx(result, divID) {
    function showTooltip(x, y, contents) {
        jQuery('<div id="tooltip" class="tooltipflot">' + contents + '</div>').css({
            position: 'absolute',
            display: 'none',
            top: y - 30,
            left: x
        }).appendTo("body").fadeIn(200);
    }
    function formatDate(now) {
        var d = new Date(now);
        var year = d.getFullYear();
        var month = d.getMonth() + 1;
        return year + "年" + month + "月";
    }
    var plot = jQuery.plot(jQuery("#" + divID),
			   [{ 'data': result.data, 'label': result.label, 'color': result.color}], {
			       series: {
			           lines: { show: true, fill: true, fillColor: { colors: [{ opacity: 0.05 }, { opacity: 0.15}]} },
			           points: { show: true }
			       },
			       legend: { position: 'nw' },
			       grid: { hoverable: true, clickable: true, borderColor: '#ccc', borderWidth: 1, labelMargin: 10 },
			       xaxis: { mode: "time", timeformat: "%y-%m" },
                   yaxis: { min:0 }
			   });

    var previousPoint = null;
    jQuery("#" + divID).bind("plothover", function (event, pos, item) {
        jQuery("#x").text(pos.x.toFixed(2));
        jQuery("#y").text(pos.y.toFixed(2));

        if (item) {
            if (previousPoint != item.dataIndex) {
                previousPoint = item.dataIndex;

                jQuery("#tooltip").remove();
                var x = formatDate(item.datapoint[0]),
					                y = item.datapoint[1];
                showTooltip(item.pageX, item.pageY,
									x + item.series.label + " : " + y + "次");
            }

        } else {
            jQuery("#tooltip").remove();
            previousPoint = null;
        }

    });

    jQuery("#" + divID).bind("plotclick", function (event, pos, item) {
        if (item) {
            jQuery("#clickdata").text("You clicked point " + item.dataIndex + " in " + item.series.label + ".");
            plot.highlight(item.series, item.datapoint);
        }
    });
}