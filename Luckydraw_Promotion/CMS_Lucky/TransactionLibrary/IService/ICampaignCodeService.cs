using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionLibrary.DTO;

namespace TransactionLibrary.IService
{
    public interface ICampaignCodeService
    {
        Task<List<CampaignCodeDTO>> CampaignCodeGetAll();
        Task<CampaignCodeDTO> CampaignCodeGetSingle(int id);
        Task<bool> CampaignCodeInsert(CampaignCodeDTO request);
        Task<bool> CampaignCodeUpdate(CampaignCodeDTO request);
        Task<bool> CampaignCodeDelete(int id);
    }
}
