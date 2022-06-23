using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionLibrary.DTO;

namespace TransactionLibrary.IService
{
    public interface ICampGiftService
    {
        Task<List<CampGiftDTO>> CampGiftGetAll();
        Task<CampGiftDTO> CampGiftGetSingle(int id);
        Task<bool> CampGiftInsert(CampGiftDTO request);
        Task<bool> CampGiftUpdate(CampGiftDTO request);
        Task<bool> CampGiftDelete(int id);
    }
}
