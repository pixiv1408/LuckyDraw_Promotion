using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datactx.Models
{
    public class Rulesforgift
    {
        [Key]
        public int ruleId { get; set; }
        public string ruleName { get; set; } = null!;
        public int ruleGiftCount { get; set; } = 0;
        public TimeSpan ruleStartTime { get; set; }
        public TimeSpan? ruleEndTime { get; set; }
        public bool ruleAllDay { get; set; } = false;
        public int ruleProbability { get; set; } = 0;
        public string ruleScheduleValue { get; set; } = null!;



        public int repeatId { get; set; }
        public int cgId { get; set; }
        public RepeatSchedule RepeatSchedule { get; set; } = null!;
        public CampGift CampGift { get; set; } = null!;
    }
}
