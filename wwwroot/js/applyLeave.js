
var myObj = new MyObj();

$(document).ready(function() {  
    
    getApplyLeave();

    $("#applyLeaveDiv").on("change", "select[name='newApplyType']", function(){
        var val = $(this).val();
        if($(this).val() == -1){
            $("#applyLeaveDiv").find(".newRestType").show();
        }else{
            $("#applyLeaveDiv").find(".newRestType").hide();
        }
    });

    $("#searchFilterDiv").on("click", "[name='searchFilterBtn']", function(){
        getApplyLeave();
    });

});//.ready function


function showApplyLeavePage(page=""){
    window.location.href = "/ApplyLeave/Index?page="+page;  
}


//#region applyLeave

function getApplyLeave(){
    var page = $("#applyLeaveDiv").length > 0 ? 0 : 1;

    var sDate = $("#filter_sDate").val();
    var eDate = $("#filter_eDate").val();
    if(((sDate == "" && eDate == "") || (sDate != "" && eDate != "")) && sDate <= eDate){
        var successFn = function(res){
            if(page==0){
                refreshApplyLeaveIng(res);
            }else{
                refreshApplyLeaveLog(res);
            } 
        };
        var data ={
            page : page,
            sDate : sDate,
            eDate : eDate
        };
        myObj.rAjaxFn("post", "/ApplyLeave/getMyApplyLeave", data, successFn);
    }else{
        alert("搜尋日期格式有誤");  return;
    }
}

function refreshApplyLeaveIng(res){
    $("#applyLeaveDiv").find("a.add_applyLeave").show();
    $('.btnActive').css('pointer-events', "");
    $("#applyLeaveList").empty();
    res.forEach(function(value){
        var row = $(".template").find("[name='applyLeaveRow']").clone();
        var addTime = myObj.dateTimeFormat(value.createTime);
        var dateTD = row.find("[name='applyDate']").text(addTime.ymdText + "\n" + addTime.hmText);
        dateTD.html(dateTD.html().replace(/\n/g, "<br/>"));
        row.find("input[name='applyTypeVal']").val(value.applyType);
        var type = "";
        switch(value.applyType){
            case 1: type="出差"; break;
            case 2: type="外出"; break;
            case 3: type="特休"; break;
            case 4: type="事假"; break;
            case 5: type="病假"; break;
            case 6: type="公假"; break;
            case 7: type="調休"; break;
            case 8: type="喪假"; break;
            case 9: type="婚假"; break;
            case 10: type="產假"; break;
            case 11: type="陪產假"; break;
            case 12: type="其他"; break;
        };
        row.find("[name='applyType']").text(type);
        row.find("[name='note']").text(value.note);

        var sTime = myObj.dateTimeFormat(value.startTime);
        var sTimeTD = row.find("[name='startTime']").text(sTime.ymdText + "\n" + sTime.hmText);
        sTimeTD.html(sTimeTD.html().replace(/\n/g, "<br/>"));
        var eTime = myObj.dateTimeFormat(value.endTime);
        var eTimeTD = row.find("[name='endTime']").text(eTime.ymdText + "\n" + eTime.hmText);
        eTimeTD.html(eTimeTD.html().replace(/\n/g, "<br/>"));

        row.find(".edit_applyLeave").attr("onclick","editApplyLeave(this,"+value.id+");");
        row.find(".del_applyLeave").attr("onclick","delApplyLeave("+value.id+");");
        $("#applyLeaveList").append(row);
    });
}

function showAddApplyLeaveRow(){
    $("#applyLeaveDiv").find("a.add_applyLeave").hide();
    $('.btnActive').css('pointer-events', "none"); 
    var addApplyLeaveRow = $(".template").find("[name='addApplyLeaveRow']").clone();
    //var dt = myObj.dateTimeFormat();
    //var dateText = dt.year + "/" + dt.month + "/" + dt.day + " " + dt.hour + ":" + dt.minute;
    addApplyLeaveRow.find("[name='newApplyDate']").text();
    addApplyLeaveRow.find("a.up_applyLeave").remove();
    addApplyLeaveRow.find("a.add_applyLeave").attr("onclick", "createApplyLeave(this);");
    addApplyLeaveRow.find("a.cel_applyLeave").attr("onclick", "cancelApplyLeave();");
    $('#applyLeaveList').append(addApplyLeaveRow);
}

function createApplyLeave(thisBtn){
    var thisRow =  $(thisBtn).closest("tr[name='addApplyLeaveRow']");
    var applyTypeVal = thisRow.find("[name='newApplyType']").val();
    applyTypeVal = applyTypeVal == -1? thisRow.find("[name='newRestType']").val() : applyTypeVal;
    var startDate = thisRow.find("[name='newStartDate']").val();
    var startTime = thisRow.find("[name='newStartTime']").val();
    var endDate = thisRow.find("[name='newEndDate']").val();
    var endTime = thisRow.find("[name='newEndTime']").val();
    if(applyTypeVal=="" || startDate=="" || startTime=="" || endDate=="" || endTime==""){
        alert("申請類別或時間未填寫"); return;
    }

    var data = {
        applyType : applyTypeVal,
        note : thisRow.find("[name='newApplyNote']").val(), 
        startTime : startDate + "T" + startTime,
        endTime : endDate + "T" + endTime,
    };
    var successFn = function(res){
        cancelApplyLeave();
    }
    myObj.cudAjaxFn("/ApplyLeave/createApplyLeave", data, successFn);
}

function cancelApplyLeave(){
    getApplyLeave();
}

function editApplyLeave(thisBtn, applyingID){
    $('.btnActive').css('pointer-events', "none");

    var thisRow = $(thisBtn).closest("tr[name='applyLeaveRow']").hide();
    var thisApplyDate = $(thisRow).find("[name='applyDate']").html();
    var thisApplyTypeVal = $(thisRow).find("input[name='applyTypeVal']").val();
    var thisNote = $(thisRow).find("[name='note']").text();
    var thisStartTime = $(thisRow).find("[name='startTime']").html();
    var thisEndTime = $(thisRow).find("[name='endTime']").html();

    var updateRow = $(".template").find("[name='addApplyLeaveRow']").clone();
    updateRow.find("[name='newApplyDate']").append(thisApplyDate);


    if(thisApplyTypeVal > 2){
        updateRow.find("select[name='newApplyType']").find("option[value='-1']").prop("selected", true);
        updateRow.find("select[name='newRestType']").find("option[value='"+thisApplyTypeVal+"']").prop("selected", true);
    }else{
        updateRow.find("select[name='newApplyType']").find("option[value='"+thisApplyTypeVal+"']").prop("selected", true);
    }
    updateRow.find("[name='newApplyNote']").val(thisNote);
    updateRow.find("[name='newStartDate']").val((thisStartTime.split("<br>")[0]).replace(new RegExp("/", "g"), "-"));
    updateRow.find("[name='newStartTime']").val(thisStartTime.split("<br>")[1]);
    updateRow.find("[name='newEndDate']").val((thisEndTime.split("<br>")[0]).replace(new RegExp("/", "g"), "-"));
    updateRow.find("[name='newEndTime']").val(thisEndTime.split("<br>")[1]);

    updateRow.find("a.add_applyLeave").remove();
    updateRow.find("a.up_applyLeave").attr("onclick", "upApplyLeave(this, "+ applyingID +")");
    updateRow.find("a.cel_applyLeave").attr("onclick", "cancelApplyLeave()");
    $(thisRow).after(updateRow);
    if(thisApplyTypeVal > 2){
        $("#applyLeaveDiv").find(".newRestType").show();
    }
}

function upApplyLeave(thisBtn, applyingID){
    var thisRow =  $(thisBtn).closest("tr[name='addApplyLeaveRow']");
    var applyTypeVal = thisRow.find("[name='newApplyType']").val();
    applyTypeVal = applyTypeVal == -1? thisRow.find("[name='newRestType']").val() : applyTypeVal;
    var startDate = thisRow.find("[name='newStartDate']").val();
    var startTime = thisRow.find("[name='newStartTime']").val();
    var endDate = thisRow.find("[name='newEndDate']").val();
    var endTime = thisRow.find("[name='newEndTime']").val();
    if(applyTypeVal=="" || startDate=="" || startTime=="" || endDate=="" || endTime==""){
        alert("申請類別或時間未填寫"); return;
    }

    var data = {
        ID : applyingID,
        applyType : applyTypeVal,
        note : thisRow.find("[name='newApplyNote']").val(), 
        startTime : startDate + "T" + startTime,
        endTime : endDate + "T" + endTime,
    };
    var successFn = function(res){
        cancelApplyLeave();
    }
    myObj.cudAjaxFn("/ApplyLeave/updateApplyLeave", data, successFn);
}

function delApplyLeave(applyingID){
    var msg = "您真的確定要取消申請嗎？\n\n請確認！";
    if(confirm(msg)==false) 
        return;
    var successFn = function(res){
        if(res > 0){
            cancelApplyLeave();
        }else{
            alert('fail');
        }     
    };
    myObj.cudAjaxFn("/ApplyLeave/delApplyLeave",{applyingID: applyingID},successFn);
}


//#endregion applyLeave


//------------------------------------------------------------------------------------------------------------

//#region applyLog



function refreshApplyLeaveLog(res){
    $("#applyLeaveLogList").empty();
    res.forEach(function(value){
        var row = $(".template").find("[name='applyLeaveLogRow']").clone();
        var addTime = myObj.dateTimeFormat(value.createTime);
        var dateTD = row.find("[name='applyDate']").text(addTime.ymdText + "\n" + addTime.hmText);
        dateTD.html(dateTD.html().replace(/\n/g, "<br/>"));

        var type = "";
        switch(value.applyType){
            case 1: type="出差"; break;
            case 2: type="外出"; break;
            case 3: type="特休"; break;
            case 4: type="事假"; break;
            case 5: type="病假"; break;
            case 6: type="公假"; break;
            case 7: type="調休"; break;
            case 8: type="喪假"; break;
            case 9: type="婚假"; break;
            case 10: type="產假"; break;
            case 11: type="陪產假"; break;
            case 12: type="其他"; break;
        };
        row.find("[name='applyType']").text(type);
        row.find("[name='note']").text(value.note);

        var sTime = myObj.dateTimeFormat(value.startTime);
        var sTimeTD = row.find("[name='startTime']").text(sTime.ymdText + "\n" + sTime.hmText);
        sTimeTD.html(sTimeTD.html().replace(/\n/g, "<br/>"));
        var eTime = myObj.dateTimeFormat(value.endTime);
        var eTimeTD = row.find("[name='endTime']").text(eTime.ymdText + "\n" + eTime.hmText);
        eTimeTD.html(eTimeTD.html().replace(/\n/g, "<br/>"));

        var status = "";
        switch(value.applyStatus){
            case 0: status="待審核"; break;
            case 1: status="通過"; break;
            case 2: status="不通過"; break;
        };
        row.find("[name='applyStatus']").text(status);
        $("#applyLeaveLogList").append(row);
    });
}

//#endregion applyLog


