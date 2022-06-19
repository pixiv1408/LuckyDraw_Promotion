using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionLibrary.DTO;

namespace TransactionLibrary.IService
{
    public interface IProgramSizeService
    {
        Task<List<ProgramSizeDTO>> ProgramSizeGetAll();
        Task<ProgramSizeDTO> ProgramSizeGetSingle(int id);
        Task<bool> ProgramSizeInsert(ProgramSizeDTO request);
        Task<bool> ProgramSizeUpdate(ProgramSizeDTO request);
        Task<bool> ProgramSizeDelete(int id);
    }
}
