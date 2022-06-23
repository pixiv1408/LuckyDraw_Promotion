using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLibrary.Response
{
    public class RulesforgiftRP
    {
        public int ruleId { get; set; }
        public string ruleName { get; set; }
        public int ruleGiftCount { get; set; } = 0;
        public TimeSpan ruleStartTime { get; set; }
        public TimeSpan? ruleEndTime { get; set; }
        public bool ruleAllDay { get; set; }
        public int ruleProbability { get; set; }
        public string ruleScheduleValue { get; set; }
        public int repeatId { get; set; }
        public int cgId { get; set; }
    }
}
