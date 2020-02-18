class MyObj{
    
    constructor() {
        this.subWin = null;
        this.errorCode = 0;
        this.ajaxCompleteFlag = false;
    }
    cudAjaxFn(url, data, successFn)
    {
        $.ajax({
            type : "post",
            url : url,     
            data: data,       
            success:function(res){
                if(res==1062){
                    alert("已有相關資料，請勿重複");
                }
                else if(res==-2){
                    alert("逾時過久，請重新登入");
                    if(window.name == "subWindow"){
                        window.close();
                        window.opener.location.href = "/Home/logOut";
                    }else{
                        window.location.href = "/Home/logOut";
                    }
                }else if(res==-1){
                    alert("該帳號已存在");
                }
                else if(res==0){
                    alert("操作失敗");
                }else{
                    successFn(res);
                }        
            },
            error:function(){alert("error");}
        });   
    }
    rAjaxFn(type, url, data, successFn)
    {
        $.ajax({
            type : type,
            url : url,     
            data: data,       
            success:function(res){
                successFn(res); 
            },
            error:function(){alert("error");}
        });   
    }
    getAccountList(type, url, successFn){
        this.rAjaxFn(type, url, null, successFn)
    }
    openSubWindow(width, height, url, closeFn)
    {
        $('.btnActive').css('pointer-events', "none");
        var win_width = width;
        var win_height = height;
        var PosX = (parseInt(screen.width-win_width))/2; 
        var PosY = (parseInt(screen.height-win_height))/2; 
        var parameter = "height=" + win_height + ",width=" + win_width + ",top=" + PosY + ",left=" + PosX +
                ",toolbar=no,menubar=no,scrollbars=no,resizable=no,location=no,status=no";       
        this.subWin = window.open(url, "subWindow", parameter);
        this.lookSubWin(closeFn);
    }
    lookSubWin(closeFn){
        var timer = setInterval(function(){  
            if(myObj.subWin.closed){
                $('.btnActive').css('pointer-events', "");
                closeFn();
                clearInterval(timer); 
            } 
        }, 1000);
    }
    dataCheck(action, type)
    {
        this.errorCode = 0;  
        if(type == "employee"){
            if($("[name='password']").val() != $("[name='rePassword']").val()){
                this.errorCode = 2;
            }
            $("[group='detail']").each(function(){
                if($(this).prop("type") =="password" && action =="update")return;
                
                if($(this).val()==""){
                    myObj.errorCode = 1;
                    return false;
                }
            }); 
        }
    }
    callAlert(code){
        switch(code){
            case 1: alert("欄位都須填寫或選擇");break;
            case 2: alert("密碼並不一致，請重新輸入");break;
        }        
    }
    timeSpanToTime(value){
        var startHours = this.add0(value.startTime.hours);
        var startMinutes = this.add0(value.startTime.minutes); 
        var endHours = this.add0(value.endTime.hours); 
        var endMinutes = this.add0(value.endTime.minutes);
        if(value.lateTime != undefined){
            var lateHours = this.add0(value.lateTime.hours); 
            var lateMinutes = this.add0(value.lateTime.minutes);
        }
        value.startTime = startHours + ":" + startMinutes;
        value.endTime = endHours + ":" + endMinutes;
        value.lateTime = lateHours + ":" + lateMinutes;
    }
    dateTimeFormat(time=""){
        if(time != ""){
            var dateTime = new Date(time);
        }else{
            var dateTime = new Date();
        } 
        var dt = {
            year: dateTime.getFullYear(),
            month: myObj.add0(dateTime.getMonth() + 1),
            day: myObj.add0(dateTime.getDate()),
            week: dateTime.getDay(),
            hour: myObj.add0(dateTime.getHours()),
            minute: myObj.add0(dateTime.getMinutes()),
            second: myObj.add0(dateTime.getSeconds()),
        }
        return dt;
    }
    add0(num){
        return num < 10 ? ("0" + num) : num;
    }
    
    

}//class
