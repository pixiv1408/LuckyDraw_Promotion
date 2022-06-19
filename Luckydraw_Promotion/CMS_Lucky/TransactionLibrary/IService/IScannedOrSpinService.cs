using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionLibrary.DTO;

namespace TransactionLibrary.IService
{
    public interface IScannedOrSpinService
    {
        Task<List<ScannedOrSpinDTO>> SosGetAll();
        Task<ScannedOrSpinDTO> SosGetSingle(int id);
        Task<bool> SosInsert(ScannedOrSpinDTO request);
        Task<bool> SosUpdate(ScannedOrSpinDTO request);
        Task<bool> SosDelete(int id);
    }
}
