﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLibrary.DTO
{
    public class CampaignCodeDTO
    {
        public int ccId { get; set; }
        public string ccCode { get; set; } 
        public DateTime ccCreatedDate { get; set; }
        public int camId { get; set; }
    }
}
