using Datactx.Dbcontext;
using Datactx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionLibrary.Interface;

namespace TransactionLibrary.Repository
{
    public class CampaignCodeGiftRepo : BaseRepo<CampaignCodeGift>, ICampaignCodeGiftRepo
    {
        public CampaignCodeGiftRepo(DatabaseContext data) : base(data)
        {

        }
    }
}
