﻿class MyObj{
    
    constructor() {
        this.subWin = null;
        this.errorCode = 0;
        this.ajaxCompleteFlag = false;
        this.workHoursToDay = 8;
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
                }else if(res==-1){
                    alert("該帳號已存在");
                }else if(res==0){
                    alert("操作失敗");
                }else{
                    successFn(res);
                }        
            },
            error:function(res){
                if(res.responseJSON != undefined && res.responseJSON.statusText == "fail"){
                    if(res.responseJSON.result == "-2"){
                        alert("逾時過久或登入異常，請重新登入");
                        if(window.name == "subWindow"){
                            window.close();
                            window.opener.location.href = "/Home/logOut";
                        }else{
                            window.location.href = "/Home/logOut";
                        }
                    }  
                }else{
                    alert("error");
                }
            }
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
            error:function(res){
                if(res.responseJSON != undefined && res.responseJSON.statusText == "fail"){
                    if(res.responseJSON.result == "-2"){
                        alert("逾時過久或登入異常，請重新登入");
                        if(window.name == "subWindow"){
                            window.close();
                            window.opener.location.href = "/Home/logOut";
                        }else{
                            window.location.href = "/Home/logOut";
                        }
                    }  
                }else{
                    alert("error");
                }
            }
        });   
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
    workTimeSpanToTime(value){
        var startHours = this.add0(value.startTime.hours);
        var startMinutes = this.add0(value.startTime.minutes); 
        var endHours = this.add0(value.endTime.hours); 
        var endMinutes = this.add0(value.endTime.minutes);
        var sRestHours = this.add0(value.sRestTime.hours);
        var sRestMinutes = this.add0(value.sRestTime.minutes);
        var eRestHours = this.add0(value.eRestTime.hours);
        var eRestMinutes = this.add0(value.eRestTime.minutes);

        value.startTime = startHours + ":" + startMinutes;
        value.endTime = endHours + ":" + endMinutes;
        value.sRestTime = sRestHours + ":" + sRestMinutes;
        value.eRestTime = eRestHours + ":" + eRestMinutes;
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
        var weekList = ['日', '一', '二', '三', '四', '五', '六']; 
        dt.twWeek = "星期" + weekList[dt.week];
        dt.worldWeek = "(" + weekList[dt.week] + ")";
        dt.ymdText = dt.year + "/" + dt.month + "/" + dt.day;
        dt.hmsText = dt.hour + ":" + dt.minute + ":" + dt.second;
        dt.hmText = dt.hour + ":" + dt.minute;
        dt.ymdHtml = dt.year + "-" + dt.month + "-" + dt.day;
        return dt;
    }
    add0(num){
        return num < 10 ? ("0" + num) : num;
    }
    isExistDate(dateStr) {
        var dateObj = dateStr.split('-'); // yyyy-mm-dd
        //列出12個月，每月最大日期限制
        var limitInMonth = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
        var theYear = parseInt(dateObj[0]);
        var theMonth = parseInt(dateObj[1]);
        var theDay = parseInt(dateObj[2]);
        var isLeap = new Date(theYear, 1, 29).getDate() === 29; // 是否為閏年?
        if (isLeap) {
          // 若為閏年，最大日期限制改為 29
          limitInMonth[1] = 29;
        }
        // 比對該日是否超過每個月份最大日期限制
        return theDay <= limitInMonth[theMonth - 1];
      }
    

}//class
