
var myObj = new MyObj();

$(document).ready(function() {  

    getSelOption();

    $("select[name='department']").on("change", function(){
        $("select[name='position']").empty().append(new Option("請選擇", ""));
        var departSel = $("select[name='department']").val();
        if(departSel == ""){  
            return;
        }
        setAllPosition(departSel);
    });

    $("select[name='position']").on("click", function(){
        var departSel = $("select[name='department']").val();
        if(departSel == ""){
            alert("請先選擇部門");
            return;
        }
    });

});//.ready function

function getSelOption(){
    var successFn = function(res){
        setDepartOption(res.departOption);
        setTimeOption(res.timeOption);
        setGroupOption(res.groupOption);
        if($("input[name='updateEmployeeBtn']").length > 0){
            var editID = $("input[name='updateEmployeeBtn']").attr("data-id");
            getAccountDetail(editID);
        }
    };
    myObj.rAjaxFn("get", "/EmployeeList/getSelOption", null, successFn);
}

function setDepartOption(res){
    myObj.departPosition = res;
    var departSelList = $("select[name='department']");
    if(($("#ruleVal").val() & 0x0008) > 0){
        var departName= "";
        res.forEach(function(value){
            if(departName != value.department){
                departName = value.department;
                departSelList.append(new Option(value.department, value.department));
            }
        });
    }
    else{
        departSelList.append(new Option(res[0].department, res[0].department));
        setAllPosition(res[0].department);
    }
}

function setAllPosition(departSel){
    $("select[name='position']").empty().append(new Option("請選擇", ""));
    var positionSelList = $("select[name='position']");
    myObj.departPosition.forEach(function(value){
        if(value.department == departSel)
            positionSelList.append(new Option(value.position, value.id));
    });
}

function setTimeOption(res){
    var timeRule = $("select[name='timeRule']");
    res.forEach(function(value){
        myObj.timeSpanToTime(value);
        var text = value.name + " - 上班時間 : " + value.startTime + " ~ " + value.endTime;
        timeRule.append(new Option(text, value.id));
    });
}

function setGroupOption(res){
    var groupSelList = $("select[name='actAuthority']");
    res.forEach(function(value){
        groupSelList.append(new Option(value.groupName, value.id));
    }); 
}

function getAccountDetail(editID){
    var getAccInfoSuccessFn = function(accInfo){
        $("input[name='account']").val(accInfo.account);
        $("input[name='userName']").val(accInfo.userName);
        $("input[name='startWorkDate']").val(((accInfo.startWorkDate).split("T"))[0]);
        $("select[name='department']").find("option[value='"+accInfo.department+"']").prop("selected", "selected");
        setAllPosition(accInfo.department);
        $("select[name='position']").find("option[value='"+ accInfo.departmentID +"']").prop("selected", true);
        $("select[name='timeRule']").find("option[value='"+accInfo.timeRuleID+"']").prop("selected", true);
        $("select[name='actAuthority']").find("option[value='"+accInfo.groupID+"']").prop("selected", true);
        $("select[name='accLV']").find("option[value='"+accInfo.accLV+"']").prop("selected", true);
    };
    myObj.rAjaxFn("get", "/EmployeeList/getAccountDetail", {employeeID: editID}, getAccInfoSuccessFn);
}

function closeSubWin(){
    window.close();
}

function createEmployee(){
    myObj.dataCheck("add","employee");
    if(myObj.errorCode>0){
        myObj.callAlert(myObj.errorCode);
        return;
    }
    var data = {
        account: $("input[name='account']").val(),
        password: $("input[name='password']").val(),
        userName: $("input[name='userName']").val(),
        accLV : $("select[name='accLV']").val(),
        departmentID: $("select[name='position']").val(),
        timeRuleID: $("select[name='timeRule']").val(),
        groupID: $("select[name='actAuthority']").val(),
    };
    var data2 = {
        startWorkDate: $("input[name='startWorkDate']").val(),
    };
    var successFn = function(res){
        if(res== 1){
            window.close();
        }else if(res==0){
            alert("fail");
        }else if(res==-1){
            alert("該帳號已存在");
        }
    };
    myObj.cudAjaxFn("/EmployeeList/createEmployee", {newEmployee:data, employeeDetail:data2}, successFn);
}

function updateEmployee(employeeID){
    myObj.dataCheck("update","employee");
    if(myObj.errorCode>0){
        myObj.callAlert(myObj.errorCode);
        return;
    }
    var data = {
        ID: employeeID,
        account: $("input[name='account']").val(),
        password: $("input[name='password']").val(),
        userName: $("input[name='userName']").val(),
        accLV : $("select[name='accLV']").val(),
        departmentID: $("select[name='position']").val(),
        timeRuleID: $("select[name='timeRule']").val(),
        groupID: $("select[name='actAuthority']").val(),
    };
    var data2 = {
        startWorkDate: $("input[name='startWorkDate']").val(),
    };
    var successFn = function(res){
        if(res== 1){
            window.close();
        }
    };
    myObj.cudAjaxFn("/EmployeeList/updateEmployee", {updateData:data, employeeDetail:data2}, successFn);
}












