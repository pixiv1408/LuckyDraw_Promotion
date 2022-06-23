using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionLibrary.DTO;

namespace TransactionLibrary.IService
{
    public interface ICampaignService
    {
        Task<List<CampaignDTO>> CampaignGetAll();
        Task<CampaignDTO> CampaignGetSingle(int id);
        Task<bool> CampaignInsert(CampaignDTO request);
        Task<bool> CampaignUpdate(CampaignDTO request);
        Task<bool> CampaignDelete(int id);
    }
}
