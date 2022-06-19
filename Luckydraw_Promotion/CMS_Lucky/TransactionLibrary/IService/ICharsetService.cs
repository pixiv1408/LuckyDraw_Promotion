using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionLibrary.DTO;

namespace TransactionLibrary.IService
{
    public interface ICharsetService
    {
        Task<List<CharsetDTO>> CharsetGetAll();
        Task<CharsetDTO> CharsetGetSingle(int id);
        Task<bool> CharsetInsert(CharsetDTO request);
        Task<bool> CharsetUpdate(CharsetDTO request);
        Task<bool> CharsetDelete(int id);
    }
}
