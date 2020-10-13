// JavaScript Document
$(function(){
	$("div.foot div.main ul.footnav li:last").css("border","none");
});

function placeholder(css) {
    if (navigator.userAgent.toLowerCase().indexOf("chrome") == -1) {
        $("input").each(function () {
            if (typeof ($(this).attr("placeholder")) != "undefined") {
                var pcolor = "#999999"; //颜色
                placeholder = $(this).attr("placeholder");	
                var temp = "<div name='temp' style='margin:0; padding:0; border:0;color:" + pcolor + ";cursor:text;width:"+($(this).width())+"px;" + css + "'>" + placeholder + "</div>";
                if($(this).attr("id")=="Password")
				{
					var temp = "<div name='temp' style='margin:0;margin-top:-1px; padding:0; border:0;color:" + pcolor + ";cursor:text;width:"+($(this).width())+"px;" + css + "'>" + placeholder + "</div>";
				}
				$(this).hide().after(temp);

                $("div[name=temp]").live("click", function () {
                    $(this).hide().prev().show().focus();
                });

                $(this).live("blur", function () {
                    if ($(this).val() == "") {
                        $(this).hide().next().show();
                    }
                });
            }
        });
    }
}

function showerr(errTitle, errinfo) {
    var jBoxConfig = {};
    jBoxConfig.defaults = {
        id: null, /* 在页面中的唯一id，如果为null则自动生成随机id,一个id只会显示一个jBox */
        top: '40%' /* 窗口离顶部的距离,可以是百分比或像素(如 '100px') */
    };
    $.jBox.setDefaults(jBoxConfig);
    $.jBox.prompt(errinfo, errTitle, 'error');
}

function showinfo(errTitle, errinfo) {
    var jBoxConfig = {};
    jBoxConfig.defaults = {
        id: null, /* 在页面中的唯一id，如果为null则自动生成随机id,一个id只会显示一个jBox */
        top: '40%' /* 窗口离顶部的距离,可以是百分比或像素(如 '100px') */
    };
    $.jBox.setDefaults(jBoxConfig);
    $.jBox.prompt(errinfo, errTitle, 'success');
}

function showtip(url, tiptitle, tipwidth, tipheight, tiptop) {
    // 用iframe显示http://www.baidu.com的内容，并设置了标题、宽与高、按钮
    $.jBox("iframe:" + url + "", {
        title: tiptitle,
        width: tipwidth,
        height: tipheight,
        top: tiptop
    });
}

function addFavorite2() {
        var url = window.location;
        var title = document.title;
        var ua = navigator.userAgent.toLowerCase();
        if (ua.indexOf("360se") > -1) {
            alert("由于360浏览器功能限制，请按 Ctrl+D 手动收藏！");
        } else if (ua.indexOf("msie 8") > -1) {
            window.external.AddToFavoritesBar(url, title); //IE8
        } else if (document.all) {
            try {
                window.external.addFavorite(url, title);
            } catch (e) {
                alert('您的浏览器不支持,请按 Ctrl+D 手动收藏!');
            }
        } else if (window.sidebar) {
            window.sidebar.addPanel(title, url, "");
        } else {
            alert('您的浏览器不支持,请按 Ctrl+D 手动收藏!');
        }
    }