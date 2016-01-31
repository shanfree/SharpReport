function scrollTabs(){} 
scrollTabs.prototype = { 
    st : function(tabs,divs,openClass,closeClass){
		var temp = this; 
        if(tabs.length!=divs.length){ 
		    alert("菜单层数量和内容层数量不一样!"); 
            return false;
		}                 
        for(var i=0;i<tabs.length;i++){
		    temp.$(tabs[i]).value = i;                 
            temp.$(tabs[i]).onmouseover = function(){
				for(var j=0;j<tabs.length;j++){
					temp.$(tabs[j]).className = closeClass; 
                    temp.$(divs[j]).style.display = "none"; 
                } 
                temp.$(tabs[this.value]).className = openClass;     
                temp.$(divs[this.value]).style.display = "";
			}
		}
	}, 
    $ : function(oid){ 
        if(typeof(oid) == "string") 
        return document.getElementById(oid); 
        return oid; 
    } 
}