using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionLibrary.DTO;

namespace TransactionLibrary.IService
{
    public interface IPositionService
    {
        Task<List<PositionDTO>> PositionGetAll();
        Task<PositionDTO> PositionGetSingle(int id);
        Task<bool> PositionInsert(PositionDTO request);
        Task<bool> PositionUpdate(PositionDTO request);
        Task<bool> PositionDelete(int id);
    }
}
