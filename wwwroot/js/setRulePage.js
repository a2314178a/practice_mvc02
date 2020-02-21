﻿
var myObj = new MyObj();

$(document).ready(function() {  
    
    init();
    $("ul[group='table']").on("click", "a", function(){
        $(".add_timeRule").show();
        $('.btnActive').css('pointer-events', "");
    });
});//.ready function

function showSetRulePage(page){
    window.location.href = "/SetRule/Index?page="+page;  
}



function init(){
    if($("#timeRuleDiv").length > 0){
        getAllTimeRule();
    }else if($("#groupRuleDiv").length > 0){
        showGroupRule();
    }else if($("#specialDateDiv").length > 0){
        showSpecialDate();
    }
    
}


//#region  timeRule

function showTimeRule(){
    $('.btnActive').css('pointer-events', "");
    $(".add_timeRule").show();
    getAllTimeRule();
}

function getAllTimeRule(){
    var successFn = function(res){
        refreshTimeRuleList(res);
    };
    myObj.rAjaxFn("get", "/SetRule/getAllTimeRule", null, successFn)
}

function refreshTimeRuleList(res){
    $("#timeRuleList").empty();
    res.forEach(function(value){
        myObj.timeSpanToTime(value);
        var row = $(".template").find("[name='timeRuleRow']").clone();
        row.find("[name='name']").text(value.name);
        row.find("[name='startTime']").text(value.startTime);
        row.find("[name='endTime']").text(value.endTime);
        row.find("[name='lateTime']").text(value.lateTime);
        row.find(".edit_timeRule").attr("onclick","editTimeRule(this,"+value.id+");");
        row.find(".del_timeRule").attr("onclick","delTimeRule("+value.id+");");
        $("#timeRuleList").append(row);
     });
}

function showAddTimeRuleRow(){
    $("#timeRuleDiv").find("a.add_timeRule").hide();
    $('.btnActive').css('pointer-events', "none"); 
    var addTimeRuleRow = $(".template").find("[name='addTimeRuleRow']").clone();
    addTimeRuleRow.find("a.update_timeRule").remove();
    addTimeRuleRow.find("a.create_timeRule").attr("onclick", "addTimeRule(this);");
    addTimeRuleRow.find("a.cancel_timeRule").attr("onclick", "cancelAddTimeRule(this);");
    $('#timeRuleList').append(addTimeRuleRow);
}

function addTimeRule(thisBtn){
    var thisRow =  $(thisBtn).closest("tr[name='addTimeRuleRow']");
    var name = thisRow.find("[name='newName']").val();
    var startTime = thisRow.find("[name='newStartTime']").val();
    var endTime = thisRow.find("[name='newEndTime']").val();
    var lateTime = thisRow.find("[name='newLateTime']").val();

    if(name == "" || startTime =="" || endTime == "" || lateTime ==""){
        alert("欄位不可為空");
        return;
    }
    var data = {
        name : name,
        startTime : startTime,
        endTime : endTime,
        lateTime : lateTime
    };

    var successFn = function(res){
        showTimeRule();
    }
    myObj.cudAjaxFn("/SetRule/addTimeRule", data, successFn);
}

function cancelAddTimeRule(thisBtn){
    showTimeRule();
}

function delTimeRule(timeRuleID){
    var msg = "您真的確定要刪除嗎？\n\n請確認！";
    if(confirm(msg)==false) 
        return;
    var successFn = function(res){
        if(res > 0){
            showTimeRule();
        }else{
            alert('fail');
        }     
    };
    myObj.cudAjaxFn("/SetRule/delTimeRule",{timeRuleID: timeRuleID},successFn);
}

function editTimeRule(thisBtn, timeRuleID){
    $('.btnActive').css('pointer-events', "none");

    var thisRow = $(thisBtn).closest("tr[name='timeRuleRow']").hide();
    var thisName = thisRow.find("[name='name']").text();
    var thisStartTime = thisRow.find("[name='startTime']").text();
    var thisEndTime = thisRow.find("[name='endTime']").text();
    var thisLateTime = thisRow.find("[name='lateTime']").text();

    var updateRuleRow = $(".template").find("[name='addTimeRuleRow']").clone();
    updateRuleRow.find("input[name='newName']").val(thisName);
    updateRuleRow.find("input[name='newStartTime']").val(thisStartTime);
    updateRuleRow.find("input[name='newEndTime']").val(thisEndTime);
    updateRuleRow.find("input[name='newLateTime']").val(thisLateTime);
    updateRuleRow.find("a.create_timeRule").remove();
    updateRuleRow.find("a.update_timeRule").attr("onclick", "updateTimeRule(this, "+ timeRuleID +")");
    updateRuleRow.find("a.cancel_timeRule").attr("onclick", "cancelAddTimeRule(this)");

    $(thisRow).after(updateRuleRow);
}

function updateTimeRule(thisBtn, timeRuleID){
    var thisRow =  $(thisBtn).closest("tr[name='addTimeRuleRow']");
    var name = thisRow.find("[name='newName']").val();
    var startTime = thisRow.find("[name='newStartTime']").val();
    var endTime = thisRow.find("[name='newEndTime']").val();
    var lateTime = thisRow.find("[name='newLateTime']").val();
    if(startTime =="" || endTime == "" || lateTime ==""){
        alert("欄位不可為空");
        return;
    }
    var data = {
        ID : timeRuleID,
        name: name,
        startTime : startTime,
        endTime : endTime,
        lateTime : lateTime
    };
    var successFn = function(res){
        showTimeRule();
    }
    myObj.cudAjaxFn("/SetRule/updateTimeRule", data, successFn);
}

//#endregion  timeRule

//--------------------------------------------------------------------------------------------------------------------------------

//#region groupRule

function showGroupRule(){
    $('.btnActive').css('pointer-events', "");
    $(".add_group").show();
    getAllGroup();
}

function getAllGroup(){
    var successFn = function(res){
        refreshGroupList(res);
    };
    myObj.rAjaxFn("get", "/SetRule/getAllGroup", null, successFn);
}

function refreshGroupList(res){
    $("#groupList").empty();
    res.forEach(function(value){
        var row = $(".template").find("[name='groupRow']").clone();
        var chkBox = $(".template").find("div[name='chkBox']").clone();
        row.find("[name='groupName']").text(value.groupName);
        var para = value.ruleParameter;
        var allChkBox = chkBox.find("input[type='checkbox']");
        $.each(allChkBox, function(key, obj){
            var thisVal = $(obj).val();
            if(para & thisVal){
                $(obj).prop("checked", "checked");
            }
            $(obj).prop("disabled", "disabled");
        });
        row.find("[name='groupAuthority']").append(chkBox);
        row.find(".edit_group").attr("onclick","editGroup(this,"+value.id+");");
        row.find(".del_group").attr("onclick","delGroup("+value.id+");");
        $("#groupList").append(row);
     });
}

function showAddGroupRow(){
    $("#groupRuleDiv").find("a.add_group").hide();
    $('.btnActive').css('pointer-events', "none"); 
    var addGroupRow = $(".template").find("[name='addGroupRow']").clone();
    var chkBox = $(".template").find("div[name='chkBox']").clone();
    addGroupRow.find("[name='newGroupAuthority']").append(chkBox);
    addGroupRow.find("a.update_group").remove();
    addGroupRow.find("a.create_group").attr("onclick", "addGroup(this);");
    addGroupRow.find("a.cancel_group").attr("onclick", "cancelAddGroup(this);");
    $('#groupList').append(addGroupRow);
}

function addGroup(thisBtn){
    var thisRow =  $(thisBtn).closest("tr[name='addGroupRow']");
    var groupName = thisRow.find("[name='newGroupName']").val();
    var chkBox = thisRow.find("input[type='checkbox']:checked");
    var paraVal = 0x0000;
    $.each(chkBox, function(key, obj){
        paraVal = paraVal | $(obj).val();
    });

    if(groupName == ""){
        alert("群組名稱不可為空");
        return;
    }
    var data = {
        groupName : groupName,
        ruleParameter : paraVal,
    };

    var successFn = function(res){
        showGroupRule();
    }
    myObj.cudAjaxFn("/SetRule/addGroup", data, successFn);
}

function cancelAddGroup(thisBtn){
    showGroupRule();
}

function delGroup(groupID){
    var msg = "您真的確定要刪除嗎？\n\n請確認！";
    if(confirm(msg)==false) 
        return;
    var successFn = function(res){
        if(res > 0){
            showGroupRule();
        }else{
            alert('fail');
        }     
    };
    myObj.cudAjaxFn("/SetRule/delGroup",{groupID: groupID},successFn);
}

function editGroup(thisBtn, groupID){
    $('.btnActive').css('pointer-events', "none");

    var thisRow = $(thisBtn).closest("tr[name='groupRow']").hide();
    var thisGroupName = thisRow.find("[name='groupName']").text();
    var chkBox = thisRow.find("div[name='chkBox']").clone();
    $.each(chkBox.find("[type='checkbox']"), function(key, obj){
        $(obj).prop("disabled", false);
    });

    var updateGroupRow = $(".template").find("[name='addGroupRow']").clone();
    updateGroupRow.find("input[name='newGroupName']").val(thisGroupName);
    updateGroupRow.find("[name='newGroupAuthority']").append(chkBox);

    updateGroupRow.find("a.create_group").remove();
    updateGroupRow.find("a.update_group").attr("onclick", "updateGroup(this, "+ groupID +")");
    updateGroupRow.find("a.cancel_group").attr("onclick", "cancelAddGroup(this)");

    $(thisRow).after(updateGroupRow);
}

function updateGroup(thisBtn, groupID){
    var thisRow =  $(thisBtn).closest("tr[name='addGroupRow']");
    var groupName = thisRow.find("[name='newGroupName']").val();
    var chkBox = thisRow.find("input[type='checkbox']:checked");
    var paraVal = 0x0000;
    $.each(chkBox, function(key, obj){
        paraVal = paraVal | $(obj).val();
    });

    if(groupName == ""){
        alert("群組名稱不可為空");
        return;
    }
    var data = {
        ID : groupID,
        groupName : groupName,
        ruleParameter : paraVal,
    };
    
    var successFn = function(res){
        showGroupRule();
    }
    myObj.cudAjaxFn("/SetRule/updateGroup", data, successFn);
}

//#endregion groupRule

//-----------------------------------------------------------------------------------------------------------------------------------------

//#region specialDate

function showSpecialDate(){
    $('.btnActive').css('pointer-events', "");
    $(".add_spDate").show();
    getAllSpecialDate();
}

function getAllSpecialDate(){
    var successFn = function(res){
        refreshSpDateList(res);
    };
    myObj.rAjaxFn("get", "/SetRule/getAllSpecialDate", null, successFn);
}

function refreshSpDateList(res){
    $("#specialDateList").empty();
    res.forEach(function(value){
        var dt = myObj.dateTimeFormat(value.date);

        var row = $(".template").find("[name='specialDateRow']").clone();
        row.find("[name='date']").text(dt.ymdText + " " + dt.worldWeek);
        row.find("input[name='statusVal']").val(value.status);
        row.find("[name='status']").text((value.status == 1? "休假" : "上班"));
        row.find("[name='note']").text(value.note);
        row.find(".edit_spDate").attr("onclick","editSpecialDate(this,"+value.id+");");
        row.find(".del_spDate").attr("onclick","delSpecialDate("+value.id+");");
        $("#specialDateList").append(row);
     });
}

function showAddSpDateRow(){
    $("#specialDateDiv").find("a.add_spDate").hide();
    $('.btnActive').css('pointer-events', "none"); 
    var addSpDateRow = $(".template").find("[name='addSpecialDateRow']").clone();
    addSpDateRow.find("a.update_spDate").remove();
    addSpDateRow.find("a.create_spDate").attr("onclick", "addUpSpecialDate(this);");
    addSpDateRow.find("a.cancel_spDate").attr("onclick", "celSpecialDate(this);");
    $('#specialDateList').append(addSpDateRow);
}

function celSpecialDate(){
    showSpecialDate();
}

function delSpecialDate(spDateID){
    var msg = "您真的確定要刪除嗎？\n\n請確認！";
    if(confirm(msg)==false) 
        return;
    var successFn = function(res){
        if(res > 0){
            showSpecialDate();
        }else{
            alert('fail');
        }     
    };
    myObj.cudAjaxFn("/SetRule/delSpecialDate",{spDateID: spDateID},successFn);
}

function editSpecialDate(thisBtn, spDateID){
    $('.btnActive').css('pointer-events', "none");

    var thisRow = $(thisBtn).closest("tr[name='specialDateRow']").hide();
    var thisDate = thisRow.find("[name='date']").text();
    var dateVal = thisDate.split(" ")[0].replace(new RegExp("/", "g"), "-");
    var thisStatus = thisRow.find("input[name='statusVal']").val();
    var thisNote = thisRow.find("[name='note']").text();

    var updateSpDate = $(".template").find("[name='addSpecialDateRow']").clone();
    updateSpDate.find("input[name='newDate']").val(dateVal);
    updateSpDate.find("select[name='status']").find("option[value='"+thisStatus+"']").prop("selected", true);
    updateSpDate.find("input[name='newNote']").val(thisNote);

    updateSpDate.find("a.create_spDate").remove();
    updateSpDate.find("a.update_spDate").attr("onclick", "addUpSpecialDate(this, "+ spDateID +")");
    updateSpDate.find("a.cancel_spDate").attr("onclick", "celSpecialDate()");

    $(thisRow).after(updateSpDate);
}

function addUpSpecialDate(thisBtn, spDateID=0){
    var thisRow =  $(thisBtn).closest("tr[name='addSpecialDateRow']");
    var date = thisRow.find("[name='newDate']").val();
    var status = thisRow.find("select[name='status']").val();
    var note = thisRow.find("[name='newNote']").val();

    if(date == "" || status ==""){
        alert("日期與狀態欄位不可為空");
        return;
    }
    var data = {
        ID : spDateID,
        date : date,
        status : status,
        note : note,
    };

    var successFn = function(res){
        showSpecialDate();
    };
    myObj.cudAjaxFn("/SetRule/addUpSpecialTime", data, successFn);
}


//#endregion specialDate











