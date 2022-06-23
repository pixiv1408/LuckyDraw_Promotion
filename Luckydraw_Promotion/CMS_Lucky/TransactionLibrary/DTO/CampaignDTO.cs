using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLibrary.DTO
{
    public class CampaignDTO
    {
        public int camId { get; set; }
        public string camName { get; set; } 
        public bool camAutoUpdate { get; set; } = false;
        public bool camJoinOnlyOne { get; set; } = false;
        public bool ApplyAllCampaign { get; set; } = false;
        public string Description { get; set; } 
        public int camCodeUsageLimit { get; set; } = 1;
        public bool camUnlimited { get; set; } = false;
        public int camCodeCount { get; set; } = 1;
        public int charId { get; set; }
        public int camCodeLength { get; set; } = 10;
        public string camPrefix { get; set; } = "ALTA";
        public string? camPostfix { get; set; }

        //Time Frame
        public DateTime camStartDate { get; set; }
        public DateTime? camEndDate { get; set; }
        public TimeSpan camStartTime { get; set; }
        public TimeSpan? camEndTime { get; set; }

        public int psId { get; set; }
    }
}
