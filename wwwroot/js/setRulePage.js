
var myObj = new MyObj();

$(document).ready(function() {  
    showTimeRule();

    $("ul[group='table']").on("click", "a", function(){
        $(".add_timeRule").show();
        $('.btnActive').css('pointer-events', "");
    });
});//.ready function



//#region  timeRule

function showTimeRule(){
    $("ul a[name='groupRule']").removeClass("active");
    $("ul a[name='timeRule']").addClass("active");
    $('.btnActive').css('pointer-events', "");
    $("#groupRuleDiv").hide();
    $(".add_timeRule, #timeRuleDiv").show();
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

//------------------------------------------------------------------------------------------------------------

//#region groupRule

function showGroupRule(){
    $("ul a[name='timeRule']").removeClass("active");
    $("ul a[name='groupRule']").addClass("active");
    $('.btnActive').css('pointer-events', "");
    $("#timeRuleDiv").hide();
    $("#groupRuleDiv").show();
    $(".add_group").show();
    getAllGroup();
}

function getAllGroup(){
    var successFn = function(res){
        refreshGroupList(res);
    };
    myObj.rAjaxFn("get", "/SetRule/getAllGroup", null, successFn)
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

















