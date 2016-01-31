function setH(){
   $("#SlideBox").height(document.body.clientHeight-$(".toolbar").innerHeight()-1);
   $(".treeBox").height($("body").innerHeight()-$("div").innerHeight()-1);
   $("#panel").height($("body").innerHeight()-$("#tabs").innerHeight());
   var n=20;
   $(".SlideBox dd").height($(".SlideBox td").innerHeight()*n+n+1);
}
$(document).ready(function(){
	if($.browser.msie&$.browser.version=="6.0"){
		if(confirm("您当前使用的浏览器版本过低，可能影响体验，请升级至最新版本！")){
		    window.location.href="http://windows.microsoft.com/zh-cn/internet-explorer/products/ie/home";
		}
	}
	$(".t tr:even").addClass("alt");
    setH();
});
$(window).resize(function(){
	setH();
})