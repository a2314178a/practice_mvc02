
var myObj = new MyObj();

$(document).ready(function() {  

    $("#searchFilterDiv").on("click", "[name='searchFilterBtn']", function(){
        getPunchLogByIDByDate();
    });

});//.ready function

function showPunchCardPage(){
    window.location.href = "/PunchCard/Index";
}
function showPunchLogPage(targetID){
    window.location.href = "/PunchCard/Index?page=log&target="+targetID;
}
function showTimeTotalPage(targetID){
    window.location.href = "/PunchCard/Index?page=total&target="+targetID;
}

function getAllPunchLogByID(employeeID=0){
    myObj.lookEmployeeID = employeeID;
    var successFn = function(res){
        refreshPunchLogList(res);
    };
    myObj.rAjaxFn("post", "/PunchCard/getAllPunchLogByID", {employeeID: employeeID}, successFn);
}

function getPunchLogByIDByDate(){
    var sDate = $("#filter_sDate").val();
    var eDate = $("#filter_eDate").val();
    if(sDate == "" && eDate == ""){
        getAllPunchLogByID(myObj.lookEmployeeID);  return;
    }
    else if(sDate == "" || eDate == "" || sDate > eDate){
        alert("搜尋日期格式有誤");  return;
    }
    var data = {
        employeeID : myObj.lookEmployeeID,
        sDate : sDate,
        eDate : eDate
    };
    var successFn = function(res){
        refreshPunchLogList(res);
    };
    myObj.rAjaxFn("post", "/PunchCard/getPunchLogByIDByDate", data, successFn);
}

function refreshPunchLogList(res){
    $("#punchLogList").empty();
    res.forEach(function(value){
        var row = $(".template").find("[name='punchLogRow']").clone();
        var dtOn = myObj.dateTimeFormat(value.onlineTime);
        var dtOff = myObj.dateTimeFormat(value.offlineTime);
        var workDate = myObj.dateTimeFormat(value.logDate);
        var logDate = workDate.year + "-" + workDate.month + "-" + workDate.day;
        var dtOnTime = dtOn.year == 1? "" : (dtOn.hour + ":" + dtOn.minute + ":" + dtOn.second);
        var dtOffTime = dtOff.year == 1? "" : (dtOff.hour + ":" + dtOff.minute + ":" + dtOff.second);

        var status = "";
        status = (value.punchStatus & 0x02) ? status+="遲到/" : status;
        status = (value.punchStatus & 0x04) ? status+="早退/" : status;
        status = (value.punchStatus & 0x08) ? status+="加班/" : status;
        status = (value.punchStatus & 0x10) ? status+="缺卡/" : status;
        status = (value.punchStatus & 0x20) ? "曠職" : status;
        status = (value.punchStatus & 0x01) && status == "" ? status+="正常" : status;
        status = status.charAt(status.length-1) == "/" ? status.substring(0, status.length -1) :status;
        
        row.find("[name='logDate']").text(logDate);
        row.find("[name='logOnlineTime']").text(dtOnTime);
        row.find("[name='logOfflineTime']").text(dtOffTime);
        row.find("[name='logPunchStatus']").text(status);
        row.find(".edit_punchLog").attr("onclick","editPunchLog(this, "+value.id+");");
        row.find(".del_punchLog").attr("onclick","delPunchLog("+value.id+");");
        $("#punchLogList").append(row);
    });
}

function showAddPunchLogRow(employeeID, employeeDepartID){
    $("#punchLogDiv").find("a.add_punchLog").hide();
    $('.btnActive').css('pointer-events', "none"); 
    var addPunchLogRow = $(".template").find("[name='addPunchLogRow']").clone();
    addPunchLogRow.find("a.update_punchLog").remove();
    addPunchLogRow.find("a.create_punchLog").attr("onclick", "createPunchLog(this,"+employeeID+","+employeeDepartID+");");
    addPunchLogRow.find("a.cancel_punchLog").attr("onclick", "cancelPunchLog("+employeeID+");");
    $('#punchLogList').append(addPunchLogRow);
}

function cancelPunchLog(employeeID){
    $('.btnActive').css('pointer-events', ""); 
    $("#punchLogDiv").find("a.add_punchLog").show();
    //getAllPunchLogByID(employeeID);
    getPunchLogByIDByDate();
}

function createPunchLog(thisBtn, employeeID, employeeDepartID){
    var thisRow =  $(thisBtn).closest("tr[name='addPunchLogRow']");
    var dateTime = thisRow.find("input[name='newDateTime']").val();
    var onlineTime = thisRow.find("input[name='newOnlineTime']").val();
    var offlineTime = thisRow.find("input[name='newOfflineTime']").val();
    if(dateTime =="" || (onlineTime =="" && offlineTime =="")){
        alert("此打卡紀錄不合法");return;
    }
    onlineTime = onlineTime != "" ? (dateTime + "T" + onlineTime) : "";
    offlineTime = offlineTime != "" ? (dateTime + "T" + offlineTime) : "";

    var newPunchLog = {
        accountID : employeeID,
        departmentID : employeeDepartID,
        logDate : dateTime,
        onlineTime : onlineTime,
        offlineTime : offlineTime,
    };
    var successFn = function(res){
        if(res == 2){
            alert("此打卡紀錄不合法");return;
        }
        cancelPunchLog(employeeID);
    }
    myObj.cudAjaxFn("/PunchCard/forceAddPunchCardLog", newPunchLog, successFn);
}

function editPunchLog(thisBtn, logID){
    $('.btnActive').css('pointer-events', "none");

    var thisRow = $(thisBtn).closest("tr[name='punchLogRow']").hide();
    var thisDate = thisRow.find("[name='logDate']").text();
    var thisOnlineTime = thisRow.find("[name='logOnlineTime']").text();
    var thisOfflineTime = thisRow.find("[name='logOfflineTime']").text();

    var updateLogRow = $(".template").find("[name='addPunchLogRow']").clone();
    updateLogRow.find("input[name='newDateTime']").val(thisDate);
    updateLogRow.find("input[name='newOnlineTime']").val(thisOnlineTime);
    updateLogRow.find("input[name='newOfflineTime']").val(thisOfflineTime);

    updateLogRow.find("a.create_punchLog").remove();
    updateLogRow.find("a.update_punchLog").attr("onclick", "updatePunchLog(this, "+ logID +")");
    updateLogRow.find("a.cancel_punchLog").attr("onclick", "cancelPunchLog("+myObj.lookEmployeeID+")");

    $(thisRow).after(updateLogRow);
}

function updatePunchLog(thisBtn, punchLogID){
    var thisRow =  $(thisBtn).closest("tr[name='addPunchLogRow']");
    var dateTime = thisRow.find("input[name='newDateTime']").val();
    var onlineTime = thisRow.find("input[name='newOnlineTime']").val();
    var offlineTime = thisRow.find("input[name='newOfflineTime']").val();
    if(dateTime =="" || (onlineTime =="" && offlineTime =="")){
        alert("此打卡紀錄不合法");return;
    }
    onlineTime = onlineTime != "" ? (dateTime + "T" + onlineTime) : "";
    offlineTime = offlineTime != "" ? (dateTime + "T" + offlineTime) : "";

    var updatePunchLog = {
        ID : punchLogID,
        logDate : dateTime,
        onlineTime : onlineTime,
        offlineTime : offlineTime,
    };
    var successFn = function(res){
        if(res == 2){
            alert("此打卡紀錄不合法");return;
        }
        cancelPunchLog(myObj.lookEmployeeID);
    }
    myObj.cudAjaxFn("/PunchCard/forceUpdatePunchCardLog", updatePunchLog, successFn);
}

function delPunchLog(logID){
    var msg = "您真的確定要刪除嗎？\n\n請確認！";
    if(confirm(msg)==false) 
        return;
    var successFn = function(res){
        if(res > 0){
            cancelPunchLog(myObj.lookEmployeeID);
        }else{
            alert('fail');
        }     
    };
    myObj.cudAjaxFn("/PunchCard/delPunchCardLog",{punchLogID: logID},successFn);
}

//--------------------------------------------------------------------------------------------------------

function getTimeTotalByID(targetID){
    var successFn = function(res){
        refreshTimeTotalList(res);
    };
    myObj.rAjaxFn("post", "/PunchCard/getTimeTotalByID", {targetID:targetID}, successFn);
}

function refreshTimeTotalList(res){
    $("#timeTotalList").empty();
    res.forEach(function(value){
        var row = $(".template").find("[name='timeTotalRow']").clone();
        var dt = myObj.dateTimeFormat(value.dateMonth);
        var dateText = dt.year + "-" + dt.month;
        row.find("[name='logDate']").text(dateText);
        row.find("[name='timeTotal']").text(value.totalTime);
        $("#timeTotalList").append(row);
    });
}



