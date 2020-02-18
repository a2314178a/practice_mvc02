
var myObj = new MyObj();

$(document).ready(function() {  
    showEmployee();
    $(window).bind('beforeunload',function(){
        if(myObj.subWin != null && myObj.subWin.open){
            myObj.subWin.close();
        }
    });
});//.ready function



function getAllAccount(){
    var successFn = function(res){
        refreshAccList(res);
    };
    myObj.getAccountList("get", "/EmployeeList/getThisLvAllAcc", successFn)
}

function refreshAccList(res){
    $("#accountList").empty();
    res.forEach(function(value){
        //myObj.timeSpanToTime(value);
        var row = $(".template").find("[name='accountRow']").clone();
        row.find("[name='account']").text(value.account);
        row.find("[name='userName']").find('a').attr("onclick","showThisPunchLog("+value.id+");").text(value.userName);
        row.find("[name='department']").text(value.department);
        row.find("[name='position']").text(value.position);
        //var text = value.startTime + " ~ " + value.endTime;
        //row.find("[name='timeRule']").text(text);
        row.find(".edit_user").attr("onclick","editEmployee(this,"+value.id+");");
        row.find(".del_user").attr("onclick","delEmployee("+value.id+");");
        $("#accountList").append(row);
     });
}

function showEmployee(){
    $("ul a[name='employee']").addClass("active");
    $("ul a[name='department']").removeClass("active");
    $('.btnActive').css('pointer-events', "");
    getAllAccount();
}


function showAddAccWindow(){
    $('.btnActive').css('pointer-events', "none");  
    var closeFn = getAllAccount;
    myObj.openSubWindow(500, 650, "/EmployeeList/showAddForm", closeFn);
}
function delEmployee(employeeID){
    var msg = "您真的確定要刪除嗎？\n\n請確認！";
    if(confirm(msg)==false) 
        return;
    var successFn = function(res){
        if(res > 0){
            getAllAccount();
        }else{
            alert('fail');
        }     
    };
    myObj.cudAjaxFn("/EmployeeList/delEmployee", {employeeID: employeeID}, successFn);
}
function editEmployee(thisBtn, employeeID){
    $('.btnActive').css('pointer-events', "none");  
    var closeFn = getAllAccount;
    myObj.openSubWindow(500, 650, "/EmployeeList/showAddForm?ID=" + employeeID, closeFn);
}


function showThisPunchLog(employeeID){
    window.location.href = "/PunchCard/getEmployeeLog?employeeID="+employeeID;
}

