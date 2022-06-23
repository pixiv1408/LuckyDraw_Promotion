using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionLibrary.DTO;

namespace TransactionLibrary.IService
{
    public interface IGiftService
    {
        Task<List<GiftDTO>> GiftGetAll();
        Task<GiftDTO> GiftGetSingle(int id);
        Task<bool> GiftInsert(GiftDTO request);
        Task<bool> GiftUpdate(GiftDTO request);
        Task<bool> GiftDelete(int id);
    }
}
