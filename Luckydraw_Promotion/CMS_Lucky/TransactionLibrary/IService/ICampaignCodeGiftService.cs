using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionLibrary.DTO;

namespace TransactionLibrary.IService
{
    public interface ICampaignCodeGiftService
    {
        Task<List<CampaignCodeGiftDTO>> CampaignCodeGiftGetAll();
        Task<CampaignCodeGiftDTO> CampaignCodeGiftGetSingle(int id);
        Task<bool> CampaignCodeGiftInsert(CampaignCodeGiftDTO request);
        Task<bool> CampaignCodeGiftUpdate(CampaignCodeGiftDTO request);
        Task<bool> CampaignCodeGiftDelete(int id);
    }
}
