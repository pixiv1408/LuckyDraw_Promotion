using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionLibrary.DTO;

namespace TransactionLibrary.IService
{
    public interface IRepeatScheduleService
    {
        Task<List<RepeatScheduleDTO>> ResGetAll();
        Task<RepeatScheduleDTO> ResGetSingle(int id);
        Task<bool> ResInsert(RepeatScheduleDTO request);
        Task<bool> ResUpdate(RepeatScheduleDTO request);
        Task<bool> ResDelete(int id);
    }
}
