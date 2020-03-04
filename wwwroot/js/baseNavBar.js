
//var myObj = new MyObj();

$(document).ready(function() {  

    chkMsg.chkNewMessage();

});//.ready function


var chkMsg = {
    canFlash: false,
    flashIng: false,
    chkMsgTime: 60*1000,
    fadeTime: 2000,
    chkNewMessage: function(){
        if((location.pathname).indexOf("Message") >=0 || $("#messageLink").length ==0){
            return;
        }
        var successFn = function(res){
            if(res.length > 0){
                $("#messageLink").text("您有新訊息!");
                chkMsg.canFlash = true;
                if(!chkMsg.flashIng){
                    chkMsg.flashText();
                }   
            }else{
                $("#messageLink").text("訊息");
                chkMsg.canFlash = false;
            } 
        };
        myObj.rAjaxFn("post", "/Message/getReceiveMessage?readStatus=0", null, successFn);
        setTimeout("chkMsg.chkNewMessage()", chkMsg.chkMsgTime);
    },
    flashText: function(){
        $("#messageLink").fadeToggle(chkMsg.fadeTime);
        if(chkMsg.canFlash){
            setTimeout("chkMsg.flashText()", chkMsg.fadeTime);
            chkMsg.flashIng = true;
        }else{
            $("#messageLink").show();
            chkMsg.flashIng = false;
        } 
    }
};
