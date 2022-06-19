﻿using Datactx.Dbcontext;
using Datactx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionLibrary.Interface;

namespace TransactionLibrary.Repository
{
    public class RepeatScheduleRepo : BaseRepo<RepeatSchedule>, IRepeatScheduleRepo
    {
        public RepeatScheduleRepo(DatabaseContext data) : base(data)
        {

        }
    }
}
