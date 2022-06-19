using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionLibrary.DTO;

namespace TransactionLibrary.IService
{
    public interface IWinnerService
    {
        Task<List<WinnerDTO>> WinnerGetAll();
        Task<WinnerDTO> WinnerGetSingle(int id);
        Task<bool> WinnerInsert(WinnerDTO request);
        Task<bool> WinnerUpdate(WinnerDTO request);
        Task<bool> WinnerDelete(int id);
    }
}
