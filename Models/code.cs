using System;
namespace practice_mvc02.Models
{
    public class groupRuleCode
    {
        public int punchAndLog {get;}
        public int departEmployeeList {get;}
        public int allEmployeeList {get;}
        public int employeeEdit {get;}
        public int editPunchLog {get;}
        public int departmentList {get;}
        public int setRule {get;}
        public int applySign {get;}
    
    
        public groupRuleCode(){
            this.punchAndLog = 0x0001; //打卡與紀錄
            this.editPunchLog = 0x0002;    //編輯出勤紀錄
            this.departEmployeeList = 0x0004;  //查看部門員工
            this.allEmployeeList = 0x0008; //查看所有員工
            this.employeeEdit = 0x0010;  //編輯員工
            this.departmentList = 0x0020;  //部門職位相關
            this.setRule = 0x0040; //設定規則
            this.applySign = 0x0080;
        } 
    }

    public class punchStatusCode
    {
        public int normal {get;}
        public int hadLost {get;}
        public int lateIn {get;}
        public int earlyOut {get;}
        public int overtime {get;}
    
        public punchStatusCode(){
            this.normal = 0x0001;   //正常
            this.lateIn = 0x0002;   //遲到
            this.earlyOut = 0x0004; //早退
            this.overtime = 0x0008; //加班
            this.hadLost = 0x0010;  //缺卡
        } 
    }





}