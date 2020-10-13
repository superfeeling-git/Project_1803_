var t = n =0, count;
$(document).ready(function(){ 
count=$("#banner_list a").length;
$("div.banner_num ul li:first").addClass("on");
$("#banner_list a:not(:first-child)").hide();
$("#banner>div>ul li").click(function() {
	var i = $(this).text() -1;//获取Li元素内的值，即1，2，3，4
	n = i;
	if (i >= count) return;
	$("#banner_list a").filter(":visible").fadeOut(500).parent().children().eq(i).fadeIn(1000);
	document.getElementById("banner").style.background="";
	$(this).toggleClass("on");
	$(this).siblings().removeAttr("class");
	});
	t = setInterval("showAuto()", 4000);
	$("#banner").hover(function(){clearInterval(t)}, function(){t = setInterval("showAuto()", 4000);});
})

function showAuto()
{
n = n >=(count -1) ?0 : ++n;
$("#banner>div>ul li").eq(n).trigger('click');
}