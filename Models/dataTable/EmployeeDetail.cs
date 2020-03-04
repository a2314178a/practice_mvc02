using System;
using System.ComponentModel.DataAnnotations;

namespace practice_mvc02.Models.dataTable
{
    public class EmployeeDetail
    {
        [Key]
        public int ID {get;set;}
        public int accountID {get; set;}
        public string humanID {get; set;}
        public DateTime birthday {get; set;}
        public DateTime startWorkDate {get; set;}
        public int lastOperaAccID {get; set;}
        public DateTime createTime {get; set;}
        public DateTime updateTime {get; set;}
    }
}