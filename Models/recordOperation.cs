using System;

namespace practice_mvc02.Models
{
    public class recordOperation
    {
        public int ID { get; set; }
        public int operateID { get; set; }
        public int beOperatedID { get; set; }
        public byte operateType { get; set; }
        public string detail { get; set; }
        public string description { get; set; }
        public DateTime createTime { get; set; }
    }
}
