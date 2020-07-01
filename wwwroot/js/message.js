﻿
var myObj = new MyObj();

$(document).ready(function() {   
    init();
    $("#writeMsgDiv").on("change", "#selReceiveDepart", function(){
        $("#selReceiveID").empty().append(new Option("請選擇", "")).append(new Option("全體", "-1"));
        var departSel = $("#selReceiveDepart").val();
        if(departSel == "" || departSel == 0){  
            return;
        }
        setReceiveOption(departSel);
    });

    $(".message_table").on("change", "#msgProcess", function(){
        if($(this).val()=="read"){
            setHadRead();
        }else if($(this).val()=="del"){
            delMsg();
        }
    });

    $("#selAllChkBox").on("click", function(){
        if($(this).prop("checked")){
            $("#messageList").find("input[type='checkbox']").prop("checked", true);
        }else{
            $("#messageList").find("input[type='checkbox']").prop("checked", false);
        }
    });

});//.ready function


function showMessagePage(page){
    window.location.href = "/Message/Index?page="+page;
}

function init(){
    if($("#newMsgDiv").length >0){
        getReceiveMessage(0);
    }else if($("#allMsgDiv").length >0){
        getReceiveMessage(1);
    }else if($("#backupMsgDiv").length >0){
        getSendMessage();
    }else if($("#writeMsgDiv").length >0){
        getReceiveOption();
    }
}



//#region new all backup message
function getReceiveMessage(read){
    var successFn = function(res){
        refreshMessage(res);     
    };
    myObj.rAjaxFn("post", "/Message/getReceiveMessage?readStatus="+read, null, successFn);
}

function getSendMessage(){
    var successFn = function(res){
        refreshMessage(res);
    };
    myObj.rAjaxFn("post", "/Message/getSendMessage", null, successFn);
}

function refreshMessage(res){
    $("#selAllChkBox").prop("checked", false);
    $("#msgProcess").find("option[value='']").prop("selected", true);
    var msgID = 0;
    var receiveName = "";
    $("#messageList").empty();
    res.forEach(function(value){
        if(value.messageID != msgID){   //若同時寄很多人 也只要出現一次該信件
            msgID = value.messageID;
            var row = $(".template").find("[name='receiveMsgRow']").clone();
            var dt = myObj.dateTimeFormat(value.createTime);
            var dtTD = row.find("[name='dateTime']").text(dt.ymdText + "\n" + dt.hmText);
            dtTD.html(dtTD.html().replace(/\n/g, "<br/>"));
         
            row.find("[name='title']").find('a').attr("onclick", `showContent(this, ${value.id});`)
                                                .data("read", value.read).text(value.title);
            row.find("[name='sendName']").text(value.userName);

            var receiveTD = $("#messageList").find("td[data-tmp='tmp']");
            if($(receiveTD).length >0){
                receiveTD.text(receiveName);
                receiveTD.removeAttr("data-tmp");
            }
            
            row.find("[name='receiveName']").attr("data-tmp","tmp");
            receiveName = value.userName;

            row.find("input[name='msgChkBox']").val(value.id);
            $("#messageList").append(row);

            var textRow = $(".template").find("[name='msgContentRow']").clone();
            textRow.find("[name='content']").attr("data-id", value.id).text(value.content).hide();
            $("#messageList").append(textRow);
        }else{
           receiveName += ", " + value.userName;    //串收件人
        }
    });
    var receiveTD = $("#messageList").find("td[data-tmp='tmp']");
    if($(receiveTD).length >0){
        receiveTD.text(receiveName);
        receiveTD.removeAttr("data-tmp");
    }
}

function showContent(thisLink, relatedID){    //relatedID = msgID
    $("#messageList").find(`[data-id='${relatedID}']`).toggle();
    if($(thisLink).data("read") == 1 || $("#backupMsgDiv").length >0){
        return;
    }
    var msgID = [relatedID];
    var successFn = function(res){
        if(res==1){
            $(thisLink).data("read", 1);
        }
    };
    myObj.cudAjaxFn("/Message/setHadReadMsg", {msgID}, successFn);  //標示已讀
}

function setHadRead(){
    var msgID = [];
    var hasChkMsg = $("#messageList").find("input[name='msgChkBox']:checked");
    $.each(hasChkMsg, function(key, obj){
        msgID.push($(obj).val());
    });
    if(msgID.length == 0){
        $("#msgProcess").find("option[value='']").prop("selected", true);
        return;
    }

    var msg = "您確定要把訊息設為已讀嗎？\n\n請確認！";
    if(confirm(msg)==false){ 
        $("#msgProcess").find("option[value='']").prop("selected", true);
        return;
    }
    var successFn = function(res){
        getReceiveMessage(0);
    };
    myObj.cudAjaxFn("/Message/setHadReadMsg", {msgID}, successFn);
}

function delMsg(){
    var msgID = [];
    var hasChkMsg = $("#messageList").find("input[name='msgChkBox']:checked");
    $.each(hasChkMsg, function(key, obj){
        msgID.push($(obj).val());
    });
    if(msgID.length == 0){
        $("#msgProcess").find("option[value='']").prop("selected", true);
        return;
    }

    var msg = "您真的確定要刪除訊息嗎？\n\n請確認！";
    if(confirm(msg)==false){ 
        $("#msgProcess").find("option[value='']").prop("selected", true);
        return;
    }
    var successFn = function(res){
        if($("#allMsgDiv").length >0){
            getReceiveMessage(1);
        }else if($("#newMsgDiv").length >0){
            getReceiveMessage(0);
        }else if($("#backupMsgDiv").length >0){
            getSendMessage();
        }
    };
    if($("#allMsgDiv").length >0 || $("#newMsgDiv").length >0){
        var sel="rDel"
    }else if($("#backupMsgDiv").length >0){
        var sel="sDel"
    }
    myObj.cudAjaxFn("/Message/delMessage", {msgID, sel}, successFn);
}

//#endregion new all message

//------------------------------------------------------------------------------------------------------------

//#region write message

function getReceiveOption(){
    var successFn = function(res){
        refreshSelOption(res);
    };
    myObj.rAjaxFn("post", "/Message/getReceiveOption", null, successFn);
}

function refreshSelOption(res){
    var departName = "";
    myObj.departAndEmployee = res;
    res.forEach(function(value){
        if(value.department != departName){
            $("#selReceiveDepart").append(new Option(value.department, value.department));
            departName = value.department;
        }
    });
}

function setReceiveOption(departSel){
    myObj.departAndEmployee.forEach(function(value){
        if(value.department == departSel && value.userName != null){
            $("#selReceiveID").append(new Option(value.userName, value.accID));
        }
    });
}

function sendMsg(){
    var title = $("#msgTitle").val();
    var content = $("#content").val();
    var depart = $("#selReceiveDepart").val();
    var receiveID = $("#selReceiveID").val();
    
    if((depart == "" || depart != -1) && receiveID == ""){
        alert("請選擇收信人");
        return;
    }
    var data = {
        title, content, depart, receiveID
    };
    var successFn = function(res){
        if(res >0){
            alert("寄信成功");
            clearMsg();
        }else{
            alert("寄信失敗");
        }    
    };
    myObj.rAjaxFn("post", "/Message/sendMsg", data, successFn);
}

function clearMsg(){
    $("#msgTitle,#content").val("");
    $("#selReceiveDepart").find("option[value='']").prop("selected", true);
    $("#selReceiveID").empty().append(new Option("請選擇", "")).append(new Option("全體", "-1"));
}


//#endregion write message






