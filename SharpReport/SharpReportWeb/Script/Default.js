function setH(){
   $("#sysMenu").height($("body").innerHeight()-28);
   $("#frameBox_S1 iframe").height($("body").innerHeight()-18);
   $("#frameBox_S2 iframe").height($("body").innerHeight()-$("#dropNav").innerHeight()-39);
   if($("#tabs").length>0){$("#frameBox_S4").css("margin-top","-1px");}
   if($.browser.msie){
	   $("#frameBox_S4").height($("body").innerHeight()-$("#tip").innerHeight()-$("#tabs").innerHeight()-10);
   }
   else if($.browser.mozilla){
	   $("#frameBox_S4").height($("body").innerHeight()-$("#tip").innerHeight()-$("#tabs").innerHeight()-14);
   }
   else{
	   $("#frameBox_S4").height($("body").innerHeight()-$("#tip").innerHeight()-$("#tabs").innerHeight()-12);
   }
  // $(".AccordionPanelContent").height($("body").innerHeight()-31*$(".AccordionPanelTab").length)
   /*var n=20;
   $("dl.SlideBox dd").height($("dl.SlideBox td").innerHeight()*n+n);*/
}
$(document).ready(function(){
	$("#dropNav a:odd").addClass("odd");
	$(".t tr:even").addClass("alt");
	$(".t th").css("border-right","1px solid #FFF");
	$(".t tr").find("td:last").css("border-right","1px solid #FFF");
	$(".form td:last").css("border-bottom","none");
	$("input.btn").parent("span.btn").css("display","inline-block");
    setH();
});
$(window).resize(function(){
	setH();
})